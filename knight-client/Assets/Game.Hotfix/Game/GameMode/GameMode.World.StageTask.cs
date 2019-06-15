using Knight.Hotfix.Core;
using System.Threading.Tasks;
using Knight.Core;
using UnityFx.Async;

namespace Game
{
    public partial class GameMode_World
    {
        /// <summary>
        /// 加载场景资源的StageTask
        /// </summary>
        public class StageTask_LoadAssets : StageTask
        {
            public GameMode_World GameMode;

            public StageTask_LoadAssets(GameMode_World rGameMode)
            {
                this.GameMode = rGameMode;
            }

            protected override bool OnInit()
            {
                Log.I("LoadAssets Init");
                name = "LoadAssets";
                return true;
            }

            protected override async Task OnRun_Async()
            {
                await base.OnRun_Async();
            }
        }

        /// <summary>
        /// 初始化数据， 加载界面
        /// </summary>
        public class StageTask_InitData : StageTask
        {
            public GameMode_World GameMode;

            public StageTask_InitData(GameMode_World rGameMode)
            {
                GameMode = rGameMode;
            }

            protected override bool OnInit()
            {
                Log.I("InitData Init");
                name = "InitData";
                return true;
            }

            protected override async Task OnRun_Async()
            {
                await StageManager.Instance.SwitchSatge("MainStage");

                //打开Login界面
                await ViewManager.Instance.OpenAsync("MainStageInfoPanel", View.State.Fixing);
                await WaitAsync.WaitForSeconds(1.0f);

                //隐藏进度条
                GameLoading.Instance.Hide();

                Log.CI(Log.COLOR_ORANGE, "游戏关卡数据初始化完毕");
            }
        }
    }
}
