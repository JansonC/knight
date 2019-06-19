using Knight.Core;
using Knight.Hotfix.Core;
using UnityEngine.UI;

namespace Game
{
    public class CropsPanel : ViewController
    {
        [DataBinding]
        private void OnBackBtnClicked(EventArg rEventArg)
        {
            Log.I("点击返回按钮");
            ViewManager.Instance.CloseView(GUID);
        }
    }
}
