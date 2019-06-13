//======================================================================
//        Copyright (C) 2015-2020 Winddy He. All rights reserved
//        Email: hgplan@126.com
//======================================================================
using UnityEngine;

namespace Knight.Framework.Input
{
    /// <summary>
    /// 输入管理器 
    ///    键盘输入和虚拟手柄输入同时存在
    /// </summary>
    public class InputManager : MonoBehaviour
    {
        public static InputManager Instance { get; private set; }

        /// <summary>
        /// 键盘输入
        /// </summary>
        private KeyboardInput mKeyboardInput = null;

        /// <summary>
        /// 虚拟手柄输入
        /// </summary>
        private JoystickInput mJoystickInput = null;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;

                mKeyboardInput = BaseInput.Create<KeyboardInput>();
                mJoystickInput = BaseInput.Create<JoystickInput>();
            }
        }

        public float Horizontal
        {
            get
            {
                float fHorizontal = mKeyboardInput.Horizontal + mJoystickInput.Horizontal;
                return Mathf.Clamp(fHorizontal, -1.0f, 1.0f);
            }
        }

        public float Vertical
        {
            get
            {
                float fVertical = mKeyboardInput.Vertical + mJoystickInput.Vertical;
                return Mathf.Clamp(fVertical, -1.0f, 1.0f);
            }
        }

        public bool IsKeyDown(InputKey rInputKey)
        {
            return mKeyboardInput.IsKeyDown(rInputKey);
        }

        public bool IsKeyUp(InputKey rInputKey)
        {
            return mKeyboardInput.IsKeyUp(rInputKey);
        }

        public bool IsKey(InputKey rInputKey)
        {
            return mKeyboardInput.IsKey(rInputKey);
        }
    }
}
