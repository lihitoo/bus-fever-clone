# ItemPurchasePanel — cấu trúc UI

Bằng chứng: `file-observed`, XAPK 1.3.2/build 65. Chưa tự xác nhận panel này đã được mở khi chơi; xem hồ sơ runtime riêng.

Có 88 MonoBehaviour component; 47 component có liên kết media xuất được. [Bảng chi tiết](ui-elements.csv) chứa hierarchy, path ID, anchor/pivot, font/text, sprite, raycast và toàn bộ serialized fields. Tọa độ là dữ liệu prefab, chưa phải bounding box runtime.

| Hierarchy | Component | Text mặc định | Sprite |
| --- | --- | --- | --- |
| ItemPurchasePanel/SafeArea/All_Anim/Board_Bg/Btn_Close | UnityEngine.UI.Button |  |  |
| ItemPurchasePanel/SafeArea/All_Anim/Board_Bg/Btn_Close | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| ItemPurchasePanel/SafeArea/All_Anim/Board_Bg/VipContent_Text | TMPro.TextMeshProUGUI | Send a vehicle to fly to  the <color=#ec6f00>VIP</color> parking spot |  |
| ItemPurchasePanel/SafeArea/All_Anim/Board_Bg/Vip_Text | TMPro.TextMeshProUGUI | VIP |  |
| ItemPurchasePanel/SafeArea/All_Anim/Board_Bg/Btn_Group/Btn_Yellow | UnityEngine.UI.Button |  |  |
| ItemPurchasePanel/SafeArea/All_Anim/Board_Bg/Btn_Group/Btn_Yellow | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| ItemPurchasePanel/SafeArea/All_Anim/Board_Bg/Btn_Group/Btn_Yellow/UP_Empty/Prop_Text | TMPro.TextMeshProUGUI | 200 |  |
| ItemPurchasePanel/SafeArea/All_Anim/Board_Bg/Btn_Group/Btn2_Empty/Btn_Yellow | UnityEngine.UI.Button |  |  |
| ItemPurchasePanel/SafeArea/All_Anim/Board_Bg/Btn_Group/Btn2_Empty/Btn_Yellow | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| ItemPurchasePanel/SafeArea/All_Anim/Board_Bg/Btn_Group/Btn2_Empty/Btn_Yellow/UP_Empty/Prop_Text | TMPro.TextMeshProUGUI | 80 |  |
| ItemPurchasePanel/SafeArea/All_Anim/Board_Bg/Btn_Group/Btn2_Empty/Btn_Green | UnityEngine.UI.Button |  |  |
| ItemPurchasePanel/SafeArea/All_Anim/Board_Bg/Btn_Group/Btn2_Empty/Btn_Green | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| ItemPurchasePanel/SafeArea/All_Anim/Board_Bg/Btn_Group/Btn2_Empty/Btn_Green/UP_Empty/Prop_Text | TMPro.TextMeshProUGUI | Free |  |
| ItemPurchasePanel/SafeArea/All_Anim/Card_Empty/Goods_Empty/Prop1_Empty/Ball_Img/Number_Text | TMPro.TextMeshProUGUI | ×2 |  |
| ItemPurchasePanel/SafeArea/All_Anim/Card_Empty/Goods_Empty/Prop2_Empty/Fly_Img/Number_Text | TMPro.TextMeshProUGUI | ×2 |  |
| ItemPurchasePanel/SafeArea/All_Anim/Card_Empty/Goods_Empty/Prop3_Empty/Arrange_Img/Number_Text | TMPro.TextMeshProUGUI | ×2 |  |
| ItemPurchasePanel/SafeArea/All_Anim/Card_Empty/Title_Empty/Title_Text | TMPro.TextMeshProUGUI | All-In-One Pack |  |
| ItemPurchasePanel/SafeArea/All_Anim/Card_Empty/Bottom_Empty/Buy_Btn | UnityEngine.UI.Button |  |  |
| ItemPurchasePanel/SafeArea/All_Anim/Card_Empty/Bottom_Empty/Buy_Btn | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| ItemPurchasePanel/SafeArea/All_Anim/Card_Empty/Bottom_Empty/Buy_Btn/Up_Empty/Btn_Text | TMPro.TextMeshProUGUI | $ 3.99 |  |
| ItemPurchasePanel/SafeArea/All_Anim/Card_Empty/Bottom_Empty/GetPropTip_Text | TMPro.TextMeshProUGUI | Get All 3 Boosters! |  |
| ItemPurchasePanel/SafeArea/All_Anim/Card_Empty/Bottom_Empty/Sale_Empty/Sale_Text | TMPro.TextMeshProUGUI | 20% |  |
| ItemPurchasePanel/SafeArea/All_Anim/Card_Empty/Bottom_Empty/Sale_Empty/Sale_Text/Sale_Text_1 | TMPro.TextMeshProUGUI | OFF |  |
