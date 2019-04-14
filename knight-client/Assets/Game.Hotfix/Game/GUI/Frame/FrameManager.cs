﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Knight.Core;
using Knight.Hotfix.Core;
using UnityEngine;

namespace Game
{
    public class FrameManager : THotfixMB<FrameManager>
    {
        public class BackCache
        {
            public string ViewName;
            public string ViewGUID;
            public View.State State;
        }

        public static FrameManager Instance { get; private set; }

        [HotfixBinding("FramePanel")] public RectTransform FramePanel;
        [HotfixBinding("PagePanel")] public RectTransform PagePanel;

        /// <summary>
        /// 回退的缓存
        /// </summary>
        private Stack<BackCache> mBackCaches;

        public override void Awake()
        {
            Instance = this;

            // 初始化这个Page节点
            ViewManager.Instance.FrameRoot = FramePanel.gameObject;
            ViewManager.Instance.PageRoot = PagePanel.gameObject;

            mBackCaches = new Stack<BackCache>();
        }

        public void CloseAllPages()
        {
            ViewManager.Instance.CloseAllPageViews();
            mBackCaches.Clear();
        }

        public BackCache GetLastBackCache()
        {
            if (mBackCaches == null || mBackCaches.Count == 0) return null;
            var rBackcache = mBackCaches.Peek();
            if (rBackcache == null) return null;
            return mBackCaches.Pop();
        }

        public void BackView(Action<View> rOpenCompleted = null)
        {
            var rBackCache = GetLastBackCache();
            if (rBackCache == null)
            {
                UtilTool.SafeExecute(rOpenCompleted, null);
                return;
            }

            ViewManager.Instance.CloseView(rBackCache.ViewGUID);

            rBackCache = GetLastBackCache();
            if (rBackCache == null)
            {
                UtilTool.SafeExecute(rOpenCompleted, null);
                return;
            }

            if (rBackCache.State == View.State.Popup)
                OpenPopupUI(rBackCache.ViewName, rOpenCompleted);
            else
                OpenPageUI(rBackCache.ViewName, rBackCache.State, rOpenCompleted);
        }

        public async Task<View> OpenPageUIAsync(string rViewName, View.State rState, Action<View> rOpenCompleted = null)
        {
            var rView = await ViewManager.Instance.OpenAsync(rViewName, rState, rOpenCompleted);
            if (rView != null && rView.IsBackCache)
            {
                mBackCaches.Push(new BackCache()
                {
                    ViewName = rView.ViewName,
                    ViewGUID = rView.GUID,
                    State = rView.CurState,
                });
            }

            return rView;
        }

        public void OpenPageUI(string rViewName, View.State rState, Action<View> rOpenCompleted = null)
        {
            ViewManager.Instance.Open(rViewName, rState, (rView) =>
            {
                if (rView != null && rView.IsBackCache)
                {
                    mBackCaches.Push(new BackCache()
                    {
                        ViewName = rView.ViewName,
                        ViewGUID = rView.GUID,
                        State = rView.CurState,
                    });
                }

                UtilTool.SafeExecute(rOpenCompleted, rView);
            });
        }

        public async Task<View> OpenPopUIAsync(string rViewName, Action<View> rOpenCompleted = null)
        {
            var rView = await ViewManager.Instance.OpenAsync(rViewName, View.State.Popup, rOpenCompleted);
            if (rView != null && rView.IsBackCache)
            {
                mBackCaches.Push(new BackCache()
                {
                    ViewName = rView.ViewName,
                    ViewGUID = rView.GUID,
                    State = rView.CurState,
                });
            }

            return rView;
        }

        public void OpenPopupUI(string rViewName, Action<View> rOpenCompleted = null)
        {
            ViewManager.Instance.Open(rViewName, View.State.Popup, (rView) =>
            {
                if (rView != null && rView.IsBackCache)
                {
                    mBackCaches.Push(new BackCache()
                    {
                        ViewName = rView.ViewName,
                        ViewGUID = rView.GUID,
                        State = rView.CurState,
                    });
                }

                UtilTool.SafeExecute(rOpenCompleted, rView);
            });
        }

        public void SetActive(string rViewGUID, bool bIsActive)
        {
            if (bIsActive)
                ViewManager.Instance.Show(rViewGUID);
            else
                ViewManager.Instance.Hide(rViewGUID);
        }
    }
}
