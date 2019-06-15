using System.Collections.Generic;

namespace UnityEngine.UI
{
    [ExecuteInEditMode]
    public class TextStyleManager : MonoBehaviour
    {
        public static TextStyleManager Instance { get; private set; }

        public List<TextStyle> TextStyles;

        private void Awake()
        {
            if (Instance != null)
            {
                Instance = this;
            }
        }
    }
}
