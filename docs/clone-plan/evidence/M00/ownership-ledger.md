# M00 ownership decision

Source: current GameInstaller partials, source package digests in package-decision.json, Unity MCP project bus-fever-clone@2d3e9060d6c81474 (6000.4.12f1).

| Resource | Create / authority | Release |
| --- | --- | --- |
| Datasave | GameInstaller / DatasaveService | Owned registration, reverse teardown |
| Wallet | One DatasaveResourceWallet shared by Shop and resource consumers | Owned wallet registration; balance provider borrowed |
| Audio | DreamyAudio.Service owns audio instance | GameInstaller unregisters only |
| Feedback | Authored FeedbackHost instance under installer | Unregister services before host Shutdown and destruction |
| Config | DataConfigService with registered documents before initialization | Installer-owned |
| UI presenters | PanelPresenterFactory creates; PanelManager/host drives Show/Dispose | Panel lifecycle; restore manager factories on teardown |
| Home navigation | Existing HomeNavigator, new instance per HomePresenter | HomePresenter.Dispose |
| Settings / Shop | Existing feature installers in imported integrations | Tracked installation + reverse teardown |
| VContainer | Package 1.19.0 installed; no active Home container | Future bounded gameplay session pilot |

User correction: no additional HomeComposition or HomePresenterFactory. Temporary pilot and its two tests were removed; final Home wiring exactly retains the original explicit constructor injection. No new wrappers around HomeNavigator. Runtime asmdef does not need VContainer until the gameplay session consumes it.

Version policy: retain all current Dreamy pins and embedded sources. Registry versions differ from current consumer sources; source digests are recorded, no organization-wide compatibility certification is claimed. Upstream candidate packages stay uninstalled until their feature and compatibility check. Package-check verifies structural completeness, not runtime of every package API.

Production blocker: PurchaseWithBillingAsync currently simulates Purchased. Replace via Shop gateway during SHOP feature; until then no production billing claim. Do not change billing semantics as an unrelated baseline fix.

Runtime observation: normal Bootstrap route reached MainScene, installer Ready, no console warning/error; screenshot m00-template-home-1.png shows current template Home. Earlier m00-template-home.png captures loading and must be labelled as launch, not Home. Both are baseline evidence, not clone fidelity.
