using System.Threading.Tasks;
using Knight.Core;
using Knight.Framework.Stage;
using Knight.Hotfix.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class MainStageInfoPanel : ViewController
    {
        private Image userHeadImg;

        protected override async Task OnOpen()
        {
            await base.OnOpen();
            Transform view = View.GameObject.transform;
            userHeadImg = view.Find("HeadGroup/UserHeadImg").GetComponent<Image>();
        }

        [DataBinding]
        private void OnHeadImgClicked(EventArg rEventArg)
        {
            Log.CI(Log.COLOR_ORANGE, "点击头像");

            string rUIABPath = "game/gui/textures/atlas/atlas_head_icon.ab";
            var rAssetRequest =
                AssetLoader.Instance.LoadAsset(rUIABPath, "m3", AssetLoader.Instance.IsSumilateMode_GUI());
            if (rAssetRequest.Asset != null)
            {
                Texture2D texture = rAssetRequest.Asset as Texture2D;

                if (texture != null)
                {
                    Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height),
                        new Vector2(0.5f, 0.5f));
                    if (sprite != null)
                    {
                        userHeadImg.sprite = sprite;
                    }
                }
            }
        }
    }
}
