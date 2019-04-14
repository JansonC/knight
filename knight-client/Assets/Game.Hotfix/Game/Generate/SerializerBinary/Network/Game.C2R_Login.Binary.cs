using System.IO;
using Knight.Hotfix.Core;

/// <summary>
/// Auto generate code, not need modify.
/// </summary>
namespace Game
{
    public partial class C2R_Login
    {
        public override void Serialize(BinaryWriter rWriter)
        {
            base.Serialize(rWriter);
            rWriter.Serialize(RpcId);
            rWriter.Serialize(Account);
            rWriter.Serialize(Password);
        }

        public override void Deserialize(BinaryReader rReader)
        {
            base.Deserialize(rReader);
            RpcId = rReader.Deserialize(RpcId);
            Account = rReader.Deserialize(Account);
            Password = rReader.Deserialize(Password);
        }
    }
}
