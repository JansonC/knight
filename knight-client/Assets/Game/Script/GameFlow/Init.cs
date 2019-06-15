﻿//======================================================================
//        Copyright (C) 2015-2020 Winddy He. All rights reserved
//        Email: hgplan@126.com
//======================================================================
using UnityEngine;
using Knight.Core;
using Knight.Framework.Hotfix;
using System.Threading.Tasks;
using UnityEngine.UI;
using Knight.Framework.AssetBundles;
using Knight.Framework.Stage;

namespace Game
{
    /// <summary>
    /// 游戏初始化
    /// </summary>
    internal class Init : MonoBehaviour
    {
        public bool needLog = false;
        public string HotfixABPath = "";
        public string HotfixModule = "";

        async void Start()
        {
            Log.IsActive = needLog;
            Log.CI(Log.COLOR_ORANGE, "游戏启动");
            //限帧
            Application.targetFrameRate = 60;

            // 初始化事件管理器
            EventManager.Instance.Initialize();

            // 初始化协程管理器
            CoroutineManager.Instance.Initialize();

            // 加载游戏本地脚本
            TypeResolveManager.Instance.Initialize();
            TypeResolveManager.Instance.AddAssembly("Game");
            TypeResolveManager.Instance.AddAssembly("Game.Hotfix", true);

            // 初始化热更新模块
            HotfixRegister.Register();
            HotfixManager.Instance.Initialize();

            // 初始化舞台模块
            StageRoot.Instance.Initialize();

            // 初始化UI模块
            UIRoot.Instance.Initialize();

            // 初始化加载进度条
            GameLoading.Instance.LoadingView = LoadingView_Knight.Instance;
            GameLoading.Instance.StartLoading(0.5f, "游戏初始化阶段，开始加载资源...");

            //异步初始化代码
            await Start_Async();
        }

        private async Task Start_Async()
        {
            Log.CI(Log.COLOR_YELLOW, "开始初始化");

            // 平台初始化
            await ABPlatform.Instance.Initialize();

            // 资源下载模块初始化
            await ABUpdater.Instance.Initialize();

            // 初始化资源加载模块
            AssetLoader.Instance = new ABLoader();
            AssetLoader.Instance.Initialize();

            GameLoading.Instance.Hide();
            GameLoading.Instance.StartLoading(1.0f, "游戏初始化阶段，开始加载资源...");

            // 加载热更新代码资源
            await HotfixManager.Instance.Load(HotfixABPath, HotfixModule);

            // 开始热更新端的游戏主逻辑
            await HotfixGameMainLogic.Instance.Initialize();

            Log.CI(Log.COLOR_YELLOW, "初始化结束");
        }
    }
}
