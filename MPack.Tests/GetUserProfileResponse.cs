using System;
using System.Collections.Generic;
using System.Text;

namespace MPack.Tests
{
    public class GetUserProfileResponse : ResponseBase
    {
        [Tag(30)]
        public List<CustomerInfo> Customers { get; set; }
        [Tag(31)]
        public CurrentUserInfo CurrentCustomer { get; set; }
    }

    public class CurrentUserInfo
    {
        [Tag(170)]
        public string Username { get; set; }
        [Tag(173)]
        public string title { get; set; }
    }

    public class CustomerInfo
    {
        [Tag(120)]
        public string Title { get; set; }
    }
}
