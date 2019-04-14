using Knight.Hotfix.Core;
using UnityEngine.UI;
using Knight.Core;

namespace Game
{
    public class LoginView : ViewController
    {
        [HotfixBinding("Login")] public LoginViewModel ViewModel;

        [DataBinding]
        private void OnBtnButton_Clicked(EventArg rEventArg)
        {
            GameLoading.Instance.StartLoading(1.0f, "进入游戏大厅...");
            ViewManager.Instance.CloseView(GUID);

            // @TODO: 账户数据通过网络初始化
            Account.Instance.Initialize();

            World.Instance.Initialize();
        }
    }
}
