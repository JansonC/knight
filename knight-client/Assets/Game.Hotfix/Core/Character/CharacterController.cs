using System.Threading.Tasks;

namespace Knight.Hotfix.Core
{
    public class CharacterController : HotfixKnightObject
    {
        public Character Character;

        public CharacterController()
        {
        }

        public string GUID
        {
            get
            {
                if (Character == null)
                {
                    return "";
                }

                return Character.GUID;
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

        public virtual void AnimaEventCb(string evenName)
        {
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
