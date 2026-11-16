# Audit Bus Fever Party!

## Phạm vi và trạng thái

Audit gameplay, UI, asset, chuyển động và âm thanh; công việc audit này chưa viết code clone hoặc import asset vào game đích. Bộ asset tham chiếu dùng chung theo yêu cầu người dùng. Ghi phiên bản tại nguồn bằng chứng để tra sai khác khi cần: XAPK 1.3.2/build 65 cho dữ liệu tĩnh; Google Play 1.3.3/build 66 cho phiên chơi LDPlayer.

Đây là hồ sơ đang được bổ sung, không phải xác nhận đã khám phá hết game. Dữ liệu trích được và hành vi đã chơi được ghi riêng.

## Đọc hồ sơ

- [Gameplay, onboarding và progression đầu game](features/gameplay-audit.md)
- [Settings, Restart và interruption](features/settings-audit.md)
- [Victory và reward](features/victory-audit.md)
- [VIP và Extra Spot](features/boosters-audit.md)
- [Home, Profile và Settings tại Home](features/home-and-profile-audit.md)
- [Shop và Leaderboard locked](features/shop-audit.md)
- [Supplies và Lucky Spin](features/supplies-and-spin-audit.md)
- [Tween, animation và polish](motion-and-polish.md)
- [Âm thanh](audio-audit.md)
- [Flow đã quan sát và các nhánh chưa mở](flows.md)
- [Catalog prefab UI](catalogs/ui-prefabs.json), [3.673 component UI](catalogs/ui-components.csv)
- [Ví dụ map sprite có hình ảnh](asset-map-examples.md)
- [Cấu hình gameplay đọc trực tiếp](catalogs/gameplay-configs.json)
- [278 khóa localization tiếng Anh/Việt](catalogs/localization-en-vi.csv)
- [Trạng thái audit và việc tiếp theo](checkpoint.md)

## Dữ liệu đã kiểm tra

| Nguồn | Kết quả | Giới hạn |
| --- | --- | --- |
| XAPK | Hash và identity đã ghi, base/split được unpack và kiểm tra receipt | Không xác nhận nội dung remote |
| Manifest bundle | 29 bundle, 2.648 asset có đường dẫn/address/dependency | Address không tự chứng minh đang được dùng trong runtime |
| 25 bundle FileOffset | Bỏ đúng 12 byte zero trên bản sao, đọc được 31.436 object | Giữ hash nguồn/bản sao trong receipt |
| UI | 73 prefab, 3.826 node; 3.673 MonoBehaviour component | Bao gồm prefab hỗ trợ, item, popup; không phải 70 màn hình độc lập |
| Binding | 1.634 thuộc tính component liên kết tới media xuất được | Binding serialized; chưa kiểm tra mọi state runtime |
| Animation | 425 clip trong bundle; 426 file `.anim` trong export có cả base data | Tốc độ Animator/sequence có thể đổi thời gian thực |
| Sprite/audio | 1.407 sprite và 50 audio clip, xuất thành công và receipt pass | Media count không chứng minh mapping trigger hoặc fidelity |
| REA | Metadata + binary ARM64, có Evidence và địa chỉ method | Chưa decompile logic native; tên method không phải hành vi đã chứng minh |
| 4 bundle level AES | Manifest xác nhận provider AES | Chưa giải mã; chưa có catalog layout toàn bộ level |

## Nguồn bằng chứng

- Root nghiên cứu ngoài repo: `D:\GameAudit\bus-fever-1.3.2`.
- `reports/rea-metadata-evidence.json`: Evidence gốc 32 MB. ID `ev_0f574a0d01228861532457b929aba75019d0b5e63945a2fdb0232f543c839272`.
- `reports/runtime-actions.jsonl`: thời gian UTC, input, đường dẫn/hash screenshot.
- `runtime/session01-v1.3.3.mp4` và các session tiếp theo: bản ghi ADB; media catalog/checkpoint ghi trạng thái lưu thực tế.
- `static-trees-v2/panels/*.json`: toàn bộ hierarchy/component fields đọc bằng UnityPy 1.25.4.
- `normalized-bundles/normalization-receipts.json`: đường dẫn/hash trước và sau bỏ prefix.
- `full-assetripper/`: export AssetRipper 2.0.0.0; catalog kiểm tra 9.032 file.
- [Google Play chính thức](https://play.google.com/store/apps/details?id=gridplus.busjam.carpuzzle), truy cập 2026-11-16: đối chứng identity và mô tả core loop; không dùng mô tả marketing thay cho quan sát runtime.

## Rủi ro khi dùng export

AssetRipper báo lỗi đọc `BuildSettings` trong `globalgamemanagers` và nhận scripting backend `Unknown`. Shader export đang ở chế độ `Dummy`; một số custom MonoBehaviour YAML bị mất field. Vì vậy không coi project xuất ra là project Unity gốc chạy được. Đối với custom fields trong 25 bundle, dùng typetree UnityPy làm nguồn; đã parse 23.324 tree với 0 lỗi trong phạm vi chọn.

AudioConfig trong base và một số config khác chưa khôi phục field bằng cách đọc hiện tại. Không suy volume, xác suất reward hoặc level count từ file YAML rỗng. Native logic, trạng thái cloud/billing và điều kiện mở một số module vẫn chưa xác minh.
