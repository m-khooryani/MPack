using System.Collections.Generic;

namespace MPack.Tests
{
    class Response
    {
        [Tag(2)]
        public List<ResponseBase> SubResponses { get; set; }
    }
}
