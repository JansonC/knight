using System.Threading.Tasks;
using Knight.Core;
using Knight.Hotfix.Core;
using UnityEngine;

namespace Game
{
    public class DungeonStage : StageController
    {
        private Transform leftBg;
        private Transform rightBg;

        protected override async Task OnInitialize()
        {
            await base.OnInitialize();
        }

        protected override async Task OnOpen()
        {
            await base.OnOpen();
            Transform stageTrans = Stage.GameObject.transform;
            leftBg = stageTrans.Find("BgLeft");
            rightBg = stageTrans.Find("BgRight");
            ResetBgPosition();
        }

        protected override void OnClose()
        {
            base.OnClose();
        }

        private void ResetBgPosition()
        {
            float width = WorldUtils.GetScreenWidth();
            float height = WorldUtils.GetScreenHeight();
            float radio = width / height;
            if (radio > WorldUtils.GetScreenMaxRadio())
            {
                radio = WorldUtils.GetScreenMaxRadio();
            }

            if (radio < WorldUtils.GetScreenMinRadio())
            {
                radio = WorldUtils.GetScreenMinRadio();
            }

            float unityWidth = WorldUtils.MaxScreenHeight * radio / WorldUtils.GamePixelUnit / 2;
            leftBg.localPosition = new Vector2(-unityWidth, 0);
            rightBg.localPosition = new Vector2(unityWidth, 0);
        }
    }
}
