using System;
using System.Threading.Tasks;
using Knight.Core;
using Knight.Framework.Character;

namespace Knight.Hotfix.Core
{
    public class Knight : Character
    {
        protected override async Task InitializeCharacterModel()
        {
            CharacterControllerContainer = GameObject.GetComponent<KnightControllerContainer>();
            if (CharacterControllerContainer == null)
            {
                Log.CI(Log.COLOR_RED, "'{0}' 预制体没有KnightControllerContainer脚本组件", CharacterId);
                return;
            }

            var rType = Type.GetType(CharacterControllerContainer.CharacterControllerClass);
            if (rType == null)
            {
                Log.CI(Log.COLOR_RED, "找不到对应的KnightControllerClass, className: {0}",
                    CharacterControllerContainer.CharacterControllerClass);
                return;
            }

            // 构建CharacterController
            CharacterController = HotfixReflectAssists.Construct(rType) as KnightController;
            CharacterController.Character = this;
            Log.I("初始化{0}", rType.Name);
            await CharacterController.Initialize();
        }
    }
}
