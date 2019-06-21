using System.Collections.Generic;
using System.Linq;
using Knight.Core;

namespace Knight.Framework.Character
{
    public class DataBindingTypeResolve
    {
        public static List<string> GetAllKnights()
        {
            var rTypeNames = TypeResolveManager.Instance.GetAllTypes(true)
                .Where(rType => rType != null && rType.BaseType?.FullName == "Knight.Hotfix.Core.KnightController")
                .Select(rType => { return rType.FullName; });
            return new List<string>(rTypeNames);
        }

        public static List<string> GetAllMonsters()
        {
            var rTypeNames = TypeResolveManager.Instance.GetAllTypes(true)
                .Where(rType => rType != null && rType.BaseType?.FullName == "Knight.Hotfix.Core.MonsterController")
                .Select(rType => { return rType.FullName; });
            return new List<string>(rTypeNames);
        }
    }
}
