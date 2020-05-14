using Blink.Classes.Blink;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Blink.Classes
{
    public class StoreIt
    {
        //                                                 C:\Temp                         \Blink_XT2                \__DataStorage
        private static readonly string PathDataStorage = $"{Config.DefaultRootStoragePart}\\{Config.StoragePartBase}\\__DataStorage";

        private const string FileNameMainDataStorage = @"Blink_XT2_MainData.txt";
        private static readonly string PathAndFileNameMainDataStorage = $"{PathDataStorage}\\{FileNameMainDataStorage}";

        private const string FileNameAuthTokenStorage = @"Blink_XT2_AuthToken.txt";
        private static readonly string PathAndFileNameAuthTokenStorage = $"{PathDataStorage}\\{FileNameAuthTokenStorage}";

        public class MainData
        {
            public DateTime TimestampLastWritten;
            public string RegionTier;
            public string RegionDescription;
            public int AccountId;
            public List<Network> Networks;
        }

        public class Network
        {
            public string Name;
            public int Id;
            public List<Camera> Cameras;
        }

        public class Camera
        {
            public string Name;
            public int Id;
        }

        public class AuthToken
        {
            public DateTime TimestampTokenCreated;
            public string Token;
        }

        public void StoreData(BaseData baseData, BatteryUsage blinkNetwork)
        {
            WriteMainData(baseData, blinkNetwork);
            var currentData = ReadMainData();

            WriteAuthToken(baseData);
            var authTokenList = ReadAuthToken();
        }

        public void WriteMainData(BaseData baseData, BatteryUsage blinkNetwork)
        {
            if (!Directory.Exists(PathDataStorage))
            {
                Directory.CreateDirectory(PathDataStorage);
            }

            var currentData = new MainData
            {
                RegionTier = baseData.RegionTier,
                RegionDescription = baseData.RegionDescription,
                AccountId = baseData.AccountId,
                Networks = new List<Network>()
            };

            for (int i = 0; i < blinkNetwork.networks.Length; i++)
            {
                var cameras = new List<Camera>();
                for (int n = 0; n < blinkNetwork.networks[i].cameras.Length; n++)
                {
                    cameras.Add(new Camera
                    {
                        Name = blinkNetwork.networks[i].cameras[n].name,
                        Id = blinkNetwork.networks[i].cameras[n].id
                    });
                }

                currentData.Networks.Add(new Network
                {
                    Name = blinkNetwork.networks[i].name,
                    Id = blinkNetwork.networks[i].network_id,
                    Cameras = cameras
                });
            }

            currentData.TimestampLastWritten = DateTime.Now;
            var currentDataAsString = JsonConvert.SerializeObject(currentData);
            File.WriteAllText(PathAndFileNameMainDataStorage, currentDataAsString);
        }

        public MainData ReadMainData()
        {
            if (!File.Exists(PathAndFileNameMainDataStorage))
            {
                return null;
            }
            var fileContent = File.ReadAllText(PathAndFileNameMainDataStorage);
            var ret = JsonConvert.DeserializeObject<MainData>(fileContent);
            return ret;
        }

        public void WriteAuthToken(BaseData baseData)
        {
            if (!Directory.Exists(PathDataStorage))
            {
                Directory.CreateDirectory(PathDataStorage);
            }

            var alreadyStoredAuthTokenList = ReadAuthToken();
            if (alreadyStoredAuthTokenList == null)
            {
                alreadyStoredAuthTokenList = new List<AuthToken>();
            }
            else if (alreadyStoredAuthTokenList.Any(x => x.Token.Equals(baseData.AuthToken)))
            {
                return;
            }

            alreadyStoredAuthTokenList.Add(new AuthToken
            {
                TimestampTokenCreated = DateTime.Now,
                Token = baseData.AuthToken
            });
            var currentDataAsString = JsonConvert.SerializeObject(alreadyStoredAuthTokenList);
            File.WriteAllText(PathAndFileNameAuthTokenStorage, currentDataAsString);
        }

        public List<AuthToken> ReadAuthToken()
        {
            if (!File.Exists(PathAndFileNameAuthTokenStorage))
            {
                return null;
            }
            var fileContent = File.ReadAllText(PathAndFileNameAuthTokenStorage);
            var ret = JsonConvert.DeserializeObject<List<AuthToken>>(fileContent);
            return ret;
        }
    }
}
