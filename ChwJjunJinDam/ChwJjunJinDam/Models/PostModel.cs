using System;

namespace ChwJjunJinDam.Models
{
    public class PostModel
    {
        public string user_id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int like { get; set; }
        public string postinfo { get; set; }
        public DateTime end_date { get; set; }
    }
}
