# ADFreePanel — cấu trúc UI

Bằng chứng: `file-observed`, XAPK 1.3.2/build 65. Chưa tự xác nhận panel này đã được mở khi chơi; xem hồ sơ runtime riêng.

Có 32 MonoBehaviour component; 16 component có liên kết media xuất được. [Bảng chi tiết](ui-elements.csv) chứa hierarchy, path ID, anchor/pivot, font/text, sprite, raycast và toàn bộ serialized fields. Tọa độ là dữ liệu prefab, chưa phải bounding box runtime.

| Hierarchy | Component | Text mặc định | Sprite |
| --- | --- | --- | --- |
| ADFreePanel/SafeArea/All_Anim/Top_Empty/Btn_Close | UnityEngine.UI.Button |  |  |
| ADFreePanel/SafeArea/All_Anim/Top_Empty/Btn_Close | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| ADFreePanel/SafeArea/All_Anim/Top_Empty/Title_Text | TMPro.TextMeshProUGUI | No Ads |  |
| ADFreePanel/SafeArea/All_Anim/Mid_Empty/Text_Empty/Mid_Text | TMPro.TextMeshProUGUI | REMOVE FORCED ADS FOREVER |  |
| ADFreePanel/SafeArea/All_Anim/Bottom_Empty/Btn_Green | UnityEngine.UI.Button |  |  |
| ADFreePanel/SafeArea/All_Anim/Bottom_Empty/Btn_Green | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| ADFreePanel/SafeArea/All_Anim/Bottom_Empty/Btn_Green/UP_Empty/Prop_Text | TMPro.TextMeshProUGUI | $ 1.99 |  |
