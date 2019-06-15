using System.Threading.Tasks;

namespace Knight.Hotfix.Core
{
    public class StageController : HotfixKnightObject
    {
        public Stage Stage;

        public StageController()
        {
        }

        public string GUID
        {
            get
            {
                if (Stage == null)
                {
                    return "";
                }

                return Stage.GUID;
            }
        }

        public async Task Open()
        {
            await OnOpen();
        }

        public void Show()
        {
            OnShow();
        }

        public void Hide()
        {
            OnHide();
        }

        public void Closing()
        {
            OnClose();
        }

        /// <summary>
        /// 数据绑定前
        /// </summary>

        #region Virtual Function

        protected override async Task OnInitialize()
        {
            await base.OnInitialize();
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
        }

        protected override void OnDispose()
        {
            base.Dispose();
        }

        /// <summary>
        /// 数据绑定之后
        /// </summary>
#pragma warning disable 1998
        protected virtual async Task OnOpen()
#pragma warning restore 1998
        {
        }

        protected virtual void OnShow()
        {
        }

        protected virtual void OnHide()
        {
        }

        protected virtual void OnClose()
        {
        }

        #endregion
    }
}
