using UnityEngine;

namespace Knight.Framework.Stage
{
    public class StageRoot : MonoBehaviour
    {
        public static StageRoot Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        public void Initialize()
        {

        }
    }
}
