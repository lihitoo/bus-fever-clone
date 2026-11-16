# Btn_Green — cấu trúc UI

Bằng chứng: `file-observed`, XAPK 1.3.2/build 65. Chưa tự xác nhận panel này đã được mở khi chơi; xem hồ sơ runtime riêng.

Có 10 MonoBehaviour component; 7 component có liên kết media xuất được. [Bảng chi tiết](ui-elements.csv) chứa hierarchy, path ID, anchor/pivot, font/text, sprite, raycast và toàn bộ serialized fields. Tọa độ là dữ liệu prefab, chưa phải bounding box runtime.

| Hierarchy | Component | Text mặc định | Sprite |
| --- | --- | --- | --- |
| Btn_Green | UnityEngine.UI.Button |  |  |
| Btn_Green | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| Btn_Green/UP_Empty/Prop_Text | TMPro.TextMeshProUGUI | Free |  |
