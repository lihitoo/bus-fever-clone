> **ADR cập nhật theo user:** không tạo HomeComposition hoặc HomePresenterFactory mới. Home giữ HomeNavigator và constructor DI trực tiếp. VContainer chỉ cài pin ở M00; bài tập scope chuyển sang GAME. Đoạn Home container pilot cũ bên dưới là lịch sử thiết kế đã bị thay thế bởi quyết định này.

# Hợp đồng triển khai: senior code, installer riêng và VContainer vừa đủ

Đây là yêu cầu cho giai đoạn code sau khi user yêu cầu triển khai. Các tên file/type bên dưới là thiết kế đề xuất, chưa phải API của Dreamy hay code đã tồn tại. Đọc cùng [conventions](04-conventions.md), [architecture](03-architecture.md) và [harness](06-harness.md).

## VContainer: hai bài tập có giới hạn

1. **Home:** một composition scope tạo HomePresenter qua typed factory của Dreamy UI. Học constructor injection, registration, lifetime và dependency graph. PanelManager vẫn gọi lifecycle presenter đúng contract hiện tại. Không dùng container entrypoint gọi Show lần hai.
2. **Gameplay:** thêm đúng một child scope cho mỗi level session khi đến feature GAME. Học scoped session, cancellation, retry/exit và thứ tự dispose. Không tạo scope cho từng passenger, tween, popup hay pooled entity.

Ngoài hai điểm trên, mặc định dùng constructor DI và factory trực tiếp. Settings, Shop, Daily, Missions và những feature khác không bắt buộc biết VContainer. Không truyền IObjectResolver vào application/domain/view, không đổi toàn bộ GameInstaller hoặc Dreamy packages sang container. Mở rộng container cần ADR nêu lợi ích đã quan sát, chi phí và rollback. Source generator và tự scan assembly chưa nằm trong pilot.

T002 chỉ dựng bridge/factory và kiểm tra lifetime nhỏ; UI Home thật được thay ở task HOME, session scope thật ở GAME. Không dựng sẵn tất cả feature để hoàn thành task nền tảng.

## Installer cho từng Dreamy feature

Giữ service creation/disposal hiện có ở GameInstaller. Tách phần composition đang nằm trong các partial sang owner riêng theo từng feature khi đến lượt feature đó; không làm một đợt refactor lớn trước khi thấy UI.

| Owner đề xuất | Trách nhiệm | Không sở hữu |
| --- | --- | --- |
| GameInstaller | Trình tự initialize, readiness, fail rollback và reverse teardown | Logic shop, settings, puzzle |
| SettingsFeatureInstaller | Dependencies settings, presenter registrations, panel addresses, setting gateways | Wallet/audio service mượn từ root |
| ShopFeatureInstaller | Catalog adapter, purchase/restore gateway, Shop presenters, production capability validation | Tạo wallet thứ hai hoặc tự giả lập Purchased trong production |
| TutorialFeatureInstaller | Target resolver và input gate, presenter registrations | Luật puzzle hoặc tiến trình ngoài contract |
| ProgressionFeatureInstaller | Level catalog/progression adapters, reward routing | View scene và tween completion |
| DailyRewardFeatureInstaller | Clock/reward/config adapters và claim UI | Datasave hoặc receipt store thứ hai |
| MissionsFeatureInstaller | Fact-to-counter adapter, cycle identity, claim UI | Poll mọi View hoặc làm global event router |
| LuckyWheelFeatureInstaller | Config/reward adapter, wheel UI, owned playback | Trao thưởng bằng animation callback |
| LocalizationInstaller | Locale provider, text/font binding, setting gateway | Purchase/game state |

Những installer chưa có package được chọn chỉ tồn tại trên plan. Không thêm chúng vào manifest hoặc tạo class rỗng. Core/Assets/Audio/Save/Config/Feedback là foundation, không cần bọc thêm một tầng nếu owner hiện có đã rõ.

Mỗi installer nhận dependencies tường minh qua constructor/installation context nhỏ có typed members. Không nhận GodContext chứa mọi service. Bước install trả về installation handle hoặc cơ chế cleanup tương đương được kiểm tra với API thật; registry điều phối teardown theo thứ tự ngược. Không khai báo đây là interface của Dreamy. Nếu init dở thất bại, dispose phần đã tạo; handle idempotent; service mượn không bị dispose. Đăng ký presenter có thể cần phục hồi factory trước đó theo template hiện có. Không reflection scan, static mutable registry hay installer tự tìm nhau trong scene.

Acceptance cho mỗi installer: install→open→close→reopen không nhân handler; cancel giữa init không publish Ready; teardown hai lần an toàn; lỗi feature không hủy service dùng chung; không còn hai nơi đăng ký cùng presenter. Chạy kiểm tra lifecycle ở lớp thấp nhất đủ chứng minh, cộng PlayMode cho panel/scene integration thực tế.

## SOLID gắn với hành vi cần chứng minh

| Nguyên tắc / pattern | Áp dụng cụ thể | Bằng chứng review |
| --- | --- | --- |
| SRP + MVP | BoardRules quyết định move; presenter điều phối; view render; playback phát hiệu ứng | Đổi skin không sửa rules, test rules không cần scene |
| OCP + Strategy | Chỉ tách movement/mechanism policy khi đã có biến thể thực tế | Hai biến thể dùng cùng contract, không switch khắp codebase |
| LSP | Billing/ad/clock fake và provider giữ cùng pending/cancel/failure semantics | Contract scenario không đổi khi thay provider |
| ISP | Read model/wallet query và command boundary vừa nhu cầu consumer | View không nhận save/wallet mutation interface |
| DIP + Adapter | Use case nhận gateway hợp đồng nhỏ; composition chọn Dreamy/platform adapter | Domain không phụ thuộc Dreamy locator, Unity hay VContainer |
| Factory | Tạo presenter/session qua typed factory có owner | Một Show/Dispose, không Resolve ở leaf |
| State machine | Session Loading/Playing/Resolving/Won/Failed/Exiting có guard | Invalid transition bị từ chối; retry đổi session ID |
| Command + Result | Tap thành move request, rejection có lý do | Tap bị khóa không đổi state; duplicate request không move hai lần |
| Observer | Phát fact đã commit cho UI/audio/mission cần biết | Unsubscribe khi close; event không vòng lặp sửa authority |
| Transaction + idempotency | Reward/purchase/claim có receipt/cycle ID | Duplicate/late callback chỉ grant một lần, crash recovery rõ |
| Pool | Xe/passenger/FX có reset contract | Return giữa tween rồi rent lại không giữ callback cũ |

Không bắt dùng mọi pattern trong mọi feature. Review reject interface chỉ bọc một lời gọi không tạo boundary có ích, base class chứa nhiều cờ, factory-of-factories hoặc global event bus che dependencies. Ưu tiên một đường đi dễ đọc từ intent tới commit và presentation.

## Skill routing khi thực thi

Mỗi task phải đọc skill liên quan lúc bắt đầu và kiểm tra source/pins hiện tại. Các dòng chưa áp dụng ở lượt planning này là hướng dẫn cho lần thực thi, không phải claim đã chạy skill hoặc test.

| Loại công việc | Skill cần áp dụng | Output bắt buộc |
| --- | --- | --- |
| Nền tảng / ownership | unity-project-analysis, unity-foundations, dreamy-template, dreamy-architecture, dreamy-core | Dependency DAG, service owner/lifetime, version decisions |
| Feature xuyên package | dreamy-feature | Config/save/session/UI/assets/verification map |
| Panel/popup và reskin | dreamy-ui, unity-ui, unity-ui-reskin, unity-scene-prefab | Serialized binding map, GUID-safe diff, safe-area, matched screenshots |
| DI/lifecycle/async | dreamy-architecture, unity-async | Cancellation/disposal ledger, close/retry scenarios |
| Asset loading | dreamy-assets, unity-addressables | Handle/cache/pool owner, failure/release receipts |
| Config và save | dreamy-dataconfig, dreamy-datasave, unity-serialization | Schema/stable IDs/validation/migrations và recovery |
| SFX/tween/haptic | dreamy-audio, dreamy-feedback | Cue→trigger→owner→cleanup→reference-time map |
| Locale | dreamy-localization | Key/font/fallback map, relayout screenshots |
| Editor/import | dreamy-editor-tools, unity-editor-tooling | Dry-run/receipt và Runtime không tham chiếu Editor |
| Verification | dreamy-testing, unity-testing; unity-profiling khi cần đo | Smallest meaningful test, compile/console, revision-bound evidence |
| Device/build | dreamy-mobile, mobile-production, android-build-release | Real device/build/provider checks và degraded reasons chính xác |

## Feature review gate

Một task implementation chỉ được official-verified khi reviewer theo được requirement→source state→asset binding→owner→normal route→scenario→receipt đúng revision. Compile không chứng minh parity; screenshot không chứng minh save/reward correctness. Pattern names không thay cho lifecycle tests. Source thiếu thì giữ unknown và bổ sung capture trước acceptance liên quan.

Mỗi feature có một PR/slice nhìn thấy được: before screenshot của project, target screenshot, after screenshot và clip flow. UI mới được gắn vào route thật ngay trong slice. Sau khi verify mới chuyển feature tiếp. Dashboard chỉ báo tiến độ bằng receipts đã review; file local được chọn để xem thử không phải evidence chính thức.
