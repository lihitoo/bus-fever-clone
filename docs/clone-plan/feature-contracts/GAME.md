> Current polish refresh: see checkpoint.md and evidence/reference-refresh. Runtime now uses PuzzleCatalog(Level1/2), native sky/plane transition in the existing loader, package-backed Next, source SFX and owned Dreamy VFX smoke. Native Pause Home replaces the temporary gameplay Home HUD. Historical single-level/loading-placeholder statements below are superseded. Full source parity is still under review.

# GAME — M02 implementation contract

Status: playable first session in review; source parity is not accepted.

Current architecture supersedes scene-based route below: MainScene hosts Home and Gameplay prefab roots. SceneLoader.TransitionContentAsync covers root replacement; no GameplayScene. Tutorial is the Dreamy v0.3.0 package through GameplayTutorialBridge. See [current ownership](../12-main-scene-and-dreamy-reuse.md).

## Source and decisions

| Behavior | Evidence / decision | Current implementation |
| --- | --- | --- |
| Tap a vehicle, leave along its arrow | R003–R010; source GameScene and bus_normal_6 assets | Grid exit-lane validation; world pointer targets and native vehicle mesh |
| Reserve ordinary parking | R003 shows seven ordinary slots plus VIP; R023/R026 show “No spots available” | Synchronous slot reservation before driving; VIP is excluded from ordinary capacity |
| Board by matching color; remaining capacity decreases | R021–R027 | Session owns queue and counts; view animates a passenger of the accepted color into the target vehicle |
| Release a slot after departure | Gameplay audit | Slot stays reserved through Driving, Parked and Departing; release once on Complete |
| Same-color priority | Unresolved in source | Explicit provisional decision: oldest arrival in parking wins |
| Passenger misses a suitable vehicle | Unresolved full source loop | Explicit provisional decision: rotate unmatched front passenger to queue tail |
| First layout and capacity | R003–R010 provide visual layout, not decrypted source coordinates | Six manually transcribed vehicle definitions; coordinates/capacities are approximate and labeled in config provenance |
| Track mesh | Recovered scene contains environment/parking, with track generated at runtime | Editable reconstructed ellipse mesh and kerbs; source spline/entrance branch remain open |
| Pause / restart | R016–R019 | Pause stops session transitions and view motion; Restart uses the persistent scene loader to replace the session |
| Completion | R011 proves the original result flow | M02 shows local completion only; Victory/reward/Next/progression commit belong to M03 |

No fail condition is invented from a full parking lot. “No spots available” leaves the vehicle on the board. Jam/fail/revive semantics still require source evidence.

## Ownership and lifetime

- `PuzzleDefinition` and `PuzzleMotionProfile`: Dreamy DataConfig, `Resources/DataConfig/puzzleLevel.json`. Validate dimensions, IDs, overlap, supply by color and finite positive motion values before session creation.
- `PuzzleSession`: session authority; contains occupancy, slot reservations, queue, capacity and terminal state. No Unity scene, UI, container, save or vendor calls.
- `GameplayPresenter`: constructor DI, subscribes to view intent/tick, runs session transitions and publishes read models. Presentation completion cannot grant currency or progression.
- `GameplayPanel`: source-derived GamePanel HUD and native 3D world; sends intents and renders state. Owns instantiated scenery/vehicles/passengers and clears them on disable/dispose.
- `GameplayFeatureInstaller`: one VContainer container for the entire session, scoped Session/Presenter; the root resolves once. Leaves never resolve. Owned presenter wrapper unbinds before disposing the container; repeated Dispose is harmless.
- `GameInstaller`: reuses the existing DataConfig and presenter factory; orchestrates feature installation and scene navigation. Settings remains installed by SettingsFeatureInstaller, with only a project callback for Restart.
- `HomeNavigator`: existing owner of Play navigation. No HomeComposition or new Home presenter factory.

Normal route: BootstrapScene → MainScene/Home → Play → SceneLoader → GameplayScene/GameplayBootstrap → PanelManager → GameplayPanel/session scope. Return Home and Restart use the same persistent SceneLoader. Loading overlay must finish closing before pointer actions are available.

Session changes do not mutate Datasave or the economy wallet. There are no new SDK methods or vendor dependencies in this slice.

## Asset bindings and limits

See `evidence/M02/recovered-import.json`, `palette-import.json`, `ui-rebuild-bindings.json`, and the editor-authored prefabs in `Assets/_Project/Art/BusFever/UI`. Receipts retain source digests/GUIDs and record actual imported digests after migration. No recovered dummy gameplay scripts were imported.

Source VAT/toon shaders are not recovered runtime behavior. URP materials, flat passenger tint, reconstructed track geometry, camera/vehicle scale, motion durations and queue priority are provisional. Timing is configurable; it is not claimed as measured source timing.

Remaining gates: decrypted level catalog, exact path/collision geometry, source same-color priority, fail/revive, passenger entrance and full loop policy, track connector, source toon/VAT presentation, exact camera/aspects/safe area, SFX/feedback, 50 real scene restarts and Android/player checks. The 50-scope EditMode test proves presenter subscription cleanup only, not scene/pool/device endurance.
