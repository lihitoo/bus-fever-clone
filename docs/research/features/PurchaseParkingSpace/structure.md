# PurchaseParkingSpace — cấu trúc UI

Bằng chứng: `file-observed`, XAPK 1.3.2/build 65. Chưa tự xác nhận panel này đã được mở khi chơi; xem hồ sơ runtime riêng.

Có 126 MonoBehaviour component; 72 component có liên kết media xuất được. [Bảng chi tiết](ui-elements.csv) chứa hierarchy, path ID, anchor/pivot, font/text, sprite, raycast và toàn bộ serialized fields. Tọa độ là dữ liệu prefab, chưa phải bounding box runtime.

| Hierarchy | Component | Text mặc định | Sprite |
| --- | --- | --- | --- |
| PurchaseParkingSpace/SafeArea/All_Anim/Board_Bg/Btn_Close | UnityEngine.UI.Button |  |  |
| PurchaseParkingSpace/SafeArea/All_Anim/Board_Bg/Btn_Close | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| PurchaseParkingSpace/SafeArea/All_Anim/Board_Bg/KeepGoing_Img/Text | TMPro.TextMeshProUGUI | +1 |  |
| PurchaseParkingSpace/SafeArea/All_Anim/Board_Bg/Title_Text | TMPro.TextMeshProUGUI | Extra Spot |  |
| PurchaseParkingSpace/SafeArea/All_Anim/Board_Bg/ParkingSpace_Text | TMPro.TextMeshProUGUI | Unlock a parking spot! |  |
| PurchaseParkingSpace/SafeArea/All_Anim/Board_Bg/Btn_Yellow | UnityEngine.UI.Button |  |  |
| PurchaseParkingSpace/SafeArea/All_Anim/Board_Bg/Btn_Yellow | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| PurchaseParkingSpace/SafeArea/All_Anim/Board_Bg/Btn_Yellow/UP_Empty/Prop_Text | TMPro.TextMeshProUGUI | 200 |  |
| PurchaseParkingSpace/SafeArea/All_Anim/Board_Bg/Btn_Green | UnityEngine.UI.Button |  |  |
| PurchaseParkingSpace/SafeArea/All_Anim/Board_Bg/Btn_Green | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| PurchaseParkingSpace/SafeArea/All_Anim/Board_Bg/Btn_Green/UP_Empty/Prop_Text | TMPro.TextMeshProUGUI | Free |  |
| PurchaseParkingSpace/SafeArea/All_Anim/Card_Empty/Goods_Empty/Tool_Empty/Coin_Empty/Number_Text_3 | TMPro.TextMeshProUGUI | 750 |  |
| PurchaseParkingSpace/SafeArea/All_Anim/Card_Empty/Goods_Empty/Tool_Empty/Ball_Empty/Number_Text_3 | TMPro.TextMeshProUGUI | ×1 |  |
| PurchaseParkingSpace/SafeArea/All_Anim/Card_Empty/Goods_Empty/Tool_Empty/Arrange_Empty/Number_Text_3 | TMPro.TextMeshProUGUI | ×1 |  |
| PurchaseParkingSpace/SafeArea/All_Anim/Card_Empty/Goods_Empty/Tool_Empty/Car_Empty/Number_Text_3 | TMPro.TextMeshProUGUI | ×1 |  |
| PurchaseParkingSpace/SafeArea/All_Anim/Card_Empty/Goods_Empty/Spot_Empty/Number_Text_3 | TMPro.TextMeshProUGUI | +1 Spot |  |
| PurchaseParkingSpace/SafeArea/All_Anim/Card_Empty/Goods_Empty/Ads_Empty/Number_Text_3 | TMPro.TextMeshProUGUI | No Ads |  |
| PurchaseParkingSpace/SafeArea/All_Anim/Card_Empty/Goods_Empty/Bonus_Empty | UnityEngine.UI.Button |  |  |
| PurchaseParkingSpace/SafeArea/All_Anim/Card_Empty/Goods_Empty/Bonus_Empty | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| PurchaseParkingSpace/SafeArea/All_Anim/Card_Empty/Goods_Empty/Bonus_Empty/Number_Text_3 | TMPro.TextMeshProUGUI | Bonus |  |
| PurchaseParkingSpace/SafeArea/All_Anim/Card_Empty/Bottom_Empty/Coins_Text | TMPro.TextMeshProUGUI | 375 |  |
| PurchaseParkingSpace/SafeArea/All_Anim/Card_Empty/Bottom_Empty/Title_Text | TMPro.TextMeshProUGUI | Daily Reward |  |
| PurchaseParkingSpace/SafeArea/All_Anim/Card_Empty/Bottom_Empty/Buy_Btn | UnityEngine.UI.Button |  |  |
| PurchaseParkingSpace/SafeArea/All_Anim/Card_Empty/Bottom_Empty/Buy_Btn | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| PurchaseParkingSpace/SafeArea/All_Anim/Card_Empty/Bottom_Empty/Buy_Btn/Up_Empty/Btn_Text | TMPro.TextMeshProUGUI | $ 7.99 |  |
| PurchaseParkingSpace/SafeArea/All_Anim/Card_Empty/Bottom_Empty/BuyInfo_Btn | UnityEngine.UI.Button |  |  |
| PurchaseParkingSpace/SafeArea/All_Anim/Card_Empty/Bottom_Empty/BuyInfo_Btn/Up_Empty/Btn_Text | TMPro.TextMeshProUGUI | Claim |  |
| PurchaseParkingSpace/SafeArea/All_Anim/Card_Empty/Bottom_Empty/NoBuy_Btn | UnityEngine.UI.Button |  |  |
| PurchaseParkingSpace/SafeArea/All_Anim/Card_Empty/Bottom_Empty/NoBuy_Btn/Up_Empty/Btn_Text | TMPro.TextMeshProUGUI | Claimed |  |
| PurchaseParkingSpace/SafeArea/All_Anim/Card_Empty/Vip_Empty/Vip_Text | TMPro.TextMeshProUGUI | 3-Day VIP Pass |  |
| PurchaseParkingSpace/SafeArea/All_Anim/Card_Empty/Info_Empty/Info_Content/Coin_Img/Number_Text_1 | TMPro.TextMeshProUGUI | 750 |  |
| PurchaseParkingSpace/SafeArea/All_Anim/Card_Empty/Info_Empty/Info_Content/Coin_Img/Number_Text_1/Number_Text_2 | TMPro.TextMeshProUGUI | 750 |  |
| PurchaseParkingSpace/SafeArea/All_Anim/Card_Empty/Info_Empty/Info_Content/Ball_Img/Number_Text_1 | TMPro.TextMeshProUGUI | ×1 |  |
| PurchaseParkingSpace/SafeArea/All_Anim/Card_Empty/Info_Empty/Info_Content/Ball_Img/Number_Text_1/Number_Text_2 | TMPro.TextMeshProUGUI | ×1 |  |
| PurchaseParkingSpace/SafeArea/All_Anim/Card_Empty/Info_Empty/Info_Content/Fly_Img/Number_Text_2 | TMPro.TextMeshProUGUI | ×1 |  |
| PurchaseParkingSpace/SafeArea/All_Anim/Card_Empty/Info_Empty/Info_Content/Fly_Img/Number_Text_2/Number_Text_3 | TMPro.TextMeshProUGUI | ×1 |  |
| PurchaseParkingSpace/SafeArea/All_Anim/Card_Empty/Info_Empty/Info_Content/Arrange_Img/Number_Text_3 | TMPro.TextMeshProUGUI | ×1 |  |
| PurchaseParkingSpace/SafeArea/All_Anim/Card_Empty/Info_Empty/Info_Content/Arrange_Img/Number_Text_3/Number_Text_4 | TMPro.TextMeshProUGUI | ×1 |  |
| PurchaseParkingSpace/SafeArea/All_Anim/Card_Empty/Info_Empty/Button | UnityEngine.UI.Button |  |  |
