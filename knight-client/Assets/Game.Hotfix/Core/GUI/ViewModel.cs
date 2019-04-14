using System;
using Knight.Core;

namespace Knight.Hotfix.Core
{
    public class ViewModel
    {
        public Action<string> PropChangedHandler;

        public void PropChanged(string rPropName)
        {
            UtilTool.SafeExecute(PropChangedHandler, rPropName);
        }
    }
}
