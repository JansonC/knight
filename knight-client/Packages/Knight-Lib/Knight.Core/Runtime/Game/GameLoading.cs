//======================================================================
//        Copyright (C) 2015-2020 Winddy He. All rights reserved
//        Email: hgplan@126.com
//======================================================================
using UnityEngine;

namespace Knight.Core
{
    public interface ILoadingView
    {
        void ShowLoading(string rTextTips);
        void ShowLoading(float rIntervalTime, string rTextTips);
        void SetLoadingProgress(float fProgressValue);
        void HideLoading();
        void SetTips(string rTextTips);
    }

    public class GameLoading : MonoBehaviour
    {
        public static GameLoading Instance { get; private set; }

        /// <summary>
        /// 加载界面
        /// </summary>
        public ILoadingView LoadingView;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        /// <summary>
        /// 开始加载
        /// </summary>
        public void StartLoading(float rIntervalTime, string rTextTips = "")
        {
            LoadingView?.ShowLoading(rIntervalTime, rTextTips);
        }

        public void StartLoading(string rTextTips = "")
        {
            LoadingView?.ShowLoading(rTextTips);
        }

        public void SetTips(string rTextTips)
        {
            LoadingView?.SetTips(rTextTips);
        }

        public void SetLoadingProgress(float fProgressValue)
        {
            LoadingView?.SetLoadingProgress(fProgressValue);
        }

        public void Hide()
        {
            LoadingView?.HideLoading();
        }
    }
}
