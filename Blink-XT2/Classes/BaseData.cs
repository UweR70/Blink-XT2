using System.Collections.Generic;

namespace Blink.Classes
{
    public class BaseData
    {
        public string Email;

        public string ApiServer;
        public string RegionPropertyName;
        public string RegionValue;
        public string AuthToken;
        public int AccountId;     

        public string RootStoragePath;

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
        public string ApiServer;
        public string RegionPropertyName;
        public string AuthToken;
        public int NetworkId;
        public int CameraId;
    }
}
