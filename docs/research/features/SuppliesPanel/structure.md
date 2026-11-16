# SuppliesPanel — cấu trúc UI

Bằng chứng: `file-observed`, XAPK 1.3.2/build 65. Chưa tự xác nhận panel này đã được mở khi chơi; xem hồ sơ runtime riêng.

Có 239 MonoBehaviour component; 158 component có liên kết media xuất được. [Bảng chi tiết](ui-elements.csv) chứa hierarchy, path ID, anchor/pivot, font/text, sprite, raycast và toàn bộ serialized fields. Tọa độ là dữ liệu prefab, chưa phải bounding box runtime.

| Hierarchy | Component | Text mặc định | Sprite |
| --- | --- | --- | --- |
| SuppliesPanel/SafeArea/All_Anim/Title_Text | TMPro.TextMeshProUGUI | Bus Supplies |  |
| SuppliesPanel/SafeArea/All_Anim/Top_Empty/Coin_Text | TMPro.TextMeshProUGUI | x15 |  |
| SuppliesPanel/SafeArea/All_Anim/Top_Empty/Buy_Btn | UnityEngine.UI.Button |  |  |
| SuppliesPanel/SafeArea/All_Anim/Top_Empty/Buy_Btn | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| SuppliesPanel/SafeArea/All_Anim/Top_Empty/Buy_Btn/Up_Empty/Btn_Text | TMPro.TextMeshProUGUI | Free |  |
| SuppliesPanel/SafeArea/All_Anim/Top_Empty/Buy_Btn/Up_Empty/Btn_Text/Title_Text_1 | TMPro.TextMeshProUGUI | Free |  |
| SuppliesPanel/SafeArea/All_Anim/Top_Empty/Unusable_Btn | UnityEngine.UI.Button |  |  |
| SuppliesPanel/SafeArea/All_Anim/Top_Empty/Unusable_Btn | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| SuppliesPanel/SafeArea/All_Anim/Top_Empty/Unusable_Btn/Up_Empty/Btn_Text | TMPro.TextMeshProUGUI | Free |  |
| SuppliesPanel/SafeArea/All_Anim/Top_Empty/Unusable_Btn/Up_Empty/Btn_Text/Title_Text_1 | TMPro.TextMeshProUGUI | Free |  |
| SuppliesPanel/SafeArea/All_Anim/Top_Empty/Time_Btn | UnityEngine.UI.Button |  |  |
| SuppliesPanel/SafeArea/All_Anim/Top_Empty/Time_Btn/Up_Empty/Btn_Text | TMPro.TextMeshProUGUI | Free |  |
| SuppliesPanel/SafeArea/All_Anim/Middle_Empty/Reward1_Empty/Buy_Btn | UnityEngine.UI.Button |  |  |
| SuppliesPanel/SafeArea/All_Anim/Middle_Empty/Reward1_Empty/Buy_Btn | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| SuppliesPanel/SafeArea/All_Anim/Middle_Empty/Reward1_Empty/Buy_Btn/Up_Empty/Btn_Text | TMPro.TextMeshProUGUI | Free |  |
| SuppliesPanel/SafeArea/All_Anim/Middle_Empty/Reward1_Empty/Unusable_Btn | UnityEngine.UI.Button |  |  |
| SuppliesPanel/SafeArea/All_Anim/Middle_Empty/Reward1_Empty/Unusable_Btn | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| SuppliesPanel/SafeArea/All_Anim/Middle_Empty/Reward1_Empty/Unusable_Btn/Up_Empty/Btn_Text | TMPro.TextMeshProUGUI | Free |  |
| SuppliesPanel/SafeArea/All_Anim/Middle_Empty/Reward1_Empty/Locked_Btn | UnityEngine.UI.Button |  |  |
| SuppliesPanel/SafeArea/All_Anim/Middle_Empty/Reward1_Empty/Locked_Btn | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| SuppliesPanel/SafeArea/All_Anim/Middle_Empty/Reward1_Empty/Locked_Btn/Up_Empty/Btn_Text | TMPro.TextMeshProUGUI | Free |  |
| SuppliesPanel/SafeArea/All_Anim/Middle_Empty/Reward1_Empty/Finished_Img | UnityEngine.UI.Button |  |  |
| SuppliesPanel/SafeArea/All_Anim/Middle_Empty/Reward1_Empty/Coin_Empty/Coin_Text | TMPro.TextMeshProUGUI | x45 |  |
| SuppliesPanel/SafeArea/All_Anim/Middle_Empty/Reward2_Empty/Buy_Btn | UnityEngine.UI.Button |  |  |
| SuppliesPanel/SafeArea/All_Anim/Middle_Empty/Reward2_Empty/Buy_Btn | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| SuppliesPanel/SafeArea/All_Anim/Middle_Empty/Reward2_Empty/Buy_Btn/Up_Empty/Btn_Text | TMPro.TextMeshProUGUI | Free |  |
| SuppliesPanel/SafeArea/All_Anim/Middle_Empty/Reward2_Empty/Unusable_Btn | UnityEngine.UI.Button |  |  |
| SuppliesPanel/SafeArea/All_Anim/Middle_Empty/Reward2_Empty/Unusable_Btn | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| SuppliesPanel/SafeArea/All_Anim/Middle_Empty/Reward2_Empty/Unusable_Btn/Up_Empty/Btn_Text | TMPro.TextMeshProUGUI | Free |  |
| SuppliesPanel/SafeArea/All_Anim/Middle_Empty/Reward2_Empty/Locked_Btn | UnityEngine.UI.Button |  |  |
| SuppliesPanel/SafeArea/All_Anim/Middle_Empty/Reward2_Empty/Locked_Btn | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| SuppliesPanel/SafeArea/All_Anim/Middle_Empty/Reward2_Empty/Locked_Btn/Up_Empty/Btn_Text | TMPro.TextMeshProUGUI | Free |  |
| SuppliesPanel/SafeArea/All_Anim/Middle_Empty/Reward2_Empty/Finished_Img | UnityEngine.UI.Button |  |  |
| SuppliesPanel/SafeArea/All_Anim/Middle_Empty/Reward2_Empty/Coin_Empty/Coin_Text | TMPro.TextMeshProUGUI | x75 |  |
| SuppliesPanel/SafeArea/All_Anim/Middle_Empty/Reward3_Empty/Buy_Btn | UnityEngine.UI.Button |  |  |
| SuppliesPanel/SafeArea/All_Anim/Middle_Empty/Reward3_Empty/Buy_Btn | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| SuppliesPanel/SafeArea/All_Anim/Middle_Empty/Reward3_Empty/Buy_Btn/Up_Empty/Btn_Text | TMPro.TextMeshProUGUI | Free |  |
| SuppliesPanel/SafeArea/All_Anim/Middle_Empty/Reward3_Empty/Unusable_Btn | UnityEngine.UI.Button |  |  |
| SuppliesPanel/SafeArea/All_Anim/Middle_Empty/Reward3_Empty/Unusable_Btn | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| SuppliesPanel/SafeArea/All_Anim/Middle_Empty/Reward3_Empty/Unusable_Btn/Up_Empty/Btn_Text | TMPro.TextMeshProUGUI | Free |  |
| SuppliesPanel/SafeArea/All_Anim/Middle_Empty/Reward3_Empty/Locked_Btn | UnityEngine.UI.Button |  |  |
| SuppliesPanel/SafeArea/All_Anim/Middle_Empty/Reward3_Empty/Locked_Btn | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| SuppliesPanel/SafeArea/All_Anim/Middle_Empty/Reward3_Empty/Locked_Btn/Up_Empty/Btn_Text | TMPro.TextMeshProUGUI | Free |  |
| SuppliesPanel/SafeArea/All_Anim/Middle_Empty/Reward3_Empty/Finished_Img | UnityEngine.UI.Button |  |  |
| SuppliesPanel/SafeArea/All_Anim/Middle_Empty/Reward3_Empty/Coin_Empty/Coin_Text | TMPro.TextMeshProUGUI | x105 |  |
| SuppliesPanel/SafeArea/All_Anim/Middle_Empty/Reward4_Empty/Buy_Btn | UnityEngine.UI.Button |  |  |
| SuppliesPanel/SafeArea/All_Anim/Middle_Empty/Reward4_Empty/Buy_Btn | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| SuppliesPanel/SafeArea/All_Anim/Middle_Empty/Reward4_Empty/Buy_Btn/Up_Empty/Btn_Text | TMPro.TextMeshProUGUI | Free |  |
| SuppliesPanel/SafeArea/All_Anim/Middle_Empty/Reward4_Empty/Unusable_Btn | UnityEngine.UI.Button |  |  |
| SuppliesPanel/SafeArea/All_Anim/Middle_Empty/Reward4_Empty/Unusable_Btn | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| SuppliesPanel/SafeArea/All_Anim/Middle_Empty/Reward4_Empty/Unusable_Btn/Up_Empty/Btn_Text | TMPro.TextMeshProUGUI | Free |  |
| SuppliesPanel/SafeArea/All_Anim/Middle_Empty/Reward4_Empty/Locked_Btn | UnityEngine.UI.Button |  |  |
| SuppliesPanel/SafeArea/All_Anim/Middle_Empty/Reward4_Empty/Locked_Btn | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
| SuppliesPanel/SafeArea/All_Anim/Middle_Empty/Reward4_Empty/Locked_Btn/Up_Empty/Btn_Text | TMPro.TextMeshProUGUI | Free |  |
| SuppliesPanel/SafeArea/All_Anim/Middle_Empty/Reward4_Empty/Finished_Img | UnityEngine.UI.Button |  |  |
| SuppliesPanel/SafeArea/All_Anim/Middle_Empty/Reward4_Empty/Coin_Empty/Coin_Text | TMPro.TextMeshProUGUI | x145 |  |
| SuppliesPanel/SafeArea/All_Anim/Middle_Empty/Bottom_Text | TMPro.TextMeshProUGUI | Grab Your <color=#fff000>Free</color> supplies! |  |
| SuppliesPanel/SafeArea/All_Anim/Btn_Close | UnityEngine.UI.Button |  |  |
| SuppliesPanel/SafeArea/All_Anim/Btn_Close | SolitarySpark.Runtime.UI.Components.ButtonSoundPlayer |  |  |
