> **SDK decision mới:** SDK ngoài do DreamySDK xử lý; hiện dùng API stub/default theo user để local test. Không cần provider thật cho local UI acceptance. Production/provider gates vẫn riêng. [Contract](11-dreamy-sdk-boundary.md).

# Quyết định, rủi ro và release gates

| ID | Quyết định hiện tại | Khi xem lại |
| --- | --- | --- |
| ADR01 | Dùng template hiện hữu, giữ GameInstaller service ownership; VContainer giới hạn Home và gameplay session, installer riêng từng feature | Khi bridge/borrowed lifetime test fail hoặc có ADR chứng minh cần mở rộng container |
| ADR02 | Dreamy PanelManager/PresenterFactory vẫn điều khiển panel lifecycle | Khi version package target thay đổi contract factory/cache |
| ADR03 | Dùng chung source assets theo user, provenance vẫn ghi build | Khi thấy khác behavior/content ở capture |
| ADR04 | Một wallet, một save authority, mọi reward dùng transaction/receipt | Không thay đổi trừ package contract review chính thức |
| ADR05 | Mỗi feature thay UI ngay normal route và nghiệm thu trước khi chuyển | Khi blocker độc lập cần đổi thứ tự, ghi dependency/coverage lý do |
| ADR06 | Reuse Tutorial/Progression/Missions/DailyReward/LuckyWheel sẵn có, không dựng lại từ đầu | Consumer verification chỉ ra scope gap cụ thể |
| ADR07 | Ranking/events/providers chưa có bằng chứng giữ gated, không fake online success | Khi có SDK/account/backend và source flow verified |

## Risk register

| Risk | Mức | Giải pháp và gate |
| --- | --- | --- |
| Source Unity2022→Unity6 URP | Cao | Material/shader/crowd/Spine pilot + matched captures trước batch import |
| Registry toolkit cũ vs packages current | Cao | Pin/hash ledger, source review, consumer test; không tự upgrade hoặc downgrade toàn graph |
| ServiceLocator và VContainer hai owners | Cao | Borrowed bridge; exactly-one instance/dispose tests trên reload/fail/cancel |
| Shop simulation grant Purchased | Critical production | Bắt buộc thay gateway, dev flag/mock tách; production no provider trả unavailable, không grant |
| AES/content/native rules thiếu | Critical exact parity | Discovery blockers riêng; không tuyên bố whole-game khi còn unknown |
| Video <1FPS/audio chưa sync | Cao feel | Capture pipeline/device thật; không fit curve runtime bằng ảnh thưa |
| Duplicate rewards / late SDK callback | Critical economy | Transaction/session IDs, atomic receipt, replay/restart/fault tests |
| Timed events/clock drift | Cao | Clock gateway, trusted-time policy, offline grace theo nguồn, test boundary; không silently trust altered local time |
| Cached presenter/listeners/pooled FX leaks | Cao mobile | Reopen20/retry50/scene reload, allocations and handle baseline |
| Moving upstream branches | Vừa | Record git hashes, pin trước implementation acceptance; không update ngoài feature scope |
| Localization deps TMP5 conflict | Cao integration | UPM resolve thử có rollback, font rendering smoke, không dùng README version như proof |
| Backend/ads/billing/account thiếu | Cao | Contract tests có controlled provider, nhưng real service gate riêng không pass từ mock |

## Definition of Ready

Task có source-state + scope + owner + input/config/save boundary + package pin + asset dependencies + callable entry + test/scenario + expected evidence. Feature bị khóa/unknown vẫn được ghi chi tiết discovery task; implementation của semantics đó không bắt đầu bằng đoán.

## Definition of Done

Task artifacts hiện hữu và reviewable; đúng entry normal flow; UI mới đã route thật; required static/behavior/lifecycle/visual gates pass, evidence đúng hash/revision; error/cancel/relaunch test theo risk; không TODO chặn correctness; no demo production success; remaining gaps explicit. Review complete ở browser không phải verified trong plan.

## Whole-game exit

Toàn bộ feature families và screen/state graph có coverage, level manifest được reconcile, imports/fonts/materials/shaders đủ, functional/visual/feel/device/services gates không còn blocker bắt buộc. Android build ký đúng ownership, version/permissions/privacy/store SDK kiểm tra; symbols và smoke install/launch/upgrade/relaunch pass. Không publish, push tag, mua IAP thật hoặc deploy backend tự động trong task plan này.

## Change control

Mỗi lần nguồn thay version, package/hash đổi, hoặc thêm level family phải cập nhật requirement/source map, dependent task evidence eligibility và dashboard revision. Không xóa task khó để tăng %. Package proposal không nằm trong game critical path trừ khi adapter hiện tại không thể đúng; extraction/generalization package có test/sample/consumer riêng.
