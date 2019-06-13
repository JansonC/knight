using Knight.Core;
using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Knight.Hotfix.Core
{
    public class View
    {
        public enum State
        {
            Fixing,
            Frame,
            Popup,
            PageSwitch,
            PageOverlap,
        }

        public string GUID = "";
        public string ViewName = "";
        public State CurState = State.Fixing;
        public bool IsBackCache = false;

        public GameObject GameObject;

        public ViewControllerContainer ViewModelContainer;
        public ViewController ViewController;
        public ViewModel DefaultViewModel;

        public bool IsActived
        {
            get { return GameObject.activeSelf; }
            set { GameObject.SetActive(value); }
        }

        public static View CreateView(GameObject rViewGo)
        {
            if (rViewGo == null) return null;
            View rUIView = new View();
            rUIView.GameObject = rViewGo;
            return rUIView;
        }

        public async Task Initialize(string rViewName, string rViewGUID, State rViewState)
        {
            ViewName = rViewName;
            GUID = rViewGUID;
            CurState = rViewState;

            // 初始化ViewController
            await InitializeViewModel();
        }

        /// <summary>
        /// 初始化ViewController
        /// </summary>
        private async Task InitializeViewModel()
        {
            ViewModelContainer = GameObject.GetComponent<ViewControllerContainer>();
            if (ViewModelContainer == null)
            {
                Log.CI(Log.COLOR_RED, "'{0}' 预制体没有ViewContainer脚本组件", ViewName);
                return;
            }

            var rType = Type.GetType(ViewModelContainer.ViewControllerClass);
            if (rType == null)
            {
                Log.CI(Log.COLOR_RED, "找不到对应的ViewModel，type: {0}", rType);
                return;
            }

            // 构建ViewController
            ViewController = HotfixReflectAssists.Construct(rType) as ViewController;
            ViewController.View = this;
            ViewController.BindingViewModels(ViewModelContainer);
            await ViewController.Initialize();
            ViewController.DataBindingConnect(ViewModelContainer);
        }

        /// <summary>
        /// 打开View, 此时View对应的GameObject已经加载出来了, 用于做View的初始化。
        /// </summary>
        public async Task Open()
        {
            await ViewController?.Open();
        }

        /// <summary>
        /// 显示View
        /// </summary>
        public void Show()
        {
            GameObject.SetActive(true);
            ViewController?.Show();
        }

        /// <summary>
        /// 隐藏View
        /// </summary>
        public void Hide()
        {
            GameObject.SetActive(false);
            ViewController?.Hide();
        }

        public void Update()
        {
            ViewController?.Update();
        }

        public void Dispose()
        {
            ViewController?.DataBindingDisconnect(ViewModelContainer);
            ViewController?.Dispose();
        }

        /// <summary>
        /// 关闭View
        /// </summary>
        public void Close()
        {
            ViewController?.Closing();
        }
    }
}
