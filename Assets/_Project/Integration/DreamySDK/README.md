# Temporary DreamySDK facade

This local assembly is the project seam for the future dedicated Dreamy SDK. It has no UnityEngine, Editor, vendor SDK, credentials, HTTP or application-launch dependency. Feature adapters own mapping SDK results into their existing package contracts. Views emit intents and render status.

All current methods are deterministic **test stubs**, explicitly requested by the project owner. `SDKResult.IsTestResult` and `DreamySDK.IsTestMode` are always true. Cancellation is honored before producing a result. Contact/legal/restore and other informational operations complete locally. Restore has zero entitlements. Purchase/rewarded defaults cancel and cannot grant resources. No external apps open.

SettingsPanelPresenter owns link/restore action subscriptions and a cancellation lifetime. Music/SFX/haptics remain with Dreamy Settings and Audio. GameInstaller's existing Shop purchase gateway delegates to PurchaseAsync and returns Cancelled; it no longer fabricates paid receipts.

Replace the implementation at this seam when the real Dreamy SDK exists. Real payment/ads require typed receipt/completion payloads, pending/cancel/error mapping, idempotency and separate provider/device validation. Add explicit success fixtures when needed; do not infer that a completed API call means a purchase was paid or an ad reward was earned.
