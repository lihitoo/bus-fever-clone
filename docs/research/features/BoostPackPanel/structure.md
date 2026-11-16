# BoostPackPanel — cấu trúc UI

Bằng chứng: `file-observed`, XAPK 1.3.2/build 65. Chưa tự xác nhận panel này đã được mở khi chơi; xem hồ sơ runtime riêng.

Có 34 MonoBehaviour component; 17 component có liên kết media xuất được. [Bảng chi tiết](ui-elements.csv) chứa hierarchy, path ID, anchor/pivot, font/text, sprite, raycast và toàn bộ serialized fields. Tọa độ là dữ liệu prefab, chưa phải bounding box runtime.

| Hierarchy | Component | Text mặc định | Sprite |
| --- | --- | --- | --- |
| BoostPackPanel/Coins_Empty/Number_Text | TMPro.TextMeshProUGUI | 3 000 |  |
| BoostPackPanel/Goods_Empty/Ball_Img/PropNum_Text | TMPro.TextMeshProUGUI | ×1 |  |
| BoostPackPanel/Goods_Empty/Fly_Img/PropNum_Text | TMPro.TextMeshProUGUI | ×1 |  |
| BoostPackPanel/Goods_Empty/Arrange_Img/PropNum_Text | TMPro.TextMeshProUGUI | ×1 |  |
| BoostPackPanel/Title_Empty/Title_Text | TMPro.TextMeshProUGUI | Boost Pack |  |
| BoostPackPanel/Buy_Btn | UnityEngine.UI.Button |  |  |
| BoostPackPanel/Buy_Btn | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| BoostPackPanel/Buy_Btn/Up_Empty/Btn_Text | TMPro.TextMeshProUGUI | $ 4.99 |  |
| BoostPackPanel/Sale_Empty/Sale_Text | TMPro.TextMeshProUGUI | 40% |  |
| BoostPackPanel/Sale_Empty/Sale_Text/Sale_Text_1 | TMPro.TextMeshProUGUI | OFF |  |
