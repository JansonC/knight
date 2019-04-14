using System.IO;

/// <summary>
/// Auto generate code, not need modify.
/// </summary>
namespace Game
{
    public partial class GameConfig
    {
        public override void Serialize(BinaryWriter rWriter)
        {
            base.Serialize(rWriter);
            rWriter.Serialize(Avatars);
            rWriter.Serialize(Heros);
            rWriter.Serialize(ActorProfessionals);
            rWriter.Serialize(StageConfigs);
        }

        public override void Deserialize(BinaryReader rReader)
        {
            base.Deserialize(rReader);
            Avatars = rReader.Deserialize(Avatars);
            Heros = rReader.Deserialize(Heros);
            ActorProfessionals = rReader.Deserialize(ActorProfessionals);
            StageConfigs = rReader.Deserialize(StageConfigs);
        }
    }
}
