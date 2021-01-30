namespace Blink.Classes
{
    public class Config
    {
        private const string AppName = "Blink Video Download";
        private const string AppVersion = "V. 0.14";

        public readonly static string TitleAppNameAndVersion = $"{AppName} {AppVersion}";
        public readonly static string TitleErrorAppNameAndVersion = $"{TitleAppNameAndVersion} - Error";

        // $"{DefaultRootStoragePart}\{StoragePartBase}\NetworkName  \{StoragePartBase}\Camera[0].Name\" ...
        //             C:\Temp       \Blink_XT2        \HomeSweetHome\Main             \Garage        \  ...
        public const string DefaultRootStoragePart = @"C:\Temp";
        public const string StoragePartBase = "Blink_XT2";
        public const string StoragePartMain = "Main";

        public const int IntervallMinimumTimeInSeconds = 30;
        public static readonly string IntervallErrorText = $"Notice: Min. time is {IntervallMinimumTimeInSeconds} seconds.";
        public const string StoragePartSnapshotsMain = "Snapshots";
        public const string StoragePartSnapshotsImages = "Images";
        public const string StoragePartSnapshotsVideos = "Videos";
        public const int DefaultSnapshots = 1200;
        public const int DefaultFrameRate = 30;
        public static string HintTextImagesFrameRateVideoLength = 
            "Example:\r\n" +
            "In case {imageCount} snapshots will be\r\n" +
            "taken and the frame rate was set\r\n" +
            "to {frameRate} fps the generated video are\r\n" +
            "going to have a length of\r\n" +
            "{imageCount} / {frameRate} = {divisionResult} seconds.\r\n";

        public const int VerifyPinLength = 6;
    }
}
