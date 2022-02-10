// created by yasintuncel
using System;

namespace BattleTacticsOnline.Networking.Http.Models.FriendModels
{
    [Serializable]
    public class FriendRequest
    {
        public FriendUser from;
        public long createdAt;
    }
}
