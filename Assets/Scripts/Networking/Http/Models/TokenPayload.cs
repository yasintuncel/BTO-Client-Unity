// created by yasintuncel
using System;

namespace BattleTacticsOnline.Networking.Http.Models
{
    [Serializable]
    public class TokenPayload
    {
        public string id;
        public uint iat;
        public uint exp;
    }
}
