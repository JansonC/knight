using UnityEngine;

namespace Knight.Core
{
    public class WorldUtils
    {
        public static float MinScreenWidth = 640f;
        public static float MaxScreenWidth = 1136f;
        public static float MaxScreenHeight = 1136f;
        public static float GamePixelUnit = 100f;

        public static float GetScreenWidth()
        {
            return Screen.width * 1f;
        }

        public static float GetScreenHeight()
        {
            return Screen.height * 1f;
        }

        public static float GetScreenMaxRadio()
        {
            return WorldUtils.MaxScreenWidth / WorldUtils.MaxScreenHeight;
        }

        public static float GetScreenMinRadio()
        {
            return WorldUtils.MinScreenWidth / WorldUtils.MaxScreenHeight;
        }
    }
}
