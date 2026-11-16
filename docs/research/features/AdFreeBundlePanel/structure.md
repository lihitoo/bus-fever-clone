# AdFreeBundlePanel — cấu trúc UI

Bằng chứng: `file-observed`, XAPK 1.3.2/build 65. Chưa tự xác nhận panel này đã được mở khi chơi; xem hồ sơ runtime riêng.

Có 49 MonoBehaviour component; 23 component có liên kết media xuất được. [Bảng chi tiết](ui-elements.csv) chứa hierarchy, path ID, anchor/pivot, font/text, sprite, raycast và toàn bộ serialized fields. Tọa độ là dữ liệu prefab, chưa phải bounding box runtime.

| Hierarchy | Component | Text mặc định | Sprite |
| --- | --- | --- | --- |
| AdFreeBundlePanel/SafeArea/Anim_Empty/Bottom_Empty/Title_Text_3 | TMPro.TextMeshProUGUI | -35% |  |
| AdFreeBundlePanel/SafeArea/Anim_Empty/Bottom_Empty/Btn_Green | UnityEngine.UI.Button |  |  |
| AdFreeBundlePanel/SafeArea/Anim_Empty/Bottom_Empty/Btn_Green | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| AdFreeBundlePanel/SafeArea/Anim_Empty/Bottom_Empty/Btn_Green/UP_Empty/Line_Text | TMPro.TextMeshProUGUI | $ 15.37 |  |
| AdFreeBundlePanel/SafeArea/Anim_Empty/Bottom_Empty/Btn_Green/UP_Empty/Prop_Text | TMPro.TextMeshProUGUI | $ 1.99 |  |
| AdFreeBundlePanel/SafeArea/Anim_Empty/Mid_Empty/Gift_Empty/PropNum_Text_1 | TMPro.TextMeshProUGUI | 1 500 |  |
| AdFreeBundlePanel/SafeArea/Anim_Empty/Mid_Empty/Gift_Empty/PropNum_Text_2 | TMPro.TextMeshProUGUI | ×1 |  |
| AdFreeBundlePanel/SafeArea/Anim_Empty/Mid_Empty/Gift_Empty/PropNum_Text_3 | TMPro.TextMeshProUGUI | ×1 |  |
| AdFreeBundlePanel/SafeArea/Anim_Empty/Mid_Empty/Gift_Empty/PropNum_Text_4 | TMPro.TextMeshProUGUI | ×1 |  |
| AdFreeBundlePanel/SafeArea/Anim_Empty/Mid_Empty/Mid_Text | TMPro.TextMeshProUGUI | REMOVE FORCED ADS FOREVER |  |
| AdFreeBundlePanel/SafeArea/Anim_Empty/Top_Empty/Btn_Close | UnityEngine.UI.Button |  |  |
| AdFreeBundlePanel/SafeArea/Anim_Empty/Top_Empty/Btn_Close | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| AdFreeBundlePanel/SafeArea/Anim_Empty/Top_Empty/Title_Text | TMPro.TextMeshProUGUI | Ad-Free Bundle |  |
