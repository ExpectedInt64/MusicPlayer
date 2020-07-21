using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WMPLib;

namespace MusicPlayer
{
    public partial class Form1 : Form
    {


        WindowsMediaPlayer player;
        public Form1()
        {
            int player_volume = 20;
            InitializeComponent();
            trackBar1.Maximum = 100;
            player = new WindowsMediaPlayer();
            player.PlayStateChange += new _WMPOCXEvents_PlayStateChangeEventHandler(player_PlayStateChange);
            player.settings.setMode("loop", true);
            trackBar1.TickFrequency = 5;
            trackBar1.LargeChange = 3;
            trackBar1.SmallChange = 1;
            trackBar1.Value = player_volume;
            player.settings.volume = player_volume;
            textBox_Volume.Text = "Volume: "+trackBar1.Value;
            textBox_nowPlaying.Text = "Nothing";


        }

        void player_PlayStateChange(int NewState)
        { if(NewState == 3)
            {
                timer1.Start();
            }
            else
            {
                timer1.Stop();
            }
            switch (NewState)
            {
                case 0:    // Undefined
                    textBox_Status.Text = "Undefined";
                    break;

                case 1:    // Stopped
                    textBox_Status.Text = "Stopped";
                    break;

                case 2:    // Paused
                    textBox_Status.Text = "Paused";
                    break;

                case 3:    // Playing
                    textBox_Status.Text = "Playing";
                    textBox_nowPlaying.Text = player.currentMedia.name;
                    break;

                case 4:    // ScanForward
                    textBox_Status.Text = "ScanForward";
                    break;

                case 5:    // ScanReverse
                    textBox_Status.Text = "ScanReverse";
                    break;

                case 6:    // Buffering
                    textBox_Status.Text = "Buffering";
                    break;

                case 7:    // Waiting
                    textBox_Status.Text = "Waiting";
                    break;

                case 8:    // MediaEnded
                    textBox_Status.Text = "MediaEnded";
                    break;

                case 9:    // Transitioning
                    textBox_Status.Text = "Transitioning";
                    break;

                case 10:   // Ready
                    textBox_Status.Text = "Ready";
                    break;

                case 11:   // Reconnecting
                    textBox_Status.Text = "Reconnecting";
                    break;

                case 12:   // Last
                    textBox_Status.Text = "Last";
                    break;

                default:
                    textBox_Status.Text = ("Unknown State: " + NewState.ToString());
                    break;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            player.controls.stop();
            player.currentPlaylist = InitializePlayList("combat");
            player.controls.play();
        }

        private IWMPPlaylist InitializePlayList(String type)
        {
            List<string> playListData = LoadMusic("combat");
            IWMPPlaylist playlist = player.playlistCollection.newPlaylist("combat");
            foreach (String file in playListData)
            {
                IWMPMedia fileMedia = player.newMedia(file);
                playlist.appendItem(fileMedia);
            }
            return playlist;
        }

        private static List<String> LoadMusic(String folder)
        {
            Random Rnd = new Random();
            //Tells the program, what extenstions are allowed in the string
            String[] AllowedExtensions = new String[]
            {
                ".mp3",
                ".wav",
                ".flac"
            };
            //Sets path, and gets all files, then adds them to a list
            String PathName = Environment.CurrentDirectory + @"\music\"+folder+@"\";
            DirectoryInfo d = new DirectoryInfo(PathName);
            FileInfo[] Files = d.GetFiles("*");
            List<String> List = new List<String>();

            //for loop, to count all the files in the folder
            for (int i = 0; i < Files.Length; i++)
            {
                //Sets all names to lower case, then checks if they're allowed (Extension)
                String ext = Files[i].Extension.ToLower();
                for (int j = 0; j < AllowedExtensions.Length; j++)
                {
                    //If the extension is allowed, it will add the file to a list
                    if (AllowedExtensions[j] == ext)
                    {
                        List.Add(PathName + Files[i].Name);
                        break;
                    }
                }
            }
            //Saves the array from before, under a name
            String[] StringList = List.ToArray<String>();

            //Throws a new exception if there are no images in the folder
            if (StringList.Length == 0) throw new Exception("No Music found in `./music/"+folder+"/` with the following extensions: " + String.Join(", ", AllowedExtensions) + ".");
            //Returns a random picture from the array - This is the image for the image box

            //return StringList[Rnd.Next(0, StringList.Length - 1)];
            return List;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            textBox_Volume.Text = "Volume: " + trackBar1.Value;
            player.settings.volume = trackBar1.Value;
        }

        private void button_Pause_Click(object sender, EventArgs e)
        {
            if(player.playState == WMPPlayState.wmppsPaused)
            {
                player.controls.play();
                button_Pause.Text = "Pause";
            }
            else
            {
                player.controls.pause();
                button_Pause.Text = "Resume";
            }
        }

        private void button_Prev_Click(object sender, EventArgs e)
        {
            player.controls.previous();
            player.controls.play();
        }

        private void button_Next_Click(object sender, EventArgs e)
        {
            player.controls.next();
            player.controls.play();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            double percent = 0;
            percent = ((double)player.controls.currentPosition / player.controls.currentItem.duration);
            progressBar1.Value = (int)(percent * progressBar1.Maximum);
        }


        private void progressBar1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (player.playState == WMPPlayState.wmppsReady || player.playState == WMPPlayState.wmppsPlaying || player.playState == WMPPlayState.wmppsPaused)
                {
                    updateTrackPosition(getRelativeMouse(e));
                }
            }
            
        }

        private void progressBar1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                updateTrackPosition(getRelativeMouse(e));
            }
        }
        private float getRelativeMouse(MouseEventArgs e)
        {
            // Get mouse position(x) minus the width of the progressbar (so beginning of the progressbar is mousepos = 0 //
            float absoluteMouse = (PointToClient(MousePosition).X - progressBar1.Bounds.X);
            // Calculate the factor for converting the position (progbarWidth/100) //
            float calcFactor = progressBar1.Width / (float)progressBar1.Maximum;
            // In the end convert the absolute mouse value to a relative mouse value by dividing the absolute mouse by the calcfactor //
            float relativeMouse = absoluteMouse / calcFactor;
            // Set the calculated relative value to the progressbar //
            
            return relativeMouse;
            
        }
        private float getMusicProgressBar1Pos(float relativeMouse)
        {
            return (relativeMouse / 100 * (float)player.controls.currentItem.duration);
        }
        private void updateTrackPosition(float relativeMouse)
        {
            progressBar1.Value = Convert.ToInt32(relativeMouse);
            player.controls.currentPosition = Convert.ToInt32(getMusicProgressBar1Pos(relativeMouse));
        }
    }

}
