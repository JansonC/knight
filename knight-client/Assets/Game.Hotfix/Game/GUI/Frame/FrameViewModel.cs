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
        [DataBinding] public List<MainFrameTabItem> MainFrameTab { get; set; }
    }
}
