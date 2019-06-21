using NaughtyAttributes;
using UnityEngine;

namespace Knight.Framework.Character
{
    public class CharacterControllerContainer : MonoBehaviour
    {
        [Dropdown("CharacterControllerClasses")]
        public string CharacterControllerClass;

        [HideInInspector] public string[] CharacterControllerClasses = new string[0];

        public virtual void GetAllViewModelDataSources()
        {
        }
    }
}
