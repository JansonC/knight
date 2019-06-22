using System.Threading.Tasks;
using Knight.Core;
using Knight.Framework;
using Knight.Framework.Hotfix;
using Knight.Hotfix.Core;
using UnityEngine;

namespace Game
{
    public class MainStage : StageController
    {
        private GameObject cropsBtn;
        private GameObject dungeonBtn;
        private GameObject buidlKnightBtn;

        protected override async Task OnInitialize()
        {
            await base.OnInitialize();
            ViewManager.Instance.OpenAsync("MainStageInfoPanel", View.State.Fixing);
        }

        protected override async Task OnOpen()
        {
            await base.OnOpen();
            Transform stageTrans = Stage.GameObject.transform;
            cropsBtn = stageTrans.Find("CropsBtn").gameObject;
            dungeonBtn = stageTrans.Find("DungeonBtn").gameObject;
            buidlKnightBtn = stageTrans.Find("BuildKnightBtn").gameObject;
            HotfixEventManager.Instance.Binding(cropsBtn, HEventTriggerType.PointerClick, OnCropsBtnClick);
            HotfixEventManager.Instance.Binding(dungeonBtn, HEventTriggerType.PointerClick, OnDungeonBtnClick);
            HotfixEventManager.Instance.Binding(buidlKnightBtn, HEventTriggerType.PointerClick, OnBuildKnightBtnClick);
        }

        protected override void OnClose()
        {
            base.OnClose();
            HotfixEventManager.Instance.UnBinding(cropsBtn, HEventTriggerType.PointerClick, OnCropsBtnClick);
            HotfixEventManager.Instance.UnBinding(dungeonBtn, HEventTriggerType.PointerClick, OnDungeonBtnClick);
            HotfixEventManager.Instance.UnBinding(buidlKnightBtn, HEventTriggerType.PointerClick,
                OnBuildKnightBtnClick);
        }

        private async void OnCropsBtnClick(Object obj)
        {
            Log.CI(Log.COLOR_GREEN, "点击军团按钮");
            await ViewManager.Instance.OpenAsync("CropsPanel", View.State.Fixing);
        }

        private async void OnDungeonBtnClick(Object obj)
        {
            Log.CI(Log.COLOR_GREEN, "点击副本按钮");
            ViewManager.Instance.CloseAllDaynamicViews();
            await StageManager.Instance.SwitchSatge("DungeonStage");
        }

        private void OnBuildKnightBtnClick(Object obj)
        {
            Log.CI(Log.COLOR_GREEN, "点击创建骑士");
            CharacterManager.Instance.BuildKnight(1);
        }
    }
}
