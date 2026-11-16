# Audio và SFX

Đã xuất 50 AudioClip thành file nghe được trong `media/audio/`, tổng khoảng 9.5 MB. [Catalog audio](catalogs/audio-files.json) chứa đường dẫn, hash, collection, path ID và duration. [Thông số clip gốc](catalogs/audio-clips.json) có frequency/channels/compression; 50 không đồng nghĩa 50 trigger.

## Các nhóm được nhận diện

REA có `BusJam.AudioName` với tên cue: `bgm_gameplay`, `button_click`, `coin_collect`, `bus_moving`, `bus_hit`, `passenger_up`, `passenger_entry`, `level_switch`, `bus_full`, `level_win`, `level_fail`, banner normal/hard/superhard, police siren, firetruck, garage, ambulance, các prop, rank/medal, scene switch, gear và elevator.

Tên clip trong bundle có biến thể như `prop_collect V1.1`, `ambulance_countdown_V2`, `hidden_reveal`; không ép một cue về file cùng tên nếu chưa đọc AudioConfig hoặc thấy callback tương ứng.

## Những gì đã và chưa xác minh

| Hạng mục | Trạng thái |
| --- | --- |
| Byte media, source object, duration, xuất sample | Đã xuất; receipt integrity pass |
| Music/Sound có toggle riêng trong Settings | Đã thấy UI; Music OFF giữ qua nhiều level, sau đó bật lại |
| Gain/pitch, random variant, concurrent limit, ducking | Chưa biết |
| AudioConfig base fields | Chưa đọc được bằng parser hiện tại |
| Trigger runtime của từng clip | Chưa map hoàn chỉnh |
| Nghe đối chiếu, đo audio/video sync | Chưa thực hiện |
| Haptic thật | Chưa thực hiện; LDPlayer không đại diện rung trên điện thoại |

Không suy volume bằng waveform của file clip: runtime mixer và volume config có thể đổi mức phát. Các video ADB của phiên này không có audio vì thiết bị chạy Android 9; muốn đo sync cần capture âm thanh hệ thống Windows hoặc Android thật có audio capture phù hợp.
