// created by yasintuncel
using BattleTacticsOnline.Networking.Http.Models.UserSubModels;
using System;

namespace BattleTacticsOnline.Networking.Http.Models.FriendModels
{
    [Serializable]
    public class FriendUser
    {
        public string _id;
        public string nickName;
        public string identicon;

        public Activity activitiy;
        public Gold gold;
        public Level level;
    }
}
