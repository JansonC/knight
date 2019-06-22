using System;
using Knight.Core;
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

        private Action<string> animaCbAction;

        public void BindAnimaCbAction(Action<string> action)
        {
            animaCbAction = action;
        }

        public void AnimaCb(string eventName)
        {
            Log.I("Unity Anima Cb, " + eventName);
            animaCbAction(eventName);
        }
    }
}
