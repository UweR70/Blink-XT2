namespace Blink.Classes
{
    public class Config
    {
        private const string AppName = "Blink Video Download";
        private const string AppVersion = "V. 0.02";

        public readonly static string TitleAppNameAndVersion = $"{AppName} {AppVersion}";
        public readonly static string TitleErrorAppNameAndVersion = $"{TitleAppNameAndVersion} - Error";

        // $"{DefaultRootStoragePart}\{StoragePart}\NetworkName\Camera[0].Name\" ...
        //             C:\Temp       \ Blink_XT2   \HomeSweetHome\Garage      \  ...
        public const string DefaultRootStoragePart = @"C:\Temp";
        public const string StoragePart = "Blink_XT2";
    }
}
