using ChwJjunJinDam.JWT.Models;
using Solomon_Server.JWT.Services;

namespace ChwJjunJinDam.Common
{
    public class ComDef
    {
        public static JWTContainerModel jWTContainerModel = new JWTContainerModel();
        public static JWTService jwtService = new JWTService(jWTContainerModel.SecretKey);
    }
}
