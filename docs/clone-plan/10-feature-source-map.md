# Feature → source UI / asset / motion packet

Các link dưới nối plan với bộ audit. Prefab là bằng chứng file-observed, không tự chứng minh runtime của tất cả trạng thái. Source component/sprite/path ID đã map được giữ nguyên; GUID/prefab đích chỉ điền sau import thực tế. Shared popup như ItemPurchasePanel có thể phục vụ nhiều booster; cần runtime xác nhận mode, không nhân bản logic theo tên feature.

Các bảng CSV chứa hierarchy, serialized fields, anchor/pivot, raycast, font/text và media bindings. Khi triển khai: chọn từng row→source sprite/object ID→asset derivative→GUID đích→serialized component reference→matched-state receipt. Không chỉ ghi filename hoặc tên sprite.

<a id="home"></a>

## HOME — Home và bottom navigation

Source-state: R063-board-state
Cần giải quyết: Mốc chính xác Home unlock cần capture

- [Runtime audit + flow](../research/features/home-and-profile-audit.md)
- [HomePanel · UI tree](../research/features/HomePanel/structure.md)
- [HomePanel · Component / asset bindings](../research/features/HomePanel/ui-elements.csv)
- [Motion / polish facts và unknowns](../research/motion-and-polish.md)
- [Audio cue audit](../research/audio-audit.md)

Target owner dự kiến: Features/Home, Prefabs/BusFever/Home, Composition/HomeFactory. GUID/binding đích chưa tạo.

<a id="settings"></a>

## SETTINGS — Settings Home và Pause

Source-state: R016-pause-stable; R067-home-settings
Cần giải quyết: Simulation pause semantics, post-home restart/life cost chưa đủ

- [Runtime audit + flow](../research/features/settings-audit.md)
- [SettingPanel · UI tree](../research/features/SettingPanel/structure.md)
- [SettingPanel · Component / asset bindings](../research/features/SettingPanel/ui-elements.csv)
- [PausePanel · UI tree](../research/features/PausePanel/structure.md)
- [PausePanel · Component / asset bindings](../research/features/PausePanel/ui-elements.csv)
- [RestoreLoading · UI tree](../research/features/RestoreLoading/structure.md)
- [RestoreLoading · Component / asset bindings](../research/features/RestoreLoading/ui-elements.csv)
- [Motion / polish facts và unknowns](../research/motion-and-polish.md)
- [Audio cue audit](../research/audio-audit.md)

Target owner dự kiến: Features/Settings, Prefabs/BusFever/Settings, Integration/Settings. GUID/binding đích chưa tạo.

<a id="launch"></a>

## LAUNCH — Splash/loading và scene transition

Source-state: R002-playstore-launch; R018-restart-prompt
Cần giải quyết: Cold fresh/return full route và network errors cần khảo sát

- [LoadingPanel · UI tree](../research/features/LoadingPanel/structure.md)
- [LoadingPanel · Component / asset bindings](../research/features/LoadingPanel/ui-elements.csv)
- [EntryBanner · UI tree](../research/features/EntryBanner/structure.md)
- [EntryBanner · Component / asset bindings](../research/features/EntryBanner/ui-elements.csv)
- [EntryTipTextBanner · UI tree](../research/features/EntryTipTextBanner/structure.md)
- [EntryTipTextBanner · Component / asset bindings](../research/features/EntryTipTextBanner/ui-elements.csv)
- [Motion / polish facts và unknowns](../research/motion-and-polish.md)
- [Audio cue audit](../research/audio-audit.md)

Target owner dự kiến: Features/Launch, Presentation/Transitions, Scripts/Bootstrap. GUID/binding đích chưa tạo.

<a id="game"></a>

## GAME — Gameplay board, xe và passenger loop

Source-state: R003-after-loading; R021-level2-top-cleared
Cần giải quyết: Source priority, collision boundaries, complete loop/fail logic và AES chưa đủ

- [Runtime audit + flow](../research/features/gameplay-audit.md)
- [GamePanel · UI tree](../research/features/GamePanel/structure.md)
- [GamePanel · Component / asset bindings](../research/features/GamePanel/ui-elements.csv)
- [Car · UI tree](../research/features/Car/structure.md)
- [Car · Component / asset bindings](../research/features/Car/ui-elements.csv)
- [Lock_Empty · UI tree](../research/features/Lock_Empty/structure.md)
- [Lock_Empty · Component / asset bindings](../research/features/Lock_Empty/ui-elements.csv)
- [Btn_Pause · UI tree](../research/features/Btn_Pause/structure.md)
- [Btn_Pause · Component / asset bindings](../research/features/Btn_Pause/ui-elements.csv)
- [Gameplay config / rule leads (chưa đủ runtime)](../research/catalogs/gameplay-configs.json)
- [Motion / polish facts và unknowns](../research/motion-and-polish.md)
- [Audio cue audit](../research/audio-audit.md)

Target owner dự kiến: Domain/Board, Domain/Passengers, Application/PuzzleSession, Features/Gameplay, Presentation/Vehicles. GUID/binding đích chưa tạo.

<a id="tutorial"></a>

## TUTORIAL — Tutorial bàn tay/spotlight/target gate

Source-state: R004-level1-blocked-test; R048-vip-select-target
Cần giải quyết: Xác nhận replay và persistence của từng step

- [Gameplay config / rule leads (chưa đủ runtime)](../research/catalogs/gameplay-configs.json)
- [Motion / polish facts và unknowns](../research/motion-and-polish.md)
- [Audio cue audit](../research/audio-audit.md)

Target owner dự kiến: Features/Tutorial, Integration/TutorialTargets, Prefabs/BusFever/Tutorial. GUID/binding đích chưa tạo.

<a id="victory"></a>

## VICTORY — Victory, reward và Next

Source-state: R011-level1-result
Cần giải quyết: Hard/superhard/taskbar reward chưa capture

- [Runtime audit + flow](../research/features/victory-audit.md)
- [VictoryPanel · UI tree](../research/features/VictoryPanel/structure.md)
- [VictoryPanel · Component / asset bindings](../research/features/VictoryPanel/ui-elements.csv)
- [SuccessPanel · UI tree](../research/features/SuccessPanel/structure.md)
- [SuccessPanel · Component / asset bindings](../research/features/SuccessPanel/ui-elements.csv)
- [RewardPanel · UI tree](../research/features/RewardPanel/structure.md)
- [RewardPanel · Component / asset bindings](../research/features/RewardPanel/ui-elements.csv)
- [RewardPanelScale · UI tree](../research/features/RewardPanelScale/structure.md)
- [RewardPanelScale · Component / asset bindings](../research/features/RewardPanelScale/ui-elements.csv)
- [Motion / polish facts và unknowns](../research/motion-and-polish.md)
- [Audio cue audit](../research/audio-audit.md)

Target owner dự kiến: Features/Victory, Application/WinLevel, Prefabs/BusFever/Victory. GUID/binding đích chưa tạo.

<a id="fail"></a>

## FAIL — Fail, Revive, Retry và quit

Source-state: static FailPanel/RevivePanel; runtime chưa đủ
Cần giải quyết: BLOCK source-ready: cần tạo fail bằng normal gameplay

- [FailPanel · UI tree](../research/features/FailPanel/structure.md)
- [FailPanel · Component / asset bindings](../research/features/FailPanel/ui-elements.csv)
- [FailedPanel · UI tree](../research/features/FailedPanel/structure.md)
- [FailedPanel · Component / asset bindings](../research/features/FailedPanel/ui-elements.csv)
- [RevivePanel · UI tree](../research/features/RevivePanel/structure.md)
- [RevivePanel · Component / asset bindings](../research/features/RevivePanel/ui-elements.csv)
- [ReplayPanel · UI tree](../research/features/ReplayPanel/structure.md)
- [ReplayPanel · Component / asset bindings](../research/features/ReplayPanel/ui-elements.csv)
- [Revive_FrameAnim · UI tree](../research/features/Revive_FrameAnim/structure.md)
- [Revive_FrameAnim · Component / asset bindings](../research/features/Revive_FrameAnim/ui-elements.csv)
- [ReviveJam_FrameAnim · UI tree](../research/features/ReviveJam_FrameAnim/structure.md)
- [ReviveJam_FrameAnim · Component / asset bindings](../research/features/ReviveJam_FrameAnim/ui-elements.csv)
- [Motion / polish facts và unknowns](../research/motion-and-polish.md)
- [Audio cue audit](../research/audio-audit.md)

Target owner dự kiến: Domain/Failure, Features/FailRevive, Application/ReviveLevel. GUID/binding đích chưa tạo.

<a id="park"></a>

## PARK — Extra Spot và parking reservation

Source-state: R053-extra-parking; R054-extra-spot-ad-result
Cần giải quyết: Ad completion/cancel/error và coin mode cần xác minh

- [Runtime audit + flow](../research/features/boosters-audit.md)
- [PurchaseParkingSpace · UI tree](../research/features/PurchaseParkingSpace/structure.md)
- [PurchaseParkingSpace · Component / asset bindings](../research/features/PurchaseParkingSpace/ui-elements.csv)
- [Motion / polish facts và unknowns](../research/motion-and-polish.md)
- [Audio cue audit](../research/audio-audit.md)

Target owner dự kiến: Domain/Parking, Features/ExtraSpot, Integration/RewardedAds. GUID/binding đích chưa tạo.

<a id="vip"></a>

## VIP — VIP booster và xe bay

Source-state: R046-level4-ready; R049-vip-flight
Cần giải quyết: Inventory grant/free semantics và cancel còn thiếu

- [Runtime audit + flow](../research/features/boosters-audit.md)
- [VipTransitionPanel · UI tree](../research/features/VipTransitionPanel/structure.md)
- [VipTransitionPanel · Component / asset bindings](../research/features/VipTransitionPanel/ui-elements.csv)
- [ItemPurchasePanel · UI tree](../research/features/ItemPurchasePanel/structure.md)
- [ItemPurchasePanel · Component / asset bindings](../research/features/ItemPurchasePanel/ui-elements.csv)
- [Motion / polish facts và unknowns](../research/motion-and-polish.md)
- [Audio cue audit](../research/audio-audit.md)

Target owner dự kiến: Features/Boosters/Vip, Application/UseVip, Presentation/VipFlight. GUID/binding đích chưa tạo.

<a id="shop"></a>

## SHOP — Shop, coin packs và offers

Source-state: R069-shop-entry; R071-shop-coins
Cần giải quyết: Provider SDK/product IDs, purchase state UI còn thiếu

- [Runtime audit + flow](../research/features/shop-audit.md)
- [ShopPanel · UI tree](../research/features/ShopPanel/structure.md)
- [ShopPanel · Component / asset bindings](../research/features/ShopPanel/ui-elements.csv)
- [ShopCard1 · UI tree](../research/features/ShopCard1/structure.md)
- [ShopCard1 · Component / asset bindings](../research/features/ShopCard1/ui-elements.csv)
- [ShopCard1 1 · UI tree](../research/features/ShopCard1 1/structure.md)
- [ShopCard1 1 · Component / asset bindings](../research/features/ShopCard1 1/ui-elements.csv)
- [ShopCard3 · UI tree](../research/features/ShopCard3/structure.md)
- [ShopCard3 · Component / asset bindings](../research/features/ShopCard3/ui-elements.csv)
- [ShopCard4 · UI tree](../research/features/ShopCard4/structure.md)
- [ShopCard4 · Component / asset bindings](../research/features/ShopCard4/ui-elements.csv)
- [Coin1 · UI tree](../research/features/Coin1/structure.md)
- [Coin1 · Component / asset bindings](../research/features/Coin1/ui-elements.csv)
- [Coin2 · UI tree](../research/features/Coin2/structure.md)
- [Coin2 · Component / asset bindings](../research/features/Coin2/ui-elements.csv)
- [Coin3 · UI tree](../research/features/Coin3/structure.md)
- [Coin3 · Component / asset bindings](../research/features/Coin3/ui-elements.csv)
- [Coin4 · UI tree](../research/features/Coin4/structure.md)
- [Coin4 · Component / asset bindings](../research/features/Coin4/ui-elements.csv)
- [Coin5 · UI tree](../research/features/Coin5/structure.md)
- [Coin5 · Component / asset bindings](../research/features/Coin5/ui-elements.csv)
- [Coin6 · UI tree](../research/features/Coin6/structure.md)
- [Coin6 · Component / asset bindings](../research/features/Coin6/ui-elements.csv)
- [AdFreeBundlePanel · UI tree](../research/features/AdFreeBundlePanel/structure.md)
- [AdFreeBundlePanel · Component / asset bindings](../research/features/AdFreeBundlePanel/ui-elements.csv)
- [ADFreePanel · UI tree](../research/features/ADFreePanel/structure.md)
- [ADFreePanel · Component / asset bindings](../research/features/ADFreePanel/ui-elements.csv)
- [PackagePanel · UI tree](../research/features/PackagePanel/structure.md)
- [PackagePanel · Component / asset bindings](../research/features/PackagePanel/ui-elements.csv)
- [RestoreLoading · UI tree](../research/features/RestoreLoading/structure.md)
- [RestoreLoading · Component / asset bindings](../research/features/RestoreLoading/ui-elements.csv)
- [Motion / polish facts và unknowns](../research/motion-and-polish.md)
- [Audio cue audit](../research/audio-audit.md)

Target owner dự kiến: Features/Shop, Integration/Billing, Data/BusFever/Offers. GUID/binding đích chưa tạo.

<a id="profile"></a>

## PROFILE — Profile, avatar và nickname

Source-state: R064-user-profile; R065-profile-edit
Cần giải quyết: Invalid/save confirmation và account semantics chưa đủ

- [Runtime audit + flow](../research/features/home-and-profile-audit.md)
- [UserProfilePanel · UI tree](../research/features/UserProfilePanel/structure.md)
- [UserProfilePanel · Component / asset bindings](../research/features/UserProfilePanel/ui-elements.csv)
- [UserProfileEditPanel · UI tree](../research/features/UserProfileEditPanel/structure.md)
- [UserProfileEditPanel · Component / asset bindings](../research/features/UserProfileEditPanel/ui-elements.csv)
- [Motion / polish facts và unknowns](../research/motion-and-polish.md)
- [Audio cue audit](../research/audio-audit.md)

Target owner dự kiến: Features/Profile, Data/BusFever/Profile, Prefabs/BusFever/Profile. GUID/binding đích chưa tạo.

<a id="supply"></a>

## SUPPLY — Supplies và hourly cooldown

Source-state: R074-supplies; R075-supplies-claimed
Cần giải quyết: Tier unlock và trusted/offline clock policy

- [Runtime audit + flow](../research/features/supplies-and-spin-audit.md)
- [SuppliesPanel · UI tree](../research/features/SuppliesPanel/structure.md)
- [SuppliesPanel · Component / asset bindings](../research/features/SuppliesPanel/ui-elements.csv)
- [Motion / polish facts và unknowns](../research/motion-and-polish.md)
- [Audio cue audit](../research/audio-audit.md)

Target owner dự kiến: Features/Supplies, Application/ClaimSupply, Integration/Clock. GUID/binding đích chưa tạo.

<a id="spin"></a>

## SPIN — Lucky Spin và probability info

Source-state: R076-spin-entry; R077-spin-info
Cần giải quyết: Spin actual completion và rollback/recovery cần quay

- [Runtime audit + flow](../research/features/supplies-and-spin-audit.md)
- [DailySpin · UI tree](../research/features/DailySpin/structure.md)
- [DailySpin · Component / asset bindings](../research/features/DailySpin/ui-elements.csv)
- [Motion / polish facts và unknowns](../research/motion-and-polish.md)
- [Audio cue audit](../research/audio-audit.md)

Target owner dự kiến: Features/Spin, Integration/LuckyWheel, Data/BusFever/Spin. GUID/binding đích chưa tạo.

<a id="daily"></a>

## DAILY — Daily Bonus đầy đủ

Source-state: static dailybonus bundle
Cần giải quyết: BLOCK source-ready: chưa runtime entry/claim/reset

- [DailybonusPanel · UI tree](../research/features/DailybonusPanel/structure.md)
- [DailybonusPanel · Component / asset bindings](../research/features/DailybonusPanel/ui-elements.csv)
- [Motion / polish facts và unknowns](../research/motion-and-polish.md)
- [Audio cue audit](../research/audio-audit.md)

Target owner dự kiến: Features/DailyBonus, Integration/DailyReward, Prefabs/BusFever/DailyBonus. GUID/binding đích chưa tạo.

<a id="life"></a>

## LIFE — Life, refill và resource recovery

Source-state: static life bundle; template economy recovery
Cần giải quyết: BLOCK source-ready: life visibility/cost chưa xác minh

- [Btn_Lives · UI tree](../research/features/Btn_Lives/structure.md)
- [Btn_Lives · Component / asset bindings](../research/features/Btn_Lives/ui-elements.csv)
- [Effect_Life_Collect · UI tree](../research/features/Effect_Life_Collect/structure.md)
- [Effect_Life_Collect · Component / asset bindings](../research/features/Effect_Life_Collect/ui-elements.csv)
- [Motion / polish facts và unknowns](../research/motion-and-polish.md)
- [Audio cue audit](../research/audio-audit.md)

Target owner dự kiến: Features/Life, Integration/ResourceRecovery, Application/ConsumeLife. GUID/binding đích chưa tạo.

<a id="jumble"></a>

## JUMBLE — Booster Jumble

Source-state: static ItemPropConfigJumble; locked8/13 captures
Cần giải quyết: BLOCK source-ready: chưa xác định mốc/luật thực

- [Runtime audit + flow](../research/features/boosters-audit.md)
- [BoostPackPanel · UI tree](../research/features/BoostPackPanel/structure.md)
- [BoostPackPanel · Component / asset bindings](../research/features/BoostPackPanel/ui-elements.csv)
- [ItemPurchasePanel · UI tree](../research/features/ItemPurchasePanel/structure.md)
- [ItemPurchasePanel · Component / asset bindings](../research/features/ItemPurchasePanel/ui-elements.csv)
- [Motion / polish facts và unknowns](../research/motion-and-polish.md)
- [Audio cue audit](../research/audio-audit.md)

Target owner dự kiến: Features/Boosters/Jumble, Domain/JumblePolicy, Presentation/Jumble. GUID/binding đích chưa tạo.

<a id="arrange"></a>

## ARRANGE — Booster Arrange

Source-state: static ItemPropConfigArrange
Cần giải quyết: BLOCK source-ready: chưa chơi booster và unlock

- [Runtime audit + flow](../research/features/boosters-audit.md)
- [Arrange · UI tree](../research/features/Arrange/structure.md)
- [Arrange · Component / asset bindings](../research/features/Arrange/ui-elements.csv)
- [BoostPackPanel · UI tree](../research/features/BoostPackPanel/structure.md)
- [BoostPackPanel · Component / asset bindings](../research/features/BoostPackPanel/ui-elements.csv)
- [ItemPurchasePanel · UI tree](../research/features/ItemPurchasePanel/structure.md)
- [ItemPurchasePanel · Component / asset bindings](../research/features/ItemPurchasePanel/ui-elements.csv)
- [Motion / polish facts và unknowns](../research/motion-and-polish.md)
- [Audio cue audit](../research/audio-audit.md)

Target owner dự kiến: Features/Boosters/Arrange, Domain/ArrangePolicy, Presentation/Arrange. GUID/binding đích chưa tạo.

<a id="mech-garage"></a>

## MECH-GARAGE — Garage/container spawning

Source-state: metadata/guide/config candidate only
Cần giải quyết: BLOCK source-ready: cần runtime và level data cho family này

- [Gameplay config / rule leads (chưa đủ runtime)](../research/catalogs/gameplay-configs.json)
- [Motion / polish facts và unknowns](../research/motion-and-polish.md)
- [Audio cue audit](../research/audio-audit.md)

Target owner dự kiến: Domain/Mechanisms/GARAGE, Features/Mechanisms/GARAGE, Presentation/Mechanisms/GARAGE. GUID/binding đích chưa tạo.

<a id="mech-belt"></a>

## MECH-BELT — Conveyor và Gate Queue

Source-state: metadata/guide/config candidate only
Cần giải quyết: BLOCK source-ready: cần runtime và level data cho family này

- [Gameplay config / rule leads (chưa đủ runtime)](../research/catalogs/gameplay-configs.json)
- [Motion / polish facts và unknowns](../research/motion-and-polish.md)
- [Audio cue audit](../research/audio-audit.md)

Target owner dự kiến: Domain/Mechanisms/BELT, Features/Mechanisms/BELT, Presentation/Mechanisms/BELT. GUID/binding đích chưa tạo.

<a id="mech-turn"></a>

## MECH-TURN — Turn vehicle

Source-state: metadata/guide/config candidate only
Cần giải quyết: BLOCK source-ready: cần runtime và level data cho family này

- [Gameplay config / rule leads (chưa đủ runtime)](../research/catalogs/gameplay-configs.json)
- [Motion / polish facts và unknowns](../research/motion-and-polish.md)
- [Audio cue audit](../research/audio-audit.md)

Target owner dự kiến: Domain/Mechanisms/TURN, Features/Mechanisms/TURN, Presentation/Mechanisms/TURN. GUID/binding đích chưa tạo.

<a id="mech-elevator"></a>

## MECH-ELEVATOR — Elevator floors

Source-state: metadata/guide/config candidate only
Cần giải quyết: BLOCK source-ready: cần runtime và level data cho family này

- [Gameplay config / rule leads (chưa đủ runtime)](../research/catalogs/gameplay-configs.json)
- [Motion / polish facts và unknowns](../research/motion-and-polish.md)
- [Audio cue audit](../research/audio-audit.md)

Target owner dự kiến: Domain/Mechanisms/ELEVATOR, Features/Mechanisms/ELEVATOR, Presentation/Mechanisms/ELEVATOR. GUID/binding đích chưa tạo.

<a id="mech-hidden"></a>

## MECH-HIDDEN — Hidden/Doubtful colors

Source-state: metadata/guide/config candidate only
Cần giải quyết: BLOCK source-ready: cần runtime và level data cho family này

- [Gameplay config / rule leads (chưa đủ runtime)](../research/catalogs/gameplay-configs.json)
- [Motion / polish facts và unknowns](../research/motion-and-polish.md)
- [Audio cue audit](../research/audio-audit.md)

Target owner dự kiến: Domain/Mechanisms/HIDDEN, Features/Mechanisms/HIDDEN, Presentation/Mechanisms/HIDDEN. GUID/binding đích chưa tạo.

<a id="mech-combo"></a>

## MECH-COMBO — Combination vehicles

Source-state: metadata/guide/config candidate only
Cần giải quyết: BLOCK source-ready: cần runtime và level data cho family này

- [Gameplay config / rule leads (chưa đủ runtime)](../research/catalogs/gameplay-configs.json)
- [Motion / polish facts và unknowns](../research/motion-and-polish.md)
- [Audio cue audit](../research/audio-audit.md)

Target owner dự kiến: Domain/Mechanisms/COMBO, Features/Mechanisms/COMBO, Presentation/Mechanisms/COMBO. GUID/binding đích chưa tạo.

<a id="mech-link"></a>

## MECH-LINK — Linkage vehicles

Source-state: metadata/guide/config candidate only
Cần giải quyết: BLOCK source-ready: cần runtime và level data cho family này

- [Gameplay config / rule leads (chưa đủ runtime)](../research/catalogs/gameplay-configs.json)
- [Motion / polish facts và unknowns](../research/motion-and-polish.md)
- [Audio cue audit](../research/audio-audit.md)

Target owner dự kiến: Domain/Mechanisms/LINK, Features/Mechanisms/LINK, Presentation/Mechanisms/LINK. GUID/binding đích chưa tạo.

<a id="mech-wrench"></a>

## MECH-WRENCH — Wrench/Gear lock

Source-state: metadata/guide/config candidate only
Cần giải quyết: BLOCK source-ready: cần runtime và level data cho family này

- [Gameplay config / rule leads (chưa đủ runtime)](../research/catalogs/gameplay-configs.json)
- [Motion / polish facts và unknowns](../research/motion-and-polish.md)
- [Audio cue audit](../research/audio-audit.md)

Target owner dự kiến: Domain/Mechanisms/WRENCH, Features/Mechanisms/WRENCH, Presentation/Mechanisms/WRENCH. GUID/binding đích chưa tạo.

<a id="mech-ambulance"></a>

## MECH-AMBULANCE — Ambulance

Source-state: metadata/guide/config candidate only
Cần giải quyết: BLOCK source-ready: cần runtime và level data cho family này

- [Gameplay config / rule leads (chưa đủ runtime)](../research/catalogs/gameplay-configs.json)
- [Motion / polish facts và unknowns](../research/motion-and-polish.md)
- [Audio cue audit](../research/audio-audit.md)

Target owner dự kiến: Domain/Mechanisms/AMBULANCE, Features/Mechanisms/AMBULANCE, Presentation/Mechanisms/AMBULANCE. GUID/binding đích chưa tạo.

<a id="mech-fire"></a>

## MECH-FIRE — Firetruck

Source-state: metadata/guide/config candidate only
Cần giải quyết: BLOCK source-ready: cần runtime và level data cho family này

- [Gameplay config / rule leads (chưa đủ runtime)](../research/catalogs/gameplay-configs.json)
- [Motion / polish facts và unknowns](../research/motion-and-polish.md)
- [Audio cue audit](../research/audio-audit.md)

Target owner dự kiến: Domain/Mechanisms/FIRE, Features/Mechanisms/FIRE, Presentation/Mechanisms/FIRE. GUID/binding đích chưa tạo.

<a id="mech-police"></a>

## MECH-POLICE — Police

Source-state: metadata/guide/config candidate only
Cần giải quyết: BLOCK source-ready: cần runtime và level data cho family này

- [Gameplay config / rule leads (chưa đủ runtime)](../research/catalogs/gameplay-configs.json)
- [Motion / polish facts và unknowns](../research/motion-and-polish.md)
- [Audio cue audit](../research/audio-audit.md)

Target owner dự kiến: Domain/Mechanisms/POLICE, Features/Mechanisms/POLICE, Presentation/Mechanisms/POLICE. GUID/binding đích chưa tạo.

<a id="mech-luxury"></a>

## MECH-LUXURY — Luxury/VIP passenger

Source-state: metadata/guide/config candidate only
Cần giải quyết: BLOCK source-ready: cần runtime và level data cho family này

- [Gameplay config / rule leads (chưa đủ runtime)](../research/catalogs/gameplay-configs.json)
- [Motion / polish facts và unknowns](../research/motion-and-polish.md)
- [Audio cue audit](../research/audio-audit.md)

Target owner dự kiến: Domain/Mechanisms/LUXURY, Features/Mechanisms/LUXURY, Presentation/Mechanisms/LUXURY. GUID/binding đích chưa tạo.

<a id="mech-traffic"></a>

## MECH-TRAFFIC — Traffic light / limit count

Source-state: metadata/guide/config candidate only
Cần giải quyết: BLOCK source-ready: cần runtime và level data cho family này

- [Gameplay config / rule leads (chưa đủ runtime)](../research/catalogs/gameplay-configs.json)
- [Motion / polish facts và unknowns](../research/motion-and-polish.md)
- [Audio cue audit](../research/audio-audit.md)

Target owner dự kiến: Domain/Mechanisms/TRAFFIC, Features/Mechanisms/TRAFFIC, Presentation/Mechanisms/TRAFFIC. GUID/binding đích chưa tạo.

<a id="rank"></a>

## RANK — Leaderboard và weekly rewards

Source-state: R073-ranking-locked; RankingConfig
Cần giải quyết: BLOCK unlocked: cần29 + backend/provider scope

- [RankingPanel · UI tree](../research/features/RankingPanel/structure.md)
- [RankingPanel · Component / asset bindings](../research/features/RankingPanel/ui-elements.csv)
- [RankingGuidePanel · UI tree](../research/features/RankingGuidePanel/structure.md)
- [RankingGuidePanel · Component / asset bindings](../research/features/RankingGuidePanel/ui-elements.csv)
- [RankingRewardPanel · UI tree](../research/features/RankingRewardPanel/structure.md)
- [RankingRewardPanel · Component / asset bindings](../research/features/RankingRewardPanel/ui-elements.csv)
- [Motion / polish facts và unknowns](../research/motion-and-polish.md)
- [Audio cue audit](../research/audio-audit.md)

Target owner dự kiến: Features/Ranking, Integration/Leaderboard, Data/BusFever/Ranking. GUID/binding đích chưa tạo.

<a id="task"></a>

## TASK — Task Bar, collection và timed cycle

Source-state: TaskBarConfig + static panels
Cần giải quyết: BLOCK source-ready: runtime event semantics missing

- [TaskBarPanel · UI tree](../research/features/TaskBarPanel/structure.md)
- [TaskBarPanel · Component / asset bindings](../research/features/TaskBarPanel/ui-elements.csv)
- [TaskBarGuidePanel · UI tree](../research/features/TaskBarGuidePanel/structure.md)
- [TaskBarGuidePanel · Component / asset bindings](../research/features/TaskBarGuidePanel/ui-elements.csv)
- [TaskBarPromoPanel · UI tree](../research/features/TaskBarPromoPanel/structure.md)
- [TaskBarPromoPanel · Component / asset bindings](../research/features/TaskBarPromoPanel/ui-elements.csv)
- [TaskBarCollectionPanel · UI tree](../research/features/TaskBarCollectionPanel/structure.md)
- [TaskBarCollectionPanel · Component / asset bindings](../research/features/TaskBarCollectionPanel/ui-elements.csv)
- [TaskBarGameCollect · UI tree](../research/features/TaskBarGameCollect/structure.md)
- [TaskBarGameCollect · Component / asset bindings](../research/features/TaskBarGameCollect/ui-elements.csv)
- [TaskBarBallPanel · UI tree](../research/features/TaskBarBallPanel/structure.md)
- [TaskBarBallPanel · Component / asset bindings](../research/features/TaskBarBallPanel/ui-elements.csv)
- [TaskBarGiftPanel · UI tree](../research/features/TaskBarGiftPanel/structure.md)
- [TaskBarGiftPanel · Component / asset bindings](../research/features/TaskBarGiftPanel/ui-elements.csv)
- [TaskBarRewardPanel · UI tree](../research/features/TaskBarRewardPanel/structure.md)
- [TaskBarRewardPanel · Component / asset bindings](../research/features/TaskBarRewardPanel/ui-elements.csv)
- [Motion / polish facts và unknowns](../research/motion-and-polish.md)
- [Audio cue audit](../research/audio-audit.md)

Target owner dự kiến: Features/TaskBar, Integration/Missions, Application/EventCycle. GUID/binding đích chưa tạo.

<a id="color"></a>

## COLOR — Color Guess mini-game

Source-state: ColorGuessConfig + panels
Cần giải quyết: BLOCK source-ready: rules/cost/persistence not observed

- [ColorGuessPanel · UI tree](../research/features/ColorGuessPanel/structure.md)
- [ColorGuessPanel · Component / asset bindings](../research/features/ColorGuessPanel/ui-elements.csv)
- [ColorGuessPromoPanel · UI tree](../research/features/ColorGuessPromoPanel/structure.md)
- [ColorGuessPromoPanel · Component / asset bindings](../research/features/ColorGuessPromoPanel/ui-elements.csv)
- [ColorGuessGuidePanel · UI tree](../research/features/ColorGuessGuidePanel/structure.md)
- [ColorGuessGuidePanel · Component / asset bindings](../research/features/ColorGuessGuidePanel/ui-elements.csv)
- [ColorGuessInfoPanel · UI tree](../research/features/ColorGuessInfoPanel/structure.md)
- [ColorGuessInfoPanel · Component / asset bindings](../research/features/ColorGuessInfoPanel/ui-elements.csv)
- [ColorGuessSlotBase · UI tree](../research/features/ColorGuessSlotBase/structure.md)
- [ColorGuessSlotBase · Component / asset bindings](../research/features/ColorGuessSlotBase/ui-elements.csv)
- [ColorGuessBottleItem · UI tree](../research/features/ColorGuessBottleItem/structure.md)
- [ColorGuessBottleItem · Component / asset bindings](../research/features/ColorGuessBottleItem/ui-elements.csv)
- [ColorGuess_Btn · UI tree](../research/features/ColorGuess_Btn/structure.md)
- [ColorGuess_Btn · Component / asset bindings](../research/features/ColorGuess_Btn/ui-elements.csv)
- [Motion / polish facts và unknowns](../research/motion-and-polish.md)
- [Audio cue audit](../research/audio-audit.md)

Target owner dự kiến: Features/ColorGuess, Domain/ColorGuess, Data/BusFever/ColorGuess. GUID/binding đích chưa tạo.

<a id="local"></a>

## LOCAL — Localization, fonts và UI assets

Source-state: localization-en-vi.csv; font/source catalog
Cần giải quyết: Package TMP dependency and fallback target verification

- [Localization source keys EN/VI](../research/catalogs/localization-en-vi.csv)
- [Motion / polish facts và unknowns](../research/motion-and-polish.md)
- [Audio cue audit](../research/audio-audit.md)

Target owner dự kiến: Integration/Localization, Data/BusFever/Locales, Presentation/Fonts. GUID/binding đích chưa tạo.

<a id="audio"></a>

## AUDIO — Audio, haptic và full polish pass

Source-state: audio catalog; animation/motion profiles
Cần giải quyết: Runtime mixer/trigger/audio-sync capture missing

- [Motion / polish facts và unknowns](../research/motion-and-polish.md)
- [Audio cue audit](../research/audio-audit.md)

Target owner dự kiến: Presentation/Polish, Data/BusFever/Feedback, Integration/Audio. GUID/binding đích chưa tạo.
