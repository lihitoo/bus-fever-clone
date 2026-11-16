# VictoryPanel — cấu trúc UI

Bằng chứng: `file-observed`, XAPK 1.3.2/build 65. Chưa tự xác nhận panel này đã được mở khi chơi; xem hồ sơ runtime riêng.

Có 246 MonoBehaviour component; 109 component có liên kết media xuất được. [Bảng chi tiết](ui-elements.csv) chứa hierarchy, path ID, anchor/pivot, font/text, sprite, raycast và toàn bộ serialized fields. Tọa độ là dữ liệu prefab, chưa phải bounding box runtime.

| Hierarchy | Component | Text mặc định | Sprite |
| --- | --- | --- | --- |
| VictoryPanel/All_Empty/Gold_Img/Gold_Text | TMPro.TextMeshProUGUI | 400 |  |
| VictoryPanel/All_Empty/Gold_Img/Gold2_Text | TMPro.TextMeshProUGUI | 400 |  |
| VictoryPanel/All_Empty/RewardDouble_Empty/Number_Empty/A/Multiple_Text_3 | TMPro.TextMeshProUGUI | ×1.5 |  |
| VictoryPanel/All_Empty/RewardDouble_Empty/Number_Empty/A/Multiple_Text_1 | TMPro.TextMeshProUGUI | ×3  |  |
| VictoryPanel/All_Empty/RewardDouble_Empty/Number_Empty/A/Multiple_Text | TMPro.TextMeshProUGUI | ×5 |  |
| VictoryPanel/All_Empty/RewardDouble_Empty/Number_Empty/A/Multiple_Text_2 | TMPro.TextMeshProUGUI | ×3  |  |
| VictoryPanel/All_Empty/RewardDouble_Empty/Number_Empty/A/Multiple_Text_4 | TMPro.TextMeshProUGUI | ×1.5 |  |
| VictoryPanel/All_Empty/RewardDouble_Empty/Number_Empty/B/Multiple_Text_3 | TMPro.TextMeshProUGUI | ×1.5 |  |
| VictoryPanel/All_Empty/RewardDouble_Empty/Number_Empty/B/Multiple_Text_1 | TMPro.TextMeshProUGUI | ×3  |  |
| VictoryPanel/All_Empty/RewardDouble_Empty/Number_Empty/B/Multiple_Text | TMPro.TextMeshProUGUI | ×5 |  |
| VictoryPanel/All_Empty/RewardDouble_Empty/Number_Empty/B/Multiple_Text_2 | TMPro.TextMeshProUGUI | ×3  |  |
| VictoryPanel/All_Empty/RewardDouble_Empty/Number_Empty/B/Multiple_Text_4 | TMPro.TextMeshProUGUI | ×1.5 |  |
| VictoryPanel/All_Empty/Btn_Group/Yellow_Button/Btn_Yellow | UnityEngine.UI.Button |  |  |
| VictoryPanel/All_Empty/Btn_Group/Yellow_Button/Btn_Yellow | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| VictoryPanel/All_Empty/Btn_Group/Yellow_Button/Btn_Yellow/UP_Empty/Prop_Text | TMPro.TextMeshProUGUI | Next |  |
| VictoryPanel/All_Empty/Btn_Group/Btn2_Empty/Green_Button/Btn_Green | UnityEngine.UI.Button |  |  |
| VictoryPanel/All_Empty/Btn_Group/Btn2_Empty/Green_Button/Btn_Green | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| VictoryPanel/All_Empty/Btn_Group/Btn2_Empty/Green_Button/Btn_Green/UP_Empty/Prop_Text | TMPro.TextMeshProUGUI | Free |  |
| VictoryPanel/All_Empty/Btn_Group/Btn2_Empty/Yellow_Button/Btn_Yellow | UnityEngine.UI.Button |  |  |
| VictoryPanel/All_Empty/Btn_Group/Btn2_Empty/Yellow_Button/Btn_Yellow | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| VictoryPanel/All_Empty/Btn_Group/Btn2_Empty/Yellow_Button/Btn_Yellow/UP_Empty/Prop_Text | TMPro.TextMeshProUGUI | Next |  |
| VictoryPanel/All_Empty/Card_Empty/All_Empty/Node1/Card1_Empty/Bottom_Empty/Title_Text | TMPro.TextMeshProUGUI | Ad-Free Pass |  |
| VictoryPanel/All_Empty/Card_Empty/All_Empty/Node1/Card1_Empty/Bottom_Empty/Title_Text/Title_Text_1 | TMPro.TextMeshProUGUI | Ad-Free Pass |  |
| VictoryPanel/All_Empty/Card_Empty/All_Empty/Node1/Card1_Empty/Bottom_Empty/Buy_Btn | UnityEngine.UI.Button |  |  |
| VictoryPanel/All_Empty/Card_Empty/All_Empty/Node1/Card1_Empty/Bottom_Empty/Buy_Btn/Up_Empty/Btn_Text | TMPro.TextMeshProUGUI | $ 6.99 |  |
| VictoryPanel/All_Empty/Card_Empty/All_Empty/Node1/Card1_Empty/Bottom_Empty/Buy_Btn/Up_Empty/Btn_Text/Title_Text_1 | TMPro.TextMeshProUGUI | $ 6.99 |  |
| VictoryPanel/All_Empty/Card_Empty/All_Empty/Node2/ViewPort/Content/Card01_Empty/Bottom_Empty/Title_Text | TMPro.TextMeshProUGUI | Enjoy Pack |  |
| VictoryPanel/All_Empty/Card_Empty/All_Empty/Node2/ViewPort/Content/Card01_Empty/Bottom_Empty/Title_Text/Title_Text_1 | TMPro.TextMeshProUGUI | Enjoy Pack |  |
| VictoryPanel/All_Empty/Card_Empty/All_Empty/Node2/ViewPort/Content/Card01_Empty/Bottom_Empty/Buy_Btn | UnityEngine.UI.Button |  |  |
| VictoryPanel/All_Empty/Card_Empty/All_Empty/Node2/ViewPort/Content/Card01_Empty/Bottom_Empty/Buy_Btn | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| VictoryPanel/All_Empty/Card_Empty/All_Empty/Node2/ViewPort/Content/Card01_Empty/Bottom_Empty/Buy_Btn/Up_Empty/Btn_Text | TMPro.TextMeshProUGUI | $ 6.99 |  |
| VictoryPanel/All_Empty/Card_Empty/All_Empty/Node2/ViewPort/Content/Card01_Empty/Bottom_Empty/Buy_Btn/Up_Empty/Btn_Text/Title_Text_1 | TMPro.TextMeshProUGUI | $ 6.99 |  |
| VictoryPanel/All_Empty/Card_Empty/All_Empty/Node2/ViewPort/Content/Card01_Empty/Bottom_Empty/Buy_Btn/Up_Empty/Line_Text_1 | TMPro.TextMeshProUGUI | $ 9.99 |  |
| VictoryPanel/All_Empty/Card_Empty/All_Empty/Node2/ViewPort/Content/Card01_Empty/Goods_Empty/Ball_Img/Number_Text_2 | TMPro.TextMeshProUGUI | ×1 |  |
| VictoryPanel/All_Empty/Card_Empty/All_Empty/Node2/ViewPort/Content/Card01_Empty/Goods_Empty/Fly_Img/Number_Text_2 | TMPro.TextMeshProUGUI | ×1 |  |
| VictoryPanel/All_Empty/Card_Empty/All_Empty/Node2/ViewPort/Content/Card01_Empty/Goods_Empty/Arrange_Img/Number_Text_3 | TMPro.TextMeshProUGUI | ×1 |  |
| VictoryPanel/All_Empty/Card_Empty/All_Empty/Node2/ViewPort/Content/Card01_Empty/Goods_Empty/Coins_Empty/Number_Text_4 | TMPro.TextMeshProUGUI | 3 000 |  |
| VictoryPanel/All_Empty/Card_Empty/All_Empty/Node2/ViewPort/Content/Card01_Empty/Goods_Empty/Coins_Empty/Number_Text_4/Number_Text_5 | TMPro.TextMeshProUGUI | 3 000 |  |
| VictoryPanel/All_Empty/Card_Empty/All_Empty/Node2/ViewPort/Content/Card01_Empty/Sale_Empty/Sale_Text | TMPro.TextMeshProUGUI | 20% |  |
| VictoryPanel/All_Empty/Card_Empty/All_Empty/Node2/ViewPort/Content/Card01_Empty/Sale_Empty/Sale_Text/Sale_Text_1 | TMPro.TextMeshProUGUI | OFF |  |
| VictoryPanel/All_Empty/Card_Empty/All_Empty/Node2/ViewPort/Content/Card02_Empty/Bottom_Empty/Title_Text | TMPro.TextMeshProUGUI | Surprise Pack |  |
| VictoryPanel/All_Empty/Card_Empty/All_Empty/Node2/ViewPort/Content/Card02_Empty/Bottom_Empty/Title_Text/Title_Text_1 | TMPro.TextMeshProUGUI | Surprise Pack |  |
| VictoryPanel/All_Empty/Card_Empty/All_Empty/Node2/ViewPort/Content/Card02_Empty/Bottom_Empty/Buy_Btn | UnityEngine.UI.Button |  |  |
| VictoryPanel/All_Empty/Card_Empty/All_Empty/Node2/ViewPort/Content/Card02_Empty/Bottom_Empty/Buy_Btn | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| VictoryPanel/All_Empty/Card_Empty/All_Empty/Node2/ViewPort/Content/Card02_Empty/Bottom_Empty/Buy_Btn/Up_Empty/Btn_Text | TMPro.TextMeshProUGUI | $ 6.99 |  |
| VictoryPanel/All_Empty/Card_Empty/All_Empty/Node2/ViewPort/Content/Card02_Empty/Bottom_Empty/Buy_Btn/Up_Empty/Btn_Text/Title_Text_1 | TMPro.TextMeshProUGUI | $ 6.99 |  |
| VictoryPanel/All_Empty/Card_Empty/All_Empty/Node2/ViewPort/Content/Card02_Empty/Bottom_Empty/Buy_Btn/Up_Empty/Line_Text | TMPro.TextMeshProUGUI | $ 14.27 |  |
| VictoryPanel/All_Empty/Card_Empty/All_Empty/Node2/ViewPort/Content/Card02_Empty/Goods_Empty/Ball_Img/Number_Text_2 | TMPro.TextMeshProUGUI | ×5 |  |
| VictoryPanel/All_Empty/Card_Empty/All_Empty/Node2/ViewPort/Content/Card02_Empty/Goods_Empty/Fly_Img/Number_Text_2 | TMPro.TextMeshProUGUI | ×5 |  |
| VictoryPanel/All_Empty/Card_Empty/All_Empty/Node2/ViewPort/Content/Card02_Empty/Goods_Empty/Arrange_Img/Number_Text_3 | TMPro.TextMeshProUGUI | ×5 |  |
| VictoryPanel/All_Empty/Card_Empty/All_Empty/Node2/ViewPort/Content/Card02_Empty/Goods_Empty/Coins_Empty/Number_Text_4 | TMPro.TextMeshProUGUI | 750 |  |
| VictoryPanel/All_Empty/Card_Empty/All_Empty/Node2/ViewPort/Content/Card02_Empty/Goods_Empty/Coins_Empty/Number_Text_4/Number_Text_5 | TMPro.TextMeshProUGUI | 750 |  |
| VictoryPanel/All_Empty/Card_Empty/All_Empty/Node2/ViewPort/Content/Card02_Empty/Sale_Empty/Sale_Text | TMPro.TextMeshProUGUI | 30% |  |
| VictoryPanel/All_Empty/Card_Empty/All_Empty/Node2/ViewPort/Content/Card02_Empty/Sale_Empty/Sale_Text/Sale_Text_1 | TMPro.TextMeshProUGUI | OFF |  |
| VictoryPanel/All_Empty/TaskBarPanel/TaskBar_Empty/Bar_Empty | UnityEngine.UI.Button |  |  |
| VictoryPanel/All_Empty/TaskBarPanel/TaskBar_Empty/Bar_Empty | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| VictoryPanel/All_Empty/TaskBarPanel/TaskBar_Empty/Bar_Empty/All_Anim/Time_Text | TMPro.TextMeshProUGUI | {0} |  |
| VictoryPanel/All_Empty/TaskBarPanel/TaskBar_Empty/Bar_Empty/All_Anim/Loading_Text | TMPro.TextMeshProUGUI | 59/99 |  |
| VictoryPanel/All_Empty/TaskBarPanel/TaskBar_Empty/Bar_Empty/All_Anim/Loading_Text/Loading_Text_1 | TMPro.TextMeshProUGUI | 59/99 |  |
| VictoryPanel/All_Empty/TaskBarPanel/TaskBar_Empty/Bar_Empty/All_Anim/Gift_Empty | UnityEngine.UI.Button |  |  |
| VictoryPanel/All_Empty/TaskBarPanel/TaskBar_Empty/Bar_Empty/All_Anim/Gift_Empty/Gift_Control/Reward_Text | TMPro.TextMeshProUGUI | x1 |  |
| VictoryPanel/All_Empty/TaskBarPanel/TaskBar_Empty/Bar_Empty/All_Anim/Gift_Empty/Float_Control/MiniPurpleGift_Img/Reward_Text | TMPro.TextMeshProUGUI | x1 |  |
| VictoryPanel/All_Empty/TaskBarPanel/TaskBar_Empty/Bar_Empty/All_Anim/Gift_Empty/Float_Control/MiniCar_Img/Reward_Text_1 | TMPro.TextMeshProUGUI | x1 |  |
| VictoryPanel/All_Empty/TaskBarPanel/TaskBar_Empty/Bar_Empty/All_Anim/Gift_Empty/Float_Control/Coin1_Img/Reward_Text_2 | TMPro.TextMeshProUGUI | x1 |  |
| VictoryPanel/All_Empty/TaskBarPanel/TaskBar_Empty/Bar_Empty/All_Anim/Bubble_Empty/Background | UnityEngine.UI.Button |  |  |
| VictoryPanel/All_Empty/TaskBarPanel/TaskBar_Empty/Bar_Empty/All_Anim/Bubble_Empty/Info_Content/Rewards_Empty/Coin_Empty/Coin_Img/Reward_Text | TMPro.TextMeshProUGUI | 6 750 |  |
| VictoryPanel/All_Empty/TaskBarPanel/TaskBar_Empty/Bar_Empty/All_Anim/Bubble_Empty/Info_Content/Rewards_Empty/Coin_Empty/Coin_Img/Reward_Text/Reward_Text_1 | TMPro.TextMeshProUGUI | 6 750 |  |
| VictoryPanel/All_Empty/TaskBarPanel/TaskBar_Empty/Bar_Empty/All_Anim/Bubble_Empty/Info_Content/Rewards_Empty/Ball_Empty/Ball_Img/Reward_Text | TMPro.TextMeshProUGUI | ×5 |  |
| VictoryPanel/All_Empty/TaskBarPanel/TaskBar_Empty/Bar_Empty/All_Anim/Bubble_Empty/Info_Content/Rewards_Empty/Ball_Empty/Ball_Img/Reward_Text/Reward_Text_1 | TMPro.TextMeshProUGUI | ×5 |  |
| VictoryPanel/All_Empty/TaskBarPanel/TaskBar_Empty/Bar_Empty/All_Anim/Bubble_Empty/Info_Content/Rewards_Empty/Car_Empty/Car_Img/Reward_Text | TMPro.TextMeshProUGUI | ×5 |  |
| VictoryPanel/All_Empty/TaskBarPanel/TaskBar_Empty/Bar_Empty/All_Anim/Bubble_Empty/Info_Content/Rewards_Empty/Car_Empty/Car_Img/Reward_Text/Reward_Text_1 | TMPro.TextMeshProUGUI | ×5 |  |
| VictoryPanel/All_Empty/TaskBarPanel/TaskBar_Empty/Bar_Empty/All_Anim/Bubble_Empty/Info_Content/Rewards_Empty/Arrange_Empty/Arrange_Img/Reward_Text | TMPro.TextMeshProUGUI | ×5 |  |
| VictoryPanel/All_Empty/TaskBarPanel/TaskBar_Empty/Bar_Empty/All_Anim/Bubble_Empty/Info_Content/Rewards_Empty/Arrange_Empty/Arrange_Img/Reward_Text/Reward_Text_1 | TMPro.TextMeshProUGUI | ×5 |  |
