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

            DisableOrEnableAllTabPagesExceptTheFirst(false);
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

                DisableOrEnableAllTabPagesExceptTheFirst(false);
                ResetTabPage01Values();
                ResetTabPage99Values();
                // ToDo: Do NOT remove this "ToDo" line and add here a "ResetTabPage_xx_Values();" method call in case a new tabPage is added to "tabControl0"!

                var taskA = Task.Factory.StartNew(() =>
                {
                    BaseData = new InitAndDownload().Start(this, p0_txtBox_Email.Text, p0_txtBox_Password.Text, p0_txtBox_SaveDirectory.Text, p0_checkBox_AreYouInGermany.Checked);
                    if (BaseData == null)
                    {
                        return;
                    }
                    
                    if (!string.IsNullOrWhiteSpace(BaseData.RootStoragePath))
                    {
                        if (MessageBox.Show(
                                "Should the storage path be opened?",
                                Config.TitleAppNameAndVersion,
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                            == DialogResult.Yes)
                        {
                            Process.Start(BaseData.RootStoragePath);
                        }
                    }
                }).ContinueWith(result =>
                {
                    // Controls are handled here to avoid a "cross-thread" error.
                    // And: Except PageTab it must also be worked out in case "StartAsyny(...)" returned "null" in error case!
                    if (BaseData != null)
                    {
                        DisableOrEnableAllTabPagesExceptTheFirst(true);
                    }
                    p0_btn_Start.Enabled = true;
                    p0_btn_Start.Text = "Reset application";

                    SetTabPage01Values(BaseData);
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

                DisableOrEnableAllTabPagesExceptTheFirst(false);
                ResetTabPage01Values();
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

        private void DisableOrEnableAllTabPagesExceptTheFirst(bool enableThem)
        {
            for (int i = 1; i < tabControl0.TabPages.Count; i++)    // Note: starting by 1
            {
                ((Control)tabControl0.TabPages[i]).Enabled = enableThem;
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

        delegate void SetTextCallback(string message, bool append = true);
        public void SetLog(string message, bool append = true)
        {
            if (this.p0_txtBox_Info.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetLog);
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
                "The root directory part were everything will be stored.\r\n" +
                "\r\n" +
                "But pay attention:\r\n" +
                "Imagine you added your Blink system to your Wifi 'HomeSweetHome'\r\n" +
                "and you have three cameras named 'Front', 'Backyard' and 'Garage'.\r\n" +
                "\r\n" +
                $"Imagine furthermore you select here '{savePath}'.\r\n" +
                "\r\n" +
                "In this case are these directories created and used to store everything:\r\n" +
                $"\t1) {savePath}\\HomeSweetHome\\Backyard\r\n" +
                $"\t2) {savePath}\\HomeSweetHome\\Front\r\n" +
                $"\t3) {savePath}\\HomeSweetHome\\Garage\r\n";
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
            p1_txtBox_RootStoragePath.Text = baseData.RootStoragePath;

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

        #region tabPage99 - "Test A"
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
