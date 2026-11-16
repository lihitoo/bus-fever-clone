# Task cards — kế hoạch thực thi và trạng thái hiện tại

Nguồn chuẩn: plan.json. Foundation T001/T002 đã verified; M01 UI đang review. SDK ngoài dùng DreamySDK test defaults theo user, production gate riêng. Xem checkpoint.md và evidence/M01/execution.md trước khi tiếp tục.

## T001 — Baseline package pins và ownership ledger

**Status:** verified · **Phase:** M00 · **Feature:** FOUNDATION · **Weight:** 3 · **Depends:** none

**Source:** planning baseline
**Gap/precondition:** Theo baseline và dependencies

### Thực hiện

1. Đọc manifest/lock/embedded package source và toolkit registry theo hashes.
2. So consumer vs upstream dependencies, giữ embedded customizations; chốt pin/candidate riêng.
3. Review Shop simulation và tách production adapter work, không tự grant.

### Acceptance

- Không còn API claim không có nguồn.
- Một wallet/save/audio owner; conflicts có decision/rollback.

**Verification:** project-inspect, asmdef, package-check

**Artifacts/ownership:** package-decision.json, ownership-ledger.md

**Evidence:** evidence/M00/package-decision.json, evidence/M00/ownership-ledger.md, evidence/M01/asmdef.json, evidence/M01/package-check.json, evidence/M01/validation.json

## T002 — VContainer pin và kế hoạch gameplay session pilot

**Status:** verified · **Phase:** M00 · **Feature:** FOUNDATION · **Weight:** 5 · **Depends:** T001

**Source:** planning baseline
**Gap/precondition:** Theo baseline và dependencies

### Thực hiện

1. Cài VContainer1.19.0 qua Unity Package Manager; record lock hash và compatibility smoke.
2. Giữ HomePresenter/HomeNavigator hiện có với constructor DI trực tiếp; không thêm HomeComposition/factory.
3. Chuyển bài học child scope sang GAME khi có session lifetime thực; không scope từng entity.

### Acceptance

- Package resolve đúng pin, template tests không regression.
- Home wiring không thêm lớp trùng; GameInstaller vẫn sở hữu Dreamy services.
- Gameplay scope không được claim hoàn thành từ việc cài package.

**Verification:** compile, test-editmode, test-playmode

**Artifacts/ownership:** Composition ADR, DI lifetime tests, factory registration map

**Evidence:** evidence/M00/package-decision.json, evidence/M00/ownership-ledger.md, evidence/M01/asmdef.json, evidence/M01/package-check.json, evidence/M01/validation.json

## T003 — Capture pipeline và acceptance calibration

**Status:** blocked · **Phase:** M00 · **Feature:** EVIDENCE · **Weight:** 3 · **Depends:** T001

**Source:** planning baseline
**Gap/precondition:** Đã chụp current template Home/loading. Reference normal-speed audio/video calibration chưa đạt.

### Thực hiện

1. Khắc phục capture <1FPS/render black hoặc chọn Android thật; lưu FPS/audio streams.
2. Chốt matched viewport/device/time basis và sai số visual/feel.
3. Capture normal launch/tutorial/fail và inventory/cost boundaries.
4. Capture project mẫu hiện tại từ normal entry và gắn current media đúng feature, version/viewport; không dùng ảnh reference làm before.

### Acceptance

- Có clip frame đều, nghe được audio, không đo từ duplicated frames.
- Ngưỡng/thiết bị và unknowns được owner review.

**Verification:** media decode, frame timestamps, matched-state review

**Artifacts/ownership:** capture-receipt.json, acceptance-calibration.md

**Evidence:** Chưa có receipt reviewed

## T004 — Asset URP/font/Spine import pilot

**Status:** review · **Phase:** M00 · **Feature:** ASSETS · **Weight:** 3 · **Depends:** T001

**Source:** planning baseline
**Gap/precondition:** Implementation/source packet available; required visual/feel and phase dependency review remains. SDK local defaults explicitly allowed.

### Thực hiện

1. Chọn một popup, một bus/material, một crowd/character và audio từ nguồn.
2. Import derivatives vào project owner, sửa shader/material có receipt.
3. Verify atlas rect/pivot/font glyph/Spine compatibility, giữ GUID.

### Acceptance

- Không import dummy C# hoặc cả export project.
- Pilot nhìn thấy đúng tại harness scene; dependencies không thiếu.

**Verification:** compile, EditMode binding validation, visual pilot

**Artifacts/ownership:** asset-binding-map.json, URP conversion receipt

**Evidence:** evidence/M01/execution.md, evidence/M01/runtime-smoke.json

## T005 — Home và bottom navigation: chốt source/state và contract

**Status:** review · **Phase:** M01 · **Feature:** HOME · **Weight:** 1 · **Depends:** T004

**Source:** R063-board-state
**Gap/precondition:** Implementation/source packet available; required visual/feel and phase dependency review remains. SDK local defaults explicitly allowed.

### Thực hiện

1. Mở audit/source theo IDs, bổ sung mọi gap trước khi implementation semantics.
2. Lập state graph entry/action/effect/exit/error/cancel; xác định save/session và package ownership.
3. Chốt config: HomeVisualProfile, navigation addresses, level label.
4. Chốt scope package: UI / Assets / Feedback / VContainer; đọc source tại pin thực tế.

### Acceptance

- Mỗi behavior có source evidence hoặc explicit proposed decision.
- Asset dependencies, runtime route và failure scenarios được liệt kê.
- Unknown bắt buộc được giải quyết; không coi tên metadata là luật.

**Verification:** source-ready review, config-schema design

**Artifacts/ownership:** feature-contracts/HOME.md, source-state matrix

**Evidence:** evidence/M01/execution.md, evidence/M01/runtime-smoke.json

## T006 — Home và bottom navigation: implement vertical slice và thay UI ngay

**Status:** review · **Phase:** M01 · **Feature:** HOME · **Weight:** 3 · **Depends:** T005, T002

**Source:** R063-board-state
**Gap/precondition:** Implementation/source packet available; required visual/feel and phase dependency review remains. SDK local defaults explicitly allowed.

### Thực hiện

1. Tạo owner tại Features/Home, Prefabs/BusFever/Home, Composition/HomeFactory theo architecture.
2. Dùng config/save/session boundaries và service package thật; không giữ model giả cho UI.
3. Wire normal entry: Launch → readiness → Home city/bus/queue → tab hoặc Play → exit.
4. Import/bind selected art; thay address/presenter route sang UI mới trong cùng feature.
5. Hoàn thiện pressed/locked/loading/success/error/back, feedback và owned cancellation.
6. Ghi asset GUID/source IDs và transaction/lifetime ledger; không tách reskin thành deferred cuối game.

### Acceptance

- UI mới được thấy từ normal route, hành vi tạo kết quả thật.
- Authority không nằm trong View; không duplicate wallet/presenter callbacks.
- Save authority: Đọc progression/profile/wallet; không tạo balance riêng.
- Không TODO correctness hoặc fake service success.

**Verification:** compile, asmdef, lowest-layer behavior tests, normal-entry smoke

**Artifacts/ownership:** Features/Home, Prefabs/BusFever/Home, Composition/HomeFactory, source→Unity GUID binding receipt

**Evidence:** evidence/M01/execution.md, evidence/M01/runtime-smoke.json

## T007 — Home và bottom navigation: regression, visual/feel và acceptance

**Status:** review · **Phase:** M01 · **Feature:** HOME · **Weight:** 2 · **Depends:** T006

**Source:** R063-board-state
**Gap/precondition:** Functional test evidence passed. Exact visual/feel, alternate aspect/inset, fresh-entry/pause gameplay integration remain unverified.

### Thực hiện

1. Cold launch đúng Home/new-player rule
2. Tab qua lại20lần không duplicate presenter
3. Load art fail → retry, close during load
4. 1080x1920 và tall viewport, safearea không che nav
5. So source/clone cùng state, sửa sai khác ngay trước feature tiếp theo.
6. Ghi harness/tests/capture/audio/asset receipts đúng revision, update coverage/dashboard.

### Acceptance

- Tất cả scenario bắt buộc pass hoặc gate blocked có reason; không verified nếu còn gap bắt buộc.
- Required evidence tồn tại/hash đúng và người review kết luận.
- Không regression feature đã hoàn thành; no orphan subscription/CTS/handle/tween.

**Verification:** targeted EditMode/PlayMode theo risk, matched captures, console, device/provider nếu feature yêu cầu

**Artifacts/ownership:** evidence/HOME/, coverage delta, reviewed parity checklist

**Evidence:** Chưa có receipt reviewed

## T008 — Settings Home và Pause: chốt source/state và contract

**Status:** review · **Phase:** M01 · **Feature:** SETTINGS · **Weight:** 1 · **Depends:** T007

**Source:** R016-pause-stable; R067-home-settings
**Gap/precondition:** Implementation/source packet available; required visual/feel and phase dependency review remains. SDK local defaults explicitly allowed.

### Thực hiện

1. Mở audit/source theo IDs, bổ sung mọi gap trước khi implementation semantics.
2. Lập state graph entry/action/effect/exit/error/cancel; xác định save/session và package ownership.
3. Chốt config: SettingsPresentationProfile, external URLs và platform capabilities.
4. Chốt scope package: Settings / UI / Audio / Feedback; đọc source tại pin thực tế.

### Acceptance

- Mỗi behavior có source evidence hoặc explicit proposed decision.
- Asset dependencies, runtime route và failure scenarios được liệt kê.
- Unknown bắt buộc được giải quyết; không coi tên metadata là luật.

**Verification:** source-ready review, config-schema design

**Artifacts/ownership:** feature-contracts/SETTINGS.md, source-state matrix

**Evidence:** evidence/M01/execution.md, evidence/M01/runtime-smoke.json

## T009 — Settings Home và Pause: implement vertical slice và thay UI ngay

**Status:** review · **Phase:** M01 · **Feature:** SETTINGS · **Weight:** 3 · **Depends:** T008

**Source:** R016-pause-stable; R067-home-settings
**Gap/precondition:** Implementation/source packet available; required visual/feel and phase dependency review remains. SDK local defaults explicitly allowed.

### Thực hiện

1. Tạo owner tại Features/Settings, Prefabs/BusFever/Settings, Integration/Settings theo architecture.
2. Dùng config/save/session boundaries và service package thật; không giữ model giả cho UI.
3. Wire normal entry: Home hoặc Pause → đúng skin → toggle → close; gameplay Restart có cost policy.
4. Import/bind selected art; thay address/presenter route sang UI mới trong cùng feature.
5. Hoàn thiện pressed/locked/loading/success/error/back, feedback và owned cancellation.
6. Ghi asset GUID/source IDs và transaction/lifetime ledger; không tách reskin thành deferred cuối game.
7. Tách installer riêng của Dreamy feature đang dùng; explicit dependencies, installation cleanup và reverse teardown theo 09-senior-implementation.md.

### Acceptance

- UI mới được thấy từ normal route, hành vi tạo kết quả thật.
- Authority không nằm trong View; không duplicate wallet/presenter callbacks.
- Save authority: Reuse settings state; test persistence, không trộn progression.
- Không TODO correctness hoặc fake service success.

**Verification:** compile, asmdef, lowest-layer behavior tests, normal-entry smoke

**Artifacts/ownership:** Features/Settings, Prefabs/BusFever/Settings, Integration/Settings, source→Unity GUID binding receipt

**Evidence:** evidence/M01/execution.md, evidence/M01/runtime-smoke.json

## T010 — Settings Home và Pause: regression, visual/feel và acceptance

**Status:** review · **Phase:** M01 · **Feature:** SETTINGS · **Weight:** 2 · **Depends:** T009

**Source:** R016-pause-stable; R067-home-settings
**Gap/precondition:** Functional test evidence passed. Exact visual/feel, alternate aspect/inset, fresh-entry/pause gameplay integration remain unverified.

### Thực hiện

1. Music off/on giữ sau relaunch
2. Pause không cho click xuyên xuống board
3. Restore empty/cancel/error có phản hồi
4. Close20lần không nhân đôi audio callback
5. So source/clone cùng state, sửa sai khác ngay trước feature tiếp theo.
6. Ghi harness/tests/capture/audio/asset receipts đúng revision, update coverage/dashboard.

### Acceptance

- Tất cả scenario bắt buộc pass hoặc gate blocked có reason; không verified nếu còn gap bắt buộc.
- Required evidence tồn tại/hash đúng và người review kết luận.
- Không regression feature đã hoàn thành; no orphan subscription/CTS/handle/tween.

**Verification:** targeted EditMode/PlayMode theo risk, matched captures, console, device/provider nếu feature yêu cầu

**Artifacts/ownership:** evidence/SETTINGS/, coverage delta, reviewed parity checklist

**Evidence:** Chưa có receipt reviewed

## T011 — Splash/loading và scene transition: chốt source/state và contract

**Status:** planned · **Phase:** M02 · **Feature:** LAUNCH · **Weight:** 1 · **Depends:** T010

**Source:** R002-playstore-launch; R018-restart-prompt
**Gap/precondition:** Cold fresh/return full route và network errors cần khảo sát

### Thực hiện

1. Mở audit/source theo IDs, bổ sung mọi gap trước khi implementation semantics.
2. Lập state graph entry/action/effect/exit/error/cancel; xác định save/session và package ownership.
3. Chốt config: StartupRoutingPolicy, scene addresses, transition curves.
4. Chốt scope package: Core / Assets / UI / Connectivity candidate; đọc source tại pin thực tế.

### Acceptance

- Mỗi behavior có source evidence hoặc explicit proposed decision.
- Asset dependencies, runtime route và failure scenarios được liệt kê.
- Unknown bắt buộc được giải quyết; không coi tên metadata là luật.

**Verification:** source-ready review, config-schema design

**Artifacts/ownership:** feature-contracts/LAUNCH.md, source-state matrix

**Evidence:** Chưa có receipt reviewed

## T012 — Splash/loading và scene transition: implement vertical slice và thay UI ngay

**Status:** planned · **Phase:** M02 · **Feature:** LAUNCH · **Weight:** 3 · **Depends:** T011

**Source:** R002-playstore-launch; R018-restart-prompt
**Gap/precondition:** Cold fresh/return full route và network errors cần khảo sát

### Thực hiện

1. Tạo owner tại Features/Launch, Presentation/Transitions, Scripts/Bootstrap theo architecture.
2. Dùng config/save/session boundaries và service package thật; không giữ model giả cho UI.
3. Wire normal entry: Cold/return launch → init → load → route; fail → retry; transition trời/mây/máy bay.
4. Import/bind selected art; thay address/presenter route sang UI mới trong cùng feature.
5. Hoàn thiện pressed/locked/loading/success/error/back, feedback và owned cancellation.
6. Ghi asset GUID/source IDs và transaction/lifetime ledger; không tách reskin thành deferred cuối game.

### Acceptance

- UI mới được thấy từ normal route, hành vi tạo kết quả thật.
- Authority không nằm trong View; không duplicate wallet/presenter callbacks.
- Save authority: Load save/repair trước route; tutorial/progression quyết định entry.
- Không TODO correctness hoặc fake service success.

**Verification:** compile, asmdef, lowest-layer behavior tests, normal-entry smoke

**Artifacts/ownership:** Features/Launch, Presentation/Transitions, Scripts/Bootstrap, source→Unity GUID binding receipt

**Evidence:** Chưa có receipt reviewed

## T013 — Splash/loading và scene transition: regression, visual/feel và acceptance

**Status:** planned · **Phase:** M02 · **Feature:** LAUNCH · **Weight:** 2 · **Depends:** T012

**Source:** R002-playstore-launch; R018-restart-prompt
**Gap/precondition:** Cold fresh/return full route và network errors cần khảo sát

### Thực hiện

1. Init cancel không publish ready
2. Missing bundle/retry không leak handle
3. Bootstrap duplicate/reload không tạo wallet2
4. Background/relaunch không kẹt loading
5. So source/clone cùng state, sửa sai khác ngay trước feature tiếp theo.
6. Ghi harness/tests/capture/audio/asset receipts đúng revision, update coverage/dashboard.

### Acceptance

- Tất cả scenario bắt buộc pass hoặc gate blocked có reason; không verified nếu còn gap bắt buộc.
- Required evidence tồn tại/hash đúng và người review kết luận.
- Không regression feature đã hoàn thành; no orphan subscription/CTS/handle/tween.

**Verification:** targeted EditMode/PlayMode theo risk, matched captures, console, device/provider nếu feature yêu cầu

**Artifacts/ownership:** evidence/LAUNCH/, coverage delta, reviewed parity checklist

**Evidence:** Chưa có receipt reviewed

## T014 — Gameplay board, xe và passenger loop: chốt source/state và contract

**Status:** planned · **Phase:** M02 · **Feature:** GAME · **Weight:** 1 · **Depends:** T013

**Source:** R003-after-loading; R021-level2-top-cleared
**Gap/precondition:** Source priority, collision boundaries, complete loop/fail logic và AES chưa đủ

### Thực hiện

1. Mở audit/source theo IDs, bổ sung mọi gap trước khi implementation semantics.
2. Lập state graph entry/action/effect/exit/error/cancel; xác định save/session và package ownership.
3. Chốt config: LevelDefinition, VehicleDefinition, PassengerPolicy, MotionProfile.
4. Chốt scope package: Core / Assets / Audio / Feedback; project Domain; đọc source tại pin thực tế.

### Acceptance

- Mỗi behavior có source evidence hoặc explicit proposed decision.
- Asset dependencies, runtime route và failure scenarios được liệt kê.
- Unknown bắt buộc được giải quyết; không coi tên metadata là luật.

**Verification:** source-ready review, config-schema design

**Artifacts/ownership:** feature-contracts/GAME.md, source-state matrix

**Evidence:** Chưa có receipt reviewed

## T015 — Gameplay board, xe và passenger loop: implement vertical slice và thay UI ngay

**Status:** planned · **Phase:** M02 · **Feature:** GAME · **Weight:** 5 · **Depends:** T014

**Source:** R003-after-loading; R021-level2-top-cleared
**Gap/precondition:** Source priority, collision boundaries, complete loop/fail logic và AES chưa đủ

### Thực hiện

1. Tạo owner tại Domain/Board, Domain/Passengers, Application/PuzzleSession, Features/Gameplay, Presentation/Vehicles theo architecture.
2. Dùng config/save/session boundaries và service package thật; không giữ model giả cho UI.
3. Wire normal entry: Tap vehicle → validate hướng/occupancy → reserve slot → drive → match/board → full departure.
4. Import/bind selected art; thay address/presenter route sang UI mới trong cùng feature.
5. Hoàn thiện pressed/locked/loading/success/error/back, feedback và owned cancellation.
6. Ghi asset GUID/source IDs và transaction/lifetime ledger; không tách reskin thành deferred cuối game.
7. Thêm một gameplay child session scope; retry/exit dispose đúng một lần, không scope từng entity.

### Acceptance

- UI mới được thấy từ normal route, hành vi tạo kết quả thật.
- Authority không nằm trong View; không duplicate wallet/presenter callbacks.
- Save authority: Session occupancy/queue/request IDs; progression chưa tăng trước win commit.
- Không TODO correctness hoặc fake service success.

**Verification:** compile, asmdef, lowest-layer behavior tests, normal-entry smoke

**Artifacts/ownership:** Domain/Board, Domain/Passengers, Application/PuzzleSession, Features/Gameplay, Presentation/Vehicles, source→Unity GUID binding receipt

**Evidence:** Chưa có receipt reviewed

## T016 — Gameplay board, xe và passenger loop: regression, visual/feel và acceptance

**Status:** planned · **Phase:** M02 · **Feature:** GAME · **Weight:** 2 · **Depends:** T015

**Source:** R003-after-loading; R021-level2-top-cleared
**Gap/precondition:** Source priority, collision boundaries, complete loop/fail logic và AES chưa đủ

### Thực hiện

1. Blocked car không đi xuyên
2. Hai tap đồng thời không reserve cùng slot
3. Hai xe cùng màu: priority theo source
4. Boarding giảm đúng capacity, không tạo mất khách
5. Restart50lần: pool/handle/listener về baseline
6. Camera/colors/material/shadow match cùng layout
7. So source/clone cùng state, sửa sai khác ngay trước feature tiếp theo.
8. Ghi harness/tests/capture/audio/asset receipts đúng revision, update coverage/dashboard.

### Acceptance

- Tất cả scenario bắt buộc pass hoặc gate blocked có reason; không verified nếu còn gap bắt buộc.
- Required evidence tồn tại/hash đúng và người review kết luận.
- Không regression feature đã hoàn thành; no orphan subscription/CTS/handle/tween.

**Verification:** targeted EditMode/PlayMode theo risk, matched captures, console, device/provider nếu feature yêu cầu

**Artifacts/ownership:** evidence/GAME/, coverage delta, reviewed parity checklist

**Evidence:** Chưa có receipt reviewed

## T017 — Tutorial bàn tay/spotlight/target gate: chốt source/state và contract

**Status:** planned · **Phase:** M03 · **Feature:** TUTORIAL · **Weight:** 1 · **Depends:** T016

**Source:** R004-level1-blocked-test; R048-vip-select-target
**Gap/precondition:** Xác nhận replay và persistence của từng step

### Thực hiện

1. Mở audit/source theo IDs, bổ sung mọi gap trước khi implementation semantics.
2. Lập state graph entry/action/effect/exit/error/cancel; xác định save/session và package ownership.
3. Chốt config: TutorialCatalog, stable target IDs, unlock steps.
4. Chốt scope package: feature.tutorial candidate / UI / Feedback; đọc source tại pin thực tế.

### Acceptance

- Mỗi behavior có source evidence hoặc explicit proposed decision.
- Asset dependencies, runtime route và failure scenarios được liệt kê.
- Unknown bắt buộc được giải quyết; không coi tên metadata là luật.

**Verification:** source-ready review, config-schema design

**Artifacts/ownership:** feature-contracts/TUTORIAL.md, source-state matrix

**Evidence:** Chưa có receipt reviewed

## T018 — Tutorial bàn tay/spotlight/target gate: implement vertical slice và thay UI ngay

**Status:** planned · **Phase:** M03 · **Feature:** TUTORIAL · **Weight:** 3 · **Depends:** T017

**Source:** R004-level1-blocked-test; R048-vip-select-target
**Gap/precondition:** Xác nhận replay và persistence của từng step

### Thực hiện

1. Tạo owner tại Features/Tutorial, Integration/TutorialTargets, Prefabs/BusFever/Tutorial theo architecture.
2. Dùng config/save/session boundaries và service package thật; không giữ model giả cho UI.
3. Wire normal entry: First entry → target resolved → lock input subset → accepted action → next → finish.
4. Import/bind selected art; thay address/presenter route sang UI mới trong cùng feature.
5. Hoàn thiện pressed/locked/loading/success/error/back, feedback và owned cancellation.
6. Ghi asset GUID/source IDs và transaction/lifetime ledger; không tách reskin thành deferred cuối game.
7. Tách installer riêng của Dreamy feature đang dùng; explicit dependencies, installation cleanup và reverse teardown theo 09-senior-implementation.md.

### Acceptance

- UI mới được thấy từ normal route, hành vi tạo kết quả thật.
- Authority không nằm trong View; không duplicate wallet/presenter callbacks.
- Save authority: Package tutorial checkpoint; session target references không persist instance IDs.
- Không TODO correctness hoặc fake service success.

**Verification:** compile, asmdef, lowest-layer behavior tests, normal-entry smoke

**Artifacts/ownership:** Features/Tutorial, Integration/TutorialTargets, Prefabs/BusFever/Tutorial, source→Unity GUID binding receipt

**Evidence:** Chưa có receipt reviewed

## T019 — Tutorial bàn tay/spotlight/target gate: regression, visual/feel và acceptance

**Status:** planned · **Phase:** M03 · **Feature:** TUTORIAL · **Weight:** 2 · **Depends:** T018

**Source:** R004-level1-blocked-test; R048-vip-select-target
**Gap/precondition:** Xác nhận replay và persistence của từng step

### Thực hiện

1. Wrong target không advance
2. Target destroyed/late loaded → recover
3. Close/background/relaunch không skip reward
4. Hand/outline/card đúng target sau camera resize
5. So source/clone cùng state, sửa sai khác ngay trước feature tiếp theo.
6. Ghi harness/tests/capture/audio/asset receipts đúng revision, update coverage/dashboard.

### Acceptance

- Tất cả scenario bắt buộc pass hoặc gate blocked có reason; không verified nếu còn gap bắt buộc.
- Required evidence tồn tại/hash đúng và người review kết luận.
- Không regression feature đã hoàn thành; no orphan subscription/CTS/handle/tween.

**Verification:** targeted EditMode/PlayMode theo risk, matched captures, console, device/provider nếu feature yêu cầu

**Artifacts/ownership:** evidence/TUTORIAL/, coverage delta, reviewed parity checklist

**Evidence:** Chưa có receipt reviewed

## T020 — Victory, reward và Next: chốt source/state và contract

**Status:** planned · **Phase:** M03 · **Feature:** VICTORY · **Weight:** 1 · **Depends:** T019

**Source:** R011-level1-result
**Gap/precondition:** Hard/superhard/taskbar reward chưa capture

### Thực hiện

1. Mở audit/source theo IDs, bổ sung mọi gap trước khi implementation semantics.
2. Lập state graph entry/action/effect/exit/error/cancel; xác định save/session và package ownership.
3. Chốt config: WinRewardTable, difficulty variants, Spine/animation cues.
4. Chốt scope package: Progression candidate / Economy / UI / Feedback / Audio; đọc source tại pin thực tế.

### Acceptance

- Mỗi behavior có source evidence hoặc explicit proposed decision.
- Asset dependencies, runtime route và failure scenarios được liệt kê.
- Unknown bắt buộc được giải quyết; không coi tên metadata là luật.

**Verification:** source-ready review, config-schema design

**Artifacts/ownership:** feature-contracts/VICTORY.md, source-state matrix

**Evidence:** Chưa có receipt reviewed

## T021 — Victory, reward và Next: implement vertical slice và thay UI ngay

**Status:** planned · **Phase:** M03 · **Feature:** VICTORY · **Weight:** 3 · **Depends:** T020

**Source:** R011-level1-result
**Gap/precondition:** Hard/superhard/taskbar reward chưa capture

### Thực hiện

1. Tạo owner tại Features/Victory, Application/WinLevel, Prefabs/BusFever/Victory theo architecture.
2. Dùng config/save/session boundaries và service package thật; không giữ model giả cho UI.
3. Wire normal entry: Final passenger → win fact → persistent reward → Victory → Next → next layout.
4. Import/bind selected art; thay address/presenter route sang UI mới trong cùng feature.
5. Hoàn thiện pressed/locked/loading/success/error/back, feedback và owned cancellation.
6. Ghi asset GUID/source IDs và transaction/lifetime ledger; không tách reskin thành deferred cuối game.

### Acceptance

- UI mới được thấy từ normal route, hành vi tạo kết quả thật.
- Authority không nằm trong View; không duplicate wallet/presenter callbacks.
- Save authority: Win receipt/session ID chống grant2; progression và wallet consistency.
- Không TODO correctness hoặc fake service success.

**Verification:** compile, asmdef, lowest-layer behavior tests, normal-entry smoke

**Artifacts/ownership:** Features/Victory, Application/WinLevel, Prefabs/BusFever/Victory, source→Unity GUID binding receipt

**Evidence:** Chưa có receipt reviewed

## T022 — Victory, reward và Next: regression, visual/feel và acceptance

**Status:** planned · **Phase:** M03 · **Feature:** VICTORY · **Weight:** 2 · **Depends:** T021

**Source:** R011-level1-result
**Gap/precondition:** Hard/superhard/taskbar reward chưa capture

### Thực hiện

1. Double Next không skip2level
2. Relaunch sau grant trước animation không grant lại
3. Normal/hard/superhard đúng variant
4. Coin fly/counter không thay authoritative balance
5. So source/clone cùng state, sửa sai khác ngay trước feature tiếp theo.
6. Ghi harness/tests/capture/audio/asset receipts đúng revision, update coverage/dashboard.

### Acceptance

- Tất cả scenario bắt buộc pass hoặc gate blocked có reason; không verified nếu còn gap bắt buộc.
- Required evidence tồn tại/hash đúng và người review kết luận.
- Không regression feature đã hoàn thành; no orphan subscription/CTS/handle/tween.

**Verification:** targeted EditMode/PlayMode theo risk, matched captures, console, device/provider nếu feature yêu cầu

**Artifacts/ownership:** evidence/VICTORY/, coverage delta, reviewed parity checklist

**Evidence:** Chưa có receipt reviewed

## T023 — Fail, Revive, Retry và quit: chốt source/state và contract

**Status:** planned · **Phase:** M04 · **Feature:** FAIL · **Weight:** 1 · **Depends:** T022

**Source:** static FailPanel/RevivePanel; runtime chưa đủ
**Gap/precondition:** BLOCK source-ready: cần tạo fail bằng normal gameplay

### Thực hiện

1. Mở audit/source theo IDs, bổ sung mọi gap trước khi implementation semantics.
2. Lập state graph entry/action/effect/exit/error/cancel; xác định save/session và package ownership.
3. Chốt config: FailurePolicy, revive costs, reason→panel variants.
4. Chốt scope package: Economy / UI / Feedback / platform gateways; đọc source tại pin thực tế.

### Acceptance

- Mỗi behavior có source evidence hoặc explicit proposed decision.
- Asset dependencies, runtime route và failure scenarios được liệt kê.
- Unknown bắt buộc được giải quyết; không coi tên metadata là luật.

**Verification:** source-ready review, config-schema design

**Artifacts/ownership:** feature-contracts/FAIL.md, source-state matrix

**Evidence:** Chưa có receipt reviewed

## T024 — Fail, Revive, Retry và quit: implement vertical slice và thay UI ngay

**Status:** planned · **Phase:** M04 · **Feature:** FAIL · **Weight:** 5 · **Depends:** T023

**Source:** static FailPanel/RevivePanel; runtime chưa đủ
**Gap/precondition:** BLOCK source-ready: cần tạo fail bằng normal gameplay

### Thực hiện

1. Tạo owner tại Domain/Failure, Features/FailRevive, Application/ReviveLevel theo architecture.
2. Dùng config/save/session boundaries và service package thật; không giữ model giả cho UI.
3. Wire normal entry: Normal fail reason → fail panel → revive/ad/coin hoặc retry/quit → result.
4. Import/bind selected art; thay address/presenter route sang UI mới trong cùng feature.
5. Hoàn thiện pressed/locked/loading/success/error/back, feedback và owned cancellation.
6. Ghi asset GUID/source IDs và transaction/lifetime ledger; không tách reskin thành deferred cuối game.

### Acceptance

- UI mới được thấy từ normal route, hành vi tạo kết quả thật.
- Authority không nằm trong View; không duplicate wallet/presenter callbacks.
- Save authority: Spend/revive receipt atomic; life/progression policies rõ.
- Không TODO correctness hoặc fake service success.

**Verification:** compile, asmdef, lowest-layer behavior tests, normal-entry smoke

**Artifacts/ownership:** Domain/Failure, Features/FailRevive, Application/ReviveLevel, source→Unity GUID binding receipt

**Evidence:** Chưa có receipt reviewed

## T025 — Fail, Revive, Retry và quit: regression, visual/feel và acceptance

**Status:** planned · **Phase:** M04 · **Feature:** FAIL · **Weight:** 2 · **Depends:** T024

**Source:** static FailPanel/RevivePanel; runtime chưa đủ
**Gap/precondition:** BLOCK source-ready: cần tạo fail bằng normal gameplay

### Thực hiện

1. No-spots toast không mặc nhiên là fail
2. Revive cancel/no-fill giữ tiền/state đúng
3. Double revive chỉ commit1
4. Quit/relaunch trong ad xử lý late callback
5. Retry restore đúng layout theo source
6. So source/clone cùng state, sửa sai khác ngay trước feature tiếp theo.
7. Ghi harness/tests/capture/audio/asset receipts đúng revision, update coverage/dashboard.

### Acceptance

- Tất cả scenario bắt buộc pass hoặc gate blocked có reason; không verified nếu còn gap bắt buộc.
- Required evidence tồn tại/hash đúng và người review kết luận.
- Không regression feature đã hoàn thành; no orphan subscription/CTS/handle/tween.

**Verification:** targeted EditMode/PlayMode theo risk, matched captures, console, device/provider nếu feature yêu cầu

**Artifacts/ownership:** evidence/FAIL/, coverage delta, reviewed parity checklist

**Evidence:** Chưa có receipt reviewed

## T026 — Extra Spot và parking reservation: chốt source/state và contract

**Status:** planned · **Phase:** M04 · **Feature:** PARK · **Weight:** 1 · **Depends:** T025

**Source:** R053-extra-parking; R054-extra-spot-ad-result
**Gap/precondition:** Ad completion/cancel/error và coin mode cần xác minh

### Thực hiện

1. Mở audit/source theo IDs, bổ sung mọi gap trước khi implementation semantics.
2. Lập state graph entry/action/effect/exit/error/cancel; xác định save/session và package ownership.
3. Chốt config: ParkingUnlockPolicy, cost/ad modes, slot IDs.
4. Chốt scope package: Economy / UI / Audio / rewarded gateway; đọc source tại pin thực tế.

### Acceptance

- Mỗi behavior có source evidence hoặc explicit proposed decision.
- Asset dependencies, runtime route và failure scenarios được liệt kê.
- Unknown bắt buộc được giải quyết; không coi tên metadata là luật.

**Verification:** source-ready review, config-schema design

**Artifacts/ownership:** feature-contracts/PARK.md, source-state matrix

**Evidence:** Chưa có receipt reviewed

## T027 — Extra Spot và parking reservation: implement vertical slice và thay UI ngay

**Status:** planned · **Phase:** M04 · **Feature:** PARK · **Weight:** 3 · **Depends:** T026

**Source:** R053-extra-parking; R054-extra-spot-ad-result
**Gap/precondition:** Ad completion/cancel/error và coin mode cần xác minh

### Thực hiện

1. Tạo owner tại Domain/Parking, Features/ExtraSpot, Integration/RewardedAds theo architecture.
2. Dùng config/save/session boundaries và service package thật; không giữ model giả cho UI.
3. Wire normal entry: Tap + → Extra Spot → Free/coin theo nguồn → completed → unlock slot → close.
4. Import/bind selected art; thay address/presenter route sang UI mới trong cùng feature.
5. Hoàn thiện pressed/locked/loading/success/error/back, feedback và owned cancellation.
6. Ghi asset GUID/source IDs và transaction/lifetime ledger; không tách reskin thành deferred cuối game.

### Acceptance

- UI mới được thấy từ normal route, hành vi tạo kết quả thật.
- Authority không nằm trong View; không duplicate wallet/presenter callbacks.
- Save authority: Slot ownership theo session hoặc persistent phải xác minh; receipt chống double.
- Không TODO correctness hoặc fake service success.

**Verification:** compile, asmdef, lowest-layer behavior tests, normal-entry smoke

**Artifacts/ownership:** Domain/Parking, Features/ExtraSpot, Integration/RewardedAds, source→Unity GUID binding receipt

**Evidence:** Chưa có receipt reviewed

## T028 — Extra Spot và parking reservation: regression, visual/feel và acceptance

**Status:** planned · **Phase:** M04 · **Feature:** PARK · **Weight:** 2 · **Depends:** T027

**Source:** R053-extra-parking; R054-extra-spot-ad-result
**Gap/precondition:** Ad completion/cancel/error và coin mode cần xác minh

### Thực hiện

1. No-fill/cancel không unlock
2. Callback muộn của session cũ không unlock mới
3. Concurrent car không tranh slot vừa mở
4. Close popup trả input lock đúng
5. So source/clone cùng state, sửa sai khác ngay trước feature tiếp theo.
6. Ghi harness/tests/capture/audio/asset receipts đúng revision, update coverage/dashboard.

### Acceptance

- Tất cả scenario bắt buộc pass hoặc gate blocked có reason; không verified nếu còn gap bắt buộc.
- Required evidence tồn tại/hash đúng và người review kết luận.
- Không regression feature đã hoàn thành; no orphan subscription/CTS/handle/tween.

**Verification:** targeted EditMode/PlayMode theo risk, matched captures, console, device/provider nếu feature yêu cầu

**Artifacts/ownership:** evidence/PARK/, coverage delta, reviewed parity checklist

**Evidence:** Chưa có receipt reviewed

## T029 — VIP booster và xe bay: chốt source/state và contract

**Status:** planned · **Phase:** M04 · **Feature:** VIP · **Weight:** 1 · **Depends:** T028

**Source:** R046-level4-ready; R049-vip-flight
**Gap/precondition:** Inventory grant/free semantics và cancel còn thiếu

### Thực hiện

1. Mở audit/source theo IDs, bổ sung mọi gap trước khi implementation semantics.
2. Lập state graph entry/action/effect/exit/error/cancel; xác định save/session và package ownership.
3. Chốt config: VIPDefinition, target policy, flight/cue profile.
4. Chốt scope package: Economy / Tutorial candidate / Feedback / Assets; đọc source tại pin thực tế.

### Acceptance

- Mỗi behavior có source evidence hoặc explicit proposed decision.
- Asset dependencies, runtime route và failure scenarios được liệt kê.
- Unknown bắt buộc được giải quyết; không coi tên metadata là luật.

**Verification:** source-ready review, config-schema design

**Artifacts/ownership:** feature-contracts/VIP.md, source-state matrix

**Evidence:** Chưa có receipt reviewed

## T030 — VIP booster và xe bay: implement vertical slice và thay UI ngay

**Status:** planned · **Phase:** M04 · **Feature:** VIP · **Weight:** 3 · **Depends:** T029

**Source:** R046-level4-ready; R049-vip-flight
**Gap/precondition:** Inventory grant/free semantics và cancel còn thiếu

### Thực hiện

1. Tạo owner tại Features/Boosters/Vip, Application/UseVip, Presentation/VipFlight theo architecture.
2. Dùng config/save/session boundaries và service package thật; không giữ model giả cho UI.
3. Wire normal entry: Unlock4 → claim/tutorial free → chọn booster → select vehicle → flight → VIP boarding.
4. Import/bind selected art; thay address/presenter route sang UI mới trong cùng feature.
5. Hoàn thiện pressed/locked/loading/success/error/back, feedback và owned cancellation.
6. Ghi asset GUID/source IDs và transaction/lifetime ledger; không tách reskin thành deferred cuối game.

### Acceptance

- UI mới được thấy từ normal route, hành vi tạo kết quả thật.
- Authority không nằm trong View; không duplicate wallet/presenter callbacks.
- Save authority: Inventory10003 và use receipt; tutorial free tách paid use.
- Không TODO correctness hoặc fake service success.

**Verification:** compile, asmdef, lowest-layer behavior tests, normal-entry smoke

**Artifacts/ownership:** Features/Boosters/Vip, Application/UseVip, Presentation/VipFlight, source→Unity GUID binding receipt

**Evidence:** Chưa có receipt reviewed

## T031 — VIP booster và xe bay: regression, visual/feel và acceptance

**Status:** planned · **Phase:** M04 · **Feature:** VIP · **Weight:** 2 · **Depends:** T030

**Source:** R046-level4-ready; R049-vip-flight
**Gap/precondition:** Inventory grant/free semantics và cancel còn thiếu

### Thực hiện

1. Target invalid/cancel không mất booster
2. Double tap chỉ consume1
3. Moving target/modal/retry cancels safely
4. Rotor/flight/landing, VIP outline đúng source
5. So source/clone cùng state, sửa sai khác ngay trước feature tiếp theo.
6. Ghi harness/tests/capture/audio/asset receipts đúng revision, update coverage/dashboard.

### Acceptance

- Tất cả scenario bắt buộc pass hoặc gate blocked có reason; không verified nếu còn gap bắt buộc.
- Required evidence tồn tại/hash đúng và người review kết luận.
- Không regression feature đã hoàn thành; no orphan subscription/CTS/handle/tween.

**Verification:** targeted EditMode/PlayMode theo risk, matched captures, console, device/provider nếu feature yêu cầu

**Artifacts/ownership:** evidence/VIP/, coverage delta, reviewed parity checklist

**Evidence:** Chưa có receipt reviewed

## T032 — Shop, coin packs và offers: chốt source/state và contract

**Status:** planned · **Phase:** M05 · **Feature:** SHOP · **Weight:** 1 · **Depends:** T031

**Source:** R069-shop-entry; R071-shop-coins
**Gap/precondition:** Provider SDK/product IDs, purchase state UI còn thiếu

### Thực hiện

1. Mở audit/source theo IDs, bổ sung mọi gap trước khi implementation semantics.
2. Lập state graph entry/action/effect/exit/error/cancel; xác định save/session và package ownership.
3. Chốt config: OfferCatalog, product mapping, eligibility, localized price sources.
4. Chốt scope package: Shop / Economy / DataConfig / UI / production billing adapter; đọc source tại pin thực tế.

### Acceptance

- Mỗi behavior có source evidence hoặc explicit proposed decision.
- Asset dependencies, runtime route và failure scenarios được liệt kê.
- Unknown bắt buộc được giải quyết; không coi tên metadata là luật.

**Verification:** source-ready review, config-schema design

**Artifacts/ownership:** feature-contracts/SHOP.md, source-state matrix

**Evidence:** Chưa có receipt reviewed

## T033 — Shop, coin packs và offers: implement vertical slice và thay UI ngay

**Status:** planned · **Phase:** M05 · **Feature:** SHOP · **Weight:** 5 · **Depends:** T032

**Source:** R069-shop-entry; R071-shop-coins
**Gap/precondition:** Provider SDK/product IDs, purchase state UI còn thiếu

### Thực hiện

1. Tạo owner tại Features/Shop, Integration/Billing, Data/BusFever/Offers theo architecture.
2. Dùng config/save/session boundaries và service package thật; không giữ model giả cho UI.
3. Wire normal entry: Tab Shop → scroll offers → purchase provider → pending/cancel/failure/success → reward/restore.
4. Import/bind selected art; thay address/presenter route sang UI mới trong cùng feature.
5. Hoàn thiện pressed/locked/loading/success/error/back, feedback và owned cancellation.
6. Ghi asset GUID/source IDs và transaction/lifetime ledger; không tách reskin thành deferred cuối game.
7. Tách installer riêng của Dreamy feature đang dùng; explicit dependencies, installation cleanup và reverse teardown theo 09-senior-implementation.md.

### Acceptance

- UI mới được thấy từ normal route, hành vi tạo kết quả thật.
- Authority không nằm trong View; không duplicate wallet/presenter callbacks.
- Save authority: Wallet/entitlement receipt; provider transaction ID dedupe.
- Không TODO correctness hoặc fake service success.

**Verification:** compile, asmdef, lowest-layer behavior tests, normal-entry smoke

**Artifacts/ownership:** Features/Shop, Integration/Billing, Data/BusFever/Offers, source→Unity GUID binding receipt

**Evidence:** Chưa có receipt reviewed

## T034 — Shop, coin packs và offers: regression, visual/feel và acceptance

**Status:** planned · **Phase:** M05 · **Feature:** SHOP · **Weight:** 2 · **Depends:** T033

**Source:** R069-shop-entry; R071-shop-coins
**Gap/precondition:** Provider SDK/product IDs, purchase state UI còn thiếu

### Thực hiện

1. Production thiếu provider không Purchased
2. Duplicate receipt/restart không grant2
3. Pending/cancel không giả success
4. Price locale/offer visibility theo config
5. Scroll/pool selection/reopen giữ đúng binding
6. So source/clone cùng state, sửa sai khác ngay trước feature tiếp theo.
7. Ghi harness/tests/capture/audio/asset receipts đúng revision, update coverage/dashboard.

### Acceptance

- Tất cả scenario bắt buộc pass hoặc gate blocked có reason; không verified nếu còn gap bắt buộc.
- Required evidence tồn tại/hash đúng và người review kết luận.
- Không regression feature đã hoàn thành; no orphan subscription/CTS/handle/tween.

**Verification:** targeted EditMode/PlayMode theo risk, matched captures, console, device/provider nếu feature yêu cầu

**Artifacts/ownership:** evidence/SHOP/, coverage delta, reviewed parity checklist

**Evidence:** Chưa có receipt reviewed

## T035 — Profile, avatar và nickname: chốt source/state và contract

**Status:** planned · **Phase:** M05 · **Feature:** PROFILE · **Weight:** 1 · **Depends:** T034

**Source:** R064-user-profile; R065-profile-edit
**Gap/precondition:** Invalid/save confirmation và account semantics chưa đủ

### Thực hiện

1. Mở audit/source theo IDs, bổ sung mọi gap trước khi implementation semantics.
2. Lập state graph entry/action/effect/exit/error/cancel; xác định save/session và package ownership.
3. Chốt config: AvatarCatalog9entry, nickname policy/max15, localized errors.
4. Chốt scope package: UI / Datasave / Localization candidate; đọc source tại pin thực tế.

### Acceptance

- Mỗi behavior có source evidence hoặc explicit proposed decision.
- Asset dependencies, runtime route và failure scenarios được liệt kê.
- Unknown bắt buộc được giải quyết; không coi tên metadata là luật.

**Verification:** source-ready review, config-schema design

**Artifacts/ownership:** feature-contracts/PROFILE.md, source-state matrix

**Evidence:** Chưa có receipt reviewed

## T036 — Profile, avatar và nickname: implement vertical slice và thay UI ngay

**Status:** planned · **Phase:** M05 · **Feature:** PROFILE · **Weight:** 3 · **Depends:** T035

**Source:** R064-user-profile; R065-profile-edit
**Gap/precondition:** Invalid/save confirmation và account semantics chưa đủ

### Thực hiện

1. Tạo owner tại Features/Profile, Data/BusFever/Profile, Prefabs/BusFever/Profile theo architecture.
2. Dùng config/save/session boundaries và service package thật; không giữ model giả cho UI.
3. Wire normal entry: Avatar → view stats → edit → select/name → validate → save hoặc cancel.
4. Import/bind selected art; thay address/presenter route sang UI mới trong cùng feature.
5. Hoàn thiện pressed/locked/loading/success/error/back, feedback và owned cancellation.
6. Ghi asset GUID/source IDs và transaction/lifetime ledger; không tách reskin thành deferred cuối game.

### Acceptance

- UI mới được thấy từ normal route, hành vi tạo kết quả thật.
- Authority không nằm trong View; không duplicate wallet/presenter callbacks.
- Save authority: Profile save migration; no provider account ID overwrite.
- Không TODO correctness hoặc fake service success.

**Verification:** compile, asmdef, lowest-layer behavior tests, normal-entry smoke

**Artifacts/ownership:** Features/Profile, Data/BusFever/Profile, Prefabs/BusFever/Profile, source→Unity GUID binding receipt

**Evidence:** Chưa có receipt reviewed

## T037 — Profile, avatar và nickname: regression, visual/feel và acceptance

**Status:** planned · **Phase:** M05 · **Feature:** PROFILE · **Weight:** 2 · **Depends:** T036

**Source:** R064-user-profile; R065-profile-edit
**Gap/precondition:** Invalid/save confirmation và account semantics chưa đủ

### Thực hiện

1. Empty/invalid/length boundary
2. Select rồi cancel rollback
3. Save/relaunch đúng avatar/name
4. Keyboard safearea và rich text escaping
5. So source/clone cùng state, sửa sai khác ngay trước feature tiếp theo.
6. Ghi harness/tests/capture/audio/asset receipts đúng revision, update coverage/dashboard.

### Acceptance

- Tất cả scenario bắt buộc pass hoặc gate blocked có reason; không verified nếu còn gap bắt buộc.
- Required evidence tồn tại/hash đúng và người review kết luận.
- Không regression feature đã hoàn thành; no orphan subscription/CTS/handle/tween.

**Verification:** targeted EditMode/PlayMode theo risk, matched captures, console, device/provider nếu feature yêu cầu

**Artifacts/ownership:** evidence/PROFILE/, coverage delta, reviewed parity checklist

**Evidence:** Chưa có receipt reviewed

## T038 — Supplies và hourly cooldown: chốt source/state và contract

**Status:** planned · **Phase:** M05 · **Feature:** SUPPLY · **Weight:** 1 · **Depends:** T037

**Source:** R074-supplies; R075-supplies-claimed
**Gap/precondition:** Tier unlock và trusted/offline clock policy

### Thực hiện

1. Mở audit/source theo IDs, bổ sung mọi gap trước khi implementation semantics.
2. Lập state graph entry/action/effect/exit/error/cancel; xác định save/session và package ownership.
3. Chốt config: SupplyRewardTable, cooldown/tier unlock.
4. Chốt scope package: Economy / UI / trusted clock adapter; đọc source tại pin thực tế.

### Acceptance

- Mỗi behavior có source evidence hoặc explicit proposed decision.
- Asset dependencies, runtime route và failure scenarios được liệt kê.
- Unknown bắt buộc được giải quyết; không coi tên metadata là luật.

**Verification:** source-ready review, config-schema design

**Artifacts/ownership:** feature-contracts/SUPPLY.md, source-state matrix

**Evidence:** Chưa có receipt reviewed

## T039 — Supplies và hourly cooldown: implement vertical slice và thay UI ngay

**Status:** planned · **Phase:** M05 · **Feature:** SUPPLY · **Weight:** 3 · **Depends:** T038

**Source:** R074-supplies; R075-supplies-claimed
**Gap/precondition:** Tier unlock và trusted/offline clock policy

### Thực hiện

1. Tạo owner tại Features/Supplies, Application/ClaimSupply, Integration/Clock theo architecture.
2. Dùng config/save/session boundaries và service package thật; không giữ model giả cho UI.
3. Wire normal entry: Home Supplies → free15 → grant → countdown; ad tiers theo nguồn.
4. Import/bind selected art; thay address/presenter route sang UI mới trong cùng feature.
5. Hoàn thiện pressed/locked/loading/success/error/back, feedback và owned cancellation.
6. Ghi asset GUID/source IDs và transaction/lifetime ledger; không tách reskin thành deferred cuối game.

### Acceptance

- UI mới được thấy từ normal route, hành vi tạo kết quả thật.
- Authority không nằm trong View; không duplicate wallet/presenter callbacks.
- Save authority: Claim receipt + cooldown timestamp; source of time rõ.
- Không TODO correctness hoặc fake service success.

**Verification:** compile, asmdef, lowest-layer behavior tests, normal-entry smoke

**Artifacts/ownership:** Features/Supplies, Application/ClaimSupply, Integration/Clock, source→Unity GUID binding receipt

**Evidence:** Chưa có receipt reviewed

## T040 — Supplies và hourly cooldown: regression, visual/feel và acceptance

**Status:** planned · **Phase:** M05 · **Feature:** SUPPLY · **Weight:** 2 · **Depends:** T039

**Source:** R074-supplies; R075-supplies-claimed
**Gap/precondition:** Tier unlock và trusted/offline clock policy

### Thực hiện

1. 200→215 once; animated intermediate không truth
2. Tap2/quit ngay sau claim không grant2
3. Offline/clockrollback/restart timer
4. 20/50/70/100 tier lock và ad outcomes
5. So source/clone cùng state, sửa sai khác ngay trước feature tiếp theo.
6. Ghi harness/tests/capture/audio/asset receipts đúng revision, update coverage/dashboard.

### Acceptance

- Tất cả scenario bắt buộc pass hoặc gate blocked có reason; không verified nếu còn gap bắt buộc.
- Required evidence tồn tại/hash đúng và người review kết luận.
- Không regression feature đã hoàn thành; no orphan subscription/CTS/handle/tween.

**Verification:** targeted EditMode/PlayMode theo risk, matched captures, console, device/provider nếu feature yêu cầu

**Artifacts/ownership:** evidence/SUPPLY/, coverage delta, reviewed parity checklist

**Evidence:** Chưa có receipt reviewed

## T041 — Lucky Spin và probability info: chốt source/state và contract

**Status:** planned · **Phase:** M05 · **Feature:** SPIN · **Weight:** 1 · **Depends:** T040

**Source:** R076-spin-entry; R077-spin-info
**Gap/precondition:** Spin actual completion và rollback/recovery cần quay

### Thực hiện

1. Mở audit/source theo IDs, bổ sung mọi gap trước khi implementation semantics.
2. Lập state graph entry/action/effect/exit/error/cancel; xác định save/session và package ownership.
3. Chốt config: WheelRewardTable, weights, credit10wins, rotation profile.
4. Chốt scope package: feature.lucky-wheel candidate / Economy / Progression candidate / UI; đọc source tại pin thực tế.

### Acceptance

- Mỗi behavior có source evidence hoặc explicit proposed decision.
- Asset dependencies, runtime route và failure scenarios được liệt kê.
- Unknown bắt buộc được giải quyết; không coi tên metadata là luật.

**Verification:** source-ready review, config-schema design

**Artifacts/ownership:** feature-contracts/SPIN.md, source-state matrix

**Evidence:** Chưa có receipt reviewed

## T042 — Lucky Spin và probability info: implement vertical slice và thay UI ngay

**Status:** planned · **Phase:** M05 · **Feature:** SPIN · **Weight:** 3 · **Depends:** T041

**Source:** R076-spin-entry; R077-spin-info
**Gap/precondition:** Spin actual completion và rollback/recovery cần quay

### Thực hiện

1. Tạo owner tại Features/Spin, Integration/LuckyWheel, Data/BusFever/Spin theo architecture.
2. Dùng config/save/session boundaries và service package thật; không giữ model giả cho UI.
3. Wire normal entry: Open wheel → info → level credit/free-ad → spin → grant → claim/exit.
4. Import/bind selected art; thay address/presenter route sang UI mới trong cùng feature.
5. Hoàn thiện pressed/locked/loading/success/error/back, feedback và owned cancellation.
6. Ghi asset GUID/source IDs và transaction/lifetime ledger; không tách reskin thành deferred cuối game.
7. Tách installer riêng của Dreamy feature đang dùng; explicit dependencies, installation cleanup và reverse teardown theo 09-senior-implementation.md.

### Acceptance

- UI mới được thấy từ normal route, hành vi tạo kết quả thật.
- Authority không nằm trong View; không duplicate wallet/presenter callbacks.
- Save authority: Spin request/result receipt persisted trước visual; credit consumed once.
- Không TODO correctness hoặc fake service success.

**Verification:** compile, asmdef, lowest-layer behavior tests, normal-entry smoke

**Artifacts/ownership:** Features/Spin, Integration/LuckyWheel, Data/BusFever/Spin, source→Unity GUID binding receipt

**Evidence:** Chưa có receipt reviewed

## T043 — Lucky Spin và probability info: regression, visual/feel và acceptance

**Status:** planned · **Phase:** M05 · **Feature:** SPIN · **Weight:** 2 · **Depends:** T042

**Source:** R076-spin-entry; R077-spin-info
**Gap/precondition:** Spin actual completion và rollback/recovery cần quay

### Thực hiện

1. Weights boundaries + deterministic seeded test
2. Không suy weight từ lát bánh
3. Close/relaunch giữa spin không reroll grant
4. Progress reset/new-cycle và ad cancel
5. Pointer/deceleration/audio sync theo capture
6. So source/clone cùng state, sửa sai khác ngay trước feature tiếp theo.
7. Ghi harness/tests/capture/audio/asset receipts đúng revision, update coverage/dashboard.

### Acceptance

- Tất cả scenario bắt buộc pass hoặc gate blocked có reason; không verified nếu còn gap bắt buộc.
- Required evidence tồn tại/hash đúng và người review kết luận.
- Không regression feature đã hoàn thành; no orphan subscription/CTS/handle/tween.

**Verification:** targeted EditMode/PlayMode theo risk, matched captures, console, device/provider nếu feature yêu cầu

**Artifacts/ownership:** evidence/SPIN/, coverage delta, reviewed parity checklist

**Evidence:** Chưa có receipt reviewed

## T044 — Daily Bonus đầy đủ: chốt source/state và contract

**Status:** planned · **Phase:** M06 · **Feature:** DAILY · **Weight:** 1 · **Depends:** T043

**Source:** static dailybonus bundle
**Gap/precondition:** BLOCK source-ready: chưa runtime entry/claim/reset

### Thực hiện

1. Mở audit/source theo IDs, bổ sung mọi gap trước khi implementation semantics.
2. Lập state graph entry/action/effect/exit/error/cancel; xác định save/session và package ownership.
3. Chốt config: DailyRewardCatalog, cycle/reset/grace policy.
4. Chốt scope package: feature.daily-reward candidate / Economy / UI; đọc source tại pin thực tế.

### Acceptance

- Mỗi behavior có source evidence hoặc explicit proposed decision.
- Asset dependencies, runtime route và failure scenarios được liệt kê.
- Unknown bắt buộc được giải quyết; không coi tên metadata là luật.

**Verification:** source-ready review, config-schema design

**Artifacts/ownership:** feature-contracts/DAILY.md, source-state matrix

**Evidence:** Chưa có receipt reviewed

## T045 — Daily Bonus đầy đủ: implement vertical slice và thay UI ngay

**Status:** planned · **Phase:** M06 · **Feature:** DAILY · **Weight:** 3 · **Depends:** T044

**Source:** static dailybonus bundle
**Gap/precondition:** BLOCK source-ready: chưa runtime entry/claim/reset

### Thực hiện

1. Tạo owner tại Features/DailyBonus, Integration/DailyReward, Prefabs/BusFever/DailyBonus theo architecture.
2. Dùng config/save/session boundaries và service package thật; không giữ model giả cho UI.
3. Wire normal entry: Eligible entry → calendar/day → claim → reward → cooldown/new day.
4. Import/bind selected art; thay address/presenter route sang UI mới trong cùng feature.
5. Hoàn thiện pressed/locked/loading/success/error/back, feedback và owned cancellation.
6. Ghi asset GUID/source IDs và transaction/lifetime ledger; không tách reskin thành deferred cuối game.
7. Tách installer riêng của Dreamy feature đang dùng; explicit dependencies, installation cleanup và reverse teardown theo 09-senior-implementation.md.

### Acceptance

- UI mới được thấy từ normal route, hành vi tạo kết quả thật.
- Authority không nằm trong View; không duplicate wallet/presenter callbacks.
- Save authority: Claim/day/cycle receipts, timezone/trusted clock.
- Không TODO correctness hoặc fake service success.

**Verification:** compile, asmdef, lowest-layer behavior tests, normal-entry smoke

**Artifacts/ownership:** Features/DailyBonus, Integration/DailyReward, Prefabs/BusFever/DailyBonus, source→Unity GUID binding receipt

**Evidence:** Chưa có receipt reviewed

## T046 — Daily Bonus đầy đủ: regression, visual/feel và acceptance

**Status:** planned · **Phase:** M06 · **Feature:** DAILY · **Weight:** 2 · **Depends:** T045

**Source:** static dailybonus bundle
**Gap/precondition:** BLOCK source-ready: chưa runtime entry/claim/reset

### Thực hiện

1. Same day claim2 không grant2
2. Cross midnight/offline/clockback
3. Interrupted bundle claim/retry
4. All calendar/locked/claimed/error states
5. So source/clone cùng state, sửa sai khác ngay trước feature tiếp theo.
6. Ghi harness/tests/capture/audio/asset receipts đúng revision, update coverage/dashboard.

### Acceptance

- Tất cả scenario bắt buộc pass hoặc gate blocked có reason; không verified nếu còn gap bắt buộc.
- Required evidence tồn tại/hash đúng và người review kết luận.
- Không regression feature đã hoàn thành; no orphan subscription/CTS/handle/tween.

**Verification:** targeted EditMode/PlayMode theo risk, matched captures, console, device/provider nếu feature yêu cầu

**Artifacts/ownership:** evidence/DAILY/, coverage delta, reviewed parity checklist

**Evidence:** Chưa có receipt reviewed

## T047 — Life, refill và resource recovery: chốt source/state và contract

**Status:** planned · **Phase:** M06 · **Feature:** LIFE · **Weight:** 1 · **Depends:** T046

**Source:** static life bundle; template economy recovery
**Gap/precondition:** BLOCK source-ready: life visibility/cost chưa xác minh

### Thực hiện

1. Mở audit/source theo IDs, bổ sung mọi gap trước khi implementation semantics.
2. Lập state graph entry/action/effect/exit/error/cancel; xác định save/session và package ownership.
3. Chốt config: LifePolicy, cap/refill interval, cost points.
4. Chốt scope package: Economy recovery / Datasave / UI; clock adapter; đọc source tại pin thực tế.

### Acceptance

- Mỗi behavior có source evidence hoặc explicit proposed decision.
- Asset dependencies, runtime route và failure scenarios được liệt kê.
- Unknown bắt buộc được giải quyết; không coi tên metadata là luật.

**Verification:** source-ready review, config-schema design

**Artifacts/ownership:** feature-contracts/LIFE.md, source-state matrix

**Evidence:** Chưa có receipt reviewed

## T048 — Life, refill và resource recovery: implement vertical slice và thay UI ngay

**Status:** planned · **Phase:** M06 · **Feature:** LIFE · **Weight:** 3 · **Depends:** T047

**Source:** static life bundle; template economy recovery
**Gap/precondition:** BLOCK source-ready: life visibility/cost chưa xác minh

### Thực hiện

1. Tạo owner tại Features/Life, Integration/ResourceRecovery, Application/ConsumeLife theo architecture.
2. Dùng config/save/session boundaries và service package thật; không giữ model giả cho UI.
3. Wire normal entry: Enter/retry/fail → life policy → empty/refill/timer → resume.
4. Import/bind selected art; thay address/presenter route sang UI mới trong cùng feature.
5. Hoàn thiện pressed/locked/loading/success/error/back, feedback và owned cancellation.
6. Ghi asset GUID/source IDs và transaction/lifetime ledger; không tách reskin thành deferred cuối game.

### Acceptance

- UI mới được thấy từ normal route, hành vi tạo kết quả thật.
- Authority không nằm trong View; không duplicate wallet/presenter callbacks.
- Save authority: Recovery timestamps/cap and spend receipt; no duplicate wallet.
- Không TODO correctness hoặc fake service success.

**Verification:** compile, asmdef, lowest-layer behavior tests, normal-entry smoke

**Artifacts/ownership:** Features/Life, Integration/ResourceRecovery, Application/ConsumeLife, source→Unity GUID binding receipt

**Evidence:** Chưa có receipt reviewed

## T049 — Life, refill và resource recovery: regression, visual/feel và acceptance

**Status:** planned · **Phase:** M06 · **Feature:** LIFE · **Weight:** 2 · **Depends:** T048

**Source:** static life bundle; template economy recovery
**Gap/precondition:** BLOCK source-ready: life visibility/cost chưa xác minh

### Thực hiện

1. At cap/backfill/clock discontinuity
2. Fail/retry costs theo source
3. Ad/purchase refill cancel/latecallback
4. Resume after days clamp correctly
5. So source/clone cùng state, sửa sai khác ngay trước feature tiếp theo.
6. Ghi harness/tests/capture/audio/asset receipts đúng revision, update coverage/dashboard.

### Acceptance

- Tất cả scenario bắt buộc pass hoặc gate blocked có reason; không verified nếu còn gap bắt buộc.
- Required evidence tồn tại/hash đúng và người review kết luận.
- Không regression feature đã hoàn thành; no orphan subscription/CTS/handle/tween.

**Verification:** targeted EditMode/PlayMode theo risk, matched captures, console, device/provider nếu feature yêu cầu

**Artifacts/ownership:** evidence/LIFE/, coverage delta, reviewed parity checklist

**Evidence:** Chưa có receipt reviewed

## T050 — Booster Jumble: chốt source/state và contract

**Status:** planned · **Phase:** M06 · **Feature:** JUMBLE · **Weight:** 1 · **Depends:** T049

**Source:** static ItemPropConfigJumble; locked8/13 captures
**Gap/precondition:** BLOCK source-ready: chưa xác định mốc/luật thực

### Thực hiện

1. Mở audit/source theo IDs, bổ sung mọi gap trước khi implementation semantics.
2. Lập state graph entry/action/effect/exit/error/cancel; xác định save/session và package ownership.
3. Chốt config: JumbleRule, permutation/target policy, cue profile.
4. Chốt scope package: Economy / Feedback / Audio / Tutorial candidate; đọc source tại pin thực tế.

### Acceptance

- Mỗi behavior có source evidence hoặc explicit proposed decision.
- Asset dependencies, runtime route và failure scenarios được liệt kê.
- Unknown bắt buộc được giải quyết; không coi tên metadata là luật.

**Verification:** source-ready review, config-schema design

**Artifacts/ownership:** feature-contracts/JUMBLE.md, source-state matrix

**Evidence:** Chưa có receipt reviewed

## T051 — Booster Jumble: implement vertical slice và thay UI ngay

**Status:** planned · **Phase:** M06 · **Feature:** JUMBLE · **Weight:** 3 · **Depends:** T050

**Source:** static ItemPropConfigJumble; locked8/13 captures
**Gap/precondition:** BLOCK source-ready: chưa xác định mốc/luật thực

### Thực hiện

1. Tạo owner tại Features/Boosters/Jumble, Domain/JumblePolicy, Presentation/Jumble theo architecture.
2. Dùng config/save/session boundaries và service package thật; không giữ model giả cho UI.
3. Wire normal entry: Unlock milestone → choose booster → valid effect → re-evaluate board.
4. Import/bind selected art; thay address/presenter route sang UI mới trong cùng feature.
5. Hoàn thiện pressed/locked/loading/success/error/back, feedback và owned cancellation.
6. Ghi asset GUID/source IDs và transaction/lifetime ledger; không tách reskin thành deferred cuối game.

### Acceptance

- UI mới được thấy từ normal route, hành vi tạo kết quả thật.
- Authority không nằm trong View; không duplicate wallet/presenter callbacks.
- Save authority: Inventory10002/use receipt; session version invalidation.
- Không TODO correctness hoặc fake service success.

**Verification:** compile, asmdef, lowest-layer behavior tests, normal-entry smoke

**Artifacts/ownership:** Features/Boosters/Jumble, Domain/JumblePolicy, Presentation/Jumble, source→Unity GUID binding receipt

**Evidence:** Chưa có receipt reviewed

## T052 — Booster Jumble: regression, visual/feel và acceptance

**Status:** planned · **Phase:** M06 · **Feature:** JUMBLE · **Weight:** 2 · **Depends:** T051

**Source:** static ItemPropConfigJumble; locked8/13 captures
**Gap/precondition:** BLOCK source-ready: chưa xác định mốc/luật thực

### Thực hiện

1. No valid targets → no spend
2. Permutation giữ entity identity/count/color theo source
3. Blocked/moving entities và retry
4. Result deterministic fixture, animation cancel safe
5. So source/clone cùng state, sửa sai khác ngay trước feature tiếp theo.
6. Ghi harness/tests/capture/audio/asset receipts đúng revision, update coverage/dashboard.

### Acceptance

- Tất cả scenario bắt buộc pass hoặc gate blocked có reason; không verified nếu còn gap bắt buộc.
- Required evidence tồn tại/hash đúng và người review kết luận.
- Không regression feature đã hoàn thành; no orphan subscription/CTS/handle/tween.

**Verification:** targeted EditMode/PlayMode theo risk, matched captures, console, device/provider nếu feature yêu cầu

**Artifacts/ownership:** evidence/JUMBLE/, coverage delta, reviewed parity checklist

**Evidence:** Chưa có receipt reviewed

## T053 — Booster Arrange: chốt source/state và contract

**Status:** planned · **Phase:** M06 · **Feature:** ARRANGE · **Weight:** 1 · **Depends:** T052

**Source:** static ItemPropConfigArrange
**Gap/precondition:** BLOCK source-ready: chưa chơi booster và unlock

### Thực hiện

1. Mở audit/source theo IDs, bổ sung mọi gap trước khi implementation semantics.
2. Lập state graph entry/action/effect/exit/error/cancel; xác định save/session và package ownership.
3. Chốt config: ArrangeRule, boardingInterval0.1, spiral curve profile from audit.
4. Chốt scope package: Economy / Feedback / Audio / Tutorial candidate; đọc source tại pin thực tế.

### Acceptance

- Mỗi behavior có source evidence hoặc explicit proposed decision.
- Asset dependencies, runtime route và failure scenarios được liệt kê.
- Unknown bắt buộc được giải quyết; không coi tên metadata là luật.

**Verification:** source-ready review, config-schema design

**Artifacts/ownership:** feature-contracts/ARRANGE.md, source-state matrix

**Evidence:** Chưa có receipt reviewed

## T054 — Booster Arrange: implement vertical slice và thay UI ngay

**Status:** planned · **Phase:** M06 · **Feature:** ARRANGE · **Weight:** 3 · **Depends:** T053

**Source:** static ItemPropConfigArrange
**Gap/precondition:** BLOCK source-ready: chưa chơi booster và unlock

### Thực hiện

1. Tạo owner tại Features/Boosters/Arrange, Domain/ArrangePolicy, Presentation/Arrange theo architecture.
2. Dùng config/save/session boundaries và service package thật; không giữ model giả cho UI.
3. Wire normal entry: Unlock → invoke → select/auto-target theo nguồn → spiral boarding → complete.
4. Import/bind selected art; thay address/presenter route sang UI mới trong cùng feature.
5. Hoàn thiện pressed/locked/loading/success/error/back, feedback và owned cancellation.
6. Ghi asset GUID/source IDs và transaction/lifetime ledger; không tách reskin thành deferred cuối game.

### Acceptance

- UI mới được thấy từ normal route, hành vi tạo kết quả thật.
- Authority không nằm trong View; không duplicate wallet/presenter callbacks.
- Save authority: Inventory10001/use receipt, logical boarding atomic.
- Không TODO correctness hoặc fake service success.

**Verification:** compile, asmdef, lowest-layer behavior tests, normal-entry smoke

**Artifacts/ownership:** Features/Boosters/Arrange, Domain/ArrangePolicy, Presentation/Arrange, source→Unity GUID binding receipt

**Evidence:** Chưa có receipt reviewed

## T055 — Booster Arrange: regression, visual/feel và acceptance

**Status:** planned · **Phase:** M06 · **Feature:** ARRANGE · **Weight:** 2 · **Depends:** T054

**Source:** static ItemPropConfigArrange
**Gap/precondition:** BLOCK source-ready: chưa chơi booster và unlock

### Thực hiện

1. Insufficient item/repeated click
2. Target order/count theo source
3. Spiral interruption không duplicate passenger
4. Same state trước/sau, sound cue timing
5. So source/clone cùng state, sửa sai khác ngay trước feature tiếp theo.
6. Ghi harness/tests/capture/audio/asset receipts đúng revision, update coverage/dashboard.

### Acceptance

- Tất cả scenario bắt buộc pass hoặc gate blocked có reason; không verified nếu còn gap bắt buộc.
- Required evidence tồn tại/hash đúng và người review kết luận.
- Không regression feature đã hoàn thành; no orphan subscription/CTS/handle/tween.

**Verification:** targeted EditMode/PlayMode theo risk, matched captures, console, device/provider nếu feature yêu cầu

**Artifacts/ownership:** evidence/ARRANGE/, coverage delta, reviewed parity checklist

**Evidence:** Chưa có receipt reviewed

## T056 — Garage/container spawning: chốt source/state và contract

**Status:** planned · **Phase:** M07 · **Feature:** MECH-GARAGE · **Weight:** 1 · **Depends:** T055

**Source:** metadata/guide/config candidate only
**Gap/precondition:** BLOCK source-ready: cần runtime và level data cho family này

### Thực hiện

1. Mở audit/source theo IDs, bổ sung mọi gap trước khi implementation semantics.
2. Lập state graph entry/action/effect/exit/error/cancel; xác định save/session và package ownership.
3. Chốt config: GARAGEMechanismDefinition + rule/timing profile.
4. Chốt scope package: project Domain / Tutorial candidate / Feedback / Assets; đọc source tại pin thực tế.

### Acceptance

- Mỗi behavior có source evidence hoặc explicit proposed decision.
- Asset dependencies, runtime route và failure scenarios được liệt kê.
- Unknown bắt buộc được giải quyết; không coi tên metadata là luật.

**Verification:** source-ready review, config-schema design

**Artifacts/ownership:** feature-contracts/MECH-GARAGE.md, source-state matrix

**Evidence:** Chưa có receipt reviewed

## T057 — Garage/container spawning: implement vertical slice và thay UI ngay

**Status:** planned · **Phase:** M07 · **Feature:** MECH-GARAGE · **Weight:** 5 · **Depends:** T056

**Source:** metadata/guide/config candidate only
**Gap/precondition:** BLOCK source-ready: cần runtime và level data cho family này

### Thực hiện

1. Tạo owner tại Domain/Mechanisms/GARAGE, Features/Mechanisms/GARAGE, Presentation/Mechanisms/GARAGE theo architecture.
2. Dùng config/save/session boundaries và service package thật; không giữ model giả cho UI.
3. Wire normal entry: Load level family → inspect spawn/block/release order và preview count → input → resolve effects → win/fail/exit.
4. Import/bind selected art; thay address/presenter route sang UI mới trong cùng feature.
5. Hoàn thiện pressed/locked/loading/success/error/back, feedback và owned cancellation.
6. Ghi asset GUID/source IDs và transaction/lifetime ledger; không tách reskin thành deferred cuối game.

### Acceptance

- UI mới được thấy từ normal route, hành vi tạo kết quả thật.
- Authority không nằm trong View; không duplicate wallet/presenter callbacks.
- Save authority: Logical mechanism state in session; persist only source-proven progress.
- Không TODO correctness hoặc fake service success.

**Verification:** compile, asmdef, lowest-layer behavior tests, normal-entry smoke

**Artifacts/ownership:** Domain/Mechanisms/GARAGE, Features/Mechanisms/GARAGE, Presentation/Mechanisms/GARAGE, source→Unity GUID binding receipt

**Evidence:** Chưa có receipt reviewed

## T058 — Garage/container spawning: regression, visual/feel và acceptance

**Status:** planned · **Phase:** M07 · **Feature:** MECH-GARAGE · **Weight:** 2 · **Depends:** T057

**Source:** metadata/guide/config candidate only
**Gap/precondition:** BLOCK source-ready: cần runtime và level data cho family này

### Thực hiện

1. Golden layout fixture and spawn/block/release order và preview count
2. Conflicting input/reservation boundary
3. Retry/pause/revive/cancel during effect
4. Tutorial target/sort/audio/material matched source
5. So source/clone cùng state, sửa sai khác ngay trước feature tiếp theo.
6. Ghi harness/tests/capture/audio/asset receipts đúng revision, update coverage/dashboard.

### Acceptance

- Tất cả scenario bắt buộc pass hoặc gate blocked có reason; không verified nếu còn gap bắt buộc.
- Required evidence tồn tại/hash đúng và người review kết luận.
- Không regression feature đã hoàn thành; no orphan subscription/CTS/handle/tween.

**Verification:** targeted EditMode/PlayMode theo risk, matched captures, console, device/provider nếu feature yêu cầu

**Artifacts/ownership:** evidence/MECH-GARAGE/, coverage delta, reviewed parity checklist

**Evidence:** Chưa có receipt reviewed

## T059 — Conveyor và Gate Queue: chốt source/state và contract

**Status:** planned · **Phase:** M07 · **Feature:** MECH-BELT · **Weight:** 1 · **Depends:** T058

**Source:** metadata/guide/config candidate only
**Gap/precondition:** BLOCK source-ready: cần runtime và level data cho family này

### Thực hiện

1. Mở audit/source theo IDs, bổ sung mọi gap trước khi implementation semantics.
2. Lập state graph entry/action/effect/exit/error/cancel; xác định save/session và package ownership.
3. Chốt config: BELTMechanismDefinition + rule/timing profile.
4. Chốt scope package: project Domain / Tutorial candidate / Feedback / Assets; đọc source tại pin thực tế.

### Acceptance

- Mỗi behavior có source evidence hoặc explicit proposed decision.
- Asset dependencies, runtime route và failure scenarios được liệt kê.
- Unknown bắt buộc được giải quyết; không coi tên metadata là luật.

**Verification:** source-ready review, config-schema design

**Artifacts/ownership:** feature-contracts/MECH-BELT.md, source-state matrix

**Evidence:** Chưa có receipt reviewed

## T060 — Conveyor và Gate Queue: implement vertical slice và thay UI ngay

**Status:** planned · **Phase:** M07 · **Feature:** MECH-BELT · **Weight:** 5 · **Depends:** T059

**Source:** metadata/guide/config candidate only
**Gap/precondition:** BLOCK source-ready: cần runtime và level data cho family này

### Thực hiện

1. Tạo owner tại Domain/Mechanisms/BELT, Features/Mechanisms/BELT, Presentation/Mechanisms/BELT theo architecture.
2. Dùng config/save/session boundaries và service package thật; không giữ model giả cho UI.
3. Wire normal entry: Load level family → inspect belt movement, queue shrink, capacity/ordering → input → resolve effects → win/fail/exit.
4. Import/bind selected art; thay address/presenter route sang UI mới trong cùng feature.
5. Hoàn thiện pressed/locked/loading/success/error/back, feedback và owned cancellation.
6. Ghi asset GUID/source IDs và transaction/lifetime ledger; không tách reskin thành deferred cuối game.

### Acceptance

- UI mới được thấy từ normal route, hành vi tạo kết quả thật.
- Authority không nằm trong View; không duplicate wallet/presenter callbacks.
- Save authority: Logical mechanism state in session; persist only source-proven progress.
- Không TODO correctness hoặc fake service success.

**Verification:** compile, asmdef, lowest-layer behavior tests, normal-entry smoke

**Artifacts/ownership:** Domain/Mechanisms/BELT, Features/Mechanisms/BELT, Presentation/Mechanisms/BELT, source→Unity GUID binding receipt

**Evidence:** Chưa có receipt reviewed

## T061 — Conveyor và Gate Queue: regression, visual/feel và acceptance

**Status:** planned · **Phase:** M07 · **Feature:** MECH-BELT · **Weight:** 2 · **Depends:** T060

**Source:** metadata/guide/config candidate only
**Gap/precondition:** BLOCK source-ready: cần runtime và level data cho family này

### Thực hiện

1. Golden layout fixture and belt movement, queue shrink, capacity/ordering
2. Conflicting input/reservation boundary
3. Retry/pause/revive/cancel during effect
4. Tutorial target/sort/audio/material matched source
5. So source/clone cùng state, sửa sai khác ngay trước feature tiếp theo.
6. Ghi harness/tests/capture/audio/asset receipts đúng revision, update coverage/dashboard.

### Acceptance

- Tất cả scenario bắt buộc pass hoặc gate blocked có reason; không verified nếu còn gap bắt buộc.
- Required evidence tồn tại/hash đúng và người review kết luận.
- Không regression feature đã hoàn thành; no orphan subscription/CTS/handle/tween.

**Verification:** targeted EditMode/PlayMode theo risk, matched captures, console, device/provider nếu feature yêu cầu

**Artifacts/ownership:** evidence/MECH-BELT/, coverage delta, reviewed parity checklist

**Evidence:** Chưa có receipt reviewed

## T062 — Turn vehicle: chốt source/state và contract

**Status:** planned · **Phase:** M07 · **Feature:** MECH-TURN · **Weight:** 1 · **Depends:** T061

**Source:** metadata/guide/config candidate only
**Gap/precondition:** BLOCK source-ready: cần runtime và level data cho family này

### Thực hiện

1. Mở audit/source theo IDs, bổ sung mọi gap trước khi implementation semantics.
2. Lập state graph entry/action/effect/exit/error/cancel; xác định save/session và package ownership.
3. Chốt config: TURNMechanismDefinition + rule/timing profile.
4. Chốt scope package: project Domain / Tutorial candidate / Feedback / Assets; đọc source tại pin thực tế.

### Acceptance

- Mỗi behavior có source evidence hoặc explicit proposed decision.
- Asset dependencies, runtime route và failure scenarios được liệt kê.
- Unknown bắt buộc được giải quyết; không coi tên metadata là luật.

**Verification:** source-ready review, config-schema design

**Artifacts/ownership:** feature-contracts/MECH-TURN.md, source-state matrix

**Evidence:** Chưa có receipt reviewed

## T063 — Turn vehicle: implement vertical slice và thay UI ngay

**Status:** planned · **Phase:** M07 · **Feature:** MECH-TURN · **Weight:** 5 · **Depends:** T062

**Source:** metadata/guide/config candidate only
**Gap/precondition:** BLOCK source-ready: cần runtime và level data cho family này

### Thực hiện

1. Tạo owner tại Domain/Mechanisms/TURN, Features/Mechanisms/TURN, Presentation/Mechanisms/TURN theo architecture.
2. Dùng config/save/session boundaries và service package thật; không giữ model giả cho UI.
3. Wire normal entry: Load level family → inspect direction switch, rotate0.25config, blocked destination → input → resolve effects → win/fail/exit.
4. Import/bind selected art; thay address/presenter route sang UI mới trong cùng feature.
5. Hoàn thiện pressed/locked/loading/success/error/back, feedback và owned cancellation.
6. Ghi asset GUID/source IDs và transaction/lifetime ledger; không tách reskin thành deferred cuối game.

### Acceptance

- UI mới được thấy từ normal route, hành vi tạo kết quả thật.
- Authority không nằm trong View; không duplicate wallet/presenter callbacks.
- Save authority: Logical mechanism state in session; persist only source-proven progress.
- Không TODO correctness hoặc fake service success.

**Verification:** compile, asmdef, lowest-layer behavior tests, normal-entry smoke

**Artifacts/ownership:** Domain/Mechanisms/TURN, Features/Mechanisms/TURN, Presentation/Mechanisms/TURN, source→Unity GUID binding receipt

**Evidence:** Chưa có receipt reviewed

## T064 — Turn vehicle: regression, visual/feel và acceptance

**Status:** planned · **Phase:** M07 · **Feature:** MECH-TURN · **Weight:** 2 · **Depends:** T063

**Source:** metadata/guide/config candidate only
**Gap/precondition:** BLOCK source-ready: cần runtime và level data cho family này

### Thực hiện

1. Golden layout fixture and direction switch, rotate0.25config, blocked destination
2. Conflicting input/reservation boundary
3. Retry/pause/revive/cancel during effect
4. Tutorial target/sort/audio/material matched source
5. So source/clone cùng state, sửa sai khác ngay trước feature tiếp theo.
6. Ghi harness/tests/capture/audio/asset receipts đúng revision, update coverage/dashboard.

### Acceptance

- Tất cả scenario bắt buộc pass hoặc gate blocked có reason; không verified nếu còn gap bắt buộc.
- Required evidence tồn tại/hash đúng và người review kết luận.
- Không regression feature đã hoàn thành; no orphan subscription/CTS/handle/tween.

**Verification:** targeted EditMode/PlayMode theo risk, matched captures, console, device/provider nếu feature yêu cầu

**Artifacts/ownership:** evidence/MECH-TURN/, coverage delta, reviewed parity checklist

**Evidence:** Chưa có receipt reviewed

## T065 — Elevator floors: chốt source/state và contract

**Status:** planned · **Phase:** M07 · **Feature:** MECH-ELEVATOR · **Weight:** 1 · **Depends:** T064

**Source:** metadata/guide/config candidate only
**Gap/precondition:** BLOCK source-ready: cần runtime và level data cho family này

### Thực hiện

1. Mở audit/source theo IDs, bổ sung mọi gap trước khi implementation semantics.
2. Lập state graph entry/action/effect/exit/error/cancel; xác định save/session và package ownership.
3. Chốt config: ELEVATORMechanismDefinition + rule/timing profile.
4. Chốt scope package: project Domain / Tutorial candidate / Feedback / Assets; đọc source tại pin thực tế.

### Acceptance

- Mỗi behavior có source evidence hoặc explicit proposed decision.
- Asset dependencies, runtime route và failure scenarios được liệt kê.
- Unknown bắt buộc được giải quyết; không coi tên metadata là luật.

**Verification:** source-ready review, config-schema design

**Artifacts/ownership:** feature-contracts/MECH-ELEVATOR.md, source-state matrix

**Evidence:** Chưa có receipt reviewed

## T066 — Elevator floors: implement vertical slice và thay UI ngay

**Status:** planned · **Phase:** M07 · **Feature:** MECH-ELEVATOR · **Weight:** 5 · **Depends:** T065

**Source:** metadata/guide/config candidate only
**Gap/precondition:** BLOCK source-ready: cần runtime và level data cho family này

### Thực hiện

1. Tạo owner tại Domain/Mechanisms/ELEVATOR, Features/Mechanisms/ELEVATOR, Presentation/Mechanisms/ELEVATOR theo architecture.
2. Dùng config/save/session boundaries và service package thật; không giữ model giả cho UI.
3. Wire normal entry: Load level family → inspect floor unlock, elevation/occlusion và interactions → input → resolve effects → win/fail/exit.
4. Import/bind selected art; thay address/presenter route sang UI mới trong cùng feature.
5. Hoàn thiện pressed/locked/loading/success/error/back, feedback và owned cancellation.
6. Ghi asset GUID/source IDs và transaction/lifetime ledger; không tách reskin thành deferred cuối game.

### Acceptance

- UI mới được thấy từ normal route, hành vi tạo kết quả thật.
- Authority không nằm trong View; không duplicate wallet/presenter callbacks.
- Save authority: Logical mechanism state in session; persist only source-proven progress.
- Không TODO correctness hoặc fake service success.

**Verification:** compile, asmdef, lowest-layer behavior tests, normal-entry smoke

**Artifacts/ownership:** Domain/Mechanisms/ELEVATOR, Features/Mechanisms/ELEVATOR, Presentation/Mechanisms/ELEVATOR, source→Unity GUID binding receipt

**Evidence:** Chưa có receipt reviewed

## T067 — Elevator floors: regression, visual/feel và acceptance

**Status:** planned · **Phase:** M07 · **Feature:** MECH-ELEVATOR · **Weight:** 2 · **Depends:** T066

**Source:** metadata/guide/config candidate only
**Gap/precondition:** BLOCK source-ready: cần runtime và level data cho family này

### Thực hiện

1. Golden layout fixture and floor unlock, elevation/occlusion và interactions
2. Conflicting input/reservation boundary
3. Retry/pause/revive/cancel during effect
4. Tutorial target/sort/audio/material matched source
5. So source/clone cùng state, sửa sai khác ngay trước feature tiếp theo.
6. Ghi harness/tests/capture/audio/asset receipts đúng revision, update coverage/dashboard.

### Acceptance

- Tất cả scenario bắt buộc pass hoặc gate blocked có reason; không verified nếu còn gap bắt buộc.
- Required evidence tồn tại/hash đúng và người review kết luận.
- Không regression feature đã hoàn thành; no orphan subscription/CTS/handle/tween.

**Verification:** targeted EditMode/PlayMode theo risk, matched captures, console, device/provider nếu feature yêu cầu

**Artifacts/ownership:** evidence/MECH-ELEVATOR/, coverage delta, reviewed parity checklist

**Evidence:** Chưa có receipt reviewed

## T068 — Hidden/Doubtful colors: chốt source/state và contract

**Status:** planned · **Phase:** M07 · **Feature:** MECH-HIDDEN · **Weight:** 1 · **Depends:** T067

**Source:** metadata/guide/config candidate only
**Gap/precondition:** BLOCK source-ready: cần runtime và level data cho family này

### Thực hiện

1. Mở audit/source theo IDs, bổ sung mọi gap trước khi implementation semantics.
2. Lập state graph entry/action/effect/exit/error/cancel; xác định save/session và package ownership.
3. Chốt config: HIDDENMechanismDefinition + rule/timing profile.
4. Chốt scope package: project Domain / Tutorial candidate / Feedback / Assets; đọc source tại pin thực tế.

### Acceptance

- Mỗi behavior có source evidence hoặc explicit proposed decision.
- Asset dependencies, runtime route và failure scenarios được liệt kê.
- Unknown bắt buộc được giải quyết; không coi tên metadata là luật.

**Verification:** source-ready review, config-schema design

**Artifacts/ownership:** feature-contracts/MECH-HIDDEN.md, source-state matrix

**Evidence:** Chưa có receipt reviewed

## T069 — Hidden/Doubtful colors: implement vertical slice và thay UI ngay

**Status:** planned · **Phase:** M07 · **Feature:** MECH-HIDDEN · **Weight:** 5 · **Depends:** T068

**Source:** metadata/guide/config candidate only
**Gap/precondition:** BLOCK source-ready: cần runtime và level data cho family này

### Thực hiện

1. Tạo owner tại Domain/Mechanisms/HIDDEN, Features/Mechanisms/HIDDEN, Presentation/Mechanisms/HIDDEN theo architecture.
2. Dùng config/save/session boundaries và service package thật; không giữ model giả cho UI.
3. Wire normal entry: Load level family → inspect reveal trigger, hidden collision/render rule → input → resolve effects → win/fail/exit.
4. Import/bind selected art; thay address/presenter route sang UI mới trong cùng feature.
5. Hoàn thiện pressed/locked/loading/success/error/back, feedback và owned cancellation.
6. Ghi asset GUID/source IDs và transaction/lifetime ledger; không tách reskin thành deferred cuối game.

### Acceptance

- UI mới được thấy từ normal route, hành vi tạo kết quả thật.
- Authority không nằm trong View; không duplicate wallet/presenter callbacks.
- Save authority: Logical mechanism state in session; persist only source-proven progress.
- Không TODO correctness hoặc fake service success.

**Verification:** compile, asmdef, lowest-layer behavior tests, normal-entry smoke

**Artifacts/ownership:** Domain/Mechanisms/HIDDEN, Features/Mechanisms/HIDDEN, Presentation/Mechanisms/HIDDEN, source→Unity GUID binding receipt

**Evidence:** Chưa có receipt reviewed

## T070 — Hidden/Doubtful colors: regression, visual/feel và acceptance

**Status:** planned · **Phase:** M07 · **Feature:** MECH-HIDDEN · **Weight:** 2 · **Depends:** T069

**Source:** metadata/guide/config candidate only
**Gap/precondition:** BLOCK source-ready: cần runtime và level data cho family này

### Thực hiện

1. Golden layout fixture and reveal trigger, hidden collision/render rule
2. Conflicting input/reservation boundary
3. Retry/pause/revive/cancel during effect
4. Tutorial target/sort/audio/material matched source
5. So source/clone cùng state, sửa sai khác ngay trước feature tiếp theo.
6. Ghi harness/tests/capture/audio/asset receipts đúng revision, update coverage/dashboard.

### Acceptance

- Tất cả scenario bắt buộc pass hoặc gate blocked có reason; không verified nếu còn gap bắt buộc.
- Required evidence tồn tại/hash đúng và người review kết luận.
- Không regression feature đã hoàn thành; no orphan subscription/CTS/handle/tween.

**Verification:** targeted EditMode/PlayMode theo risk, matched captures, console, device/provider nếu feature yêu cầu

**Artifacts/ownership:** evidence/MECH-HIDDEN/, coverage delta, reviewed parity checklist

**Evidence:** Chưa có receipt reviewed

## T071 — Combination vehicles: chốt source/state và contract

**Status:** planned · **Phase:** M07 · **Feature:** MECH-COMBO · **Weight:** 1 · **Depends:** T070

**Source:** metadata/guide/config candidate only
**Gap/precondition:** BLOCK source-ready: cần runtime và level data cho family này

### Thực hiện

1. Mở audit/source theo IDs, bổ sung mọi gap trước khi implementation semantics.
2. Lập state graph entry/action/effect/exit/error/cancel; xác định save/session và package ownership.
3. Chốt config: COMBOMechanismDefinition + rule/timing profile.
4. Chốt scope package: project Domain / Tutorial candidate / Feedback / Assets; đọc source tại pin thực tế.

### Acceptance

- Mỗi behavior có source evidence hoặc explicit proposed decision.
- Asset dependencies, runtime route và failure scenarios được liệt kê.
- Unknown bắt buộc được giải quyết; không coi tên metadata là luật.

**Verification:** source-ready review, config-schema design

**Artifacts/ownership:** feature-contracts/MECH-COMBO.md, source-state matrix

**Evidence:** Chưa có receipt reviewed

## T072 — Combination vehicles: implement vertical slice và thay UI ngay

**Status:** planned · **Phase:** M07 · **Feature:** MECH-COMBO · **Weight:** 5 · **Depends:** T071

**Source:** metadata/guide/config candidate only
**Gap/precondition:** BLOCK source-ready: cần runtime và level data cho family này

### Thực hiện

1. Tạo owner tại Domain/Mechanisms/COMBO, Features/Mechanisms/COMBO, Presentation/Mechanisms/COMBO theo architecture.
2. Dùng config/save/session boundaries và service package thật; không giữ model giả cho UI.
3. Wire normal entry: Load level family → inspect compound bounds/capacity và movement constraints → input → resolve effects → win/fail/exit.
4. Import/bind selected art; thay address/presenter route sang UI mới trong cùng feature.
5. Hoàn thiện pressed/locked/loading/success/error/back, feedback và owned cancellation.
6. Ghi asset GUID/source IDs và transaction/lifetime ledger; không tách reskin thành deferred cuối game.

### Acceptance

- UI mới được thấy từ normal route, hành vi tạo kết quả thật.
- Authority không nằm trong View; không duplicate wallet/presenter callbacks.
- Save authority: Logical mechanism state in session; persist only source-proven progress.
- Không TODO correctness hoặc fake service success.

**Verification:** compile, asmdef, lowest-layer behavior tests, normal-entry smoke

**Artifacts/ownership:** Domain/Mechanisms/COMBO, Features/Mechanisms/COMBO, Presentation/Mechanisms/COMBO, source→Unity GUID binding receipt

**Evidence:** Chưa có receipt reviewed

## T073 — Combination vehicles: regression, visual/feel và acceptance

**Status:** planned · **Phase:** M07 · **Feature:** MECH-COMBO · **Weight:** 2 · **Depends:** T072

**Source:** metadata/guide/config candidate only
**Gap/precondition:** BLOCK source-ready: cần runtime và level data cho family này

### Thực hiện

1. Golden layout fixture and compound bounds/capacity và movement constraints
2. Conflicting input/reservation boundary
3. Retry/pause/revive/cancel during effect
4. Tutorial target/sort/audio/material matched source
5. So source/clone cùng state, sửa sai khác ngay trước feature tiếp theo.
6. Ghi harness/tests/capture/audio/asset receipts đúng revision, update coverage/dashboard.

### Acceptance

- Tất cả scenario bắt buộc pass hoặc gate blocked có reason; không verified nếu còn gap bắt buộc.
- Required evidence tồn tại/hash đúng và người review kết luận.
- Không regression feature đã hoàn thành; no orphan subscription/CTS/handle/tween.

**Verification:** targeted EditMode/PlayMode theo risk, matched captures, console, device/provider nếu feature yêu cầu

**Artifacts/ownership:** evidence/MECH-COMBO/, coverage delta, reviewed parity checklist

**Evidence:** Chưa có receipt reviewed

## T074 — Linkage vehicles: chốt source/state và contract

**Status:** planned · **Phase:** M07 · **Feature:** MECH-LINK · **Weight:** 1 · **Depends:** T073

**Source:** metadata/guide/config candidate only
**Gap/precondition:** BLOCK source-ready: cần runtime và level data cho family này

### Thực hiện

1. Mở audit/source theo IDs, bổ sung mọi gap trước khi implementation semantics.
2. Lập state graph entry/action/effect/exit/error/cancel; xác định save/session và package ownership.
3. Chốt config: LINKMechanismDefinition + rule/timing profile.
4. Chốt scope package: project Domain / Tutorial candidate / Feedback / Assets; đọc source tại pin thực tế.

### Acceptance

- Mỗi behavior có source evidence hoặc explicit proposed decision.
- Asset dependencies, runtime route và failure scenarios được liệt kê.
- Unknown bắt buộc được giải quyết; không coi tên metadata là luật.

**Verification:** source-ready review, config-schema design

**Artifacts/ownership:** feature-contracts/MECH-LINK.md, source-state matrix

**Evidence:** Chưa có receipt reviewed

## T075 — Linkage vehicles: implement vertical slice và thay UI ngay

**Status:** planned · **Phase:** M07 · **Feature:** MECH-LINK · **Weight:** 5 · **Depends:** T074

**Source:** metadata/guide/config candidate only
**Gap/precondition:** BLOCK source-ready: cần runtime và level data cho family này

### Thực hiện

1. Tạo owner tại Domain/Mechanisms/LINK, Features/Mechanisms/LINK, Presentation/Mechanisms/LINK theo architecture.
2. Dùng config/save/session boundaries và service package thật; không giữ model giả cho UI.
3. Wire normal entry: Load level family → inspect head/tail direction, simultaneous reservation, broken link protection → input → resolve effects → win/fail/exit.
4. Import/bind selected art; thay address/presenter route sang UI mới trong cùng feature.
5. Hoàn thiện pressed/locked/loading/success/error/back, feedback và owned cancellation.
6. Ghi asset GUID/source IDs và transaction/lifetime ledger; không tách reskin thành deferred cuối game.

### Acceptance

- UI mới được thấy từ normal route, hành vi tạo kết quả thật.
- Authority không nằm trong View; không duplicate wallet/presenter callbacks.
- Save authority: Logical mechanism state in session; persist only source-proven progress.
- Không TODO correctness hoặc fake service success.

**Verification:** compile, asmdef, lowest-layer behavior tests, normal-entry smoke

**Artifacts/ownership:** Domain/Mechanisms/LINK, Features/Mechanisms/LINK, Presentation/Mechanisms/LINK, source→Unity GUID binding receipt

**Evidence:** Chưa có receipt reviewed

## T076 — Linkage vehicles: regression, visual/feel và acceptance

**Status:** planned · **Phase:** M07 · **Feature:** MECH-LINK · **Weight:** 2 · **Depends:** T075

**Source:** metadata/guide/config candidate only
**Gap/precondition:** BLOCK source-ready: cần runtime và level data cho family này

### Thực hiện

1. Golden layout fixture and head/tail direction, simultaneous reservation, broken link protection
2. Conflicting input/reservation boundary
3. Retry/pause/revive/cancel during effect
4. Tutorial target/sort/audio/material matched source
5. So source/clone cùng state, sửa sai khác ngay trước feature tiếp theo.
6. Ghi harness/tests/capture/audio/asset receipts đúng revision, update coverage/dashboard.

### Acceptance

- Tất cả scenario bắt buộc pass hoặc gate blocked có reason; không verified nếu còn gap bắt buộc.
- Required evidence tồn tại/hash đúng và người review kết luận.
- Không regression feature đã hoàn thành; no orphan subscription/CTS/handle/tween.

**Verification:** targeted EditMode/PlayMode theo risk, matched captures, console, device/provider nếu feature yêu cầu

**Artifacts/ownership:** evidence/MECH-LINK/, coverage delta, reviewed parity checklist

**Evidence:** Chưa có receipt reviewed

## T077 — Wrench/Gear lock: chốt source/state và contract

**Status:** planned · **Phase:** M07 · **Feature:** MECH-WRENCH · **Weight:** 1 · **Depends:** T076

**Source:** metadata/guide/config candidate only
**Gap/precondition:** BLOCK source-ready: cần runtime và level data cho family này

### Thực hiện

1. Mở audit/source theo IDs, bổ sung mọi gap trước khi implementation semantics.
2. Lập state graph entry/action/effect/exit/error/cancel; xác định save/session và package ownership.
3. Chốt config: WRENCHMechanismDefinition + rule/timing profile.
4. Chốt scope package: project Domain / Tutorial candidate / Feedback / Assets; đọc source tại pin thực tế.

### Acceptance

- Mỗi behavior có source evidence hoặc explicit proposed decision.
- Asset dependencies, runtime route và failure scenarios được liệt kê.
- Unknown bắt buộc được giải quyết; không coi tên metadata là luật.

**Verification:** source-ready review, config-schema design

**Artifacts/ownership:** feature-contracts/MECH-WRENCH.md, source-state matrix

**Evidence:** Chưa có receipt reviewed

## T078 — Wrench/Gear lock: implement vertical slice và thay UI ngay

**Status:** planned · **Phase:** M07 · **Feature:** MECH-WRENCH · **Weight:** 5 · **Depends:** T077

**Source:** metadata/guide/config candidate only
**Gap/precondition:** BLOCK source-ready: cần runtime và level data cho family này

### Thực hiện

1. Tạo owner tại Domain/Mechanisms/WRENCH, Features/Mechanisms/WRENCH, Presentation/Mechanisms/WRENCH theo architecture.
2. Dùng config/save/session boundaries và service package thật; không giữ model giả cho UI.
3. Wire normal entry: Load level family → inspect key/color mapping, unlock atomic và lock visuals → input → resolve effects → win/fail/exit.
4. Import/bind selected art; thay address/presenter route sang UI mới trong cùng feature.
5. Hoàn thiện pressed/locked/loading/success/error/back, feedback và owned cancellation.
6. Ghi asset GUID/source IDs và transaction/lifetime ledger; không tách reskin thành deferred cuối game.

### Acceptance

- UI mới được thấy từ normal route, hành vi tạo kết quả thật.
- Authority không nằm trong View; không duplicate wallet/presenter callbacks.
- Save authority: Logical mechanism state in session; persist only source-proven progress.
- Không TODO correctness hoặc fake service success.

**Verification:** compile, asmdef, lowest-layer behavior tests, normal-entry smoke

**Artifacts/ownership:** Domain/Mechanisms/WRENCH, Features/Mechanisms/WRENCH, Presentation/Mechanisms/WRENCH, source→Unity GUID binding receipt

**Evidence:** Chưa có receipt reviewed

## T079 — Wrench/Gear lock: regression, visual/feel và acceptance

**Status:** planned · **Phase:** M07 · **Feature:** MECH-WRENCH · **Weight:** 2 · **Depends:** T078

**Source:** metadata/guide/config candidate only
**Gap/precondition:** BLOCK source-ready: cần runtime và level data cho family này

### Thực hiện

1. Golden layout fixture and key/color mapping, unlock atomic và lock visuals
2. Conflicting input/reservation boundary
3. Retry/pause/revive/cancel during effect
4. Tutorial target/sort/audio/material matched source
5. So source/clone cùng state, sửa sai khác ngay trước feature tiếp theo.
6. Ghi harness/tests/capture/audio/asset receipts đúng revision, update coverage/dashboard.

### Acceptance

- Tất cả scenario bắt buộc pass hoặc gate blocked có reason; không verified nếu còn gap bắt buộc.
- Required evidence tồn tại/hash đúng và người review kết luận.
- Không regression feature đã hoàn thành; no orphan subscription/CTS/handle/tween.

**Verification:** targeted EditMode/PlayMode theo risk, matched captures, console, device/provider nếu feature yêu cầu

**Artifacts/ownership:** evidence/MECH-WRENCH/, coverage delta, reviewed parity checklist

**Evidence:** Chưa có receipt reviewed

## T080 — Ambulance: chốt source/state và contract

**Status:** planned · **Phase:** M07 · **Feature:** MECH-AMBULANCE · **Weight:** 1 · **Depends:** T079

**Source:** metadata/guide/config candidate only
**Gap/precondition:** BLOCK source-ready: cần runtime và level data cho family này

### Thực hiện

1. Mở audit/source theo IDs, bổ sung mọi gap trước khi implementation semantics.
2. Lập state graph entry/action/effect/exit/error/cancel; xác định save/session và package ownership.
3. Chốt config: AMBULANCEMechanismDefinition + rule/timing profile.
4. Chốt scope package: project Domain / Tutorial candidate / Feedback / Assets; đọc source tại pin thực tế.

### Acceptance

- Mỗi behavior có source evidence hoặc explicit proposed decision.
- Asset dependencies, runtime route và failure scenarios được liệt kê.
- Unknown bắt buộc được giải quyết; không coi tên metadata là luật.

**Verification:** source-ready review, config-schema design

**Artifacts/ownership:** feature-contracts/MECH-AMBULANCE.md, source-state matrix

**Evidence:** Chưa có receipt reviewed

## T081 — Ambulance: implement vertical slice và thay UI ngay

**Status:** planned · **Phase:** M07 · **Feature:** MECH-AMBULANCE · **Weight:** 5 · **Depends:** T080

**Source:** metadata/guide/config candidate only
**Gap/precondition:** BLOCK source-ready: cần runtime và level data cho family này

### Thực hiện

1. Tạo owner tại Domain/Mechanisms/AMBULANCE, Features/Mechanisms/AMBULANCE, Presentation/Mechanisms/AMBULANCE theo architecture.
2. Dùng config/save/session boundaries và service package thật; không giữ model giả cho UI.
3. Wire normal entry: Load level family → inspect step budget, warning and revive step policy → input → resolve effects → win/fail/exit.
4. Import/bind selected art; thay address/presenter route sang UI mới trong cùng feature.
5. Hoàn thiện pressed/locked/loading/success/error/back, feedback và owned cancellation.
6. Ghi asset GUID/source IDs và transaction/lifetime ledger; không tách reskin thành deferred cuối game.

### Acceptance

- UI mới được thấy từ normal route, hành vi tạo kết quả thật.
- Authority không nằm trong View; không duplicate wallet/presenter callbacks.
- Save authority: Logical mechanism state in session; persist only source-proven progress.
- Không TODO correctness hoặc fake service success.

**Verification:** compile, asmdef, lowest-layer behavior tests, normal-entry smoke

**Artifacts/ownership:** Domain/Mechanisms/AMBULANCE, Features/Mechanisms/AMBULANCE, Presentation/Mechanisms/AMBULANCE, source→Unity GUID binding receipt

**Evidence:** Chưa có receipt reviewed

## T082 — Ambulance: regression, visual/feel và acceptance

**Status:** planned · **Phase:** M07 · **Feature:** MECH-AMBULANCE · **Weight:** 2 · **Depends:** T081

**Source:** metadata/guide/config candidate only
**Gap/precondition:** BLOCK source-ready: cần runtime và level data cho family này

### Thực hiện

1. Golden layout fixture and step budget, warning and revive step policy
2. Conflicting input/reservation boundary
3. Retry/pause/revive/cancel during effect
4. Tutorial target/sort/audio/material matched source
5. So source/clone cùng state, sửa sai khác ngay trước feature tiếp theo.
6. Ghi harness/tests/capture/audio/asset receipts đúng revision, update coverage/dashboard.

### Acceptance

- Tất cả scenario bắt buộc pass hoặc gate blocked có reason; không verified nếu còn gap bắt buộc.
- Required evidence tồn tại/hash đúng và người review kết luận.
- Không regression feature đã hoàn thành; no orphan subscription/CTS/handle/tween.

**Verification:** targeted EditMode/PlayMode theo risk, matched captures, console, device/provider nếu feature yêu cầu

**Artifacts/ownership:** evidence/MECH-AMBULANCE/, coverage delta, reviewed parity checklist

**Evidence:** Chưa có receipt reviewed

## T083 — Firetruck: chốt source/state và contract

**Status:** planned · **Phase:** M07 · **Feature:** MECH-FIRE · **Weight:** 1 · **Depends:** T082

**Source:** metadata/guide/config candidate only
**Gap/precondition:** BLOCK source-ready: cần runtime và level data cho family này

### Thực hiện

1. Mở audit/source theo IDs, bổ sung mọi gap trước khi implementation semantics.
2. Lập state graph entry/action/effect/exit/error/cancel; xác định save/session và package ownership.
3. Chốt config: FIREMechanismDefinition + rule/timing profile.
4. Chốt scope package: project Domain / Tutorial candidate / Feedback / Assets; đọc source tại pin thực tế.

### Acceptance

- Mỗi behavior có source evidence hoặc explicit proposed decision.
- Asset dependencies, runtime route và failure scenarios được liệt kê.
- Unknown bắt buộc được giải quyết; không coi tên metadata là luật.

**Verification:** source-ready review, config-schema design

**Artifacts/ownership:** feature-contracts/MECH-FIRE.md, source-state matrix

**Evidence:** Chưa có receipt reviewed

## T084 — Firetruck: implement vertical slice và thay UI ngay

**Status:** planned · **Phase:** M07 · **Feature:** MECH-FIRE · **Weight:** 5 · **Depends:** T083

**Source:** metadata/guide/config candidate only
**Gap/precondition:** BLOCK source-ready: cần runtime và level data cho family này

### Thực hiện

1. Tạo owner tại Domain/Mechanisms/FIRE, Features/Mechanisms/FIRE, Presentation/Mechanisms/FIRE theo architecture.
2. Dùng config/save/session boundaries và service package thật; không giữ model giả cho UI.
3. Wire normal entry: Load level family → inspect timer/fire stages, warning30/20/10 config, extinguish/fail/revive → input → resolve effects → win/fail/exit.
4. Import/bind selected art; thay address/presenter route sang UI mới trong cùng feature.
5. Hoàn thiện pressed/locked/loading/success/error/back, feedback và owned cancellation.
6. Ghi asset GUID/source IDs và transaction/lifetime ledger; không tách reskin thành deferred cuối game.

### Acceptance

- UI mới được thấy từ normal route, hành vi tạo kết quả thật.
- Authority không nằm trong View; không duplicate wallet/presenter callbacks.
- Save authority: Logical mechanism state in session; persist only source-proven progress.
- Không TODO correctness hoặc fake service success.

**Verification:** compile, asmdef, lowest-layer behavior tests, normal-entry smoke

**Artifacts/ownership:** Domain/Mechanisms/FIRE, Features/Mechanisms/FIRE, Presentation/Mechanisms/FIRE, source→Unity GUID binding receipt

**Evidence:** Chưa có receipt reviewed

## T085 — Firetruck: regression, visual/feel và acceptance

**Status:** planned · **Phase:** M07 · **Feature:** MECH-FIRE · **Weight:** 2 · **Depends:** T084

**Source:** metadata/guide/config candidate only
**Gap/precondition:** BLOCK source-ready: cần runtime và level data cho family này

### Thực hiện

1. Golden layout fixture and timer/fire stages, warning30/20/10 config, extinguish/fail/revive
2. Conflicting input/reservation boundary
3. Retry/pause/revive/cancel during effect
4. Tutorial target/sort/audio/material matched source
5. So source/clone cùng state, sửa sai khác ngay trước feature tiếp theo.
6. Ghi harness/tests/capture/audio/asset receipts đúng revision, update coverage/dashboard.

### Acceptance

- Tất cả scenario bắt buộc pass hoặc gate blocked có reason; không verified nếu còn gap bắt buộc.
- Required evidence tồn tại/hash đúng và người review kết luận.
- Không regression feature đã hoàn thành; no orphan subscription/CTS/handle/tween.

**Verification:** targeted EditMode/PlayMode theo risk, matched captures, console, device/provider nếu feature yêu cầu

**Artifacts/ownership:** evidence/MECH-FIRE/, coverage delta, reviewed parity checklist

**Evidence:** Chưa có receipt reviewed

## T086 — Police: chốt source/state và contract

**Status:** planned · **Phase:** M07 · **Feature:** MECH-POLICE · **Weight:** 1 · **Depends:** T085

**Source:** metadata/guide/config candidate only
**Gap/precondition:** BLOCK source-ready: cần runtime và level data cho family này

### Thực hiện

1. Mở audit/source theo IDs, bổ sung mọi gap trước khi implementation semantics.
2. Lập state graph entry/action/effect/exit/error/cancel; xác định save/session và package ownership.
3. Chốt config: POLICEMechanismDefinition + rule/timing profile.
4. Chốt scope package: project Domain / Tutorial candidate / Feedback / Assets; đọc source tại pin thực tế.

### Acceptance

- Mỗi behavior có source evidence hoặc explicit proposed decision.
- Asset dependencies, runtime route và failure scenarios được liệt kê.
- Unknown bắt buộc được giải quyết; không coi tên metadata là luật.

**Verification:** source-ready review, config-schema design

**Artifacts/ownership:** feature-contracts/MECH-POLICE.md, source-state matrix

**Evidence:** Chưa có receipt reviewed

## T087 — Police: implement vertical slice và thay UI ngay

**Status:** planned · **Phase:** M07 · **Feature:** MECH-POLICE · **Weight:** 5 · **Depends:** T086

**Source:** metadata/guide/config candidate only
**Gap/precondition:** BLOCK source-ready: cần runtime và level data cho family này

### Thực hiện

1. Tạo owner tại Domain/Mechanisms/POLICE, Features/Mechanisms/POLICE, Presentation/Mechanisms/POLICE theo architecture.
2. Dùng config/save/session boundaries và service package thật; không giữ model giả cho UI.
3. Wire normal entry: Load level family → inspect siren/priority/obstruction rule theo runtime → input → resolve effects → win/fail/exit.
4. Import/bind selected art; thay address/presenter route sang UI mới trong cùng feature.
5. Hoàn thiện pressed/locked/loading/success/error/back, feedback và owned cancellation.
6. Ghi asset GUID/source IDs và transaction/lifetime ledger; không tách reskin thành deferred cuối game.

### Acceptance

- UI mới được thấy từ normal route, hành vi tạo kết quả thật.
- Authority không nằm trong View; không duplicate wallet/presenter callbacks.
- Save authority: Logical mechanism state in session; persist only source-proven progress.
- Không TODO correctness hoặc fake service success.

**Verification:** compile, asmdef, lowest-layer behavior tests, normal-entry smoke

**Artifacts/ownership:** Domain/Mechanisms/POLICE, Features/Mechanisms/POLICE, Presentation/Mechanisms/POLICE, source→Unity GUID binding receipt

**Evidence:** Chưa có receipt reviewed

## T088 — Police: regression, visual/feel và acceptance

**Status:** planned · **Phase:** M07 · **Feature:** MECH-POLICE · **Weight:** 2 · **Depends:** T087

**Source:** metadata/guide/config candidate only
**Gap/precondition:** BLOCK source-ready: cần runtime và level data cho family này

### Thực hiện

1. Golden layout fixture and siren/priority/obstruction rule theo runtime
2. Conflicting input/reservation boundary
3. Retry/pause/revive/cancel during effect
4. Tutorial target/sort/audio/material matched source
5. So source/clone cùng state, sửa sai khác ngay trước feature tiếp theo.
6. Ghi harness/tests/capture/audio/asset receipts đúng revision, update coverage/dashboard.

### Acceptance

- Tất cả scenario bắt buộc pass hoặc gate blocked có reason; không verified nếu còn gap bắt buộc.
- Required evidence tồn tại/hash đúng và người review kết luận.
- Không regression feature đã hoàn thành; no orphan subscription/CTS/handle/tween.

**Verification:** targeted EditMode/PlayMode theo risk, matched captures, console, device/provider nếu feature yêu cầu

**Artifacts/ownership:** evidence/MECH-POLICE/, coverage delta, reviewed parity checklist

**Evidence:** Chưa có receipt reviewed

## T089 — Luxury/VIP passenger: chốt source/state và contract

**Status:** planned · **Phase:** M07 · **Feature:** MECH-LUXURY · **Weight:** 1 · **Depends:** T088

**Source:** metadata/guide/config candidate only
**Gap/precondition:** BLOCK source-ready: cần runtime và level data cho family này

### Thực hiện

1. Mở audit/source theo IDs, bổ sung mọi gap trước khi implementation semantics.
2. Lập state graph entry/action/effect/exit/error/cancel; xác định save/session và package ownership.
3. Chốt config: LUXURYMechanismDefinition + rule/timing profile.
4. Chốt scope package: project Domain / Tutorial candidate / Feedback / Assets; đọc source tại pin thực tế.

### Acceptance

- Mỗi behavior có source evidence hoặc explicit proposed decision.
- Asset dependencies, runtime route và failure scenarios được liệt kê.
- Unknown bắt buộc được giải quyết; không coi tên metadata là luật.

**Verification:** source-ready review, config-schema design

**Artifacts/ownership:** feature-contracts/MECH-LUXURY.md, source-state matrix

**Evidence:** Chưa có receipt reviewed

## T090 — Luxury/VIP passenger: implement vertical slice và thay UI ngay

**Status:** planned · **Phase:** M07 · **Feature:** MECH-LUXURY · **Weight:** 5 · **Depends:** T089

**Source:** metadata/guide/config candidate only
**Gap/precondition:** BLOCK source-ready: cần runtime và level data cho family này

### Thực hiện

1. Tạo owner tại Domain/Mechanisms/LUXURY, Features/Mechanisms/LUXURY, Presentation/Mechanisms/LUXURY theo architecture.
2. Dùng config/save/session boundaries và service package thật; không giữ model giả cho UI.
3. Wire normal entry: Load level family → inspect eligible passenger/capacity/priority và visuals → input → resolve effects → win/fail/exit.
4. Import/bind selected art; thay address/presenter route sang UI mới trong cùng feature.
5. Hoàn thiện pressed/locked/loading/success/error/back, feedback và owned cancellation.
6. Ghi asset GUID/source IDs và transaction/lifetime ledger; không tách reskin thành deferred cuối game.

### Acceptance

- UI mới được thấy từ normal route, hành vi tạo kết quả thật.
- Authority không nằm trong View; không duplicate wallet/presenter callbacks.
- Save authority: Logical mechanism state in session; persist only source-proven progress.
- Không TODO correctness hoặc fake service success.

**Verification:** compile, asmdef, lowest-layer behavior tests, normal-entry smoke

**Artifacts/ownership:** Domain/Mechanisms/LUXURY, Features/Mechanisms/LUXURY, Presentation/Mechanisms/LUXURY, source→Unity GUID binding receipt

**Evidence:** Chưa có receipt reviewed

## T091 — Luxury/VIP passenger: regression, visual/feel và acceptance

**Status:** planned · **Phase:** M07 · **Feature:** MECH-LUXURY · **Weight:** 2 · **Depends:** T090

**Source:** metadata/guide/config candidate only
**Gap/precondition:** BLOCK source-ready: cần runtime và level data cho family này

### Thực hiện

1. Golden layout fixture and eligible passenger/capacity/priority và visuals
2. Conflicting input/reservation boundary
3. Retry/pause/revive/cancel during effect
4. Tutorial target/sort/audio/material matched source
5. So source/clone cùng state, sửa sai khác ngay trước feature tiếp theo.
6. Ghi harness/tests/capture/audio/asset receipts đúng revision, update coverage/dashboard.

### Acceptance

- Tất cả scenario bắt buộc pass hoặc gate blocked có reason; không verified nếu còn gap bắt buộc.
- Required evidence tồn tại/hash đúng và người review kết luận.
- Không regression feature đã hoàn thành; no orphan subscription/CTS/handle/tween.

**Verification:** targeted EditMode/PlayMode theo risk, matched captures, console, device/provider nếu feature yêu cầu

**Artifacts/ownership:** evidence/MECH-LUXURY/, coverage delta, reviewed parity checklist

**Evidence:** Chưa có receipt reviewed

## T092 — Traffic light / limit count: chốt source/state và contract

**Status:** planned · **Phase:** M07 · **Feature:** MECH-TRAFFIC · **Weight:** 1 · **Depends:** T091

**Source:** metadata/guide/config candidate only
**Gap/precondition:** BLOCK source-ready: cần runtime và level data cho family này

### Thực hiện

1. Mở audit/source theo IDs, bổ sung mọi gap trước khi implementation semantics.
2. Lập state graph entry/action/effect/exit/error/cancel; xác định save/session và package ownership.
3. Chốt config: TRAFFICMechanismDefinition + rule/timing profile.
4. Chốt scope package: project Domain / Tutorial candidate / Feedback / Assets; đọc source tại pin thực tế.

### Acceptance

- Mỗi behavior có source evidence hoặc explicit proposed decision.
- Asset dependencies, runtime route và failure scenarios được liệt kê.
- Unknown bắt buộc được giải quyết; không coi tên metadata là luật.

**Verification:** source-ready review, config-schema design

**Artifacts/ownership:** feature-contracts/MECH-TRAFFIC.md, source-state matrix

**Evidence:** Chưa có receipt reviewed

## T093 — Traffic light / limit count: implement vertical slice và thay UI ngay

**Status:** planned · **Phase:** M07 · **Feature:** MECH-TRAFFIC · **Weight:** 5 · **Depends:** T092

**Source:** metadata/guide/config candidate only
**Gap/precondition:** BLOCK source-ready: cần runtime và level data cho family này

### Thực hiện

1. Tạo owner tại Domain/Mechanisms/TRAFFIC, Features/Mechanisms/TRAFFIC, Presentation/Mechanisms/TRAFFIC theo architecture.
2. Dùng config/save/session boundaries và service package thật; không giữ model giả cho UI.
3. Wire normal entry: Load level family → inspect light phase, admissible group/step limit, fail/reset → input → resolve effects → win/fail/exit.
4. Import/bind selected art; thay address/presenter route sang UI mới trong cùng feature.
5. Hoàn thiện pressed/locked/loading/success/error/back, feedback và owned cancellation.
6. Ghi asset GUID/source IDs và transaction/lifetime ledger; không tách reskin thành deferred cuối game.

### Acceptance

- UI mới được thấy từ normal route, hành vi tạo kết quả thật.
- Authority không nằm trong View; không duplicate wallet/presenter callbacks.
- Save authority: Logical mechanism state in session; persist only source-proven progress.
- Không TODO correctness hoặc fake service success.

**Verification:** compile, asmdef, lowest-layer behavior tests, normal-entry smoke

**Artifacts/ownership:** Domain/Mechanisms/TRAFFIC, Features/Mechanisms/TRAFFIC, Presentation/Mechanisms/TRAFFIC, source→Unity GUID binding receipt

**Evidence:** Chưa có receipt reviewed

## T094 — Traffic light / limit count: regression, visual/feel và acceptance

**Status:** planned · **Phase:** M07 · **Feature:** MECH-TRAFFIC · **Weight:** 2 · **Depends:** T093

**Source:** metadata/guide/config candidate only
**Gap/precondition:** BLOCK source-ready: cần runtime và level data cho family này

### Thực hiện

1. Golden layout fixture and light phase, admissible group/step limit, fail/reset
2. Conflicting input/reservation boundary
3. Retry/pause/revive/cancel during effect
4. Tutorial target/sort/audio/material matched source
5. So source/clone cùng state, sửa sai khác ngay trước feature tiếp theo.
6. Ghi harness/tests/capture/audio/asset receipts đúng revision, update coverage/dashboard.

### Acceptance

- Tất cả scenario bắt buộc pass hoặc gate blocked có reason; không verified nếu còn gap bắt buộc.
- Required evidence tồn tại/hash đúng và người review kết luận.
- Không regression feature đã hoàn thành; no orphan subscription/CTS/handle/tween.

**Verification:** targeted EditMode/PlayMode theo risk, matched captures, console, device/provider nếu feature yêu cầu

**Artifacts/ownership:** evidence/MECH-TRAFFIC/, coverage delta, reviewed parity checklist

**Evidence:** Chưa có receipt reviewed

## T095 — Leaderboard và weekly rewards: chốt source/state và contract

**Status:** planned · **Phase:** M08 · **Feature:** RANK · **Weight:** 1 · **Depends:** T094

**Source:** R073-ranking-locked; RankingConfig
**Gap/precondition:** BLOCK unlocked: cần29 + backend/provider scope

### Thực hiện

1. Mở audit/source theo IDs, bổ sung mọi gap trước khi implementation semantics.
2. Lập state graph entry/action/effect/exit/error/cancel; xác định save/session và package ownership.
3. Chốt config: RankMode/season ID/reward tiers, refresh policy.
4. Chốt scope package: UI / Economy / project leaderboard gateway; đọc source tại pin thực tế.

### Acceptance

- Mỗi behavior có source evidence hoặc explicit proposed decision.
- Asset dependencies, runtime route và failure scenarios được liệt kê.
- Unknown bắt buộc được giải quyết; không coi tên metadata là luật.

**Verification:** source-ready review, config-schema design

**Artifacts/ownership:** feature-contracts/RANK.md, source-state matrix

**Evidence:** Chưa có receipt reviewed

## T096 — Leaderboard và weekly rewards: implement vertical slice và thay UI ngay

**Status:** planned · **Phase:** M08 · **Feature:** RANK · **Weight:** 3 · **Depends:** T095

**Source:** R073-ranking-locked; RankingConfig
**Gap/precondition:** BLOCK unlocked: cần29 + backend/provider scope

### Thực hiện

1. Tạo owner tại Features/Ranking, Integration/Leaderboard, Data/BusFever/Ranking theo architecture.
2. Dùng config/save/session boundaries và service package thật; không giữ model giả cho UI.
3. Wire normal entry: Locked29 → unlock → load/cached/offline → rank → reward/reset.
4. Import/bind selected art; thay address/presenter route sang UI mới trong cùng feature.
5. Hoàn thiện pressed/locked/loading/success/error/back, feedback và owned cancellation.
6. Ghi asset GUID/source IDs và transaction/lifetime ledger; không tách reskin thành deferred cuối game.

### Acceptance

- UI mới được thấy từ normal route, hành vi tạo kết quả thật.
- Authority không nằm trong View; không duplicate wallet/presenter callbacks.
- Save authority: Per-season reward receipt; cache not fake-online result.
- Không TODO correctness hoặc fake service success.

**Verification:** compile, asmdef, lowest-layer behavior tests, normal-entry smoke

**Artifacts/ownership:** Features/Ranking, Integration/Leaderboard, Data/BusFever/Ranking, source→Unity GUID binding receipt

**Evidence:** Chưa có receipt reviewed

## T097 — Leaderboard và weekly rewards: regression, visual/feel và acceptance

**Status:** planned · **Phase:** M08 · **Feature:** RANK · **Weight:** 2 · **Depends:** T096

**Source:** R073-ranking-locked; RankingConfig
**Gap/precondition:** BLOCK unlocked: cần29 + backend/provider scope

### Thực hiện

1. Locked at6 đúng29text
2. Timeout/empty/error/offline retries
3. Weekly reset/timezone/rank reward dedupe
4. Global provider kết quả thật; local bot modes tách
5. So source/clone cùng state, sửa sai khác ngay trước feature tiếp theo.
6. Ghi harness/tests/capture/audio/asset receipts đúng revision, update coverage/dashboard.

### Acceptance

- Tất cả scenario bắt buộc pass hoặc gate blocked có reason; không verified nếu còn gap bắt buộc.
- Required evidence tồn tại/hash đúng và người review kết luận.
- Không regression feature đã hoàn thành; no orphan subscription/CTS/handle/tween.

**Verification:** targeted EditMode/PlayMode theo risk, matched captures, console, device/provider nếu feature yêu cầu

**Artifacts/ownership:** evidence/RANK/, coverage delta, reviewed parity checklist

**Evidence:** Chưa có receipt reviewed

## T098 — Task Bar, collection và timed cycle: chốt source/state và contract

**Status:** planned · **Phase:** M08 · **Feature:** TASK · **Weight:** 1 · **Depends:** T097

**Source:** TaskBarConfig + static panels
**Gap/precondition:** BLOCK source-ready: runtime event semantics missing

### Thực hiện

1. Mở audit/source theo IDs, bổ sung mọi gap trước khi implementation semantics.
2. Lập state graph entry/action/effect/exit/error/cancel; xác định save/session và package ownership.
3. Chốt config: Mission/collection templates, event cycle, expiry reward policy.
4. Chốt scope package: feature.missions candidate / Progression / Economy / UI; đọc source tại pin thực tế.

### Acceptance

- Mỗi behavior có source evidence hoặc explicit proposed decision.
- Asset dependencies, runtime route và failure scenarios được liệt kê.
- Unknown bắt buộc được giải quyết; không coi tên metadata là luật.

**Verification:** source-ready review, config-schema design

**Artifacts/ownership:** feature-contracts/TASK.md, source-state matrix

**Evidence:** Chưa có receipt reviewed

## T099 — Task Bar, collection và timed cycle: implement vertical slice và thay UI ngay

**Status:** planned · **Phase:** M08 · **Feature:** TASK · **Weight:** 3 · **Depends:** T098

**Source:** TaskBarConfig + static panels
**Gap/precondition:** BLOCK source-ready: runtime event semantics missing

### Thực hiện

1. Tạo owner tại Features/TaskBar, Integration/Missions, Application/EventCycle theo architecture.
2. Dùng config/save/session boundaries và service package thật; không giữ model giả cho UI.
3. Wire normal entry: Unlock/promo → progress from facts → bar/gift → collection → claim/expire.
4. Import/bind selected art; thay address/presenter route sang UI mới trong cùng feature.
5. Hoàn thiện pressed/locked/loading/success/error/back, feedback và owned cancellation.
6. Ghi asset GUID/source IDs và transaction/lifetime ledger; không tách reskin thành deferred cuối game.
7. Tách installer riêng của Dreamy feature đang dùng; explicit dependencies, installation cleanup và reverse teardown theo 09-senior-implementation.md.

### Acceptance

- UI mới được thấy từ normal route, hành vi tạo kết quả thật.
- Authority không nằm trong View; không duplicate wallet/presenter callbacks.
- Save authority: Counters/cycle/claim receipts; duplicate gameplay fact rejected.
- Không TODO correctness hoặc fake service success.

**Verification:** compile, asmdef, lowest-layer behavior tests, normal-entry smoke

**Artifacts/ownership:** Features/TaskBar, Integration/Missions, Application/EventCycle, source→Unity GUID binding receipt

**Evidence:** Chưa có receipt reviewed

## T100 — Task Bar, collection và timed cycle: regression, visual/feel và acceptance

**Status:** planned · **Phase:** M08 · **Feature:** TASK · **Weight:** 2 · **Depends:** T099

**Source:** TaskBarConfig + static panels
**Gap/precondition:** BLOCK source-ready: runtime event semantics missing

### Thực hiện

1. Mid-progress restart and repeated event
2. Claim before/after expiry and clock boundary
3. Reward partial recovery
4. Taskbar on Home/Victory transition binding
5. So source/clone cùng state, sửa sai khác ngay trước feature tiếp theo.
6. Ghi harness/tests/capture/audio/asset receipts đúng revision, update coverage/dashboard.

### Acceptance

- Tất cả scenario bắt buộc pass hoặc gate blocked có reason; không verified nếu còn gap bắt buộc.
- Required evidence tồn tại/hash đúng và người review kết luận.
- Không regression feature đã hoàn thành; no orphan subscription/CTS/handle/tween.

**Verification:** targeted EditMode/PlayMode theo risk, matched captures, console, device/provider nếu feature yêu cầu

**Artifacts/ownership:** evidence/TASK/, coverage delta, reviewed parity checklist

**Evidence:** Chưa có receipt reviewed

## T101 — Color Guess mini-game: chốt source/state và contract

**Status:** planned · **Phase:** M08 · **Feature:** COLOR · **Weight:** 1 · **Depends:** T100

**Source:** ColorGuessConfig + panels
**Gap/precondition:** BLOCK source-ready: rules/cost/persistence not observed

### Thực hiện

1. Mở audit/source theo IDs, bổ sung mọi gap trước khi implementation semantics.
2. Lập state graph entry/action/effect/exit/error/cancel; xác định save/session và package ownership.
3. Chốt config: Rounds/duration/multipliers/reset policy.
4. Chốt scope package: Economy / UI / project domain; reuse only matching package contracts; đọc source tại pin thực tế.

### Acceptance

- Mỗi behavior có source evidence hoặc explicit proposed decision.
- Asset dependencies, runtime route và failure scenarios được liệt kê.
- Unknown bắt buộc được giải quyết; không coi tên metadata là luật.

**Verification:** source-ready review, config-schema design

**Artifacts/ownership:** feature-contracts/COLOR.md, source-state matrix

**Evidence:** Chưa có receipt reviewed

## T102 — Color Guess mini-game: implement vertical slice và thay UI ngay

**Status:** planned · **Phase:** M08 · **Feature:** COLOR · **Weight:** 3 · **Depends:** T101

**Source:** ColorGuessConfig + panels
**Gap/precondition:** BLOCK source-ready: rules/cost/persistence not observed

### Thực hiện

1. Tạo owner tại Features/ColorGuess, Domain/ColorGuess, Data/BusFever/ColorGuess theo architecture.
2. Dùng config/save/session boundaries và service package thật; không giữ model giả cho UI.
3. Wire normal entry: Promo → info/tutorial → round guess → result → streak/reward → next/expire.
4. Import/bind selected art; thay address/presenter route sang UI mới trong cùng feature.
5. Hoàn thiện pressed/locked/loading/success/error/back, feedback và owned cancellation.
6. Ghi asset GUID/source IDs và transaction/lifetime ledger; không tách reskin thành deferred cuối game.

### Acceptance

- UI mới được thấy từ normal route, hành vi tạo kết quả thật.
- Authority không nằm trong View; không duplicate wallet/presenter callbacks.
- Save authority: Cycle/round IDs, wager/resource receipt, streak save.
- Không TODO correctness hoặc fake service success.

**Verification:** compile, asmdef, lowest-layer behavior tests, normal-entry smoke

**Artifacts/ownership:** Features/ColorGuess, Domain/ColorGuess, Data/BusFever/ColorGuess, source→Unity GUID binding receipt

**Evidence:** Chưa có receipt reviewed

## T103 — Color Guess mini-game: regression, visual/feel và acceptance

**Status:** planned · **Phase:** M08 · **Feature:** COLOR · **Weight:** 2 · **Depends:** T102

**Source:** ColorGuessConfig + panels
**Gap/precondition:** BLOCK source-ready: rules/cost/persistence not observed

### Thực hiện

1. Incorrect/correct streak boundary
2. Rapid input one guess/round
3. Close/relaunch no reward reroll
4. Timer expiry/missing potion and retry
5. So source/clone cùng state, sửa sai khác ngay trước feature tiếp theo.
6. Ghi harness/tests/capture/audio/asset receipts đúng revision, update coverage/dashboard.

### Acceptance

- Tất cả scenario bắt buộc pass hoặc gate blocked có reason; không verified nếu còn gap bắt buộc.
- Required evidence tồn tại/hash đúng và người review kết luận.
- Không regression feature đã hoàn thành; no orphan subscription/CTS/handle/tween.

**Verification:** targeted EditMode/PlayMode theo risk, matched captures, console, device/provider nếu feature yêu cầu

**Artifacts/ownership:** evidence/COLOR/, coverage delta, reviewed parity checklist

**Evidence:** Chưa có receipt reviewed

## T104 — Localization, fonts và UI assets: chốt source/state và contract

**Status:** planned · **Phase:** M09 · **Feature:** LOCAL · **Weight:** 1 · **Depends:** T103

**Source:** localization-en-vi.csv; font/source catalog
**Gap/precondition:** Package TMP dependency and fallback target verification

### Thực hiện

1. Mở audit/source theo IDs, bổ sung mọi gap trước khi implementation semantics.
2. Lập state graph entry/action/effect/exit/error/cancel; xác định save/session và package ownership.
3. Chốt config: 278key baseline, locale mapping, fallback chains.
4. Chốt scope package: localization candidate / Settings / Assets; đọc source tại pin thực tế.

### Acceptance

- Mỗi behavior có source evidence hoặc explicit proposed decision.
- Asset dependencies, runtime route và failure scenarios được liệt kê.
- Unknown bắt buộc được giải quyết; không coi tên metadata là luật.

**Verification:** source-ready review, config-schema design

**Artifacts/ownership:** feature-contracts/LOCAL.md, source-state matrix

**Evidence:** Chưa có receipt reviewed

## T105 — Localization, fonts và UI assets: implement vertical slice và thay UI ngay

**Status:** planned · **Phase:** M09 · **Feature:** LOCAL · **Weight:** 3 · **Depends:** T104

**Source:** localization-en-vi.csv; font/source catalog
**Gap/precondition:** Package TMP dependency and fallback target verification

### Thực hiện

1. Tạo owner tại Integration/Localization, Data/BusFever/Locales, Presentation/Fonts theo architecture.
2. Dùng config/save/session boundaries và service package thật; không giữ model giả cho UI.
3. Wire normal entry: Device/selected locale → tables/fonts → rebind open UI → persist.
4. Import/bind selected art; thay address/presenter route sang UI mới trong cùng feature.
5. Hoàn thiện pressed/locked/loading/success/error/back, feedback và owned cancellation.
6. Ghi asset GUID/source IDs và transaction/lifetime ledger; không tách reskin thành deferred cuối game.
7. Tách installer riêng của Dreamy feature đang dùng; explicit dependencies, installation cleanup và reverse teardown theo 09-senior-implementation.md.

### Acceptance

- UI mới được thấy từ normal route, hành vi tạo kết quả thật.
- Authority không nằm trong View; không duplicate wallet/presenter callbacks.
- Save authority: Locale setting only; no gameplay data coupling.
- Không TODO correctness hoặc fake service success.

**Verification:** compile, asmdef, lowest-layer behavior tests, normal-entry smoke

**Artifacts/ownership:** Integration/Localization, Data/BusFever/Locales, Presentation/Fonts, source→Unity GUID binding receipt

**Evidence:** Chưa có receipt reviewed

## T106 — Localization, fonts và UI assets: regression, visual/feel và acceptance

**Status:** planned · **Phase:** M09 · **Feature:** LOCAL · **Weight:** 2 · **Depends:** T105

**Source:** localization-en-vi.csv; font/source catalog
**Gap/precondition:** Package TMP dependency and fallback target verification

### Thực hiện

1. Missing key/glyph graceful fallback
2. Vietnamese diacritics/outlines/clipping
3. Switch while popup cached/open
4. TMP dependency resolution verified
5. So source/clone cùng state, sửa sai khác ngay trước feature tiếp theo.
6. Ghi harness/tests/capture/audio/asset receipts đúng revision, update coverage/dashboard.

### Acceptance

- Tất cả scenario bắt buộc pass hoặc gate blocked có reason; không verified nếu còn gap bắt buộc.
- Required evidence tồn tại/hash đúng và người review kết luận.
- Không regression feature đã hoàn thành; no orphan subscription/CTS/handle/tween.

**Verification:** targeted EditMode/PlayMode theo risk, matched captures, console, device/provider nếu feature yêu cầu

**Artifacts/ownership:** evidence/LOCAL/, coverage delta, reviewed parity checklist

**Evidence:** Chưa có receipt reviewed

## T107 — Audio, haptic và full polish pass: chốt source/state và contract

**Status:** planned · **Phase:** M09 · **Feature:** AUDIO · **Weight:** 1 · **Depends:** T106

**Source:** audio catalog; animation/motion profiles
**Gap/precondition:** Runtime mixer/trigger/audio-sync capture missing

### Thực hiện

1. Mở audit/source theo IDs, bổ sung mọi gap trước khi implementation semantics.
2. Lập state graph entry/action/effect/exit/error/cancel; xác định save/session và package ownership.
3. Chốt config: 50clip catalog, gain/pitch/variants, cue curves.
4. Chốt scope package: Audio / Feedback / DOTween adapter; đọc source tại pin thực tế.

### Acceptance

- Mỗi behavior có source evidence hoặc explicit proposed decision.
- Asset dependencies, runtime route và failure scenarios được liệt kê.
- Unknown bắt buộc được giải quyết; không coi tên metadata là luật.

**Verification:** source-ready review, config-schema design

**Artifacts/ownership:** feature-contracts/AUDIO.md, source-state matrix

**Evidence:** Chưa có receipt reviewed

## T108 — Audio, haptic và full polish pass: implement vertical slice và thay UI ngay

**Status:** planned · **Phase:** M09 · **Feature:** AUDIO · **Weight:** 3 · **Depends:** T107

**Source:** audio catalog; animation/motion profiles
**Gap/precondition:** Runtime mixer/trigger/audio-sync capture missing

### Thực hiện

1. Tạo owner tại Presentation/Polish, Data/BusFever/Feedback, Integration/Audio theo architecture.
2. Dùng config/save/session boundaries và service package thật; không giữ model giả cho UI.
3. Wire normal entry: Gameplay/UI facts → cues → pooled playback → stop/fade/cancel.
4. Import/bind selected art; thay address/presenter route sang UI mới trong cùng feature.
5. Hoàn thiện pressed/locked/loading/success/error/back, feedback và owned cancellation.
6. Ghi asset GUID/source IDs và transaction/lifetime ledger; không tách reskin thành deferred cuối game.

### Acceptance

- UI mới được thấy từ normal route, hành vi tạo kết quả thật.
- Authority không nằm trong View; không duplicate wallet/presenter callbacks.
- Save authority: Settings owned by Settings; no session leakage.
- Không TODO correctness hoặc fake service success.

**Verification:** compile, asmdef, lowest-layer behavior tests, normal-entry smoke

**Artifacts/ownership:** Presentation/Polish, Data/BusFever/Feedback, Integration/Audio, source→Unity GUID binding receipt

**Evidence:** Chưa có receipt reviewed

## T109 — Audio, haptic và full polish pass: regression, visual/feel và acceptance

**Status:** planned · **Phase:** M09 · **Feature:** AUDIO · **Weight:** 2 · **Depends:** T108

**Source:** audio catalog; animation/motion profiles
**Gap/precondition:** Runtime mixer/trigger/audio-sync capture missing

### Thực hiện

1. Mute during sound + new cues
2. Pool/retry no orphan looping audio
3. Haptic real-device permission/platform
4. Matched normal-speed AV captures and tween thresholds
5. So source/clone cùng state, sửa sai khác ngay trước feature tiếp theo.
6. Ghi harness/tests/capture/audio/asset receipts đúng revision, update coverage/dashboard.

### Acceptance

- Tất cả scenario bắt buộc pass hoặc gate blocked có reason; không verified nếu còn gap bắt buộc.
- Required evidence tồn tại/hash đúng và người review kết luận.
- Không regression feature đã hoàn thành; no orphan subscription/CTS/handle/tween.

**Verification:** targeted EditMode/PlayMode theo risk, matched captures, console, device/provider nếu feature yêu cầu

**Artifacts/ownership:** evidence/AUDIO/, coverage delta, reviewed parity checklist

**Evidence:** Chưa có receipt reviewed

## T110 — Toàn bộ level catalog và AES reconciliation

**Status:** planned · **Phase:** M10 · **Feature:** FINAL · **Weight:** 5 · **Depends:** T109, T003

**Source:** planning baseline
**Gap/precondition:** Theo baseline và dependencies

### Thực hiện

1. Resolve AES/data source hợp lệ; index đầy đủ level groups/loops/remote variants.
2. Validate every level schema/references, golden layout + content count reconciliation; chạy coverage theo family.

### Acceptance

- Không lấy level pilot thay full-content coverage.
- Không còn required layout unknown; manifest/catalog/hash reconcile.

**Verification:** harness + device/service gates theo scope

**Artifacts/ownership:** release-evidence/, final-coverage.json

**Evidence:** Chưa có receipt reviewed

## T111 — Audit production gateways và transaction recovery toàn game

**Status:** planned · **Phase:** M10 · **Feature:** FINAL · **Weight:** 5 · **Depends:** T110, T003

**Source:** planning baseline
**Gap/precondition:** Theo baseline và dependencies

### Thực hiện

1. Tái kiểm tra billing/ads/backend đã tích hợp tại feature gốc; xác nhận production config và không còn simulated Purchased. Không trì hoãn tích hợp provider tới task này.
2. Fault inject timeout/duplicate/late/restart; real completed/cancel/restore/device receipts.

### Acceptance

- Mock không pass production gate.
- No duplicate rewards hoặc fake online state.

**Verification:** harness + device/service gates theo scope

**Artifacts/ownership:** release-evidence/, final-coverage.json

**Evidence:** Chưa có receipt reviewed

## T112 — Whole experience graph regression

**Status:** planned · **Phase:** M10 · **Feature:** FINAL · **Weight:** 5 · **Depends:** T111, T003

**Source:** planning baseline
**Gap/precondition:** Theo baseline và dependencies

### Thực hiện

1. Fresh/return, every entry/action/effect/exit; reopen/retry/upgrade/localization/aspect.
2. Verify levels, events, progression, saves và restore/cancel chains.

### Acceptance

- Không âm thầm bỏ module locked/online.
- Source-state coverage và visual/feel defects required đã đóng.

**Verification:** harness + device/service gates theo scope

**Artifacts/ownership:** release-evidence/, final-coverage.json

**Evidence:** Chưa có receipt reviewed

## T113 — Android performance và IL2CPP build

**Status:** planned · **Phase:** M10 · **Feature:** FINAL · **Weight:** 5 · **Depends:** T112, T003

**Source:** planning baseline
**Gap/precondition:** Theo baseline và dependencies

### Thực hiện

1. Đo CPU/GPU/GC/UI rebuild/memory/loading/thermal trên thiết bị chuẩn.
2. Addressables build/load/unload; IL2CPP/VContainer stripping smoke; install/launch/upgrade/resume.

### Acceptance

- Build đúng revision/signing config, logs/symbols và smoke evidence.
- Frame/memory budgets được hiệu chuẩn thực; không dùng Editor FPS làm device proof.

**Verification:** harness + device/service gates theo scope

**Artifacts/ownership:** release-evidence/, final-coverage.json

**Evidence:** Chưa có receipt reviewed

## T114 — Final release readiness và handoff

**Status:** planned · **Phase:** M10 · **Feature:** FINAL · **Weight:** 5 · **Depends:** T113, T003

**Source:** planning baseline
**Gap/precondition:** Theo baseline và dependencies

### Thực hiện

1. Review package pins/provider privacy/permissions/product IDs/version/symbols/changelog/rollback.
2. Tổng hợp defect ledger, supported devices và owner acceptance; không tự publish.

### Acceptance

- Required gates pass, source/artifact provenance và known limitations đầy đủ.
- Deliverables reviewable; user acceptance còn là hành động người dùng.

**Verification:** harness + device/service gates theo scope

**Artifacts/ownership:** release-evidence/, final-coverage.json

**Evidence:** Chưa có receipt reviewed
