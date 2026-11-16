# ShopCard4 — cấu trúc UI

Bằng chứng: `file-observed`, XAPK 1.3.2/build 65. Chưa tự xác nhận panel này đã được mở khi chơi; xem hồ sơ runtime riêng.

Có 36 MonoBehaviour component; 27 component có liên kết media xuất được. [Bảng chi tiết](ui-elements.csv) chứa hierarchy, path ID, anchor/pivot, font/text, sprite, raycast và toàn bộ serialized fields. Tọa độ là dữ liệu prefab, chưa phải bounding box runtime.

| Hierarchy | Component | Text mặc định | Sprite |
| --- | --- | --- | --- |
| ShopCard4/ShopCard_Empty/Title_Text | TMPro.TextMeshProUGUI | 250 |  |
| ShopCard4/ShopCard_Empty/Buy_Btn | UnityEngine.UI.Button |  |  |
| ShopCard4/ShopCard_Empty/Buy_Btn/Up_Empty/Btn_Text | TMPro.TextMeshProUGUI | $ 1.99 |  |
| ShopCard4/ShopCard_Empty_1/Title_Text | TMPro.TextMeshProUGUI | 1100 |  |
| ShopCard4/ShopCard_Empty_1/Buy_Btn | UnityEngine.UI.Button |  |  |
| ShopCard4/ShopCard_Empty_1/Buy_Btn/Up_Empty/Btn_Text | TMPro.TextMeshProUGUI | $ 1.99 |  |
| ShopCard4/ShopCard_Empty_2/Title_Text | TMPro.TextMeshProUGUI | 2250 |  |
| ShopCard4/ShopCard_Empty_2/Buy_Btn | UnityEngine.UI.Button |  |  |
| ShopCard4/ShopCard_Empty_2/Buy_Btn/Up_Empty/Btn_Text | TMPro.TextMeshProUGUI | $ 1.99 |  |
