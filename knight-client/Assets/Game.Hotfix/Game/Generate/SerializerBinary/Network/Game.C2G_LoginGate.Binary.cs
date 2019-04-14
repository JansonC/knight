using System.IO;
using Knight.Hotfix.Core;

/// <summary>
/// Auto generate code, not need modify.
/// </summary>
namespace Game
{
	public partial class C2G_LoginGate
	{
		public override void Serialize(BinaryWriter rWriter)
		{
			base.Serialize(rWriter);
			rWriter.Serialize(RpcId);
			rWriter.Serialize(Key);
		}
		public override void Deserialize(BinaryReader rReader)
		{
			base.Deserialize(rReader);
			RpcId = rReader.Deserialize(RpcId);
			Key = rReader.Deserialize(Key);
		}
	}
}

