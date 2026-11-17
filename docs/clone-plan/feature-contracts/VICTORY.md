# VICTORY ? current M03 implementation

Status: review; functional tests and matched visual inspection are separate gates.

R011 and R029 confirm20coin victory rewards for Level1/2. Existing Dreamy Progression0.2.1 owns advancement, pending intents and retry; Economy/Datasave own grants and receipts. WinLevelService rejects unfinished sessions, uses stable `bus-fever.win.level-N`, and replay never grants again. Next only proceeds after recorded win/reward delivery and an actual PuzzleCatalog entry. Double Next is guarded by the shared transition owner. Level1?Level2 is playable; Level3 content remains unavailable and the Victory Home fallback remains accessible.

Native title/coin/Next source art is bound. Official Spine3.8 runtime plays recovered victory.skel.bytes3.8.99 jump/idle; recovered Unity Victory entrance controller owns presentation timing. Source fireworks are rendered by pinned Coffee UI Particle and owned by the panel. No vendor SDK or reward multiplier is installed. Reward visuals read configured coin amounts; unconfigured rows cannot display an invented reward.

Normal route: final bus departs ? commit/retry via package ? Victory ? Next ? existing SceneLoader cover ? dispose old session ? real Level2 in MainScene ? native Pause Home. Runtime contains no Editor dependency or alternate composition owner.

Source provenance: evidence/M02/victory-spine-import.json, victory-fireworks-import.json; evidence/reference-refresh/spine-runtime.json and audio-bindings.json. Third-party runtime package source is pinned; see Packages/com.esotericsoftware.spine.spine-unity/INTEGRATION.md and included license. Package compatibility is consumer-tested, not a universal Unity6 claim.

Balance HUD reads the shared wallet. Show records the win once while retaining the pre-grant displayed balance; Next animates12 icons through existing Dreamy IconFly, then updates displayed balance and navigates. No animation creates currency. Closing the panel cancels its CTS and stops its owned feedback handle. Repeated Next is gated before awaiting. Home fallback follows the same presentation cleanup.

After an ambiguous progression write failure, the adapter calls IProgressionRewardService.Reload before retry. Real isolated Datasave/Economy fixtures inject faults before/after progression writes; both retry to level2 and exactly20coins. Presenter fixtures prove one transfer/navigation and stop-on-close without late navigation.

Remaining acceptance: exact fireworks trail shape/blend/timing, hard/superhard/taskbar variants, audio mix and device validation. The current alpha UI particle shader is a narrow derivative of Coffee's MIT UIAdditive shader, retaining its license and changing to premultiplied alpha blending. Coffee lacks an alpha variant, so this is recorded as a rendering integration gap, not another feedback framework. UI/Default PerRendererData lost the material texture because Coffee clears CanvasRenderer textures. NativeVictoryAuthoring now refuses a missing/broken alpha shader before binding.

