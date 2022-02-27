using MDDPlatform.SharedKernel.ValueObjects;

namespace MDDPlatform.ProblemDomains.ValueObjects {
    public class Title : NotEmptyString
    {
        public Title(string value) : base(value)
        {
            
        }
    }
}