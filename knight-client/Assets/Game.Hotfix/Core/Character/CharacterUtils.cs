using UnityEngine;

namespace Knight.Hotfix.Core
{
    public class CharacterUtils
    {
        public static Knight CreateKnight(GameObject knightGo)
        {
            if (knightGo == null)
            {
                return null;
            }

            Knight knight = new Knight
            {
                GameObject = knightGo
            };
            return knight;
        }
    }
}
