# Asset và data pipeline

## Từ nguồn tới scene đang chơi

Source artifact SHA→bundle/CAB/pathID→export path/hash→selected derivative receipt→Unity GUID→prefab/component/property→screen/state→capture. Source manifest2.648address và media binding catalog đã có; khi import chỉ chọn nhóm cần cho milestone, giữ các asset chưa chọn được index. Raw export ngoài project `D:\GameAudit\bus-fever-1.3.2`; không import toàn bộ project AssetRipper hoặc dummy scripts.

### Tại từng feature

1. Liệt kê exact source-state/screens và UI hierarchy từ `docs/research/features/<Prefab>/ui-elements.csv`.
2. Chọn mesh/material/texture/sprite/font/audio/animation phụ thuộc; resolve CAB/pathID, không chỉ filename.
3. Texture atlas: rect/rotation/tight mesh/pivot/border9slice; font: glyph/atlas/material/outline/fallback; mesh: scale/orientation/bounds; audio: samples/rate/loop/variants.
4. Tạo derivative nếu cần URP shader/material tương thích; ghi nguồn/biến đổi, giữ nguyên bản raw. Shader Dummy là placeholder export, không dùng để claim appearance giống.
5. Import vào nhóm feature, giữ GUID đã dùng; prefab variants nếu base contract phù hợp, game-owned prefab nếu composition nguồn khác; không sửa base package skin cho một game.
6. Bind đúng view contract/presenter factory/address ở entry đang chạy, kiểm tra duplicate address/dependency/shader missing.
7. Capture matched state, xem ở aspect chuẩn/tall và low-end profile; sửa sai khác rồi ghi receipt.

## Phân loại asset

| Nhóm | Kiểm tra riêng |
| --- | --- |
| Home | City/background depth, bus/queue/character, projection/camera, nav animation; không flatten toàn bộ thành screenshot |
| Gameplay | Vehicle variants, colors/arrows, scale, shadow/material, crowd/VAT, conveyor/parking, collider/query bounds |
| Popup | Card frame/inset, safearea/anchors, font outline/material, sorting/raycast/modal input |
| Victory | Spine skeleton/atlas/material và licensing/package dependency; clip cùng tên không tự thay Spine playback |
| FX/audio | Lifetime/pool/release, sorting, emission/burst, cues và global mute, don't-owning-gameplay |

## Config schema dự kiến

LevelDefinition: stable ID/sourceGroup/version/difficulty/mapTransform/vehicle definitions/linkage/mechanism configs/passenger policy/parking policy/win-fail policy. VehicleDefinition: stable entity ID/color/capacity/shape/direction/bounds/hidden/container refs. MotionProfile: cue/targets/curves/timing/cancel policy. OfferDefinition: stable offer/product/resource bundle/visibility/localized key. EventDefinition: cycle identity/time basis/unlock/objectives/rewards/expiry policy. Mọi field runtime-source chưa rõ ghi unknown trong research; không thay bằng default tùy ý rồi đóng source-ready.

Static JSON/DataConfig hoặc authored ScriptableObject theo nhu cầu ops; frozen DTO vào Domain không tham chiếu SO mutable. Validate duplicate IDs, invalid capacity/cost/curve ranges, missing color/material/localization/audio/address references, mechanism invariants, schema version. Không dùng enum numeric/array index thay stable save ID khi content có thể thêm/xóa.

## Save schema và migration

Owner một Datasave service và wallet Dreamy. Save tách progression/profile/preferences/inventory/life/event/tutor checkpoint, có version và recovery receipt. Ledger cho reward/purchase/ad/spin/taskclaim đảm bảo duplicate không grant2lần; điều kiện resume/retry/cancel của paid operation phải được định nghĩa trước UI animation.

TemplateSave hiện hữu không bị đổi tên/hủy schema vô cớ. T005 review migration từ state mẫu sang state game, giữ backup, test empty/old/current/future/corrupt/truncated/interrupted write; không test migration bằng delete save mỗi lần. Xor codec ở template là encoding/obfuscation, không coi là security hay chống gian lận. Product IDs/tokens của game nguồn không dùng lại cho production.

## Level coverage và AES

Bốn bundle AES là blocker dữ liệu cho exact full-content clone. Milestone gameplay có thể dùng những layout quan sát có provenance để chứng minh route, nhưng không thay nghĩa fullgame. Cần REA điều tra parser/loader theo câu hỏi cụ thể, hoặc dữ liệu được chủ sở hữu cung cấp/capture hợp lệ. Unknown giải mã và native parsing giữ trong backlog. Count level file, config loop ranges, remote bundle và region/experiment cần reconcile với manifest và gameplay; không suy tất cả level bằng hình Level1.
