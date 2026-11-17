using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using UnityEngine;

namespace Dreamy.Template.Tests
{
    /// <summary>Test-only capture, outside Assets. Timestamps preserve real timing when encoding sparse Editor frames.</summary>
    public sealed class M02FlowCapture : MonoBehaviour
    {
        [Serializable] private sealed class Frame { public string file; public double seconds; }
        [Serializable] private sealed class Receipt { public string directory; public List<Frame> frames = new(); }
        private readonly Receipt receipt = new();
        private double started, next;
        private void Awake()
        {
            receipt.directory = Path.Combine(Path.GetTempPath(), "bus-fever-m02-" + Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(receipt.directory);
            started = Time.realtimeSinceStartupAsDouble; next = started;
        }
        private IEnumerator Start()
        {
            while (true)
            {
            yield return new WaitForEndOfFrame();
            double now = Time.realtimeSinceStartupAsDouble;
            if (now < next) continue;
            next = now + .5;
            string name = receipt.frames.Count.ToString("D5") + ".png";
            // Complete the file write before recording the frame; no deferred screenshot requests across scene loads.
            var texture = ScreenCapture.CaptureScreenshotAsTexture();
            try { File.WriteAllBytes(Path.Combine(receipt.directory,name), texture.EncodeToPNG()); }
            finally { Destroy(texture); }
            receipt.frames.Add(new Frame { file = name, seconds = now - started });
            }
        }
        private void OnDestroy()
        {
            const string path = "docs/clone-plan/evidence/M02/flow-capture-frames.json";
            Directory.CreateDirectory(Path.GetDirectoryName(path));
            File.WriteAllText(path, JsonUtility.ToJson(receipt, true));
        }
    }
}
