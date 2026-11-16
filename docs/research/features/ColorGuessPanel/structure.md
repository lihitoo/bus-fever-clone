# ColorGuessPanel — cấu trúc UI

Bằng chứng: `file-observed`, XAPK 1.3.2/build 65. Chưa tự xác nhận panel này đã được mở khi chơi; xem hồ sơ runtime riêng.

Có 35 MonoBehaviour component; 0 component có liên kết media xuất được. [Bảng chi tiết](ui-elements.csv) chứa hierarchy, path ID, anchor/pivot, font/text, sprite, raycast và toàn bộ serialized fields. Tọa độ là dữ liệu prefab, chưa phải bounding box runtime.

| Hierarchy | Component | Text mặc định | Sprite |
| --- | --- | --- | --- |
| ColorGuessPanel/TxtTitle | TMPro.TextMeshProUGUI | MAGIC CAULDRON |  |
| ColorGuessPanel/TxtTime | TMPro.TextMeshProUGUI | 3d 22h |  |
| ColorGuessPanel/BtnInfo | UnityEngine.UI.Button |  |  |
| ColorGuessPanel/BtnInfo/Text | TMPro.TextMeshProUGUI | ? |  |
| ColorGuessPanel/BtnClose | UnityEngine.UI.Button |  |  |
| ColorGuessPanel/BtnClose/Text | TMPro.TextMeshProUGUI | X |  |
| ColorGuessPanel/TxtReward | TMPro.TextMeshProUGUI | Reward |  |
| ColorGuessPanel/TxtProgress | TMPro.TextMeshProUGUI | 0/15 |  |
| ColorGuessPanel/TxtPotionLabel | TMPro.TextMeshProUGUI | ELIXIR |  |
| ColorGuessPanel/TxtPotion | TMPro.TextMeshProUGUI | 0 |  |
| ColorGuessPanel/TxtStatus | TMPro.TextMeshProUGUI | Find the Correct Sequence! |  |
| ColorGuessPanel/TxtTrayTitle | TMPro.TextMeshProUGUI | AVAILABLE BOTTLES |  |
