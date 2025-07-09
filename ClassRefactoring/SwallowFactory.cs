using System;

namespace DeveloperSample.ClassRefactoring
{
    public class SwallowFactory
    {
        public Swallow GetSwallow(SwallowType swallowType)
        {
            switch (swallowType)
            {
                case SwallowType.European:
                    return new EuropeanSwallow();
                case SwallowType.African:
                    return new AfricanSwallow();
                default:
                    throw new ArgumentException("Invalid swallowType");
            }
        }
    }
}
