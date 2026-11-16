# Motion, tween và polish

## Nguồn dữ liệu

[Animation bundle catalog](catalogs/animation-clips.json) giữ identity/source path ID. [Exported timings](catalogs/exported-animation-timings.json) đọc start/stop/loop và target từ `.anim` AssetRipper; catalog UnityPy có một số start/stop null vì player serialization không chứa cùng trường authoring. Không thay null bằng số đoán.

Các con số sau đọc trực tiếp từ `BusJamConfig` và `ItemPropConfigArrange` trong XAPK. Đó là cấu hình gốc được serialize, chưa phải kết quả đo runtime hoặc bảo đảm mọi path sử dụng chúng.

| Trường | Giá trị xấp xỉ | Ý nghĩa từ tên/cấu trúc |
| --- | --- | --- |
| `ClickVehicleDisableInputSeconds` | 0.03 s | Khoảng khóa input sau click xe; cần trace native để xác nhận path |
| `turnVehicleRotateDuration` | 0.25 s | Cấu hình thời gian xoay xe turn |
| `gateQueuePathShrinkDuration` | 0.25 s | Thu tuyến gate queue |
| `passengerGroupAboardInterval` | 0.04 s | Khoảng giữa nhóm lên xe |
| `passengerAboardInterval` | 0.03 s | Khoảng giữa khách lên xe |
| `passengerGroupAboardSpeed` | 3.8 | Đơn vị tốc độ trong game, chưa quy pixel/s |
| `passengerAniDelay` | 0.3 s | Delay animation khách |
| `passengerSmokeEffectReturnDelay` | 2.5 s | Delay trả effect khói |
| `garageOutDelay` / `garageBlockDelay` | 0.1 / 0.1 s | Hai delay garage |
| `carJamJudgeDelay` | 2.5 s | Delay kiểm tra jam; chưa suy điều kiện fail |
| `emojiDuration` | 4–6 s | Khoảng cấu hình emoji; chưa suy phân phối random |
| `emojiMaxShowCount` | 1 | Giới hạn cấu hình emoji |
| Arrange `boardingInterval` | 0.1 s | Nhịp hiệu ứng Arrange |
| Arrange `spiralRadius` | 0.2 | Bán kính xoắn |
| Arrange `spiralSpeed` / `spiralXSpeed` | 5 / 540 | Tham số xoắn; đơn vị/áp dụng cần trace |

Các curve được giữ cả time/value/inSlope/outSlope/weight trong [gameplay-configs](catalogs/gameplay-configs.json). Ví dụ curve xoay turn có hai key 0→1, slope hai đầu bằng 0; không gán tên easing cụ thể nếu chưa xác nhận cách lấy mẫu.

## Clip mẫu đọc được từ export

| Clip | Độ dài serialized |
| --- | --- |
| `Effect_GamePanel_In` | 0.25 s |
| `Effect_HomePanel_In` | 0.25 s |
| `Effect_VictoryPanel_In` | 2.8 s |
| `Bus_PassengerIn` | khoảng 0.133333 s |

Animator speed, transition blend, layer, event và code tween có thể làm thời gian nhìn thấy khác độ dài clip. Export chứa clip trùng tên thuộc source object khác nhau, vì vậy phải map path ID thay vì chỉ tìm tên.

## Polish đã thấy khi chơi

- Tutorial: spotlight, viền vàng, bàn tay, card hướng dẫn và đổi mục tiêu.
- Xe: bóng mềm, mũi tên trắng viền tối, đi cong vào ô; trail khói và dấu click sáng.
- Boarding: khách rời vòng thành nhánh; số đếm và màu label đồng bộ màu xe.
- Completion xe: puff khói trắng và confetti nhỏ cạnh ô.
- Passenger loop: có emoji phản ứng phía trên nhóm; đã thấy các biểu cảm lo lắng/khó chịu. Chưa suy luật trigger từ ảnh.
- Panel: dark scrim, khung vàng bo tròn, inset kem, button có highlight, viền và bóng tạo độ nổi.
- Chuyển cảnh: trời xanh/mây/máy bay, giữ thành feature riêng.
- Victory: nhân vật Spine, chữ lớn, fireworks và coin.

## Chưa đo được

Chưa có bảng mốc frame đã kiểm chứng cho từng input→effect; chưa đo chính xác gain/audio sync, rung, shake, velocity/acceleration xe hoặc cancel/interruption của mọi tween. Ba video đã decode thành công nhưng stream báo average khoảng 0.76–0.88 FPS, không đủ để đo tween theo mili giây; cần sửa pipeline capture hoặc đo trên thiết bị khác. Bản ghi ADB trên Android 9 không có âm thanh. Không ghi một con số “feel giống %” khi chưa có bản clone để đối chiếu.
