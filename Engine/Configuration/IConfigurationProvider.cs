namespace PostalService.Engine.Configuration
{
    // ToDO: сделать интернал
    public interface IConfigurationProvider
    {
        int CustomerCreationDelay { get; }

        double PostmanSpeed { get; }

        int PostmansCount { get; }

        double WorldWidth { get; }

        double WorldHeight { get; }

        int FPS { get; }
    }
}