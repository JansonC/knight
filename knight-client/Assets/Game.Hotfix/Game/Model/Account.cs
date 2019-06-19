using Knight.Hotfix.Core;
using UnityEngine.UI;

namespace Game
{
    [DataBinding]
    [ViewModelInitialize]
    public class Account : ViewModel
    {
        public static Account Instance
        {
            get { return ViewModelManager.Instance.ReceiveViewModel<Account>(); }
        }

        [DataBinding] public string PlayerName { get; set; }
        [DataBinding] public string HeadIcon { get; set; }
        [DataBinding] public long GlodCount { get; set; }
        [DataBinding] public long JewelCount { get; set; }
    }
}
