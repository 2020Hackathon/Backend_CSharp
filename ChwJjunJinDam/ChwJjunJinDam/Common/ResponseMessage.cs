namespace ChwJjunJinDam.Common
{
    public class ResponseMessage
    {
        public static string OK = "성공적으로 처리되었습니다.";
        public static string BAD_REQUEST = "검증 오류.";
        public static string UNAUTHORIZED = "아이디 또는 비밀번호를 확인하십시오.";
        public static string INTERNAL_SERVER_ERROR = "서버 오류.";
        public static string TOKEN_EXPIRATION = "토큰 만료.";
        public static string CREATED = "성공적으로 생성되었습니다.";
    }
}
