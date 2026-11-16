# RewardPanel — cấu trúc UI

Bằng chứng: `file-observed`, XAPK 1.3.2/build 65. Chưa tự xác nhận panel này đã được mở khi chơi; xem hồ sơ runtime riêng.

Có 29 MonoBehaviour component; 1 component có liên kết media xuất được. [Bảng chi tiết](ui-elements.csv) chứa hierarchy, path ID, anchor/pivot, font/text, sprite, raycast và toàn bộ serialized fields. Tọa độ là dữ liệu prefab, chưa phải bounding box runtime.

| Hierarchy | Component | Text mặc định | Sprite |
| --- | --- | --- | --- |
| RewardPanel/SafeArea/All_Empty/Effect_CoinReward_Collect/Point_Start/Value_Empty/Vaulel_Text | TMPro.TextMeshProUGUI | +500 |  |
| RewardPanel/SafeArea/All_Empty/Bottom_Empty/Title_Text_8 | TMPro.TextMeshProUGUI | Tap to Claim |  |
| RewardPanel/SafeArea/All_Empty/Bottom_Empty/Title_Text_8/Title_Text_3 | TMPro.TextMeshProUGUI | Tap to Claim |  |
| RewardPanel/SafeArea/All_Empty/Mask_Img_1 | UnityEngine.UI.Button |  |  |
