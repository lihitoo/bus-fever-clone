# PackagePanel — cấu trúc UI

Bằng chứng: `file-observed`, XAPK 1.3.2/build 65. Chưa tự xác nhận panel này đã được mở khi chơi; xem hồ sơ runtime riêng.

Có 48 MonoBehaviour component; 23 component có liên kết media xuất được. [Bảng chi tiết](ui-elements.csv) chứa hierarchy, path ID, anchor/pivot, font/text, sprite, raycast và toàn bộ serialized fields. Tọa độ là dữ liệu prefab, chưa phải bounding box runtime.

| Hierarchy | Component | Text mặc định | Sprite |
| --- | --- | --- | --- |
| PackagePanel/SafeArea/All_Anim/Bottom_Empty/Title_Text_3 | TMPro.TextMeshProUGUI | -50% |  |
| PackagePanel/SafeArea/All_Anim/Bottom_Empty/Btn_Green | UnityEngine.UI.Button |  |  |
| PackagePanel/SafeArea/All_Anim/Bottom_Empty/Btn_Green | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| PackagePanel/SafeArea/All_Anim/Bottom_Empty/Btn_Green/UP_Empty/Line_Text | TMPro.TextMeshProUGUI | $ 3.99 |  |
| PackagePanel/SafeArea/All_Anim/Bottom_Empty/Btn_Green/UP_Empty/Prop_Text | TMPro.TextMeshProUGUI | $ 9.99 |  |
| PackagePanel/SafeArea/All_Anim/Mid_Empty/Icon_Empty/CoinNum_Text | TMPro.TextMeshProUGUI | 1 000 |  |
| PackagePanel/SafeArea/All_Anim/Mid_Empty/Coins_Empty/Title_Text_2 | TMPro.TextMeshProUGUI | 600 |  |
| PackagePanel/SafeArea/All_Anim/Mid_Empty/Gift_Empty/Icon_Empty/PropNum_Text_1 | TMPro.TextMeshProUGUI | ×2 |  |
| PackagePanel/SafeArea/All_Anim/Mid_Empty/Gift_Empty/Icon_Empty/PropNum_Text_2 | TMPro.TextMeshProUGUI | ×2 |  |
| PackagePanel/SafeArea/All_Anim/Mid_Empty/Gift_Empty/Icon_Empty/PropNum_Text_3 | TMPro.TextMeshProUGUI | ×2 |  |
| PackagePanel/SafeArea/All_Anim/Top_Empty/Btn_Close | UnityEngine.UI.Button |  |  |
| PackagePanel/SafeArea/All_Anim/Top_Empty/Btn_Close | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| PackagePanel/SafeArea/All_Anim/Top_Empty/Title_Text | TMPro.TextMeshProUGUI | Beginner Bundle |  |
