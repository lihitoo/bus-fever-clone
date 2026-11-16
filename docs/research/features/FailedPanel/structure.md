# FailedPanel — cấu trúc UI

Bằng chứng: `file-observed`, XAPK 1.3.2/build 65. Chưa tự xác nhận panel này đã được mở khi chơi; xem hồ sơ runtime riêng.

Có 23 MonoBehaviour component; 10 component có liên kết media xuất được. [Bảng chi tiết](ui-elements.csv) chứa hierarchy, path ID, anchor/pivot, font/text, sprite, raycast và toàn bộ serialized fields. Tọa độ là dữ liệu prefab, chưa phải bounding box runtime.

| Hierarchy | Component | Text mặc định | Sprite |
| --- | --- | --- | --- |
| FailedPanel/SafeArea/Top_Empty/Title_Text | TMPro.TextMeshProUGUI | Failed! |  |
| FailedPanel/SafeArea/Top_Empty/Title_Text/Title_Text_1 | TMPro.TextMeshProUGUI | Failed! |  |
| FailedPanel/SafeArea/Mid_Empty/Mid_Text | TMPro.TextMeshProUGUI | Purchase failed! |  |
| FailedPanel/SafeArea/Bottom_Empty/Btn_Green | UnityEngine.UI.Button |  |  |
| FailedPanel/SafeArea/Bottom_Empty/Btn_Green | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| FailedPanel/SafeArea/Bottom_Empty/Btn_Green/UP_Empty/Prop_Text | TMPro.TextMeshProUGUI | Continue |  |
