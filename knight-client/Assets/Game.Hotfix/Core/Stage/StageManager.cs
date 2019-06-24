using System;
using System.Threading.Tasks;
using Knight.Core;
using Knight.Framework.Stage;
using UnityEngine;

namespace Knight.Hotfix.Core
{
    public class StageManager : THotfixSingleton<StageManager>
    {
        private GameObject stageRoot;
        private Stage curStage;

        private StageManager()
        {
        }

        public void Initialize()
        {
            stageRoot = StageRoot.Instance.gameObject;
        }

        public async Task<Stage> SwitchSatge(string stageName)
        {
            var loaderRequest = StageAssetLoader.Instance.LoadStage(stageName);
            if (loaderRequest.StagePrefabGo == null)
            {
                Log.CI(Log.COLOR_RED, "切换舞台出错，未找到预制体：{0}", stageName);
                return null;
            }

            //把Stage的GameObject结点加到stageRoot下
            GameObject stageGo = stageRoot.transform.AddChild(loaderRequest.StagePrefabGo, "Stage");
            Stage stage = Stage.CreateStage(stageGo);
            string stageGUID = Guid.NewGuid().ToString(); //生成GUID
            if (stage == null)
            {
                Log.CI(Log.COLOR_RED, "Stage GameObject {0} is null.", stageGo.name);
                return null;
            }

            if (curStage != null)
            {
                Log.CI(Log.COLOR_YELLOW, "切换舞台，移除旧的舞台：{0}", curStage.StageName);
                curStage.StageController.Closing();
                UnityEngine.Object.Destroy(curStage.GameObject);
            }

            try
            {
                await stage.Initialize(stageName, stageGUID);
                await stage.Open();
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }

            curStage = stage;
            return stage;
        }

        public void Update()
        {
            if (curStage != null)
            {
                curStage.Update();
            }
        }
    }
}
