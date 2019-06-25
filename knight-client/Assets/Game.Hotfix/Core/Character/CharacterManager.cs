using System;
using System.Threading.Tasks;
using Knight.Core;
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

        public async Task<Knight.Hotfix.Core.Knight> BuildKnight(int knightId)
        {
            var loaderRequest = CharacterAssetLoader.Instance.LoadKnight(knightId);
            if (loaderRequest.CharacterPrefabGo == null)
            {
                Log.CI(Log.COLOR_RED, "创建骑士出错，未找到预制体：{0}", knightId);
                return null;
            }

            GameObject knightGo = knightRoot.transform.AddChild(loaderRequest.CharacterPrefabGo);
            Knight.Hotfix.Core.Knight knight = CharacterUtils.CreateKnight(knightGo);
            string knightGUID = Guid.NewGuid().ToString();
            if (knight == null)
            {
                Log.CI(Log.COLOR_RED, "Knight GameObject {0} is null.", knightGo.name);
                return null;
            }

            try
            {
                await knight.Initialize(knightId, knightGUID);
                await knight.Open();
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }

            return knight;
        }

        public async Task<Knight.Hotfix.Core.Monster> BuildMonster(int monsterId)
        {
            var loaderRequest = CharacterAssetLoader.Instance.LoadMonster(monsterId);
            if (loaderRequest.CharacterPrefabGo == null)
            {
                Log.CI(Log.COLOR_RED, "创建怪物出错，未找到预制体：{0}", monsterId);
                return null;
            }

            GameObject mosnterGo = monsterRoot.transform.AddChild(loaderRequest.CharacterPrefabGo);
            Knight.Hotfix.Core.Monster monster = CharacterUtils.CreateMonster(mosnterGo);
            string monsterGUID = Guid.NewGuid().ToString();
            if (monster == null)
            {
                Log.CI(Log.COLOR_RED, "Knight GameObject {0} is null.", mosnterGo.name);
                return null;
            }

            try
            {
                await monster.Initialize(monsterId, monsterGUID);
                await monster.Open();
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }

            return monster;
        }
    }
}
