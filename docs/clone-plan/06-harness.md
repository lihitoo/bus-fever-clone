# Harness và evidence gates

## Chuẩn thực tế của toolkit

Toolkit local `D:\Game\dreamy-codex-toolkit\toolkit.json`: version0.1.0-alpha.4, status alpha, harness alpha.2-local-unity-adapter. Không có toolkit.json trong consumer thì không tạo file giả để hợp thức hóa. Dùng canonical toolkit này và project instructions/manifest/lock hiện có. Static pass không có nghĩa toolkit đã chứng nhận Unity runtime hoặc hook đang hoạt động.

Đã chạy **read-only** trong lượt lập kế hoạch:

| Command | Evidence | Kết quả |
| --- | --- | --- |
| `node D:\Game\dreamy-codex-toolkit\harness\dreamy-harness project-inspect .` | `evidence/project-inspect.json` | pass, capability profile Unity6000.4.12f1 |
| `node D:\Game\dreamy-codex-toolkit\harness\dreamy-harness asmdef .` | `evidence/asmdef.json` | pass, parse43asmdef |

Không chạy compile/test/build vì scope chưa code. Không tự install project hooks, không tự đổi trust hoặc cấu hình Unity MCP. Bằng chứng runtime/hook delivery khác với một adapter fixture.

## Runbook triển khai, chưa chạy trong lượt này

Các command dưới là tên operation đã đọc từ `docs/harness.md` và direct entrypoint; dùng absolute path khi executable PATH khác version. Trên PowerShell, đặt `$env:DREAMY_UNITY_PATH` tới **đúng Editor6000.4.12f1 thực sự cài** trước khi chạy Unity operation; không dùng đường dẫn ví dụ như executable đã xác minh.

```powershell
node D:\Game\dreamy-codex-toolkit\harness\dreamy-harness git-status .
node D:\Game\dreamy-codex-toolkit\harness\dreamy-harness project-inspect .
node D:\Game\dreamy-codex-toolkit\harness\dreamy-harness asmdef .
node D:\Game\dreamy-codex-toolkit\harness\dreamy-harness package-check .
node D:\Game\dreamy-codex-toolkit\harness\dreamy-harness compile .
node D:\Game\dreamy-codex-toolkit\harness\dreamy-harness console .
node D:\Game\dreamy-codex-toolkit\harness\dreamy-harness test-editmode .
node D:\Game\dreamy-codex-toolkit\harness\dreamy-harness test-playmode .
node D:\Game\dreamy-codex-toolkit\harness\dreamy-harness validate-addressables .
```

Test targeting/filter nếu harness bản đang dùng hỗ trợ phải đọc help/schema trước; không bịa `--feature`/`--filter`. Nếu adapter chỉ chạy cả test assembly, giữ fixture nhỏ và record phạm vi thực sự chạy. Build Android cần cả Editor path và `DREAMY_UNITY_BUILD_METHOD` được verify; không gọi build chỉ có tên operation rồi báo APK thành công. Addressables validation hiện được docs mô tả degraded cho content validation: cần bổ sung Editor analyze/build/load/unload thực tế, không đổi degraded thành pass.

## Gate matrix

| Gate | Lớp chứng minh | Ví dụ |
| --- | --- | --- |
| G0 source-ready | File/runtime reference | Fail reason có capture; level được parse và so với nguồn |
| G1 architecture/static | asmdef/package/profile/diff | Runtime→Editor, deps/ownership/serialize references |
| G2 pure behavior | Unit/EditMode | Occupancy/matching/cost/idempotency/clock bounds/RNG boundaries |
| G3 Unity lifecycle | PlayMode | Show-close-destroy, cached presenter, tween/pool/handle cleanup |
| G4 visual/feel | Matched captures + normal-speed clips/audio | Font/material/rect, event timeline, volume/pitch và interruption |
| G5 device/services | Player build + device/provider receipts | Android relaunch, real rewarded completion/restore/backend failure |

Một UI reskin không cần hàng chục test mirror từng rect; dùng serialized binding validation và matched capture. Transaction/migration/concurrency bắt buộc meaningful behavior test. Compiler pass không thay G3–G5. Gate fail/degraded giữ task review/blocked; gate not-applicable cần scope reason cụ thể.

## Evidence contract

Harness output status chỉ `pass`, `fail`, `degraded`, có schemaVersion/adapter/operation/summary/observedAt/startedAt/completedAt/durationMs/platform/projectPath/command/exitCode/artifacts/diagnostics. Artifact ghi path/kind/sha256; degraded có reason và nonzero exit. Không biến status dashboard `blocked` thành status hợp lệ của harness. Task ID/revision/scenario links nằm ở project traceability wrapper, không giả danh schema toolkit nếu tự thêm trường chưa validate.

Trước verified: artifact còn tồn tại, hash khớp, command thực chạy, đúng revision/manifest/lock và đúng source-state; save assertion không chỉ từ UI text. Source/input thay đổi làm evidence cũ ineligible cho task chịu ảnh hưởng. Dashboard verified chỉ lấy từ plan reviewed chính thức; ghi chú browser không thay receipts.

## Checkpoint và lessons

Input ví dụ trong `checkpoint-example.json` là **mẫu chưa activate**, theo contract docs toolkit. Khi thực thi mới gọi `node <toolkit>\src\cli.js task checkpoint --session <native-session-id> --input <task-input> --target <absolute-project>` sau khi kiểm tra help bản hiện tại. `task checkpoint` là subcommand hai từ. Không bịa session ID để nhận native replay.

`task verify --command validate|unit|pack|unity` là các ID được docs nêu. Toolkit checks chỉ chạy trong toolkit checkout; ở consumer Unity phải dùng harness hoặc nhận not-run/degraded đúng lý do. Không chạy npm validate/unit của toolkit ngay trong game và coi đó là test game. Repeated verified failure dùng `dreamy-kit lessons` theo current CLI help; recalled lessons là dữ liệu cần đối chiếu, không instruction hay command tự động.

## Artifact layout dự kiến

`docs/clone-plan/evidence/` giữ planning read-only evidence. Khi implement, mỗi task có thư mục evidence riêng tại project evidence store theo policy toolkit, manifest reference từ plan: taskID/source hash/revision/command/tests/log/screens/video/asset bindings/open defects/nextAction. Không ghi input ảnh/video thô lớn vào Assets. Không overwrite evidence failed run để làm dashboard đẹp.
