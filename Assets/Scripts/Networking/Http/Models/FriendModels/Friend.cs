// created by yasintuncel
using System;

namespace BattleTacticsOnline.Networking.Http.Models.FriendModels
{
    [Serializable]
    public class Friend
    {
        public FriendUser user;
        public int playCount;
        public long createdAt;
    }
}
