# EntryBanner — cấu trúc UI

Bằng chứng: `file-observed`, XAPK 1.3.2/build 65. Chưa tự xác nhận panel này đã được mở khi chơi; xem hồ sơ runtime riêng.

Có 61 MonoBehaviour component; 36 component có liên kết media xuất được. [Bảng chi tiết](ui-elements.csv) chứa hierarchy, path ID, anchor/pivot, font/text, sprite, raycast và toàn bộ serialized fields. Tọa độ là dữ liệu prefab, chưa phải bounding box runtime.

| Hierarchy | Component | Text mặc định | Sprite |
| --- | --- | --- | --- |
| EntryBanner/All_Anim/Blue_Empty/People_Control/Level_Control/Level_Fly/Level_Bg/Number_Text | TMPro.TextMeshProUGUI | 326 |  |
| EntryBanner/All_Anim/Red_Empty/People_Control/Level_Control/Level_Fly/Level_Bg/Number_Text | TMPro.TextMeshProUGUI | 326 |  |
| EntryBanner/All_Anim/Red_Empty/Banner_Control/Hard_Text | TMPro.TextMeshProUGUI | HARD |  |
| EntryBanner/All_Anim/Red_Empty/Banner_Control/Hard_Text/Hard2_Text | TMPro.TextMeshProUGUI | HARD |  |
| EntryBanner/All_Anim/Purple_Empty/People_Control/Level_Control/Level_Fly/Level_Bg/Number_Text | TMPro.TextMeshProUGUI | 326 |  |
| EntryBanner/All_Anim/Purple_Empty/Banner_Control/Hard_Text | TMPro.TextMeshProUGUI | SUPER HARD |  |
| EntryBanner/All_Anim/Purple_Empty/Banner_Control/Hard_Text/Hard2_Text | TMPro.TextMeshProUGUI | SUPER HARD |  |
