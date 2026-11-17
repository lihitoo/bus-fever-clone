# TUTORIAL ? current M03 contract

Dreamy Tutorial0.3.0 owns persisted checkpoints, step tokens, accepted signals, suspend/resume and pending-save retry. GameplayTutorialBridge only adapts game input and reference art. The former local TutorialSequence was removed; a recreated board permits already-taught prerequisites without replaying persisted checkpoints.

Normal route: Level1 entry ? package state ? resolve stable vehicle ID ? show hand/card/outline ? reject wrong or busy input ? dispatch accepted by PuzzleSession ? report captured package signal ? next checkpoint. Pause suspends the package; disposal unsubscribes and hides presentation. No view or domain code resolves VContainer services.

Reference R004 shows a bright board, cream bordered instruction card and yellow outline. The card sprite is Main_Guid_Bg_1 (138x132, source sprite border retained), bound as a sliced Image. Its original recovered prefab hierarchy was incomplete, so the existing GameplayPanel owns the card layout. Source hand follows the projected vehicle every LateUpdate. The inverted hull outline uses world-space width to account for source mesh scale. There is no full-screen dark spotlight in the observed first-step state.

Bindings: evidence/M03/tutorial-card-binding.json and hand-import.json. Current image: media/current/M02/M03-tutorial-latest.png. This screenshot explicitly forces presentation of blue-top without modifying the user's persisted cursor. The separate real-package integration test proves checkpoint reload, stale-signal rejection and completed-flow suppression.

Acceptance still open: later VIP target/tutorial content, exact original target order and hand tween, camera/aspect/target-loss recovery and broader save-failure scenarios. Source card, hand and visible yellow target outline have been opened and compared with R004; visual parity of the entire board is not asserted.
