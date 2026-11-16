# DailySpin — cấu trúc UI

Bằng chứng: `file-observed`, XAPK 1.3.2/build 65. Chưa tự xác nhận panel này đã được mở khi chơi; xem hồ sơ runtime riêng.

Có 191 MonoBehaviour component; 90 component có liên kết media xuất được. [Bảng chi tiết](ui-elements.csv) chứa hierarchy, path ID, anchor/pivot, font/text, sprite, raycast và toàn bộ serialized fields. Tọa độ là dữ liệu prefab, chưa phải bounding box runtime.

| Hierarchy | Component | Text mặc định | Sprite |
| --- | --- | --- | --- |
| DailySpin/All_Anim/ScreenAdapter/Spin_Empty_Free/Tiltle_Text | TMPro.TextMeshProUGUI | Lucky Spin |  |
| DailySpin/All_Anim/ScreenAdapter/Spin_Empty_Free/Spin_Control/Spin_Empty/AniRotation/Emptys/Award1/RewardState_Group/All_Empty/FreeSpin_Text | TMPro.TextMeshProUGUI | x1 |  |
| DailySpin/All_Anim/ScreenAdapter/Spin_Empty_Free/Spin_Control/Spin_Empty/AniRotation/Emptys/Award2/RewardState_Group/All_Empty/FreeSpin_Text | TMPro.TextMeshProUGUI | 500 |  |
| DailySpin/All_Anim/ScreenAdapter/Spin_Empty_Free/Spin_Control/Spin_Empty/AniRotation/Emptys/Award3/RewardState_Group/All_Empty/FreeSpin_Text | TMPro.TextMeshProUGUI | x1 |  |
| DailySpin/All_Anim/ScreenAdapter/Spin_Empty_Free/Spin_Control/Spin_Empty/AniRotation/Emptys/Award4/RewardState_Group/All_Empty/FreeSpin_Text | TMPro.TextMeshProUGUI | 150 |  |
| DailySpin/All_Anim/ScreenAdapter/Spin_Empty_Free/Spin_Control/Spin_Empty/AniRotation/Emptys/Award5/RewardState_Group/All_Empty/FreeSpin_Text | TMPro.TextMeshProUGUI | x1 |  |
| DailySpin/All_Anim/ScreenAdapter/Spin_Empty_Free/Spin_Control/Spin_Empty/AniRotation/Emptys/Award6/RewardState_Group/All_Empty/FreeSpin_Text | TMPro.TextMeshProUGUI | 30 |  |
| DailySpin/All_Anim/ScreenAdapter/Spin_Empty_Free/Button_Control/Spin_Control/Active_Btn | ModuleCollection.Spin.Button_Pro |  |  |
| DailySpin/All_Anim/ScreenAdapter/Spin_Empty_Free/Button_Control/Spin_Control/Active_Btn | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| DailySpin/All_Anim/ScreenAdapter/Spin_Empty_Free/Button_Control/Spin_Control/Active_Btn/UP_Empty/FreeSpin_Text | TMPro.TextMeshProUGUI | Spin |  |
| DailySpin/All_Anim/ScreenAdapter/Spin_Empty_Free/Button_Control/Spin_Control/DisActive_Btn | ModuleCollection.Spin.Button_Pro |  |  |
| DailySpin/All_Anim/ScreenAdapter/Spin_Empty_Free/Button_Control/Spin_Control/DisActive_Btn | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| DailySpin/All_Anim/ScreenAdapter/Spin_Empty_Free/Button_Control/Spin_Control/DisActive_Btn/UP_Empty/NoNetwork_Text | TMPro.TextMeshProUGUI | Spin |  |
| DailySpin/All_Anim/ScreenAdapter/Spin_Empty_Free/Button_Control/Spin_Control/AdsActive_Btn | ModuleCollection.Spin.Button_Pro |  |  |
| DailySpin/All_Anim/ScreenAdapter/Spin_Empty_Free/Button_Control/Spin_Control/AdsActive_Btn | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| DailySpin/All_Anim/ScreenAdapter/Spin_Empty_Free/Button_Control/Spin_Control/AdsActive_Btn/UP_Empty/Free_Empty/Free_Text | TMPro.TextMeshProUGUI | Free |  |
| DailySpin/All_Anim/ScreenAdapter/Spin_Empty_Free/Quit_Control/Quit_Btn | ModuleCollection.Spin.Button_Pro |  |  |
| DailySpin/All_Anim/ScreenAdapter/Spin_Empty_Free/Quit_Control/Quit_Btn | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| DailySpin/All_Anim/ScreenAdapter/Middle_Empty/Message_Control/Message_Btn | ModuleCollection.Spin.Button_Pro |  |  |
| DailySpin/All_Anim/ScreenAdapter/Middle_Empty/Message_Control/Message_Btn | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| DailySpin/All_Anim/ScreenAdapter/Middle_Empty/Time_Text | TMPro.TextMeshProUGUI | Next free spin in <color=#fff000>{0}</color>. |  |
| DailySpin/All_Anim/ScreenAdapter/Middle_Empty/Hint_Text | TMPro.TextMeshProUGUI | <color=#affeff>Win 10 levels to spin</color> |  |
| DailySpin/All_Anim/ScreenAdapter/Middle_Empty/Bar_Empty/Progress_Text | TMPro.TextMeshProUGUI | 2/5 |  |
| DailySpin/All_Anim/ScreenAdapter/ChanceDetails/All_Empty/Title_Text | TMPro.TextMeshProUGUI | Prob. |  |
| DailySpin/All_Anim/ScreenAdapter/ChanceDetails/All_Empty/Title_Text/Title1_Text | TMPro.TextMeshProUGUI | Prob. |  |
| DailySpin/All_Anim/ScreenAdapter/ChanceDetails/All_Empty/Quit_Btn | ModuleCollection.Spin.Button_Pro |  |  |
| DailySpin/All_Anim/ScreenAdapter/ChanceDetails/All_Empty/Quit_Btn | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| DailySpin/All_Anim/ScreenAdapter/ChanceDetails/All_Empty/DailySpin_Empty/Award_Group/Award1/SpinRateItem/All_Empty/Number/1_Text | TMPro.TextMeshProUGUI | 500 |  |
| DailySpin/All_Anim/ScreenAdapter/ChanceDetails/All_Empty/DailySpin_Empty/Award_Group/Award1/SpinRateItem/Probability_Text | TMPro.TextMeshProUGUI | 1.00% |  |
| DailySpin/All_Anim/ScreenAdapter/ChanceDetails/All_Empty/DailySpin_Empty/Award_Group/Award2/SpinRateItem/All_Empty/Number/1_Text | TMPro.TextMeshProUGUI | x1 |  |
| DailySpin/All_Anim/ScreenAdapter/ChanceDetails/All_Empty/DailySpin_Empty/Award_Group/Award2/SpinRateItem/Probability_Text | TMPro.TextMeshProUGUI | 8.00% |  |
| DailySpin/All_Anim/ScreenAdapter/ChanceDetails/All_Empty/DailySpin_Empty/Award_Group/Award3/SpinRateItem/All_Empty/Number/1_Text | TMPro.TextMeshProUGUI | x1 |  |
| DailySpin/All_Anim/ScreenAdapter/ChanceDetails/All_Empty/DailySpin_Empty/Award_Group/Award3/SpinRateItem/Probability_Text | TMPro.TextMeshProUGUI | 8.00% |  |
| DailySpin/All_Anim/ScreenAdapter/ChanceDetails/All_Empty/DailySpin_Empty/Award_Group/Award4/SpinRateItem/All_Empty/Number/1_Text | TMPro.TextMeshProUGUI | x1 |  |
| DailySpin/All_Anim/ScreenAdapter/ChanceDetails/All_Empty/DailySpin_Empty/Award_Group/Award4/SpinRateItem/Probability_Text | TMPro.TextMeshProUGUI | 8.00% |  |
| DailySpin/All_Anim/ScreenAdapter/ChanceDetails/All_Empty/DailySpin_Empty/Award_Group/Award5/SpinRateItem/All_Empty/Number/1_Text | TMPro.TextMeshProUGUI | 30 |  |
| DailySpin/All_Anim/ScreenAdapter/ChanceDetails/All_Empty/DailySpin_Empty/Award_Group/Award5/SpinRateItem/Probability_Text | TMPro.TextMeshProUGUI | 25.00% |  |
| DailySpin/All_Anim/ScreenAdapter/ChanceDetails/All_Empty/DailySpin_Empty/Award_Group/Award6/SpinRateItem/All_Empty/Number/1_Text | TMPro.TextMeshProUGUI | 150 |  |
| DailySpin/All_Anim/ScreenAdapter/ChanceDetails/All_Empty/DailySpin_Empty/Award_Group/Award6/SpinRateItem/Probability_Text | TMPro.TextMeshProUGUI | 50.00% |  |
| DailySpin/RewardPanel/All_Anim/SafeArea/Title_Empty/Title_Text_1 | TMPro.TextMeshProUGUI | Lucky  Reward |  |
| DailySpin/RewardPanel/All_Anim/SafeArea/Title_Empty/Title_Text | TMPro.TextMeshProUGUI | Lucky  Reward |  |
| DailySpin/RewardPanel/All_Anim/SafeArea/Reward_Empty/FreeSpin_Text | TMPro.TextMeshProUGUI | 150 |  |
| DailySpin/RewardPanel/All_Anim/SafeArea/Bottom_Empty/Title_Text_8 | TMPro.TextMeshProUGUI | Tap to Claim |  |
| DailySpin/RewardPanel/All_Anim/SafeArea/Bottom_Empty/Title_Text_8/Title_Text_3 | TMPro.TextMeshProUGUI | Tap to Claim |  |
| DailySpin/RewardPanel/Mask_Btn | UnityEngine.UI.Button |  |  |
