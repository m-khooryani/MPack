using MPack;
using System;
using System.Collections.Generic;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {

            LoginRequestDto loginRequestDto = new LoginRequestDto()
            {
                MessageType = 1,
                DeviceMessageNumber = 1000,
                Date = new DateTime(2002, 6, 30),
                DeviceMobileNumber = "989191740647",
                Username = "legalTest1",
                Password = "123456",
            };

            byte[] bytes = Parser.Serialize(loginRequestDto);

        }
    }

    class LoginRequestDto
    {
        [Tag(0)]
        public int MessageType { get; set; }
        [Tag(1)]
        public long DeviceMessageNumber { get; set; }
        [Tag(2)]
        public DateTime Date { get; set; }
        [Tag(3)]
        public string DeviceMobileNumber { get; set; }
        [Tag(30)]
        public string Username { get; set; }
        [Tag(31)]
        public string Password { get; set; }
    }
}
