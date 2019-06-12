﻿//======================================================================
//        Copyright (C) 2015-2020 Winddy He. All rights reserved
//        Email: hgplan@126.com
//======================================================================
using UnityEngine;
using System;
using System.Reflection;
using System.IO;
using System.Threading.Tasks;
using Knight.Hotfix.Core;
using Knight.Core;
using Knight.Core.WindJson;
using Knight.Framework.AssetBundles;
using UnityFx.Async;

namespace Game
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class ConfigPathAttribute : Attribute
    {
        public string AssetName;

        public ConfigPathAttribute(string rAssetName)
        {
            this.AssetName = rAssetName;
        }
    }

    [HotfixSBGroup("GameConfig")]
    public partial class GameConfig : HotfixSerializerBinary
    {
        public static GameConfig Instance
        {
            get { return HotfixSingleton<GameConfig>.GetInstance(); }
        }

        [ConfigPath("Avatar.json")] public Dict<int, ActorAvatar> Avatars;

        [ConfigPath("Hero.json")] public Dict<int, ActorHero> Heros;

        [ConfigPath("Professional.json")] public Dict<int, ActorProfessional> ActorProfessionals;

        [ConfigPath("StageConfig.json")] public Dict<int, StageConfig> StageConfigs;

        #region Loading...

        /// <summary>
        /// 加载本地原始资源，并导出为二进制资源
        /// </summary>
        public static void Load_Local(string rLocalAssetPath)
        {
            Instance.LoadLocal(rLocalAssetPath);
        }

        public void LoadLocal(string rLocalAssetPath)
        {
            var rMemberInfos = this.GetType().GetMembers();
            foreach (var rMemberInfo in rMemberInfos)
            {
                if (rMemberInfo.MemberType != MemberTypes.Field && rMemberInfo.MemberType != MemberTypes.Property)
                {
                    continue;
                }

                if (!rMemberInfo.IsApplyAttr(typeof(ConfigPathAttribute), false))
                {
                    continue;
                }

                var rConfigPathAttr = rMemberInfo.GetCustomAttribute<ConfigPathAttribute>(false);
                if (rConfigPathAttr == null)
                {
                    continue;
                }

                string rAssetPath = UtilTool.PathCombine(rLocalAssetPath, rConfigPathAttr.AssetName);
                string rJsonText = File.ReadAllText(rAssetPath);
                JsonNode rJsonNode = JsonParser.Parse(rJsonText);

                if (rMemberInfo.MemberType == MemberTypes.Field)
                {
                    FieldInfo rFieldInfo = rMemberInfo.DeclaringType.GetField(rMemberInfo.Name);
                    object rValue = rJsonNode.ToObject(rFieldInfo.FieldType);
                    rFieldInfo.SetValue(this, rValue);
                }
                else if (rMemberInfo.MemberType == MemberTypes.Property)
                {
                    PropertyInfo rPropInfo = rMemberInfo.DeclaringType.GetProperty(rMemberInfo.Name);
                    object rValue = rJsonNode.ToObject(rPropInfo.PropertyType);
                    rPropInfo.SetValue(this, rValue, null);
                }
            }

            string rBinaryPath = UtilTool.PathCombine(rLocalAssetPath.Replace("Text", "Binary"), "GameConfig.bytes");
            using (var fs = new FileStream(rBinaryPath, FileMode.Create, FileAccess.ReadWrite))
            {
                using (var br = new BinaryWriter(fs))
                {
                    this.Serialize(br);
                }
            }
        }

        /// <summary>
        /// 异步加载游戏配置
        /// </summary>
        public async Task Load(string rConfigABPath, string rConfigName)
        {
            var rAssetRequesst = await AssetLoader.Instance.LoadAssetAsync(rConfigABPath, rConfigName,
                ABPlatform.Instance.IsSumilateMode_Config());
            if (rAssetRequesst.Asset == null)
            {
                return;
            }

            TextAsset rConfigAsset = rAssetRequesst.Asset as TextAsset;
            if (rConfigAsset == null)
            {
                return;
            }

            using (var ms = new MemoryStream(rConfigAsset.bytes))
            {
                using (var br = new BinaryReader(ms))
                {
                    this.Deserialize(br);
                }
            }
        }

        /// <summary>
        /// 卸载资源包
        /// </summary>
        public void Unload(string rConfigABPath)
        {
            AssetLoader.Instance.UnloadAsset(rConfigABPath);
        }

        #endregion

        public ActorAvatar GetAvatar(int rAvatarID)
        {
            ActorAvatar rAvatar = null;
            this.Avatars.TryGetValue(rAvatarID, out rAvatar);
            return rAvatar;
        }

        public ActorHero GetHero(int rHeroID)
        {
            ActorHero rHero = null;
            this.Heros.TryGetValue(rHeroID, out rHero);
            return rHero;
        }

        public ActorProfessional GetActorProfessional(int rProfessionID)
        {
            ActorProfessional rProfessional = null;
            this.ActorProfessionals.TryGetValue(rProfessionID, out rProfessional);
            return rProfessional;
        }

        public StageConfig GetStageConfig(int rStageID)
        {
            StageConfig rStageConfig = null;
            this.StageConfigs.TryGetValue(rStageID, out rStageConfig);
            return rStageConfig;
        }
    }
}
