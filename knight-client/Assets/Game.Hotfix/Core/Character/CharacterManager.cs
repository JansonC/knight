using Knight.Framework.Character;
using Knight.Hotfix.Core;
using UnityEngine;

namespace Game
{
    public class CharacterManager : THotfixSingleton<CharacterManager>
    {
        private GameObject knightRoot;
        private GameObject monsterRoot;

        private CharacterManager()
        {
        }

        public void Initialize()
        {
            knightRoot = CharacterRoot.Instance.KnightRoot;
            monsterRoot = CharacterRoot.Instance.MonsterRoot;
        }
    }
}
