using ChwJjunJinDam.Results.MyPageResult;
using ChwJjunJinDam.Results.SchoolInfoResult;
using ChwJjunJinDam.Results.UserInfoResult;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Threading.Tasks;

namespace ChwJjunJinDam.Interface
{
    [ServiceContract]
    public partial interface IService
    {
        #region 마이페이지
        /// <summary>
        /// 유저 정보 조회 API
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
                   BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "/v1/mypage/basic/{id}")]
        Task<Response<UserInfoResult>> GetUserInfo(string id);

        /// <summary>
        /// 유저 정보 수정 API
        /// </summary>
        /// <param name="id"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json,
                   BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "/v1/mypage/basic")]
        //Task<Response> UpdateUserInfo(string id, string birth, string name, string phone_number, string userInfo);
        Task<Response> UpdateUserInfo(string id, string name, string userInfo);

        /// <summary>
        /// 작성 게시물 조회 API
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
                   BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "/v1/mypage/post/{id}")]
        Task<Response<PostResults>> GetPosts(string id);
        #endregion

        #region 학교 정보
        /// <summary>
        /// 학교 정보 조회 API
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
                   BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "/v1/school/basic/{id}")]
        Task<Response<SchoolInfoResult>> GetSchoolInformation(string id);
        #endregion
    }

    public class Response
    {
        public string message { get; set; }
        public int statusCode { get; set; }
    }

    public class Response<T>
    {
        public string message { get; set; }
        public int statusCode { get; set; }
        public T data { get; set; }

        //public Data<T> data { get; set; }
    }
}
