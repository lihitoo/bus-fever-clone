<!-- DREAMY-CODEX:START schema=1 -->
## Dreamy Codex Toolkit

Use `toolkit.json` as canonical toolkit metadata when present. For global installs, use installed Dreamy skills/rules and inspect existing project files. Inspect `Packages/manifest.json` and `Packages/packages-lock.json` before Dreamy API claims. Runtime assemblies must not reference Editor assemblies. Run the smallest meaningful available validation before claiming done. For repeated verified failures, use `dreamy-kit lessons`, checking applicability. Checkpoint work spanning turns.

Installed Codex agents: dreamy_architect, dreamy_build_engineer, dreamy_code_reviewer, dreamy_debugger, dreamy_docs_manager, dreamy_mcp_operator, dreamy_package_maintainer, dreamy_plan, dreamy_project_analyst, dreamy_skill_author, dreamy_tester, dreamy_unity_developer, dreamy_unity_editor. See toolkit `docs/toolkit-evolution.md` when available. No background model calls are required.
<!-- DREAMY-CODEX:END -->

## Project architecture

- Follow the imported Dreamy template, explicit constructor DI, MVP, SOLID and purpose-driven patterns. Prefer existing owners over extra composition wrappers. Home retains HomeNavigator; do not add HomeComposition or another Home presenter factory without a demonstrated requirement.
- Keep feature installation separate: GameInstaller orchestrates, each Dreamy feature installer owns its feature wiring. Foundation services keep exactly one owner and reverse teardown.
- Use VContainer sparingly for the future gameplay session scope; do not spread resolver access into views/domain or create a scope per entity.

## External SDK boundary — user decision

- All external SDK integrations go through the temporary `DreamySDK` facade. The future dedicated Dreamy SDK will own vendor SDKs; features only call the facade through their owning gateway/presenter/service adapter.
- This includes support/contact, terms/privacy/consent, store review, billing/restore, advertising, analytics/attribution, remote services and other vendor capabilities when introduced. Do not install vendor SDKs, scatter vendor APIs, credentials or URLs throughout features.
- Current facade is a local test stub. Return deterministic defaults, honor cancellation, and visibly identify test results. These stubs are explicitly authorized by the user for testing; missing real providers are not blockers for local feature acceptance.
- Defaults: informational actions complete without opening external apps; restore succeeds with no entitlements; purchases/rewarded ads cancel without payment/reward. Explicit success fixtures can exercise reward transactions, but never grant from UI clicks.
- Do not claim production billing/ad/backend/store readiness from stub evidence. The future SDK integration has its own device/provider gate. Keep adapters, transactions, idempotency, async ownership and cleanup testable.
- Add API methods only when a consuming feature needs them. These method names are project proposals, not claims that an organization package already implements them.
