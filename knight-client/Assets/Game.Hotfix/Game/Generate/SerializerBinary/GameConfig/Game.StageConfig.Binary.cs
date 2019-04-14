using System.IO;
using Knight.Hotfix.Core;

/// <summary>
/// Auto generate code, not need modify.
/// </summary>
namespace Game
{
    public partial class StageConfig
    {
        public override void Serialize(BinaryWriter rWriter)
        {
            base.Serialize(rWriter);
            rWriter.Serialize(StageID);
            rWriter.Serialize(SceneABPath);
            rWriter.Serialize(ScenePath);
            rWriter.Serialize(BornPos);
            rWriter.Serialize(CameraSettings);
        }

        public override void Deserialize(BinaryReader rReader)
        {
            base.Deserialize(rReader);
            StageID = rReader.Deserialize(StageID);
            SceneABPath = rReader.Deserialize(SceneABPath);
            ScenePath = rReader.Deserialize(ScenePath);
            BornPos = rReader.Deserialize(BornPos);
            CameraSettings = rReader.Deserialize(CameraSettings);
        }
    }
}
