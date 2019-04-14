using Knight.Hotfix.Core;

namespace Game
{
    public class Account : THotfixSingleton<Account>
    {
        public string PlayerName { get; set; }
        public int CoinCount { get; set; }

        private Account()
        {
        }

        public void Initialize()
        {
            PlayerName = "Knight";
            CoinCount = 999999;
        }
    }
}
