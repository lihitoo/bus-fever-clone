using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Dreamy.Template.Home
{
    /// <summary>Explicit development availability for destinations scheduled after M01.</summary>
    public sealed class FeatureAvailabilityView : MonoBehaviour
    {
        [SerializeField] private Button[] buttons;
        [SerializeField] private TMP_Text message;

        private void OnEnable()
        {
            foreach (var button in buttons)
                if (button != null) button.onClick.AddListener(ShowAvailability);
        }

        private void OnDisable()
        {
            foreach (var button in buttons)
                if (button != null) button.onClick.RemoveListener(ShowAvailability);
        }

        private void ShowAvailability()
        {
            if (message != null) message.text = "Feature scheduled in the next milestones";
        }
    }
}
