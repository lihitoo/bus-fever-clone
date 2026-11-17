> Current polish refresh: see checkpoint.md and evidence/reference-refresh. Runtime now uses PuzzleCatalog(Level1/2), native sky/plane transition in the existing loader, package-backed Next, source SFX and owned Dreamy VFX smoke. Native Pause Home replaces the temporary gameplay Home HUD. Historical single-level/loading-placeholder statements below are superseded. Full source parity is still under review.

# LAUNCH — M02 contract and open gates

Current user decision: keep MainScene for Home/Gameplay roots. GameplayScene was removed. Existing SceneLoader now also covers asynchronous root swaps; scene loads remain only for initial Bootstrap→Main. Native clouds/plane animation is still an open presentation gate. See [current ownership](../12-main-scene-and-dreamy-reuse.md).

Status: existing template loader reused for Home ↔ Gameplay and Restart; native launch presentation remains planned.

`SceneLoader` remains the single persistent scene-loading owner. Its existing cancellation path drains Unity's non-cancellable scene operation and releases the loading guard. M02 adds GameplayScene to build settings and HomeNavigator's Play destination. GameInstaller owns in-game navigation and suppresses duplicate Restart/Home requests while its load is running.

The loader overlay is modal through the scene transition. A newly instantiated GameplayPanel is not evidence that the loading overlay has exited; tests must wait for the overlay to deactivate before pointer input.

The initial route is still the imported template's Home route. The original audit entered Level 1 directly on its observed first playable launch; fresh/return save policy and complete cold-launch behavior are not sufficiently established to change persistence routing. No progression or tutorial save is fabricated.

The sample loading art has not been replaced yet. The recovered `LoadingPanel` in this import belongs to the original Shop; it is catalogued but intentionally not presented as the game's cold-launch art. Native clouds/plane transition, launch failure/retry presentation, missing bundle recovery, cancellation/background/relaunch tests and source-matched video remain acceptance gates. T011–T013 must not be marked verified from gameplay compile or smoke evidence.
