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
        private HotfixEventTrigger cropsBtnEvent;

        protected override async Task OnInitialize()
        {
            await base.OnInitialize();

            GameObject cropsBtn = Stage.GameObject.transform.Find("CropsBtn").gameObject;
            HotfixEventManager.Instance.Binding(cropsBtn, HEventTriggerType.PointerClick, OnCropsBtnClick);
        }

        private void OnCropsBtnClick(Object obj)
        {
            Log.CI(Log.COLOR_GREEN, "点击军团按钮");
        }
    }
}
