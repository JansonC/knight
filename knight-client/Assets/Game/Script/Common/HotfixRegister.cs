using Knight.Framework.Hotfix;

namespace Game
{
    public static class HotfixRegister
    {
        public static void Register()
        {
            HotfixApp_ILRT.OnHotfixRegisterFunc = (rApp) => 
            {
                rApp.DelegateManager.RegisterMethodDelegate<Knight.Framework.Net.AChannel, int>();
            };
        }
    }
}
