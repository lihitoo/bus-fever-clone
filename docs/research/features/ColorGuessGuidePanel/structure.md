# ColorGuessGuidePanel — cấu trúc UI

Bằng chứng: `file-observed`, XAPK 1.3.2/build 65. Chưa tự xác nhận panel này đã được mở khi chơi; xem hồ sơ runtime riêng.

Có 50 MonoBehaviour component; 0 component có liên kết media xuất được. [Bảng chi tiết](ui-elements.csv) chứa hierarchy, path ID, anchor/pivot, font/text, sprite, raycast và toàn bộ serialized fields. Tọa độ là dữ liệu prefab, chưa phải bounding box runtime.

| Hierarchy | Component | Text mặc định | Sprite |
| --- | --- | --- | --- |
| ColorGuessGuidePanel/BtnBackground | UnityEngine.UI.Button |  |  |
| ColorGuessGuidePanel/Step_1/TxtMarker | TMPro.TextMeshProUGUI | TAP |  |
| ColorGuessGuidePanel/Step_1/TxtTitle | TMPro.TextMeshProUGUI | Choose a Bottle |  |
| ColorGuessGuidePanel/Step_1/TxtDesc | TMPro.TextMeshProUGUI | Tap an available bottle to start the formula. |  |
| ColorGuessGuidePanel/Step_2/TxtMarker | TMPro.TextMeshProUGUI | NEXT |  |
| ColorGuessGuidePanel/Step_2/TxtTitle | TMPro.TextMeshProUGUI | Fill the Row |  |
| ColorGuessGuidePanel/Step_2/TxtDesc | TMPro.TextMeshProUGUI | Bottles fill the next empty slot from left to right. |  |
| ColorGuessGuidePanel/Step_3/TxtMarker | TMPro.TextMeshProUGUI | MATCH |  |
| ColorGuessGuidePanel/Step_3/TxtTitle | TMPro.TextMeshProUGUI | Keep Matches |  |
| ColorGuessGuidePanel/Step_3/TxtDesc | TMPro.TextMeshProUGUI | Correct bottles stay locked in their matching slots. |  |
| ColorGuessGuidePanel/Step_4/TxtMarker | TMPro.TextMeshProUGUI | MISS |  |
| ColorGuessGuidePanel/Step_4/TxtTitle | TMPro.TextMeshProUGUI | Try Again |  |
| ColorGuessGuidePanel/Step_4/TxtDesc | TMPro.TextMeshProUGUI | Wrong bottles break and return on the next attempt. |  |
| ColorGuessGuidePanel/Step_5/TxtMarker | TMPro.TextMeshProUGUI | READY |  |
| ColorGuessGuidePanel/Step_5/TxtTitle | TMPro.TextMeshProUGUI | Earn Elixirs |  |
| ColorGuessGuidePanel/Step_5/TxtDesc | TMPro.TextMeshProUGUI | Beat levels to collect more bottles for the lab. |  |
| ColorGuessGuidePanel/TxtStep | TMPro.TextMeshProUGUI | 1/5 |  |
