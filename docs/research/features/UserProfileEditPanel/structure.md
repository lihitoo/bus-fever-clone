# UserProfileEditPanel — cấu trúc UI

Bằng chứng: `file-observed`, XAPK 1.3.2/build 65. Chưa tự xác nhận panel này đã được mở khi chơi; xem hồ sơ runtime riêng.

Có 39 MonoBehaviour component; 17 component có liên kết media xuất được. [Bảng chi tiết](ui-elements.csv) chứa hierarchy, path ID, anchor/pivot, font/text, sprite, raycast và toàn bộ serialized fields. Tọa độ là dữ liệu prefab, chưa phải bounding box runtime.

| Hierarchy | Component | Text mặc định | Sprite |
| --- | --- | --- | --- |
| UserProfileEditPanel/SafeArea/All_Anim/Title_Text | TMPro.TextMeshProUGUI | Edit Profile |  |
| UserProfileEditPanel/SafeArea/All_Anim/Btn_Close | UnityEngine.UI.Button |  |  |
| UserProfileEditPanel/SafeArea/All_Anim/Btn_Close | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| UserProfileEditPanel/SafeArea/All_Anim/Top_Empty/InputField (TMP) | TMPro.TMP_InputField |  |  |
| UserProfileEditPanel/SafeArea/All_Anim/Top_Empty/InputField (TMP)/Text Area/Placeholder | TMPro.TextMeshProUGUI | Enter name... |  |
| UserProfileEditPanel/SafeArea/All_Anim/Top_Empty/InputField (TMP)/Text Area/Text | TMPro.TextMeshProUGUI | ​ |  |
| UserProfileEditPanel/SafeArea/All_Anim/Save_Btn | UnityEngine.UI.Button |  |  |
| UserProfileEditPanel/SafeArea/All_Anim/Save_Btn | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| UserProfileEditPanel/SafeArea/All_Anim/Save_Btn/UP_Empty/Prop_Text | TMPro.TextMeshProUGUI | Save |  |
