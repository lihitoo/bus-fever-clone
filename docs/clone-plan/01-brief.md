# Brief sản phẩm

## Mục tiêu

Tái tạo toàn bộ trải nghiệm Bus Fever Party trên nền project Dreamy đã import: hình ảnh, UI, luật chơi, nội dung, progression, animation/tween, âm thanh, feedback và những nhánh dịch vụ thực sự có trong nguồn. Clone phải đi được từ launch đến action/result/exit/relaunch; không nghiệm thu một ảnh tĩnh hoặc prefab chưa có chức năng.

Asset dùng chung giữa bản XAPK 1.3.2/build65 và runtime Play 1.3.3/build66 theo chỉ đạo người dùng. Nếu phát hiện khác hành vi, lưu thành quyết định có evidence thay vì tự gộp hai luật. Đích chính là Android portrait; iOS là nhánh tùy chọn cần xác nhận thiết bị/store trước gate phát hành. Editor dùng Unity 6000.4.12f1 theo project hiện tại; không hạ về Unity2022 của nguồn.

## Bốn trụ nghiệm thu

| Trụ | Điều kiện |
| --- | --- |
| Hình ảnh | Đúng asset, font/material, atlas slicing, bố cục, safe area, camera, lớp hiển thị; ảnh đối chiếu cùng state/aspect |
| Hành vi | Entry/input/điều kiện/transaction/kết quả/exit; input lặp, cancel, interruption, persistence |
| Cảm giác | Có curve và sequence, movement, boarding, particle, sound, haptic; runtime timing đo bằng capture đủ chất lượng |
| Kỹ thuật | Owner rõ; dùng package Dreamy trước; DI/MVP; Runtime không Editor; harness và test theo rủi ro; build/device/services có bằng chứng riêng |

## Toàn bộ phạm vi giữ lại

- Launch/splash/loading/retry/returning/fresh; Home và navigation; Profile/edit, Settings cả Home và gameplay; Contact/Restore/Terms/Privacy.
- Gameplay: layout/vehicle bounds/direction/blocking/exit/parking/VIP/passenger loop/matching/boarding/full departure/win/fail/revive/replay/pause.
- Booster VIP, Jumble, Arrange; chỗ đỗ thêm và luồng quảng cáo/coin được nguồn cho phép.
- Victory normal/hard/superhard, coin và reward presentation; difficulty banners, tutorial và các mốc unlock.
- Shop, coin packs, offers, NoAds/AdFreeBundle, restore/loading/pending/cancel/failure; Supplies, Spin, Daily Bonus, life/refill.
- Leaderboard locked/unlocked/rank/reward/reset; Task Bar, Profile, Color Guess và các event được xác minh hiện diện.
- Các họ cơ chế có đầu mối từ nguồn: garage, conveyor/gate queue, turn, elevator, hidden/doubtful, combination, linkage, wrench/gear, ambulance, firetruck, police, luxury/VIP passenger, traffic light và limit count. Tên metadata mới là discovery candidate; không tự sáng tác luật.
- Catalog level đầy đủ, điều kiện vòng lặp và remote content; không thay bằng một tập level tự tạo rồi gọi là clone toàn bộ.

## Persona và phiên chơi

Người mới cần nhận biết hướng xe/màu khách, thao tác một ngón và hiểu booster qua tutorial. Người quay lại cần giữ level/currency/settings/event state; người mất mạng cần hiểu hành động nào phải đợi mạng mà không nhận reward giả. Người thất bại cần hiểu reason và retry/quit/revive nhất quán với chi phí.

## Trạng thái hiểu biết hiện tại

Đã có 77 capture, 73 prefab khảo sát/3.826 node/3.673 component, 1.634 media property bindings, 1.407 sprite và 50 audio. Đây là độ bao phủ tài nguyên, không phải tỷ lệ hoàn thành clone. Gameplay đầu game và các screen Home/Shop/Profile/Supplies/Spin/locked-ranking đã quan sát. Fail/revive, booster level8/13, ranking unlocked29, event/task/daily/life và cơ chế cao chưa đủ evidence. Bốn bundle level AES chưa decode. Capture hiện dưới1FPS chưa cho phép đo timing thực tế.

## Tiêu chí hoàn thành một feature

Feature có spec và source-state IDs; đúng entry route; UI đã thay ngay trong scene/prefab đang chạy; input dẫn đến service thật; static/save/session tách; asset binding có nguồn và GUID đích; đủ error/cancel/re-entry; không tăng tiền hai lần; có clip/ảnh trước-sau, harness/test receipt cùng revision. Phần phụ thuộc backend chưa kiểm chứng phải hiện rõ trong coverage, không đóng gate whole-game.

## Ngân sách và sai số

Mục tiêu ban đầu đề xuất: 60FPS ở thiết bị Android chuẩn được chọn, không mất tap do allocations/rebuild; thiết bị thấp hơn cần profile30FPS riêng nếu được thống nhất. Chưa gán memory/thermal/build-size con số vì chưa có device baseline. Trước visual gate chốt viewport1080×1920 và ít nhất một màn tall/narrow; rect tĩnh đề xuất sai số≤2px ở viewport chuẩn, font/material/sprite đúng identity. Trước feel gate chốt sai số timing từ capture; không tuyên bố≤1frame từ video <1FPS. Các ngưỡng này là đề xuất để hiệu chuẩn ở T003, chưa phải kết quả đo.

## Giới hạn giai đoạn hiện tại

Chỉ kế hoạch, brief, ADR và dashboard. Không đổi .cs/.asmdef/.meta/scene/prefab/manifest, không cài VContainer, không chạy game build trong lượt lập kế hoạch. Không tự loại dịch vụ khó khỏi phạm vi; cũng không dùng credential của game gốc. Không tái tạo kết quả IAP/leaderboard online bằng dữ liệu giả để pass nghiệm thu.
