# Feature contracts — scope và acceptance

Tên type/config/path dưới đây là thiết kế dự kiến của project, không phải API package đã xác minh. Chi tiết thứ tự và gates nằm trong task cards.

## HOME — Home và bottom navigation

[Source packet: UI tree, component/media binding, motion/audio](10-feature-source-map.md#home)

**Phase:** M01 · **Reuse:** UI / Assets / Feedback / VContainer

**Flow:** Launch → readiness → Home city/bus/queue → tab hoặc Play → exit

**Static config:** HomeVisualProfile, navigation addresses, level label

**Persistent/session:** Đọc progression/profile/wallet; không tạo balance riêng

**Source:** R063-board-state

**Readiness gap:** Mốc chính xác Home unlock cần capture

**Owner paths đề xuất:** Features/Home, Prefabs/BusFever/Home, Composition/HomeFactory

### Scenario bắt buộc

- Cold launch đúng Home/new-player rule
- Tab qua lại20lần không duplicate presenter
- Load art fail → retry, close during load
- 1080x1920 và tall viewport, safearea không che nav

### UI cutover và evidence

- Hoàn thành interaction service/save/config trước khi coi skin là functional. Wire address/presenter vào normal route ngay trong feature; giữ source/clone capture và bindings.
- Kiểm tra button/raycast/font/atlas/sorting/safearea; show/close/reopen, input repeat, error/cancel; handle/tween/subscription cancel đúng owner.
- Source-ready, implementation và acceptance là ba task riêng; không chuyển verified từ việc tạo prefab hay đọc metadata.

## SETTINGS — Settings Home và Pause

[Source packet: UI tree, component/media binding, motion/audio](10-feature-source-map.md#settings)

**Phase:** M01 · **Reuse:** Settings / UI / Audio / Feedback

**Flow:** Home hoặc Pause → đúng skin → toggle → close; gameplay Restart có cost policy

**Static config:** SettingsPresentationProfile, external URLs và platform capabilities

**Persistent/session:** Reuse settings state; test persistence, không trộn progression

**Source:** R016-pause-stable; R067-home-settings

**Readiness gap:** Simulation pause semantics, post-home restart/life cost chưa đủ

**Owner paths đề xuất:** Features/Settings, Prefabs/BusFever/Settings, Integration/Settings

### Scenario bắt buộc

- Music off/on giữ sau relaunch
- Pause không cho click xuyên xuống board
- Restore empty/cancel/error có phản hồi
- Close20lần không nhân đôi audio callback

### UI cutover và evidence

- Hoàn thành interaction service/save/config trước khi coi skin là functional. Wire address/presenter vào normal route ngay trong feature; giữ source/clone capture và bindings.
- Kiểm tra button/raycast/font/atlas/sorting/safearea; show/close/reopen, input repeat, error/cancel; handle/tween/subscription cancel đúng owner.
- Source-ready, implementation và acceptance là ba task riêng; không chuyển verified từ việc tạo prefab hay đọc metadata.

## LAUNCH — Splash/loading và scene transition

[Source packet: UI tree, component/media binding, motion/audio](10-feature-source-map.md#launch)

**Phase:** M02 · **Reuse:** Core / Assets / UI / Connectivity candidate

**Flow:** Cold/return launch → init → load → route; fail → retry; transition trời/mây/máy bay

**Static config:** StartupRoutingPolicy, scene addresses, transition curves

**Persistent/session:** Load save/repair trước route; tutorial/progression quyết định entry

**Source:** R002-playstore-launch; R018-restart-prompt

**Readiness gap:** Cold fresh/return full route và network errors cần khảo sát

**Owner paths đề xuất:** Features/Launch, Presentation/Transitions, Scripts/Bootstrap

### Scenario bắt buộc

- Init cancel không publish ready
- Missing bundle/retry không leak handle
- Bootstrap duplicate/reload không tạo wallet2
- Background/relaunch không kẹt loading

### UI cutover và evidence

- Hoàn thành interaction service/save/config trước khi coi skin là functional. Wire address/presenter vào normal route ngay trong feature; giữ source/clone capture và bindings.
- Kiểm tra button/raycast/font/atlas/sorting/safearea; show/close/reopen, input repeat, error/cancel; handle/tween/subscription cancel đúng owner.
- Source-ready, implementation và acceptance là ba task riêng; không chuyển verified từ việc tạo prefab hay đọc metadata.

## GAME — Gameplay board, xe và passenger loop

[Source packet: UI tree, component/media binding, motion/audio](10-feature-source-map.md#game)

**Phase:** M02 · **Reuse:** Core / Assets / Audio / Feedback; project Domain

**Flow:** Tap vehicle → validate hướng/occupancy → reserve slot → drive → match/board → full departure

**Static config:** LevelDefinition, VehicleDefinition, PassengerPolicy, MotionProfile

**Persistent/session:** Session occupancy/queue/request IDs; progression chưa tăng trước win commit

**Source:** R003-after-loading; R021-level2-top-cleared

**Readiness gap:** Source priority, collision boundaries, complete loop/fail logic và AES chưa đủ

**Owner paths đề xuất:** Domain/Board, Domain/Passengers, Application/PuzzleSession, Features/Gameplay, Presentation/Vehicles

### Scenario bắt buộc

- Blocked car không đi xuyên
- Hai tap đồng thời không reserve cùng slot
- Hai xe cùng màu: priority theo source
- Boarding giảm đúng capacity, không tạo mất khách
- Restart50lần: pool/handle/listener về baseline
- Camera/colors/material/shadow match cùng layout

### UI cutover và evidence

- Hoàn thành interaction service/save/config trước khi coi skin là functional. Wire address/presenter vào normal route ngay trong feature; giữ source/clone capture và bindings.
- Kiểm tra button/raycast/font/atlas/sorting/safearea; show/close/reopen, input repeat, error/cancel; handle/tween/subscription cancel đúng owner.
- Source-ready, implementation và acceptance là ba task riêng; không chuyển verified từ việc tạo prefab hay đọc metadata.

## TUTORIAL — Tutorial bàn tay/spotlight/target gate

[Source packet: UI tree, component/media binding, motion/audio](10-feature-source-map.md#tutorial)

**Phase:** M03 · **Reuse:** feature.tutorial candidate / UI / Feedback

**Flow:** First entry → target resolved → lock input subset → accepted action → next → finish

**Static config:** TutorialCatalog, stable target IDs, unlock steps

**Persistent/session:** Package tutorial checkpoint; session target references không persist instance IDs

**Source:** R004-level1-blocked-test; R048-vip-select-target

**Readiness gap:** Xác nhận replay và persistence của từng step

**Owner paths đề xuất:** Features/Tutorial, Integration/TutorialTargets, Prefabs/BusFever/Tutorial

### Scenario bắt buộc

- Wrong target không advance
- Target destroyed/late loaded → recover
- Close/background/relaunch không skip reward
- Hand/outline/card đúng target sau camera resize

### UI cutover và evidence

- Hoàn thành interaction service/save/config trước khi coi skin là functional. Wire address/presenter vào normal route ngay trong feature; giữ source/clone capture và bindings.
- Kiểm tra button/raycast/font/atlas/sorting/safearea; show/close/reopen, input repeat, error/cancel; handle/tween/subscription cancel đúng owner.
- Source-ready, implementation và acceptance là ba task riêng; không chuyển verified từ việc tạo prefab hay đọc metadata.

## VICTORY — Victory, reward và Next

[Source packet: UI tree, component/media binding, motion/audio](10-feature-source-map.md#victory)

**Phase:** M03 · **Reuse:** Progression candidate / Economy / UI / Feedback / Audio

**Flow:** Final passenger → win fact → persistent reward → Victory → Next → next layout

**Static config:** WinRewardTable, difficulty variants, Spine/animation cues

**Persistent/session:** Win receipt/session ID chống grant2; progression và wallet consistency

**Source:** R011-level1-result

**Readiness gap:** Hard/superhard/taskbar reward chưa capture

**Owner paths đề xuất:** Features/Victory, Application/WinLevel, Prefabs/BusFever/Victory

### Scenario bắt buộc

- Double Next không skip2level
- Relaunch sau grant trước animation không grant lại
- Normal/hard/superhard đúng variant
- Coin fly/counter không thay authoritative balance

### UI cutover và evidence

- Hoàn thành interaction service/save/config trước khi coi skin là functional. Wire address/presenter vào normal route ngay trong feature; giữ source/clone capture và bindings.
- Kiểm tra button/raycast/font/atlas/sorting/safearea; show/close/reopen, input repeat, error/cancel; handle/tween/subscription cancel đúng owner.
- Source-ready, implementation và acceptance là ba task riêng; không chuyển verified từ việc tạo prefab hay đọc metadata.

## FAIL — Fail, Revive, Retry và quit

[Source packet: UI tree, component/media binding, motion/audio](10-feature-source-map.md#fail)

**Phase:** M04 · **Reuse:** Economy / UI / Feedback / platform gateways

**Flow:** Normal fail reason → fail panel → revive/ad/coin hoặc retry/quit → result

**Static config:** FailurePolicy, revive costs, reason→panel variants

**Persistent/session:** Spend/revive receipt atomic; life/progression policies rõ

**Source:** static FailPanel/RevivePanel; runtime chưa đủ

**Readiness gap:** BLOCK source-ready: cần tạo fail bằng normal gameplay

**Owner paths đề xuất:** Domain/Failure, Features/FailRevive, Application/ReviveLevel

### Scenario bắt buộc

- No-spots toast không mặc nhiên là fail
- Revive cancel/no-fill giữ tiền/state đúng
- Double revive chỉ commit1
- Quit/relaunch trong ad xử lý late callback
- Retry restore đúng layout theo source

### UI cutover và evidence

- Hoàn thành interaction service/save/config trước khi coi skin là functional. Wire address/presenter vào normal route ngay trong feature; giữ source/clone capture và bindings.
- Kiểm tra button/raycast/font/atlas/sorting/safearea; show/close/reopen, input repeat, error/cancel; handle/tween/subscription cancel đúng owner.
- Source-ready, implementation và acceptance là ba task riêng; không chuyển verified từ việc tạo prefab hay đọc metadata.

## PARK — Extra Spot và parking reservation

[Source packet: UI tree, component/media binding, motion/audio](10-feature-source-map.md#park)

**Phase:** M04 · **Reuse:** Economy / UI / Audio / rewarded gateway

**Flow:** Tap + → Extra Spot → Free/coin theo nguồn → completed → unlock slot → close

**Static config:** ParkingUnlockPolicy, cost/ad modes, slot IDs

**Persistent/session:** Slot ownership theo session hoặc persistent phải xác minh; receipt chống double

**Source:** R053-extra-parking; R054-extra-spot-ad-result

**Readiness gap:** Ad completion/cancel/error và coin mode cần xác minh

**Owner paths đề xuất:** Domain/Parking, Features/ExtraSpot, Integration/RewardedAds

### Scenario bắt buộc

- No-fill/cancel không unlock
- Callback muộn của session cũ không unlock mới
- Concurrent car không tranh slot vừa mở
- Close popup trả input lock đúng

### UI cutover và evidence

- Hoàn thành interaction service/save/config trước khi coi skin là functional. Wire address/presenter vào normal route ngay trong feature; giữ source/clone capture và bindings.
- Kiểm tra button/raycast/font/atlas/sorting/safearea; show/close/reopen, input repeat, error/cancel; handle/tween/subscription cancel đúng owner.
- Source-ready, implementation và acceptance là ba task riêng; không chuyển verified từ việc tạo prefab hay đọc metadata.

## VIP — VIP booster và xe bay

[Source packet: UI tree, component/media binding, motion/audio](10-feature-source-map.md#vip)

**Phase:** M04 · **Reuse:** Economy / Tutorial candidate / Feedback / Assets

**Flow:** Unlock4 → claim/tutorial free → chọn booster → select vehicle → flight → VIP boarding

**Static config:** VIPDefinition, target policy, flight/cue profile

**Persistent/session:** Inventory10003 và use receipt; tutorial free tách paid use

**Source:** R046-level4-ready; R049-vip-flight

**Readiness gap:** Inventory grant/free semantics và cancel còn thiếu

**Owner paths đề xuất:** Features/Boosters/Vip, Application/UseVip, Presentation/VipFlight

### Scenario bắt buộc

- Target invalid/cancel không mất booster
- Double tap chỉ consume1
- Moving target/modal/retry cancels safely
- Rotor/flight/landing, VIP outline đúng source

### UI cutover và evidence

- Hoàn thành interaction service/save/config trước khi coi skin là functional. Wire address/presenter vào normal route ngay trong feature; giữ source/clone capture và bindings.
- Kiểm tra button/raycast/font/atlas/sorting/safearea; show/close/reopen, input repeat, error/cancel; handle/tween/subscription cancel đúng owner.
- Source-ready, implementation và acceptance là ba task riêng; không chuyển verified từ việc tạo prefab hay đọc metadata.

## SHOP — Shop, coin packs và offers

[Source packet: UI tree, component/media binding, motion/audio](10-feature-source-map.md#shop)

**Phase:** M05 · **Reuse:** Shop / Economy / DataConfig / UI / production billing adapter

**Flow:** Tab Shop → scroll offers → purchase provider → pending/cancel/failure/success → reward/restore

**Static config:** OfferCatalog, product mapping, eligibility, localized price sources

**Persistent/session:** Wallet/entitlement receipt; provider transaction ID dedupe

**Source:** R069-shop-entry; R071-shop-coins

**Readiness gap:** Provider SDK/product IDs, purchase state UI còn thiếu

**Owner paths đề xuất:** Features/Shop, Integration/Billing, Data/BusFever/Offers

### Scenario bắt buộc

- Production thiếu provider không Purchased
- Duplicate receipt/restart không grant2
- Pending/cancel không giả success
- Price locale/offer visibility theo config
- Scroll/pool selection/reopen giữ đúng binding

### UI cutover và evidence

- Hoàn thành interaction service/save/config trước khi coi skin là functional. Wire address/presenter vào normal route ngay trong feature; giữ source/clone capture và bindings.
- Kiểm tra button/raycast/font/atlas/sorting/safearea; show/close/reopen, input repeat, error/cancel; handle/tween/subscription cancel đúng owner.
- Source-ready, implementation và acceptance là ba task riêng; không chuyển verified từ việc tạo prefab hay đọc metadata.

## PROFILE — Profile, avatar và nickname

[Source packet: UI tree, component/media binding, motion/audio](10-feature-source-map.md#profile)

**Phase:** M05 · **Reuse:** UI / Datasave / Localization candidate

**Flow:** Avatar → view stats → edit → select/name → validate → save hoặc cancel

**Static config:** AvatarCatalog9entry, nickname policy/max15, localized errors

**Persistent/session:** Profile save migration; no provider account ID overwrite

**Source:** R064-user-profile; R065-profile-edit

**Readiness gap:** Invalid/save confirmation và account semantics chưa đủ

**Owner paths đề xuất:** Features/Profile, Data/BusFever/Profile, Prefabs/BusFever/Profile

### Scenario bắt buộc

- Empty/invalid/length boundary
- Select rồi cancel rollback
- Save/relaunch đúng avatar/name
- Keyboard safearea và rich text escaping

### UI cutover và evidence

- Hoàn thành interaction service/save/config trước khi coi skin là functional. Wire address/presenter vào normal route ngay trong feature; giữ source/clone capture và bindings.
- Kiểm tra button/raycast/font/atlas/sorting/safearea; show/close/reopen, input repeat, error/cancel; handle/tween/subscription cancel đúng owner.
- Source-ready, implementation và acceptance là ba task riêng; không chuyển verified từ việc tạo prefab hay đọc metadata.

## SUPPLY — Supplies và hourly cooldown

[Source packet: UI tree, component/media binding, motion/audio](10-feature-source-map.md#supply)

**Phase:** M05 · **Reuse:** Economy / UI / trusted clock adapter

**Flow:** Home Supplies → free15 → grant → countdown; ad tiers theo nguồn

**Static config:** SupplyRewardTable, cooldown/tier unlock

**Persistent/session:** Claim receipt + cooldown timestamp; source of time rõ

**Source:** R074-supplies; R075-supplies-claimed

**Readiness gap:** Tier unlock và trusted/offline clock policy

**Owner paths đề xuất:** Features/Supplies, Application/ClaimSupply, Integration/Clock

### Scenario bắt buộc

- 200→215 once; animated intermediate không truth
- Tap2/quit ngay sau claim không grant2
- Offline/clockrollback/restart timer
- 20/50/70/100 tier lock và ad outcomes

### UI cutover và evidence

- Hoàn thành interaction service/save/config trước khi coi skin là functional. Wire address/presenter vào normal route ngay trong feature; giữ source/clone capture và bindings.
- Kiểm tra button/raycast/font/atlas/sorting/safearea; show/close/reopen, input repeat, error/cancel; handle/tween/subscription cancel đúng owner.
- Source-ready, implementation và acceptance là ba task riêng; không chuyển verified từ việc tạo prefab hay đọc metadata.

## SPIN — Lucky Spin và probability info

[Source packet: UI tree, component/media binding, motion/audio](10-feature-source-map.md#spin)

**Phase:** M05 · **Reuse:** feature.lucky-wheel candidate / Economy / Progression candidate / UI

**Flow:** Open wheel → info → level credit/free-ad → spin → grant → claim/exit

**Static config:** WheelRewardTable, weights, credit10wins, rotation profile

**Persistent/session:** Spin request/result receipt persisted trước visual; credit consumed once

**Source:** R076-spin-entry; R077-spin-info

**Readiness gap:** Spin actual completion và rollback/recovery cần quay

**Owner paths đề xuất:** Features/Spin, Integration/LuckyWheel, Data/BusFever/Spin

### Scenario bắt buộc

- Weights boundaries + deterministic seeded test
- Không suy weight từ lát bánh
- Close/relaunch giữa spin không reroll grant
- Progress reset/new-cycle và ad cancel
- Pointer/deceleration/audio sync theo capture

### UI cutover và evidence

- Hoàn thành interaction service/save/config trước khi coi skin là functional. Wire address/presenter vào normal route ngay trong feature; giữ source/clone capture và bindings.
- Kiểm tra button/raycast/font/atlas/sorting/safearea; show/close/reopen, input repeat, error/cancel; handle/tween/subscription cancel đúng owner.
- Source-ready, implementation và acceptance là ba task riêng; không chuyển verified từ việc tạo prefab hay đọc metadata.

## DAILY — Daily Bonus đầy đủ

[Source packet: UI tree, component/media binding, motion/audio](10-feature-source-map.md#daily)

**Phase:** M06 · **Reuse:** feature.daily-reward candidate / Economy / UI

**Flow:** Eligible entry → calendar/day → claim → reward → cooldown/new day

**Static config:** DailyRewardCatalog, cycle/reset/grace policy

**Persistent/session:** Claim/day/cycle receipts, timezone/trusted clock

**Source:** static dailybonus bundle

**Readiness gap:** BLOCK source-ready: chưa runtime entry/claim/reset

**Owner paths đề xuất:** Features/DailyBonus, Integration/DailyReward, Prefabs/BusFever/DailyBonus

### Scenario bắt buộc

- Same day claim2 không grant2
- Cross midnight/offline/clockback
- Interrupted bundle claim/retry
- All calendar/locked/claimed/error states

### UI cutover và evidence

- Hoàn thành interaction service/save/config trước khi coi skin là functional. Wire address/presenter vào normal route ngay trong feature; giữ source/clone capture và bindings.
- Kiểm tra button/raycast/font/atlas/sorting/safearea; show/close/reopen, input repeat, error/cancel; handle/tween/subscription cancel đúng owner.
- Source-ready, implementation và acceptance là ba task riêng; không chuyển verified từ việc tạo prefab hay đọc metadata.

## LIFE — Life, refill và resource recovery

[Source packet: UI tree, component/media binding, motion/audio](10-feature-source-map.md#life)

**Phase:** M06 · **Reuse:** Economy recovery / Datasave / UI; clock adapter

**Flow:** Enter/retry/fail → life policy → empty/refill/timer → resume

**Static config:** LifePolicy, cap/refill interval, cost points

**Persistent/session:** Recovery timestamps/cap and spend receipt; no duplicate wallet

**Source:** static life bundle; template economy recovery

**Readiness gap:** BLOCK source-ready: life visibility/cost chưa xác minh

**Owner paths đề xuất:** Features/Life, Integration/ResourceRecovery, Application/ConsumeLife

### Scenario bắt buộc

- At cap/backfill/clock discontinuity
- Fail/retry costs theo source
- Ad/purchase refill cancel/latecallback
- Resume after days clamp correctly

### UI cutover và evidence

- Hoàn thành interaction service/save/config trước khi coi skin là functional. Wire address/presenter vào normal route ngay trong feature; giữ source/clone capture và bindings.
- Kiểm tra button/raycast/font/atlas/sorting/safearea; show/close/reopen, input repeat, error/cancel; handle/tween/subscription cancel đúng owner.
- Source-ready, implementation và acceptance là ba task riêng; không chuyển verified từ việc tạo prefab hay đọc metadata.

## JUMBLE — Booster Jumble

[Source packet: UI tree, component/media binding, motion/audio](10-feature-source-map.md#jumble)

**Phase:** M06 · **Reuse:** Economy / Feedback / Audio / Tutorial candidate

**Flow:** Unlock milestone → choose booster → valid effect → re-evaluate board

**Static config:** JumbleRule, permutation/target policy, cue profile

**Persistent/session:** Inventory10002/use receipt; session version invalidation

**Source:** static ItemPropConfigJumble; locked8/13 captures

**Readiness gap:** BLOCK source-ready: chưa xác định mốc/luật thực

**Owner paths đề xuất:** Features/Boosters/Jumble, Domain/JumblePolicy, Presentation/Jumble

### Scenario bắt buộc

- No valid targets → no spend
- Permutation giữ entity identity/count/color theo source
- Blocked/moving entities và retry
- Result deterministic fixture, animation cancel safe

### UI cutover và evidence

- Hoàn thành interaction service/save/config trước khi coi skin là functional. Wire address/presenter vào normal route ngay trong feature; giữ source/clone capture và bindings.
- Kiểm tra button/raycast/font/atlas/sorting/safearea; show/close/reopen, input repeat, error/cancel; handle/tween/subscription cancel đúng owner.
- Source-ready, implementation và acceptance là ba task riêng; không chuyển verified từ việc tạo prefab hay đọc metadata.

## ARRANGE — Booster Arrange

[Source packet: UI tree, component/media binding, motion/audio](10-feature-source-map.md#arrange)

**Phase:** M06 · **Reuse:** Economy / Feedback / Audio / Tutorial candidate

**Flow:** Unlock → invoke → select/auto-target theo nguồn → spiral boarding → complete

**Static config:** ArrangeRule, boardingInterval0.1, spiral curve profile from audit

**Persistent/session:** Inventory10001/use receipt, logical boarding atomic

**Source:** static ItemPropConfigArrange

**Readiness gap:** BLOCK source-ready: chưa chơi booster và unlock

**Owner paths đề xuất:** Features/Boosters/Arrange, Domain/ArrangePolicy, Presentation/Arrange

### Scenario bắt buộc

- Insufficient item/repeated click
- Target order/count theo source
- Spiral interruption không duplicate passenger
- Same state trước/sau, sound cue timing

### UI cutover và evidence

- Hoàn thành interaction service/save/config trước khi coi skin là functional. Wire address/presenter vào normal route ngay trong feature; giữ source/clone capture và bindings.
- Kiểm tra button/raycast/font/atlas/sorting/safearea; show/close/reopen, input repeat, error/cancel; handle/tween/subscription cancel đúng owner.
- Source-ready, implementation và acceptance là ba task riêng; không chuyển verified từ việc tạo prefab hay đọc metadata.

## MECH-GARAGE — Garage/container spawning

[Source packet: UI tree, component/media binding, motion/audio](10-feature-source-map.md#mech-garage)

**Phase:** M07 · **Reuse:** project Domain / Tutorial candidate / Feedback / Assets

**Flow:** Load level family → inspect spawn/block/release order và preview count → input → resolve effects → win/fail/exit

**Static config:** GARAGEMechanismDefinition + rule/timing profile

**Persistent/session:** Logical mechanism state in session; persist only source-proven progress

**Source:** metadata/guide/config candidate only

**Readiness gap:** BLOCK source-ready: cần runtime và level data cho family này

**Owner paths đề xuất:** Domain/Mechanisms/GARAGE, Features/Mechanisms/GARAGE, Presentation/Mechanisms/GARAGE

### Scenario bắt buộc

- Golden layout fixture and spawn/block/release order và preview count
- Conflicting input/reservation boundary
- Retry/pause/revive/cancel during effect
- Tutorial target/sort/audio/material matched source

### UI cutover và evidence

- Hoàn thành interaction service/save/config trước khi coi skin là functional. Wire address/presenter vào normal route ngay trong feature; giữ source/clone capture và bindings.
- Kiểm tra button/raycast/font/atlas/sorting/safearea; show/close/reopen, input repeat, error/cancel; handle/tween/subscription cancel đúng owner.
- Source-ready, implementation và acceptance là ba task riêng; không chuyển verified từ việc tạo prefab hay đọc metadata.

## MECH-BELT — Conveyor và Gate Queue

[Source packet: UI tree, component/media binding, motion/audio](10-feature-source-map.md#mech-belt)

**Phase:** M07 · **Reuse:** project Domain / Tutorial candidate / Feedback / Assets

**Flow:** Load level family → inspect belt movement, queue shrink, capacity/ordering → input → resolve effects → win/fail/exit

**Static config:** BELTMechanismDefinition + rule/timing profile

**Persistent/session:** Logical mechanism state in session; persist only source-proven progress

**Source:** metadata/guide/config candidate only

**Readiness gap:** BLOCK source-ready: cần runtime và level data cho family này

**Owner paths đề xuất:** Domain/Mechanisms/BELT, Features/Mechanisms/BELT, Presentation/Mechanisms/BELT

### Scenario bắt buộc

- Golden layout fixture and belt movement, queue shrink, capacity/ordering
- Conflicting input/reservation boundary
- Retry/pause/revive/cancel during effect
- Tutorial target/sort/audio/material matched source

### UI cutover và evidence

- Hoàn thành interaction service/save/config trước khi coi skin là functional. Wire address/presenter vào normal route ngay trong feature; giữ source/clone capture và bindings.
- Kiểm tra button/raycast/font/atlas/sorting/safearea; show/close/reopen, input repeat, error/cancel; handle/tween/subscription cancel đúng owner.
- Source-ready, implementation và acceptance là ba task riêng; không chuyển verified từ việc tạo prefab hay đọc metadata.

## MECH-TURN — Turn vehicle

[Source packet: UI tree, component/media binding, motion/audio](10-feature-source-map.md#mech-turn)

**Phase:** M07 · **Reuse:** project Domain / Tutorial candidate / Feedback / Assets

**Flow:** Load level family → inspect direction switch, rotate0.25config, blocked destination → input → resolve effects → win/fail/exit

**Static config:** TURNMechanismDefinition + rule/timing profile

**Persistent/session:** Logical mechanism state in session; persist only source-proven progress

**Source:** metadata/guide/config candidate only

**Readiness gap:** BLOCK source-ready: cần runtime và level data cho family này

**Owner paths đề xuất:** Domain/Mechanisms/TURN, Features/Mechanisms/TURN, Presentation/Mechanisms/TURN

### Scenario bắt buộc

- Golden layout fixture and direction switch, rotate0.25config, blocked destination
- Conflicting input/reservation boundary
- Retry/pause/revive/cancel during effect
- Tutorial target/sort/audio/material matched source

### UI cutover và evidence

- Hoàn thành interaction service/save/config trước khi coi skin là functional. Wire address/presenter vào normal route ngay trong feature; giữ source/clone capture và bindings.
- Kiểm tra button/raycast/font/atlas/sorting/safearea; show/close/reopen, input repeat, error/cancel; handle/tween/subscription cancel đúng owner.
- Source-ready, implementation và acceptance là ba task riêng; không chuyển verified từ việc tạo prefab hay đọc metadata.

## MECH-ELEVATOR — Elevator floors

[Source packet: UI tree, component/media binding, motion/audio](10-feature-source-map.md#mech-elevator)

**Phase:** M07 · **Reuse:** project Domain / Tutorial candidate / Feedback / Assets

**Flow:** Load level family → inspect floor unlock, elevation/occlusion và interactions → input → resolve effects → win/fail/exit

**Static config:** ELEVATORMechanismDefinition + rule/timing profile

**Persistent/session:** Logical mechanism state in session; persist only source-proven progress

**Source:** metadata/guide/config candidate only

**Readiness gap:** BLOCK source-ready: cần runtime và level data cho family này

**Owner paths đề xuất:** Domain/Mechanisms/ELEVATOR, Features/Mechanisms/ELEVATOR, Presentation/Mechanisms/ELEVATOR

### Scenario bắt buộc

- Golden layout fixture and floor unlock, elevation/occlusion và interactions
- Conflicting input/reservation boundary
- Retry/pause/revive/cancel during effect
- Tutorial target/sort/audio/material matched source

### UI cutover và evidence

- Hoàn thành interaction service/save/config trước khi coi skin là functional. Wire address/presenter vào normal route ngay trong feature; giữ source/clone capture và bindings.
- Kiểm tra button/raycast/font/atlas/sorting/safearea; show/close/reopen, input repeat, error/cancel; handle/tween/subscription cancel đúng owner.
- Source-ready, implementation và acceptance là ba task riêng; không chuyển verified từ việc tạo prefab hay đọc metadata.

## MECH-HIDDEN — Hidden/Doubtful colors

[Source packet: UI tree, component/media binding, motion/audio](10-feature-source-map.md#mech-hidden)

**Phase:** M07 · **Reuse:** project Domain / Tutorial candidate / Feedback / Assets

**Flow:** Load level family → inspect reveal trigger, hidden collision/render rule → input → resolve effects → win/fail/exit

**Static config:** HIDDENMechanismDefinition + rule/timing profile

**Persistent/session:** Logical mechanism state in session; persist only source-proven progress

**Source:** metadata/guide/config candidate only

**Readiness gap:** BLOCK source-ready: cần runtime và level data cho family này

**Owner paths đề xuất:** Domain/Mechanisms/HIDDEN, Features/Mechanisms/HIDDEN, Presentation/Mechanisms/HIDDEN

### Scenario bắt buộc

- Golden layout fixture and reveal trigger, hidden collision/render rule
- Conflicting input/reservation boundary
- Retry/pause/revive/cancel during effect
- Tutorial target/sort/audio/material matched source

### UI cutover và evidence

- Hoàn thành interaction service/save/config trước khi coi skin là functional. Wire address/presenter vào normal route ngay trong feature; giữ source/clone capture và bindings.
- Kiểm tra button/raycast/font/atlas/sorting/safearea; show/close/reopen, input repeat, error/cancel; handle/tween/subscription cancel đúng owner.
- Source-ready, implementation và acceptance là ba task riêng; không chuyển verified từ việc tạo prefab hay đọc metadata.

## MECH-COMBO — Combination vehicles

[Source packet: UI tree, component/media binding, motion/audio](10-feature-source-map.md#mech-combo)

**Phase:** M07 · **Reuse:** project Domain / Tutorial candidate / Feedback / Assets

**Flow:** Load level family → inspect compound bounds/capacity và movement constraints → input → resolve effects → win/fail/exit

**Static config:** COMBOMechanismDefinition + rule/timing profile

**Persistent/session:** Logical mechanism state in session; persist only source-proven progress

**Source:** metadata/guide/config candidate only

**Readiness gap:** BLOCK source-ready: cần runtime và level data cho family này

**Owner paths đề xuất:** Domain/Mechanisms/COMBO, Features/Mechanisms/COMBO, Presentation/Mechanisms/COMBO

### Scenario bắt buộc

- Golden layout fixture and compound bounds/capacity và movement constraints
- Conflicting input/reservation boundary
- Retry/pause/revive/cancel during effect
- Tutorial target/sort/audio/material matched source

### UI cutover và evidence

- Hoàn thành interaction service/save/config trước khi coi skin là functional. Wire address/presenter vào normal route ngay trong feature; giữ source/clone capture và bindings.
- Kiểm tra button/raycast/font/atlas/sorting/safearea; show/close/reopen, input repeat, error/cancel; handle/tween/subscription cancel đúng owner.
- Source-ready, implementation và acceptance là ba task riêng; không chuyển verified từ việc tạo prefab hay đọc metadata.

## MECH-LINK — Linkage vehicles

[Source packet: UI tree, component/media binding, motion/audio](10-feature-source-map.md#mech-link)

**Phase:** M07 · **Reuse:** project Domain / Tutorial candidate / Feedback / Assets

**Flow:** Load level family → inspect head/tail direction, simultaneous reservation, broken link protection → input → resolve effects → win/fail/exit

**Static config:** LINKMechanismDefinition + rule/timing profile

**Persistent/session:** Logical mechanism state in session; persist only source-proven progress

**Source:** metadata/guide/config candidate only

**Readiness gap:** BLOCK source-ready: cần runtime và level data cho family này

**Owner paths đề xuất:** Domain/Mechanisms/LINK, Features/Mechanisms/LINK, Presentation/Mechanisms/LINK

### Scenario bắt buộc

- Golden layout fixture and head/tail direction, simultaneous reservation, broken link protection
- Conflicting input/reservation boundary
- Retry/pause/revive/cancel during effect
- Tutorial target/sort/audio/material matched source

### UI cutover và evidence

- Hoàn thành interaction service/save/config trước khi coi skin là functional. Wire address/presenter vào normal route ngay trong feature; giữ source/clone capture và bindings.
- Kiểm tra button/raycast/font/atlas/sorting/safearea; show/close/reopen, input repeat, error/cancel; handle/tween/subscription cancel đúng owner.
- Source-ready, implementation và acceptance là ba task riêng; không chuyển verified từ việc tạo prefab hay đọc metadata.

## MECH-WRENCH — Wrench/Gear lock

[Source packet: UI tree, component/media binding, motion/audio](10-feature-source-map.md#mech-wrench)

**Phase:** M07 · **Reuse:** project Domain / Tutorial candidate / Feedback / Assets

**Flow:** Load level family → inspect key/color mapping, unlock atomic và lock visuals → input → resolve effects → win/fail/exit

**Static config:** WRENCHMechanismDefinition + rule/timing profile

**Persistent/session:** Logical mechanism state in session; persist only source-proven progress

**Source:** metadata/guide/config candidate only

**Readiness gap:** BLOCK source-ready: cần runtime và level data cho family này

**Owner paths đề xuất:** Domain/Mechanisms/WRENCH, Features/Mechanisms/WRENCH, Presentation/Mechanisms/WRENCH

### Scenario bắt buộc

- Golden layout fixture and key/color mapping, unlock atomic và lock visuals
- Conflicting input/reservation boundary
- Retry/pause/revive/cancel during effect
- Tutorial target/sort/audio/material matched source

### UI cutover và evidence

- Hoàn thành interaction service/save/config trước khi coi skin là functional. Wire address/presenter vào normal route ngay trong feature; giữ source/clone capture và bindings.
- Kiểm tra button/raycast/font/atlas/sorting/safearea; show/close/reopen, input repeat, error/cancel; handle/tween/subscription cancel đúng owner.
- Source-ready, implementation và acceptance là ba task riêng; không chuyển verified từ việc tạo prefab hay đọc metadata.

## MECH-AMBULANCE — Ambulance

[Source packet: UI tree, component/media binding, motion/audio](10-feature-source-map.md#mech-ambulance)

**Phase:** M07 · **Reuse:** project Domain / Tutorial candidate / Feedback / Assets

**Flow:** Load level family → inspect step budget, warning and revive step policy → input → resolve effects → win/fail/exit

**Static config:** AMBULANCEMechanismDefinition + rule/timing profile

**Persistent/session:** Logical mechanism state in session; persist only source-proven progress

**Source:** metadata/guide/config candidate only

**Readiness gap:** BLOCK source-ready: cần runtime và level data cho family này

**Owner paths đề xuất:** Domain/Mechanisms/AMBULANCE, Features/Mechanisms/AMBULANCE, Presentation/Mechanisms/AMBULANCE

### Scenario bắt buộc

- Golden layout fixture and step budget, warning and revive step policy
- Conflicting input/reservation boundary
- Retry/pause/revive/cancel during effect
- Tutorial target/sort/audio/material matched source

### UI cutover và evidence

- Hoàn thành interaction service/save/config trước khi coi skin là functional. Wire address/presenter vào normal route ngay trong feature; giữ source/clone capture và bindings.
- Kiểm tra button/raycast/font/atlas/sorting/safearea; show/close/reopen, input repeat, error/cancel; handle/tween/subscription cancel đúng owner.
- Source-ready, implementation và acceptance là ba task riêng; không chuyển verified từ việc tạo prefab hay đọc metadata.

## MECH-FIRE — Firetruck

[Source packet: UI tree, component/media binding, motion/audio](10-feature-source-map.md#mech-fire)

**Phase:** M07 · **Reuse:** project Domain / Tutorial candidate / Feedback / Assets

**Flow:** Load level family → inspect timer/fire stages, warning30/20/10 config, extinguish/fail/revive → input → resolve effects → win/fail/exit

**Static config:** FIREMechanismDefinition + rule/timing profile

**Persistent/session:** Logical mechanism state in session; persist only source-proven progress

**Source:** metadata/guide/config candidate only

**Readiness gap:** BLOCK source-ready: cần runtime và level data cho family này

**Owner paths đề xuất:** Domain/Mechanisms/FIRE, Features/Mechanisms/FIRE, Presentation/Mechanisms/FIRE

### Scenario bắt buộc

- Golden layout fixture and timer/fire stages, warning30/20/10 config, extinguish/fail/revive
- Conflicting input/reservation boundary
- Retry/pause/revive/cancel during effect
- Tutorial target/sort/audio/material matched source

### UI cutover và evidence

- Hoàn thành interaction service/save/config trước khi coi skin là functional. Wire address/presenter vào normal route ngay trong feature; giữ source/clone capture và bindings.
- Kiểm tra button/raycast/font/atlas/sorting/safearea; show/close/reopen, input repeat, error/cancel; handle/tween/subscription cancel đúng owner.
- Source-ready, implementation và acceptance là ba task riêng; không chuyển verified từ việc tạo prefab hay đọc metadata.

## MECH-POLICE — Police

[Source packet: UI tree, component/media binding, motion/audio](10-feature-source-map.md#mech-police)

**Phase:** M07 · **Reuse:** project Domain / Tutorial candidate / Feedback / Assets

**Flow:** Load level family → inspect siren/priority/obstruction rule theo runtime → input → resolve effects → win/fail/exit

**Static config:** POLICEMechanismDefinition + rule/timing profile

**Persistent/session:** Logical mechanism state in session; persist only source-proven progress

**Source:** metadata/guide/config candidate only

**Readiness gap:** BLOCK source-ready: cần runtime và level data cho family này

**Owner paths đề xuất:** Domain/Mechanisms/POLICE, Features/Mechanisms/POLICE, Presentation/Mechanisms/POLICE

### Scenario bắt buộc

- Golden layout fixture and siren/priority/obstruction rule theo runtime
- Conflicting input/reservation boundary
- Retry/pause/revive/cancel during effect
- Tutorial target/sort/audio/material matched source

### UI cutover và evidence

- Hoàn thành interaction service/save/config trước khi coi skin là functional. Wire address/presenter vào normal route ngay trong feature; giữ source/clone capture và bindings.
- Kiểm tra button/raycast/font/atlas/sorting/safearea; show/close/reopen, input repeat, error/cancel; handle/tween/subscription cancel đúng owner.
- Source-ready, implementation và acceptance là ba task riêng; không chuyển verified từ việc tạo prefab hay đọc metadata.

## MECH-LUXURY — Luxury/VIP passenger

[Source packet: UI tree, component/media binding, motion/audio](10-feature-source-map.md#mech-luxury)

**Phase:** M07 · **Reuse:** project Domain / Tutorial candidate / Feedback / Assets

**Flow:** Load level family → inspect eligible passenger/capacity/priority và visuals → input → resolve effects → win/fail/exit

**Static config:** LUXURYMechanismDefinition + rule/timing profile

**Persistent/session:** Logical mechanism state in session; persist only source-proven progress

**Source:** metadata/guide/config candidate only

**Readiness gap:** BLOCK source-ready: cần runtime và level data cho family này

**Owner paths đề xuất:** Domain/Mechanisms/LUXURY, Features/Mechanisms/LUXURY, Presentation/Mechanisms/LUXURY

### Scenario bắt buộc

- Golden layout fixture and eligible passenger/capacity/priority và visuals
- Conflicting input/reservation boundary
- Retry/pause/revive/cancel during effect
- Tutorial target/sort/audio/material matched source

### UI cutover và evidence

- Hoàn thành interaction service/save/config trước khi coi skin là functional. Wire address/presenter vào normal route ngay trong feature; giữ source/clone capture và bindings.
- Kiểm tra button/raycast/font/atlas/sorting/safearea; show/close/reopen, input repeat, error/cancel; handle/tween/subscription cancel đúng owner.
- Source-ready, implementation và acceptance là ba task riêng; không chuyển verified từ việc tạo prefab hay đọc metadata.

## MECH-TRAFFIC — Traffic light / limit count

[Source packet: UI tree, component/media binding, motion/audio](10-feature-source-map.md#mech-traffic)

**Phase:** M07 · **Reuse:** project Domain / Tutorial candidate / Feedback / Assets

**Flow:** Load level family → inspect light phase, admissible group/step limit, fail/reset → input → resolve effects → win/fail/exit

**Static config:** TRAFFICMechanismDefinition + rule/timing profile

**Persistent/session:** Logical mechanism state in session; persist only source-proven progress

**Source:** metadata/guide/config candidate only

**Readiness gap:** BLOCK source-ready: cần runtime và level data cho family này

**Owner paths đề xuất:** Domain/Mechanisms/TRAFFIC, Features/Mechanisms/TRAFFIC, Presentation/Mechanisms/TRAFFIC

### Scenario bắt buộc

- Golden layout fixture and light phase, admissible group/step limit, fail/reset
- Conflicting input/reservation boundary
- Retry/pause/revive/cancel during effect
- Tutorial target/sort/audio/material matched source

### UI cutover và evidence

- Hoàn thành interaction service/save/config trước khi coi skin là functional. Wire address/presenter vào normal route ngay trong feature; giữ source/clone capture và bindings.
- Kiểm tra button/raycast/font/atlas/sorting/safearea; show/close/reopen, input repeat, error/cancel; handle/tween/subscription cancel đúng owner.
- Source-ready, implementation và acceptance là ba task riêng; không chuyển verified từ việc tạo prefab hay đọc metadata.

## RANK — Leaderboard và weekly rewards

[Source packet: UI tree, component/media binding, motion/audio](10-feature-source-map.md#rank)

**Phase:** M08 · **Reuse:** UI / Economy / project leaderboard gateway

**Flow:** Locked29 → unlock → load/cached/offline → rank → reward/reset

**Static config:** RankMode/season ID/reward tiers, refresh policy

**Persistent/session:** Per-season reward receipt; cache not fake-online result

**Source:** R073-ranking-locked; RankingConfig

**Readiness gap:** BLOCK unlocked: cần29 + backend/provider scope

**Owner paths đề xuất:** Features/Ranking, Integration/Leaderboard, Data/BusFever/Ranking

### Scenario bắt buộc

- Locked at6 đúng29text
- Timeout/empty/error/offline retries
- Weekly reset/timezone/rank reward dedupe
- Global provider kết quả thật; local bot modes tách

### UI cutover và evidence

- Hoàn thành interaction service/save/config trước khi coi skin là functional. Wire address/presenter vào normal route ngay trong feature; giữ source/clone capture và bindings.
- Kiểm tra button/raycast/font/atlas/sorting/safearea; show/close/reopen, input repeat, error/cancel; handle/tween/subscription cancel đúng owner.
- Source-ready, implementation và acceptance là ba task riêng; không chuyển verified từ việc tạo prefab hay đọc metadata.

## TASK — Task Bar, collection và timed cycle

[Source packet: UI tree, component/media binding, motion/audio](10-feature-source-map.md#task)

**Phase:** M08 · **Reuse:** feature.missions candidate / Progression / Economy / UI

**Flow:** Unlock/promo → progress from facts → bar/gift → collection → claim/expire

**Static config:** Mission/collection templates, event cycle, expiry reward policy

**Persistent/session:** Counters/cycle/claim receipts; duplicate gameplay fact rejected

**Source:** TaskBarConfig + static panels

**Readiness gap:** BLOCK source-ready: runtime event semantics missing

**Owner paths đề xuất:** Features/TaskBar, Integration/Missions, Application/EventCycle

### Scenario bắt buộc

- Mid-progress restart and repeated event
- Claim before/after expiry and clock boundary
- Reward partial recovery
- Taskbar on Home/Victory transition binding

### UI cutover và evidence

- Hoàn thành interaction service/save/config trước khi coi skin là functional. Wire address/presenter vào normal route ngay trong feature; giữ source/clone capture và bindings.
- Kiểm tra button/raycast/font/atlas/sorting/safearea; show/close/reopen, input repeat, error/cancel; handle/tween/subscription cancel đúng owner.
- Source-ready, implementation và acceptance là ba task riêng; không chuyển verified từ việc tạo prefab hay đọc metadata.

## COLOR — Color Guess mini-game

[Source packet: UI tree, component/media binding, motion/audio](10-feature-source-map.md#color)

**Phase:** M08 · **Reuse:** Economy / UI / project domain; reuse only matching package contracts

**Flow:** Promo → info/tutorial → round guess → result → streak/reward → next/expire

**Static config:** Rounds/duration/multipliers/reset policy

**Persistent/session:** Cycle/round IDs, wager/resource receipt, streak save

**Source:** ColorGuessConfig + panels

**Readiness gap:** BLOCK source-ready: rules/cost/persistence not observed

**Owner paths đề xuất:** Features/ColorGuess, Domain/ColorGuess, Data/BusFever/ColorGuess

### Scenario bắt buộc

- Incorrect/correct streak boundary
- Rapid input one guess/round
- Close/relaunch no reward reroll
- Timer expiry/missing potion and retry

### UI cutover và evidence

- Hoàn thành interaction service/save/config trước khi coi skin là functional. Wire address/presenter vào normal route ngay trong feature; giữ source/clone capture và bindings.
- Kiểm tra button/raycast/font/atlas/sorting/safearea; show/close/reopen, input repeat, error/cancel; handle/tween/subscription cancel đúng owner.
- Source-ready, implementation và acceptance là ba task riêng; không chuyển verified từ việc tạo prefab hay đọc metadata.

## LOCAL — Localization, fonts và UI assets

[Source packet: UI tree, component/media binding, motion/audio](10-feature-source-map.md#local)

**Phase:** M09 · **Reuse:** localization candidate / Settings / Assets

**Flow:** Device/selected locale → tables/fonts → rebind open UI → persist

**Static config:** 278key baseline, locale mapping, fallback chains

**Persistent/session:** Locale setting only; no gameplay data coupling

**Source:** localization-en-vi.csv; font/source catalog

**Readiness gap:** Package TMP dependency and fallback target verification

**Owner paths đề xuất:** Integration/Localization, Data/BusFever/Locales, Presentation/Fonts

### Scenario bắt buộc

- Missing key/glyph graceful fallback
- Vietnamese diacritics/outlines/clipping
- Switch while popup cached/open
- TMP dependency resolution verified

### UI cutover và evidence

- Hoàn thành interaction service/save/config trước khi coi skin là functional. Wire address/presenter vào normal route ngay trong feature; giữ source/clone capture và bindings.
- Kiểm tra button/raycast/font/atlas/sorting/safearea; show/close/reopen, input repeat, error/cancel; handle/tween/subscription cancel đúng owner.
- Source-ready, implementation và acceptance là ba task riêng; không chuyển verified từ việc tạo prefab hay đọc metadata.

## AUDIO — Audio, haptic và full polish pass

[Source packet: UI tree, component/media binding, motion/audio](10-feature-source-map.md#audio)

**Phase:** M09 · **Reuse:** Audio / Feedback / DOTween adapter

**Flow:** Gameplay/UI facts → cues → pooled playback → stop/fade/cancel

**Static config:** 50clip catalog, gain/pitch/variants, cue curves

**Persistent/session:** Settings owned by Settings; no session leakage

**Source:** audio catalog; animation/motion profiles

**Readiness gap:** Runtime mixer/trigger/audio-sync capture missing

**Owner paths đề xuất:** Presentation/Polish, Data/BusFever/Feedback, Integration/Audio

### Scenario bắt buộc

- Mute during sound + new cues
- Pool/retry no orphan looping audio
- Haptic real-device permission/platform
- Matched normal-speed AV captures and tween thresholds

### UI cutover và evidence

- Hoàn thành interaction service/save/config trước khi coi skin là functional. Wire address/presenter vào normal route ngay trong feature; giữ source/clone capture và bindings.
- Kiểm tra button/raycast/font/atlas/sorting/safearea; show/close/reopen, input repeat, error/cancel; handle/tween/subscription cancel đúng owner.
- Source-ready, implementation và acceptance là ba task riêng; không chuyển verified từ việc tạo prefab hay đọc metadata.

