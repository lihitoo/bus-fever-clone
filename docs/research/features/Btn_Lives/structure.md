# Btn_Lives — cấu trúc UI

Bằng chứng: `file-observed`, XAPK 1.3.2/build 65. Chưa tự xác nhận panel này đã được mở khi chơi; xem hồ sơ runtime riêng.

Có 13 MonoBehaviour component; 6 component có liên kết media xuất được. [Bảng chi tiết](ui-elements.csv) chứa hierarchy, path ID, anchor/pivot, font/text, sprite, raycast và toàn bộ serialized fields. Tọa độ là dữ liệu prefab, chưa phải bounding box runtime.

| Hierarchy | Component | Text mặc định | Sprite |
| --- | --- | --- | --- |
| Btn_Lives/Btn_Lives | UnityEngine.UI.Button |  |  |
| Btn_Lives/Btn_Lives | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| Btn_Lives/Btn_Lives/Lives_Img/LivesNum_Text | TMPro.TextMeshProUGUI | 0 |  |
| Btn_Lives/Btn_Lives/UnlimitedTime_Text | TMPro.TextMeshProUGUI | 00:00:00 |  |
| Btn_Lives/Btn_Lives/FullLivesTime_Text | TMPro.TextMeshProUGUI | 14:28 |  |
| Btn_Lives/Btn_Lives/FullLives_Text | TMPro.TextMeshProUGUI | Full |  |
