using System.IO;
using Knight.Hotfix.Core;

/// <summary>
/// Auto generate code, not need modify.
/// </summary>
namespace Game
{
    public partial class R2C_Login
    {
        public override void Serialize(BinaryWriter rWriter)
        {
            base.Serialize(rWriter);
            rWriter.Serialize(RpcId);
            rWriter.Serialize(Error);
            rWriter.Serialize(Message);
            rWriter.Serialize(Address);
            rWriter.Serialize(Key);
        }

        public override void Deserialize(BinaryReader rReader)
        {
            base.Deserialize(rReader);
            RpcId = rReader.Deserialize(RpcId);
            Error = rReader.Deserialize(Error);
            Message = rReader.Deserialize(Message);
            Address = rReader.Deserialize(Address);
            Key = rReader.Deserialize(Key);
        }
    }
}
