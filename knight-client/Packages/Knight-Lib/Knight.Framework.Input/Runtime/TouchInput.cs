//======================================================================
//        Copyright (C) 2015-2020 Winddy He. All rights reserved
//        Email: hgplan@126.com
//======================================================================
//#define INPUT_EDITOR_REMOTE_DEBUG
using UnityEngine;

namespace Knight.Framework.Input
{
    [System.Serializable]
    public class TouchObject
    {
        ///<summary>
        /// The position delta since last change.
        ///</summary>
        public Vector2 deltaPosition;

        /// <summary>
        /// Amount of time that has passed since the last recorded change in Touch values.
        /// </summary>
        public float deltaTime;

        /// <summary>
        /// fingerId
        /// </summary>
        public int fingerId;

        /// <summary>
        /// Describes the phase of the touch.
        /// </summary>
        public TouchPhase phase;

        /// <summary>
        /// The position of the touch in pixel coordinates.
        /// </summary>
        public Vector2 position;

        /// <summary>
        /// Number of taps.
        /// </summary>
        public int tapCount;

        public TouchObject(Touch rTouch)
        {
            SetTouch(rTouch);
        }

        public void SetTouch(Touch rTouch)
        {
            deltaPosition = rTouch.deltaPosition;
            deltaTime = rTouch.deltaTime;
            fingerId = rTouch.fingerId;
            phase = rTouch.phase;
            position = rTouch.position;
            tapCount = rTouch.tapCount;
        }
    }

    /// <summary>
    /// @TODO: 需要做一个TouchObject的对象池
    /// </summary>
    public class TouchInput : MonoBehaviour
    {
        public static TouchInput Instance { get; private set; }

        public int touchCount = 0;
        public MouseTouchMonitor mouseTouchMonitor;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        public int TouchCount
        {
            get
            {
#if UNITY_EDITOR && !INPUT_EDITOR_REMOTE_DEBUG
                return touchCount;
#else
                this.touchCount = UnityEngine.Input.touchCount;
                return UnityEngine.Input.touchCount;
#endif
            }
        }

        public TouchObject GetTouch(int nTouchIndex)
        {
#if UNITY_EDITOR && !INPUT_EDITOR_REMOTE_DEBUG
            if (nTouchIndex == 0)
            {
                return mouseTouchMonitor.TouchObj;
            }
            else
            {
                if (UnityEngine.Input.touchCount <= nTouchIndex)
                {
                    return null;
                }

                return new TouchObject(UnityEngine.Input.GetTouch(nTouchIndex));
            }

#else
            if (UnityEngine.Input.touchCount <= nTouchIndex) return null;
            return new TouchObject(UnityEngine.Input.GetTouch(nTouchIndex));
#endif
        }

        void Update()
        {
#if UNITY_EDITOR && !INPUT_EDITOR_REMOTE_DEBUG
            if (UnityEngine.Input.GetMouseButton(0))
            {
                touchCount = 1;
            }
            else
            {
                touchCount = 0;
            }
#endif
        }
    }
}
