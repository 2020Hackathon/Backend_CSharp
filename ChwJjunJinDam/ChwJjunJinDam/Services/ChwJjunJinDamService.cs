using ChwJjunJinDam.Common;
using ChwJjunJinDam.DataBase;
using ChwJjunJinDam.Interface;
using ChwJjunJinDam.Models;
using ChwJjunJinDam.Results.MyPageResult;
using ChwJjunJinDam.Results.SchoolInfoResult;
using ChwJjunJinDam.Results.UserInfoResult;
using ChwJjunJinDam.Utils;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChwJjunJinDam.Services
{
    public partial class ChwJjunJinDamService : MySqlDBConnectionManager, IService
    {
        DBManager<UserModel> userInfoDBManager = new DBManager<UserModel>();
        DBManager<PostModel> postDBManager = new DBManager<PostModel>();
        DBManager<SchoolInfoModel> schoolInfoDBManager = new DBManager<SchoolInfoModel>();

        public delegate Response<UserInfoResult> GetUserInfoBadResponse(ConTextColor preColor, int statusCode, ConTextColor setColor, string msg);
        public delegate Response<PostResults> GetPostsBadResponse(ConTextColor preColor, int statusCode, ConTextColor setColor, string msg);
        public delegate Response<SchoolInfoResult> GetSchoolInfoBadResponse(ConTextColor preColor, int statusCode, ConTextColor setColor, string msg);

        public async Task<Response<UserInfoResult>> GetUserInfo(string id)
        {
            string apiName = "GET USER INFO";

            GetUserInfoBadResponse getUserInfoBadResponse = delegate (ConTextColor preColor, int statusCode, ConTextColor setColor, string msg)
            {
                UserModel tempModel = new UserModel();
                tempModel.birth = "";
                tempModel.name = "";
                tempModel.phone_number = "";
                tempModel.userInfo = "";
                ServiceManager.ShowRequestResult(apiName, preColor, statusCode, setColor);
                return new Response<UserInfoResult> { data = new UserInfoResult { user = tempModel }, message = msg, statusCode = statusCode };
            };

            if (id != null)
            {
                try
                {
                    UserModel user = new UserModel();

                    using (var db = GetConnection())
                    {
                        db.Open();

                        string selectSql = $@"
SELECT
    *
FROM
    user
WHERE 
    id = '{id}'
;";
                        user = await userInfoDBManager.GetSingleDataAsync(db, selectSql, "");

                        if (user != null)
                        {
                            ServiceManager.ShowRequestResult(apiName, ConTextColor.LIGHT_GREEN, ResponseStatus.SUCCESS, ConTextColor.WHITE);
                            return new Response<UserInfoResult> { data = new UserInfoResult { user = user }, message = ResponseMessage.OK, statusCode = ResponseStatus.SUCCESS };
                        }
                        else
                        {
                            return getUserInfoBadResponse(ConTextColor.RED, ResponseStatus.FAILURE, ConTextColor.WHITE, "해당 유저가 존재하지 않습니다.");
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(apiName + " ERROR : " + e.Message);
                    return getUserInfoBadResponse(ConTextColor.PURPLE, ResponseStatus.INTERNAL_ERROR, ConTextColor.WHITE, ResponseMessage.INTERNAL_ERROR);
                }
            }
            else
            {
                return getUserInfoBadResponse(ConTextColor.RED, ResponseStatus.FAILURE, ConTextColor.WHITE, ResponseMessage.BAD_REQUEST);
            }
        }

        public async Task<Response> UpdateUserInfo(string id, string birth, string name, string phone_number, string userInfo)
        {
            string apiName = "UPDATE USER INFO";

            //if (ComDef.jwtService.IsTokenValid(ServiceManager.GetHeaderValue(WebOperationContext.Current)))
            //{
                if (id != null && name != null && birth != null && phone_number != null && userInfo != null)
                {
                    try
                    {
                        using (var db = GetConnection())
                        {
                            db.Open();

                            var userModel = new UserModel();
                            userModel.name = name;
                            userModel.birth = birth;
                            userModel.phone_number = phone_number;
                            userModel.userInfo = userInfo;

                            string updateSql = $@"
UPDATE
    user
SET
    birth = '{birth}',
    name = '{name}',
    phone_number = '{phone_number}',
    userInfo = '{userInfo}'
WHERE
    id = '{id}';
";
                            if (await userInfoDBManager.UpdateAsync(db, updateSql, userModel) == QueryExecutionResult.SUCCESS)
                            {
                                return ServiceManager.Result(apiName, ResponseType.OK);
                            }
                            else
                            {
                                return ServiceManager.Result(apiName, ResponseType.BAD_REQUEST);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(apiName + " ERROR : " + e.Message);
                        return ServiceManager.Result(apiName, ResponseType.INTERNAL_ERROR);
                    }
                }
                else
                {
                    return ServiceManager.Result(apiName, ResponseType.BAD_REQUEST);
                }
            //}
            //else
            //{
            //    return ServiceManager.Result(apiName, ResponseType.BAD_REQUEST);
            //}
        }

        public async Task<Response<PostResults>> GetPosts(string id)
        {
            string apiName = "GET POSTS";

            GetPostsBadResponse getPostBadResponse = delegate (ConTextColor preColor, int statusCode, ConTextColor setColor, string msg)
            {
                List<PostModel> tempModel = new List<PostModel>();
                //tempModel.user_id = "";
                //tempModel.title = "";
                //tempModel.description = "";
                //tempModel.like = 0;
                //tempModel.postinfo = "";
                //tempModel.end_date = new DateTime(00, 00, 00);
                ServiceManager.ShowRequestResult(apiName, preColor, statusCode, setColor);
                return new Response<PostResults> { data = new PostResults { posts = tempModel }, message = msg, statusCode = statusCode };
            };

            if (id != null)
            {
                var postItems = new List<PostModel>();
                try
                {
                    using (var db = GetConnection())
                    {
                        db.Open();

                        string selectSql = $@"
SELECT
    *
FROM
    post
WHERE
    user_id = '{id}';
;";
                        postItems = await postDBManager.GetListAsync(db, selectSql, "");

                        if (postItems != null && postItems.Count > 0) 
                        {
                            ServiceManager.ShowRequestResult(apiName, ConTextColor.LIGHT_GREEN, ResponseStatus.SUCCESS, ConTextColor.WHITE);
                            return new Response<PostResults> { data = new PostResults { posts = postItems }, message = ResponseMessage.OK, statusCode = ResponseStatus.SUCCESS };
                        }
                        else
                        {
                            return getPostBadResponse(ConTextColor.RED, ResponseStatus.NOT_FOUND, ConTextColor.WHITE, "게시글이 존재하지 않습니다.");
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(apiName + " ERROR : " + e.Message);
                    return getPostBadResponse(ConTextColor.PURPLE, ResponseStatus.INTERNAL_ERROR, ConTextColor.WHITE, ResponseMessage.INTERNAL_ERROR);
                }
            }
            else
            {
                return getPostBadResponse(ConTextColor.RED, ResponseStatus.FAILURE, ConTextColor.WHITE, ResponseMessage.BAD_REQUEST);
            }
        }

        public async Task<Response<SchoolInfoResult>> GetSchoolInformation(string id)
        {
            string apiName = "GET SCHOOL INFORMATION";

            GetSchoolInfoBadResponse getSchoolInfoBadResponse = delegate (ConTextColor preColor, int statusCode, ConTextColor setColor, string msg)
            {
                SchoolInfoModel tempModel = new SchoolInfoModel();
                // tempModel.AA = "";

                ServiceManager.ShowRequestResult(apiName, preColor, statusCode, setColor);
                return new Response<SchoolInfoResult> { data = new SchoolInfoResult { schoolInfo = tempModel }, message = msg, statusCode = statusCode };
            };

            if (id != null)
            {
                var schoolInfoModel = new SchoolInfoModel();

                try
                {
                    using (var db = GetConnection())
                    {
                        db.Open();

                        string selectSql = @"
SELECT
    *
FROM
    school
;";
                        schoolInfoModel = await schoolInfoDBManager.GetSingleDataAsync(db, selectSql, "");

                        if (schoolInfoModel != null)
                        {
                            ServiceManager.ShowRequestResult(apiName, ConTextColor.LIGHT_GREEN, ResponseStatus.SUCCESS, ConTextColor.WHITE);
                            return new Response<SchoolInfoResult> { data = new SchoolInfoResult { schoolInfo = schoolInfoModel }, message = ResponseMessage.OK, statusCode = ResponseStatus.SUCCESS };
                        }
                        else
                        {
                            return getSchoolInfoBadResponse(ConTextColor.RED, ResponseStatus.NOT_FOUND, ConTextColor.WHITE, "해당 학교 정보가 존재하지 않습니다.");
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(apiName + " ERROR : " + e.Message);
                    return getSchoolInfoBadResponse(ConTextColor.PURPLE, ResponseStatus.INTERNAL_ERROR, ConTextColor.WHITE, ResponseMessage.INTERNAL_ERROR);
                }
            }
            else
            {
                return getSchoolInfoBadResponse(ConTextColor.RED, ResponseStatus.FAILURE, ConTextColor.WHITE, ResponseMessage.BAD_REQUEST);
            }
        }
    }
}
