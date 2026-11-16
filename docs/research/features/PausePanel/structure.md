# PausePanel — cấu trúc UI

Bằng chứng: `file-observed`, XAPK 1.3.2/build 65. Chưa tự xác nhận panel này đã được mở khi chơi; xem hồ sơ runtime riêng.

Có 74 MonoBehaviour component; 46 component có liên kết media xuất được. [Bảng chi tiết](ui-elements.csv) chứa hierarchy, path ID, anchor/pivot, font/text, sprite, raycast và toàn bộ serialized fields. Tọa độ là dữ liệu prefab, chưa phải bounding box runtime.

| Hierarchy | Component | Text mặc định | Sprite |
| --- | --- | --- | --- |
| PausePanel/SafeArea/All_Anim/Btn_Close | UnityEngine.UI.Button |  |  |
| PausePanel/SafeArea/All_Anim/Btn_Close | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| PausePanel/SafeArea/All_Anim/Settings_Text_1 | TMPro.TextMeshProUGUI | Settings |  |
| PausePanel/SafeArea/All_Anim/Music_Empty/Music_Text | TMPro.TextMeshProUGUI | Music |  |
| PausePanel/SafeArea/All_Anim/Music_Empty/Music_Btn | UnityEngine.UI.Toggle |  |  |
| PausePanel/SafeArea/All_Anim/Music_Empty/Music_Btn | BusJam.Home.ToggleAnim |  |  |
| PausePanel/SafeArea/All_Anim/Sound_Empty/Sound_Text | TMPro.TextMeshProUGUI | Sound |  |
| PausePanel/SafeArea/All_Anim/Sound_Empty/Sound_Btn | UnityEngine.UI.Toggle |  |  |
| PausePanel/SafeArea/All_Anim/Sound_Empty/Sound_Btn | BusJam.Home.ToggleAnim |  |  |
| PausePanel/SafeArea/All_Anim/Viber_Empty/Viber_Text | TMPro.TextMeshProUGUI | Vibration |  |
| PausePanel/SafeArea/All_Anim/Viber_Empty/Viber_Btn | UnityEngine.UI.Toggle |  |  |
| PausePanel/SafeArea/All_Anim/Viber_Empty/Viber_Btn | BusJam.Home.ToggleAnim |  |  |
| PausePanel/SafeArea/All_Anim/Btn_Yellow | UnityEngine.UI.Button |  |  |
| PausePanel/SafeArea/All_Anim/Btn_Yellow | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| PausePanel/SafeArea/All_Anim/Btn_Yellow/UP_Empty/Prop_Text | TMPro.TextMeshProUGUI | Home |  |
| PausePanel/SafeArea/All_Anim/Btn_Green | UnityEngine.UI.Button |  |  |
| PausePanel/SafeArea/All_Anim/Btn_Green | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| PausePanel/SafeArea/All_Anim/Btn_Green/UP_Empty/Prop_Text | TMPro.TextMeshProUGUI | Restart |  |
| PausePanel/SafeArea/All_Anim/Btn_Green_1 | UnityEngine.UI.Button |  |  |
| PausePanel/SafeArea/All_Anim/Btn_Green_1 | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| PausePanel/SafeArea/All_Anim/Btn_Green_1/UP_Empty/Prop_Text | TMPro.TextMeshProUGUI | Restart |  |
