# FailPanel — cấu trúc UI

Bằng chứng: `file-observed`, XAPK 1.3.2/build 65. Chưa tự xác nhận panel này đã được mở khi chơi; xem hồ sơ runtime riêng.

Có 92 MonoBehaviour component; 46 component có liên kết media xuất được. [Bảng chi tiết](ui-elements.csv) chứa hierarchy, path ID, anchor/pivot, font/text, sprite, raycast và toàn bộ serialized fields. Tọa độ là dữ liệu prefab, chưa phải bounding box runtime.

| Hierarchy | Component | Text mặc định | Sprite |
| --- | --- | --- | --- |
| FailPanel/SafeArea/All_Anim/Revive_Empty/Title_Text | TMPro.TextMeshProUGUI | Are you sure? |  |
| FailPanel/SafeArea/All_Anim/Revive_Empty/MidBg_Img/Tip_Text | TMPro.TextMeshProUGUI | You will lose a life! |  |
| FailPanel/SafeArea/All_Anim/Revive_Empty/Btn2_Empty/Yellow_Btn | UnityEngine.UI.Button |  |  |
| FailPanel/SafeArea/All_Anim/Revive_Empty/Btn2_Empty/Yellow_Btn | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| FailPanel/SafeArea/All_Anim/Revive_Empty/Btn2_Empty/Yellow_Btn/UP_Empty/Prop_Text | TMPro.TextMeshProUGUI | 200 |  |
| FailPanel/SafeArea/All_Anim/Revive_Empty/Btn2_Empty/Btn_Green | UnityEngine.UI.Button |  |  |
| FailPanel/SafeArea/All_Anim/Revive_Empty/Btn2_Empty/Btn_Green | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| FailPanel/SafeArea/All_Anim/Revive_Empty/Btn2_Empty/Btn_Green/UP_Empty/Prop_Text | TMPro.TextMeshProUGUI | Free |  |
| FailPanel/SafeArea/All_Anim/Revive_Empty/Btn2_Empty/Restart_Btn | TMPro.TextMeshProUGUI | Restart |  |
| FailPanel/SafeArea/All_Anim/Revive_Empty/Btn2_Empty/Restart_Btn | UnityEngine.UI.Button |  |  |
| FailPanel/SafeArea/All_Anim/Revive_Empty/Btn2_Empty/Restart_Btn | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| FailPanel/SafeArea/All_Anim/BoostPackPanel/Coins_Empty/Number_Text | TMPro.TextMeshProUGUI | 3 000 |  |
| FailPanel/SafeArea/All_Anim/BoostPackPanel/Goods_Empty/Ball_Img/PropNum_Text | TMPro.TextMeshProUGUI | ×1 |  |
| FailPanel/SafeArea/All_Anim/BoostPackPanel/Goods_Empty/Fly_Img/PropNum_Text | TMPro.TextMeshProUGUI | ×1 |  |
| FailPanel/SafeArea/All_Anim/BoostPackPanel/Goods_Empty/Arrange_Img/PropNum_Text | TMPro.TextMeshProUGUI | ×1 |  |
| FailPanel/SafeArea/All_Anim/BoostPackPanel/Title_Empty/Title_Text | TMPro.TextMeshProUGUI | Boost Pack |  |
| FailPanel/SafeArea/All_Anim/BoostPackPanel/Buy_Btn | UnityEngine.UI.Button |  |  |
| FailPanel/SafeArea/All_Anim/BoostPackPanel/Buy_Btn | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| FailPanel/SafeArea/All_Anim/BoostPackPanel/Buy_Btn/Up_Empty/Btn_Text | TMPro.TextMeshProUGUI | $ 7.99 |  |
| FailPanel/SafeArea/All_Anim/BoostPackPanel/Sale_Empty/Sale_Text | TMPro.TextMeshProUGUI | 40% |  |
| FailPanel/SafeArea/All_Anim/BoostPackPanel/Sale_Empty/Sale_Text/Sale_Text_1 | TMPro.TextMeshProUGUI | OFF |  |
| FailPanel/SafeArea/All_Anim/BottomTip_Text | TMPro.TextMeshProUGUI | Hold to see the map |  |
| FailPanel/SafeArea/All_Anim/TopResourece_Empty/Btn_Lives/Btn_Lives | UnityEngine.UI.Button |  |  |
| FailPanel/SafeArea/All_Anim/TopResourece_Empty/Btn_Lives/Btn_Lives | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| FailPanel/SafeArea/All_Anim/TopResourece_Empty/Btn_Lives/Btn_Lives/Lives_Img/LivesNum_Text | TMPro.TextMeshProUGUI | 0 |  |
| FailPanel/SafeArea/All_Anim/TopResourece_Empty/Btn_Lives/Btn_Lives/UnlimitedTime_Text | TMPro.TextMeshProUGUI | 00:00:00 |  |
| FailPanel/SafeArea/All_Anim/TopResourece_Empty/Btn_Lives/Btn_Lives/FullLivesTime_Text | TMPro.TextMeshProUGUI | 14:28 |  |
| FailPanel/SafeArea/All_Anim/TopResourece_Empty/Btn_Lives/Btn_Lives/FullLives_Text | TMPro.TextMeshProUGUI | Full |  |
| FailPanel/SafeArea/All_Anim/TopResourece_Empty/Btn_Gold/Btn_Gold | UnityEngine.UI.Button |  |  |
| FailPanel/SafeArea/All_Anim/TopResourece_Empty/Btn_Gold/Btn_Gold | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| FailPanel/SafeArea/All_Anim/TopResourece_Empty/Btn_Gold/Btn_Gold/Gold_Text | TMPro.TextMeshProUGUI | 7889 |  |
