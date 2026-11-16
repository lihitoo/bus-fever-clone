# ColorGuessInfoPanel — cấu trúc UI

Bằng chứng: `file-observed`, XAPK 1.3.2/build 65. Chưa tự xác nhận panel này đã được mở khi chơi; xem hồ sơ runtime riêng.

Có 7 MonoBehaviour component; 0 component có liên kết media xuất được. [Bảng chi tiết](ui-elements.csv) chứa hierarchy, path ID, anchor/pivot, font/text, sprite, raycast và toàn bộ serialized fields. Tọa độ là dữ liệu prefab, chưa phải bounding box runtime.

| Hierarchy | Component | Text mặc định | Sprite |
| --- | --- | --- | --- |
| ColorGuessInfoPanel/BtnBackground | UnityEngine.UI.Button |  |  |
| ColorGuessInfoPanel/TxtTitle | TMPro.TextMeshProUGUI | HOW TO PLAY |  |
| ColorGuessInfoPanel/TxtContent | TMPro.TextMeshProUGUI | Beat levels to collect elixirs Tap bottles to fill the first empty shelf slot Correct bottles stay locked Wrong bottles burst and return next try Complete all slots to claim the reward |  |
