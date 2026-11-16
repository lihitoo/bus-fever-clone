> **SDK decision mới:** SDK ngoài do DreamySDK xử lý; hiện dùng API stub/default theo user để local test. Không cần provider thật cho local UI acceptance. Production/provider gates vẫn riêng. [Contract](11-dreamy-sdk-boundary.md).

# Project và package strategy

## Baseline đã đọc

Unity 6000.4.12f1; manifest + lock được đọc; URP17.4, Addressables2.9.1, InputSystem1.19, UGUI2/TMP, UniTask/DOTween có trong dependency. Build scenes và asmdef graph giữ trong evidence project-inspect. Harness static `project-inspect` và `asmdef` đều pass, 43 asmdef; chưa chứng minh compile/PlayMode/build. Active renderer cần đối chiếu profile/scene khi triển khai, không suy chỉ từ tên dependency.

GameInstaller hiện có thứ tự persistence/infrastructure→economy→config→feature→presentation; có rollback cleanup. HomePresenter là C# với IHomeView, Bind/Dispose; PanelPresenterFactory gắn vào PanelManager theo scene. Economy dùng một DatasaveResourceWallet; feedback do FeedbackHost sở hữu; audio package sở hữu service. Cần giữ các hợp đồng này khi đưa VContainer vào.

## Ưu tiên tái sử dụng

| Package | Hiện trạng/đích sử dụng | Điều kiện |
| --- | --- | --- |
| Core1.2.0 | Manifest git v1.2.0; lifecycle/event/state/shared contracts | Không dùng locator trong leaf feature mới |
| Assets1.0.1 | Manifest git; Addressables load/cache/release qua adapter | Test cancel/in-flight/failure và ownership đúng version |
| Datasave1.0.1 | Manifest git; progression, inventory, profile, settings, event state | Save migration/backup/recovery và transaction receipt |
| DataConfig1.0.1 | Manifest git; level/offer/timing/unlock/event definitions | Validate ID/schema/cross references trước runtime |
| UI1.1.0 | Embedded; panel/popup/navigation/presenter lifecycle | Không sửa package chỉ để reskin game |
| Audio1.0.5 | Manifest git; BGM/SFX/mute | Map cue→clip→mixer và lifetime, không double-create |
| Feedback0.4.1 | Manifest git; VFX/UI/icon fly/haptic/camera capabilities qua source verification | Không đặt luật gameplay trong feedback callback |
| Feature0.2.0 | Embedded; feature/UI foundation | Dùng base/variant theo source và giữ sample dependency direction |
| Economy0.8.1 | Embedded; wallet/reward/recovery | Một wallet; reward atomic/idempotent; không có balance shadow |
| Settings0.3.0 | Embedded; reuse setting model/platform gateway | Hai skin Home/Pause, cùng setting state |
| Shop0.3.0 | Embedded; catalog/purchase/recovery | Thay gateway demo mô phỏng Purchased trước production |
| EditorTools1.2.0 | Embedded; tooling/validation được công bố | Editor-only, dry-run trước batch mutation |
| Debugger pinned SHA | Dev diagnostics | Không mang cheat/provider demo vào production |

Phiên bản trên là quan sát manifest hoặc package.json, không phải chứng nhận compatibility. Toàn bộ declared/resolved/hash/registry trong [matrix](evidence/project-package-matrix.json). Registry toolkit có nhiều version/commit cũ hơn đích; mọi nâng/cài phải có consumer test trước khi claim API tương thích. Không overwrite registry global để che drift.

## Package upstream đã tìm thấy, chưa cài

[Org inventory](evidence/org-repositories.json) có23 repo từ API khi khảo sát, khác snapshot web listing22; [pin evidence](evidence/upstream-packages.json) ghi SHA chính xác và package.json. Khả năng dưới đây đọc từ mô tả/README ở pin, vẫn cần source+consumer verification.

| Package | Pin version quan sát | Kế hoạch |
| --- | --- | --- |
| feature.tutorial | 0.3.0 | Ưu tiên cho tutorial UI/3D, checkpoint và scoped input; adapter target BusFever |
| feature.progression | 0.2.1 | Level advancement và milestone/reward; kiểm tra dependency config/save/economy cũ |
| feature.missions | 0.3.1 | Mission counters/claim; Task Bar timed seasons cần gap analysis, không giả định sample periodic là full event framework |
| feature.daily-reward | 0.3.0 | Daily Bonus; Supples hourly chỉ reuse phần reward nếu contract phù hợp |
| feature.lucky-wheel | Xem package.json trong evidence | Lucky Spin; kiểm tra weighted pick, progression credit, reward recovery và cancellation trước adapter |
| connectivity | Xem package.json trong evidence | Mạng/retry/recovery với host SDK; không tự xem network online là transaction succeeded |
| localization | 0.2.0 | Import 278 key, font fallback và setting gateway; kiểm tra dependency TMP5 so với Unity6 UGUI/TMP hiện hữu trước install |

Không copy version dependency cũ từ package.json vào project để downgrade cả graph. T001 tạo compatibility decision từng package, pin tag/SHA thực sự chọn, so diff lock và chạy consumer. Nếu cần sửa package, thay đổi độc lập có test/package version/changelog rồi thử lại tại project; tránh chỉnh vendor cache.

## VContainer giới hạn ở Home và gameplay session

User muốn học DI nên đây là requirement, không thêm chỉ để đổi style. Gói `jp.hadashikick.vcontainer` chưa có trong manifest. Tài liệu chính thức có ví dụ git pin1.19.0; đó là candidate để thử trên Unity6000.4.12f1, không tự gọi là latest hoặc bảo đảm IL2CPP. T002 quyết định pin sau consumer smoke; không cài ở giai đoạn plan. [Installation](https://vcontainer.hadashikick.jp/getting-started/installation).

## Khoảng trống và đề xuất làm thêm

| Gap | Đề xuất | Owner mặc định / điều kiện đưa lên org |
| --- | --- | --- |
| Dreamy↔VContainer ownership bridge | Adapter nhỏ cho service đã tồn tại, presenter factory, readiness và dispose | Project Composition trước; package `com.dreamy.integration.vcontainer` chỉ là tên đề xuất, chưa tồn tại trong inventory; đưa lên org sau2 consumer độc lập |
| Ads reward completion | IRewardedAdGateway, kết quả completed/cancelled/no-fill/error, transaction token | Project platform adapter; chỉ đề xuất shared Ads package khi đã kiểm tra SDK org khác và contract reuse |
| Billing production/restore | Implement gateway có trong Shop, receipt/idempotency/pending | Adapter project dùng provider SDK được chọn; không viết Shop thứ hai |
| Ranking profile/backend | Local profile + leaderboard gateway/caching/weekly identity | Game-specific trước; đề xuất module shared khi data/privacy/offline semantics rõ |
| Trusted clock/life/hourly/event | Clock boundary, recovery/resource policies; đánh giá Economy recovery có đủ chưa | Adapter/policy project; không tạo life/daily-reward package trùng sẵn có |
| Task Bar/Color Guess | Event session/cycle contracts, game UI, reward integration | Project Features; Missions/LuckyWheel/DailyReward reuse theo scope, không ép sai semantics |
| Puzzle/movement/passenger | Domain riêng BusFever | Luôn project, không đẩy luật xe vào Core/UI/Feedback |

Mỗi proposal cần README contract, dependency DAG, runtime/editor/test asmdef, sample, rollback, test bằng2consumer và release record. Những đề xuất này không phải package đã được phê duyệt hoặc đã có API.
