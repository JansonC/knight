using System.IO;
using Knight.Hotfix.Core;

/// <summary>
/// Auto generate code, not need modify.
/// </summary>
namespace Game
{
    public partial class ActorHero
    {
        public override void Serialize(BinaryWriter rWriter)
        {
            base.Serialize(rWriter);
            rWriter.Serialize(ID);
            rWriter.Serialize(Name);
            rWriter.Serialize(AvatarID);
            rWriter.Serialize(SkillID);
            rWriter.Serialize(Scale);
            rWriter.Serialize(Height);
            rWriter.Serialize(Radius);
        }

        public override void Deserialize(BinaryReader rReader)
        {
            base.Deserialize(rReader);
            ID = rReader.Deserialize(ID);
            Name = rReader.Deserialize(Name);
            AvatarID = rReader.Deserialize(AvatarID);
            SkillID = rReader.Deserialize(SkillID);
            Scale = rReader.Deserialize(Scale);
            Height = rReader.Deserialize(Height);
            Radius = rReader.Deserialize(Radius);
        }
    }
}
