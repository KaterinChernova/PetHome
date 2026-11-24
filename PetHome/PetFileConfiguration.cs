namespace PetHome;

public class PetFileConfigurationProvider(string filePath): ConfigurationProvider
{
    public override void Load()
    {
        // Читаем файлик
        
        // инициализируем прочитанное

        var key = "pet_home_setting";
        var value = "pet_home_setting_value";
        
        Data[key] = value;
    }
}

public sealed class PetFileConfigurationSource(string filePath) : IConfigurationSource
{
    public IConfigurationProvider Build(IConfigurationBuilder builder)
    {
        return new PetFileConfigurationProvider(filePath);
    }
}

public static class PetFileConfigurationExtensions
{
    public static IConfigurationBuilder AddPetFile(this IConfigurationBuilder builder, string filePath)
    {
        return builder.Add(new PetFileConfigurationSource(filePath));
    }
}