namespace Knight.Framework.Character
{
    public class MonsterControllerContainer : CharacterControllerContainer
    {
        public override void GetAllViewModelDataSources()
        {
            CharacterControllerClasses = DataBindingTypeResolve.GetAllMonsters().ToArray();
        }
    }
}
