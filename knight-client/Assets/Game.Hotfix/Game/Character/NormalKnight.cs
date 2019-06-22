using Knight.Core;
using Knight.Hotfix.Core;

namespace Game
{
    public class NormalKnight : KnightController
    {
        public override void AnimaEventCb(string evenName)
        {
            Log.I("热更新 Anima Cb, " +evenName);
        }
    }
}
