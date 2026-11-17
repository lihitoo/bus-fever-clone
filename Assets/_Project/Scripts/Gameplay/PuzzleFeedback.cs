using System;
using Dreamy.Audio;
using Dreamy.Feedback;

namespace Dreamy.Template.Gameplay
{
    public enum PuzzleCue { Dispatch, Blocked, Boarding, Full, Win }
    public sealed class PuzzleFeedback : IDisposable
    {
        private readonly IAudioService audio;
        private readonly IHapticService haptics;
        private readonly AudioHandle[] handles = new AudioHandle[32];
        private int cursor;
        private bool paused, disposed;
        public PuzzleFeedback(IAudioService audio,IHapticService haptics) { this.audio=audio; this.haptics=haptics; }
        public void Play(PuzzleCue cue)
        {
            if (disposed || paused) return;
            string key = cue switch { PuzzleCue.Dispatch=>"bus.move",PuzzleCue.Blocked=>"bus.hit",PuzzleCue.Boarding=>"passenger.board",PuzzleCue.Full=>"bus.full",_=>"level.win" };
            if (audio != null)
            {
                audio.Stop(handles[cursor]);
                handles[cursor] = audio.Play(new AudioKey("core",key)).Handle;
                cursor=(cursor+1)%handles.Length;
            }
            if (cue != PuzzleCue.Boarding) haptics?.Play(cue == PuzzleCue.Win ? HapticType.Success : cue == PuzzleCue.Blocked ? HapticType.Warning : HapticType.Light);
        }
        public void Pause(bool value)
        {
            if (disposed || paused == value) return; paused=value;
            if (value) audio?.PauseBus(AudioBusId.Sfx); else audio?.ResumeBus(AudioBusId.Sfx);
        }
        public void Dispose()
        {
            if (disposed) return; if (paused) Pause(false); disposed=true;
            foreach (var handle in handles) audio?.Stop(handle);
        }
    }
}
