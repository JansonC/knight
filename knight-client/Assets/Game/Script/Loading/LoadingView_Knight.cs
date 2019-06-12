//======================================================================
//        Copyright (C) 2015-2020 Winddy He. All rights reserved
//        Email: hgplan@126.com
//======================================================================
using UnityEngine;
using System.Collections;
using Knight.Core;
using UnityEngine.UI;

namespace Game
{
    public class LoadingView_Knight : MonoBehaviour, ILoadingView
    {
        public static LoadingView_Knight Instance { get; private set; }

        /// <summary>
        /// 背景图片，可能有需要切换的情况
        /// </summary>
        public Image Background;

        /// <summary>
        /// 加载的进度条
        /// </summary>
        public Slider LoadingBar;

        /// <summary>
        /// 加载时候的一些文字提示
        /// </summary>
        public Text TextTips;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        public void SetTips(string rTips)
        {
            TextTips.text = rTips;
        }

        public void SetLoadingProgress(float rValue)
        {
            LoadingBar.value = rValue;
        }

        /// <summary>
        /// 开始出现加载界面
        /// </summary>
        public void ShowLoading(float rIntervalTime, string rTextTips = "")
        {
            gameObject.SetActive(true);
            SetTips(rTextTips);
            SetLoadingProgress(0);
            StartCoroutine(LoadingProgress(rIntervalTime));
        }

        /// <summary>
        /// 开始出现加载界面
        /// </summary>
        public void ShowLoading(string rTextTips)
        {
            gameObject.SetActive(true);
            SetTips(rTextTips);
            SetLoadingProgress(0);
        }

        /// <summary>
        /// 加载界面
        /// </summary>
        public void HideLoading()
        {
            SetLoadingProgress(1);
            gameObject.SetActive(false);
            SetTips("");
        }

        private IEnumerator LoadingProgress(float rIntervalTime)
        {
            float rLoadingTime = rIntervalTime * 0.9f;
            float rCurTime = 0;
            while (rCurTime <= rLoadingTime)
            {
                SetLoadingProgress(rCurTime / rIntervalTime);
                yield return 0;
                rCurTime += Time.deltaTime;
            }
        }
    }
}
