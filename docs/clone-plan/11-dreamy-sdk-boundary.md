# DreamySDK — API facade cho toàn bộ SDK bên ngoài

Quyết định trực tiếp của user: SDK bên ngoài sẽ do một Dreamy SDK riêng xử lý; hiện đặt tên tạm `DreamySDK`, có tên hàm và giá trị mặc định để test. Rule bắt buộc nằm trong [AGENTS.md](../../AGENTS.md). Đây là facade local trong project, chưa phải package/API phát hành bởi Dreamy organization.

Dependency: View intent → presenter/service → feature gateway/SDK facade → future Dreamy SDK → vendor SDK. Không gọi SDK vendor, URL hay gửi message trực tiếp trong View. Những service pure game như wallet/progression không chuyển quyền sở hữu sang SDK. Stub không được dùng làm bằng chứng production.

| API đề xuất hiện có | Default local |
| --- | --- |
| OpenContactAsync / OpenTermsAsync / OpenPrivacyAsync | Completed, message có nhãn test stub; không mở ứng dụng bên ngoài |
| RestorePurchasesAsync | Completed, 0 entitlement, “Nothing to restore” có nhãn stub |
| ShowConsentAsync / OpenStoreAsync / RequestReviewAsync | Completed có nhãn test stub, không gọi mạng/vendor |
| PurchaseAsync | Cancelled, không transaction/payment/entitlement |
| ShowRewardedAdAsync | Cancelled, không phát quảng cáo hoặc trao thưởng |

Mọi call có cancellation token. Cần thêm scenario success/pending/error sau này thì thêm fixture/provider tại boundary, không cài đường grant tài nguyên vào button. Không cần user cung cấp support/legal URL để kiểm thử local M01 nữa. Vẫn cần cấu hình thật trong phase tích hợp Dreamy SDK tương lai.

SettingsPanel chỉ gửi ExternalActionRequested và render result; SettingsPanelPresenter quản lý subscription, token, đóng màn và SDK action; package SettingsPresenter vẫn sở hữu music/SFX/haptic state qua SettingsService. Đây là adapter cho action project-specific chưa có trong package contract. Home không thêm composition/factory.

Shop purchase gateway trước đây luôn trả simulated Purchased đã chuyển sang default Cancelled từ DreamySDK; test đã đổi theo quyết định user. Sau này ánh xạ receipt thật/success fixture rõ ràng trước khi commit reward. Không dùng bool “success” chung để xem một API gọi xong là thanh toán hoặc quảng cáo hoàn tất.

Quyết định này thay thế các dòng trong plan cũ coi thiếu provider là blocker cho **local UI acceptance**. Provider/device/store acceptance vẫn là gate riêng; không biến stub thành production-ready.
