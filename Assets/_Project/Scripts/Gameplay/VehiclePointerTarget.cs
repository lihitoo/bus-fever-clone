using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Dreamy.Template.Gameplay
{
    public sealed class VehiclePointerTarget : MonoBehaviour, IPointerClickHandler
    {
        private string vehicleId;
        private Action<string> selected;
        public void Bind(string id, Action<string> onSelected) { vehicleId = id; selected = onSelected; }
        public void OnPointerClick(PointerEventData eventData) => selected?.Invoke(vehicleId);
        private void OnDestroy() => selected = null;
    }
}
