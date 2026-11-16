# ShopCard3 — cấu trúc UI

Bằng chứng: `file-observed`, XAPK 1.3.2/build 65. Chưa tự xác nhận panel này đã được mở khi chơi; xem hồ sơ runtime riêng.

Có 48 MonoBehaviour component; 28 component có liên kết media xuất được. [Bảng chi tiết](ui-elements.csv) chứa hierarchy, path ID, anchor/pivot, font/text, sprite, raycast và toàn bộ serialized fields. Tọa độ là dữ liệu prefab, chưa phải bounding box runtime.

| Hierarchy | Component | Text mặc định | Sprite |
| --- | --- | --- | --- |
| ShopCard3/Vip_Empty/Vip_Text | TMPro.TextMeshProUGUI | 3-Day VIP Pass |  |
| ShopCard3/TItle_Empty/Coins_Text | TMPro.TextMeshProUGUI | 500 |  |
| ShopCard3/TItle_Empty/Title_Text | TMPro.TextMeshProUGUI | Daily Reward |  |
| ShopCard3/Buy_Btn | UnityEngine.UI.Button |  |  |
| ShopCard3/Buy_Btn/Up_Empty/Btn_Text | TMPro.TextMeshProUGUI | $ 7.99 |  |
| ShopCard3/Gift_Empty/Number_Text_3 | TMPro.TextMeshProUGUI | No Ads |  |
| ShopCard3/Gift_Empty_1/Number_Text_3 | TMPro.TextMeshProUGUI | +1 Spot |  |
| ShopCard3/Gift_Empty_2 | UnityEngine.UI.Button |  |  |
| ShopCard3/Gift_Empty_2/Number_Text_3 | TMPro.TextMeshProUGUI | Bonus |  |
| ShopCard3/Purchase_Empty/Title_Text_1 | TMPro.TextMeshProUGUI | Not Purchased |  |
| ShopCard3/Info_Empty/Coin_Img/Number_Text_1 | TMPro.TextMeshProUGUI | x125 |  |
| ShopCard3/Info_Empty/Ball_Img/Number_Text_1 | TMPro.TextMeshProUGUI | x1 |  |
| ShopCard3/Info_Empty/Fly_Img/Number_Text_2 | TMPro.TextMeshProUGUI | x1 |  |
| ShopCard3/Info_Empty/Arrange_Img/Number_Text_3 | TMPro.TextMeshProUGUI | x1 |  |
