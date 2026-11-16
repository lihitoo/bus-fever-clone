# Bus Fever Party! — Hồ sơ khảo sát

Mục tiêu của hồ sơ: hỗ trợ dựng lại gameplay, UI, chuyển động, âm thanh và cảm giác tương tác bằng bằng chứng có thể kiểm tra. Đã khảo sát runtime trên LDPlayer, xuất asset và phân tích metadata bằng REA; chưa viết code clone trong công việc audit này.

- **[Bắt đầu tại hồ sơ audit](audit.md)**
- [Checkpoint hiện tại](checkpoint.md)
- [Ví dụ map sprite tới component](asset-map-examples.md)
- [Danh mục hình chụp](captures.md)

- [Kiểm tra ban đầu](source-inspection.md)
- [Quy trình và cấu trúc tài liệu](documentation-plan.md)
- [Mẫu hồ sơ từng feature](feature-template.md)
- [Danh mục nguồn máy đọc được](source-inventory.json)

## Quy ước bằng chứng

| Nhãn | Ý nghĩa |
| --- | --- |
| `file-observed` | Đọc trực tiếp từ file; kèm đường dẫn, hash hoặc object ID |
| `runtime-observed` | Đã thấy khi chơi; kèm video/screenshot và trạng thái |
| `static-inference` | Suy luận từ prefab, cấu hình hoặc code; chưa chứng minh trong runtime |
| `proposed` | Lựa chọn triển khai của bản clone |
| `unknown` | Chưa đủ dữ liệu |

Không đổi `static-inference` thành `runtime-observed` chỉ vì tên bundle/method có vẻ phù hợp. Chỉ ghi feature hoàn tất khi có bằng chứng cho các trạng thái và luồng đã thống nhất.

## Mốc kiểm tra ban đầu (lịch sử)

Ngày khảo sát: 2026-11-16, máy Windows. Repo đích hiện chỉ có README và Git, chưa có Unity project, `toolkit.json`, `Packages/manifest.json` hay `Packages/packages-lock.json`.

Khởi động/cài game, AssetRipper và REA đã được thực hiện sau mốc này. Xem checkpoint hiện tại để tiếp tục; không lặp lại cài app hoặc xóa dữ liệu để quay onboarding.
