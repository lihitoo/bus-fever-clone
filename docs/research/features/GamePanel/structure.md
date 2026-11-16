# GamePanel — cấu trúc UI

Bằng chứng: `file-observed`, XAPK 1.3.2/build 65. Chưa tự xác nhận panel này đã được mở khi chơi; xem hồ sơ runtime riêng.

Có 151 MonoBehaviour component; 64 component có liên kết media xuất được. [Bảng chi tiết](ui-elements.csv) chứa hierarchy, path ID, anchor/pivot, font/text, sprite, raycast và toàn bộ serialized fields. Tọa độ là dữ liệu prefab, chưa phải bounding box runtime.

| Hierarchy | Component | Text mặc định | Sprite |
| --- | --- | --- | --- |
| GamePanel/All_Empty/Bubbles/Btn_Add/All_Anim | UnityEngine.UI.Button |  |  |
| GamePanel/All_Empty/Bubbles/Btn_Add/All_Anim | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| GamePanel/All_Empty/Bubbles/GrageItem/All_Anim/Num_Text | TMPro.TextMeshProUGUI | 5 |  |
| GamePanel/All_Empty/Top_Empty/Level_Text | TMPro.TextMeshProUGUI | Level {0} |  |
| GamePanel/All_Empty/Top_Empty/Btn_Pause | UnityEngine.UI.Button |  |  |
| GamePanel/All_Empty/Top_Empty/Btn_Pause | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| GamePanel/All_Empty/Top_Empty/Btn_Replay | UnityEngine.UI.Button |  |  |
| GamePanel/All_Empty/Top_Empty/Btn_Replay | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| GamePanel/All_Empty/FireTruckCD_Empty/Node/TimeShadow_Text | TMPro.TextMeshProUGUI | 23s |  |
| GamePanel/All_Empty/FireTruckCD_Empty/Node/Time_Text_1 | TMPro.TextMeshProUGUI | 23s |  |
| GamePanel/All_Empty/FireTruckCD_Empty/Node/Time_Text | TMPro.TextMeshProUGUI | 23s |  |
| GamePanel/All_Empty/Props/Prop_3 | UnityEngine.UI.Button |  |  |
| GamePanel/All_Empty/Props/Prop_3 | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| GamePanel/All_Empty/Props/Prop_3/Up_Empty/Level_Text | TMPro.TextMeshProUGUI | Level {0} |  |
| GamePanel/All_Empty/Props/Prop_3/Up_Empty/Vip_Text | TMPro.TextMeshProUGUI | VIP |  |
| GamePanel/All_Empty/Props/Prop_3/Up_Empty/RedDot_Img/Red_Text | TMPro.TextMeshProUGUI | 5 |  |
| GamePanel/All_Empty/Props/Prop_3/Up_Empty/Green_Empty/Free_Text | TMPro.TextMeshProUGUI | Free |  |
| GamePanel/All_Empty/Props/Prop_3/Up_Empty/Green_Empty/Free_Text/Free_Text | TMPro.TextMeshProUGUI | Free |  |
| GamePanel/All_Empty/Props/Prop_1 | UnityEngine.UI.Button |  |  |
| GamePanel/All_Empty/Props/Prop_1 | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| GamePanel/All_Empty/Props/Prop_1/Up_Empty/Level_Text | TMPro.TextMeshProUGUI | Level {0} |  |
| GamePanel/All_Empty/Props/Prop_1/Up_Empty/Arrange_Text | TMPro.TextMeshProUGUI | Arrange |  |
| GamePanel/All_Empty/Props/Prop_1/Up_Empty/RedDot_Img/Red_Text | TMPro.TextMeshProUGUI | 5 |  |
| GamePanel/All_Empty/Props/Prop_1/Up_Empty/Green_Empty/Free_Text | TMPro.TextMeshProUGUI | Free |  |
| GamePanel/All_Empty/Props/Prop_1/Up_Empty/Green_Empty/Free_Text/Free_Text | TMPro.TextMeshProUGUI | Free |  |
| GamePanel/All_Empty/Props/Prop_2 | UnityEngine.UI.Button |  |  |
| GamePanel/All_Empty/Props/Prop_2 | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| GamePanel/All_Empty/Props/Prop_2/Up_Empty/Level_Text | TMPro.TextMeshProUGUI | Level {0} |  |
| GamePanel/All_Empty/Props/Prop_2/Up_Empty/Icon_Img/Arrange_Text_1 | TMPro.TextMeshProUGUI | Jumble |  |
| GamePanel/All_Empty/Props/Prop_2/Up_Empty/RedDot_Img/Red_Text | TMPro.TextMeshProUGUI | 5 |  |
| GamePanel/All_Empty/Props/Prop_2/Up_Empty/Green_Empty/Free_Text | TMPro.TextMeshProUGUI | Free |  |
| GamePanel/All_Empty/Props/Prop_2/Up_Empty/Green_Empty/Free_Text/Free_Text | TMPro.TextMeshProUGUI | Free |  |
| GamePanel/Effect_AmbulanceHeartFly/Heart_Empty_01/Text_Node/Text | TMPro.TextMeshProUGUI | -1 |  |
