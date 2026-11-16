# Ball — cấu trúc UI

Bằng chứng: `file-observed`, XAPK 1.3.2/build 65. Chưa tự xác nhận panel này đã được mở khi chơi; xem hồ sơ runtime riêng.

Có 5 MonoBehaviour component; 1 component có liên kết media xuất được. [Bảng chi tiết](ui-elements.csv) chứa hierarchy, path ID, anchor/pivot, font/text, sprite, raycast và toàn bộ serialized fields. Tọa độ là dữ liệu prefab, chưa phải bounding box runtime.

| Hierarchy | Component | Text mặc định | Sprite |
| --- | --- | --- | --- |
| Ball/Ball_Img/Title_Text_7 | TMPro.TextMeshProUGUI | ×1 |  |
| Ball/Ball_Img/Title_Text_7/Title_Text_3 | TMPro.TextMeshProUGUI | ×1 |  |
