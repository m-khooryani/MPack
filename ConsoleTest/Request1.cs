using System.Collections.Generic;

namespace ConsoleTest
{
    public class Request1
    {
        public List<BaseRequest> SubRequests { get; set; }
        public int MessageNumber { get; set; }
        public int Timestamp { get; set; }
        public string MobileNumber { get; set; }
        public string Username { get; set; }
    }
}
