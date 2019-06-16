using Knight.Core;
using UnityEngine;

namespace Knight.Framework.Stage
{
    public class StageRoot : MonoBehaviour
    {
        public static StageRoot Instance { get; private set; }

        public Camera StageCamera;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        public void Initialize()
        {
            StageCamera.orthographicSize = WorldUtils.MaxScreenHeight / WorldUtils.GamePixelUnit / 2;
        }
    }
}
