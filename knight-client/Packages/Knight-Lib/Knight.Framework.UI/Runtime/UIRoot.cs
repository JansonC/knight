//======================================================================
//        Copyright (C) 2015-2020 Winddy He. All rights reserved
//        Email: hgplan@126.com
//======================================================================

using Knight.Core;
using UnityEngine.EventSystems;

namespace UnityEngine.UI
{
    public class UIRoot : MonoBehaviour
    {
        public static UIRoot Instance { get; private set; }

        public GameObject DynamicRoot;
        public GameObject GlobalsRoot;
        public GameObject PopupRoot;
        public Camera UICamera;
        public EventSystem UIEventSystem;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        public void Initialize()
        {
            UICamera.orthographicSize = WorldUtils.MaxScreenHeight / WorldUtils.GamePixelUnit / 2;
            DynamicRoot.SetActive(true);
            GlobalsRoot.SetActive(true);
            PopupRoot.SetActive(true);
        }

        public void SetEventSystemEnable(bool value)
        {
            UIEventSystem.enabled = value;
        }
    }
}
