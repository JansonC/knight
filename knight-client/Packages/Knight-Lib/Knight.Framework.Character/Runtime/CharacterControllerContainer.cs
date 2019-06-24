using System;
using NaughtyAttributes;
using UnityEngine;

namespace Knight.Framework.Character
{
    [RequireComponent(typeof(Animator))]
    public class CharacterControllerContainer : MonoBehaviour
    {
        [Dropdown("CharacterControllerClasses")]
        public string CharacterControllerClass;

        [HideInInspector] public string[] CharacterControllerClasses = new string[0];

        public virtual void GetAllViewModelDataSources()
        {
        }

        private Action<string> animaCbAction;
        private Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public void BindAnimaCbAction(Action<string> action)
        {
            animaCbAction = action;
        }

        public void AnimaCb(string eventName)
        {
            animaCbAction?.Invoke(eventName);
        }

        public void SwitchAnima(int status)
        {
            if (animator != null)
            {
                animator.SetInteger("status", status);
            }
        }
    }
}
