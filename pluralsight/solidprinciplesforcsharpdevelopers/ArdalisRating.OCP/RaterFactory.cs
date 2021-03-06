namespace ArdalisRating.OCP
{
    public class RaterFactory
    {
        public IRater Create(RatingEngine engine, Policy policy) => policy.Type switch
        {
            PolicyType.Auto => new AutoPolicyRater(engine, engine.Logger),
            PolicyType.Land => new LandPolicyRater(engine, engine.Logger),
            _ => null
        };
    }
}
