using System;
using Dreamy.DataConfig;

namespace Dreamy.Template.Gameplay
{
    [DataConfig("puzzleCatalog")]
    public sealed class PuzzleCatalog : ConfigBase
    {
        public PuzzleDefinition[] Levels { get; set; }
        public PuzzleDefinition Find(int level) => Array.Find(Levels,d => d.LevelNumber == level);
        public override void Initialize(string documentName)
        {
            if (Levels == null || Levels.Length == 0) throw new ArgumentException("Puzzle catalog is empty.");
            var ids = new System.Collections.Generic.HashSet<int>();
            foreach (var level in Levels)
            { level.Validate(); if (level.LevelNumber < 1 || !ids.Add(level.LevelNumber)) throw new ArgumentException("Duplicate level number."); }
        }
    }
}
