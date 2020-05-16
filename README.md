# Blink-XT2
Blink (XT2) Win 10 / C # application that still works after the last Blink changes of May 11, 2020.<br>
<br>
Keyfeatures:
<ul>
<li> <!-- ##### Open  ##### -->
This app is capable of 
<ul>
  <li>
    download all videos and the thumbnails from each camera of all networks.
  </li>
  <li>
    deleting all downloaded videos on Blinks server on user request.
  </li>
  <li>
    take a snapshot/thumbnail every x seconds and <b>to create a video from these.</b> 
  </li>
</ul>
<br>
</li><!-- ##### Close ##### -->
<li> <!-- ##### Open  ##### -->
The most important API calls are fully developed and ready to use. Out-of-the box!<br>
Like:
<ul>
  <li>
    Take a snapshot (thumbnail) / download it.
  </li>
  <li>
    Record a video / download videos.
  </li>
  <li>
    Arm / disarm a complete (Blink) network.
  </li>
  <li>
    Enable / disable motion detection per camera.
  </li>
  <li>
    etc.    
  </li>
</ul>
<br>
</li><!-- ##### Close ##### -->
<li> <!-- ##### Open  ##### -->
Demo implementations like the following are available; see <a href="https://github.com/UweR70/Blink-XT2/blob/master/Blink-XT2/Classes/Quicktest.cs" target="_blank">Quicktest.cs</a>.
<pre><code>
...
var commandArm = uweR70_Command.CommandArmDisarmAsync(minData, UweR70_Command.ArmDisarm.arm).Result;
var commandDisarm = uweR70_Command.CommandArmDisarmAsync(minData, UweR70_Command.ArmDisarm.disarm).Result;
<br>
var commandMotionDetectionEnable = uweR70_Command.CommandMotionDetectionAsync(minData, UweR70_Command.MotionDetection.enable).Result;
var commandMotionDetectionDisable = uweR70_Command.CommandMotionDetectionAsync(minData, UweR70_Command.MotionDetection.disable).Result;
<br>
var commandClip = uweR70_Command.CommandClipAsync(minData).Result;
var commandThumbnail = uweR70_Command.CommandThumbnailAsync(minData).Result;
<br>
var login = uweR70_Get.LoginAsync(baseData, new UweR70_Get.LoginBody
{
    email = "&lt;your blink email address&gt;",
    password = "&lt;your blink password&gt;"
}).Result;
<br>
var network = uweR70_Get.BatteryUssageAsync(baseData).Result;
var thumbnailImage = uweR70_Get.ThumbnailImageAsync(minData, "&lt;enter valid data here&gt;").Result;
var video = uweR70_Get.VideoAsync(baseData, "&lt;enter valid data here&gt;").Result;
var changedMedia = uweR70_Get.ChangedMediaAsync(baseData, 0).Result;
<br>        
var cameraStatus = uweR70_Get.CameraStatusAsync(minData).Result;
var signalStrength = uweR70_Get.SignalStrengthAsync(minData).Result;
<br>
var events = uweR70_Get.EventsAsync(minData).Result;
var typeList = new[] { "first_boot", "battery", "armed", "disarmed", "scheduled_arm", "scheduled_disarm", "heartbeat", "sm_offline" };
var blinkEvents = events._event;
var count = blinkEvents.Length;
for (int i = 0; i < typeList.Length; i++)
{
    blinkEvents = blinkEvents.Where(x => !x.type.Equals(typeList[i], StringComparison.InvariantCultureIgnoreCase)).ToArray();
    count = blinkEvents.Length;
}
<br>
var homescreenV3 = uweR70_Get.HomescreenV3Async(baseData).Result;
var quickRegionInfo = uweR70_Get.QuickRegionInfoAsync(baseData).Result;
var syncModules = uweR70_Get.SyncModulesAsync(minData).Result;
...
</code></pre>
<br>
</li><!-- ##### Close ##### -->
<li> <!-- ##### Open  ##### -->
Furthermore it contains a "documentation" class providing <a href="https://github.com/UweR70/Blink-XT2/wiki/All-original-Blink-URIs">all original API calls</a><br>
(incl. the therefore needed URLs) of the <a href="https://play.google.com/store/apps/details?id=com.immediasemi.android.blink&gl=US"> original Blink mobile phone app</a>.<br>
<br>
Script kiddies will love it.<br>
<br>
Login example as follows because it is most requested:<br>
<pre><code>
...
@POST("https://rest-{tier}.immedia-semi.com/api/v4/account/login")
Observable<LoginResponse> login(@Body LoginBody paramLoginBody, @Path("tier") String paramString);
<br>
@POST("https://rest-{tier}.immedia-semi.com/api/v4/account/login")
Call<LoginResponse> loginCall(@Body LoginBody paramLoginBody, @Path("tier") String paramString);
...
</code></pre>
<br>
</li><!-- ##### Close ##### -->
<li> <!-- ##### Open  ##### -->
My wiki contains a 
<a href="https://github.com/UweR70/Blink-XT2/wiki/Tutorial:-How-to-decompile-an-apk%3Fi" target="_blank">Tutorial: How to decompile an apk?</a><br>
This tutorial demonstrates step-by-step how to get the original Blink mobile phone app <b>code</b> - which also contains the API calls mentioned above.<br>
<br>
</li><!-- ##### Close ##### -->
</ul>

# Dependencies
<ul>
  <li>
    Newtonsoft.Json,<br>
    Accord, Accord.Video, Accord.Video.FFMPEG
  </li>
  <li>
    .NET Framework 4.8
  </li>
</ul>

# How to install, compile and run
Good news first:<br>
<a href="https://github.com/UweR70/Blink-XT2/blob/master/Blink-XT2/Compiled_Versions/UweR70_Blink-XT2_V_0.12.7z" target="_blank">Here</a><br>
you will find a ziped but runable setup.exe (version 0.12).<br>
<br>
The bad news:<br>
Sorry, figured currently not out how to add these packages to the repository:<br>
<ul>
  <li>
    'Newtonsoft.Json'
  </li>
  <li>
    'Accord', 'Accord.Video', 'Accord.Video.FFMPEG'
  </li>
</ul>
Shame on me ...<br>
Follow these steps to fix this (in Visual Studio):
<ul>
  <li>
    Download the repository as zip file and unzip it.
  </li>
  <li>
    Start Visual Studio (2017) and open the project (file 'Blink-XT2.sln').<br>
    A rebuild at this point will not work due the missing NuGet packages.
  </li>
  <li>
    Select 'Solution Explorer'.
  </li>
  <li>
    Select 'References' in the 'Blink-XT2' project.
  </li>
  <li>
    Right mouse click -> Select 'Manage NuGet Packages ...' in the context menu.
  </li>
  <li>
    A new window/tab should be opened in Visual Studio: 'NuGet: Blink-XT2'.
  </li>
  <li>
    This window/tab contains top most a yellow part that says:<br>
    "Some NuGet packages are missing from this solution. Click to restore from your online packages sources."<br>
    There is also a button called "Restore".
  </li>
  <li>
    Click this button.
  </li>
  <li>
    Make sure the required '.NET Framework 4.8' is installed.
  </li>
  <li>
    Rebuild the solution.
  </li>
  <li>
    Done!
  </li>
  </ul>

# Remarks
<ul>
  <li>
    This is my very first try to handle Blink XT2.<br>
    -> Optimizations and additional functionality may follow later.<br>
    <br>
  </li>
  <li>
    There is no official Blink (XT2) API.<br>
    -> So it is difficult to impossible to say whether I am using the right (API) calls or have misunderstood something completely.<br>
    <br>
  </li>
  <li>
    I own only one Blink XT2 system with three cameras and I am located in Germany.<br>
    -> So, I have no clue whether my app will work outside Germany/Europe.<br>
    <br>
  </li>
  <li>
    While 'InitAndDownload.cs' (<a href="https://github.com/UweR70/Blink-XT2/blob/master/Blink-XT2/Classes/InitAndDownload.cs" target="_blank">link</a>) contains the fully developed functionality to login and download all videos and thumbnails<br>
    for all networks, is 'Quicktest.cs' (<a href="https://github.com/UweR70/Blink-XT2/blob/master/Blink-XT2/Classes/Quicktest.cs" target="_blank">link</a>) meant as demonstration how to use/feed the API calls.<br> 
    <br>
    The tabPage 'InitSummary' <i>plays</i> a little bit with the gathered login, network, camera, video and thumbnail data.<br>
    <br>
    The old-school Windows Form application is just a wrapper that gives you a user-friendly way to supply<br>
    the main logic with all required values.<br>
    It contains also some 'Task.Factory...' handling to make everything smooth and non-blocking/non-leaking.<br>
    <br>
  </li>
  <li>
    The form ('Form1.cs [Design]') contains a 'tabControl' control.<br>
    Meant to give you the opportunity to add your own new functionality in a new 'tabPage'.<br>
    <br>
    Everything you need is provided in a well set instance of the class 'BaseData'.<br>
    <br>
    Advise:<br>
    Search in 'Form1.cs' for ...
    <pre><code>
    // ToDo: Do NOT remove this "ToDo" line and add here a "SetTabPage_xx_Values(BaseData);" method call in case a new tabPage is added to "tabControl0"!
    </code></pre>
    ... or simply check Visual Studios "Task List" to get an idea how<br>
    to integrate and handle your new tabPage in the existing code well.<br>
    <br>
  </li>
  <li>
    How do I get the 'Classes.Blink.<i>xxy</i>.cs' classes (<a href="https://github.com/UweR70/Blink-XT2/tree/master/Blink-XT2/Classes/Blink" target="_blank">link</a>)<br>
    like 'Classes.Blink.CameraStatus.cs', 'Classes.Blink.HomescreenV3', etc.?<br>
    <br>
    Example:<br>
    Open 'Classes.Blink.UweR70_Get.cs' (<a href="https://github.com/UweR70/Blink-XT2/blob/master/Blink-XT2/Classes/UweR70_Get.cs"  target="_blank">link</a>) and serach for the method 'LoginAsync(...)' ... <br>
    <pre><code>
    public async Task&lt;LoginResponse&gt; LoginAsync(BaseData baseData, LoginBody loginBody)
    {
        //  @POST("https://rest-{tier}.immedia-semi.com/api/v4/account/login")
        //   Observable<LoginResponse> login(@Body LoginBody paramLoginBody, @Path("tier") String paramString);
        //
        //  @POST("https://rest-{tier}.immedia-semi.com/api/v4/account/login")
        //  Call<LoginResponse> loginCall(@Body LoginBody paramLoginBody, @Path("tier") String paramString);
        var uri = $"https://rest-{baseData.ApiServer}.immedia-semi.com/api/v4/account/login";
        var retString = await FirePostCallAsync(uri, loginBody);
        var ret = JsonConvert.DeserializeObject&lt;LoginResponse&gt;(retString);
        return ret;
     }
    </code></pre>
    ... and set a breakpoint in this line:<br>
    <pre><code>
    var ret = JsonConvert.DeserializeObject&lt;LoginResponse&gt;(retString);
    </code></pre>
    Start debugging / run the code.<br>
    Copy the 'retString' value in to the clipboard when the breakpoint is hit.<br>
    <br>
    But double check that the copied value is <b>not</b> wrapped in quotation marks!<br>
    looks good:<br>
    &nbsp;&nbsp;&nbsp;{"account":{"id": ... "region":{"e001":"Europe"}}<br>
    looks bad:<br>
    &nbsp;&nbsp;&nbsp;"{"account":{"id": ... "region":{"e001":"Europe"}}"<br>
    <br>
    Stop the debugger.<br>
    Add a new class 'BlinkTest.cs' in the 'Classes' directory.<br>
    Place the cursor inbetween the inner curly braces
    <pre><code>
    ...
    namespace Blink.Classes
    {
       class BlinkTest 
       { 
           ... place the cursor here ...
       }
    }
    </code></pre>
    Select in Visual Studio (2017) "Edit" -> "Special Paste" -> 'Paste JSON as Classes'<br>
    After Visual Studio generated and added the new class remove the 'wrapping' Rootobject.<br>
    But of course do not remove the properties.<br>
    Done.<br>
    The class can than be used to deserialize the 'retString' as shown above.<br>
    <br>
  </li>
</ul>

# Last but not least
Enjoy.
