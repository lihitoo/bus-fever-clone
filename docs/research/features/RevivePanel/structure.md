# RevivePanel — cấu trúc UI

Bằng chứng: `file-observed`, XAPK 1.3.2/build 65. Chưa tự xác nhận panel này đã được mở khi chơi; xem hồ sơ runtime riêng.

Có 201 MonoBehaviour component; 89 component có liên kết media xuất được. [Bảng chi tiết](ui-elements.csv) chứa hierarchy, path ID, anchor/pivot, font/text, sprite, raycast và toàn bộ serialized fields. Tọa độ là dữ liệu prefab, chưa phải bounding box runtime.

| Hierarchy | Component | Text mặc định | Sprite |
| --- | --- | --- | --- |
| RevivePanel/SafeArea/All_Anim/Revive_Empty/Revive_Control/Parking_Empty/KeepGoing_Text | TMPro.TextMeshProUGUI | <color=#ec6f00>Clear</color> all parked buses and <color=#ec6f00>unlock</color> 1 extra spot! |  |
| RevivePanel/SafeArea/All_Anim/Revive_Empty/Revive_Control/Parking_Empty/Normal_Text | TMPro.TextMeshProUGUI | Out of Spots |  |
| RevivePanel/SafeArea/All_Anim/Revive_Empty/Revive_Control/Ambulance_Empty/Time_Text_1 | TMPro.TextMeshProUGUI | +4 |  |
| RevivePanel/SafeArea/All_Anim/Revive_Empty/Revive_Control/Ambulance_Empty/Time_Text_1/Time_Text_2 | TMPro.TextMeshProUGUI | +4 |  |
| RevivePanel/SafeArea/All_Anim/Revive_Empty/Revive_Control/Ambulance_Empty/Reset_Text | TMPro.TextMeshProUGUI | Reset steps to save life |  |
| RevivePanel/SafeArea/All_Anim/Revive_Empty/Revive_Control/Ambulance_Empty/KeepGoing_Text | TMPro.TextMeshProUGUI | Rescue failed |  |
| RevivePanel/SafeArea/All_Anim/Revive_Empty/Revive_Control/Firetruck_Empty/Time_Text | TMPro.TextMeshProUGUI | +20s |  |
| RevivePanel/SafeArea/All_Anim/Revive_Empty/Revive_Control/Firetruck_Empty/Time_Text/Time_Text_2 | TMPro.TextMeshProUGUI | +20s |  |
| RevivePanel/SafeArea/All_Anim/Revive_Empty/Revive_Control/Firetruck_Empty/Reset_Text_1 | TMPro.TextMeshProUGUI | Reset clock to stop fire |  |
| RevivePanel/SafeArea/All_Anim/Revive_Empty/Revive_Control/Firetruck_Empty/Title_Text | TMPro.TextMeshProUGUI | Out of Spots |  |
| RevivePanel/SafeArea/All_Anim/Revive_Empty/Revive_Control/SpliceBus_Empty/Arrange_Text | TMPro.TextMeshProUGUI | <color=#ec6f00>Arrange </color>passenger to keep playing! |  |
| RevivePanel/SafeArea/All_Anim/Revive_Empty/Revive_Control/SpliceBus_Empty/Title_Text | TMPro.TextMeshProUGUI | Out of Spots |  |
| RevivePanel/SafeArea/All_Anim/Revive_Empty/Revive_Control/VipCar_Empty/Title_Text | TMPro.TextMeshProUGUI | Car Jammed ! |  |
| RevivePanel/SafeArea/All_Anim/Revive_Empty/Revive_Control/VipCar_Empty/Tip_Text | TMPro.TextMeshProUGUI | Send vehicle to  <color=#ec6f00>VIP</color>  spot  to solve  jammed car! |  |
| RevivePanel/SafeArea/All_Anim/Revive_Empty/LosePassenager_Empty/Bubble_Img/Num_Text | TMPro.TextMeshProUGUI | 22 |  |
| RevivePanel/SafeArea/All_Anim/Revive_Empty/LosePassenager_Empty/Bubble_Img/Num_Text/Num_Text_2 | TMPro.TextMeshProUGUI | 22 |  |
| RevivePanel/SafeArea/All_Anim/Revive_Empty/LosePassenager_Empty/Bubble_Img/Tip_Text | TMPro.TextMeshProUGUI | You will lose your <color=#c6243a>passengers</color>! |  |
| RevivePanel/SafeArea/All_Anim/Revive_Empty/LosePassenager_Empty/Title_Text | TMPro.TextMeshProUGUI | Out of Spots |  |
| RevivePanel/SafeArea/All_Anim/Revive_Empty/Btn_Group/Coin_Btn | UnityEngine.UI.Button |  |  |
| RevivePanel/SafeArea/All_Anim/Revive_Empty/Btn_Group/Coin_Btn | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| RevivePanel/SafeArea/All_Anim/Revive_Empty/Btn_Group/Coin_Btn/UP_Empty/Prop_Text | TMPro.TextMeshProUGUI | 200 |  |
| RevivePanel/SafeArea/All_Anim/Revive_Empty/Btn_Group/Free_Btn | UnityEngine.UI.Button |  |  |
| RevivePanel/SafeArea/All_Anim/Revive_Empty/Btn_Group/Free_Btn | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| RevivePanel/SafeArea/All_Anim/Revive_Empty/Btn_Group/Free_Btn/UP_Empty/Prop_Text | TMPro.TextMeshProUGUI | Revive |  |
| RevivePanel/SafeArea/All_Anim/Revive_Empty/Btn_Group/Free_Btn/LabelBg_Img/Free_Text | TMPro.TextMeshProUGUI | Free |  |
| RevivePanel/SafeArea/All_Anim/Revive_Empty/Btn_Group/Btn2_Empty/Yellow_Btn | UnityEngine.UI.Button |  |  |
| RevivePanel/SafeArea/All_Anim/Revive_Empty/Btn_Group/Btn2_Empty/Yellow_Btn | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| RevivePanel/SafeArea/All_Anim/Revive_Empty/Btn_Group/Btn2_Empty/Yellow_Btn/UP_Empty/Prop_Text | TMPro.TextMeshProUGUI | 200 |  |
| RevivePanel/SafeArea/All_Anim/Revive_Empty/Btn_Group/Btn2_Empty/Btn_Green | UnityEngine.UI.Button |  |  |
| RevivePanel/SafeArea/All_Anim/Revive_Empty/Btn_Group/Btn2_Empty/Btn_Green | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| RevivePanel/SafeArea/All_Anim/Revive_Empty/Btn_Group/Btn2_Empty/Btn_Green/UP_Empty/Prop_Text | TMPro.TextMeshProUGUI | Free |  |
| RevivePanel/SafeArea/All_Anim/Revive_Empty/Btn_Group/Restart_Btn | TMPro.TextMeshProUGUI | Restart |  |
| RevivePanel/SafeArea/All_Anim/Revive_Empty/Btn_Group/Restart_Btn | UnityEngine.UI.Button |  |  |
| RevivePanel/SafeArea/All_Anim/Revive_Empty/Btn_Group/Restart_Btn | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| RevivePanel/SafeArea/All_Anim/BoostPackPanel/Coins_Empty/Number_Text | TMPro.TextMeshProUGUI | 3 000 |  |
| RevivePanel/SafeArea/All_Anim/BoostPackPanel/Goods_Empty/Ball_Img/PropNum_Text | TMPro.TextMeshProUGUI | ×1 |  |
| RevivePanel/SafeArea/All_Anim/BoostPackPanel/Goods_Empty/Fly_Img/PropNum_Text | TMPro.TextMeshProUGUI | ×1 |  |
| RevivePanel/SafeArea/All_Anim/BoostPackPanel/Goods_Empty/Arrange_Img/PropNum_Text | TMPro.TextMeshProUGUI | ×1 |  |
| RevivePanel/SafeArea/All_Anim/BoostPackPanel/Title_Empty/Title_Text | TMPro.TextMeshProUGUI | Boost Pack |  |
| RevivePanel/SafeArea/All_Anim/BoostPackPanel/Buy_Btn | UnityEngine.UI.Button |  |  |
| RevivePanel/SafeArea/All_Anim/BoostPackPanel/Buy_Btn | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| RevivePanel/SafeArea/All_Anim/BoostPackPanel/Buy_Btn/Up_Empty/Btn_Text | TMPro.TextMeshProUGUI | $ 7.99 |  |
| RevivePanel/SafeArea/All_Anim/BoostPackPanel/Sale_Empty/Sale_Text | TMPro.TextMeshProUGUI | 40% |  |
| RevivePanel/SafeArea/All_Anim/BoostPackPanel/Sale_Empty/Sale_Text/Sale_Text_1 | TMPro.TextMeshProUGUI | OFF |  |
| RevivePanel/SafeArea/All_Anim/BottomTip_Text | TMPro.TextMeshProUGUI | Hold to see the map |  |
| RevivePanel/ReplayPanel/SafeArea/All_Anim/Btn_Close | UnityEngine.UI.Button |  |  |
| RevivePanel/ReplayPanel/SafeArea/All_Anim/Btn_Close | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| RevivePanel/ReplayPanel/SafeArea/All_Anim/Replay_Text | TMPro.TextMeshProUGUI | Restart |  |
| RevivePanel/ReplayPanel/SafeArea/All_Anim/Replay_Text | TMPro.TextMeshProUGUI | Restart this level? |  |
| RevivePanel/ReplayPanel/SafeArea/All_Anim/Btn_Yellow | UnityEngine.UI.Button |  |  |
| RevivePanel/ReplayPanel/SafeArea/All_Anim/Btn_Yellow | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| RevivePanel/ReplayPanel/SafeArea/All_Anim/Btn_Yellow/UP_Empty/Prop_Text | TMPro.TextMeshProUGUI | No |  |
| RevivePanel/ReplayPanel/SafeArea/All_Anim/Btn_Green | UnityEngine.UI.Button |  |  |
| RevivePanel/ReplayPanel/SafeArea/All_Anim/Btn_Green | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| RevivePanel/ReplayPanel/SafeArea/All_Anim/Btn_Green/UP_Empty/Prop_Text | TMPro.TextMeshProUGUI | Yes |  |
