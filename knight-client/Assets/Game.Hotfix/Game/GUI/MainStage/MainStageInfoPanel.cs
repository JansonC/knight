using System.Threading.Tasks;
using Knight.Core;
using Knight.Framework.Tweening;
using Knight.Hotfix.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class MainStageInfoPanel : ViewController
    {
        private Image userHeadImg;
        private int headIndex = 1;
        private GameObject cropsMgrGroup;
        private ScaleTweening cropsMgrGroupTA;
        private bool isTARevert = false;

        protected override async Task OnOpen()
        {
            await base.OnOpen();
            Transform view = View.GameObject.transform;
            userHeadImg = view.Find("HeadGroup/UserHeadImg").GetComponent<Image>();
            cropsMgrGroup = view.Find("CropsMgrGroup").gameObject;
            cropsMgrGroupTA = cropsMgrGroup.GetComponent<ScaleTweening>();
            cropsMgrGroupTA.SetCompleted(OnCropsMgrGroupTAComplete);
            cropsMgrGroupTA.SetRewind(OnCropsMgrGroupTAComplete);
        }

        [DataBinding]
        private void OnHeadImgClicked(EventArg eventArg)
        {
            Log.CI(Log.COLOR_ORANGE, "点击头像");

            string rUIABPath = "game/gui/textures/atlas/atlas_head_icon.ab";
            var rAssetRequest =
                AssetLoader.Instance.LoadAsset(rUIABPath, "m" + headIndex, AssetLoader.Instance.IsSumilateMode_GUI());
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
                        headIndex++;
                        if (headIndex > 15)
                        {
                            headIndex = 1;
                        }
                    }
                }
            }
        }

        [DataBinding]
        private void OnCropsMgrBtnClicked(EventArg eventArg)
        {
            if (cropsMgrGroup.activeSelf)
            {
                isTARevert = true;
                cropsMgrGroupTA.Revert();
            }
            else
            {
                isTARevert = false;
                cropsMgrGroup.SetActive(true);
                cropsMgrGroupTA.Play();
            }
        }

        private void OnCropsMgrGroupTAComplete()
        {
            cropsMgrGroup.SetActive(!isTARevert);
        }

        [DataBinding]
        private void OnKnightMgrBtnClick(EventArg eventArg)
        {
            Log.I("点击骑士管理按钮");
        }
    }
}
