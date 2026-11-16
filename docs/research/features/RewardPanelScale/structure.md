# RewardPanelScale — cấu trúc UI

Bằng chứng: `file-observed`, XAPK 1.3.2/build 65. Chưa tự xác nhận panel này đã được mở khi chơi; xem hồ sơ runtime riêng.

Có 34 MonoBehaviour component; 0 component có liên kết media xuất được. [Bảng chi tiết](ui-elements.csv) chứa hierarchy, path ID, anchor/pivot, font/text, sprite, raycast và toàn bộ serialized fields. Tọa độ là dữ liệu prefab, chưa phải bounding box runtime.

| Hierarchy | Component | Text mặc định | Sprite |
| --- | --- | --- | --- |
| RewardPanelScale/SafeArea/All_Empty/Title_Empty/Top_Empty/Title_Text_5 | TMPro.TextMeshProUGUI | Rewards |  |
| RewardPanelScale/SafeArea/All_Empty/Title_Empty/Top_Empty/Title_Text_4 | TMPro.TextMeshProUGUI | Rewards |  |
| RewardPanelScale/SafeArea/All_Empty/Title_Empty/Top_Empty/Title_Text | TMPro.TextMeshProUGUI | Rewards |  |
| RewardPanelScale/SafeArea/All_Empty/Effect_CoinReward_Collect/Point_Start/Value_Empty/Vaulel_Text | TMPro.TextMeshProUGUI | +500 |  |
| RewardPanelScale/SafeArea/All_Empty/Bottom_Empty/Title_Text_8 | TMPro.TextMeshProUGUI | Tap to Claim |  |
| RewardPanelScale/SafeArea/All_Empty/Bottom_Empty/Title_Text_8/Title_Text_3 | TMPro.TextMeshProUGUI | Tap to Claim |  |
| RewardPanelScale/SafeArea/All_Empty/Mask_Img_1 | UnityEngine.UI.Button |  |  |
