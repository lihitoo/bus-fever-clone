# TaskBarPanel — cấu trúc UI

Bằng chứng: `file-observed`, XAPK 1.3.2/build 65. Chưa tự xác nhận panel này đã được mở khi chơi; xem hồ sơ runtime riêng.

Có 61 MonoBehaviour component; 28 component có liên kết media xuất được. [Bảng chi tiết](ui-elements.csv) chứa hierarchy, path ID, anchor/pivot, font/text, sprite, raycast và toàn bộ serialized fields. Tọa độ là dữ liệu prefab, chưa phải bounding box runtime.

| Hierarchy | Component | Text mặc định | Sprite |
| --- | --- | --- | --- |
| TaskBarPanel/TaskBar_Empty/Bar_Empty | UnityEngine.UI.Button |  |  |
| TaskBarPanel/TaskBar_Empty/Bar_Empty | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| TaskBarPanel/TaskBar_Empty/Bar_Empty/All_Anim/Time_Text | TMPro.TextMeshProUGUI | {0} |  |
| TaskBarPanel/TaskBar_Empty/Bar_Empty/All_Anim/Loading_Text | TMPro.TextMeshProUGUI | 59/99 |  |
| TaskBarPanel/TaskBar_Empty/Bar_Empty/All_Anim/Loading_Text/Loading_Text_1 | TMPro.TextMeshProUGUI | 59/99 |  |
| TaskBarPanel/TaskBar_Empty/Bar_Empty/All_Anim/Gift_Empty | UnityEngine.UI.Button |  |  |
| TaskBarPanel/TaskBar_Empty/Bar_Empty/All_Anim/Gift_Empty/Gift_Control/Reward_Text | TMPro.TextMeshProUGUI | x1 |  |
| TaskBarPanel/TaskBar_Empty/Bar_Empty/All_Anim/Gift_Empty/Float_Control/MiniPurpleGift_Img/Reward_Text | TMPro.TextMeshProUGUI | x1 |  |
| TaskBarPanel/TaskBar_Empty/Bar_Empty/All_Anim/Gift_Empty/Float_Control/MiniCar_Img/Reward_Text_1 | TMPro.TextMeshProUGUI | x1 |  |
| TaskBarPanel/TaskBar_Empty/Bar_Empty/All_Anim/Gift_Empty/Float_Control/Coin1_Img/Reward_Text_2 | TMPro.TextMeshProUGUI | x1 |  |
| TaskBarPanel/TaskBar_Empty/Bar_Empty/All_Anim/Bubble_Empty/Background | UnityEngine.UI.Button |  |  |
| TaskBarPanel/TaskBar_Empty/Bar_Empty/All_Anim/Bubble_Empty/Info_Content/Rewards_Empty/Coin_Empty/Coin_Img/Reward_Text | TMPro.TextMeshProUGUI | 6 750 |  |
| TaskBarPanel/TaskBar_Empty/Bar_Empty/All_Anim/Bubble_Empty/Info_Content/Rewards_Empty/Coin_Empty/Coin_Img/Reward_Text/Reward_Text_1 | TMPro.TextMeshProUGUI | 6 750 |  |
| TaskBarPanel/TaskBar_Empty/Bar_Empty/All_Anim/Bubble_Empty/Info_Content/Rewards_Empty/Ball_Empty/Ball_Img/Reward_Text | TMPro.TextMeshProUGUI | ×5 |  |
| TaskBarPanel/TaskBar_Empty/Bar_Empty/All_Anim/Bubble_Empty/Info_Content/Rewards_Empty/Ball_Empty/Ball_Img/Reward_Text/Reward_Text_1 | TMPro.TextMeshProUGUI | ×5 |  |
| TaskBarPanel/TaskBar_Empty/Bar_Empty/All_Anim/Bubble_Empty/Info_Content/Rewards_Empty/Car_Empty/Car_Img/Reward_Text | TMPro.TextMeshProUGUI | ×5 |  |
| TaskBarPanel/TaskBar_Empty/Bar_Empty/All_Anim/Bubble_Empty/Info_Content/Rewards_Empty/Car_Empty/Car_Img/Reward_Text/Reward_Text_1 | TMPro.TextMeshProUGUI | ×5 |  |
| TaskBarPanel/TaskBar_Empty/Bar_Empty/All_Anim/Bubble_Empty/Info_Content/Rewards_Empty/Arrange_Empty/Arrange_Img/Reward_Text | TMPro.TextMeshProUGUI | ×5 |  |
| TaskBarPanel/TaskBar_Empty/Bar_Empty/All_Anim/Bubble_Empty/Info_Content/Rewards_Empty/Arrange_Empty/Arrange_Img/Reward_Text/Reward_Text_1 | TMPro.TextMeshProUGUI | ×5 |  |
