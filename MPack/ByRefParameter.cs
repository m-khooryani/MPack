using System.Linq.Expressions;

namespace MPack
{
    internal class ByRefParameter
    {
        public Expression Value;
        public ParameterExpression Variable;
        public bool IsOut;
    }
}
