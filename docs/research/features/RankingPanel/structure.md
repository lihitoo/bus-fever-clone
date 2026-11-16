# RankingPanel — cấu trúc UI

Bằng chứng: `file-observed`, XAPK 1.3.2/build 65. Chưa tự xác nhận panel này đã được mở khi chơi; xem hồ sơ runtime riêng.

Có 130 MonoBehaviour component; 52 component có liên kết media xuất được. [Bảng chi tiết](ui-elements.csv) chứa hierarchy, path ID, anchor/pivot, font/text, sprite, raycast và toàn bộ serialized fields. Tọa độ là dữ liệu prefab, chưa phải bounding box runtime.

| Hierarchy | Component | Text mặc định | Sprite |
| --- | --- | --- | --- |
| RankingPanel/All/WeeklyRoot/Top3_Empty/Top3Podium_Empty/Top1Name_Text | TMPro.TextMeshProUGUI | CERULEAN |  |
| RankingPanel/All/WeeklyRoot/Top3_Empty/Top3Podium_Empty/Top2Name_Text | TMPro.TextMeshProUGUI | HUNDREDX |  |
| RankingPanel/All/WeeklyRoot/Top3_Empty/Top3Podium_Empty/Top3Name_Text | TMPro.TextMeshProUGUI | July |  |
| RankingPanel/All/WeeklyRoot/WeeklyListBg/Bubble/RewardRoot/Bg/RankingRewardItem/Amount | TMPro.TextMeshProUGUI | ×3 |  |
| RankingPanel/All/WeeklyRoot/WeeklyListBg/Bubble/RewardRoot/Bg/RankingRewardItem_1/Amount | TMPro.TextMeshProUGUI | ×3 |  |
| RankingPanel/All/WeeklyRoot/WeeklyListBg/Bubble/RewardRoot/Bg/RankingRewardItem_2/Amount | TMPro.TextMeshProUGUI | ×3 |  |
| RankingPanel/All/GlobalRoot/GlobalListBg/GlobalList/Content/BottomLoading_Empty/Loading_Text | TMPro.TextMeshProUGUI | Loading... |  |
| RankingPanel/All/GlobalRoot/GlobalListBg/SelfRankingItem/RankingNum_Empty/Rank_Text_Normal | TMPro.TextMeshProUGUI | 4 |  |
| RankingPanel/All/GlobalRoot/GlobalListBg/SelfRankingItem/RankingNum_Empty/Rank_Text_First | TMPro.TextMeshProUGUI | 1 |  |
| RankingPanel/All/GlobalRoot/GlobalListBg/SelfRankingItem/RankingNum_Empty/Rank_Text_Second | TMPro.TextMeshProUGUI | 2 |  |
| RankingPanel/All/GlobalRoot/GlobalListBg/SelfRankingItem/RankingNum_Empty/Rank_Text_Third | TMPro.TextMeshProUGUI | 3 |  |
| RankingPanel/All/GlobalRoot/GlobalListBg/SelfRankingItem/Name_Text | TMPro.TextMeshProUGUI | UserName4 |  |
| RankingPanel/All/GlobalRoot/GlobalListBg/SelfRankingItem/ScoreNum_Text | TMPro.TextMeshProUGUI | 131 |  |
| RankingPanel/All/GlobalRoot/GlobalListBg/SelfRankingItem/Score_Text | TMPro.TextMeshProUGUI | Score |  |
| RankingPanel/All/GlobalRoot/GlobalListBg/SelfRankingItem/Gift_Btn | UnityEngine.UI.Button |  |  |
| RankingPanel/All/GlobalRoot/GlobalListBg/SelfRankingItem/Gift_Btn | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| RankingPanel/All/GlobalRoot/GlobalListBg/NoInternet/Txt | TMPro.TextMeshProUGUI | No Internet...Try Later! |  |
| RankingPanel/All/GlobalRoot/GlobalListBg/Loading/Txt | TMPro.TextMeshProUGUI | Loading... |  |
| RankingPanel/All/GlobalRoot/GlobalListBg/RightBottom_Empty/Btn_Up | UnityEngine.UI.Button |  |  |
| RankingPanel/All/GlobalRoot/GlobalListBg/RightBottom_Empty/Btn_Up | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| RankingPanel/All/GlobalRoot/GlobalListBg/RightBottom_Empty/Btn_Bottom | UnityEngine.UI.Button |  |  |
| RankingPanel/All/GlobalRoot/GlobalListBg/RightBottom_Empty/Btn_Bottom | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| RankingPanel/All/Top_Empty/Btn_Close | UnityEngine.UI.Button |  |  |
| RankingPanel/All/Top_Empty/Btn_Close | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| RankingPanel/All/Top_Empty/Btns_Empty/WeeklyCountdown/Time_Text | TMPro.TextMeshProUGUI | 5d22h |  |
| RankingPanel/All/Top_Empty/Btns_Empty/Weekly | UnityEngine.UI.Button |  |  |
| RankingPanel/All/Top_Empty/Btns_Empty/Weekly | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| RankingPanel/All/Top_Empty/Btns_Empty/Weekly/Text | TMPro.TextMeshProUGUI | Weekly |  |
| RankingPanel/All/Top_Empty/Btns_Empty/Global | UnityEngine.UI.Button |  |  |
| RankingPanel/All/Top_Empty/Btns_Empty/Global | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| RankingPanel/All/Top_Empty/Btns_Empty/Global/Text | TMPro.TextMeshProUGUI | Players |  |
| RankingPanel/All/Top_Empty/Btns_Empty/Info_Btn | UnityEngine.UI.Button |  |  |
| RankingPanel/All/Top_Empty/Btns_Empty/Info_Btn | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| RankingPanel/All/Lock_Empty/Lock_Text | TMPro.TextMeshProUGUI | Reach level 29 to unlock Leaderboard! |  |
| RankingPanel/All/Title_Empty/Title_Text | TMPro.TextMeshProUGUI | Leaderboard |  |
