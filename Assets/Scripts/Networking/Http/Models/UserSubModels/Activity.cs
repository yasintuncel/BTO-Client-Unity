// created by yasintuncel
using System;

namespace BattleTacticsOnline.Networking.Http.Models.UserSubModels
{
    [Serializable]
    public class Activity
    {
        public bool isOnline;
        public int lastActiveAt;
        public bool isInGame;
        public string gameId;
    }
}
