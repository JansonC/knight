namespace Knight.Framework.Character
{
    public class KnightControllerContainer : CharacterControllerContainer
    {
        public override void GetAllViewModelDataSources()
        {
            CharacterControllerClasses = DataBindingTypeResolve.GetAllKnights().ToArray();
        }
    }
}
