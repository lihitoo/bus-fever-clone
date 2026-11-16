# TaskBarRewardPanel — cấu trúc UI

Bằng chứng: `file-observed`, XAPK 1.3.2/build 65. Chưa tự xác nhận panel này đã được mở khi chơi; xem hồ sơ runtime riêng.

Có 140 MonoBehaviour component; 47 component có liên kết media xuất được. [Bảng chi tiết](ui-elements.csv) chứa hierarchy, path ID, anchor/pivot, font/text, sprite, raycast và toàn bộ serialized fields. Tọa độ là dữ liệu prefab, chưa phải bounding box runtime.

| Hierarchy | Component | Text mặc định | Sprite |
| --- | --- | --- | --- |
| TaskBarRewardPanel/SafeArea/Content/All_Anim/Reward_Empty/TaskPopupTopBarItem/ProgressNum_Text | TMPro.TextMeshProUGUI | 59/99 |  |
| TaskBarRewardPanel/SafeArea/Content/All_Anim/Reward_Empty/TaskPopupTopBarItem/RightReward_Btn | UnityEngine.UI.Button |  |  |
| TaskBarRewardPanel/SafeArea/Content/All_Anim/Reward_Empty/TaskPopupTopBarItem/RightReward_Btn/RewardNum_Text | TMPro.TextMeshProUGUI | x1 |  |
| TaskBarRewardPanel/SafeArea/Content/All_Anim/Reward_Empty/Scroll View/Viewport/Content/Card_Empty_1/Gift_Img | UnityEngine.UI.Button |  |  |
| TaskBarRewardPanel/SafeArea/Content/All_Anim/Reward_Empty/Scroll View/Viewport/Content/Card_Empty_1/Gift_Img | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| TaskBarRewardPanel/SafeArea/Content/All_Anim/Reward_Empty/Scroll View/Viewport/Content/Card_Empty_1/Gift_Img/Gift_Text | TMPro.TextMeshProUGUI | x1 |  |
| TaskBarRewardPanel/SafeArea/Content/All_Anim/Reward_Empty/Scroll View/Viewport/Content/Card_Empty_1/BlueBtn_Img/Number_Empty | TMPro.TextMeshProUGUI | 5 |  |
| TaskBarRewardPanel/SafeArea/Content/All_Anim/Reward_Empty/Scroll View/Viewport/Content/Card_Empty_1/GreenBtn_Img/Number_Empty | TMPro.TextMeshProUGUI | 2 |  |
| TaskBarRewardPanel/SafeArea/Content/All_Anim/Reward_Empty/Bubble_Empty/GameObject | UnityEngine.UI.Button |  |  |
| TaskBarRewardPanel/SafeArea/Content/All_Anim/Reward_Empty/Bubble_Empty/BubbleUp_Empty/Info_Content/Bubble_Empty/Coin_Empty/Coin_Img/Reward_Text | TMPro.TextMeshProUGUI | 6 750 |  |
| TaskBarRewardPanel/SafeArea/Content/All_Anim/Reward_Empty/Bubble_Empty/BubbleUp_Empty/Info_Content/Bubble_Empty/Coin_Empty/Coin_Img/Reward_Text/Reward_Text_1 | TMPro.TextMeshProUGUI | 6 750 |  |
| TaskBarRewardPanel/SafeArea/Content/All_Anim/Reward_Empty/Bubble_Empty/BubbleUp_Empty/Info_Content/Bubble_Empty/Ball_Empty/Ball_Img/Reward_Text | TMPro.TextMeshProUGUI | ×5 |  |
| TaskBarRewardPanel/SafeArea/Content/All_Anim/Reward_Empty/Bubble_Empty/BubbleUp_Empty/Info_Content/Bubble_Empty/Ball_Empty/Ball_Img/Reward_Text/Reward_Text_1 | TMPro.TextMeshProUGUI | ×5 |  |
| TaskBarRewardPanel/SafeArea/Content/All_Anim/Reward_Empty/Bubble_Empty/BubbleUp_Empty/Info_Content/Bubble_Empty/Car_Empty/Car_Img/Reward_Text | TMPro.TextMeshProUGUI | ×5 |  |
| TaskBarRewardPanel/SafeArea/Content/All_Anim/Reward_Empty/Bubble_Empty/BubbleUp_Empty/Info_Content/Bubble_Empty/Car_Empty/Car_Img/Reward_Text/Reward_Text_1 | TMPro.TextMeshProUGUI | ×5 |  |
| TaskBarRewardPanel/SafeArea/Content/All_Anim/Reward_Empty/Bubble_Empty/BubbleUp_Empty/Info_Content/Bubble_Empty/Arrange_Empty/Arrange_Img/Reward_Text | TMPro.TextMeshProUGUI | ×5 |  |
| TaskBarRewardPanel/SafeArea/Content/All_Anim/Reward_Empty/Bubble_Empty/BubbleUp_Empty/Info_Content/Bubble_Empty/Arrange_Empty/Arrange_Img/Reward_Text/Reward_Text_1 | TMPro.TextMeshProUGUI | ×5 |  |
| TaskBarRewardPanel/SafeArea/Content/All_Anim/Reward_Empty/Bubble_Empty/BubbleDown_Empty/Info_Content/Bubble_Empty/Coin_Empty/Coin_Img/Reward_Text | TMPro.TextMeshProUGUI | 6 750 |  |
| TaskBarRewardPanel/SafeArea/Content/All_Anim/Reward_Empty/Bubble_Empty/BubbleDown_Empty/Info_Content/Bubble_Empty/Coin_Empty/Coin_Img/Reward_Text/Reward_Text_1 | TMPro.TextMeshProUGUI | 6 750 |  |
| TaskBarRewardPanel/SafeArea/Content/All_Anim/Reward_Empty/Bubble_Empty/BubbleDown_Empty/Info_Content/Bubble_Empty/Ball_Empty/Ball_Img/Reward_Text | TMPro.TextMeshProUGUI | ×5 |  |
| TaskBarRewardPanel/SafeArea/Content/All_Anim/Reward_Empty/Bubble_Empty/BubbleDown_Empty/Info_Content/Bubble_Empty/Ball_Empty/Ball_Img/Reward_Text/Reward_Text_1 | TMPro.TextMeshProUGUI | ×5 |  |
| TaskBarRewardPanel/SafeArea/Content/All_Anim/Reward_Empty/Bubble_Empty/BubbleDown_Empty/Info_Content/Bubble_Empty/Car_Empty/Car_Img/Reward_Text | TMPro.TextMeshProUGUI | ×5 |  |
| TaskBarRewardPanel/SafeArea/Content/All_Anim/Reward_Empty/Bubble_Empty/BubbleDown_Empty/Info_Content/Bubble_Empty/Car_Empty/Car_Img/Reward_Text/Reward_Text_1 | TMPro.TextMeshProUGUI | ×5 |  |
| TaskBarRewardPanel/SafeArea/Content/All_Anim/Reward_Empty/Bubble_Empty/BubbleDown_Empty/Info_Content/Bubble_Empty/Arrange_Empty/Arrange_Img/Reward_Text | TMPro.TextMeshProUGUI | ×5 |  |
| TaskBarRewardPanel/SafeArea/Content/All_Anim/Reward_Empty/Bubble_Empty/BubbleDown_Empty/Info_Content/Bubble_Empty/Arrange_Empty/Arrange_Img/Reward_Text/Reward_Text_1 | TMPro.TextMeshProUGUI | ×5 |  |
| TaskBarRewardPanel/SafeArea/Content/All_Anim/Top_Empty/TimeBg_Img/TimeNum_Text | TMPro.TextMeshProUGUI | {0} |  |
| TaskBarRewardPanel/SafeArea/Content/All_Anim/Top_Empty/TitleBg_Img/Title_Text | TMPro.TextMeshProUGUI | Color Journey |  |
| TaskBarRewardPanel/SafeArea/Content/All_Anim/Top_Empty/TitleBg_Img/Title_Text_Green | TMPro.TextMeshProUGUI | Color Journey |  |
| TaskBarRewardPanel/SafeArea/Content/All_Anim/Top_Empty/TitleBg_Img/Title_Text_Red | TMPro.TextMeshProUGUI | Color Journey |  |
| TaskBarRewardPanel/SafeArea/Content/All_Anim/Top_Empty/TitleBg_Img/Title_Text_Yellow | TMPro.TextMeshProUGUI | Color Journey |  |
| TaskBarRewardPanel/SafeArea/Content/All_Anim/Top_Empty/Info_Img | UnityEngine.UI.Button |  |  |
| TaskBarRewardPanel/SafeArea/Content/All_Anim/Top_Empty/Info_Img | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| TaskBarRewardPanel/SafeArea/Content/All_Anim/Top_Empty/Btn_Close | UnityEngine.UI.Button |  |  |
| TaskBarRewardPanel/SafeArea/Content/All_Anim/Top_Empty/Btn_Close | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
