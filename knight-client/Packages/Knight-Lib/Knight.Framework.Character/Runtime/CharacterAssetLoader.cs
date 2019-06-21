using Knight.Core;
using UnityEngine;

namespace Knight.Framework.Character
{
    public class CharacterAssetLoader : TSingleton<CharacterAssetLoader>
    {
        public class LoaderRequest
        {
            public GameObject CharacterPrefabGo;
            public string CharacterName;

            public LoaderRequest(string CharacterName)
            {
                this.CharacterName = CharacterName;
            }
        }

        private CharacterAssetLoader()
        {
        }

        public LoaderRequest LoadKnight(int knightId)
        {
            string knightName = "knight" + knightId;
            string knightABPath = "game/character/knight/" + knightName + ".ab";
            return LoadCharacter(knightName, knightABPath);
        }

        public LoaderRequest LoadMonster(int monsterId)
        {
            string monsterName = "monster" + monsterId;
            string monsterABPath = "game/character/knight/" + monsterName + ".ab";
            return LoadCharacter(monsterName, monsterABPath);
        }

        /// <summary>
        /// 加载角色资源
        /// </summary>
        public LoaderRequest LoadCharacter(string cName, string cABPath)
        {
            LoaderRequest rRequest = new LoaderRequest(cName);
            var rAssetRequest = AssetLoader.Instance.LoadAsset(cABPath, rRequest.CharacterName,
                AssetLoader.Instance.IsSumilateMode_GUI());
            if (rAssetRequest.Asset != null)
            {
                rRequest.CharacterPrefabGo = rAssetRequest.Asset as GameObject;
            }

            return rRequest;
        }

        public void UnloadKnight(int knightId)
        {
            string knightName = "knight" + knightId;
            string knightABPath = "game/character/knight/" + knightName + ".ab";
            UnloadCharacter(knightABPath);
        }

        public void UnloadMonster(int monsterId)
        {
            string monsterName = "monster" + monsterId;
            string monsterABPath = "game/character/knight/" + monsterName + ".ab";
            UnloadCharacter(monsterABPath);
        }

        /// <summary>
        /// 卸载角色资源
        /// </summary>
        public void UnloadCharacter(string cABPath)
        {
            AssetLoader.Instance.UnloadAsset(cABPath);
        }
    }
}
