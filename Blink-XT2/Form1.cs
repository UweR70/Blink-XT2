using Blink.Classes;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blink
{
    public partial class Form1 : Form
    {
        public BaseData BaseData;

        public bool IsDownloadRunning;
        public bool EmptyInfoText;

        public bool IsSnapshotRunning;
        public Snapshot SnapshotInstance;
        private decimal FrameRateOldValue;
        private bool FrameRateValueChangedViaClickOnControlUpButton;

        public class ComboboxItem
        {
            public string Text { get; set; }
            public int Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {   
            this.Text = Config.TitleAppNameAndVersion;
            IsDownloadRunning =  false;
            EmptyInfoText = true;
            p0_txtBox_SaveDirectory.Text = Config.DefaultRootStoragePart;
            p0_txtBox_Email.Focus();

            p2_numUpDown_Seconds.Value = Config.IntervallMinimumTimeInSeconds;
            IsSnapshotRunning = false;
            FrameRateOldValue = -1;
            FrameRateValueChangedViaClickOnControlUpButton = false;
            SnapshotInstance = new Snapshot();

            DisableOrEnableallTabPagesExceptTheGiven(false, 0);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            new Snapshot().StopTakingSnapshots();
        }

        #region tabPage0 - "Download And Init"
        private void p0_btn_SelectSavePath_Click(object sender, EventArgs e)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                if (string.IsNullOrEmpty(p0_txtBox_SaveDirectory.Text))
                {
                    folderBrowserDialog.SelectedPath = Config.DefaultRootStoragePart;
                }
                else
                {
                    folderBrowserDialog.SelectedPath = p0_txtBox_SaveDirectory.Text;
                }

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    p0_txtBox_SaveDirectory.Text = folderBrowserDialog.SelectedPath;
                    p0_txtBox_Info.Text = HelpSaveDirectory();
                }
            }
        }

        private void p0_btn_Start_Click(object sender, EventArgs e)
        {
            if (!IsDownloadRunning)
            {
                if (!AreAllNeededValuesGiven())
                {
                    return;
                }
                EmptyInfoText = false;
                p0_txtBox_Info.Text = string.Empty;
                p0_txtBox_Email.Enabled = p0_txtBox_Password.Enabled = p0_checkBox_AreYouInGermany.Enabled = p0_btn_SelectSavePath.Enabled = p0_btn_Start.Enabled = false;
                p0_btn_Start.Text = "Running ...";

                DisableOrEnableallTabPagesExceptTheGiven(false, 0);
                ResetTabPage01Values();
                ResetTabPage02Values();
                ResetTabPage99Values();
                // ToDo: Do NOT remove this "ToDo" line and add here a "ResetTabPage_xx_Values();" method call in case a new tabPage is added to "tabControl0"!

                var taskA = Task.Factory.StartNew(() =>
                {
                    BaseData = new InitAndDownload().Start(this, p0_txtBox_Email.Text, p0_txtBox_Password.Text, p0_txtBox_SaveDirectory.Text, p0_checkBox_AreYouInGermany.Checked);
                    if (BaseData == null)
                    {
                        return;
                    }
                    
                    if (!string.IsNullOrWhiteSpace(BaseData.StoragePathNetwork))
                    {
                        if (MessageBox.Show(
                                "Should the storage path be opened?",
                                Config.TitleAppNameAndVersion,
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                            == DialogResult.Yes)
                        {
                            Process.Start(BaseData.StoragePathMain);
                        }
                    }
                }).ContinueWith(result =>
                {
                    // Controls are handled here to avoid a "cross-thread" error.
                    // And: Except PageTab it must also be worked out in case "StartAsyny(...)" returned "null" in error case!
                    if (BaseData != null)
                    {
                        DisableOrEnableallTabPagesExceptTheGiven(true, 0);
                    }
                    p0_btn_Start.Enabled = true;
                    p0_btn_Start.Text = "Reset application";

                    SetTabPage01Values(BaseData);
                    SetTabPage02Values(BaseData);
                    SetTabPage99Values(BaseData);
                    // ToDo: Do NOT remove this "ToDo" line and add here a "SetTabPage_xx_Values(BaseData);" method call in case a new tabPage is added to "tabControl0"!
                }, TaskScheduler.FromCurrentSynchronizationContext());
                // Do NOT add here something like               
                //      var x = taskA.Result;
                // because this would block "taskA" ..
            }
            else
            {
                EmptyInfoText = true;
                p0_txtBox_Info.Text = HelpStart();
                p0_txtBox_Email.Enabled = p0_txtBox_Password.Enabled = p0_checkBox_AreYouInGermany.Enabled = p0_btn_SelectSavePath.Enabled = p0_btn_Start.Enabled = true;
                p0_btn_Start.Text = "Start";

                DisableOrEnableallTabPagesExceptTheGiven(false, 0);
                ResetTabPage01Values();
                ResetTabPage02Values();
                ResetTabPage99Values();
                // ToDo: Do NOT remove this "ToDo" line and add here a "ResetTabPage_xx_Values();" method call in case a new tabPage is added to "tabControl0"!
            }
            IsDownloadRunning = !IsDownloadRunning;
        }

        private void p0_btn_Start_MouseEnter(object sender, EventArgs e)
        {
            if (!IsDownloadRunning && EmptyInfoText)
            {
                p0_txtBox_Info.Text = HelpStart();
            }
        }

        private void p0_txtBox_Email_MouseEnter(object sender, EventArgs e)
        {
            if (!IsDownloadRunning)
            {
                p0_txtBox_Info.Text = HelpEmailAndPassword();
            }
        }

        private void p0_txtBox_Password_MouseEnter(object sender, EventArgs e)
        {
            if (!IsDownloadRunning)
            {
                p0_txtBox_Info.Text = HelpEmailAndPassword();
            }
        }

        private void p0_txtBox_SaveDirectory_MouseEnter(object sender, EventArgs e)
        {
            if (!IsDownloadRunning)
            {
                p0_txtBox_Info.Text = HelpSaveDirectory();
            }
        }

        private void p0_checkBox_AreYouInGermany_MouseEnter(object sender, EventArgs e)
        {
            if (!IsDownloadRunning)
            {
                p0_txtBox_Info.Text = HelpAreYouInGermany();
            }
        }

        private void XX_DisableOrEnableAllTabPagesExceptTheFirst(bool enableThem)
        {
            for (int i = 1; i < tabControl0.TabPages.Count; i++)    // Note: starting by 1
            {
                ((Control)tabControl0.TabPages[i]).Enabled = enableThem;
            }
        }

        private void DisableOrEnableallTabPagesExceptTheGiven(bool enableThem, int NumberOfTabPageThatShouldNotBeChanged)
        {
            for (int i = 0; i < tabControl0.TabPages.Count; i++)
            {
                if (i != NumberOfTabPageThatShouldNotBeChanged)
                {
                    ((Control)tabControl0.TabPages[i]).Enabled = enableThem;
                }
            }
        }

        private bool AreAllNeededValuesGiven()
        {
            if (string.IsNullOrEmpty(p0_txtBox_Email.Text))
            {
                MessageBox.Show(
                    $"Please provide your Blink log in email address.",
                    Config.TitleErrorAppNameAndVersion,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                p0_txtBox_Email.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(p0_txtBox_Password.Text))
            {
                MessageBox.Show(
                    $"Please provide your Blink log password.",
                    Config.TitleErrorAppNameAndVersion,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                p0_txtBox_Password.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(p0_txtBox_SaveDirectory.Text))
            {
                MessageBox.Show(
                    $"Please provide a valid path to store everything.",
                    Config.TitleErrorAppNameAndVersion,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                p0_btn_SelectSavePath.Focus();
                return false;
            }
            return true;
        }

        delegate void SetP0TxtBoxInfoTextCallback(string message, bool append = true);
        public void SetP0TxtBoxInfoText(string message, bool append = true)
        {
            if (this.p0_txtBox_Info.InvokeRequired)
            {
                var d = new SetP0TxtBoxInfoTextCallback(SetP0TxtBoxInfoText);
                this.Invoke(d, new object[] { message, append });
            }
            else
            {
                if (append)
                {
                    this.p0_txtBox_Info.Text += string.Format("{0}\t{1}\r\n", DateTime.Now, message);
                }
                else
                {
                    this.p0_txtBox_Info.Text = message;
                }
                p0_txtBox_Info.SelectionStart = p0_txtBox_Info.TextLength;
                p0_txtBox_Info.ScrollToCaret();
            }
        }

        public string GetLog()
        {
            return p0_txtBox_Info.Text;
        }

        private string HelpEmailAndPassword()
        {
            return "Fields 'Email:' and 'Password:'\r\n" +
                "\r\n" +
                "Please enter the email address and password\r\n" +
                "that you have selected when you 'activated' your Blink system.\r\n" +
                "\r\n" +
                "These are the same values ​​that you use\r\n" +
                "to log in to your Blink mobile application.\r\n";
        }

        private string HelpSaveDirectory()
        {
            var savePath = string.IsNullOrEmpty(p0_txtBox_SaveDirectory.Text) 
                                ? Config.DefaultRootStoragePart
                                : p0_txtBox_SaveDirectory.Text;

            return "Field 'Save directory:'\r\n" +
                "\r\n" +
                "The root directory part where the downloaded videos and thumbnails will be stored.\r\n" +
                "\r\n" +
                "But pay attention:\r\n" +
                "Imagine you added your Blink system to your Wifi 'HomeSweetHome'\r\n" +
                "and you have three cameras named 'Front', 'Backyard' and 'Garage'.\r\n" +
                "\r\n" +
                $"Imagine furthermore you selected here '{savePath}'.\r\n" +
                "\r\n" +
                "In this case are these directories created and used to store:\r\n" +
                $"\t1) {savePath}\\Blink_XT2\\HomeSweetHome\\Main\\Backyard\r\n" +
                $"\t2) {savePath}\\Blink_XT2\\HomeSweetHome\\Main\\Front\r\n" +
                $"\t3) {savePath}\\Blink_XT2\\HomeSweetHome\\Main\\Garage\r\n";
        }

        private string HelpAreYouInGermany()
        {
            return "Field 'Are you in Germany?'\r\n" +
                "\r\n" +
                "Check this in case you are in Germany, otherwise uncheck it.\r\n" +
                "\r\n" +
                "It is needed to chose the correct Blink server.\r\n" +
                "\r\n" +
                "On the other side:\r\n" +
                "In Germany it does not matter at all!?\r\n" +
                "It´s hard do develop software in case you do not have any official (API) documentation.";
        }

        private string HelpStart()
        {
            return "Button 'Start'\r\n" +
                "\r\n" +
                "Click this button to start the download try.\r\n" +
                "Same basic checks will be made whether everything needed is given.\r\n" +
                "\r\n" +
                "After a download, the application can be reset with this button.\r\n" +
                "\r\n" +
                "This gives you the opportunity to copy the here shown text output of the download\r\n" +
                "before it is overwritten by help texts (like this one).";
        }
        #endregion

        #region tabPage01 - "Init Summary"

        private void SetTabPage01Values(BaseData baseData)
        {
            if (baseData == null)
            {
                return;
            }
            p1_txtBox_Email.Text = baseData.Email;
            p1_txtBox_Region.Text = $"{baseData.RegionPropertyName} / {baseData.RegionValue}";
            p1_txtBox_AuthToken.Text = baseData.AuthToken;
            p1_txtBox_AccountId.Text = baseData.AccountId.ToString();
            p1_txtBox_RootStoragePath.Text = baseData.StoragePathNetwork;

            p1_comboBox_Networks.Items.Clear();
            p1_comboBox_Networks.Text = string.Empty;
            for (int i = 0; i < baseData.Networks.Count; i++)
            {
                p1_comboBox_Networks.Items.Add(new ComboboxItem
                {
                    Text = $"{BaseData.Networks[i].Name} ({BaseData.Networks[i].Id})",
                    Value = BaseData.Networks[i].Id
                });
            }

            p1_comboBox_Cameras.Items.Clear();
            p1_comboBox_Cameras.Text = string.Empty;
            p1_txtBox_PathAndFileNameThumbnail.Text = p1_txtBox_PathAndFileNameVideos.Text = string.Empty;

            p1_pictureBox1.Image = null;
        }

        private void ResetTabPage01Values()
        {
            p1_txtBox_Email.Text =
            p1_txtBox_Region.Text =
            p1_txtBox_AuthToken.Text =
            p1_txtBox_AccountId.Text =
            p1_txtBox_RootStoragePath.Text = string.Empty;

            p1_comboBox_Networks.Items.Clear();
            p1_comboBox_Networks.Text = string.Empty;

            p1_comboBox_Cameras.Items.Clear();
            p1_comboBox_Cameras.Text = string.Empty;

            p1_txtBox_PathAndFileNameThumbnail.Text = p1_txtBox_PathAndFileNameVideos.Text = string.Empty;

            p1_pictureBox1.Image = null;
        }

        private void p1_comboBox_Networks_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedObject = p1_comboBox_Networks.SelectedItem as ComboboxItem;
            if (selectedObject == null)
            {
                p1_comboBox_Cameras.Items.Clear();
                p1_comboBox_Cameras.Text = string.Empty;
                p1_txtBox_PathAndFileNameThumbnail.Text = p1_txtBox_PathAndFileNameVideos.Text = string.Empty;
                return;
            }
            var networkId = selectedObject.Value;

            var networkObject = BaseData.Networks.Where(x => x.Id == networkId).ToList();
            if (networkObject == null || networkObject.Count() != 1)
            {
                // Should never be true!
                return;
            }

            p1_comboBox_Cameras.Items.Clear();
            p1_comboBox_Cameras.Text = string.Empty;
            for (int i = 0; i < networkObject[0].Cameras.Count; i++)
            {
                p1_comboBox_Cameras.Items.Add(new ComboboxItem
                {
                    Text = $"{networkObject[0].Cameras[i].Name} ({networkObject[0].Cameras[i].Id})",
                    Value = networkObject[0].Cameras[i].Id
                });
            }
            
            p1_txtBox_PathAndFileNameThumbnail.Text = p1_txtBox_PathAndFileNameVideos.Text = string.Empty;

            p1_pictureBox1.Image = null;
        }

        private void p1_comboBox_Cameras_SelectedIndexChanged(object sender, EventArgs e)
        {
            /* Sure, the camera list could also be found via:
             *          BaseData.Networks[p2_comboBox_Networks.SelectedIndex].Cameras[p2_comboBox_Cameras.SelectedIndex]
             * but this works only as long as the order of the combo box items are not changed 
             * between 
             * assigning the values to the combo box
             * and
             * this event is fired!
             * 
             * But may be the order of the combo box items will be changed in a future release were they can be asc./desc. sorted.
             * Means I go the hard way and fetch the correct network and camerea id to get finally the correct camera object.
             * See the five commented lines of code below! 
             *      var testId = ...
             */

            // Network
            var networkSelectedIndex = p1_comboBox_Networks.SelectedIndex;
            var networkComboBoxItem = p1_comboBox_Networks.Items[networkSelectedIndex] as ComboboxItem;
            if (networkComboBoxItem == null)
            {
                return;
            }
            var networkId = networkComboBoxItem.Value;

            var networkObject = BaseData.Networks.Where(x => x.Id == networkId).ToList();
            if (networkObject == null || networkObject.Count() != 1)
            {
                // Should never be true!
                return;
            }

            // Camera
            var selectedObject = p1_comboBox_Cameras.SelectedItem as ComboboxItem;
            if (selectedObject == null)
            {
                p1_txtBox_PathAndFileNameThumbnail.Text = p1_txtBox_PathAndFileNameVideos.Text = string.Empty;
                return;
            }
            var cameraId = selectedObject.Value;

            var cameraObject = networkObject[0].Cameras.Where(x => x.Id == cameraId).ToList();
            if (cameraObject == null || cameraObject.Count() != 1)
            {
                // Should never be true!
                return;
            }

            //var testId = BaseData.Networks[p2_comboBox_Networks.SelectedIndex].Cameras[p2_comboBox_Cameras.SelectedIndex].Id;
            //if (cameraObject[0].Id != testId)
            //{
            //    throw new Exception("mmmhhh ...");
            //}

            p1_txtBox_PathAndFileNameThumbnail.Text = cameraObject[0].Media.PathAndFileNameThumbnail;
            p1_txtBox_PathAndFileNameVideos.Text = string.Empty;
            if (cameraObject[0].Media.PathAndFileNameVideos.Count == 0)
            {
                p1_txtBox_PathAndFileNameVideos.Text = "<currently none>";
            }
            else
            {
                for (int i = 0; i < cameraObject[0].Media.PathAndFileNameVideos.Count; i++)
                {
                    p1_txtBox_PathAndFileNameVideos.Text += $"{cameraObject[0].Media.PathAndFileNameVideos[i]}\r\n";
                }
            }

            p1_pictureBox1.Image = Image.FromFile(cameraObject[0].Media.PathAndFileNameThumbnail);
        }
        #endregion

        #region tabPage02 - "Snapshots"
        private void SetTabPage02Values(BaseData baseData, bool emptyAlsoInfo = true)
        {
            if (baseData == null)
            {
                return;
            }
            p2_txtBox_Email.Text = baseData.Email;
            p2_txtBox_Region.Text = $"{baseData.RegionPropertyName} / {baseData.RegionValue}";
            p2_txtBox_AuthToken.Text = baseData.AuthToken;
            p2_txtBox_AccountId.Text = baseData.AccountId.ToString();
            p2_txtBox_RootStoragePath.Text = baseData.StoragePathNetwork;

            p2_comboBox_Networks.Items.Clear();
            p2_comboBox_Networks.Text = string.Empty;
            for (int i = 0; i < baseData.Networks.Count; i++)
            {
                p2_comboBox_Networks.Items.Add(new ComboboxItem
                {
                    Text = $"{BaseData.Networks[i].Name} ({BaseData.Networks[i].Id})",
                    Value = BaseData.Networks[i].Id
                });
            }

            p2_comboBox_Cameras.Items.Clear();
            p2_comboBox_Cameras.Text = string.Empty;

            p2_numUpDown_Days.Value = p2_numUpDown_Hours.Value = p2_numUpDown_Minutes.Value = 0;
            p2_numUpDown_Seconds.Value = Config.IntervallMinimumTimeInSeconds;

            p2_checkBox_CreateVideo.Checked = true;
            p2_numericUpDown_FrameRate.Value = Config.DefaultFrameRate;
            DisplayHintTextImagesFrameRateVideoLength(Config.DefaultSnapshots, Config.DefaultFrameRate);   // Default values!

            p2_btn_Start.Text = "Start";
            if (emptyAlsoInfo)
            {
                p2_txtBox_Info.Text = string.Empty;
            } else
            {
                SetP2TxtBoxInfoText(string.Empty);
                SetP2TxtBoxInfoText("All page fields except this textbox were reset.");
            }
        }
                
        private void ResetTabPage02Values()
        {
            p2_txtBox_Email.Text =
            p2_txtBox_Region.Text =
            p2_txtBox_AuthToken.Text =
            p2_txtBox_AccountId.Text =
            p2_txtBox_RootStoragePath.Text = string.Empty;

            p2_comboBox_Networks.Items.Clear();
            p2_comboBox_Networks.Text = string.Empty;

            p2_comboBox_Cameras.Items.Clear();
            p2_comboBox_Cameras.Text = string.Empty;

            p2_numUpDown_Days.Value = p2_numUpDown_Hours.Value = p2_numUpDown_Minutes.Value = 0;
            p2_numUpDown_Seconds.Value = Config.IntervallMinimumTimeInSeconds;

            p2_checkBox_CreateVideo.Checked = true;
            p2_numericUpDown_FrameRate.Value = Config.DefaultFrameRate;
            DisplayHintTextImagesFrameRateVideoLength(Config.DefaultSnapshots, Config.DefaultFrameRate);   // Default values!

            p2_btn_Start.Text = "Start";
            p2_txtBox_Info.Text = string.Empty;
        }

        private void p2_comboBox_Networks_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedObject = p2_comboBox_Networks.SelectedItem as ComboboxItem;
            if (selectedObject == null)
            {
                p2_comboBox_Cameras.Items.Clear();
                p2_comboBox_Cameras.Text = string.Empty;
                
                return;
            }
            var networkId = selectedObject.Value;

            var networkObject = BaseData.Networks.Where(x => x.Id == networkId).ToList();
            if (networkObject == null || networkObject.Count() != 1)
            {
                // Should never be true!
                return;
            }

            p2_comboBox_Cameras.Items.Clear();
            p2_comboBox_Cameras.Text = string.Empty;
            for (int i = 0; i < networkObject[0].Cameras.Count; i++)
            {
                p2_comboBox_Cameras.Items.Add(new ComboboxItem
                {
                    Text = $"{networkObject[0].Cameras[i].Name} ({networkObject[0].Cameras[i].Id})",
                    Value = networkObject[0].Cameras[i].Id
                });
            }
        }

        private decimal GetIntervallInSeconds()
        {
            return p2_numUpDown_Days.Value * 86400 +
                p2_numUpDown_Hours.Value * 3600 +
                p2_numUpDown_Minutes.Value * 60 + 
                p2_numUpDown_Seconds.Value;
        }

        private void DisplayCurrentInterval()
        {
            var intervalInSeconds = (int)GetIntervallInSeconds();
            if (intervalInSeconds < Config.IntervallMinimumTimeInSeconds)
            {
                p2_lbl_SelectedInterval.Text = Config.IntervallErrorText;
            }
            else
            {
                p2_lbl_SelectedInterval.Text = $"Take a snapshot every {intervalInSeconds:N0} seconds.";
            }
        }

        private void p2_numUpDown_Days_ValueChanged(object sender, EventArgs e)
        {
            DisplayCurrentInterval();
        }

        private void p2_numUpDown_Hours_ValueChanged(object sender, EventArgs e)
        {
            DisplayCurrentInterval();
        }

        private void p2_numUpDown_Minutes_ValueChanged(object sender, EventArgs e)
        {
            DisplayCurrentInterval();
        }
        private void p2_numUpDown_Seconds_ValueChanged(object sender, EventArgs e)
        {
            DisplayCurrentInterval();
        }

        private void p2_checkBox_CreateVideo_CheckedChanged(object sender, EventArgs e)
        {
            if (p2_checkBox_CreateVideo.Checked)
            {
                p2_numericUpDown_FrameRate.Enabled = true;
                DisplayHintTextImagesFrameRateVideoLength(Config.DefaultSnapshots, (int)p2_numericUpDown_FrameRate.Value);
            }
            else
            {
                p2_numericUpDown_FrameRate.Enabled = false;
                p2_numericUpDown_FrameRate.Value = Config.DefaultFrameRate;
                DisplayHintTextImagesFrameRateVideoLength(Config.DefaultSnapshots, Config.DefaultFrameRate);   // Default values!
            }
        }

        private void p2_numericUpDown_FrameRate_KeyUp(object sender, KeyEventArgs e)
        {
           FrameRateValueChangedViaClickOnControlUpButton = false;
        }
        
        private void p2_numericUpDown_FrameRate_ValueChanged(object sender, EventArgs e)
        {
            if (FrameRateValueChangedViaClickOnControlUpButton 
                && p2_numericUpDown_FrameRate.Value != p2_numericUpDown_FrameRate.Minimum
                && p2_numericUpDown_FrameRate.Value % p2_numericUpDown_FrameRate.Increment != 0)
            {
                var x = (int)(p2_numericUpDown_FrameRate.Value / p2_numericUpDown_FrameRate.Increment);
                if (FrameRateOldValue > p2_numericUpDown_FrameRate.Value)
                {
                    // value decreased
                    p2_numericUpDown_FrameRate.Value = (x + 1) * p2_numericUpDown_FrameRate.Increment;
                } else if (FrameRateOldValue < p2_numericUpDown_FrameRate.Value)
                {
                    // Value increased
                    p2_numericUpDown_FrameRate.Value = x * p2_numericUpDown_FrameRate.Increment;
                }
            }

            FrameRateOldValue = p2_numericUpDown_FrameRate.Value;
            FrameRateValueChangedViaClickOnControlUpButton = true;

            DisplayHintTextImagesFrameRateVideoLength(Config.DefaultSnapshots, (int)p2_numericUpDown_FrameRate.Value);
        }

        private void DisplayHintTextImagesFrameRateVideoLength(int imageCount, int frameRate)
        {
            var divisionResult = (double)imageCount / frameRate;
            p2_lbl_ImagesFrameRateVideoLength.Text = Config.HintTextImagesFrameRateVideoLength
                .Replace("{imageCount}", imageCount.ToString("N0"))
                .Replace("{frameRate}", frameRate.ToString(""))
                .Replace("{divisionResult}", divisionResult.ToString("0.00"));
        }

        private void p2_btn_Start_Click(object sender, EventArgs e)
        {
            if (!IsSnapshotRunning)
            {
                if (!AreAllSnapshotValuesGiven())
                {
                    return;
                }
                p2_txtBox_Info.Text = string.Empty;
                p2_comboBox_Networks.Enabled = p2_comboBox_Cameras.Enabled = p2_numUpDown_Days.Enabled = p2_numUpDown_Hours.Enabled = p2_numUpDown_Minutes.Enabled = p2_numUpDown_Seconds.Enabled = false;
                p2_btn_Start.Text = "Running ...";

                DisableOrEnableallTabPagesExceptTheGiven(false, 2);

                var intervalInSeconds = (int)GetIntervallInSeconds();

                var networkSelectedIndex = p2_comboBox_Networks.SelectedIndex;
                var networkComboBoxItem = p2_comboBox_Networks.Items[networkSelectedIndex] as ComboboxItem;
                if (networkComboBoxItem == null)
                {
                    return;
                }
                var networkId = networkComboBoxItem.Value;

                var cameraSelectedIndex = p2_comboBox_Cameras.SelectedIndex;
                var cameraComboBoxItem = p2_comboBox_Cameras.Items[cameraSelectedIndex] as ComboboxItem;
                if (cameraComboBoxItem == null)
                {
                    return;
                }
                var cameraId = cameraComboBoxItem.Value;

                SnapshotInstance.StartTakingSnapshots(this, BaseData, intervalInSeconds, networkId, cameraId);
            }
            else
            {
                SnapshotInstance.StopTakingSnapshots();

                if (p2_checkBox_CreateVideo.Checked)
                {
                    new ImageToVideo().Convert(this, 
                        SnapshotInstance.BaseStoragePathSnapshot,
                        (int)p2_numericUpDown_FrameRate.Value
                    );
                }

                SetTabPage02Values(BaseData, false);

                p2_comboBox_Networks.Enabled = p2_comboBox_Cameras.Enabled = p2_numUpDown_Days.Enabled = p2_numUpDown_Hours.Enabled = p2_numUpDown_Minutes.Enabled = p2_numUpDown_Seconds.Enabled = true;
                p2_btn_Start.Text = "Start";

                DisableOrEnableallTabPagesExceptTheGiven(true, -1); // "-1" is a non-extsing tabPage, means all tabPages will be changed.

                if (MessageBox.Show(
                               "Should the image snaphot storage path be opened?",
                               Config.TitleAppNameAndVersion,
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                           == DialogResult.Yes)
                {
                    Process.Start(SnapshotInstance.BaseStoragePathSnapshot);    // Set while "SnapshotInstance.StartTakingSnapshots(...)" where worked out.
                }
            }
            IsSnapshotRunning = !IsSnapshotRunning;
        }

        private bool AreAllSnapshotValuesGiven()
        {
            if(p2_comboBox_Networks.SelectedIndex == -1)
            {
                MessageBox.Show(
                   $"Please select a network.",
                   Config.TitleErrorAppNameAndVersion,
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error
                );
                p2_comboBox_Networks.Focus();
                return false;
            }

            if (p2_comboBox_Cameras.SelectedIndex == -1)
            {
                MessageBox.Show(
                   $"Please select a camera.",
                   Config.TitleErrorAppNameAndVersion,
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error
                );
                p2_comboBox_Cameras.Focus();
                return false;
            }

            var intervalInSeconds = (int)GetIntervallInSeconds();
            if (intervalInSeconds < Config.IntervallMinimumTimeInSeconds)
            {
                MessageBox.Show(
                  $"Please provide an interval of minumum {Config.IntervallMinimumTimeInSeconds} seconds.",
                  Config.TitleErrorAppNameAndVersion,
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Error
                );
                p2_numUpDown_Days.Focus();
                return false;
            }
            return true;
        }

        delegate void SetP2TxtBoxInfoTextCallback(string message, bool append = true);
        public void SetP2TxtBoxInfoText(string message, bool append = true)
        {
            if (this.p0_txtBox_Info.InvokeRequired)
            {
                var d = new SetP2TxtBoxInfoTextCallback(SetP2TxtBoxInfoText);
                this.Invoke(d, new object[] { message, append });
            }
            else
            {
                if (append)
                {
                    this.p2_txtBox_Info.Text += string.Format("{0}\t{1}\r\n", DateTime.Now, message);
                }
                else
                {
                    this.p2_txtBox_Info.Text = message;
                }
                p2_txtBox_Info.SelectionStart = p2_txtBox_Info.TextLength;
                p2_txtBox_Info.ScrollToCaret();
            }
        }
        #endregion

        #region tabPage99 - "Quciktest"
        private void SetTabPage99Values(BaseData baseData)
        {
            if (baseData == null)
            {
                return;
            }
            p99_txtBox_Info.Text = baseData.Email;  // Just a dummy value. 
        }

        private void ResetTabPage99Values()
        {
            p99_txtBox_Info.Text = string.Empty;
        }

        private void p99_btn_Start_Click(object sender, EventArgs e)
        {
            var taskA = Task.Factory.StartNew(() =>
            {
                new Quicktest().Test(this, BaseData);
            }).ContinueWith(result =>
            {
                // Currently nothing to do here
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
        #endregion
    }
}
