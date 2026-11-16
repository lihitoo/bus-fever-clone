# RankingRewardPanel — cấu trúc UI

Bằng chứng: `file-observed`, XAPK 1.3.2/build 65. Chưa tự xác nhận panel này đã được mở khi chơi; xem hồ sơ runtime riêng.

Có 209 MonoBehaviour component; 80 component có liên kết media xuất được. [Bảng chi tiết](ui-elements.csv) chứa hierarchy, path ID, anchor/pivot, font/text, sprite, raycast và toàn bộ serialized fields. Tọa độ là dữ liệu prefab, chưa phải bounding box runtime.

| Hierarchy | Component | Text mặc định | Sprite |
| --- | --- | --- | --- |
| RankingRewardPanel/SafeArea/Content/Title_Text | TMPro.TextMeshProUGUI | Weekly Rank |  |
| RankingRewardPanel/SafeArea/Content/RankingMove_Empty/TopTip_Text | TMPro.TextMeshProUGUI | Nice job! You finished #4 last week. |  |
| RankingRewardPanel/SafeArea/Content/RankingMove_Empty/Top3Podium_Empty/Top1Name_Text | TMPro.TextMeshProUGUI | CERULEAN |  |
| RankingRewardPanel/SafeArea/Content/RankingMove_Empty/Top3Podium_Empty/Top2Name_Text | TMPro.TextMeshProUGUI | HUNDREDX |  |
| RankingRewardPanel/SafeArea/Content/RankingMove_Empty/Top3Podium_Empty/Top3Name_Text | TMPro.TextMeshProUGUI | July |  |
| RankingRewardPanel/SafeArea/Content/RankingMove_Empty/RankingList/Content/RankingItem_Empty/RankingItem/RankingNum_Empty/Rank_Text_Normal | TMPro.TextMeshProUGUI | 4 |  |
| RankingRewardPanel/SafeArea/Content/RankingMove_Empty/RankingList/Content/RankingItem_Empty/RankingItem/RankingNum_Empty/Rank_Text_First | TMPro.TextMeshProUGUI | 1 |  |
| RankingRewardPanel/SafeArea/Content/RankingMove_Empty/RankingList/Content/RankingItem_Empty/RankingItem/RankingNum_Empty/Rank_Text_Second | TMPro.TextMeshProUGUI | 2 |  |
| RankingRewardPanel/SafeArea/Content/RankingMove_Empty/RankingList/Content/RankingItem_Empty/RankingItem/RankingNum_Empty/Rank_Text_Third | TMPro.TextMeshProUGUI | 3 |  |
| RankingRewardPanel/SafeArea/Content/RankingMove_Empty/RankingList/Content/RankingItem_Empty/RankingItem/Name_Text | TMPro.TextMeshProUGUI | UserName4 |  |
| RankingRewardPanel/SafeArea/Content/RankingMove_Empty/RankingList/Content/RankingItem_Empty/RankingItem/ScoreNum_Text | TMPro.TextMeshProUGUI | 131 |  |
| RankingRewardPanel/SafeArea/Content/RankingMove_Empty/RankingList/Content/RankingItem_Empty/RankingItem/Score_Text | TMPro.TextMeshProUGUI | Score |  |
| RankingRewardPanel/SafeArea/Content/RankingMove_Empty/RankingList/Content/RankingItem_Empty/RankingItem/Gift_Btn | UnityEngine.UI.Button |  |  |
| RankingRewardPanel/SafeArea/Content/RankingMove_Empty/RankingList/Content/RankingItem_Empty/RankingItem/Gift_Btn | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| RankingRewardPanel/SafeArea/Content/RankingMove_Empty/RankingList/Content/RankingItem_Empty_1/RankingItem_1/RankingNum_Empty/Rank_Text_Normal | TMPro.TextMeshProUGUI | 5 |  |
| RankingRewardPanel/SafeArea/Content/RankingMove_Empty/RankingList/Content/RankingItem_Empty_1/RankingItem_1/RankingNum_Empty/Rank_Text_First | TMPro.TextMeshProUGUI | 1 |  |
| RankingRewardPanel/SafeArea/Content/RankingMove_Empty/RankingList/Content/RankingItem_Empty_1/RankingItem_1/RankingNum_Empty/Rank_Text_Second | TMPro.TextMeshProUGUI | 2 |  |
| RankingRewardPanel/SafeArea/Content/RankingMove_Empty/RankingList/Content/RankingItem_Empty_1/RankingItem_1/RankingNum_Empty/Rank_Text_Third | TMPro.TextMeshProUGUI | 3 |  |
| RankingRewardPanel/SafeArea/Content/RankingMove_Empty/RankingList/Content/RankingItem_Empty_1/RankingItem_1/Name_Text | TMPro.TextMeshProUGUI | UserName4 |  |
| RankingRewardPanel/SafeArea/Content/RankingMove_Empty/RankingList/Content/RankingItem_Empty_1/RankingItem_1/ScoreNum_Text | TMPro.TextMeshProUGUI | 131 |  |
| RankingRewardPanel/SafeArea/Content/RankingMove_Empty/RankingList/Content/RankingItem_Empty_1/RankingItem_1/Score_Text | TMPro.TextMeshProUGUI | Score |  |
| RankingRewardPanel/SafeArea/Content/RankingMove_Empty/RankingList/Content/RankingItem_Empty_1/RankingItem_1/Gift_Btn | UnityEngine.UI.Button |  |  |
| RankingRewardPanel/SafeArea/Content/RankingMove_Empty/RankingList/Content/RankingItem_Empty_1/RankingItem_1/Gift_Btn | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| RankingRewardPanel/SafeArea/Content/RankingMove_Empty/RankingList/Content/RankingItem_Empty_2/RankingItem_2/RankingNum_Empty/Rank_Text_Normal | TMPro.TextMeshProUGUI | 6 |  |
| RankingRewardPanel/SafeArea/Content/RankingMove_Empty/RankingList/Content/RankingItem_Empty_2/RankingItem_2/RankingNum_Empty/Rank_Text_First | TMPro.TextMeshProUGUI | 1 |  |
| RankingRewardPanel/SafeArea/Content/RankingMove_Empty/RankingList/Content/RankingItem_Empty_2/RankingItem_2/RankingNum_Empty/Rank_Text_Second | TMPro.TextMeshProUGUI | 2 |  |
| RankingRewardPanel/SafeArea/Content/RankingMove_Empty/RankingList/Content/RankingItem_Empty_2/RankingItem_2/RankingNum_Empty/Rank_Text_Third | TMPro.TextMeshProUGUI | 3 |  |
| RankingRewardPanel/SafeArea/Content/RankingMove_Empty/RankingList/Content/RankingItem_Empty_2/RankingItem_2/Name_Text | TMPro.TextMeshProUGUI | UserName4 |  |
| RankingRewardPanel/SafeArea/Content/RankingMove_Empty/RankingList/Content/RankingItem_Empty_2/RankingItem_2/ScoreNum_Text | TMPro.TextMeshProUGUI | 131 |  |
| RankingRewardPanel/SafeArea/Content/RankingMove_Empty/RankingList/Content/RankingItem_Empty_2/RankingItem_2/Score_Text | TMPro.TextMeshProUGUI | Score |  |
| RankingRewardPanel/SafeArea/Content/RankingMove_Empty/RankingList/Content/RankingItem_Empty_2/RankingItem_2/Gift_Btn | UnityEngine.UI.Button |  |  |
| RankingRewardPanel/SafeArea/Content/RankingMove_Empty/RankingList/Content/RankingItem_Empty_2/RankingItem_2/Gift_Btn | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| RankingRewardPanel/SafeArea/Content/RankingMove_Empty/RankingList/Content/RankingItem_Empty_3/RankingItem_3/RankingNum_Empty/Rank_Text_Normal | TMPro.TextMeshProUGUI | 7 |  |
| RankingRewardPanel/SafeArea/Content/RankingMove_Empty/RankingList/Content/RankingItem_Empty_3/RankingItem_3/RankingNum_Empty/Rank_Text_First | TMPro.TextMeshProUGUI | 1 |  |
| RankingRewardPanel/SafeArea/Content/RankingMove_Empty/RankingList/Content/RankingItem_Empty_3/RankingItem_3/RankingNum_Empty/Rank_Text_Second | TMPro.TextMeshProUGUI | 2 |  |
| RankingRewardPanel/SafeArea/Content/RankingMove_Empty/RankingList/Content/RankingItem_Empty_3/RankingItem_3/RankingNum_Empty/Rank_Text_Third | TMPro.TextMeshProUGUI | 3 |  |
| RankingRewardPanel/SafeArea/Content/RankingMove_Empty/RankingList/Content/RankingItem_Empty_3/RankingItem_3/Name_Text | TMPro.TextMeshProUGUI | UserName4 |  |
| RankingRewardPanel/SafeArea/Content/RankingMove_Empty/RankingList/Content/RankingItem_Empty_3/RankingItem_3/ScoreNum_Text | TMPro.TextMeshProUGUI | 131 |  |
| RankingRewardPanel/SafeArea/Content/RankingMove_Empty/RankingList/Content/RankingItem_Empty_3/RankingItem_3/Score_Text | TMPro.TextMeshProUGUI | Score |  |
| RankingRewardPanel/SafeArea/Content/RankingMove_Empty/RankingList/Content/RankingItem_Empty_3/RankingItem_3/Gift_Btn | UnityEngine.UI.Button |  |  |
| RankingRewardPanel/SafeArea/Content/RankingMove_Empty/RankingList/Content/RankingItem_Empty_3/RankingItem_3/Gift_Btn | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| RankingRewardPanel/SafeArea/Content/RankingMove_Empty/RankingList/Content/RankingItem_Empty_4/RankingItem_4/RankingNum_Empty/Rank_Text_Normal | TMPro.TextMeshProUGUI | 8 |  |
| RankingRewardPanel/SafeArea/Content/RankingMove_Empty/RankingList/Content/RankingItem_Empty_4/RankingItem_4/RankingNum_Empty/Rank_Text_First | TMPro.TextMeshProUGUI | 1 |  |
| RankingRewardPanel/SafeArea/Content/RankingMove_Empty/RankingList/Content/RankingItem_Empty_4/RankingItem_4/RankingNum_Empty/Rank_Text_Second | TMPro.TextMeshProUGUI | 2 |  |
| RankingRewardPanel/SafeArea/Content/RankingMove_Empty/RankingList/Content/RankingItem_Empty_4/RankingItem_4/RankingNum_Empty/Rank_Text_Third | TMPro.TextMeshProUGUI | 3 |  |
| RankingRewardPanel/SafeArea/Content/RankingMove_Empty/RankingList/Content/RankingItem_Empty_4/RankingItem_4/Name_Text | TMPro.TextMeshProUGUI | UserName4 |  |
| RankingRewardPanel/SafeArea/Content/RankingMove_Empty/RankingList/Content/RankingItem_Empty_4/RankingItem_4/ScoreNum_Text | TMPro.TextMeshProUGUI | 131 |  |
| RankingRewardPanel/SafeArea/Content/RankingMove_Empty/RankingList/Content/RankingItem_Empty_4/RankingItem_4/Score_Text | TMPro.TextMeshProUGUI | Score |  |
| RankingRewardPanel/SafeArea/Content/RankingMove_Empty/RankingList/Content/RankingItem_Empty_4/RankingItem_4/Gift_Btn | UnityEngine.UI.Button |  |  |
| RankingRewardPanel/SafeArea/Content/RankingMove_Empty/RankingList/Content/RankingItem_Empty_4/RankingItem_4/Gift_Btn | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| RankingRewardPanel/SafeArea/Content/RankingMove_Empty/RankingList/Content/SelfRankingItem/SelfRankingItem/RankingNum_Empty/Rank_Text_Normal | TMPro.TextMeshProUGUI | 9 |  |
| RankingRewardPanel/SafeArea/Content/RankingMove_Empty/RankingList/Content/SelfRankingItem/SelfRankingItem/RankingNum_Empty/Rank_Text_First | TMPro.TextMeshProUGUI | 1 |  |
| RankingRewardPanel/SafeArea/Content/RankingMove_Empty/RankingList/Content/SelfRankingItem/SelfRankingItem/RankingNum_Empty/Rank_Text_Second | TMPro.TextMeshProUGUI | 2 |  |
| RankingRewardPanel/SafeArea/Content/RankingMove_Empty/RankingList/Content/SelfRankingItem/SelfRankingItem/RankingNum_Empty/Rank_Text_Third | TMPro.TextMeshProUGUI | 3 |  |
| RankingRewardPanel/SafeArea/Content/RankingMove_Empty/RankingList/Content/SelfRankingItem/SelfRankingItem/Name_Text | TMPro.TextMeshProUGUI | UserName4 |  |
| RankingRewardPanel/SafeArea/Content/RankingMove_Empty/RankingList/Content/SelfRankingItem/SelfRankingItem/ScoreNum_Text | TMPro.TextMeshProUGUI | 131 |  |
| RankingRewardPanel/SafeArea/Content/RankingMove_Empty/RankingList/Content/SelfRankingItem/SelfRankingItem/Score_Text | TMPro.TextMeshProUGUI | Score |  |
| RankingRewardPanel/SafeArea/Content/RankingMove_Empty/RankingList/Content/SelfRankingItem/SelfRankingItem/Gift_Btn | UnityEngine.UI.Button |  |  |
| RankingRewardPanel/SafeArea/Content/RankingMove_Empty/RankingList/Content/SelfRankingItem/SelfRankingItem/Gift_Btn | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| RankingRewardPanel/SafeArea/Content/RankingMove_Empty/SelfRankingItem_Ani/RankingNum_Empty/Rank_Text_Normal | TMPro.TextMeshProUGUI | 4 |  |
| RankingRewardPanel/SafeArea/Content/RankingMove_Empty/SelfRankingItem_Ani/RankingNum_Empty/Rank_Text_First | TMPro.TextMeshProUGUI | 1 |  |
| RankingRewardPanel/SafeArea/Content/RankingMove_Empty/SelfRankingItem_Ani/RankingNum_Empty/Rank_Text_Second | TMPro.TextMeshProUGUI | 2 |  |
| RankingRewardPanel/SafeArea/Content/RankingMove_Empty/SelfRankingItem_Ani/RankingNum_Empty/Rank_Text_Third | TMPro.TextMeshProUGUI | 3 |  |
| RankingRewardPanel/SafeArea/Content/RankingMove_Empty/SelfRankingItem_Ani/Name_Text | TMPro.TextMeshProUGUI | UserName4 |  |
| RankingRewardPanel/SafeArea/Content/RankingMove_Empty/SelfRankingItem_Ani/ScoreNum_Text | TMPro.TextMeshProUGUI | 131 |  |
| RankingRewardPanel/SafeArea/Content/RankingMove_Empty/SelfRankingItem_Ani/Score_Text | TMPro.TextMeshProUGUI | Score |  |
| RankingRewardPanel/SafeArea/Content/RankingMove_Empty/SelfRankingItem_Ani/Gift_Btn | UnityEngine.UI.Button |  |  |
| RankingRewardPanel/SafeArea/Content/RankingMove_Empty/SelfRankingItem_Ani/Gift_Btn | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| RankingRewardPanel/SafeArea/Content/Reward_Empty/All_Anim/RewardProp3_Empty/Reward1_Empty/Reward_Img/RewardNum_Text | TMPro.TextMeshProUGUI | ×3 |  |
| RankingRewardPanel/SafeArea/Content/Reward_Empty/All_Anim/RewardProp3_Empty/Reward2_Empty/Reward_Img/RewardNum_Text | TMPro.TextMeshProUGUI | ×3 |  |
| RankingRewardPanel/SafeArea/Content/Reward_Empty/All_Anim/RewardProp3_Empty/Reward3_Empty/Reward_Img/RewardNum_Text | TMPro.TextMeshProUGUI | ×3 |  |
| RankingRewardPanel/SafeArea/Content/Reward_Empty/All_Anim/RewardProp2_Empty/Reward1_Empty/Reward_Img/RewardNum_Text | TMPro.TextMeshProUGUI | ×3 |  |
| RankingRewardPanel/SafeArea/Content/Reward_Empty/All_Anim/RewardProp2_Empty/Reward2_Empty/Reward_Img/RewardNum_Text | TMPro.TextMeshProUGUI | ×3 |  |
| RankingRewardPanel/SafeArea/Content/Reward_Empty/All_Anim/TapClaim_Text | TMPro.TextMeshProUGUI | Tap to Claim |  |
| RankingRewardPanel/SafeArea/Content/TapContinue_Text | TMPro.TextMeshProUGUI | Tap to Continue |  |
