// created by yasintuncel
using BattleTacticsOnline.Networking.Http.Infrastructure;
using System;
using System.Collections.Generic;

namespace BattleTacticsOnline.Networking.Http.Models
{
    [Serializable]
    public class HttpModel<T>
    {
        public string url;
        public Dictionary<string, string> postParams;
        public Dictionary<string, string> headerParams;
        public IRequest<T> iRequest;
    }
}
