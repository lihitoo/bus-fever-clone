# M01–M03 local playable closeout — 2026-11-18

The normal Editor route is working: Bootstrap → Home → Level1 → Pause/Restart → Victory → Next → Level2 → Pause Home. Home and Gameplay keep one MainScene; the existing loader owns the transition cover. DreamySDK remains the authorized local stub.

| Verified result | Evidence |
|---|---|
| 19/19 focused EditMode tests | [Final job](closeout-final-editmode.json) |
| 1/1 full PlayMode flow, 32.66s | [Final job](closeout-final-flow.json); actual leaf XML under ../M02/tests |
| Win before/after-write failure → retry → one20coin grant | WinLevelIntegrationTests; isolated temporary saves |
| One IconFly/Next; close stops transfer, no late navigation | VictoryPresenterLifecycleTests; shared wallet fixture |
| Source smoke, pause cleanup, restart, double Next, real Level2, one scene/installer | M02GameplayFlowTests |
| 45 project asmdefs; no Runtime→Editor dependency | [Harness](closeout-harness.json) |
| 61 real frames,32.10s, video decodes | [Video receipt](closeout-video.json) |

Implemented this pass: shared-wallet Victory HUD and Dreamy IconFly; progression recovery; source tutorial sliced card, larger hand and visible yellow world-space outline; incoming road/curb join and queue compaction; red/yellow body material repair; source fireworks pixel scaling, alpha shader and trail bindings; darker result cover, coin aspect and brown Next outline. Selective existing prefab updates preserve GUIDs. No new scene, loader, HomeComposition, vendor SDK or parallel reward/tutorial infrastructure.

Opened and compared current tutorial/Victory/Level2 with retained R004/R011/R019. Online Level1/Level2 frames were inspected in the preceding reference refresh. Original game was not reopened. Current screenshots and the latest video are attached to the dashboard. Tutorial screenshot is a presentation-only fixture; persistent tutorial state was not reset.

Known visual differences remain: original queue order/capacity is only partly evidenced; incoming geometry and body toon/VAT/shadows remain approximations; fireworks render but source rounded trail shape and exact timing differ; Level2 vehicle spacing/projection differs. Audio cues are bound, but the sparse silent video proves neither audible mix nor tween fidelity. Actual device/safe area/performance gates, later tutorials, Level3 and hard/superhard content remain open. Strict whole-feature parity tasks therefore remain review; the dashboard now separately shows concrete completed local behavior.

A PlayMode pass previously hid a broken shader: pink particle geometry passed the mesh-presence assertion. The shader import BOM was corrected; both shaders were checked with ShaderUtil (zero messages), binding now validates shader errors, then final screenshots were opened again. Initial runner timeouts and the earlier failed lifecycle fixture remain historical evidence; final acceptance uses the final job IDs above.

Rendering package gap: Coffee4.13.0 provides additive UI particles but no alpha blend variant. SourceParticleAlpha.shader is its MIT-licensed shader with premultiplied alpha blending; propose adding this variant upstream rather than creating a replacement particle service. Dreamy Feedback continues to own leased gameplay effects and icon fly.

No build or commit was requested for this closeout. [Content hashes](closeout-artifacts.json) identify reviewed runtime/prefab/media artifacts without attributing earlier workspace edits to this pass.
