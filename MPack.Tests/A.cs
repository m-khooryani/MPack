using System;
using System.Collections.Generic;

namespace MPack.Tests
{
    public class A
    {
        [Tag(250)]
        public List<B> List { get; set; }
        [Tag(251)]
        public int ZZ { get; set; }
    }

    public class B
    {
        [Tag(252)]
        public int X { get; set; }
        [Tag(253)]
        public string Y { get; set; }
    }

    public class C : B
    {
        [Tag(254)]
        public string Password { get; set; }
    }

    public class D : B
    {

    }


    public class RequestBase
    {
        [Tag(0)]
        public int MessageType { get; set; }
        [Tag(1)]
        public string Username { get; set; }
    }

    public class Request
    {
        [Tag(0)]
        public List<RequestBase> SubRequests { get; set; }
        [Tag(1)]
        public long MessageNumber { get; set; }
        [Tag(2)]
        public DateTime Date { get; set; }
        [Tag(3)]
        public string MobileNumber { get; set; }
        [Tag(4)]
        public string Username { get; set; }
    }
    public class LoginRequest : RequestBase
    {
        [Tag(31)]
        public string Password { get; set; }
    }
    public class GetUserProfileRequest : RequestBase
    {
    }
}
