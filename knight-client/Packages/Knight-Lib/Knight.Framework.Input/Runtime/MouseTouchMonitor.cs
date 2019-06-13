//======================================================================
//        Copyright (C) 2015-2020 Winddy He. All rights reserved
//        Email: hgplan@126.com
//======================================================================
using UnityEngine;

namespace Knight.Framework.Input
{
    public class MouseTouchMonitor : MonoBehaviour
    {
        public TouchObject TouchObj;

        private float mCurTime;
        private float mLastTime;

        private Vector2 mCurPos;
        private Vector2 mLastPos;

        public bool IsTouched { get; private set; } = false;

        void Update()
        {
            if (UnityEngine.Input.GetMouseButton(0))
            {
                if (TouchObj.deltaPosition == Vector2.zero)
                {
                    TouchObj.phase = TouchPhase.Stationary;
                }
                else
                {
                    TouchObj.phase = TouchPhase.Moved;
                }

                TouchObj.deltaTime = mCurTime - mLastTime;
                TouchObj.deltaPosition = mCurPos - mLastPos;

                mLastTime = mCurTime;
                mCurTime += Time.deltaTime;

                mLastPos = mCurPos;
                mCurPos = UnityEngine.Input.mousePosition;
                TouchObj.position = mCurPos;

                IsTouched = true;
            }

            if (UnityEngine.Input.GetMouseButtonDown(0))
            {
                mCurTime = mLastTime = 0;
                mCurPos = mLastPos = UnityEngine.Input.mousePosition;

                TouchObj.fingerId = -1000;
                TouchObj.position = UnityEngine.Input.mousePosition;
                TouchObj.phase = TouchPhase.Began;
                IsTouched = true;
            }

            if (UnityEngine.Input.GetMouseButtonUp(0))
            {
                TouchObj.fingerId = -1000;
                TouchObj.position = UnityEngine.Input.mousePosition;
                TouchObj.phase = TouchPhase.Ended;
                IsTouched = false;
            }
        }
    }
}
