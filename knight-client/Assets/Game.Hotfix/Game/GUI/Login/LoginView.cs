using Knight.Hotfix.Core;
using System.Threading.Tasks;
using UnityEngine.UI;
using Knight.Core;

namespace Game
{
    public class LoginView : ViewController
    {
        protected override async Task OnInitialize()
        {
            await base.OnInitialize();
            Account.Instance.PlayerName = "Knight";
            Account.Instance.GlodCount = 999;
            Account.Instance.HeadIcon = "m1";
        }

        [DataBinding]
        private void OnBtnButton_Clicked(EventArg rEventArg)
        {
            GameLoading.Instance.StartLoading(1.0f, "进入游戏大厅...");
            ViewManager.Instance.CloseView(GUID);
            World.Instance.Initialize().WarpErrors();
        }
    }
}
