using MDDPlatform.SharedKernel.ValueObjects;

namespace MDDPlatform.ProblemDomains.ValueObjects{
    public class Name : NotEmptyString
    {
        public Name(string value) : base(value)
        {
        }
    }
}