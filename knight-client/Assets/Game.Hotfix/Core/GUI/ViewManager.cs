﻿//======================================================================
//        Copyright (C) 2015-2020 Winddy He. All rights reserved
//        Email: hgplan@126.com
//======================================================================
using Knight.Core;
using System;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.UI;

namespace Knight.Hotfix.Core
{
    public class ViewManager : THotfixSingleton<ViewManager>
    {
        /// <summary>
        /// 存放各种动态节点的地方
        /// </summary>
        public GameObject DynamicRoot;

        /// <summary>
        /// 存放各种弹出框节点的地方
        /// </summary>
        public GameObject PopupRoot;

        /// <summary>
        /// 存放各种Page页面的地方
        /// </summary>
        public GameObject FrameRoot;

        public GameObject PageRoot;

        /// <summary>
        /// 当前的UI中的Views，每个View是用GUID来作唯一标识
        /// 底层-->顶层 { 0 --> list.count }
        /// </summary>
        private IndexedDict<string, View> mCurFrameViews;

        private IndexedDict<string, View> mCurPageViews;

        /// <summary>
        /// 当前存在的固定View，每个View使用GUID来作唯一标识
        /// </summary>
        private IndexedDict<string, View> mCurFixedViews;

        private ViewManager()
        {
        }

        public void Initialize()
        {
            DynamicRoot = UIRoot.Instance.DynamicRoot;
            PopupRoot = UIRoot.Instance.PopupRoot;

            mCurFrameViews = new IndexedDict<string, View>();
            mCurPageViews = new IndexedDict<string, View>();
            mCurFixedViews = new IndexedDict<string, View>();
        }

        public void Update()
        {
            if (mCurPageViews != null)
            {
                var rCurViewKeys = mCurPageViews.Keys;
                for (int i = 0; i < rCurViewKeys.Count; i++)
                {
                    mCurPageViews[rCurViewKeys[i]].Update();
                }
            }

            if (mCurFixedViews != null)
            {
                var rCurViewKeys = mCurFixedViews.Keys;
                for (int i = 0; i < rCurViewKeys.Count; i++)
                {
                    mCurFixedViews[rCurViewKeys[i]].Update();
                }
            }
        }

        public void Show(string rViewGUID)
        {
            View rView = null;
            if (mCurFixedViews.TryGetValue(rViewGUID, out rView))
            {
                rView.Show();
            }

            if (mCurFrameViews.TryGetValue(rViewGUID, out rView))
            {
                rView.Show();
            }

            if (mCurPageViews.TryGetValue(rViewGUID, out rView))
            {
                rView.Show();
            }
        }

        public void Hide(string rViewGUID)
        {
            View rView = null;
            if (mCurFixedViews.TryGetValue(rViewGUID, out rView))
            {
                rView.Hide();
            }

            if (mCurFrameViews.TryGetValue(rViewGUID, out rView))
            {
                rView.Hide();
            }

            if (mCurPageViews.TryGetValue(rViewGUID, out rView))
            {
                rView.Hide();
            }
        }

        /// <summary>
        /// 打开一个View
        /// </summary>
        public async Task<View> OpenAsync(string rViewName, View.State rViewState, ViewModel rViewModel = null,
            Action<View> rOpenCompleted = null)
        {
            // 企图关闭当前的View
            Debug.Log("Open " + rViewName);
            MaybeCloseTopView(rViewState);
            return await OpenViewAsync(rViewName, rViewState, rViewModel, rOpenCompleted);
        }

        public void Open(string rViewName, View.State rViewState, ViewModel rViewModel,
            Action<View> rOpenCompleted = null)
        {
            OpenAsync(rViewName, rViewState, rViewModel, rOpenCompleted).WarpErrors();
        }

        private async Task<View> OpenViewAsync(string rViewName, View.State rViewState, ViewModel rViewModel,
            Action<View> rOpenCompleted)
        {
            var rLoaderRequest = UIAssetLoader.Instance.LoadUI(rViewName);
            return await OpenView(rViewName, rLoaderRequest.ViewPrefabGo, rViewState, rViewModel, rOpenCompleted);
        }

        /// <summary>
        /// 移除顶层View
        /// </summary>
        public void Pop(Action rCloseComplted = null)
        {
            // 得到顶层结点
            CKeyValuePair<string, View> rTopNode = this.mCurPageViews.Last();
            if (rTopNode == null)
            {
                UtilTool.SafeExecute(rCloseComplted);
                return;
            }

            string rViewGUID = rTopNode.Key;
            View rView = rTopNode.Value;

            if (rView == null)
            {
                UtilTool.SafeExecute(rCloseComplted);
                return;
            }

            // 移除顶层结点
            mCurPageViews.Remove(rViewGUID);
            rView.Close();
            DestroyView(rView);
            UtilTool.SafeExecute(rCloseComplted);
        }

        public void CloseAllPageViews()
        {
            var rViewKeys = mCurPageViews.Keys;
            for (int i = 0; i < rViewKeys.Count; i++)
            {
                CloseView(rViewKeys[i]);
            }
        }

        /// <summary>
        /// 根据GUID来关闭指定的View
        /// </summary>
        public void CloseView(string rViewGUID, Action rCloseCompleted = null)
        {
            bool isFixedView = false;
            View rView = null;

            // 找到View
            if (mCurFixedViews.TryGetValue(rViewGUID, out rView))
            {
                isFixedView = true;
            }
            else if (mCurPageViews.TryGetValue(rViewGUID, out rView))
            {
                isFixedView = false;
            }

            // View不存在
            if (rView == null)
            {
                UtilTool.SafeExecute(rCloseCompleted);
                return;
            }

            // View存在
            if (isFixedView)
            {
                mCurFixedViews.Remove(rViewGUID);
            }
            else
            {
                if (rView.CurState == View.State.Frame)
                {
                    mCurFrameViews.Remove(rViewGUID);
                }
                else if (rView.CurState == View.State.PageSwitch || rView.CurState == View.State.PageSwitch)
                {
                    mCurPageViews.Remove(rViewGUID);
                }
            }

            // 移除顶层结点
            rView.Close();

            DestroyView(rView);
            UtilTool.SafeExecute(rCloseCompleted);
        }

        /// <summary>
        /// 初始化View，如果是Dispatch类型的话，只对curViews顶层View进行交换
        /// </summary>
        public async Task<View> OpenView(string rViewName, GameObject rViewPrefab, View.State rViewState,
            ViewModel rViewModel, Action<View> rOpenCompleted)
        {
            if (rViewPrefab == null) return null;

            //把View的GameObject结点加到rootCanvas下
            GameObject rViewGo = null;
            switch (rViewState)
            {
                case View.State.Fixing:
                    rViewGo = DynamicRoot.transform.AddChildNoScale(rViewPrefab, "UI");
                    break;
                case View.State.Popup:
                    rViewGo = PopupRoot.transform.AddChildNoScale(rViewPrefab, "UI");
                    break;
                case View.State.Frame:
                    rViewGo = FrameRoot.transform.AddChildNoScale(rViewPrefab, "UI");
                    break;
                case View.State.PageSwitch:
                case View.State.PageOverlap:
                    rViewGo = PageRoot.transform.AddChildNoScale(rViewPrefab, "UI");
                    break;
            }

            var rView = View.CreateView(rViewGo);
            string rViewGUID = Guid.NewGuid().ToString(); //生成GUID
            if (rView == null)
            {
                Debug.LogErrorFormat("GameObject {0} is null.", rViewGo.name);
                UtilTool.SafeExecute(rOpenCompleted, null);
                return null;
            }

            // 设置Default ViewModel
            rView.DefaultViewModel = rViewModel;

            //新的View的存储逻辑
            switch (rViewState)
            {
                case View.State.Fixing:
                    mCurFixedViews.Add(rViewGUID, rView);
                    break;
                case View.State.Frame:
                    mCurFrameViews.Add(rViewGUID, rView);
                    break;
                case View.State.PageSwitch:
                    if (mCurPageViews.Count == 0)
                    {
                        mCurPageViews.Add(rViewGUID, rView);
                    }
                    else
                    {
                        var rTopNode = mCurPageViews.Last();
                        mCurPageViews.Remove(rTopNode.Key);
                        mCurPageViews.Add(rViewGUID, rView);
                    }

                    break;
                case View.State.PageOverlap:
                    mCurPageViews.Add(rViewGUID, rView);
                    break;
                case View.State.Popup:
                    mCurPageViews.Add(rViewGUID, rView);
                    break;
                default:
                    break;
            }

            try
            {
                await rView.Initialize(rViewName, rViewGUID, rViewState); //为View的初始化设置
                await rView.Open();
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }

            UtilTool.SafeExecute(rOpenCompleted, rView);
            return rView;
        }

        /// <summary>
        /// 企图关闭一个当前的View，当存在当前View时候，并且传入的View是需要Dispatch的。
        /// </summary>
        private void MaybeCloseTopView(View.State rViewState)
        {
            // 得到顶层结点
            CKeyValuePair<string, View> rTopNode = null;
            if (mCurPageViews.Count > 0)
            {
                rTopNode = mCurPageViews.Last();
            }

            if (rTopNode == null)
            {
                return;
            }

            string rViewGUID = rTopNode.Key;
            View rView = rTopNode.Value;
            if (rView == null) return;

            if (rViewState == View.State.PageSwitch)
            {
                // 移除顶层结点
                mCurPageViews.Remove(rViewGUID);
                rView.Close();
                DestroyView(rView);
            }
        }

        /// <summary>
        /// 等待View关闭动画播放完后开始删除一个View
        /// </summary>
        private void DestroyView(View rView)
        {
            rView.Dispose();
            UtilTool.SafeDestroy(rView.GameObject);
            rView = null;
        }
    }
}
