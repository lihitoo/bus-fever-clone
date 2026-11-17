using System;
using System.Collections.Generic;
using Dreamy.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Dreamy.Template.Gameplay
{
    public sealed class GameplayPanel : UIPanel, IGameplayView, IGameplayTutorialView, IGameplayFxView
    {
        private Dreamy.Feedback.IVfxService effects;
        private readonly List<Dreamy.Feedback.FeedbackHandle> effectHandles = new();
        public void BindEffects(Dreamy.Feedback.IVfxService value) => effects = value;
        [SerializeField] private GameObject sceneryPrefab;
        [SerializeField] private GameObject vehiclePrefab;
        [SerializeField] private GameObject[] passengerPrefabs;
        [SerializeField] private Material[] vehicleMaterials;
        [SerializeField] private Button restartButton;
        [SerializeField] private Button pauseButton;
        [SerializeField] private Button homeButton;
        [SerializeField] private TMP_Text status;
        [SerializeField] private TMP_Text passengerCount;
        [SerializeField] private RectTransform tutorialHand;
        [SerializeField] private GameObject tutorialCard;
        [SerializeField] private Material tutorialOutlineMaterial;
        private string tutorialTarget;
        private float tutorialTime;
        private readonly Dictionary<string, VehicleVisual> vehicles = new();
        private readonly List<PassengerVisual> passengers = new();
        private GameObject world;
        private readonly List<Behaviour> borrowedSceneComponents = new();
        private Transform[] docks;
        private bool paused;
        private float loopTime;
        private int lastPassengerCount = -1;
        private PuzzleMotionProfile motion;
        private static readonly Color[] Colors = { new(.03f,.55f,1), new(1,.08f,.12f), new(1,.72f,.02f),
            new(.65f,.15f,1),new(1,.36f,.02f),new(1,.12f,.65f),new(.12f,.85f,.1f) };
        public override bool CanBack => false;
        public override bool CanCache => false;
        public event Action<string> VehicleRequested;
        public event Action RestartRequested;
        public event Action PauseRequested;
        public event Action HomeRequested;
        public event Action<float> Tick;

        private sealed class VehicleVisual
        {
            public Transform Transform;
            public TMP_Text Count;
            public VehicleState State;
            public Vector3 Start;
            public Vector3 Target;
            public Vector3 Exit;
            public Quaternion InitialRotation;
            public float Elapsed;
            public int Remaining = -1;
            public GameObject TutorialOutline;
        }

        private sealed class PassengerVisual
        {
            public GameObject Object;
            public VehicleColor Color;
            public Transform Destination;
            public Vector3 Start;
            public float Elapsed;
            public bool Positioned;
        }

        private void OnEnable()
        {
            restartButton.onClick.AddListener(Restart);
            pauseButton.onClick.AddListener(Pause);
            homeButton.onClick.AddListener(Home);
        }
        protected override void OnDisable()
        {
            restartButton.onClick.RemoveListener(Restart);
            pauseButton.onClick.RemoveListener(Pause);
            homeButton.onClick.RemoveListener(Home);
            Clear();
            base.OnDisable();
        }
        private void Restart() => RestartRequested?.Invoke();
        private void Pause() => PauseRequested?.Invoke();
        private void Home() => HomeRequested?.Invoke();

        public void Initialize(PuzzleDefinition definition, IReadOnlyList<VehicleReadModel> models)
        {
            Clear(); paused = false; loopTime = 0; lastPassengerCount = -1; motion = definition.Motion;
            passengerCount.enabled = false; // Internal readout remains available to the harness, outside the native HUD.
            homeButton.gameObject.SetActive(false); // Native Home action belongs to the Pause panel.
            foreach (var text in GetComponentsInChildren<TMP_Text>(true))
                if (text.name == "Level_Text" && text.transform.parent.name == "Top_Empty") text.text = "Level " + definition.LevelNumber;
            world = Instantiate(sceneryPrefab);
            world.name = "PuzzleSessionWorld";
            foreach (var renderer in world.GetComponentsInChildren<Renderer>(true))
                if (renderer.name == "Car_P_Shadow") renderer.enabled = false;
            foreach (var camera in FindObjectsByType<Camera>(FindObjectsSortMode.None))
                if (camera.enabled && camera.gameObject.scene == gameObject.scene && !camera.transform.IsChildOf(world.transform))
                { borrowedSceneComponents.Add(camera); camera.enabled = false; }
            foreach (var light in FindObjectsByType<Light>(FindObjectsSortMode.None))
                if (light.enabled && light.gameObject.scene == gameObject.scene && !light.transform.IsChildOf(world.transform))
                { borrowedSceneComponents.Add(light); light.enabled = false; }
            docks = new Transform[7];
            foreach (var node in world.GetComponentsInChildren<Transform>(true))
            {
                int index = node.name switch { "PS_1" => 0, "PS_2" => 1, "PS_3" => 2, "PS_4" => 3,
                    "PS_AD_1" => 4, "PS_AD_2" => 5, "PS_AD_3" => 6, _ => -1 };
                if (index >= 0) docks[index] = node;
            }
            for (int i = 0; i < docks.Length; i++)
            {
                bool available = i < definition.ParkingCount;
                foreach (var node in docks[i].GetComponentsInChildren<Transform>(true))
                {
                    // The source AD slot also contains a nested ordinary slot and its shadow.
                    // Toggle the whole visual branch so hidden outlines do not leave black quads.
                    if (node.name == "Car_P2") node.gameObject.SetActive(available);
                    if (node.name == "Car_P_AD" || node.name == "Add") node.gameObject.SetActive(!available);
                }
            }
            var boardRotation = Quaternion.Euler(0, definition.BoardRotation, 0);
            foreach (var model in models)
            {
                var d = model.Definition;
                var instance = Instantiate(vehiclePrefab, world.transform);
                instance.name = d.Id;
                instance.transform.localScale = Vector3.one * 1.25f;
                var local = new Vector3((d.X + d.Width * .5f - definition.Columns * .5f) * definition.CellSize, 0,
                    (d.Y + d.Height * .5f - definition.Rows * .5f) * definition.CellSize);
                instance.transform.position = new Vector3(0, 0, 10.0f) + boardRotation * local;
                instance.transform.rotation = boardRotation * Quaternion.Euler(0, (int)d.Direction * 90, 0);
                foreach (var renderer in instance.GetComponentsInChildren<MeshRenderer>(true))
                    if (renderer.sharedMaterial != null && renderer.sharedMaterial.name.StartsWith("Car_"))
                        renderer.sharedMaterial = vehicleMaterials[(int)d.Color];
                instance.GetComponent<VehiclePointerTarget>().Bind(d.Id, id => VehicleRequested?.Invoke(id));
                var label = instance.GetComponentInChildren<TextMeshPro>(true);
                GameObject outline = null;
                if (tutorialOutlineMaterial != null)
                {
                    var body = Array.Find(instance.GetComponentsInChildren<MeshFilter>(true), filter => filter.name == "Bus_001");
                    if (body != null)
                    {
                        outline = new GameObject("TutorialVehicleOutline", typeof(MeshFilter), typeof(MeshRenderer));
                        outline.transform.SetParent(body.transform, false);
                        outline.GetComponent<MeshFilter>().sharedMesh = body.sharedMesh;
                        outline.GetComponent<MeshRenderer>().sharedMaterial = tutorialOutlineMaterial;
                        outline.SetActive(false);
                    }
                }
                vehicles.Add(d.Id, new VehicleVisual { Transform = instance.transform, Count = label,
                    State = VehicleState.Board, InitialRotation = instance.transform.rotation,
                    Exit = instance.transform.rotation * Vector3.forward, TutorialOutline = outline });
            }
            foreach (var color in definition.Passengers)
            {
                var passenger = Instantiate(passengerPrefabs[(int)color], world.transform);
                passenger.name = "Passenger-" + passengers.Count;
                var block = new MaterialPropertyBlock(); block.SetColor("_BaseColor", Colors[(int)color]);
                foreach (var renderer in passenger.GetComponentsInChildren<MeshRenderer>(true))
                    if (!renderer.name.Contains("Shadow")) renderer.SetPropertyBlock(block);
                passengers.Add(new PassengerVisual { Object = passenger, Color = color });
            }
        }

        public void Render(IReadOnlyList<VehicleReadModel> models, int remainingPassengers, bool complete)
        {
            foreach (var model in models)
            {
                var visual = vehicles[model.Definition.Id];
                if (visual.Count != null && (visual.Remaining != model.Remaining || visual.State != model.State))
                {
                    visual.Remaining = model.Remaining;
                    visual.Count.text = model.Remaining.ToString();
                    visual.Count.gameObject.SetActive(model.State == VehicleState.Parked || model.State == VehicleState.Departing);
                }
                if (visual.State == model.State) continue;
                visual.State = model.State; visual.Elapsed = 0; visual.Start = visual.Transform.position;
                if ((model.State == VehicleState.Driving || model.State == VehicleState.Departing) && effects != null)
                {
                    effectHandles.RemoveAll(handle => !handle.IsRunning);
                    effectHandles.Add(effects.Play("bus.departure", visual.Start));
                }
                if (model.State == VehicleState.Driving) visual.Target = docks[model.Slot].position + Vector3.up * .03f;
                if (model.State == VehicleState.Parked)
                {
                    visual.Transform.position = visual.Target;
                    visual.Transform.rotation = docks[model.Slot].rotation;
                }
                if (model.State == VehicleState.Departing) visual.Target = visual.Start + new Vector3(-3.5f, 0, 1.2f);
                if (model.State == VehicleState.Complete) visual.Transform.gameObject.SetActive(false);
            }
            if (lastPassengerCount != remainingPassengers)
            {
                lastPassengerCount = remainingPassengers;
                passengerCount.text = remainingPassengers + " passengers";
            }
            if (complete) ShowMessage("");
        }

        public void BoardPassenger(string vehicleId, VehicleColor color)
        {
            var passenger = passengers.Find(p => p.Color == color && p.Object.activeSelf && p.Destination == null);
            if (passenger == null) throw new InvalidOperationException("Passenger presentation diverged from session supply.");
            passenger.Destination = vehicles[vehicleId].Transform;
            passenger.Start = passenger.Object.transform.position;
            passenger.Elapsed = 0;
        }

        private void Update()
        {
            if (world == null || paused) return;
            float delta = Time.deltaTime;
            Tick?.Invoke(delta);
            loopTime += delta * motion.LoopSpeed;
            int waitingIndex = 0;
            for (int i = 0; i < passengers.Count; i++)
            {
                var passenger = passengers[i];
                if (!passenger.Object.activeSelf) continue;
                if (passenger.Destination != null)
                {
                    passenger.Elapsed += delta;
                    float t = Mathf.Clamp01(passenger.Elapsed / motion.BoardingDuration);
                    passenger.Object.transform.position = Vector3.Lerp(passenger.Start, passenger.Destination.position, t) + Vector3.up * Mathf.Sin(t * Mathf.PI) * .12f;
                    if (t >= 1) passenger.Object.SetActive(false);
                    continue;
                }
                // Four lanes fit one circuit; overflow waits on the incoming branch.
                // Never wrap the complete supply onto the same loop and overlap multiple rows.
                float rowIndex = waitingIndex / 4;
                float row = (waitingIndex++ % 4) - 1.5f;
                float angle = loopTime - rowIndex * (Mathf.PI * 2 / PassengerTrack.CircuitRows);
                var target = PassengerTrack.Loop(angle, row);
                if (rowIndex >= PassengerTrack.CircuitRows)
                    target = PassengerTrack.Incoming((rowIndex - PassengerTrack.CircuitRows) * .105f, row);
                var previous = passenger.Object.transform.position;
                passenger.Object.transform.position = passenger.Positioned ? Vector3.Lerp(previous, target, 1 - Mathf.Exp(-delta * 12)) : target;
                var direction = rowIndex >= PassengerTrack.CircuitRows
                    ? PassengerTrack.Incoming((rowIndex - PassengerTrack.CircuitRows) * .105f + .02f, row) - target
                    : new Vector3(-Mathf.Sin(angle), 0, Mathf.Cos(angle));
                if (direction.sqrMagnitude > .000001f) passenger.Object.transform.rotation = Quaternion.LookRotation(direction);
                passenger.Positioned = true;
            }
            foreach (var v in vehicles.Values)
            {
                if (v.State != VehicleState.Driving && v.State != VehicleState.Departing) continue;
                v.Elapsed += delta;
                float t = Mathf.Clamp01(v.Elapsed / motion.TravelDuration);
                if (v.State == VehicleState.Driving)
                {
                    // Exit along the validated heading before turning into the parking lane.
                    Vector3 a = v.Start + v.Exit * .7f;
                    Vector3 b = new Vector3(v.Target.x, v.Target.y, 12.6f);
                    float u = 1 - t;
                    var position = u*u*u*v.Start + 3*u*u*t*a + 3*u*t*t*b + t*t*t*v.Target;
                    Vector3 forward = position - v.Transform.position;
                    if (forward.sqrMagnitude > .000001f) v.Transform.rotation = Quaternion.LookRotation(forward.normalized);
                    v.Transform.position = position;
                }
                else v.Transform.position = Vector3.Lerp(v.Start, v.Target, t * t * (3 - 2 * t));
            }
        }
        public void SetPaused(bool value)
        {
            paused = value;
            if (value) StopEffects();
        }

        private void StopEffects()
        {
            foreach (var handle in effectHandles) handle.Stop();
            effectHandles.Clear();
        }
        public void RenderTutorial(string vehicleId)
        {
            tutorialTarget = vehicleId; tutorialTime = 0;
            foreach (var pair in vehicles)
                if (pair.Value.TutorialOutline != null) pair.Value.TutorialOutline.SetActive(pair.Key == vehicleId);
            if (tutorialHand != null) tutorialHand.gameObject.SetActive(vehicleId != null);
            if (tutorialCard != null) tutorialCard.SetActive(vehicleId != null);
        }
        private void LateUpdate()
        {
            if (tutorialTarget == null || tutorialHand == null || world == null) return;
            if (!vehicles.TryGetValue(tutorialTarget,out var target) || target.Transform == null)
            { tutorialHand.gameObject.SetActive(false); return; }
            var camera = world.GetComponentInChildren<Camera>();
            Vector2 local;
            var canvas = tutorialHand.GetComponentInParent<Canvas>();
            var screen = camera.WorldToScreenPoint(target.Transform.position + Vector3.up * .3f);
            if (!paused) tutorialTime += Time.unscaledDeltaTime;
            if (screen.z <= 0) { tutorialHand.gameObject.SetActive(false); return; }
            tutorialHand.gameObject.SetActive(true);
            RectTransformUtility.ScreenPointToLocalPointInRectangle((RectTransform)tutorialHand.parent,screen,
                canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : canvas.worldCamera,out local);
            tutorialHand.anchoredPosition = local + new Vector2(35,-65 + Mathf.Sin(tutorialTime * 5)*12);
            tutorialHand.localScale = Vector3.one * (1 + Mathf.Sin(tutorialTime * 5)*.06f);
        }
        public void ShowMessage(string message) => status.text = message;
        public void Clear()
        {
            StopEffects();
            foreach (var component in borrowedSceneComponents) if (component != null) component.enabled = true;
            borrowedSceneComponents.Clear();
            if (world != null) { world.SetActive(false); Destroy(world); }
            world = null; vehicles.Clear(); passengers.Clear();
            RenderTutorial(null);
        }
    }
}
