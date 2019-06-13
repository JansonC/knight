using Knight.Framework.Net;

namespace Knight.Hotfix.Core
{
    public class HotfixNetworkClientDispatcher
    {
        public void Dispatch(NetworkSession rSession, Packet rPacket)
        {
            HotfixNetworkClient.Instance.Run(rSession, rPacket);
        }
    }
}
