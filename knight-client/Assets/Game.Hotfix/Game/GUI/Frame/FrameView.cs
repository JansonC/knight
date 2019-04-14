using Knight.Hotfix.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using Knight.Core;
using UnityEngine.UI;

namespace Game
{
    public class FrameView : ViewController
    {
        [HotfixBinding("MainFrame")] public FrameViewModel MainFrame;

        private int mCurIndex;
        private int mPrevIndex;

        private View mListTestView;

        protected override async Task OnInitialize()
        {
            await base.OnInitialize();

            mCurIndex = 0;
            mPrevIndex = 0;

            MainFrame.PlayerName = Account.Instance.PlayerName;
            MainFrame.CoinCount = LogicUtilTool.ToCountString(Account.Instance.CoinCount);

            MainFrame.MainFrameTab = new List<MainFrameTabItem>()
            {
                new MainFrameTabItem() {Name = "战 斗"},
                new MainFrameTabItem() {Name = "基 地"},
                new MainFrameTabItem() {Name = "商 城"},
            };
        }

        protected override async Task OnOpen()
        {
            await base.OnOpen();
            // 打开故事大厅
            mListTestView = await FrameManager.Instance.OpenPageUIAsync("KNListTest", View.State.PageSwitch);
        }

        [DataBinding]
        public void OnMainFrameTabChanged(EventArg rEventArg)
        {
            var nCurIndex = rEventArg.Get<int>(0);
            if (nCurIndex == mCurIndex) return;

            mPrevIndex = mCurIndex;
            mCurIndex = nCurIndex;

            if (mCurIndex == 0)
            {
                // 打开故事大厅
                mListTestView.Show();
            }
            else
            {
                mListTestView.Hide();
            }
        }
    }
}
