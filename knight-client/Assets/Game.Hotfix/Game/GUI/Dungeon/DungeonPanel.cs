using System.Threading.Tasks;
using Knight.Core;
using Knight.Hotfix.Core;
using UnityEngine.UI;

namespace Game
{
    public class DungeonPanel : ViewController
    {
        protected override async Task OnInitialize()
        {
            await base.OnInitialize();
        }

        [DataBinding]
        private void OnBackBtnClicked(EventArg rEventArg)
        {
            Log.CI(Log.COLOR_ORANGE, "点击返回按钮");
            ViewManager.Instance.CloseAllDaynamicViews();
            StageManager.Instance.SwitchSatge("MainStage");
        }
    }
}
