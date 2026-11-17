using System;
using System.IO;
using System.Linq;
using Dreamy.Template.Gameplay;
using Dreamy.Template.Home;
using Dreamy.UI;
using Newtonsoft.Json.Linq;
using TMPro;
using UnityEditor;
using UnityEditor.AddressableAssets;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Dreamy.Template.Editor
{
    public static class M02Authoring
    {
        private const string Art = RecoveredAssetMigration.Root;
        private const string UI = "Assets/_Project/Art/BusFever/UI/";
        private const string PanelPath = "Assets/_Project/Prefabs/Panel/GameplayPanel.prefab";
        private static TMP_FontAsset Font => AssetDatabase.LoadAssetAtPath<TMP_FontAsset>(Art + "/textmesh pro/fonts/fonts & materials/Poppins-Bold SDF.asset");

        public static string Build()
        {
            // Migrate only this import's materials, preserving M01's already tuned art.
            var receipts = new[] { "recovered-import.json", "palette-import.json" }
                .SelectMany(file => (JArray)JObject.Parse(File.ReadAllText("docs/clone-plan/evidence/M02/" + file))["assets"])
                .Select(token => (string)token["target"]).Where(path => path.EndsWith(".mat"))
                .Distinct().Where(path => AssetDatabase.LoadAssetAtPath<Material>(path).shader.name == "Hidden/InternalErrorShader").ToArray();
            RecoveredAssetMigration.MigrateMaterials(receipts);
            var passengerMaterial = AssetDatabase.LoadAssetAtPath<Material>(Art + "/Material/Idle_passenger.mat");
            passengerMaterial.shader = Shader.Find("Universal Render Pipeline/Simple Lit");
            EditorUtility.SetDirty(passengerMaterial); AssetDatabase.SaveAssetIfDirty(passengerMaterial);
            PrepareWorld(); PrepareVehicle();
            SourceUiRebuilder.Rebuild("GamePanel", UI + "GamePanel.prefab");
            var root = Object.Instantiate(AssetDatabase.LoadAssetAtPath<GameObject>(UI + "GamePanel.prefab"));
            root.name = "GameplayPanel";
            try
            {
                root.SetActive(false);
                var panel = root.AddComponent<GameplayPanel>();
                Set(panel, "canvasGroup", root.GetComponent<CanvasGroup>() ?? root.AddComponent<CanvasGroup>());
                foreach (var group in root.GetComponentsInChildren<CanvasGroup>(true)) { group.alpha = 1; group.interactable = true; group.blocksRaycasts = true; }
                foreach (var node in root.GetComponentsInChildren<Transform>(true))
                    if (node.name.StartsWith("Effect_") || node.name == "RayCaster" || node.name == "Bubbles" || node.name == "FireTruckCD_Empty" || node.name == "BgBeach_Img") node.gameObject.SetActive(false);
                root.transform.Find("All_Empty").gameObject.SetActive(true);
                root.transform.Find("All_Empty/PlayArea").gameObject.SetActive(false);
                root.transform.Find("All_Empty").gameObject.AddComponent<SafeArea>();
                var top = root.transform.Find("All_Empty/Top_Empty"); top.gameObject.SetActive(true);
                Set(panel, "restartButton", top.Find("Btn_Replay").GetComponent<Button>());
                Set(panel, "pauseButton", top.Find("Btn_Pause").GetComponent<Button>());
                foreach (var button in top.GetComponentsInChildren<Button>(true)) button.gameObject.SetActive(true);
                var replayRect = (RectTransform)top.Find("Btn_Replay"); replayRect.anchoredPosition = new Vector2(120,-65); replayRect.localScale = Vector3.one * .85f;
                var pauseRect = (RectTransform)top.Find("Btn_Pause"); pauseRect.anchoredPosition = new Vector2(-120,-65); pauseRect.localScale = Vector3.one * .85f;
                top.Find("Level_Text").GetComponent<TMP_Text>().text = "Level 1";
                var props = root.transform.Find("All_Empty/Props"); props.gameObject.SetActive(true);
                props.localScale = Vector3.one * .85f;
                int index = 0;
                foreach (Transform prop in props)
                {
                    prop.gameObject.SetActive(true);
                    foreach (var button in prop.GetComponentsInChildren<Button>(true)) button.interactable = false;
                    foreach (var node in prop.GetComponentsInChildren<Transform>(true))
                        if (node.name == "RedDot_Img" || node.name == "GreenDot_Img" || node.name == "Green_Empty" || node.name == "Icon_Img") node.gameObject.SetActive(false);
                    var lockNode = prop.Find("Up_Empty/Lock_Img"); if (lockNode != null) lockNode.gameObject.SetActive(true);
                    prop.Find("Up_Empty/Level_Text").GetComponent<TMP_Text>().text = "Level " + new[] { 4, 8, 13 }[index++];
                }
                var status = Label(root.transform.Find("All_Empty"), "SessionStatus", new Vector2(.5f,.18f), new Vector2(920,100), 30);
                Set(panel, "status", status);
                var count = Label(root.transform.Find("All_Empty"), "PassengerCount", new Vector2(.5f,.86f), new Vector2(600,60), 26);
                Set(panel, "passengerCount", count);
                var homeLabel = Label(root.transform.Find("All_Empty"), "Home", new Vector2(.5f,.025f), new Vector2(240,70), 28);
                homeLabel.text = "Home"; homeLabel.raycastTarget = true;
                var home = homeLabel.gameObject.AddComponent<Button>(); home.targetGraphic = homeLabel;
                Set(panel, "homeButton", home);
                Set(panel, "sceneryPrefab", AssetDatabase.LoadAssetAtPath<GameObject>(UI + "GameplayWorld.prefab"));
                Set(panel, "vehiclePrefab", AssetDatabase.LoadAssetAtPath<GameObject>(UI + "PuzzleVehicle.prefab"));
                var serialized = new SerializedObject(panel);
                var passengers = serialized.FindProperty("passengerPrefabs"); passengers.arraySize = 3;
                var materials = serialized.FindProperty("vehicleMaterials"); materials.arraySize = 3;
                var colors = new[] { "blue", "red", "yellow" };
                for (int i = 0; i < 3; i++)
                {
                    passengers.GetArrayElementAtIndex(i).objectReferenceValue = AssetDatabase.LoadAssetAtPath<GameObject>(Art + "/busjam/game/bundleables/busandpassenger/passenger_" + colors[i] + ".prefab");
                    materials.GetArrayElementAtIndex(i).objectReferenceValue = AssetDatabase.LoadAssetAtPath<Material>(Art + "/Material/Car_" + colors[i] + "_new" + (i == 0 ? "_0" : "") + ".mat");
                }
                serialized.ApplyModifiedPropertiesWithoutUndo();
                foreach (var text in root.GetComponentsInChildren<TMP_Text>(true))
                {
                    text.font = Font; text.fontSharedMaterial = AssetDatabase.LoadAssetAtPath<Material>(Art + "/Material/Poppins-Bold SDF_OutlineBlack3.mat");
                    text.raycastTarget = text == homeLabel;
                }
                PrefabUtility.SaveAsPrefabAsset(root, PanelPath);
            }
            finally { Object.DestroyImmediate(root); }
            WireHome();
            var settings = AddressableAssetSettingsDefaultObject.Settings;
            settings.CreateOrMoveEntry(AssetDatabase.AssetPathToGUID(PanelPath), settings.DefaultGroup).address = Address.GameplayPanel;
            settings.CreateOrMoveEntry(AssetDatabase.AssetPathToGUID(PauseSkinAuthoring.Path), settings.DefaultGroup).address = Address.PauseSettingsPanel;
            EditorUtility.SetDirty(settings); AssetDatabase.SaveAssetIfDirty(settings);
            // MainScene hosts Home and Gameplay roots; no extra gameplay scene.
            return "M02 source world, interactive vehicles, GamePanel, Play binding and Addressables authored for MainScene.";
        }

        private static void PrepareWorld()
        {
            var world = Object.Instantiate(AssetDatabase.LoadAssetAtPath<GameObject>(Art + "/busjam/game/bundleables/prefabs/GameScene.prefab"));
            try
            {
                world.name = "GameplayWorld";
                foreach (var particle in world.GetComponentsInChildren<ParticleSystem>(true)) particle.gameObject.SetActive(false);
                foreach (var node in world.GetComponentsInChildren<Transform>(true))
                {
                    if (node.name == "Plane_onlyshadow") node.GetComponent<Renderer>().enabled = false;
                    if (node.name == "Car_P_02" || node.name == "Text (TMP)") node.gameObject.SetActive(false);
                }
                var background = world.GetComponentsInChildren<MeshRenderer>(true).First(r => r.name == "BG01_split01");
                background.sharedMaterial.shader = Shader.Find("Universal Render Pipeline/Unlit");
                EditorUtility.SetDirty(background.sharedMaterial); AssetDatabase.SaveAssetIfDirty(background.sharedMaterial);
                BuildRoad(world.transform);
                foreach (var camera in world.GetComponentsInChildren<Camera>(true))
                {
                    camera.cullingMask = -1; camera.gameObject.AddComponent<PhysicsRaycaster>();
                }
                // Initial tutorial opens the three extra ordinary slots; VIP remains reserved.
                foreach (var node in world.GetComponentsInChildren<Transform>(true))
                    if (node.name.StartsWith("PS_AD_"))
                    {
                        node.gameObject.SetActive(true);
                        foreach (var child in node.GetComponentsInChildren<Transform>(true))
                            if (child.name == "Add" || child.name == "Car_P_AD" || child.name.Contains("Lock")) child.gameObject.SetActive(false);
                        var slot = node.GetComponentsInChildren<Transform>(true).FirstOrDefault(t => t.name == "Car_P2");
                        if (slot != null) slot.gameObject.SetActive(true);
                    }
                PrefabUtility.SaveAsPrefabAsset(world, UI + "GameplayWorld.prefab");
            }
            finally { Object.DestroyImmediate(world); }
        }

        private static void PrepareVehicle()
        {
            var vehicle = Object.Instantiate(AssetDatabase.LoadAssetAtPath<GameObject>(Art + "/busjam/game/bundleables/busandpassenger/bus_normal_10.prefab"));
            try
            {
                vehicle.name = "PuzzleVehicle";
                foreach (var animator in vehicle.GetComponentsInChildren<Animator>(true)) Object.DestroyImmediate(animator);
                foreach (var body in vehicle.GetComponentsInChildren<Rigidbody>(true)) Object.DestroyImmediate(body);
                foreach (var collider in vehicle.GetComponentsInChildren<Collider>(true)) Object.DestroyImmediate(collider);
                foreach (var particle in vehicle.GetComponentsInChildren<ParticleSystem>(true)) particle.gameObject.SetActive(false);
                var box = vehicle.AddComponent<BoxCollider>(); box.center = new Vector3(0,.15f,0); box.size = new Vector3(.31f,.3f,.67f);
                vehicle.AddComponent<VehiclePointerTarget>();
                var label = new GameObject("Capacity", typeof(TextMeshPro)).GetComponent<TextMeshPro>(); label.transform.SetParent(vehicle.transform, false);
                label.transform.localPosition = new Vector3(.22f,.36f,0); label.transform.rotation = Quaternion.Euler(55,0,0);
                label.font = Font; label.fontSize = 2; label.rectTransform.sizeDelta = new Vector2(.4f,.3f); label.alignment = TextAlignmentOptions.Center;
                PrefabUtility.SaveAsPrefabAsset(vehicle, UI + "PuzzleVehicle.prefab");
            }
            finally { Object.DestroyImmediate(vehicle); }
        }

        private static void WireHome()
        {
            const string path = "Assets/_Project/Prefabs/Panel/HomePanel.prefab";
            var root = PrefabUtility.LoadPrefabContents(path);
            try
            {
                var play = root.GetComponentsInChildren<Button>(true).Single(b => b.name == "Play_Btn");
                Set(root.GetComponent<HomePanel>(), "playButton", play);
                var availability = root.GetComponent<FeatureAvailabilityView>();
                var serialized = new SerializedObject(availability); var buttons = serialized.FindProperty("buttons");
                for (int i = buttons.arraySize - 1; i >= 0; i--)
                    if (buttons.GetArrayElementAtIndex(i).objectReferenceValue == play) { buttons.GetArrayElementAtIndex(i).objectReferenceValue = null; buttons.DeleteArrayElementAtIndex(i); }
                serialized.ApplyModifiedPropertiesWithoutUndo(); PrefabUtility.SaveAsPrefabAsset(root, path);
            }
            finally { PrefabUtility.UnloadPrefabContents(root); }
        }

        private static void BuildRoad(Transform parent)
        {
            // The recovered scene has runtime-generated track geometry, absent from the exported prefab.
            // Reconstruct editable mesh geometry; source-accurate spline/timing remains an audit gate.
            const int segments = 96;
            var vertices = new Vector3[(segments + 1) * 2]; var triangles = new int[segments * 6];
            for (int i = 0; i <= segments; i++)
            {
                float angle = i * Mathf.PI * 2 / segments;
                vertices[i*2] = new Vector3(Mathf.Cos(angle)*1.5f, .04f, PassengerTrack.CenterZ+Mathf.Sin(angle)*1.13f);
                vertices[i*2+1] = new Vector3(Mathf.Cos(angle)*.8f, .04f, PassengerTrack.CenterZ+Mathf.Sin(angle)*.47f);
                if (i == segments) continue;
                int t = i*6, v = i*2;
                triangles[t] = v; triangles[t+1] = v+2; triangles[t+2] = v+1;
                triangles[t+3] = v+1; triangles[t+4] = v+2; triangles[t+5] = v+3;
            }
            var mesh = new Mesh { name = "ObservedPassengerLoop", vertices = vertices, triangles = triangles };
            mesh.RecalculateNormals(); mesh.RecalculateBounds();
            string path = UI + "PassengerLoop.asset";
            var existing = AssetDatabase.LoadAssetAtPath<Mesh>(path);
            if (existing == null) AssetDatabase.CreateAsset(mesh, path);
            else { EditorUtility.CopySerialized(mesh,existing); Object.DestroyImmediate(mesh); mesh = existing; EditorUtility.SetDirty(existing); AssetDatabase.SaveAssetIfDirty(existing); }
            string materialPath = UI + "PassengerRoad.mat";
            var material = AssetDatabase.LoadAssetAtPath<Material>(materialPath);
            if (material == null) { material = new Material(Shader.Find("Universal Render Pipeline/Unlit")); AssetDatabase.CreateAsset(material, materialPath); }
            material.SetColor("_BaseColor", new Color(.46f,.46f,.52f)); material.SetFloat("_Cull",0);
            EditorUtility.SetDirty(material); AssetDatabase.SaveAssetIfDirty(material);
            var road = new GameObject("ObservedPassengerLoop", typeof(MeshFilter),typeof(MeshRenderer)); road.transform.SetParent(parent,false);
            road.GetComponent<MeshFilter>().sharedMesh = mesh; road.GetComponent<MeshRenderer>().sharedMaterial = material;
            string borderPath = UI + "PassengerRoadBorder.mat";
            var border = AssetDatabase.LoadAssetAtPath<Material>(borderPath);
            if (border == null) { border = new Material(Shader.Find("Universal Render Pipeline/Unlit")); AssetDatabase.CreateAsset(border, borderPath); }
            border.SetColor("_BaseColor",new Color(.94f,.95f,1)); EditorUtility.SetDirty(border); AssetDatabase.SaveAssetIfDirty(border);
            for (int ring = 0; ring < 2; ring++)
            {
                var line = new GameObject(ring == 0 ? "OuterKerb" : "InnerKerb",typeof(LineRenderer)).GetComponent<LineRenderer>();
                line.transform.SetParent(parent,false); line.useWorldSpace = false; line.loop = ring != 0; line.positionCount = segments;
                line.sharedMaterial = border; line.widthMultiplier = .045f;
                for (int i = 0; i < segments; i++)
                { float angle = ring == 0 ? Mathf.PI*1.5f+.24f+i*(Mathf.PI*2-.48f)/(segments-1) : i*Mathf.PI*2/segments;
                    line.SetPosition(i,new Vector3(Mathf.Cos(angle)*(ring == 0 ? 1.5f : .8f), .055f, PassengerTrack.CenterZ+Mathf.Sin(angle)*(ring == 0 ? 1.13f : .47f))); }
            }
            BuildIncoming(parent,material,border);
        }

        public static string RebuildRoad()
        {
            var root = PrefabUtility.LoadPrefabContents(UI + "GameplayWorld.prefab");
            try
            {
                foreach (var name in new[] { "ObservedPassengerLoop", "OuterKerb", "InnerKerb", "PassengerIncoming", "IncomingKerb0", "IncomingKerb1", "BoardingJunction" })
                {
                    var old = root.transform.Find(name);
                    if (old != null) Object.DestroyImmediate(old.gameObject);
                }
                BuildRoad(root.transform);
                PrefabUtility.SaveAsPrefabAsset(root,UI + "GameplayWorld.prefab");
            }
            finally { PrefabUtility.UnloadPrefabContents(root); }
            return "Updated only loop, incoming branch and boarding junction in the existing world prefab.";
        }

        private static void BuildIncoming(Transform parent, Material roadMaterial, Material border)
        {
            const int segments = 40;
            var vertices = new Vector3[(segments+1)*2]; var triangles = new int[segments*6];
            var edges = new LineRenderer[2];
            for(int lane=0;lane<2;lane++)
            {
                edges[lane] = new GameObject("IncomingKerb"+lane,typeof(LineRenderer)).GetComponent<LineRenderer>();
                edges[lane].transform.SetParent(parent,false); edges[lane].useWorldSpace=false;
                edges[lane].positionCount=segments+1; edges[lane].widthMultiplier=.045f; edges[lane].sharedMaterial=border;
            }
            for(int i=0;i<=segments;i++)
            {
                float distance=i*3.4f/segments;
                var center=PassengerTrack.Incoming(distance);
                var tangent=PassengerTrack.Incoming(Mathf.Min(distance+.01f,3.4f))-PassengerTrack.Incoming(Mathf.Max(0,distance-.01f));
                var normal=Vector3.Cross(Vector3.up,tangent.normalized)*.34f;
                for(int lane=0;lane<2;lane++)
                {
                    vertices[i*2+lane]=center+(lane==0?normal:-normal);
                    edges[lane].SetPosition(i,vertices[i*2+lane]);
                }
                if(i==segments)continue;
                int v=i*2,t=i*6; triangles[t]=v;triangles[t+1]=v+2;triangles[t+2]=v+1;
                triangles[t+3]=v+1;triangles[t+4]=v+2;triangles[t+5]=v+3;
            }
            var mesh=new Mesh{name="PassengerIncoming",vertices=vertices,triangles=triangles};mesh.RecalculateNormals();
            // The branch meets the ring: do not draw its curb across the shared road surface.
            foreach(var edge in edges)
            {
                var positions=new Vector3[edge.positionCount];edge.GetPositions(positions);
                var visible=positions.Skip(8).ToArray();edge.positionCount=visible.Length;edge.SetPositions(visible);
            }
            const string path=UI+"PassengerIncoming.asset";
            var existing=AssetDatabase.LoadAssetAtPath<Mesh>(path);
            if(existing==null)AssetDatabase.CreateAsset(mesh,path);
            else { EditorUtility.CopySerialized(mesh,existing);Object.DestroyImmediate(mesh);mesh=existing;EditorUtility.SetDirty(mesh);AssetDatabase.SaveAssetIfDirty(mesh); }
            var road=new GameObject("PassengerIncoming",typeof(MeshFilter),typeof(MeshRenderer));road.transform.SetParent(parent,false);
            road.GetComponent<MeshFilter>().sharedMesh=mesh;road.GetComponent<MeshRenderer>().sharedMaterial=roadMaterial;
            var junction=GameObject.CreatePrimitive(PrimitiveType.Cube);junction.name="BoardingJunction";
            junction.transform.SetParent(parent,false);junction.transform.localPosition=new Vector3(0,.025f,PassengerTrack.CenterZ-1.04f);
            junction.transform.localScale=new Vector3(.82f,.03f,.3f);junction.GetComponent<Renderer>().sharedMaterial=roadMaterial;
            Object.DestroyImmediate(junction.GetComponent<Collider>());
        }

        private static TMP_Text Label(Transform parent, string name, Vector2 anchor, Vector2 size, float fontSize)
        {
            var label = new GameObject(name, typeof(RectTransform), typeof(TextMeshProUGUI)).GetComponent<TMP_Text>();
            label.transform.SetParent(parent, false); label.rectTransform.anchorMin = label.rectTransform.anchorMax = anchor;
            label.rectTransform.sizeDelta = size; label.font = Font; label.fontSize = fontSize;
            label.alignment = TextAlignmentOptions.Center; label.raycastTarget = false; return label;
        }
        private static void Set(Object target, string field, Object value)
        {
            var serialized = new SerializedObject(target); serialized.FindProperty(field).objectReferenceValue = value;
            serialized.ApplyModifiedPropertiesWithoutUndo();
        }
    }
}
