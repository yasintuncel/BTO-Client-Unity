// created by yasintuncel
using BattleTacticsOnline.Networking.Http.Models;
using UnityEngine;

namespace BattleTacticsOnline.Networking.Http.Infrastructure.Delegates
{
    public delegate void DUserLogin(User user);
    public delegate void DUserLogout();

    public interface IUserLogin
    {
        void OnUserLogin(User user);
        void OnUserLogout();
    }
}
