> **ADR cập nhật theo user:** không tạo HomeComposition hoặc HomePresenterFactory mới. Home giữ HomeNavigator và constructor DI trực tiếp. VContainer chỉ cài pin ở M00; bài tập scope chuyển sang GAME. Đoạn Home container pilot cũ bên dưới là lịch sử thiết kế đã bị thay thế bởi quyết định này.

# Code convention và review contract

SDK ngoài: mọi tích hợp vendor đi qua DreamySDK ở feature gateway/presenter/service. Local test dùng default stub theo user; View không gọi vendor hoặc mở URL trực tiếp. [Contract hiện tại](11-dreamy-sdk-boundary.md) và [rule repo](../../AGENTS.md) thay thế yêu cầu cung cấp provider thật trước local UI acceptance; production có gate riêng.

Các quy tắc này là yêu cầu cho giai đoạn triển khai, chưa sinh .cs hoặc .editorconfig.

| Chủ đề | Quy tắc bắt buộc | Dấu hiệu reject |
| --- | --- | --- |
| Naming | PascalCase type/public member, camelCase private/local theo template hiện tại; `I` cho boundary interface; `Async` cho async; namespace BusFever theo feature | Trộn nhiều style trong cùng module; đổi field serialize chỉ để đẹp |
| File | Một owner/class chính mỗi file; readonly dependencies, sealed mặc định nếu không có extension contract | GameManager chứa save/UI/physics/purchase/pool tất cả |
| DI | Constructor injection cho pure C#; MonoBehaviour injection tại factory/root; dependencies required fail fast ở root | ServiceLocator/Resolve/GetInstance trong presenter, domain hoặc leaf view |
| MVP | View render+intent; Presenter projection/orchestration; Model/session/service authority | Button tự trừ coin, View tìm service bằng FindObjectOfType |
| Domain | Stable IDs, deterministic rules, explicit Result/reason; không UnityEngine/MonoBehaviour | Luật chọn xe dựa vào vị trí tween dở hoặc prefab name |
| Error | Domain rejection là kết quả hợp lệ; exception cho fault; boundary log context và recovery | catch rỗng, trả success khi timeout/no-fill |
| Async | Token theo owner; không async void ngoài Unity boundary; await task có kết quả | Delay theo magic number để chờ init xong; nhiệm vụ sống sau close |
| Tween | Config profile/cue ID, owner và cancel; kill tween đúng target/handle | DOTween.KillAll, callback giữ scene chết, tween trao reward |
| Serialization | Giữ .meta/GUID/reference; rename serialized field có migration/FormerlySerializedAs phù hợp | Xóa tạo lại prefab hoặc đổi schema không migration |
| Data | Config/save/session tách; validate numeric range và references | Ghi progression vào ScriptableObject chung, dùng instance ID làm save key |
| Economy | Package wallet là truth, receipt và idempotency key | Ui balance riêng, grant IAP trong click handler |
| Runtime/Editor | Editor asmdef/platform Editor; generated importer ngoài Runtime | `using UnityEditor` vào Runtime hoặc Editor helper được gọi lúc chơi |
| Performance | Không LINQ/closures/alloc theo frame trong hot loop; pool/reset; profile trước optimize | DI Resolve trong từng Update/passenger, instantiate không release |
| Tests | Tập trung behavior/boundary/lifecycle/save, fixture từ source hoặc contract | Test chỉ assert field getter giống implementation |
| Docs | Requirement→source→asset→owner→scenario→evidence | Claim parity bằng số ảnh/file hoặc compile pass |

## Checklist mỗi PR/feature

1. Scope/feature ID, source states, những unknown được giữ lại.
2. Owner và lifetime của mọi subscription/token/tween/asset handle; mọi injected service ai dispose.
3. Đúng data boundaries; package reuse và version/hash đã đối chiếu.
4. Normal route mở được UI mới; address binding không trỏ màn demo cũ; nút bấm có hành vi/error path.
5. Scene/prefab diff nhỏ, không mất GUID/binding, safe area/font/atlas/material đã xem.
6. Chạy lowest test layer cần thiết + compile/console khi Unity available, record degraded nếu chưa chạy được.
7. Before/after source/clone capture cùng state; những sai khác còn lại có ID.
8. Một feature xong mới chuyển feature kế; không chỉ tạo folder/prefab xong đánh dấu verified.

## Học VContainer theo milestone

T002 học container registrations, constructor injection và dependency graph bằng feature Home có test. Gameplay học một child session scope và ownership của view factories. Các feature khác, gồm Shop/Spin, dùng constructor DI trực tiếp; chưa mở rộng container. Kết thúc một milestone ghi 5–10 dòng giải thích dependency đi từ đâu và dispose ở đâu; dùng Diagnostics Window khi có leak/duplicate, không bật source generator để che lỗi lifecycle. Source generation/IL2CPP tối ưu là task muộn cần device/build evidence.
