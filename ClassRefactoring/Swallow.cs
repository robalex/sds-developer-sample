
namespace DeveloperSample.ClassRefactoring
{
    public abstract class Swallow
    {
        public SwallowType Type { get; }
        public SwallowLoad Load { get; private set; }

        public abstract double GetAirspeedVelocity();

        public void ApplyLoad(SwallowLoad load)
        {
            Load = load;
        }
    }
}
