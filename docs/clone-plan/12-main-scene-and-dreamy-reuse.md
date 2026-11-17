# MainScene and Dreamy package ownership

Latest user decisions supersede earlier proposals that created GameplayScene or a local tutorial cursor.

## Scene and presentation lifecycle

BootstrapScene installs persistent foundation services and the existing SceneLoader, then loads MainScene once. MainScene owns the shared Canvas, PanelManager and EventSystem. Home and Gameplay are addressable prefab roots managed through Dreamy UI. GameplayScene and GameplayBootstrap were removed; each gameplay root creates one VContainer session scope, not a scope per entity.

HomeNavigator retains Play navigation via an injected callback from GameInstaller. That callback and the gameplay Restart/Home callbacks use `SceneLoader.TransitionContentAsync`. The existing persistent loading overlay covers the screen, closes outgoing Settings/Gameplay/Home through PanelManager, opens the requested root, then reveals the screen. The scene handle stays unchanged. Closing a gameplay panel disposes its presenter/scope and destroys its world. Scene camera/light components borrowed by gameplay are restored during cleanup.

Future source animation belongs to the existing loading presentation: await cover completion, replace/prepare root, await destination readiness, await reveal completion. Current cover timing is a provisional150ms with the existing loading skin; no claim that the original clouds/plane animation is implemented. No extra LoadingScene or second transition service is needed.

## Tutorial migration

Installed organization package `com.dreamy.feature.tutorial` v0.3.0, pinned to `dbf1f6ef6f0ced68d5ee4f73740662c466c7d331` in manifest and resolved lock. Inspected actual package source: `TutorialInstaller`, `TutorialModel`, `ITutorialService`, `TutorialSignalHandle`, `ITutorialPersistence` and catalog contracts. Its dependencies match the project's Core1.2.0, DataConfig/Datasave1.0.1 and UI1.1.0 ownership; consumer tests are the compatibility evidence, not a general certification.

`GameInstaller.Tutorial` orchestrates the package installer using the existing shared Datasave/DataConfig owners. `tutorialCatalog.json` is the single tutorial sequence source. Removed `TutorialSequence` and its duplicate cursor tests; PuzzleDefinition no longer owns tutorial steps.

`GameplayTutorialBridge` is game-specific glue: maps vehicle dispatch to the package's HostSignal token, renders the current target using the reference hand/card, and suspends/resumes with the session. The package owns cursor/token/checkpoint/completion and persistence retry. Failed saves retry the package's pending operation without replaying gameplay. A resumed freshly recreated board permits previously taught prerequisite cars to move, without advancing the current tutorial step. Completed onboarding does not replay. This is an explicit local replay policy; source parity still requires observation.

The bridge uses the runtime installer because the project supplies custom reference UI. It does not import the package sample overlay or create a second package presenter for that service. Domain cars/views never resolve global services. No fake Datasave implementation was introduced.

## Package-first rule for every next feature

Before implementing a feature, inspect the organization's current repository list, selected tags, package manifest and source. Reuse the matching package through a separate installer and keep only Bus Fever rules/adapters/art in project code. A package absent from the consumer is not evidence that the organization lacks it.

Verified organization candidates on this pass include tutorial, progression, missions, daily-reward, lucky-wheel, connectivity, localization, shop, settings, economy, UI, feedback, audio, assets, DataConfig, Datasave and Core. `feature.progression` currently has v0.2.1 (`c49961d8a94af999635ff40be74a047a8c39a5ad`); inspect it before Victory/reward/Next. This inventory does not assert APIs or compatibility for packages not yet integrated. Missing capabilities should be documented as precise gaps and proposed package extensions, not silently replaced by a parallel framework.
