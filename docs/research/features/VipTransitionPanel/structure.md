# VipTransitionPanel — cấu trúc UI

Bằng chứng: `file-observed`, XAPK 1.3.2/build 65. Chưa tự xác nhận panel này đã được mở khi chơi; xem hồ sơ runtime riêng.

Có 15 MonoBehaviour component; 1 component có liên kết media xuất được. [Bảng chi tiết](ui-elements.csv) chứa hierarchy, path ID, anchor/pivot, font/text, sprite, raycast và toàn bộ serialized fields. Tọa độ là dữ liệu prefab, chưa phải bounding box runtime.

| Hierarchy | Component | Text mặc định | Sprite |
| --- | --- | --- | --- |
| VipTransitionPanel/All_Anim/Img_Bg/VipHint_Text1 | TMPro.TextMeshProUGUI | Select a Vehicle for the <color=#ec6f00>VIP</color> Spot |  |
| VipTransitionPanel/All_Anim/Img_Bg/VipHint_Text1/VipHint_Text3 | TMPro.TextMeshProUGUI | Select a Vehicle for the <color=#ec6f00>VIP</color> Spot |  |
| VipTransitionPanel/All_Anim/Img_Bg/VipHint_Text1/VipHint_Text2 | TMPro.TextMeshProUGUI | Select a Vehicle for the <color=#ec6f00>VIP</color> Spot |  |
