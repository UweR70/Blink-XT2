using Accord.Video.FFMPEG;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

/*  ATTENTION:
    - This functionality needs thess three NuGet packages:
        - Accord
        - Accord.Video
        - Accord.Video.FFMPEG
   
     - Follow these steps to add all three at once:
        - Select 'References' in the 'Blink-XT2' project.
        - Right mouse click -> Select 'Manage NuGet Packages ...' in the context menu.
        - A new window/tab should be opened in Visual Studio: 'NuGet: Blink-XT2'.
        - Select 'Browse' and enter 
            Accord.Video.FFMPEG
          in the 'Search' field.
        - Select the searched package and click the "Install" button.
          All three packages will be installed due the fact that 
            Accord.Video.FFMPEG
          requires the other two packages.
        - Rebuild the solution.
        - Done! 
*/

namespace Blink.Classes
{
    public class ImageToVideo
    {
        public void Convert(Form1 form, string pathToTheImages, int frameRate)
        {
            // Example: 1,200 images with frameRate equal to 30 -> 1,200 / 30 => Video length will be exact 40 seconds.

            var minWidth = int.MaxValue;
            var minHeight = int.MaxValue;

            var directoryInfo = new DirectoryInfo(pathToTheImages);
            var images = directoryInfo.GetFiles("*.jpg");

            var videoFileName = $"_{images.Length}_ImagesToOneVideo__{directoryInfo.Name}.avi";

            var divisionResult = (double)images.Length / frameRate;
            form.SetP2TxtBoxInfoText($"Start to convert {images.Length} images to one video!");
            form.SetP2TxtBoxInfoText($"File name will be {videoFileName}");
            form.SetP2TxtBoxInfoText(string.Empty);
            form.SetP2TxtBoxInfoText($"Info:");
            form.SetP2TxtBoxInfoText($"\tBased on the given frame rate of {frameRate} fps and {images.Length} found images");
            form.SetP2TxtBoxInfoText($"\twill the video be have a length of around ({images.Length} / {frameRate} =) {divisionResult:N2} seconds.");
            form.SetP2TxtBoxInfoText(string.Empty);
            form.SetP2TxtBoxInfoText("Searching for the smallest image dimensions ...");
            //will the video be have a length of 35 seconds

            for (int i = 0; i < images.Length; i++)
            {
                using (var oneBitmap = new Bitmap(images[i].FullName))
                {
                    if (oneBitmap.Width < minWidth)
                    {
                        minWidth = oneBitmap.Width;
                    }
                    if (oneBitmap.Height < minHeight)
                    {
                        minHeight = oneBitmap.Height;
                    }
                }
            }
            form.SetP2TxtBoxInfoText($"Smallest dimension: Width: {minWidth}, Height: {minHeight}.");
            form.SetP2TxtBoxInfoText(string.Empty);
            form.SetP2TxtBoxInfoText("Any to the video added image will be resized to this dimension - if necessary.");
            form.SetP2TxtBoxInfoText("Start to create video ... Be patient. This will take its time!");

            var pathAndFileNameNewVideo = Path.Combine(pathToTheImages, videoFileName);
            using (var vFWriter = new VideoFileWriter())
            {
                vFWriter.Open(pathAndFileNameNewVideo, minWidth, minHeight, frameRate, VideoCodec.MPEG2);

                for (int i = 0; i < images.Length; i++)
                {
                    using (var oneBitmap = new Bitmap(images[i].FullName))
                    {
                        if (oneBitmap.Width != minWidth || oneBitmap.Height != minHeight)
                        {
                            vFWriter.WriteVideoFrame(ReduceBitmap(oneBitmap, minWidth, minHeight));
                        }
                        else
                        {
                            vFWriter.WriteVideoFrame(oneBitmap);
                        }
                    }
                }
                vFWriter.Close();
            }
            form.SetP2TxtBoxInfoText("Video successful created and in the image folder stored!");
        }

        public Bitmap ReduceBitmap(Bitmap original, int reduceToThisWidth, int reduceToThisHeight)
        {
            var ret = new Bitmap(reduceToThisWidth, reduceToThisHeight);
            using (var graphics = Graphics.FromImage(ret))
            {
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.DrawImage(
                    original, 
                    new Rectangle(0, 0, reduceToThisWidth, reduceToThisHeight), 
                    new Rectangle(0, 0, original.Width, original.Height), 
                    GraphicsUnit.Pixel
                );
            }
            return ret;
        }
    }
}
