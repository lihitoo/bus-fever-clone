# DailybonusPanel — cấu trúc UI

Bằng chứng: `file-observed`, XAPK 1.3.2/build 65. Chưa tự xác nhận panel này đã được mở khi chơi; xem hồ sơ runtime riêng.

Có 218 MonoBehaviour component; 104 component có liên kết media xuất được. [Bảng chi tiết](ui-elements.csv) chứa hierarchy, path ID, anchor/pivot, font/text, sprite, raycast và toàn bộ serialized fields. Tọa độ là dữ liệu prefab, chưa phải bounding box runtime.

| Hierarchy | Component | Text mặc định | Sprite |
| --- | --- | --- | --- |
| DailybonusPanel/SafeArea/All_Anim/Title_Text | TMPro.TextMeshProUGUI | Daily Bonus |  |
| DailybonusPanel/SafeArea/All_Anim/Btn_Close | UnityEngine.UI.Button |  |  |
| DailybonusPanel/SafeArea/All_Anim/Btn_Close | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| DailybonusPanel/SafeArea/All_Anim/7Days_Empty/Day1/Normal_Btn/Day_Text | TMPro.TextMeshProUGUI | Day {0} |  |
| DailybonusPanel/SafeArea/All_Anim/7Days_Empty/Day1/Finish_Btn/Day_Text | TMPro.TextMeshProUGUI | Day {0} |  |
| DailybonusPanel/SafeArea/All_Anim/7Days_Empty/Day1/Pick_Btn/Day_Text | TMPro.TextMeshProUGUI | Day {0} |  |
| DailybonusPanel/SafeArea/All_Anim/7Days_Empty/Day1/Reward_Empty/Number_Text_1 | TMPro.TextMeshProUGUI | 50 |  |
| DailybonusPanel/SafeArea/All_Anim/7Days_Empty/Day1/Reward_Img/Reward_1/Reward_Img_1/Number_Text | TMPro.TextMeshProUGUI | 50 |  |
| DailybonusPanel/SafeArea/All_Anim/7Days_Empty/Day1/Button | UnityEngine.UI.Button |  |  |
| DailybonusPanel/SafeArea/All_Anim/7Days_Empty/Day1/Button | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| DailybonusPanel/SafeArea/All_Anim/7Days_Empty/Day2/Normal_Btn/Day_Text | TMPro.TextMeshProUGUI | Day {0} |  |
| DailybonusPanel/SafeArea/All_Anim/7Days_Empty/Day2/Finish_Btn/Day_Text | TMPro.TextMeshProUGUI | Day {0} |  |
| DailybonusPanel/SafeArea/All_Anim/7Days_Empty/Day2/Pick_Btn/Day_Text | TMPro.TextMeshProUGUI | Day {0} |  |
| DailybonusPanel/SafeArea/All_Anim/7Days_Empty/Day2/Reward_Empty/Number_Text_1 | TMPro.TextMeshProUGUI | x1 |  |
| DailybonusPanel/SafeArea/All_Anim/7Days_Empty/Day2/Reward_Img/Reward_1/Reward_Img_1/Number_Text | TMPro.TextMeshProUGUI | x1 |  |
| DailybonusPanel/SafeArea/All_Anim/7Days_Empty/Day2/Button | UnityEngine.UI.Button |  |  |
| DailybonusPanel/SafeArea/All_Anim/7Days_Empty/Day2/Button | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| DailybonusPanel/SafeArea/All_Anim/7Days_Empty/Day3/Normal_Btn/Day_Text | TMPro.TextMeshProUGUI | Day {0} |  |
| DailybonusPanel/SafeArea/All_Anim/7Days_Empty/Day3/Finish_Btn/Day_Text | TMPro.TextMeshProUGUI | Day {0} |  |
| DailybonusPanel/SafeArea/All_Anim/7Days_Empty/Day3/Pick_Btn/Day_Text | TMPro.TextMeshProUGUI | Day {0} |  |
| DailybonusPanel/SafeArea/All_Anim/7Days_Empty/Day3/Reward_Empty/Number_Text_1 | TMPro.TextMeshProUGUI | 75 |  |
| DailybonusPanel/SafeArea/All_Anim/7Days_Empty/Day3/Reward_Img/Reward_1/Reward_Img_1/Number_Text | TMPro.TextMeshProUGUI | 75 |  |
| DailybonusPanel/SafeArea/All_Anim/7Days_Empty/Day3/Button | UnityEngine.UI.Button |  |  |
| DailybonusPanel/SafeArea/All_Anim/7Days_Empty/Day3/Button | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| DailybonusPanel/SafeArea/All_Anim/7Days_Empty/Day4/Normal_Btn/Day_Text | TMPro.TextMeshProUGUI | Day {0} |  |
| DailybonusPanel/SafeArea/All_Anim/7Days_Empty/Day4/Finish_Btn/Day_Text | TMPro.TextMeshProUGUI | Day {0} |  |
| DailybonusPanel/SafeArea/All_Anim/7Days_Empty/Day4/Pick_Btn/Day_Text | TMPro.TextMeshProUGUI | Day {0} |  |
| DailybonusPanel/SafeArea/All_Anim/7Days_Empty/Day4/Reward_Empty/Number_Text_1 | TMPro.TextMeshProUGUI | x1 |  |
| DailybonusPanel/SafeArea/All_Anim/7Days_Empty/Day4/Reward_Img/Reward_1/Reward_Img_1/Number_Text | TMPro.TextMeshProUGUI | x1 |  |
| DailybonusPanel/SafeArea/All_Anim/7Days_Empty/Day4/Button | UnityEngine.UI.Button |  |  |
| DailybonusPanel/SafeArea/All_Anim/7Days_Empty/Day4/Button | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| DailybonusPanel/SafeArea/All_Anim/7Days_Empty/Day5/Normal_Btn/Day_Text | TMPro.TextMeshProUGUI | Day {0} |  |
| DailybonusPanel/SafeArea/All_Anim/7Days_Empty/Day5/Finish_Btn/Day_Text | TMPro.TextMeshProUGUI | Day {0} |  |
| DailybonusPanel/SafeArea/All_Anim/7Days_Empty/Day5/Pick_Btn/Day_Text | TMPro.TextMeshProUGUI | Day {0} |  |
| DailybonusPanel/SafeArea/All_Anim/7Days_Empty/Day5/Reward_Empty/Number_Text_1 | TMPro.TextMeshProUGUI | 150 |  |
| DailybonusPanel/SafeArea/All_Anim/7Days_Empty/Day5/Reward_Img/Reward_1/Reward_Img_1/Number_Text | TMPro.TextMeshProUGUI | 150 |  |
| DailybonusPanel/SafeArea/All_Anim/7Days_Empty/Day5/Button | UnityEngine.UI.Button |  |  |
| DailybonusPanel/SafeArea/All_Anim/7Days_Empty/Day5/Button | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| DailybonusPanel/SafeArea/All_Anim/7Days_Empty/Day6/Normal_Btn/Day_Text | TMPro.TextMeshProUGUI | Day {0} |  |
| DailybonusPanel/SafeArea/All_Anim/7Days_Empty/Day6/Finish_Btn/Day_Text | TMPro.TextMeshProUGUI | Day {0} |  |
| DailybonusPanel/SafeArea/All_Anim/7Days_Empty/Day6/Pick_Btn/Day_Text | TMPro.TextMeshProUGUI | Day {0} |  |
| DailybonusPanel/SafeArea/All_Anim/7Days_Empty/Day6/Reward_Empty/Number_Text_1 | TMPro.TextMeshProUGUI | x1 |  |
| DailybonusPanel/SafeArea/All_Anim/7Days_Empty/Day6/Reward_Img/Reward_1/Reward_Img_1/Number_Text | TMPro.TextMeshProUGUI | x1 |  |
| DailybonusPanel/SafeArea/All_Anim/7Days_Empty/Day6/Button | UnityEngine.UI.Button |  |  |
| DailybonusPanel/SafeArea/All_Anim/7Days_Empty/Day6/Button | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| DailybonusPanel/SafeArea/All_Anim/7Days_Empty/DaySpecial7/Normal_Btn/Day_Text | TMPro.TextMeshProUGUI | Day {0} |  |
| DailybonusPanel/SafeArea/All_Anim/7Days_Empty/DaySpecial7/Finish_Btn/Day_Text | TMPro.TextMeshProUGUI | Day {0} |  |
| DailybonusPanel/SafeArea/All_Anim/7Days_Empty/DaySpecial7/Pick_Btn/Day_Text | TMPro.TextMeshProUGUI | Day {0} |  |
| DailybonusPanel/SafeArea/All_Anim/7Days_Empty/DaySpecial7/Reward_Empty/Reward1_Empty/Number_Text | TMPro.TextMeshProUGUI | 500 |  |
| DailybonusPanel/SafeArea/All_Anim/7Days_Empty/DaySpecial7/Reward_Empty/Reward2_Empty/Number_Text | TMPro.TextMeshProUGUI | x1 |  |
| DailybonusPanel/SafeArea/All_Anim/7Days_Empty/DaySpecial7/Reward_Img/Reward_1/Reward_Img_1/Number_Text_1 | TMPro.TextMeshProUGUI | 500 |  |
| DailybonusPanel/SafeArea/All_Anim/7Days_Empty/DaySpecial7/Reward_Img/Reward_2/Reward_Img_1/Number_Text_1 | TMPro.TextMeshProUGUI | 500 |  |
| DailybonusPanel/SafeArea/All_Anim/7Days_Empty/DaySpecial7/Reward_Img/Reward_2/Reward_Img_2/Number_Text_1 | TMPro.TextMeshProUGUI | x1 |  |
| DailybonusPanel/SafeArea/All_Anim/7Days_Empty/DaySpecial7/Button | UnityEngine.UI.Button |  |  |
| DailybonusPanel/SafeArea/All_Anim/7Days_Empty/DaySpecial7/Button | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| DailybonusPanel/SafeArea/All_Anim/Btn_Green | UnityEngine.UI.Button |  |  |
| DailybonusPanel/SafeArea/All_Anim/Btn_Green | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| DailybonusPanel/SafeArea/All_Anim/Btn_Green/UP_Empty/Prop_Text | TMPro.TextMeshProUGUI | Claim |  |
| DailybonusPanel/SafeArea/All_Anim/Btn_Grey | UnityEngine.UI.Button |  |  |
| DailybonusPanel/SafeArea/All_Anim/Btn_Grey | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| DailybonusPanel/SafeArea/All_Anim/Btn_Grey/UP_Empty/Prop_Text | TMPro.TextMeshProUGUI | Claimed |  |
