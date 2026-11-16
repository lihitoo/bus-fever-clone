# Checkpoint audit — 2026-11-16

## Scope giữ nguyên

Audit kỹ game gốc và viết tài liệu có hình ảnh, UI/component/asset mapping, flow, motion và audio. Chưa triển khai gameplay/UI clone trong công việc này. Không ghi sửa vào `Assets`, `Packages` hay `ProjectSettings` trong audit. Trong lúc làm việc, repo đã xuất hiện template Unity và thay đổi được stage từ hoạt động khác; giữ nguyên các thay đổi đó, không reset/stage/commit thay người dùng.

## Nguồn và công cụ

- XAPK 1.3.2/build 65: SHA-256 `e8288abeccd9047ac19a0ee26723110b4e768be33582c7d34af128f1fc519ad7`.
- Runtime: Google Play 1.3.3/build 66, LDPlayer 9.5.32.0, Android 9; ABI khai báo có arm64 qua translation, viewport logic portrait 1080×1920, physical display 1920×1080, density 280.
- Người dùng yêu cầu dùng chung asset giữa hai bản; version vẫn giữ trong provenance.
- REA npm 6.8.0, Node 24.22.1 trong cache tool đã có; local REA source commit `1173c0a9dc1b352a60943a491462294db8f353ae`. Không đăng ký MCP hoặc đổi config REA.
- AssetRipper 2.0.0.0 có sẵn tại `D:\Game\BlockOutExtraction\1264\tools\AssetRipper-2.0.0`.
- UnityPy 1.25.4 và imageio-ffmpeg được cài trong venv riêng `D:\GameAudit\bus-fever-1.3.2\tools\pyenv`.

## Kết quả theo track

| Track | Trạng thái | Evidence / giới hạn |
| --- | --- | --- |
| Intake | pass | Nguồn, hash, split, engine/version được ghi |
| Unpack | pass | 4 file XAPK, 802 file assets từ base, 29 file lib từ split; receipt pass |
| FileOffset normalization | pass trong phạm vi | 25 bản sao bỏ 12 byte zero; hash nguồn/bản sao có receipt |
| AssetRipper | partial | Có project export và catalog 9.032 file; BuildSettings parse error, backend Unknown, shader Dummy và custom fields thiếu |
| Sprite/audio export | pass trong phạm vi | 1.407 sprite, 50 audio; 1.457 output receipt pass |
| Media decode | pass cho audio | 50 audio decode bằng FFmpeg, 0 lỗi; sprite receipt không thay thế kiểm tra visual từng ảnh |
| Static UI | pass trong phạm vi | 73 prefab/3.826 node/3.673 MonoBehaviour, 1.634 media property bindings; chưa phải full runtime coverage |
| REA metadata | pass trong phạm vi | Metadata v31, 164 image/15.604 type/97.257 method; 85.732 code slot, 11.525 no-body; không decompile logic native |
| Level data AES | blocked | 4 bundle được manifest khai báo AES, chưa đọc layout/config bên trong |
| Runtime survey | partial | Gameplay đầu game; VIP; Extra Spot entry; Home, Profile, edit, Home Settings/Restore, Shop, Leaderboard locked, Supplies claim, Spin info |
| Tween timing | partial | Có curve/clip/config; ADB capture dưới 1 FPS, Windows window capture trả vùng render đen; chưa đo timeline runtime tin cậy |
| Audio trigger/sync/haptic | partial | Media đã xuất; chưa nghe đối chiếu/mix/trigger đầy đủ hoặc rung thật |
| Unity import/compile/build/parity | not-applicable cho scope này | Người dùng yêu cầu chưa code |

## State và thao tác cần lưu ý

- ADB local đã bật ở instance LDPlayer index 0 qua `basicSettings.adbDebug=1`; backup config trước thay đổi nằm ngoài repo tại `reports/ldplayer-config-before-adb.json`. Không tắt ADB/đóng giả lập khi người dùng còn dùng.
- Lần đầu XAPK bị LicenseActivity chuyển sang Google Play. Người dùng đã xử lý Google Play; runtime chơi được là 1.3.3. Không downgrade hoặc cài lại XAPK để tiếp tục.
- Đã đổi Music OFF để thử persistence, sau đó bật lại ON.
- VIP tutorial đã dùng; không chắc lượng grant nếu chỉ nhìn một badge. Supplies đã claim +15, không phải trạng thái fresh còn free reward.
- Đã nhấn Restore, trả Nothing to restore. Không mua IAP, không gửi email Contact, không đổi profile.
- Có đoạn progression giữa Level 4–6 không được log/capture liên tục; không quy toàn bộ tiến trình đó cho chuỗi input agent.
- AssetRipper PID lúc khởi chạy là 71848; khi kiểm tra cuối không còn process đó. Không còn export chờ. Các bản ghi ADB 01/02/03 đã kéo về disk và decode kiểm tra; không xóa chúng.

## Chỗ lưu và cách tiếp tục

Tài liệu, hình, audio sample, CSV/JSON index: `docs/research/`. Raw/unpacked/export/tool scripts/Evidence/video: `D:\GameAudit\bus-fever-1.3.2`. Không rerun exporter vào output đã tồn tại. Tên capture là mục đích lúc đặt tên, không phải kết luận về state thực tế; ảnh và log là nguồn xác nhận.

Ưu tiên tiếp theo:

1. Sửa capture để có frame đều và audio đồng bộ trước khi ghi số đo tween runtime. Giữ clip/config hiện tại làm dữ liệu tham chiếu.
2. Tạo fail/revive bằng luật bình thường; ghi lại reason, retry, quit/Home và mất life. Hiện mới có toast No spots available, không coi đó là fail.
3. Chơi tới Level 8/13 để xác nhận hai booster còn lại; tiếp tục tới 29 cho ranking thật. Không dùng state inject để chứng minh luồng unlock.
4. Khảo sát Task Bar, Daily Bonus, Color Guess, life, hard/superhard và các cơ chế xe nâng cao khi entry xuất hiện. Hình/bundle tồn tại không đủ chứng minh đang active.
5. Điều tra 4 bundle AES và native logic theo từng câu hỏi cụ thể. Giữ track REA/AssetRipper riêng; không gọi dummy C# là source gameplay gốc.
6. Hoàn thiện screenshot bounding boxes/runtime visibility và callback binding cho từng state; bảng prefab hiện đã giữ anchor/pivot/font/sprite và source IDs.

Không có code clone cần compile/test trong audit này. Kết quả validation tài liệu/media được lưu tại `catalogs/validation.json` sau khi chạy kiểm tra.
