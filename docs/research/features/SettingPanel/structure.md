# SettingPanel — cấu trúc UI

Bằng chứng: `file-observed`, XAPK 1.3.2/build 65. Chưa tự xác nhận panel này đã được mở khi chơi; xem hồ sơ runtime riêng.

Có 95 MonoBehaviour component; 50 component có liên kết media xuất được. [Bảng chi tiết](ui-elements.csv) chứa hierarchy, path ID, anchor/pivot, font/text, sprite, raycast và toàn bộ serialized fields. Tọa độ là dữ liệu prefab, chưa phải bounding box runtime.

| Hierarchy | Component | Text mặc định | Sprite |
| --- | --- | --- | --- |
| SettingPanel/SafeArea/GameObject/Board_Bg/Bg_Img3/Music_Empty/Music_Text | TMPro.TextMeshProUGUI | Music |  |
| SettingPanel/SafeArea/GameObject/Board_Bg/Bg_Img3/Music_Empty/Music_Btn | UnityEngine.UI.Toggle |  |  |
| SettingPanel/SafeArea/GameObject/Board_Bg/Bg_Img3/Music_Empty/Music_Btn | BusJam.Home.ToggleAnim |  |  |
| SettingPanel/SafeArea/GameObject/Board_Bg/Bg_Img3/Sound_Empty/Sound_Text | TMPro.TextMeshProUGUI | Sound |  |
| SettingPanel/SafeArea/GameObject/Board_Bg/Bg_Img3/Sound_Empty/Sound_Btn | UnityEngine.UI.Toggle |  |  |
| SettingPanel/SafeArea/GameObject/Board_Bg/Bg_Img3/Sound_Empty/Sound_Btn | BusJam.Home.ToggleAnim |  |  |
| SettingPanel/SafeArea/GameObject/Board_Bg/Bg_Img3/Viber_Empty/Viber_Text | TMPro.TextMeshProUGUI | Vibration |  |
| SettingPanel/SafeArea/GameObject/Board_Bg/Bg_Img3/Viber_Empty/Viber_Btn | UnityEngine.UI.Toggle |  |  |
| SettingPanel/SafeArea/GameObject/Board_Bg/Bg_Img3/Viber_Empty/Viber_Btn | BusJam.Home.ToggleAnim |  |  |
| SettingPanel/SafeArea/GameObject/Board_Bg/FixedItems/Settings_Text | TMPro.TextMeshProUGUI | Settings |  |
| SettingPanel/SafeArea/GameObject/Board_Bg/FixedItems/Btn_Close | UnityEngine.UI.Button |  |  |
| SettingPanel/SafeArea/GameObject/Board_Bg/FixedItems/Btn_Close | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| SettingPanel/SafeArea/GameObject/Board_Bg/MidBts_Empty/Contact_Btn | UnityEngine.UI.Button |  |  |
| SettingPanel/SafeArea/GameObject/Board_Bg/MidBts_Empty/Contact_Btn/UP_Empty/Prop_Text | TMPro.TextMeshProUGUI | Contact |  |
| SettingPanel/SafeArea/GameObject/Board_Bg/MidBts_Empty/Restore_Btn | UnityEngine.UI.Button |  |  |
| SettingPanel/SafeArea/GameObject/Board_Bg/MidBts_Empty/Restore_Btn | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| SettingPanel/SafeArea/GameObject/Board_Bg/MidBts_Empty/Restore_Btn/UP_Empty/Prop_Text | TMPro.TextMeshProUGUI | Restore |  |
| SettingPanel/SafeArea/GameObject/Board_Bg/MidBts_Empty/SaveSync_Btn | UnityEngine.UI.Button |  |  |
| SettingPanel/SafeArea/GameObject/Board_Bg/MidBts_Empty/SaveSync_Btn | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| SettingPanel/SafeArea/GameObject/Board_Bg/MidBts_Empty/SaveSync_Btn/UP_Empty/Prop_Text | TMPro.TextMeshProUGUI | Save Progress |  |
| SettingPanel/SafeArea/GameObject/Board_Bg/BottomBtn_Empty/Terms_Btn | UnityEngine.UI.Button |  |  |
| SettingPanel/SafeArea/GameObject/Board_Bg/BottomBtn_Empty/Terms_Btn | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| SettingPanel/SafeArea/GameObject/Board_Bg/BottomBtn_Empty/Terms_Btn/Terms_Text | TMPro.TextMeshProUGUI | Terms of Service |  |
| SettingPanel/SafeArea/GameObject/Board_Bg/BottomBtn_Empty/Privacy_Btn | UnityEngine.UI.Button |  |  |
| SettingPanel/SafeArea/GameObject/Board_Bg/BottomBtn_Empty/Privacy_Btn | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| SettingPanel/SafeArea/GameObject/Board_Bg/BottomBtn_Empty/Privacy_Btn/Privacy_Text | TMPro.TextMeshProUGUI | Privacy Policy |  |
| SettingPanel/SafeArea/GameObject/Board_Bg/BottomBtn_Empty/GDPR_Btn | UnityEngine.UI.Button |  |  |
| SettingPanel/SafeArea/GameObject/Board_Bg/BottomBtn_Empty/GDPR_Btn | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| SettingPanel/SafeArea/GameObject/Board_Bg/BottomBtn_Empty/GDPR_Btn/Privacy_Text | TMPro.TextMeshProUGUI | GDPR |  |
| SettingPanel/SafeArea/GameObject/Board_Bg/Version_Text | TMPro.TextMeshProUGUI | V1.0.1 |  |
