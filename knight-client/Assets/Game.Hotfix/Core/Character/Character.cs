using System.Threading.Tasks;
using Knight.Core;
using Knight.Framework.Character;
using UnityEngine;

namespace Knight.Hotfix.Core
{
    public enum KnightStatus
    {
        Normal = 0,
        Idle = 1,
        Walking = 2,
        Attacking = 3,
        Taunt = 4,
        Hurt = 5,
        Dying = 6
    }

    public class Character
    {
        public string GUID = "";
        public int CharacterId = 0;
        public GameObject GameObject;
        public CharacterControllerContainer CharacterControllerContainer;
        public CharacterController CharacterController;

        public bool IsActived
        {
            get { return GameObject.activeSelf; }
            set { GameObject.SetActive(value); }
        }

        public async Task Initialize(int characterId, string characterGUID)
        {
            CharacterId = characterId;
            GUID = characterGUID;
            await InitializeCharacterModel();
            BindAnimaEvent();
        }

        /// <summary>
        /// 初始化ViewController
        /// </summary>
        protected virtual async Task InitializeCharacterModel()
        {
        }

        protected void BindAnimaEvent()
        {
            Log.I("绑定动画事件回调");
            CharacterControllerContainer.BindAnimaCbAction(CharacterController.AnimaEventCb);
        }

        /// <summary>
        /// 打开，此时对应的GameObject已经加载出来了, 用于做初始化。
        /// </summary>
        public async Task Open()
        {
            await CharacterController?.Open();
        }

        /// <summary>
        /// 显示
        /// </summary>
        public void Show()
        {
            GameObject.SetActive(true);
            CharacterController?.Show();
        }

        /// <summary>
        /// 隐藏
        /// </summary>
        public void Hide()
        {
            GameObject.SetActive(false);
            CharacterController?.Hide();
        }

        public void Update()
        {
            CharacterController?.Update();
        }

        public void Dispose()
        {
            CharacterController?.Dispose();
        }

        /// <summary>
        /// 关闭
        /// </summary>
        public void Close()
        {
            CharacterController?.Closing();
        }

        public void SwitchStatus(int status)
        {
            CharacterControllerContainer?.SwitchAnima(status);
        }
    }
}
