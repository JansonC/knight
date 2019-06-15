using System.Collections.Generic;
using System.Linq;
using Knight.Core;

namespace Knight.Framework.Stage
{
    public class DataBindingTypeResolve
    {
        public static List<string> GetAllStages()
        {
            var rTypeNames = TypeResolveManager.Instance.GetAllTypes(true)
                .Where(rType => rType != null && rType.BaseType?.FullName == "Knight.Hotfix.Core.StageController")
                .Select(rType => { return rType.FullName; });
            return new List<string>(rTypeNames);
        }
    }
}
