using Knight.Core;
using UnityEngine;

namespace Knight.Framework.Stage
{
    public class StageAssetLoader : TSingleton<StageAssetLoader>
    {
        public class LoaderRequest
        {
            public GameObject StagePrefabGo;
            public string StageName;

            public LoaderRequest(string StageName)
            {
                this.StageName = StageName;
            }
        }

        private StageAssetLoader()
        {
        }

        /// <summary>
        /// 加载舞台
        /// </summary>
        public LoaderRequest LoadStage(string stageName)
        {
            LoaderRequest rRequest = new LoaderRequest(stageName);
            string rUIABPath = "game/stage/prefabs/" + rRequest.StageName.ToLower() + ".ab";
            var rAssetRequest = AssetLoader.Instance.LoadAsset(rUIABPath, rRequest.StageName,
                AssetLoader.Instance.IsSumilateMode_GUI());
            if (rAssetRequest.Asset != null)
            {
                rRequest.StagePrefabGo = rAssetRequest.Asset as GameObject;
            }

            return rRequest;
        }

        /// <summary>
        /// 卸载舞台资源
        /// </summary>
        public void UnloadStage(string stageName)
        {
            string rUIABPath = "game/stage/prefabs/" + stageName.ToLower() + ".ab";
            AssetLoader.Instance.UnloadAsset(rUIABPath);
        }
    }
}
