using System.IO;
using Knight.Hotfix.Core;

/// <summary>
/// Auto generate code, not need modify.
/// </summary>
namespace Game
{
    public partial class ActorAvatar
    {
        public override void Serialize(BinaryWriter rWriter)
        {
            base.Serialize(rWriter);
            rWriter.Serialize(ID);
            rWriter.Serialize(AvatarName);
            rWriter.Serialize(ABPath);
            rWriter.Serialize(AssetName);
        }

        public override void Deserialize(BinaryReader rReader)
        {
            base.Deserialize(rReader);
            ID = rReader.Deserialize(ID);
            AvatarName = rReader.Deserialize(AvatarName);
            ABPath = rReader.Deserialize(ABPath);
            AssetName = rReader.Deserialize(AssetName);
        }
    }
}
