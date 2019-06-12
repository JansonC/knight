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
            public ViewModel DefaultViewModel;
        }

        public static FrameManager Instance { get; private set; }

        [HotfixBinding("FramePanel")] public RectTransform FramePanel;
        [HotfixBinding("PagePanel")] public RectTransform PagePanel;

        /// <summary>
        /// 回退的缓存
        /// </summary>
        private List<BackCache> mBackCaches;

        public override void Awake()
        {
            Instance = this;

            // 初始化这个Page节点
            ViewManager.Instance.FrameRoot = this.FramePanel.gameObject;
            ViewManager.Instance.PageRoot = this.PagePanel.gameObject;

            this.mBackCaches = new List<BackCache>();
        }

        public void CloseAllPages()
        {
            ViewManager.Instance.CloseAllPageViews();
            this.mBackCaches.Clear();
        }

        public BackCache GetLastBackCache()
        {
            if (this.mBackCaches == null || this.mBackCaches.Count == 0) return null;
            var rBackcache = this.mBackCaches[this.mBackCaches.Count - 1];
            if (rBackcache == null) return null;
            this.mBackCaches.Remove(rBackcache);
            return rBackcache;
        }

        public void BackView(Action<View> rOpenCompleted = null)
        {
            var rBackCache = this.GetLastBackCache();
            if (rBackCache == null)
            {
                UtilTool.SafeExecute(rOpenCompleted, null);
                return;
            }

            ViewManager.Instance.CloseView(rBackCache.ViewGUID);

            rBackCache = this.GetLastBackCache();
            if (rBackCache == null)
            {
                UtilTool.SafeExecute(rOpenCompleted, null);
                return;
            }

            if (rBackCache.State == View.State.Popup)
                this.OpenPopupUI(rBackCache.ViewName, rBackCache.DefaultViewModel, rOpenCompleted);
            else
                this.OpenPageUI(rBackCache.ViewName, rBackCache.State, rBackCache.DefaultViewModel, rOpenCompleted);
        }

        public void CloseView(string rViewGUID)
        {
            var rBackCache = this.mBackCaches.Find((rItem) => { return rItem.ViewGUID.Equals(rViewGUID); });
            if (rBackCache != null)
            {
                this.mBackCaches.Remove(rBackCache);
            }

            ViewManager.Instance.CloseView(rViewGUID);
        }

        public async Task<View> OpenPageUIAsync(string rViewName, View.State rState, ViewModel rDefaultViewModel = null,
            Action<View> rOpenCompleted = null)
        {
            var rView = await ViewManager.Instance.OpenAsync(rViewName, rState, rDefaultViewModel, rOpenCompleted);
            if (rView != null && rView.IsBackCache)
            {
                this.mBackCaches.Add(new BackCache()
                {
                    ViewName = rView.ViewName,
                    ViewGUID = rView.GUID,
                    State = rView.CurState,
                    DefaultViewModel = rView.DefaultViewModel
                });
            }

            return rView;
        }

        public void OpenPageUI(string rViewName, View.State rState, ViewModel rDefaultViewModel = null,
            Action<View> rOpenCompleted = null)
        {
            ViewManager.Instance.Open(rViewName, rState, rDefaultViewModel, (rView) =>
            {
                if (rView != null && rView.IsBackCache)
                {
                    this.mBackCaches.Add(new BackCache()
                    {
                        ViewName = rView.ViewName,
                        ViewGUID = rView.GUID,
                        State = rView.CurState,
                        DefaultViewModel = rView.DefaultViewModel
                    });
                }

                UtilTool.SafeExecute(rOpenCompleted, rView);
            });
        }

        public async Task<View> OpenPopUIAsync(string rViewName, ViewModel rDefaultViewModel = null,
            Action<View> rOpenCompleted = null)
        {
            var rView = await ViewManager.Instance.OpenAsync(rViewName, View.State.Popup, rDefaultViewModel,
                rOpenCompleted);
            if (rView != null && rView.IsBackCache)
            {
                this.mBackCaches.Add(new BackCache()
                {
                    ViewName = rView.ViewName,
                    ViewGUID = rView.GUID,
                    State = rView.CurState,
                    DefaultViewModel = rView.DefaultViewModel
                });
            }

            return rView;
        }

        public void OpenPopupUI(string rViewName, ViewModel rDefaultViewModel = null,
            Action<View> rOpenCompleted = null)
        {
            ViewManager.Instance.Open(rViewName, View.State.Popup, rDefaultViewModel, (rView) =>
            {
                if (rView != null && rView.IsBackCache)
                {
                    this.mBackCaches.Add(new BackCache()
                    {
                        ViewName = rView.ViewName,
                        ViewGUID = rView.GUID,
                        State = rView.CurState,
                        DefaultViewModel = rView.DefaultViewModel
                    });
                }

                UtilTool.SafeExecute(rOpenCompleted, rView);
            });
        }

        public void SetActive(string rViewGUID, bool bIsActive)
        {
            if (bIsActive)
            {
                ViewManager.Instance.Show(rViewGUID);
            }
            else
            {
                ViewManager.Instance.Hide(rViewGUID);
            }
        }
    }
}
