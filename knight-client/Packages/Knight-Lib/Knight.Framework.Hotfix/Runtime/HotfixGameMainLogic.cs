//======================================================================
//        Copyright (C) 2015-2020 Winddy He. All rights reserved
//        Email: hgplan@126.com
//======================================================================
using System.Threading.Tasks;
using UnityEngine;

namespace Knight.Framework.Hotfix
{
    public class HotfixGameMainLogic : MonoBehaviour
    {
        public static HotfixGameMainLogic Instance { get; private set; }

        public string MainLogicScript;

        public HotfixObject MainLogicHotfixObj;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        public async Task Initialize()
        {
            // 加载Hotfix端的代码
            MainLogicHotfixObj = HotfixManager.Instance.Instantiate(MainLogicScript);

            // 加载Hotfix端的代码
            await (HotfixManager.Instance.Invoke(MainLogicHotfixObj, "Initialize") as Task);
        }

        void Update()
        {
            if (MainLogicHotfixObj == null)
            {
                return;
            }

            HotfixManager.Instance.Invoke(MainLogicHotfixObj, "Update");
        }
    }
}
