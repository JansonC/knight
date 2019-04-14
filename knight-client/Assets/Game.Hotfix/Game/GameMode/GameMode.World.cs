using Knight.Hotfix.Core;

namespace Game
{
    public partial class GameMode_World : GameMode
    {
        protected override void OnBuildStages()
        {
            AddGameStage(0, new StageTask_LoadAssets(this));
            AddGameStage(2, new StageTask_InitData(this));
        }
    }
}
