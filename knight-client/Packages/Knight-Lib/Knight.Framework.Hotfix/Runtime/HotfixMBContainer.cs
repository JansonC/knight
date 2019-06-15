//======================================================================
//        Copyright (C) 2015-2020 Winddy He. All rights reserved
//        Email: hgplan@126.com
//======================================================================
using System.Collections.Generic;
using UnityEngine;

namespace Knight.Framework.Hotfix
{
    [DefaultExecutionOrder(80)]
    public class HotfixMBContainer : MonoBehaviour
    {
        [HideInInspector] [SerializeField] protected string mHotfixName;
        [HideInInspector] [SerializeField] protected List<UnityObject> mObjects;
        [HideInInspector] [SerializeField] protected bool mNeedUpdate;

        public HotfixObject MBHotfixObject { get; private set; }

        public string HotfixName
        {
            get { return mHotfixName; }
            set { mHotfixName = value; }
        }

        public bool NeedUpdate
        {
            get { return mNeedUpdate; }
            set { mNeedUpdate = value; }
        }

        public List<UnityObject> Objects
        {
            get { return mObjects; }
        }

        private string mParentType = "Knight.Hotfix.Core.THotfixMB`1<{0}>";

        protected virtual void Awake()
        {
            InitHotfixMB();
        }

        protected virtual void Start()
        {
            if (MBHotfixObject == null)
            {
                return;
            }

            MBHotfixObject.InvokeParent(mParentType, "Start_Proxy");
        }

        protected virtual void Update()
        {
            if (!mNeedUpdate)
            {
                return;
            }

            if (MBHotfixObject == null)
            {
                return;
            }

            MBHotfixObject.InvokeParent(mParentType, "Update_Proxy");
        }

        protected virtual void OnDestroy()
        {
            if (MBHotfixObject != null)
            {
                MBHotfixObject.InvokeParent(mParentType, "OnDestroy_Proxy");
            }

            if (mObjects != null)
            {
                mObjects.Clear();
            }

            MBHotfixObject = null;
            mObjects = null;
        }

        protected virtual void OnEnable()
        {
            if (MBHotfixObject == null)
            {
                return;
            }

            MBHotfixObject.InvokeParent(mParentType, "OnEnable_Proxy");
        }

        protected virtual void OnDisable()
        {
            if (MBHotfixObject == null)
            {
                return;
            }

            MBHotfixObject.InvokeParent(mParentType, "OnDisable_Proxy");
        }

        protected void InitHotfixMB()
        {
            if (MBHotfixObject == null && !string.IsNullOrEmpty(mHotfixName))
            {
                mParentType = string.Format(mParentType, mHotfixName);
                MBHotfixObject = HotfixManager.Instance.Instantiate(mHotfixName);
                MBHotfixObject.InvokeParent(mParentType, "Awake_Proxy", gameObject, mObjects);
            }
        }

        public void Initialize(string rHotfixName, bool bNeedUpdate = false)
        {
            mHotfixName = rHotfixName;
            mNeedUpdate = bNeedUpdate;
            Awake();
        }

        public T Get<T>(string rName) where T : class
        {
            if (Objects == null)
            {
                return null;
            }

            var rUObj = Objects.Find((rItem) => { return rItem.Name.Equals(rName); });
            if (rUObj == null)
            {
                return null;
            }

            return rUObj.Object as T;
        }
    }
}
