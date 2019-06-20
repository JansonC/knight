using UnityEngine;

namespace Knight.Framework.Character
{
    public class CharacterRoot : MonoBehaviour
    {
        public static CharacterRoot Instance { get; private set; }

        public GameObject KnightRoot;
        public GameObject MonsterRoot;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        public void Initialize()
        {
        }
    }
}
