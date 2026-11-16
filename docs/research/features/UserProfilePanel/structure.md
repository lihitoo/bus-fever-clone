# UserProfilePanel — cấu trúc UI

Bằng chứng: `file-observed`, XAPK 1.3.2/build 65. Chưa tự xác nhận panel này đã được mở khi chơi; xem hồ sơ runtime riêng.

Có 36 MonoBehaviour component; 16 component có liên kết media xuất được. [Bảng chi tiết](ui-elements.csv) chứa hierarchy, path ID, anchor/pivot, font/text, sprite, raycast và toàn bộ serialized fields. Tọa độ là dữ liệu prefab, chưa phải bounding box runtime.

| Hierarchy | Component | Text mặc định | Sprite |
| --- | --- | --- | --- |
| UserProfilePanel/SafeArea/All_Anim/Title_Text | TMPro.TextMeshProUGUI | Profile |  |
| UserProfilePanel/SafeArea/All_Anim/Btn_Close | UnityEngine.UI.Button |  |  |
| UserProfilePanel/SafeArea/All_Anim/Btn_Close | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| UserProfilePanel/SafeArea/All_Anim/Top_Empty/UsingAvatar_Empty | UnityEngine.UI.Button |  |  |
| UserProfilePanel/SafeArea/All_Anim/Top_Empty/UsingAvatar_Empty | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| UserProfilePanel/SafeArea/All_Anim/Top_Empty/UserName_Text | TMPro.TextMeshProUGUI | Shell Yeah |  |
| UserProfilePanel/SafeArea/All_Anim/Top_Empty/Edit_Btn | UnityEngine.UI.Button |  |  |
| UserProfilePanel/SafeArea/All_Anim/BottomBg_Empty/LevelBg_Img/Level_Text | TMPro.TextMeshProUGUI | Current Level |  |
| UserProfilePanel/SafeArea/All_Anim/BottomBg_Empty/LevelBg_Img/LevelNum_Text | TMPro.TextMeshProUGUI | 45 |  |
| UserProfilePanel/SafeArea/All_Anim/BottomBg_Empty/PassengersBg_Img/Passengers_Text | TMPro.TextMeshProUGUI | Passenger helped |  |
| UserProfilePanel/SafeArea/All_Anim/BottomBg_Empty/PassengersBg_Img/PassengersNum_Text | TMPro.TextMeshProUGUI | 45M |  |
| UserProfilePanel/SafeArea/All_Anim/BottomBg_Empty/GameDaysBg_Img/GameDays_Text | TMPro.TextMeshProUGUI | Game Days |  |
| UserProfilePanel/SafeArea/All_Anim/BottomBg_Empty/GameDaysBg_Img/GameDays_Text | TMPro.TextMeshProUGUI | 234 |  |
