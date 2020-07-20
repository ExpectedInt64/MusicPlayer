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


        WindowsMediaPlayer Player = new WindowsMediaPlayer();
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Player.controls.stop();
            Player.currentPlaylist = InitializePlayList("combat");
            Player.controls.play();
        }

        private IWMPPlaylist InitializePlayList(String type)
        {
            List<string> playListData = LoadMusic("combat");
            IWMPPlaylist playlist = Player.playlistCollection.newPlaylist("combat");
            foreach (String file in playListData)
            {
                IWMPMedia fileMedia = Player.newMedia(file);
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
                ".wav"
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
    }

}
