using System;
using System.Threading.Tasks;
using Knight.Core;
using Knight.Framework.Stage;
using UnityEngine;
using Game;

namespace Knight.Hotfix.Core
{
    public class Stage
    {
        public string GUID = "";
        public string StageName = "";
        public GameObject GameObject;
        public StageControllerContainer StageControllerContainer;
        public StageController StageController;

        public bool IsActived
        {
            get { return GameObject.activeSelf; }
            set { GameObject.SetActive(value); }
        }

        public static Stage CreateStage(GameObject stageGo)
        {
            if (stageGo == null)
            {
                return null;
            }

            Stage stage = new Stage();
            stage.GameObject = stageGo;
            return stage;
        }

        public async Task Initialize(string stageName, string stageGUID)
        {
            StageName = stageName;
            GUID = stageGUID;
            await InitializeStageModel();
        }

        /// <summary>
        /// 初始化ViewController
        /// </summary>
        private async Task InitializeStageModel()
        {
            StageControllerContainer = GameObject.GetComponent<StageControllerContainer>();
            if (StageControllerContainer == null)
            {
                Log.CI(Log.COLOR_RED, "'{0}' 预制体没有StageControllerContainer脚本组件", StageName);
                return;
            }
            
            var rType = Type.GetType(StageControllerContainer.StageControllerClass);
            if (rType == null)
            {
                Log.CI(Log.COLOR_RED, "找不到对应的StageControllerClass, className: {0}",
                    StageControllerContainer.StageControllerClass);
                return;
            }

            // 构建StageController
            StageController = HotfixReflectAssists.Construct(rType) as StageController;
            StageController.Stage = this;
            Log.I("初始化{0}", rType.Name);
            await StageController.Initialize();
        }

        /// <summary>
        /// 打开View, 此时View对应的GameObject已经加载出来了, 用于做View的初始化。
        /// </summary>
        public async Task Open()
        {
            await StageController?.Open();
        }

        /// <summary>
        /// 显示View
        /// </summary>
        public void Show()
        {
            GameObject.SetActive(true);
            StageController?.Show();
        }

        /// <summary>
        /// 隐藏View
        /// </summary>
        public void Hide()
        {
            GameObject.SetActive(false);
            StageController?.Hide();
        }

        public void Update()
        {
            StageController?.Update();
        }

        public void Dispose()
        {
            StageController?.Dispose();
        }

        /// <summary>
        /// 关闭View
        /// </summary>
        public void Close()
        {
            StageController?.Closing();
        }
    }
}
