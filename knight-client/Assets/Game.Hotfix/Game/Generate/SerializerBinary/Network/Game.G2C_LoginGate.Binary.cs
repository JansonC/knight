using System.IO;
using Knight.Hotfix.Core;

/// <summary>
/// Auto generate code, not need modify.
/// </summary>
namespace Game
{
    public partial class G2C_LoginGate
    {
        public override void Serialize(BinaryWriter rWriter)
        {
            base.Serialize(rWriter);
            rWriter.Serialize(RpcId);
            rWriter.Serialize(Error);
            rWriter.Serialize(Message);
            rWriter.Serialize(PlayerId);
        }

        public override void Deserialize(BinaryReader rReader)
        {
            base.Deserialize(rReader);
            RpcId = rReader.Deserialize(RpcId);
            Error = rReader.Deserialize(Error);
            Message = rReader.Deserialize(Message);
            PlayerId = rReader.Deserialize(PlayerId);
        }
    }
}
