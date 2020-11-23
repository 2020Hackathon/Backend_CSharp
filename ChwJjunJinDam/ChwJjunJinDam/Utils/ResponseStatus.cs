using System;
using System.Net;

namespace ChwJjunJinDam.Utils
{
    public class ResponseStatus
    {
        public static int SUCCESS = ConvertHttpStatusCodeToInt(HttpStatusCode.OK); // 200
        public static int FAILURE = ConvertHttpStatusCodeToInt(HttpStatusCode.BadRequest); // 400
        public static int UNAUTHORIZED = ConvertHttpStatusCodeToInt(HttpStatusCode.Unauthorized); // 401
        public static int FORBIDDEN = ConvertHttpStatusCodeToInt(HttpStatusCode.Forbidden); // 403
        public static int NOT_FOUND = ConvertHttpStatusCodeToInt(HttpStatusCode.NotFound); // 404
        public static int INTERNAL_ERROR = ConvertHttpStatusCodeToInt(HttpStatusCode.InternalServerError); // 500
        

        public static int ConvertHttpStatusCodeToInt(HttpStatusCode httpStatusCode)
        {
            return Convert.ToInt32(httpStatusCode);
        }
    }
}
