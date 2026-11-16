using System;
using Dreamy.UI;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Dreamy.Template.Home
{
    public sealed class HomePanel : UIPanel, IHomeView
    {
        [Header("Navigation")]
        [SerializeField] private Button shopButton;
        [SerializeField] private Button settingsButton;
        [SerializeField] private Button demoButton;
        [SerializeField] private GameObject backdropPrefab;
        private GameObject backdropInstance;

        public override bool CanBack => false;
        public override bool CanCache => true;

        public event Action<HomeDestination> DestinationRequested;
        public void RenderLevel(int level)
        {
            if (backdropInstance == null) return;
            foreach (var label in backdropInstance.GetComponentsInChildren<TextMeshPro>(true))
                if (label.name == "LEVEL") label.text = "LEVEL  " + level;
        }

        private void OnEnable()
        {
            if (backdropPrefab != null && backdropInstance == null)
            {
                backdropInstance = Instantiate(backdropPrefab);
                foreach (var animator in backdropInstance.GetComponentsInChildren<Animator>(true))
                    foreach (var parameter in animator.parameters)
                    {
                        if (parameter.name == "Stay" && parameter.type == AnimatorControllerParameterType.Trigger)
                            animator.SetTrigger(parameter.nameHash);
                        if (parameter.name == "Stay" && parameter.type == AnimatorControllerParameterType.Bool)
                            animator.SetBool(parameter.nameHash, true);
                        if (parameter.name == "In" && parameter.type == AnimatorControllerParameterType.Trigger)
                            animator.SetTrigger(parameter.nameHash);
                    }
                foreach (var renderer in backdropInstance.GetComponentsInChildren<SkinnedMeshRenderer>(true))
                    renderer.updateWhenOffscreen = true;
            }
            shopButton?.onClick.AddListener(RequestShop);
            settingsButton?.onClick.AddListener(RequestSettings);
            if (demoButton != null)
            {
                demoButton.onClick.AddListener(RequestDemo);
            }
        }

        protected override void OnDisable()
        {
            if (backdropInstance != null) Destroy(backdropInstance);
            backdropInstance = null;
            shopButton?.onClick.RemoveListener(RequestShop);
            settingsButton?.onClick.RemoveListener(RequestSettings);
            demoButton?.onClick.RemoveListener(RequestDemo);
            base.OnDisable();
        }

        public void SetNavigationInteractable(bool interactable)
        {
            if (shopButton != null) shopButton.interactable = interactable;
            if (settingsButton != null) settingsButton.interactable = interactable;
            if (demoButton != null) demoButton.interactable = interactable;
        }

        private void RequestDemo() => DestinationRequested?.Invoke(HomeDestination.Demo);

        private void RequestShop() => DestinationRequested?.Invoke(HomeDestination.Shop);
        private void RequestSettings() => DestinationRequested?.Invoke(HomeDestination.Settings);
    }
}
