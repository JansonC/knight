using Knight.Hotfix.Core;
using UnityEngine.UI;

namespace Game
{
    [DataBinding]
    public class LoginViewModel : ViewModel
    {
        private string mAccountName = "Knight";
        private string mPassword = "knight666";

        [DataBinding]
        public string AccountName
        {
            get { return mAccountName; }
            set
            {
                mAccountName = value;
                PropChanged("AccountName");
            }
        }

        [DataBinding]
        public string Password
        {
            get { return mPassword; }
            set
            {
                mPassword = value;
                PropChanged("Password");
            }
        }
    }
}
