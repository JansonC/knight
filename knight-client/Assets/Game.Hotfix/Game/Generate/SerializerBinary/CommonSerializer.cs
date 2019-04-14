using System.IO;
using Knight.Hotfix.Core;
using Knight.Core;

/// <summary>
/// Auto generate code, not need modify.
/// </summary>
namespace Game
{
    public static class CommonSerializer
    {
        public static void Serialize(this BinaryWriter rWriter, Dict<int, ActorAvatar> value)
        {
            var bValid = null != value;
            rWriter.Serialize(bValid);
            if (!bValid) return;

            rWriter.Serialize(value.Count);
            foreach (var rPair in value)
            {
                rWriter.Serialize(rPair.Key);
                rWriter.Serialize(rPair.Value);
            }
        }

        public static Dict<int, ActorAvatar> Deserialize(this BinaryReader rReader, Dict<int, ActorAvatar> value)
        {
            var bValid = rReader.Deserialize(default(bool));
            if (!bValid) return null;

            var nCount = rReader.Deserialize(default(int));
            var rResult = new Dict<int, ActorAvatar>();
            for (int nIndex = 0; nIndex < nCount; ++nIndex)
            {
                var rKey = rReader.Deserialize(default(int));
                var rValue = rReader.Deserialize(default(ActorAvatar));
                rResult.Add(rKey, rValue);
            }

            return rResult;
        }

        public static void Serialize(this BinaryWriter rWriter, Dict<int, ActorHero> value)
        {
            var bValid = null != value;
            rWriter.Serialize(bValid);
            if (!bValid) return;

            rWriter.Serialize(value.Count);
            foreach (var rPair in value)
            {
                rWriter.Serialize(rPair.Key);
                rWriter.Serialize(rPair.Value);
            }
        }

        public static Dict<int, ActorHero> Deserialize(this BinaryReader rReader, Dict<int, ActorHero> value)
        {
            var bValid = rReader.Deserialize(default(bool));
            if (!bValid) return null;

            var nCount = rReader.Deserialize(default(int));
            var rResult = new Dict<int, ActorHero>();
            for (int nIndex = 0; nIndex < nCount; ++nIndex)
            {
                var rKey = rReader.Deserialize(default(int));
                var rValue = rReader.Deserialize(default(ActorHero));
                rResult.Add(rKey, rValue);
            }

            return rResult;
        }

        public static void Serialize(this BinaryWriter rWriter, Dict<int, ActorProfessional> value)
        {
            var bValid = null != value;
            rWriter.Serialize(bValid);
            if (!bValid) return;

            rWriter.Serialize(value.Count);
            foreach (var rPair in value)
            {
                rWriter.Serialize(rPair.Key);
                rWriter.Serialize(rPair.Value);
            }
        }

        public static Dict<int, ActorProfessional> Deserialize(this BinaryReader rReader,
            Dict<int, ActorProfessional> value)
        {
            var bValid = rReader.Deserialize(default(bool));
            if (!bValid) return null;

            var nCount = rReader.Deserialize(default(int));
            var rResult = new Dict<int, ActorProfessional>();
            for (int nIndex = 0; nIndex < nCount; ++nIndex)
            {
                var rKey = rReader.Deserialize(default(int));
                var rValue = rReader.Deserialize(default(ActorProfessional));
                rResult.Add(rKey, rValue);
            }

            return rResult;
        }

        public static void Serialize(this BinaryWriter rWriter, Dict<int, StageConfig> value)
        {
            var bValid = null != value;
            rWriter.Serialize(bValid);
            if (!bValid) return;

            rWriter.Serialize(value.Count);
            foreach (var rPair in value)
            {
                rWriter.Serialize(rPair.Key);
                rWriter.Serialize(rPair.Value);
            }
        }

        public static Dict<int, StageConfig> Deserialize(this BinaryReader rReader, Dict<int, StageConfig> value)
        {
            var bValid = rReader.Deserialize(default(bool));
            if (!bValid) return null;

            var nCount = rReader.Deserialize(default(int));
            var rResult = new Dict<int, StageConfig>();
            for (int nIndex = 0; nIndex < nCount; ++nIndex)
            {
                var rKey = rReader.Deserialize(default(int));
                var rValue = rReader.Deserialize(default(StageConfig));
                rResult.Add(rKey, rValue);
            }

            return rResult;
        }

        public static void Serialize(this BinaryWriter rWriter, float[] value)
        {
            var bValid = (null != value);
            rWriter.Serialize(bValid);
            if (!bValid) return;

            rWriter.Serialize(value.Length);
            for (int nIndex = 0; nIndex < value.Length; nIndex++)
                rWriter.Serialize(value[nIndex]);
        }

        public static float[] Deserialize(this BinaryReader rReader, float[] value)
        {
            var bValid = rReader.Deserialize(default(bool));
            if (!bValid) return null;

            var nCount = rReader.Deserialize(default(int));
            var rResult = new float[nCount];
            for (int nIndex = 0; nIndex < nCount; nIndex++)
                rResult[nIndex] = rReader.Deserialize(default(float));
            return rResult;
        }
    }
}
