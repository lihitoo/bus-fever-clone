# Kiểm tra nguồn ban đầu

Đây là snapshot trước khi chạy audit. Trạng thái công cụ và runtime hiện tại xem tại [audit](audit.md) và [checkpoint](checkpoint.md).

## Nguồn và phạm vi

- File: `D:\Downloads\Bus+Fever+Party!_1.3.2_APKPure.xapk`
- Kích thước: 243160913 byte.
- SHA-256: `e8288abeccd9047ac19a0ee26723110b4e768be33582c7d34af128f1fc519ad7`.
- Tên trong manifest XAPK: Bus Fever Party!
- Package: `gridplus.busjam.carpuzzle`.
- Version: `1.3.2`; version code: `65`.
- Manifest XAPK khai báo min SDK 26, target SDK 36. Chưa giải mã AndroidManifest bên trong APK để đối chiếu.
- Phạm vi lượt này: kiểm tra khả thi, xác định nguồn và thiết kế hồ sơ khảo sát. Chưa triển khai clone.

## Cấu trúc đã đọc trực tiếp

| Thành phần | Nội dung |
| --- | --- |
| `gridplus.busjam.carpuzzle.apk` | 209089559 byte; 2960 ZIP entries |
| `config.arm64_v8a.apk` | 33999510 byte; 34 ZIP entries |
| APK chính | `assets/bin/Data/Managed/Metadata/global-metadata.dat` |
| APK chính | `assets/bin/Data/globalgamemanagers`, assets chia `.split0`–`.split2` |
| Split ARM64 | `lib/arm64-v8a/libil2cpp.so`, `lib/arm64-v8a/libunity.so` |

Cấu trúc này xác nhận Unity IL2CPP. Chưa xác định phiên bản Unity. Khi phân tích phải giữ metadata và native binary đúng cùng bản này, cùng các phần assets bị chia nhỏ.

Trong `assets/Sandbox/` có manifest bundle và các bundle mang tên `home`, `game_ui`, `game_prefabs`, `game_config`, `globalconfig`, `excels`, `bus_and_passenger`, `sound`, `effects`, `guide`, `dailybonus`, `spin`, `ranking`, `life`, `inventory`, `supplies`, `task_bar`, `color_guess`, `level_escape_*` cùng các bundle khác. Tên chỉ là ứng viên để khảo sát, không xác nhận feature đang bật hoặc nội dung đầy đủ.

## Công cụ trên máy

| Track | Trạng thái kiểm tra |
| --- | --- |
| LDPlayer | Có `D:\LDPlayer\LDPlayer9\ldconsole.exe`; `list2` trả một instance index 0, chưa chạy |
| ADB | Gọi được; `adb devices -l` chưa thấy thiết bị; lệnh đã khởi động ADB server |
| REA | Có source tại `D:\Tools\rea`, package.json ghi 6.8.0; Git commit `1173c0a9dc1b352a60943a491462294db8f353ae` |
| REA thực thi | Chưa kiểm tra CLI, dependencies, MCP, native provider; chưa có kết quả REA cho game |
| AssetRipper | Chưa tìm thấy trong các vị trí kiểm tra; chưa tìm toàn bộ ổ đĩa; chưa chạy export |
| scrcpy / capture audio | Chưa xác minh cài đặt và tương thích thiết bị |
| Unity đích | Chưa có cấu trúc Unity project trong repo hiện tại |

REA và AssetRipper được giữ thành hai track bắt buộc trong quy trình đề xuất vì người dùng yêu cầu kết hợp cả hai; trạng thái hiện tại đều chưa có kết quả phân tích/xuất cho game này.

## Giới hạn

Chưa cài hoặc mở game, chụp UI, đo tween, nghe âm thanh, xác định level hay xác minh các tính năng có điều kiện mở khóa. Không có bằng chứng để tuyên bố đã map UI/asset hoặc clone giống hoàn toàn.

## Nguồn công cụ

- [AssetRipper chính thức](https://github.com/AssetRipper/AssetRipper): công cụ phân tích và chuyển đổi tài nguyên Unity.
- [REA chính thức](https://github.com/morluto/rea): tham chiếu khả năng phân tích; readiness phải kiểm tra theo bản cài thực tế.
- [scrcpy](https://github.com/Genymobile/scrcpy), [audio](https://github.com/Genymobile/scrcpy/blob/master/doc/audio.md), [recording](https://github.com/Genymobile/scrcpy/blob/master/doc/recording.md): điều khiển/ghi hình Android; audio forwarding cần Android 11+, phải thử thực tế trên thiết bị.
