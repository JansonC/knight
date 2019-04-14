using Knight.Core;
using Knight.Hotfix.Core;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class ListTestView : ViewController
    {
        [HotfixBinding("ListTest")] public ListTestViewModel ListTest;

        protected override async Task OnInitialize()
        {
            await base.OnInitialize();

            ListTest.ItemDatas = new ObservableList<ListDataItem>();
            for (int i = 0; i < 10; i++)
            {
                ListTest.ItemDatas.Add(new ListDataItem()
                {
                    Value1 = i.ToString(),
                    Value2 = (i % 3).ToString()
                });
            }
        }

        [DataBinding]
        protected void OnBtnAdd_Clicked(EventArg rEventArg)
        {
            var rListItem = new ListDataItem() {Value1 = "hhh", Value2 = "0"};
            Debug.LogError("==================== " + ListTest.ItemDatas.GetType());
            ListTest.ItemDatas.Insert(0, rListItem);
            ListTest.ItemDatas.Refresh();
        }

        [DataBinding]
        protected void OnBtnDelete_Clicked(EventArg rEventArg)
        {
            ListTest.ItemDatas.RemoveAt(0);
            ListTest.ItemDatas.Refresh();
        }

        [DataBinding]
        protected void OnListItem_Clicked(int nIndex, EventArg rEventArg)
        {
            Debug.LogError($"Item {nIndex} clicked.. {ListTest.ItemDatas[nIndex].Value1}");
        }
    }
}
