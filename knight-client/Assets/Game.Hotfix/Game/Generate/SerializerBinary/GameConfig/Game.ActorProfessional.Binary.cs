using System.IO;
using Knight.Hotfix.Core;

/// <summary>
/// Auto generate code, not need modify.
/// </summary>
namespace Game
{
    public partial class ActorProfessional
    {
        public override void Serialize(BinaryWriter rWriter)
        {
            base.Serialize(rWriter);
            rWriter.Serialize(ID);
            rWriter.Serialize(HeroID);
            rWriter.Serialize(Name);
            rWriter.Serialize(Desc);
        }

        public override void Deserialize(BinaryReader rReader)
        {
            base.Deserialize(rReader);
            ID = rReader.Deserialize(ID);
            HeroID = rReader.Deserialize(HeroID);
            Name = rReader.Deserialize(Name);
            Desc = rReader.Deserialize(Desc);
        }
    }
}
