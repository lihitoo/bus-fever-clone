# M01 execution checkpoint

## Implemented in normal project routes

- Existing HomePanel prefab/address/GUID retained. HomePresenter/HomeNavigator wiring retained. No HomeComposition/factory layer.
- Recovered animated Home backdrop: city, bus, passenger rigs, source cameras/controllers/meshes/textures. HomePanel owns creation and destruction of this visual instance. Converted materials use installed URP shaders; source toon-disabled draw passes were re-enabled. Multiply shadows, transparent glass and additive headlight glow were migrated explicitly.
- Home has editable source-derived uGUI controls and navigation. Settings uses its existing Addressables panel identity and feature installer. Buttons for future features report availability rather than awarding resources or claiming unimplemented gameplay.
- Source sprite IDs, rects, pivots and borders drive rebuilt UI; TMP Poppins SDF + source Play outline material imported. Recovered UI prefab hierarchy was incomplete when loaded directly, so Editor API reconstructed the audited component tree. The 3D prefab imported with all 1,098 transforms.
- Existing ResourceUIHolder reads the actual shared coin wallet. The 112K displayed in development captures comes from existing template save data, not the reference account's 200 coins. Do not reset the user's save to match a screenshot.
- Settings toggles route through the package presenter/service and existing audio/haptics owners. Contact/legal/restore route through a project presenter to DreamySDK test defaults. No external app/message/network/provider call occurs.
- Source button_click WAV replaces the project core/ui.click sample; authored AudioButtonTrigger components reuse Dreamy Audio. Settings uses UITweenPlayer + fade/scale effects and lifecycle cleanup. Timing defaults are implementation choices pending reference calibration.

## Evidence actually run

- Unity MCP project `D:/Game/bus-fever-clone`, Editor6000.4.12f1, Android target. Normal Bootstrap → MainScene observed Ready.
- Final EditMode job `5503398325bf4bb484c77267f0b16b81`: 36/36 passed (includes updated Shop cancellation default and two SDK default/cancellation tests).
- PlayMode job `4d12d3fc2bea498fb27167de9636b850`: 3/3 passed (existing transaction/feedback regressions).
- `runtime-smoke.json`: 20 real Home→Settings→SDK actions→close/reopen cycles; Music persistence across reopen, original preference restored, one Home instance. Not a player build or physical haptic test.
- Harness project-inspect/asmdef/package-check receipts are separate artifacts. Console error-only query after final runtime route returned 0 errors. Existing BuildReport obsolete API warnings remain.
- Current/source comparison media are linked from plan.json. Capture files named first/native/shadowfix are diagnostic iterations, not acceptance captures.
- `current-video.json` records a real 32-frame Editor walkthrough at ~3FPS with actual timestamps, converted to VFR MP4 and decoded successfully. No audio; this is a flow preview, not a normal-speed feel acceptance recording. A first experimental CaptureScreenshotAsTexture call failed outside end-of-frame; deferred native screenshot capture fixed it. Those diagnostic Console errors remain historical, not hidden by clearing Console.

## Remaining acceptance, not silently closed

- Home bus level sign has a presenter-supplied initial project level1; M02 still needs to provide the progression-backed current level. Reference has a Level6 account; project progression integration/entry policy belongs to M02 and fresh-entry source unlock threshold remains unknown.
- Pause skin/runtime Restart path depends on gameplay session M02. Home Settings is wired and tested; do not claim a tested gameplay pause/restart from that result.
- Source/clone visual differences remain in toon shading, glass/glow, precise layout/font outlines and animation-state snapshots. Current account/avatar/palette differs from the observed reference account.
- Reference recording is <1FPS without audio. Exact tween/SFX sync is unverified. Tall/inset device validation and an audible matched recording remain open.
- Shop/Ranking/Profile/Supplies/Spin/Play destinations are later milestones. Shop still opens the existing functional template Shop; game-specific Shop skin is M05. Play availability does not represent implemented puzzle gameplay.

M01 UI implementation is reviewable, but **full M01 parity acceptance is not closed**. Preserve this distinction in the dashboard. DreamySDK local stubs are expressly allowed by user decision and do not block local testing; real SDK production validation is deferred separately.

## Final authoring adjustments

Bus Stay constant clip writeDefaultValues=false retains recovered entry pose; otherwise Unity6 reset the bones offscreen. A second source bus variant is disabled to avoid overlap. Source level sign now renders the presenter initial level1. Progression value injection remains M02. Current Home art has calibrated edge/center anchors, selected/unselected tabs and the source font outline. Pause skin is authored and previewed through PanelManager with the same Settings factory; Restart without a session reports a rejection, not a simulated restart. See pause-preview.json.

T001/T002 foundation scope verified against package hashes, ownership tests and harness; Home/Settings UI tasks stay review until the retained visual/feel/dependency gates pass. No phase-complete claim.
