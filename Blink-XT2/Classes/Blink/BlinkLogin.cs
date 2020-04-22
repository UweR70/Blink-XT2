namespace Blink.Classes.Blink
{
    public class BlinkLogin
    {   
        public Account account { get; set; }
        public Client client { get; set; }
        public Authtoken authtoken { get; set; }
        public Networks networks { get; set; }
        public Region region { get; set; }

        public class Account
        {
            public int id { get; set; }
            public bool email_verified { get; set; }
            public bool email_verification_required { get; set; }
        }

        public class Client
        {
            public int id { get; set; }
        }

        public class Authtoken
        {
            public string authtoken { get; set; }
            public string message { get; set; }
        }

        public class Networks
        {
            public _55520 _55520 { get; set; }
        }

        public class _55520
        {
            public string name { get; set; }
            public bool onboarded { get; set; }
        }

        /*  Why sooooo long comments?
         *  Because the code works fine for me in Germany and Mid April 2020.
         *  In your region could it be that the region code is different.
         *  And this can cause errors while you are trying to log in!
         *  
         *  Due the fact that there is (currently) no official API documentation
         *  I could not know how YOUR region call looks like.
         *  
         *  But I can describe in very deep details how I came to these classes.
         *  And this gives you the possibility to adjust the code!
         *  What means finally adding a property to this class ;-)
         *  
         *  
         *  
         *  
         *  
         *  Add this code
         *  
         *      var uri = $"https://rest.{baseData.RegionPropertyName}.immedia-semi.com/regions";
         *      var regionsString = await common.MakeGetCall(uri, baseData.AuthToken, baseData.ApiServer); 
         *      
         *  Make a breakpoint after 'var regionsString = ...'.
         *  Fire this code.
         *  Copy the 'regionString' value in to the clipboard when the breakpoint is hit.
         *  Stop the debugger.
         *  Add a new class 'BlinkRegions_TEST.cs' in the 'Classes' directory.
         *  Place the cursor inbetween the inner curly braces
         *  
         *          ...
         *          namespace Blink.Classes
         *          {
         *              class BlinkRegions_TEST 
         *              { 
         *                  ... place the cursor here ...
         *              }
         *          }
         *          
         *  Select in Visual Studio (2017) "File" -> "Special Paste" -> 'Paste JSON as Classes'
         *  After Visual Studio generated the new class remove the 'wrapping' Rootobject (because it is not needed).
         *  But do NOT remove the inside the Rootobject wrapped properties!
         *  
         *  PART A:
         *  Take a look at the other classes that Visual Studio added to "BlinkRegions_TEST.cs".
         *  It should look like these 
         *      public class E002
         *      public class Usu017
         *      public class Usu013       
         *      public class Sg     
         *      public class Usu012
         *  Add these public class names here in this class as property in lower letters (as long as they arent already added).
         *
         *  PART B:
         *  You have now a class "BlinkRegions_TEST.cs" which can be used to instantiate the value of the variable "regionsString".
         *  So add now the last/third line of code:
         *  
         *      var uri = $"https://rest.{baseData.RegionPropertyName}.immedia-semi.com/regions";
         *      var regionsString = await common.MakeGetCall(uri, baseData.AuthToken, baseData.ApiServer); 
         *      var regions = JsonConvert.DeserializeObject<BlinkRegions>(regionsString);
         *      
         *  Set now a breakpoint after "var regions = ...".
         *  Fire the code.
         *  The variable "regions" should now have two properties:
         *          regions.preferred
         *          regions.regions
         *  And:
         *          regions.regions
         *  has five properties:
         *      1.) regions.regions.E002
         *      2.) regions.regions.Sg
         *      3.) regions.regions.Usu012
         *      4.) regions.regions.Usu013
         *      5.) regions.regions.Usu017
         *  EACH of them have a property called "dns", like:
         *      1.) regions.regions.E002.dns
         *      2.) regions.regions.Sg.dns
         *      3.) regions.regions.Usu012.dns
         *      4.) regions.regions.Usu013.dns
         *      5.) regions.regions.Usu017.dns
         *  Take each of these values and add the values here in this class as property in lower letters (as long as they arent already added).
         *   
         *   
         *  These apis call are returning "Unautorized Access".
         *  So we can assume that the regions "prsg", "u012", "u013" and u017" are working!
         *      https://rest.e001.immedia-semi.com/api/v1/camera/usage
         *      https://rest.prsg.immedia-semi.com/api/v1/camera/usage
         *      https://rest.u012.immedia-semi.com/api/v1/camera/usage
         *      https://rest.u013.immedia-semi.com/api/v1/camera/usage
         *      https://rest.u017.immedia-semi.com/api/v1/camera/usage
         *  while these are NOT working
         *      https://rest.e002.immedia-semi.com/api/v1/camera/usage
         *      https://rest.sg.immedia-semi.com/api/v1/camera/usage
         *      https://rest.usu012.immedia-semi.com/api/v1/camera/usage
         *      https://rest.usu013.immedia-semi.com/api/v1/camera/usage
         *      https://rest.usu017.immedia-semi.com/api/v1/camera/usage
         *      
         *  Conclusion:
         *  PART A must not be made!
        */

        public class Region
        {
            // This property was in Germany, Mid April 2020, returned after a login API call was fired. So I added it!
            public string e001 { get; set; }

            //// From Part A:
            // public string e002 { get; set; }
            // public string sg { get; set; }
            // public string usu012 { get; set; }
            // public string usu013 { get; set; }
            // public string usu017 { get; set; }

            // From Part B:
            public string prsg { get; set; }
            public string u012 { get; set; }
            public string u013 { get; set; }
            public string u017 { get; set; }
        }
    }
}
