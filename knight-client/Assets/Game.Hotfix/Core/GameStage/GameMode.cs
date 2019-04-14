//======================================================================
//        Copyright (C) 2015-2020 Winddy He. All rights reserved
//        Email: hgplan@126.com
//======================================================================

using System;
using System.Collections.Generic;
using Knight.Core;

namespace Knight.Hotfix.Core
{
    /// <summary>
    /// 游戏模式的基类
    /// </summary>
    public class GameMode
    {
        /// <summary>
        /// 得到当前的游戏模式
        /// </summary>
        public static Func<GameMode> GetCurrentMode;

        /// <summary>
        /// 游戏关卡管理器对象
        /// </summary>
        public GameStageManager GSM;

        /// <summary>
        /// 初始化游戏数据
        /// </summary>
        public void InitData()
        {
            //设置GameStageManager
            GSM = GameStageManager.Instance;
            // 构建GameStages
            GSM.gameStages = new Dict<int, GameStage>();
            // 构建GameStages
            OnBuildStages();
        }

        public void Update()
        {
            OnUpdate();
        }

        public void Destroy()
        {
            OnDestroy();
        }

        protected virtual void OnBuildStages()
        {
        }

        protected virtual void OnUpdate()
        {
        }

        protected virtual void OnDestroy()
        {
        }

        public void AddGameStage(int nIndex, params StageTask[] rStageTasks)
        {
            GameStage rStageLoadAssets = new GameStage();
            rStageLoadAssets.index = nIndex;
            rStageLoadAssets.taskList = new List<StageTask>();
            rStageLoadAssets.taskList.AddRange(rStageTasks);
            GSM.gameStages.Add(rStageLoadAssets.index, rStageLoadAssets);
        }
    }
}
