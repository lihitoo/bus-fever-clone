using System.Linq;
using Dreamy.Audio;
using UnityEditor;
using UnityEngine;

namespace Dreamy.Template.Editor
{
    public static class PuzzleAudioAuthoring
    {
        public static string Build()
        {
            const string folder="Assets/_Project/Art/BusFever/Audio/";
            var library=AssetDatabase.LoadAssetAtPath<AudioLibrary>("Assets/DreamyAudioLibrary.asset");
            var serializedLibrary=new SerializedObject(library); var sounds=serializedLibrary.FindProperty("sounds");
            foreach(string key in new[] { "bus.move","bus.hit","passenger.board","bus.full","level.win","level.switch" })
            {
                string path=folder+key+".asset";
                var file=AssetDatabase.LoadAssetAtPath<SoundAudioFile>(path);
                if(file==null) { file=ScriptableObject.CreateInstance<SoundAudioFile>(); AssetDatabase.CreateAsset(file,path); }
                var serialized=new SerializedObject(file);
                serialized.FindProperty("key").stringValue=key;
                serialized.FindProperty("bus").stringValue="sfx";
                serialized.FindProperty("volume").floatValue=1;
                serialized.FindProperty("randomPitch").floatValue=0;
                serialized.FindProperty("maxInstances").intValue=key=="passenger.board"?4:2;
                serialized.FindProperty("cooldownSeconds").floatValue=key=="passenger.board"?.04f:0;
                var clips=serialized.FindProperty("clips");clips.arraySize=1;
                clips.GetArrayElementAtIndex(0).objectReferenceValue=AssetDatabase.LoadAssetAtPath<AudioClip>(folder+key+".wav");
                serialized.ApplyModifiedPropertiesWithoutUndo();AssetDatabase.SaveAssetIfDirty(file);
                bool exists=false;
                for(int i=0;i<sounds.arraySize;i++) if(sounds.GetArrayElementAtIndex(i).objectReferenceValue==file)exists=true;
                if(!exists) { int index=sounds.arraySize++; sounds.GetArrayElementAtIndex(index).objectReferenceValue=file; }
            }
            serializedLibrary.ApplyModifiedPropertiesWithoutUndo();AssetDatabase.SaveAssetIfDirty(library);
            return "Six recovered source audio cues registered with Dreamy Audio; gain/cooldown are provisional host tuning.";
        }
    }
}
