# TaskBarGuidePanel — cấu trúc UI

Bằng chứng: `file-observed`, XAPK 1.3.2/build 65. Chưa tự xác nhận panel này đã được mở khi chơi; xem hồ sơ runtime riêng.

Có 23 MonoBehaviour component; 7 component có liên kết media xuất được. [Bảng chi tiết](ui-elements.csv) chứa hierarchy, path ID, anchor/pivot, font/text, sprite, raycast và toàn bộ serialized fields. Tọa độ là dữ liệu prefab, chưa phải bounding box runtime.

| Hierarchy | Component | Text mặc định | Sprite |
| --- | --- | --- | --- |
| TaskBarGuidePanel/All_Anim/Image | UnityEngine.UI.Button |  |  |
| TaskBarGuidePanel/All_Anim/Image | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| TaskBarGuidePanel/All_Anim/Middle_Empty/Pic1_Empty/Intro_Text | TMPro.TextMeshProUGUI | Beat Levels! |  |
| TaskBarGuidePanel/All_Anim/Middle_Empty/Pic2_Empty/Intro_Text | TMPro.TextMeshProUGUI | Collect Passengers! |  |
| TaskBarGuidePanel/All_Anim/Middle_Empty/Pic3_Empty/Intro_Text | TMPro.TextMeshProUGUI | Win Rewards! |  |
| TaskBarGuidePanel/All_Anim/Tap_Text | TMPro.TextMeshProUGUI | Tap to Continue |  |
