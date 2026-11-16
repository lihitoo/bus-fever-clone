# Cấu trúc tài liệu và cách khảo sát

## Định dạng

Dùng Markdown làm tài liệu gốc, PNG cho ảnh/crop/contact sheet, MP4 cho chuyển động và WAV/OGG cho âm thanh mẫu. JSON/CSV chứa catalog có ID ổn định để tìm kiếm, đối chiếu và dùng khi triển khai. Có thể xuất thành website tài liệu để xem video/audio thuận tiện; PDF chỉ là bản chụp để chia sẻ.

Markdown liên kết ảnh bằng `![mô tả](media/screens/<capture-id>.png)`. Đường dẫn dưới đây là cấu trúc đề xuất, chưa phải dữ liệu đã thu thập:

```text
docs/research/
  README.md
  source-inspection.md
  source-inventory.json
  coverage.csv
  flows.md
  features/
    <feature-id>/
      spec.md
      ui-elements.csv
      motion.json
      audio.csv
      acceptance.md
  catalogs/
    assets.jsonl
    bindings.csv
    levels.jsonl
    evidence.jsonl
  media/
    screens/
    annotated/
    clips/
    audio/
    contact-sheets/
```

File game, raw export, binary và video lớn nên nằm trong workspace nghiên cứu riêng ngoài Unity project. Ghi đường dẫn/hash trong catalog; quản lý bản sao media cần chia sẻ theo dung lượng và chính sách Git/LFS đã chọn.

## Ba hướng bổ sung cho nhau

1. **Chơi và quan sát:** điều khiển bằng ADB hoặc công cụ điều khiển Android, chụp màn hình, ghi video và thao tác. Unity UI thường được render trong một surface nên Android UI hierarchy không đủ để đọc toàn bộ nút/text. Kiểm tra khả năng capture trước khi chọn pipeline.
2. **AssetRipper:** xuất thử một số texture/sprite, prefab, material, animation và audio nếu có; xem trực tiếp kết quả và dependencies trước khi export lớn. Atlas có thể cần sprite rect, pivot, border 9-slice; raw texture không đủ mô tả một phần tử UI.
3. **REA:** trả lời các câu hỏi cụ thể còn thiếu, ví dụ điều kiện thắng, thứ tự xử lý input, công thức phần thưởng hoặc tham số chuyển động. Metadata/method name không tự khôi phục đầy đủ logic. Kiểm tra provider có hỗ trợ native ARM64 và cặp metadata/binary này hay không.

LDPlayer phù hợp để khảo sát nếu chạy được split ARM64 này. Một máy Android ARM64 thật là phương án đối chứng hữu ích cho frame pacing, âm thanh và rung. scrcpy hỗ trợ điều khiển và ghi hình; capture âm thanh cần Android 11 trở lên. Không coi FPS/timing của giả lập là giá trị gốc nếu chưa kiểm tra tải máy và bản ghi.

## Thứ tự khảo sát

1. Ghi identity, hash, độ phân giải, DPI, Android, ABI, locale, trạng thái save và network. Giữ profile hiện có; onboarding cần profile riêng nếu đã chơi.
2. Cài đủ base và split sau khi kiểm tra bản đang cài. Ghi first launch, tutorial và một vòng gameplay đầy đủ có thể tiếp cận được.
3. Vẽ graph screen/state từ quan sát: entry, điều kiện mở, thao tác, kết quả, back/close, interruption và persistence. Theo dõi phần chưa mở khóa, phụ thuộc mạng hoặc sự kiện thời gian.
4. Với mỗi feature, thu trạng thái mặc định, pressed/disabled, loading, success, failure, empty và các trạng thái khác thực sự tồn tại. Chỉ ghi “không áp dụng” sau khi kiểm tra.
5. Xuất asset vào thư mục mới ngoài nguồn và đích; lập contact sheet và catalog source object/dependency. Xác minh prefab references cùng màn hình runtime để map asset.
6. Dùng REA cho các câu hỏi còn chưa rõ. Lưu tool/provider version, evidence ID, input hash và giới hạn từng kết quả.
7. Đo motion/audio theo clip, ghi sai số. Dựng bản clone sau khi đã có hồ sơ đủ rõ cho phần tương ứng.
8. So sánh original/clone ở cùng trạng thái, độ phân giải và input sequence; dùng ảnh overlay/diff, timeline và nghe đối chiếu. Theo dõi các sai khác còn lại.

## Các trường phải có

| Mảng | Dữ liệu cần ghi |
| --- | --- |
| Flow/gameplay | Tiền điều kiện, input hợp lệ/không hợp lệ, luật, trình tự, khóa input, win/lose, retry/exit, save/resume |
| UI | Screen/state ID, ảnh có đánh số, element ID, hierarchy, rect chuẩn hóa và pixel, anchors/pivot nếu khôi phục được, safe area, font/material, size/color, sorting, hit target, binding |
| Motion | Trigger, target/property, from/to, duration/delay, easing hoặc đường cong đo, sequence/parallel, loop, overshoot, interrupt/cancel, evidence timestamp và sai số |
| Polish | Anticipation, squash/stretch, bounce, particles, trails, camera shake, flash, haptic; thứ tự và đồng bộ với gameplay/audio |
| Audio | Trigger, clip/object ID, thời điểm bắt đầu, gain/pitch, loop, fade, overlap, concurrency, cooldown, music ducking nếu quan sát được |
| Level/config | Level ID, layout, thứ tự/chướng ngại/ràng buộc, random seed nếu xác định được, điều kiện thắng/thua, unlock, nguồn dữ liệu |
| Acceptance | Chuỗi thao tác tái hiện, kết quả kỳ vọng, capture đối chứng, sai số chấp nhận và phần chưa kiểm chứng |

Không gán tên easing như `OutBack` chỉ bằng cảm giác. Nếu không lấy được tham số gốc, ghi đường cong fit và độ tin cậy. Video 60 FPS chỉ có độ phân giải thời gian khoảng 16.7 ms/frame trước các sai số capture khác.

## Liên kết asset

```text
artifact SHA-256
  → bundle / serialized file + pathID + type
  → exported file + hash + dependencies
  → prefab hierarchy / component / property
  → feature / screen / state / UI element
  → runtime capture + timestamp
  → clone asset path + Unity GUID + component
```

Chỉ tên file hoặc ảnh nhìn giống nhau tạo ra candidate mapping. Binding được xác nhận cần reference trong prefab/code hoặc bằng chứng runtime tương ứng; ghi cách xác nhận. Asset động, remote và service chưa tiếp cận được phải giữ trạng thái chưa biết.

## Tiêu chí bao phủ

`coverage.csv` theo dõi từng feature/state với các cột: `feature_id,state_id,discovered,captured,asset_mapped,logic_explained,motion_measured,audio_mapped,implemented,verified,evidence_ids,gaps,next_action`.

Không dùng một tỷ lệ “giống 100%” chung khi chưa có mẫu số là danh sách feature/state/level và các phép so sánh. Ghi riêng mức bao phủ nội dung, độ giống hình ảnh, hành vi, timing và các tích hợp dịch vụ.
