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

        public static Monster CreateMonster(GameObject knightGo)
        {
            if (knightGo == null)
            {
                return null;
            }

            Monster monster = new Monster
            {
                GameObject = knightGo
            };
            return monster;
        }
    }
}
