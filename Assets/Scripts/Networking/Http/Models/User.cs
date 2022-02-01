// created by yasintuncel
using BattleTacticsOnline.Networking.Http.Models.UserSubModels;
using System;

namespace BattleTacticsOnline.Networking.Http.Models
{
    [Serializable]
    public class User
    {
        public string _id;
        public string nickName;
        public string uid;
        public string identicon;
        public long createdAt;

        public Activity activitiy;
        public Gold gold;
        public Level level;
    }
}
