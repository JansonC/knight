using UnityEngine;

namespace Knight.Framework.Character
{
    public static class CharacterTool
    {
        public static GameObject AddChild(this Transform rParent, GameObject rPrefabGo, string rLayerName = "Character")
        {
            if (rParent == null || rPrefabGo == null)
            {
                return null;
            }

            GameObject rTargetGo = Object.Instantiate(rPrefabGo);
            rTargetGo.name = rPrefabGo.name;
            rTargetGo.transform.SetParent(rParent, false);
            rTargetGo.transform.localScale = Vector3.one;
            rTargetGo.SetLayer(rLayerName);
            return rTargetGo;
        }

        /// <summary>
        /// 递归设置一个节点的层
        /// </summary>
        public static void SetLayer(this GameObject rGo, string rLayerName)
        {
            if (rGo == null)
            {
                return;
            }

            SetLayer(rGo.transform, rLayerName);
        }

        /// <summary>
        /// 设置一个GameObject的层
        /// </summary>
        public static void SetLayer(Transform rParent, string rLayerName)
        {
            if (rParent == null)
            {
                return;
            }

            rParent.gameObject.layer = LayerMask.NameToLayer(rLayerName);

            for (int i = 0; i < rParent.transform.childCount; i++)
            {
                var rTrans = rParent.transform.GetChild(i);
                SetLayer(rTrans, rLayerName);
            }
        }
    }
}
