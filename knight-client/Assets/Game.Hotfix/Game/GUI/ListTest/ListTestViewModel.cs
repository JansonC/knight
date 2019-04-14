using Knight.Core;
using Knight.Hotfix.Core;
using UnityEngine.UI;

namespace Game
{
    [DataBinding]
    public class ListDataItem : ViewModel
    {
        [DataBinding] public string Value1 { get; set; }

        [DataBinding] public string Value2 { get; set; }
    }

    [DataBinding]
    public class ListTestViewModel : ViewModel
    {
        private ObservableList<ListDataItem> mItemDatas;

        [DataBinding]
        public ObservableList<ListDataItem> ItemDatas
        {
            get { return mItemDatas; }
            set
            {
                mItemDatas = value;
                PropChanged("ItemDatas");
            }
        }
    }
}
