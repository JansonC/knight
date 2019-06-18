using Knight.Core;
using UnityEngine;

namespace Knight.Framework.Stage
{
    public class StageAssetLoader : TSingleton<StageAssetLoader>
    {
        public class LoaderRequest
        {
            public GameObject ViewPrefabGo;
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
        /// 异步加载UI
        /// </summary>
        public LoaderRequest LoadStage(string rViewName)
        {
            LoaderRequest rRequest = new LoaderRequest(rViewName);
            string rUIABPath = "game/stage/prefabs/" + rRequest.StageName.ToLower() + ".ab";
            var rAssetRequest = AssetLoader.Instance.LoadAsset(rUIABPath, rRequest.StageName,
                AssetLoader.Instance.IsSumilateMode_GUI());
            if (rAssetRequest.Asset != null)
            {
                rRequest.ViewPrefabGo = rAssetRequest.Asset as GameObject;
            }

            return rRequest;
        }

        /// <summary>
        /// 卸载UI资源
        /// </summary>
        public void UnloadStage(string rViewName)
        {
            string rUIABPath = "game/stage/prefabs/" + rViewName.ToLower() + ".ab";
            AssetLoader.Instance.UnloadAsset(rUIABPath);
        }
    }
}
