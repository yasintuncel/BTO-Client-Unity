// created by yasintuncel
namespace BattleTacticsOnline.Networking.Http
{
    public static class HttpConstants
    {
        public const string HOST_LOCAL = "localhost";

        public const string HOST = HOST_LOCAL;
        
        public const string PORT = "27027";
        public const string URL = "http://" + HOST + ":" + PORT;
        
        public const string REGISTER_KEY = "registerkey";
        public const string REGISTER_KEY_VALUE = "QJ_pAYL9hhtP2iY_4z566zfj1sMCN328";

        public const string TOKEN_KEY = "tokenkey";
        public const string TOKEN_KEY_VALUE = "B6v82Z9jgw6AH16_7kc1gx2CKIiFSm";

        public const string AUTH_KEY = "x-access-token";
        
        public const string REGISTER_AS_GUEST = URL + "/register" + "/guest";
        
        public const string USER_INFORMATION = URL + "/api" + "/user";

        public const string TOKEN_REFRESH = URL + "/token" + "/refresh";
        
        public const string IDENTICONS = URL + "/images/identicons";
    }
}
