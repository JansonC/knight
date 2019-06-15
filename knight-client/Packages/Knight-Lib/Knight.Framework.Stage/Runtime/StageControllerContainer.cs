using NaughtyAttributes;
using UnityEngine;

namespace Knight.Framework.Stage
{
    public class StageControllerContainer : MonoBehaviour
    {
        [Dropdown("StageControllerClasses")] public string StageControllerClass;

        [HideInInspector] public string[] StageControllerClasses = new string[0];

        public void GetAllViewModelDataSources()
        {
            StageControllerClasses = DataBindingTypeResolve.GetAllStages().ToArray();
        }
    }
}
