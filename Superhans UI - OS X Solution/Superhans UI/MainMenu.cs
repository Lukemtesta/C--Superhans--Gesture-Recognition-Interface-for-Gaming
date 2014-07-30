using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Timers;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Collections;


/*

Copyright (c) 2014 Luke Marcus Biagio Testa
All rights reserved.

Redistribution and use in source and binary forms are permitted
provided that the above copyright notice and this paragraph are
duplicated in all such forms and that any documentation,
advertising materials, and other materials related to such
distribution and use acknowledge that the software was developed
by the Luke Marcus Biagio Testa. The name of the
Luke Marcus Biagio Testa may not be used to endorse or promote products derived
from this software without specific prior written permission.
THIS SOFTWARE IS PROVIDED ``AS IS'' AND WITHOUT ANY EXPRESS OR
IMPLIED WARRANTIES, INCLUDING, WITHOUT LIMITATION, THE IMPLIED
WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE.
 * 
 */


namespace WindowsFormsApplication1
{
    public partial class MainMenu : Form
    {
        //---------------- Variables ---------------

        public static System.Timers.Timer MainMenuAnimationTimer;

        string rootDirectory;

        const int NoPictureBox = 8;
        static int FPS = 17;
        static float timerAnimation;

        CalibrationForm CalibrationWindow;
        ExistingGames ExistingGamesWindow;

        List<ImageGroup> imageGroupList = new List<ImageGroup>();

        ImageGroup displayFunc;
        Matrix Mat;
        Animation animate;

        public MainMenu()
        {
            InitializeComponent();

            // Initialize Matrix Class
            Mat = new Matrix();

            // Initialize Image Group class
            displayFunc = new ImageGroup(this);

            // Initialize Animation Class
            //animate = new Animation(this);

            // Setup Animation Timers
            SetupTimerMenuAnimation();

            // Initialize Animation Timers
            timerAnimation = 0;

            // Render Menu. Initially in MainMenu.
            rootDirectory = displayFunc.texturePath + @"/MainMenu/";
            Console.WriteLine(rootDirectory);

            displayFunc.ReadTexturesFromFile("texture", 0);
            displayFunc.RenderFile();

            // Trigger Form Shown
            //Shown += Form1_Shown;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            // On MainMenu render, do translate animation

            //MenuAnimation(800);
        }


        //--------------------------- Timer Methods ----------------------

        void RotationYAnimation(MainMenu GUI, int timer, string pictureBox, string directoryName, int subDir)
        {
             RotationYAnimation(GUI, timer, pictureBox, directoryName, subDir, 1, "texture");

             
        }
        
        void RotationYAnimation(MainMenu GUI, int timer, string pictureBox, string directoryName, int subDir, int Prepare, string filename)
        {
            Point[] P = new Point[NoPictureBox];

            timerAnimation = 0;

            if (timerAnimation == 0)
            {
                for (int i = 0; i < NoPictureBox; i++)
                    P[i] = GUI.Controls.Find(pictureBox, true)[0].Location;
            }


            MainMenuAnimationTimer.Enabled = true;

            // Compute rand()
            /*Random rand = new Random();

            double rotationDirection = rand.Next(0, 2);

            if (rotationDirection == 0)
                rotationDirection = -1;*/

            //Size initialSize = GUI.Controls.Find(pictureBox, true)[0].Size;
            //Size pointSize = GUI.Controls.Find(pictureBox, true)[0].Size;
            //Point pointLocation = GUI.Controls.Find(pictureBox, true)[0].Location;

           /* Point CoM = new Point( ( (pointSize.Width/2) + pointLocation.X) , ( (pointSize.Height/2) + pointLocation.Y) );

            double locationDelta = (CoM.X - pointLocation.X) / (timer / 17);
            int sizeDelta = pointSize.Width / (timer / 17);*/

           /* while (  pointSize.Width > 0 )
            {                
                pointSize.Width -= sizeDelta;
                pointLocation.X += (int)locationDelta;

                GUI.Invoke((Action)(() => { GUI.Controls.Find(pictureBox, true)[0].Location = pointLocation; }));
                GUI.Invoke((Action)(() => { GUI.Controls.Find(pictureBox, true)[0].Size = pointSize; }));
*/
                GUI.Invoke((Action)(() => { GUI.Refresh(); }));
                GUI.Invoke((Action)(() => { GUI.Update(); }));
        //    }

            if(Prepare == 1)
                PrepareRender(directoryName, subDir, filename);

            displayFunc.RenderSingleTexture( (PictureBox)GUI.Controls.Find(pictureBox, true)[0] , subDir );

        /*    while (pointSize.Width != initialSize.Width)
            {
                pointSize.Width += sizeDelta;
                pointLocation.X -= (int)locationDelta;

                GUI.Invoke((Action)(() => { GUI.Controls.Find(pictureBox, true)[0].Location = pointLocation; }));
                GUI.Invoke((Action)(() => { GUI.Controls.Find(pictureBox, true)[0].Size = pointSize; }));

                GUI.Invoke((Action)(() => { GUI.Refresh(); }));
            }
*/
            MainMenuAnimationTimer.Enabled = false;
        }

        void RotationXAnimation(MainMenu GUI, int timer, string pictureBox, string directoryName, int subDir)
        {
            RotationXAnimation(GUI, timer, pictureBox, directoryName, subDir, 1, "texture");
        }

        void RotationXAnimation(MainMenu GUI, int timer, string pictureBox, string directoryName, int subDir, int Prepare, string filename)
        {
            Point[] P = new Point[NoPictureBox];

            timerAnimation = 0;

            if (timerAnimation == 0)
            {
                for (int i = 0; i < NoPictureBox; i++)
                    P[i] = GUI.Controls.Find(pictureBox, true)[0].Location;
            }

            MainMenuAnimationTimer.Enabled = true;

            // Compute rand()
       /*     Random rand = new Random();

            double rotationDirection = rand.Next(0, 2);

            if (rotationDirection == 0)
                rotationDirection = -1;

            Size initialSize = GUI.Controls.Find(pictureBox, true)[0].Size;
            Size pointSize = GUI.Controls.Find(pictureBox, true)[0].Size;
            Point pointLocation = GUI.Controls.Find(pictureBox, true)[0].Location;

            Point CoM = new Point(((pointSize.Width / 2) + pointLocation.X), ((pointSize.Height / 2) + pointLocation.Y));

            double locationDelta = (CoM.Y - pointLocation.Y) / (timer / 17);
            int sizeDelta = pointSize.Height / (timer / 17);

            while (pointSize.Height > 0)
            {
                pointSize.Height -= sizeDelta;
                pointLocation.Y += (int)locationDelta;

                //Console.WriteLine(pointSize.Height);

                //System.Threading.Thread.Sleep(100);

                //Console.WriteLine(pictureBox);
                //Console.WriteLine(GUI.Controls.Find(pictureBox, true)[0].Size.Height + " vs " + pointSize.Height + " where d" + sizeDelta);

                GUI.Controls.Find(pictureBox, true)[0].Location = pointLocation; 
                GUI.Controls.Find(pictureBox, true)[0].Size = pointSize;

                GUI.Refresh();
                GUI.Update();
            }*/

            if(Prepare == 1)
                PrepareRender(directoryName, subDir, filename);

            displayFunc.RenderSingleTexture((PictureBox)GUI.Controls.Find(pictureBox, true)[0], subDir);

           /* while (pointSize.Height != initialSize.Height)
            {
                pointSize.Height += sizeDelta;
                pointLocation.Y -= (int)locationDelta;

                GUI.Invoke((Action)(() => { GUI.Controls.Find(pictureBox, true)[0].Location = pointLocation; }));
                GUI.Invoke((Action)(() => { GUI.Controls.Find(pictureBox, true)[0].Size = pointSize; }));

                GUI.Invoke((Action)(() => { GUI.Refresh(); }));
            }
*/
            MainMenuAnimationTimer.Enabled = false;
        }


        void MenuAnimation(int timer)
        {
            Point[] P = new Point[NoPictureBox];

            timerAnimation = 0;

            if (timerAnimation == 0)
            {
                for (int i = 0; i < NoPictureBox; i++)
                    P[i] = this.Controls.Find("pictureBox" + (i + 1).ToString(), true)[0].Location;
            }

            MainMenuAnimationTimer.Enabled = true;

           // while (timerAnimation <= timer)
           // {
                float offset = timer / (timerAnimation);

                //Console.WriteLine("offset: " + offset);

                /*for (int i = 0; i < NoPictureBox; i++)
                {
                    Point newPosition = P[i];
                    newPosition.X += (int)offset;

                    this.Controls.Find("pictureBox" + (i + 1).ToString(), true)[0].Location = newPosition;
                }*/

                //this.Update();
           // }

            MainMenuAnimationTimer.Enabled = false;
        }

        public void SetupTimerMenuAnimation()
        {
            MainMenuAnimationTimer = new System.Timers.Timer(17);
            MainMenuAnimationTimer.Elapsed += new ElapsedEventHandler(OnTimedEventMenuAnimation);
            Console.WriteLine("Menu Animation Timer Started");
        }

        public void OnTimedEventMenuAnimation(object source, ElapsedEventArgs e)
        {
            //MainMenuAnimationTimer.Enabled = false;

            timerAnimation += FPS;
            
        }

        //---------------------------- Render Methods ---------------------------

        private Boolean RenderSubDirectory(string directoryName, int subDir)
        {
            return RenderSubDirectory(directoryName, "texture", subDir);
        }

        private Boolean RenderSubDirectory(string directoryName, string fileName, int subDir)
        {
            string subDirectory;

            if (subDir == 0)
                subDirectory = displayFunc.subDirectoryLeft;
            else
                subDirectory = displayFunc.subDirectoryRight;

            if (subDirectory.Contains(directoryName) == false)
            {
                displayFunc.SubDirectory(directoryName, subDir);
                displayFunc.ReadTexturesFromFile(fileName, subDir);
                //displayFunc.PrintFileContents(fileName);
                displayFunc.RenderFile();

                return true;
            }
            else
                return false;
        }

        private Boolean PrepareRender(string directoryName, int subDir, string filename)
        {
            if (subDir == 0)
                return PrepareRender(directoryName, filename, subDir);
            else
                return PrepareRender(directoryName, filename, subDir);
        }

        private Boolean PrepareRender(string directoryName, string fileName, int subDir)
        {
            string subDirectory;

            if (subDir == 0)
                subDirectory = displayFunc.subDirectoryLeft;
            else
                subDirectory = displayFunc.subDirectoryRight;

            if (subDirectory.Contains(directoryName) == false)
            {
                displayFunc.SubDirectory(directoryName, subDir);
                displayFunc.ReadTexturesFromFile(fileName, subDir);

                return true;
            }
            else
                return false;
        }

        // ---------------------------- Threads --------------------------

        void RunFlipAnimation(string[] img, string subDirectory, int subDir)
        {
            for (int i = 0; i < img.Length; i++)
            {
                Random rand = new Random();
                int r = rand.Next(0, 2);

                if (r == 0)
                    RotationXAnimation(this, 300, img[i], subDirectory, subDir);
                else
                    RotationYAnimation(this, 300, img[i], subDirectory, subDir);
                    
            }
        }

        //----------------------------- PictureBox Click Events -----------------

        // Setu/Calibration subGroup 1
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string[] s = { "pictureBox1", "pictureBox2", "pictureBox3", "pictureBox4" };

            if (displayFunc.subDirectoryLeft.Contains("Setup") == false && displayFunc.subDirectoryLeft.Contains("Connectivity") == false)
                RunFlipAnimation(s, "Setup", 0);
            else if (displayFunc.subDirectoryLeft.Contains("Connectivity") )
            {
                // Auto-Connect
				Process.Start (@"/System/Library/PreferencePanes/Bluetooth.prefPane");
            }
            else 
            {
                // calibration

                //animate.CloseMenuAnimation();
                CalibrationWindow = new CalibrationForm(this);
                
               
					Process.Start(Directory.GetCurrentDirectory() + @"/Superhans Real-Time Model Interaction");

				this.Hide ();

				CalibrationWindow.Show();
            }
            
        }

        // Connectivity/Defualt Control subGroup 1
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string[] s = { "pictureBox1", "pictureBox2", "pictureBox3", "pictureBox4" };

			if (displayFunc.subDirectoryLeft.Contains ("Connectivity") == false && displayFunc.subDirectoryLeft.Contains ("Setup") == false)
				RunFlipAnimation (s, "Connectivity", 0);
			else if (displayFunc.subDirectoryLeft.Contains ("Connectivity")) {
				// Default Control
			} 
			else 
			{
				// Sensitivity
				Process.Start (@"/System/Library/PreferencePanes/Keyboard.prefPane");
			}

        }

        // Back/Exit subGroup 1
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            string[] s = { "pictureBox1", "pictureBox2", "pictureBox3", "pictureBox4" };

            if (displayFunc.subDirectoryLeft.Contains("Setup") || displayFunc.subDirectoryLeft.Contains("Connectivity"))
            {
                //back

                displayFunc.subDirectoryLeft = displayFunc.subDirectoryLeft.Substring(0, displayFunc.subDirectoryLeft.LastIndexOf(@"/"));
                displayFunc.subDirectoryLeft = displayFunc.subDirectoryLeft.Substring(0, (displayFunc.subDirectoryLeft.LastIndexOf(@"/") + 1));

                displayFunc.ReadTexturesFromFile("BackMenu", 0);

                for (int i = 0; i < 3; i++)
                {
                    if (i == 2)
                        pictureBox4.Visible = false;

                    RotationXAnimation(this, 300, s[i], "", 0, 0, "texture");
                }

            }
            else
            {
                // Exit

                Application.Exit();
            }
        }

        // Developer/Instructables subGroup right
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            

            if (displayFunc.subDirectoryRight.Contains("Community") == false)
            {
                string[] s = { "pictureBox5", "pictureBox6", "pictureBox7", "pictureBox8" };
                RunFlipAnimation(s, "Community", 1);
            }
            else if (displayFunc.subDirectoryRight.Contains("Help") == true)
            {
                // FAQ
                string filename = Directory.GetCurrentDirectory() + @"/FAQ.pdf";

				Console.WriteLine (filename);

                if (!File.Exists(filename))
                {
                    Console.WriteLine("FAQ document does not exist");
					//Console.WriteLine (Directory.GetCurrentDirectory ());
                    Application.Exit();
                }

                Process.Start(filename);
            }
            
            else if (displayFunc.subDirectoryRight.Contains("Developers") == false)
            {
                string[] s = {"pictureBox7", "pictureBox8" };
                RunFlipAnimation(s, "Developers", 1);
            }
            else if (displayFunc.subDirectoryRight.Contains("Developers") == true)
            {
                // Instructables

                Process.Start("http://instructables.com");
            }
           
        }

        // Back/Community Right Group 
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pictureBox3_Click(null, null);
        }

        // Back/Community Right group
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
            if (displayFunc.subDirectoryRight.Contains("Community") == false)
            {
                string[] s = { "pictureBox5", "pictureBox6", "pictureBox7", "pictureBox8" };
                RunFlipAnimation(s, "Community", 1);
            }
            else if ( displayFunc.subDirectoryRight.Contains("Help") == true || displayFunc.subDirectoryRight.Contains("Developers") == true )
            {
                // back

                string[] s = { "pictureBox7", "pictureBox8" };


                displayFunc.subDirectoryRight = rootDirectory;
                RunFlipAnimation(s, "Community", 1);
            }
            else
            {
                // Nothing
            }

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

            if (displayFunc.subDirectoryRight.Contains("Community") == false)
            {
                string[] s = { "pictureBox5", "pictureBox6", "pictureBox7", "pictureBox8" };
                RunFlipAnimation(s, "Community", 1);
            }
            else if (displayFunc.subDirectoryRight.Contains("Developers") == true)
            {
                // SDK
                Process.Start("https://gist.github.com/Lukemtesta/7544130");
            }
            else if (displayFunc.subDirectoryRight.Contains("Help") == false)
            {
                string[] s = { "pictureBox7", "pictureBox8" };
                RunFlipAnimation(s, "Help", 1);
            }
            else if (displayFunc.subDirectoryRight.Contains("Help") == true)
            {
                // PDF
                string filename = Directory.GetCurrentDirectory() + @"/SuperhansDocumentation.pdf";

                if (!File.Exists(filename))
                {
                    Console.WriteLine("Documentation does not exist");
                    Application.Exit();
                }
                
                Process.Start(filename);
            }
            
            
        }

        // Exit/Existing Games || DeviceID
        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            if (displayFunc.subDirectoryLeft.Contains("Setup") )
            {
                // Existing Games
                //animate.CloseMenuAnimation();

                ExistingGamesWindow = new ExistingGames(this);
                ExistingGamesWindow.Show();
                this.Hide();
            }
            else if (displayFunc.subDirectoryLeft.Contains("Connectivity"))
            {
                //Device ID
            }
            else
            {
                //Exit
                pictureBox5_Click(null, null);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

    }
}
