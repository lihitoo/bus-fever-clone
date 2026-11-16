# Thứ tự làm và cơ chế thấy thay đổi ngay

## Nguyên tắc thay màn

Mỗi feature triển khai là một lát cắt từ route thật đến kết quả thật: asset đã chọn→prefab/variant→view→presenter→service/config/save→motion/audio→QA. Khi route của màn đó hoàn thành, đổi address/factory binding để mở màn mới ngay trong gameplay/Home bình thường. Giữ màn gốc/demo ở vùng sample/dev khi cần reference, không để CTA chính mở nhầm demo.

Không để tất cả UI cuối dự án mới reskin. Không paste screenshot làm background thay UI. Feature tương lai chưa xong phải hiện trạng thái chưa khả dụng minh bạch trong build phát triển, không tạo button giả thành công. UI-only preview hữu ích để review art nhưng không vượt gate feature verification.

## Milestones đề xuất

| Milestone | Sau khi làm sẽ thấy | Điều kiện trước khi chuyển |
| --- | --- | --- |
| M00 Baseline/compatibility/DI | Chưa đổi visual; bootstrap smoke và graph rõ | T001–T004, owner/test baseline, blocker ledger |
| M01 Home + Settings | Home thành phố/bus/queue đúng art, tab/nav; settings Home/Pause skin | Normal launch mở Home mới; không dependency duplicate; toggle persistence |
| M02 Gameplay chuẩn | Bãi Level1 thật, xe đúng mesh/material/camera, tap→thoát→parking→boarding | Source rule evidence tối thiểu, 1 complete playable route |
| M03 Tutorial + Victory | Hand/spotlight/lock đúng mục tiêu, reward/counter/confetti/Next | Tutorial interruption, reward exactly once, Next đúng progression |
| M04 Fail/parking/VIP | Thấy lý do thua/revive, extra spot, xe bay VIP | Normal fail/retry, ad cancel/no-fill và resource cost |
| M05 Shop/Profile/Supplies/Spin | Các màn thay ngay lần lượt theo feature, không chờ xong hết | Mỗi màn pass riêng, production provider chưa có giữ blocked |
| M06 Daily/Life/Jumble/Arrange | Timer/progression/unlock và booster còn lại | Runtime rule đã khảo sát, ngày/clock/relaunch/recovery |
| M07 Advanced mechanics/content | Mỗi họ cơ chế xuất hiện cùng level fixture đúng nguồn | Rule/visual/input/exit/cancel của từng họ, không bỏ âm thầm |
| M08 Ranking/TaskBar/ColorGuess | Locked/unlocked và event screens đúng entry | Backend/cycle/error/claim conditions thật hoặc gate blocked rõ |
| M09 Localization/Audio/Polish | Locale/fonts/fallback đúng; cues/tween/haptic đồng nhất toàn game | Matched captures, clip/audio đủ chất lượng và interruption cleanup |
| M10 Whole-game parity/device | Flow đầy đủ, aspect/performance/migration | Coverage không còn unknown bắt buộc, production services/build evidence |

Task list và dependency chính xác nằm trong plan.json/task-cards.md; bảng trên là view sản phẩm. Discovery blockers có thể giữ feature blocked trong khi chuẩn bị feature độc lập, nhưng execution WIP=1. Không reorder tùy tiện gây mất progression hoặc đụng wallet/presenter owner.

## Review sau mỗi màn

Chụp source và clone cùng viewport, level/save/locale/state; lưu trước khi thay và sau khi wire xong. Review không chỉ ảnh default: pressed/disabled/loading/empty/error/success, show/hide/back, 20 reopen, pause/resume, multi tap. Clip ngắn 10–30s cho action→effect→exit; âm thanh phải nghe được trước feel gate. Ghi sai khác position/font/sprite/sort/curve/sound bằng ID và sửa ngay trong milestone đó.

## Kế hoạch lặp có checkpoint

Trước task: kiểm tra baseline revision, source evidence và package hashes; ghi các path định chạm. Trong task: không sửa package và game ở cùng một diff nếu không thật sự cần; nếu cần package extension, consumer fixture trước. Kết thúc: artifacts tồn tại, validation receipt và failed checks được giữ; status review cho tới khi mọi gate bắt buộc pass. Nếu bị ngắt, resume theo nextAction và hash, không export đè hoặc chạy lại tác vụ không rõ trạng thái.

## Dự kiến effort

Không gán ngày hoàn thành khi source level AES, provider SDK, device capture và late-game rules còn thiếu. Dùng effort points1/2/3/5 cho kích thước tương đối; dashboard tính theo số task/weight, không coi points là giờ/ngày. Sau hai feature đầu đo throughput thực rồi mới lập calendar. Blocker chờ người dùng/provider không cộng thành công vào progress.
