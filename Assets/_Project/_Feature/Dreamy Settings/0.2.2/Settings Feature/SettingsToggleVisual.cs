using UnityEngine;
using UnityEngine.UI;

namespace Dreamy.Feature.Settings.Integration
{
    /// <summary>Source skin only. The Settings presenter remains the setting authority.</summary>
    [RequireComponent(typeof(Toggle))]
    public sealed class SettingsToggleVisual : MonoBehaviour
    {
        [SerializeField] private GameObject onVisual;
        [SerializeField] private GameObject offVisual;
        private Toggle toggle;

        private void Awake() => toggle = GetComponent<Toggle>();
        private void OnEnable()
        {
            if (toggle == null) toggle = GetComponent<Toggle>();
            toggle.onValueChanged.AddListener(Render);
            Render(toggle.isOn);
        }
        private void OnDisable() => toggle.onValueChanged.RemoveListener(Render);
        public void Refresh() => Render(GetComponent<Toggle>().isOn);
        private void Render(bool enabled)
        {
            if (onVisual != null) onVisual.SetActive(enabled);
            if (offVisual != null) offVisual.SetActive(!enabled);
        }
    }
}
