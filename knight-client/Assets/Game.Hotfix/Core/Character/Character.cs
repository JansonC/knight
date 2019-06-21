using System;
using System.Threading.Tasks;
using Knight.Core;
using Knight.Framework.Character;
using UnityEngine;

namespace Knight.Hotfix.Core
{
    public class Character
    {
        public string GUID = "";
        public string CharacterName = "";
        public GameObject GameObject;
        public CharacterControllerContainer CharacterControllerContainer;
        public CharacterController CharacterController;

        public bool IsActived
        {
            get { return GameObject.activeSelf; }
            set { GameObject.SetActive(value); }
        }

        public static T CreateCharacter<T>(GameObject characterGo) where T : Character
        {
            if (characterGo == null)
            {
                return null;
            }

            Character character = new Character
            {
                GameObject = characterGo
            };
            return (T) character;
        }

        public async Task Initialize(string characterName, string characterGUID)
        {
            CharacterName = characterName;
            GUID = characterGUID;
            await InitializeCharacterModel();
        }

        /// <summary>
        /// 初始化ViewController
        /// </summary>
        private async Task InitializeCharacterModel()
        {
            CharacterControllerContainer = GameObject.GetComponent<CharacterControllerContainer>();
            if (CharacterControllerContainer == null)
            {
                Log.CI(Log.COLOR_RED, "'{0}' 预制体没有CharacterControllerContainer脚本组件", CharacterName);
                return;
            }

            var rType = Type.GetType(CharacterControllerContainer.CharacterControllerClass);
            if (rType == null)
            {
                Log.CI(Log.COLOR_RED, "找不到对应的CharacterControllerClass, className: {0}",
                    CharacterControllerContainer.CharacterControllerClass);
                return;
            }

            // 构建CharacterController
            CharacterController = HotfixReflectAssists.Construct(rType) as CharacterController;
            CharacterController.Character = this;
            Log.I("初始化{0}", rType.Name);
            await CharacterController.Initialize();
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
    }
}
