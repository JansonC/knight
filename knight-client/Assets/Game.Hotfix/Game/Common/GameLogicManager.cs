//======================================================================
//        Copyright (C) 2015-2020 Winddy He. All rights reserved
//        Email: hgplan@126.com
//======================================================================
using System.Threading.Tasks;
using Knight.Core;
using Knight.Framework.Hotfix;
using Knight.Hotfix.Core;

namespace Game
{
    public class GameLogicManager
    {
        public async Task Initialize()
        {
            // [0] 其他模块的初始化
            // 事件模块管理器
            HotfixEventManager.Instance.Initialize();

            // 舞台管理器
            StageManager.Instance.Initialize();

            // ViewModel管理器
            ViewModelManager.Instance.Initialize();

            // UI模块管理器
            ViewManager.Instance.Initialize();

            // 开始游戏Init流程
            await Init.Start_Async();

            Log.CI(Log.COLOR_GREEN, "热更新完毕");
        }

        public void Update()
        {
            // UI的模块更新逻辑
            ViewManager.Instance.Update();
        }
    }
}
