# EntryTipTextBanner — cấu trúc UI

Bằng chứng: `file-observed`, XAPK 1.3.2/build 65. Chưa tự xác nhận panel này đã được mở khi chơi; xem hồ sơ runtime riêng.

Có 15 MonoBehaviour component; 3 component có liên kết media xuất được. [Bảng chi tiết](ui-elements.csv) chứa hierarchy, path ID, anchor/pivot, font/text, sprite, raycast và toàn bộ serialized fields. Tọa độ là dữ liệu prefab, chưa phải bounding box runtime.

| Hierarchy | Component | Text mặc định | Sprite |
| --- | --- | --- | --- |
| EntryTipTextBanner/All_Anim/Content_Empty/Tip_Text | TMPro.TextMeshProUGUI | <color=#fff228>86.7%</color> of plevers have completed this level - join them! |  |
| EntryTipTextBanner/All_Anim/Content_Empty/HardStage_Empty/Hard_Text | TMPro.TextMeshProUGUI | HARD |  |
| EntryTipTextBanner/All_Anim/Content_Empty/SuperHard_Empty/SuperHard_Text | TMPro.TextMeshProUGUI | SUPER HARD |  |
