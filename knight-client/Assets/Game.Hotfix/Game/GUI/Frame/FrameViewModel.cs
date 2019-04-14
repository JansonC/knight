using Knight.Hotfix.Core;
using System.Collections.Generic;
using UnityEngine.UI;

namespace Game
{
    [DataBinding]
    public class MainFrameTabItem : ViewModel
    {
        [DataBinding] public string Name { get; set; }
    }

    [DataBinding]
    public class FrameViewModel : ViewModel
    {
        private string mPlayerName;
        private string mCoinCount;

        private List<MainFrameTabItem> mMainFrameTab;

        [DataBinding]
        public string PlayerName
        {
            get { return mPlayerName; }
            set
            {
                mPlayerName = value;
                PropChanged("PlayerName");
            }
        }

        [DataBinding]
        public string CoinCount
        {
            get { return mCoinCount; }
            set
            {
                mCoinCount = value;
                PropChanged("CoinCount");
            }
        }

        [DataBinding]
        public List<MainFrameTabItem> MainFrameTab
        {
            get { return mMainFrameTab; }
            set
            {
                mMainFrameTab = value;
                PropChanged("MainFrameTab");
            }
        }
    }
}
