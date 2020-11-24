using ChwJjunJinDam.Common;
using ChwJjunJinDam.Interface;
using ChwJjunJinDam.Utils;
using System;
using System.ServiceModel.Web;

namespace ChwJjunJinDam
{
    public enum ResponseType
    {
        OK,
        BAD_REQUEST,
        INTERNAL_ERROR,
        CREATED
    }

    public class ServiceManager
    {
        public delegate Response RequestResult(string apiName, ResponseType type);
        public static RequestResult Result = delegate (string apiName, ResponseType type)
        {
            switch (type)
            {
                case ResponseType.OK:
                    ShowRequestResult(apiName, ConTextColor.LIGHT_GREEN, ResponseStatus.SUCCESS, ConTextColor.WHITE);
                    return new Response { message = ResponseMessage.OK, statusCode = ResponseStatus.SUCCESS };
                case ResponseType.BAD_REQUEST:
                    ShowRequestResult(apiName, ConTextColor.RED, ResponseStatus.FAILURE, ConTextColor.WHITE);
                    return new Response { message = ResponseMessage.BAD_REQUEST, statusCode = ResponseStatus.FAILURE }; ;
                case ResponseType.INTERNAL_ERROR:
                    ShowRequestResult(apiName, ConTextColor.PURPLE, ResponseStatus.INTERNAL_ERROR, ConTextColor.WHITE);
                    return new Response { message = ResponseMessage.INTERNAL_ERROR, statusCode = ResponseStatus.INTERNAL_ERROR };
                default:
                    return null;
            }
        };

        /// <summary>
        /// Get Header's Token
        /// </summary>
        /// <param name="webOperationContext"></param>
        /// <returns></returns>
        public static string GetHeaderValue(WebOperationContext webOperationContext)
        {
            string requestHeaderValue = webOperationContext.IncomingRequest.Headers["token"].ToString();
            if (webOperationContext.IncomingRequest.Headers != null && requestHeaderValue != null)
            {
                return requestHeaderValue;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// Request Time Log
        /// </summary>
        /// <returns></returns>
        public static string CheckRequestTime()
        {
            DateTime time = DateTime.Now;
            string msg = string.Empty;
            msg += "[";
            msg += time.Year.ToString() + "년 ";
            msg += time.Month.ToString() + "월 ";
            msg += time.Day.ToString() + "일 ";
            msg += time.Hour.ToString() + "시 ";
            msg += time.Minute.ToString() + "분 ";
            msg += time.Second.ToString() + "초 ";
            msg += "] ";
            return msg;
        }

        /// <summary>
        /// Request Log
        /// </summary>
        /// <param name="apiName"></param>
        /// <param name="preColor"></param>
        /// <param name="statusCode"></param>
        /// <param name="setColor"></param>
        public static void ShowRequestResult(string apiName, ConTextColor preColor, int statusCode, ConTextColor setColor)
        {
            Console.Write(CheckRequestTime() + $"{apiName} responded ");
            WrapAPI.SetConsoleTextColor(preColor);
            Console.WriteLine(statusCode);
            WrapAPI.SetConsoleTextColor(setColor);
        }
    }
}
