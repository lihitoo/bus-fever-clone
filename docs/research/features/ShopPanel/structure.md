# ShopPanel — cấu trúc UI

Bằng chứng: `file-observed`, XAPK 1.3.2/build 65. Chưa tự xác nhận panel này đã được mở khi chơi; xem hồ sơ runtime riêng.

Có 24 MonoBehaviour component; 8 component có liên kết media xuất được. [Bảng chi tiết](ui-elements.csv) chứa hierarchy, path ID, anchor/pivot, font/text, sprite, raycast và toàn bộ serialized fields. Tọa độ là dữ liệu prefab, chưa phải bounding box runtime.

| Hierarchy | Component | Text mặc định | Sprite |
| --- | --- | --- | --- |
| ShopPanel/SafeArea/All_Empty/Top_Empty/Btn_Close | UnityEngine.UI.Button |  |  |
| ShopPanel/SafeArea/All_Empty/Top_Empty/Btn_Close | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| ShopPanel/SafeArea/All_Empty/Top_Empty/Shop_Text | TMPro.TextMeshProUGUI | Shop |  |
