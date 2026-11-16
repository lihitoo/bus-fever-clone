# ReplayPanel — cấu trúc UI

Bằng chứng: `file-observed`, XAPK 1.3.2/build 65. Chưa tự xác nhận panel này đã được mở khi chơi; xem hồ sơ runtime riêng.

Có 37 MonoBehaviour component; 22 component có liên kết media xuất được. [Bảng chi tiết](ui-elements.csv) chứa hierarchy, path ID, anchor/pivot, font/text, sprite, raycast và toàn bộ serialized fields. Tọa độ là dữ liệu prefab, chưa phải bounding box runtime.

| Hierarchy | Component | Text mặc định | Sprite |
| --- | --- | --- | --- |
| ReplayPanel/SafeArea/All_Anim/Btn_Close | UnityEngine.UI.Button |  |  |
| ReplayPanel/SafeArea/All_Anim/Btn_Close | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| ReplayPanel/SafeArea/All_Anim/Replay_Text | TMPro.TextMeshProUGUI | Restart |  |
| ReplayPanel/SafeArea/All_Anim/Replay_Text | TMPro.TextMeshProUGUI | Restart this level? |  |
| ReplayPanel/SafeArea/All_Anim/Btn_Yellow | UnityEngine.UI.Button |  |  |
| ReplayPanel/SafeArea/All_Anim/Btn_Yellow | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| ReplayPanel/SafeArea/All_Anim/Btn_Yellow/UP_Empty/Prop_Text | TMPro.TextMeshProUGUI | No |  |
| ReplayPanel/SafeArea/All_Anim/Btn_Green | UnityEngine.UI.Button |  |  |
| ReplayPanel/SafeArea/All_Anim/Btn_Green | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| ReplayPanel/SafeArea/All_Anim/Btn_Green/UP_Empty/Prop_Text | TMPro.TextMeshProUGUI | Yes |  |
