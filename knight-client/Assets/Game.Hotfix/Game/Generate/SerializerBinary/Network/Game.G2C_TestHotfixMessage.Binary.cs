using System.IO;
using Knight.Hotfix.Core;

/// <summary>
/// Auto generate code, not need modify.
/// </summary>
namespace Game
{
    public partial class G2C_TestHotfixMessage
    {
        public override void Serialize(BinaryWriter rWriter)
        {
            base.Serialize(rWriter);
            rWriter.Serialize(Info);
        }

        public override void Deserialize(BinaryReader rReader)
        {
            base.Deserialize(rReader);
            Info = rReader.Deserialize(Info);
        }
    }
}
