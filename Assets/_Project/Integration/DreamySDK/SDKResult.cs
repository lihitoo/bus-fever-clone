namespace Dreamy.SDK
{
    public enum SDKStatus { Unavailable, Completed, Cancelled, Failed }

    public readonly struct SDKResult
    {
        public SDKResult(SDKStatus status, string message, int restoredEntitlements = 0)
        {
            Status = status;
            Message = message;
            RestoredEntitlements = restoredEntitlements;
        }
        public SDKStatus Status { get; }
        public string Message { get; }
        public int RestoredEntitlements { get; }
        public bool IsTestResult => true;
    }
}
