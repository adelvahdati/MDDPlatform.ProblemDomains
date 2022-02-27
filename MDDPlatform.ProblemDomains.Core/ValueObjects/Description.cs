using MDDPlatform.SharedKernel.ValueObjects;

namespace MDDPlatform.ProblemDomains.ValueObjects {
    public class Description : OptionalString
    {
        public Description(string? value) : base(value)
        {
        }
    }
}