# TaskBarPromoPanel — cấu trúc UI

Bằng chứng: `file-observed`, XAPK 1.3.2/build 65. Chưa tự xác nhận panel này đã được mở khi chơi; xem hồ sơ runtime riêng.

Có 94 MonoBehaviour component; 24 component có liên kết media xuất được. [Bảng chi tiết](ui-elements.csv) chứa hierarchy, path ID, anchor/pivot, font/text, sprite, raycast và toàn bộ serialized fields. Tọa độ là dữ liệu prefab, chưa phải bounding box runtime.

| Hierarchy | Component | Text mặc định | Sprite |
| --- | --- | --- | --- |
| TaskBarPromoPanel/SafeArea/Content/All_Anim/Bg_Img/TimeBg_Img/TimeNum_Text | TMPro.TextMeshProUGUI | {0} |  |
| TaskBarPromoPanel/SafeArea/Content/All_Anim/Bg_Img/TitleBg_Img/Title_Text | TMPro.TextMeshProUGUI | Color Journey |  |
| TaskBarPromoPanel/SafeArea/Content/All_Anim/Bg_Img/TitleBg_Img/Title_Text_Green | TMPro.TextMeshProUGUI | Color Journey |  |
| TaskBarPromoPanel/SafeArea/Content/All_Anim/Bg_Img/TitleBg_Img/Title_Text_Yellow | TMPro.TextMeshProUGUI | Color Journey |  |
| TaskBarPromoPanel/SafeArea/Content/All_Anim/Bg_Img/TitleBg_Img/Title_Text_Red | TMPro.TextMeshProUGUI | Color Journey |  |
| TaskBarPromoPanel/SafeArea/Content/All_Anim/Bg_Img/Info_Img | UnityEngine.UI.Button |  |  |
| TaskBarPromoPanel/SafeArea/Content/All_Anim/Bg_Img/Info_Img | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| TaskBarPromoPanel/SafeArea/Content/All_Anim/Bg_Img/Btn_Close | UnityEngine.UI.Button |  |  |
| TaskBarPromoPanel/SafeArea/Content/All_Anim/Bg_Img/Btn_Close | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| TaskBarPromoPanel/SafeArea/Content/All_Anim/Bg_Img/TaskPopupTopBarItem/ProgressNum_Text | TMPro.TextMeshProUGUI | 59/99 |  |
| TaskBarPromoPanel/SafeArea/Content/All_Anim/Bg_Img/TaskPopupTopBarItem/RightReward_Btn | UnityEngine.UI.Button |  |  |
| TaskBarPromoPanel/SafeArea/Content/All_Anim/Bg_Img/TaskPopupTopBarItem/RightReward_Btn/RewardNum_Text | TMPro.TextMeshProUGUI | x1 |  |
| TaskBarPromoPanel/SafeArea/Content/All_Anim/Bg_Img/IntroTextBg_Img/Intro_Text | TMPro.TextMeshProUGUI | Complete all stages to win the Grand Prize! |  |
| TaskBarPromoPanel/SafeArea/Content/All_Anim/Bg_Img/IntroTextBg_Img/Intro_Text_Green | TMPro.TextMeshProUGUI | Complete all stages to win the Grand Prize! |  |
| TaskBarPromoPanel/SafeArea/Content/All_Anim/Bg_Img/IntroTextBg_Img/Intro_Text_Yellow | TMPro.TextMeshProUGUI | Complete all stages to win the Grand Prize! |  |
| TaskBarPromoPanel/SafeArea/Content/All_Anim/Bg_Img/IntroTextBg_Img/Intro_Text_Red | TMPro.TextMeshProUGUI | Complete all stages to win the Grand Prize! |  |
| TaskBarPromoPanel/SafeArea/Content/All_Anim/Bg_Img/Play_Btn | UnityEngine.UI.Button |  |  |
| TaskBarPromoPanel/SafeArea/Content/All_Anim/Bg_Img/Play_Btn | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| TaskBarPromoPanel/SafeArea/Content/All_Anim/Bg_Img/Play_Btn/UP_Empty/Prop_Text | TMPro.TextMeshProUGUI | Play |  |
