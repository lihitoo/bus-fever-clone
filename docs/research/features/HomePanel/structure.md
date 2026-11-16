# HomePanel — cấu trúc UI

Bằng chứng: `file-observed`, XAPK 1.3.2/build 65. Chưa tự xác nhận panel này đã được mở khi chơi; xem hồ sơ runtime riêng.

Có 260 MonoBehaviour component; 131 component có liên kết media xuất được. [Bảng chi tiết](ui-elements.csv) chứa hierarchy, path ID, anchor/pivot, font/text, sprite, raycast và toàn bộ serialized fields. Tọa độ là dữ liệu prefab, chưa phải bounding box runtime.

| Hierarchy | Component | Text mặc định | Sprite |
| --- | --- | --- | --- |
| HomePanel/All_Empty/Top_Empty/UserProfileAvatarButton | UnityEngine.UI.Button |  |  |
| HomePanel/All_Empty/Top_Empty/UserProfileAvatarButton | BusJam.UserProfile.UserProfileAvatarButton |  |  |
| HomePanel/All_Empty/Top_Empty/UserProfileAvatarButton | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| HomePanel/All_Empty/Top_Empty/Btn_Setting | UnityEngine.UI.Button |  |  |
| HomePanel/All_Empty/Top_Empty/Btn_Setting | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| HomePanel/All_Empty/TaskBarPanel/TaskBar_Empty/Bar_Empty | UnityEngine.UI.Button |  |  |
| HomePanel/All_Empty/TaskBarPanel/TaskBar_Empty/Bar_Empty | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| HomePanel/All_Empty/TaskBarPanel/TaskBar_Empty/Bar_Empty/All_Anim/Time_Text | TMPro.TextMeshProUGUI | {0} |  |
| HomePanel/All_Empty/TaskBarPanel/TaskBar_Empty/Bar_Empty/All_Anim/Loading_Text | TMPro.TextMeshProUGUI | 59/99 |  |
| HomePanel/All_Empty/TaskBarPanel/TaskBar_Empty/Bar_Empty/All_Anim/Loading_Text/Loading_Text_1 | TMPro.TextMeshProUGUI | 59/99 |  |
| HomePanel/All_Empty/TaskBarPanel/TaskBar_Empty/Bar_Empty/All_Anim/Gift_Empty | UnityEngine.UI.Button |  |  |
| HomePanel/All_Empty/TaskBarPanel/TaskBar_Empty/Bar_Empty/All_Anim/Gift_Empty/Gift_Control/Reward_Text | TMPro.TextMeshProUGUI | x1 |  |
| HomePanel/All_Empty/TaskBarPanel/TaskBar_Empty/Bar_Empty/All_Anim/Gift_Empty/Float_Control/MiniPurpleGift_Img/Reward_Text | TMPro.TextMeshProUGUI | x1 |  |
| HomePanel/All_Empty/TaskBarPanel/TaskBar_Empty/Bar_Empty/All_Anim/Gift_Empty/Float_Control/MiniCar_Img/Reward_Text_1 | TMPro.TextMeshProUGUI | x1 |  |
| HomePanel/All_Empty/TaskBarPanel/TaskBar_Empty/Bar_Empty/All_Anim/Gift_Empty/Float_Control/Coin1_Img/Reward_Text_2 | TMPro.TextMeshProUGUI | x1 |  |
| HomePanel/All_Empty/TaskBarPanel/TaskBar_Empty/Bar_Empty/All_Anim/Bubble_Empty/Background | UnityEngine.UI.Button |  |  |
| HomePanel/All_Empty/TaskBarPanel/TaskBar_Empty/Bar_Empty/All_Anim/Bubble_Empty/Info_Content/Rewards_Empty/Coin_Empty/Coin_Img/Reward_Text | TMPro.TextMeshProUGUI | 6 750 |  |
| HomePanel/All_Empty/TaskBarPanel/TaskBar_Empty/Bar_Empty/All_Anim/Bubble_Empty/Info_Content/Rewards_Empty/Coin_Empty/Coin_Img/Reward_Text/Reward_Text_1 | TMPro.TextMeshProUGUI | 6 750 |  |
| HomePanel/All_Empty/TaskBarPanel/TaskBar_Empty/Bar_Empty/All_Anim/Bubble_Empty/Info_Content/Rewards_Empty/Ball_Empty/Ball_Img/Reward_Text | TMPro.TextMeshProUGUI | ×5 |  |
| HomePanel/All_Empty/TaskBarPanel/TaskBar_Empty/Bar_Empty/All_Anim/Bubble_Empty/Info_Content/Rewards_Empty/Ball_Empty/Ball_Img/Reward_Text/Reward_Text_1 | TMPro.TextMeshProUGUI | ×5 |  |
| HomePanel/All_Empty/TaskBarPanel/TaskBar_Empty/Bar_Empty/All_Anim/Bubble_Empty/Info_Content/Rewards_Empty/Car_Empty/Car_Img/Reward_Text | TMPro.TextMeshProUGUI | ×5 |  |
| HomePanel/All_Empty/TaskBarPanel/TaskBar_Empty/Bar_Empty/All_Anim/Bubble_Empty/Info_Content/Rewards_Empty/Car_Empty/Car_Img/Reward_Text/Reward_Text_1 | TMPro.TextMeshProUGUI | ×5 |  |
| HomePanel/All_Empty/TaskBarPanel/TaskBar_Empty/Bar_Empty/All_Anim/Bubble_Empty/Info_Content/Rewards_Empty/Arrange_Empty/Arrange_Img/Reward_Text | TMPro.TextMeshProUGUI | ×5 |  |
| HomePanel/All_Empty/TaskBarPanel/TaskBar_Empty/Bar_Empty/All_Anim/Bubble_Empty/Info_Content/Rewards_Empty/Arrange_Empty/Arrange_Img/Reward_Text/Reward_Text_1 | TMPro.TextMeshProUGUI | ×5 |  |
| HomePanel/All_Empty/Right_Empty/Supplies_Btn | UnityEngine.UI.Button |  |  |
| HomePanel/All_Empty/Right_Empty/Supplies_Btn | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| HomePanel/All_Empty/Right_Empty/Supplies_Btn/All_Anim/Text_Empty/Supplies_Text | TMPro.TextMeshProUGUI | Supplies |  |
| HomePanel/All_Empty/Right_Empty/Supplies_Btn/All_Anim/Sale_Empty/Sale_Text | TMPro.TextMeshProUGUI | 50% |  |
| HomePanel/All_Empty/Right_Empty/Supplies_Btn/All_Anim/Sale_Empty/Sale_Text/Sale_Text_1 | TMPro.TextMeshProUGUI | OFF |  |
| HomePanel/All_Empty/Right_Empty/Spin_Btn | UnityEngine.UI.Button |  |  |
| HomePanel/All_Empty/Right_Empty/Spin_Btn | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| HomePanel/All_Empty/Right_Empty/Spin_Btn/All_Anim/Text_Empty/Supplies_Text | TMPro.TextMeshProUGUI | Spin |  |
| HomePanel/All_Empty/Right_Empty/Spin_Btn/All_Anim/Sale_Empty/Sale_Text | TMPro.TextMeshProUGUI | 50% |  |
| HomePanel/All_Empty/Right_Empty/Spin_Btn/All_Anim/Sale_Empty/Sale_Text/Sale_Text_1 | TMPro.TextMeshProUGUI | OFF |  |
| HomePanel/All_Empty/Right_Empty/Spin_Btn/All_Anim/MiniIcon_Empty/All_Anim/Text_Control/Number_Text | TMPro.TextMeshProUGUI | +1 |  |
| HomePanel/All_Empty/Right_Empty/DailyBonusEntrance | UnityEngine.UI.Button |  |  |
| HomePanel/All_Empty/Right_Empty/DailyBonusEntrance | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| HomePanel/All_Empty/Right_Empty/DailyBonusEntrance/All_Anim/Text_Empty/Supplies_Text | TMPro.TextMeshProUGUI | Check-In |  |
| HomePanel/All_Empty/Right_Empty/ColorGuess_Btn | UnityEngine.UI.Button |  |  |
| HomePanel/All_Empty/Right_Empty/ColorGuess_Btn/Title | TMPro.TextMeshProUGUI | COLOR LAB |  |
| HomePanel/All_Empty/Right_Empty/ColorGuess_Btn/PotionCount | TMPro.TextMeshProUGUI | 0 |  |
| HomePanel/All_Empty/Right_Empty/ColorGuess_Btn/RedDot/Text | TMPro.TextMeshProUGUI | 0 |  |
| HomePanel/All_Empty/Right_Empty/RankingHomeEntrance | UnityEngine.UI.Button |  |  |
| HomePanel/All_Empty/Right_Empty/RankingHomeEntrance | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| HomePanel/All_Empty/Right_Empty/RankingHomeEntrance/Icon | TMPro.TextMeshProUGUI | # |  |
| HomePanel/All_Empty/Right_Empty/RankingHomeEntrance/Title | TMPro.TextMeshProUGUI | Rank |  |
| HomePanel/All_Empty/Right_Empty/RankingHomeEntrance/Lock | TMPro.TextMeshProUGUI | Lv.29 |  |
| HomePanel/All_Empty/Left_Empty/Btn_Empty/Ads_Btn | UnityEngine.UI.Button |  |  |
| HomePanel/All_Empty/Left_Empty/Btn_Empty/Ads_Btn | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| HomePanel/All_Empty/Left_Empty/Beginner_Btn | UnityEngine.UI.Button |  |  |
| HomePanel/All_Empty/Left_Empty/Beginner_Btn | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| HomePanel/All_Empty/Left_Empty/Beginner_Btn/Text_Empty/Shop_Text | TMPro.TextMeshProUGUI | On Sale |  |
| HomePanel/All_Empty/Left_Empty/Beginner_Btn/Sale_Empty/Sale_Text | TMPro.TextMeshProUGUI | 50% |  |
| HomePanel/All_Empty/Left_Empty/Beginner_Btn/Sale_Empty/Sale_Text/Sale_Text_1 | TMPro.TextMeshProUGUI | OFF |  |
| HomePanel/All_Empty/Left_Empty/Ad-Free_Bundle_Btn | UnityEngine.UI.Button |  |  |
| HomePanel/All_Empty/Left_Empty/Ad-Free_Bundle_Btn | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| HomePanel/All_Empty/Left_Empty/Ad-Free_Bundle_Btn/Text_Empty/Free_Text | TMPro.TextMeshProUGUI | Ad Free |  |
| HomePanel/All_Empty/Left_Empty/Ad-Free_Bundle_Btn/Sale_Empty/Sale_Text | TMPro.TextMeshProUGUI | 35% |  |
| HomePanel/All_Empty/Left_Empty/Ad-Free_Bundle_Btn/Sale_Empty/Sale_Text/Sale_Text_1 | TMPro.TextMeshProUGUI | OFF |  |
| HomePanel/All_Empty/Left_Empty/Shop_Btn | UnityEngine.UI.Button |  |  |
| HomePanel/All_Empty/Left_Empty/Shop_Btn | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| HomePanel/All_Empty/Left_Empty/Shop_Btn/Shop_Text | TMPro.TextMeshProUGUI | Shop |  |
| HomePanel/All_Empty/Bottom_Empty/Play_Btn | UnityEngine.UI.Button |  |  |
| HomePanel/All_Empty/Bottom_Empty/Play_Btn | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| HomePanel/All_Empty/Bottom_Empty/Play_Btn/UP_Empty/ImageMask/Play_Text | TMPro.TextMeshProUGUI | Play |  |
