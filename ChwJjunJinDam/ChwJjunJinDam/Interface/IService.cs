using System.ServiceModel;

namespace ChwJjunJinDam.Interface
{
    [ServiceContract]
    public partial interface IService
    {

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
