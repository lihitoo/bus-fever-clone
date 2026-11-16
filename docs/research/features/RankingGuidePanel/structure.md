# RankingGuidePanel — cấu trúc UI

Bằng chứng: `file-observed`, XAPK 1.3.2/build 65. Chưa tự xác nhận panel này đã được mở khi chơi; xem hồ sơ runtime riêng.

Có 38 MonoBehaviour component; 11 component có liên kết media xuất được. [Bảng chi tiết](ui-elements.csv) chứa hierarchy, path ID, anchor/pivot, font/text, sprite, raycast và toàn bộ serialized fields. Tọa độ là dữ liệu prefab, chưa phải bounding box runtime.

| Hierarchy | Component | Text mặc định | Sprite |
| --- | --- | --- | --- |
| RankingGuidePanel/Mask_Img | UnityEngine.UI.Button |  |  |
| RankingGuidePanel/Mask_Img | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| RankingGuidePanel/All_Anim/Content2/All_Anim/Title_Text | TMPro.TextMeshProUGUI | Weekly Contest |  |
| RankingGuidePanel/All_Anim/Content2/All_Anim/Middle_Empty/Pic1_Empty/Intro_Text | TMPro.TextMeshProUGUI | Beat Levels Earn Points! |  |
| RankingGuidePanel/All_Anim/Content2/All_Anim/Middle_Empty/Pic2_Empty/Intro_Text | TMPro.TextMeshProUGUI | Take the Lead! |  |
| RankingGuidePanel/All_Anim/Content2/All_Anim/Middle_Empty/Pic3_Empty/Intro_Text | TMPro.TextMeshProUGUI | Win Rewards! |  |
| RankingGuidePanel/All_Anim/Content2/All_Anim/Tap_Text | TMPro.TextMeshProUGUI | Tap to Continue |  |
