using System.Collections.Generic;

namespace Blink.Classes
{
    public class BaseData
    {
        public string Email;

        public string LoginTier;
        public string RegionTier;
        public string RegionDescription;
        public string AuthToken;
        public int AccountId;
        public int ClientId;
        public string VerificationPin;

        public string StoragePathNetwork;           // C:\Temp\Blink_XT2\Home
        public string StoragePathMain;              // C:\Temp\Blink_XT2\Home\Main
        public string StoragePathSnapshots;         // C:\Temp\Blink_XT2\Home\Snapshots
        public string StoragePathSnapshotsImages;   // C:\Temp\Blink_XT2\Home\Snapshots\Images
        public string StoragePathSnapshotsVideos;   // C:\Temp\Blink_XT2\Home\Snapshots\Videos   // ToDo: Info: Currently not used. But already added for further releases.

        public List<Network> Networks;
    
        public class Network
        {
            public int Id;
            public string Name;
            public List<Camera> Cameras;
        }

        public class Camera
        {
            public int Id;
            public string Name;
            public Media Media;
        }

        public class Media
        {
            public string PathAndFileNameThumbnail;
            public List<string> PathAndFileNameVideos;
        }
    }

    public class MinimumData
    {
        public string RegionTier;
        public string AuthToken;
        public int NetworkId;
        public int CameraId;
    }
}
