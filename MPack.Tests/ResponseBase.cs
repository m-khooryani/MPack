namespace MPack.Tests
{
    public class ResponseBase
    {
        [Tag(210)]
        public bool IsSuccessful { get; set; }
        [Tag(211)]
        [Ignore]
        public int ErrorCode { get; set; }
    }
}
