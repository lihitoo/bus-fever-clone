using UnityEngine;

namespace Dreamy.Template.Gameplay
{
    /// <summary>Reference scene geometry shared by the editable road and passenger presentation.</summary>
    public static class PassengerTrack
    {
        public const int CircuitRows = 60;
        public const float CenterZ = 14.95f;
        public static Vector3 Loop(float angle, float lane = 0)
            => new(Mathf.Cos(angle) * (1.18f + lane * .075f), .055f,
                CenterZ + Mathf.Sin(angle) * (.76f + lane * .065f));

        public static Vector3 Incoming(float distance, float lane = 0)
        {
            float t = Mathf.Clamp01(distance / 3.4f);
            var start = Loop(0, lane);
            var control = new Vector3(start.x, start.y, CenterZ + 1.8f);
            var end = new Vector3(2.1f + lane * .075f, start.y, CenterZ + 3.4f);
            return (1-t)*(1-t)*start + 2*(1-t)*t*control + t*t*end + Vector3.forward * Mathf.Max(0,distance-3.4f);
        }
    }
}
