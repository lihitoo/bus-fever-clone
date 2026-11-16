# ShopCard1 1 — cấu trúc UI

Bằng chứng: `file-observed`, XAPK 1.3.2/build 65. Chưa tự xác nhận panel này đã được mở khi chơi; xem hồ sơ runtime riêng.

Có 28 MonoBehaviour component; 15 component có liên kết media xuất được. [Bảng chi tiết](ui-elements.csv) chứa hierarchy, path ID, anchor/pivot, font/text, sprite, raycast và toàn bộ serialized fields. Tọa độ là dữ liệu prefab, chưa phải bounding box runtime.

| Hierarchy | Component | Text mặc định | Sprite |
| --- | --- | --- | --- |
| ShopCard1 1/Text_Empty/Remove_Text | TMPro.TextMeshProUGUI | -Remove bottom banner ads |  |
| ShopCard1 1/Text_Empty/Remove_Text_1 | TMPro.TextMeshProUGUI | -Remove ads between levels |  |
| ShopCard1 1/Text_Empty/Remove_Text_2 | TMPro.TextMeshProUGUI | -Optional reward ads will be kept |  |
| ShopCard1 1/Title_Text | TMPro.TextMeshProUGUI | AD-Free Pass |  |
| ShopCard1 1/Buy_Btn | UnityEngine.UI.Button |  |  |
| ShopCard1 1/Buy_Btn/Up_Empty/Btn_Text | TMPro.TextMeshProUGUI | $ 6.99 |  |
| ShopCard1 1/Buy_Btn/Up_Empty/Btn_Text/Title_Text_1 | TMPro.TextMeshProUGUI | $ 6.99 |  |
| ShopCard1 1/Goods_Empty/Coin_Img/Number_Text | TMPro.TextMeshProUGUI | 200 |  |
| ShopCard1 1/Goods_Empty/Ball_Img/Number_Text_1 | TMPro.TextMeshProUGUI | ×1 |  |
| ShopCard1 1/Goods_Empty/Fly_Img/Number_Text_2 | TMPro.TextMeshProUGUI | ×1 |  |
| ShopCard1 1/Goods_Empty/Arrange_Img/Number_Text_3 | TMPro.TextMeshProUGUI | ×1 |  |
| ShopCard1 1/Sale_Empty/Sale_Text | TMPro.TextMeshProUGUI | 35% |  |
| ShopCard1 1/Sale_Empty/Sale_Text/Sale_Text_1 | TMPro.TextMeshProUGUI | OFF |  |
