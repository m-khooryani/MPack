using System.Collections;

namespace MPack
{
    internal interface IWrappedCollection : IList
    {
        object UnderlyingCollection { get; }
    }
}
