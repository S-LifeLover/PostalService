namespace PostalService.Engine.Configuration
{
    public interface IConfigurationProvider
    {
        int CustomerCreationDelay { get; }

        double PostmanSpeed { get; }

        int PostmansCount { get; }

        double WorldWidth { get; }

        double WorldHeight { get; }
    }
}