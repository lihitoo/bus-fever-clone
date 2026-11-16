# Bus Fever — kế hoạch clone toàn bộ game

**Trạng thái: M01 Home/Settings đã gắn vào route thật, đang review visual/feel. Unity MCP hoạt động; Home giữ HomeNavigator, không thêm composition/factory mới. SDK ngoài dùng DreamySDK local test stubs theo user.**

[Quy tắc DreamySDK](11-dreamy-sdk-boundary.md) · [Kết quả và giới hạn M01](evidence/M01/execution.md) · [Smoke 20 lần mở/đóng](evidence/M01/runtime-smoke.json).

Mở [dashboard.html](dashboard.html) trực tiếp để theo dõi. File HTML chứa dữ liệu kế hoạch nên dùng được khi mở bằng `file://`, không cần server, CDN hay tài khoản. [plan.json](plan.json) là nguồn task chuẩn; HTML là snapshot cùng revision. Ghi chú/status trong browser là tự báo cáo, không tự trở thành bằng chứng hoàn thành. Export JSON để giữ lại khi đổi máy; muốn cập nhật tiến độ chính thức phải đối chiếu evidence và cập nhật plan.json rồi tái tạo HTML.

Tái tạo HTML bằng `python docs/clone-plan/tools/render-dashboard.py` từ repo root. Renderer chỉ đọc plan.json và ghi dashboard.html, không reset task/progress hoặc chạm game. Khi thay revision plan, ghi chú cũ cần review/migrate ID trước import; không trộn evidence của revision khác.

Đọc theo thứ tự:

1. [Brief sản phẩm và phạm vi](01-brief.md).
2. [Hiện trạng project, package và khoảng trống](02-packages.md).
3. [Kiến trúc DI/MVP, quyền sở hữu và vòng đời](03-architecture.md).
4. [Code convention và checklist review](04-conventions.md).
5. [Thứ tự triển khai và cơ chế thay UI ngay](05-delivery.md).
6. [Hợp đồng feature chi tiết](feature-specs.md), [toàn bộ task có dependency và acceptance](task-cards.md).
7. [Harness, verification và bằng chứng](06-harness.md).
8. [Asset, dữ liệu, migration và save](07-assets-data.md).
9. [Rủi ro, quyết định và điều kiện phát hành](08-decisions-risks.md).
10. [Senior code, installer từng feature và skill routing](09-senior-implementation.md).
11. [Map từng feature tới UI tree/component/asset và motion/audio nguồn](10-feature-source-map.md).

Nguồn chính: [audit game](../research/audit.md), [coverage](../research/coverage.csv), [mẫu project hiện tại](../../Assets/_Project/Scripts/Bootstrap/GameInstaller.cs), [manifest](../../Packages/manifest.json), [lock](../../Packages/packages-lock.json). Baseline hash nằm trong `evidence/planning-baseline.json`. Không dùng tên API trong tài liệu như bảo đảm tương thích nếu chưa qua kiểm tra consumer ở version đang chọn.

Điểm bắt đầu triển khai sau khi được yêu cầu: **T001**, giữ WIP một feature, hoàn thành artifact + QA + screenshot của feature đó rồi mới chuyển phần tiếp theo. Không bắt đầu từ một backend khổng lồ rồi mới reskin hàng loạt.

## Media trên dashboard

Chọn feature để xem ảnh reference tương ứng và ảnh/video project hiện tại cạnh nhau. Các capture hiện tại chưa có evidence được để trống có nhãn; không thay bằng ảnh game gốc. Có thể chọn file ảnh/video cục bộ để preview phía current; preview chỉ sống trong tab, không ghi file vào repo và không được Export trong progress notes. Để lưu lâu dài, đưa capture vào `media/current/<feature>/` rồi cập nhật `features[].media.currentImages/currentVideos` trong plan.json và chạy renderer. Mỗi entry gồm `src`, `label`; receipts lưu revision/device/viewport/state/hash.

Ba video reference đã copy kèm để mở offline. Đây là recording session tổng của runtime1.3.3, thấp hơn1FPS và không có audio; chưa dùng đo tween/SFX. Library không hứa mỗi feature có trong từng video. XAPK cung cấp ban đầu1.3.2 và runtime audit1.3.3 được ghi rõ trong audit; theo chỉ dẫn user, không tách hai bộ asset khi chưa có sai khác quan sát.

Planning và browser checks: [planning-validation.json](evidence/planning-validation.json), [browser-validation.json](evidence/browser-validation.json). [Checkpoint tiếp tục](checkpoint.md). Unity runtime/build chưa được chạy trong scope planning.

[Rule SDK bắt buộc của repo](../../AGENTS.md) · [SDK facade local](../../Assets/_Project/Integration/DreamySDK/README.md) · [Pause preview](evidence/M01/pause-preview.json) · [Clip current và giới hạn capture](evidence/M01/current-video.json).
