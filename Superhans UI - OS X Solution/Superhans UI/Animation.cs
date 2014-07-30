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
    class Animation
    {
        public static System.Timers.Timer animationTimer;

        int timerAnimation;

        MainMenu MainForm;
        CalibrationForm CalibrationForm;
        ExistingGames ExistingGames;

        public Animation(MainMenu GUI)
        {
            MainForm = GUI;

            animationTimer = new System.Timers.Timer();
        }

        public Animation(ExistingGames GUI)
        {
            ExistingGames = GUI;

            animationTimer = new System.Timers.Timer();
        }

        public Animation(CalibrationForm GUI)
        {
            CalibrationForm = GUI;

            animationTimer = new System.Timers.Timer();
        }

        ~Animation()
        { }

        public void SetupTimerMenuAnimation()
        {
            animationTimer = new System.Timers.Timer(17);
            animationTimer.Elapsed += new ElapsedEventHandler(OnTimedEventMenuAnimation);
            Console.WriteLine("Menu Animation Timer Started");
        }

        public void OnTimedEventMenuAnimation(object source, ElapsedEventArgs e)
        {
            timerAnimation += 17;
        }

        public void TranslateY(int timer, PictureBox[] img, Point finalPosition )
        {
            Point[] initialPosition = new Point[img.Length];
            Point[] newPosition = new Point[img.Length];

            for (int i = 0; i < img.Length; i++)
            {
                initialPosition[i] = img[i].Location;
            }

            newPosition = initialPosition;
            int offsetY = (initialPosition[0].Y - finalPosition.Y) / (timer / 17); 

            animationTimer.Enabled = true;

            while (img[0].Location.Y < finalPosition.Y)
            {
                for (int i = 0; i < img.Length; i++)
                {
                    newPosition[i].Y -= offsetY;

                    img[i].Location = newPosition[i];
                }

                MainForm.Refresh();
            }

            
            animationTimer.Enabled = false;

            timerAnimation = 0;
        }

        public void TranslateX(int timer, PictureBox[] img, Point finalPosition)
        {
            Point[] initialPosition = new Point[img.Length];
            Point[] newPosition = new Point[img.Length];

            for (int i = 0; i < img.Length; i++)
            {
                initialPosition[i] = img[i].Location;
            }

            newPosition = initialPosition;
            int offsetX = (initialPosition[0].X - finalPosition.X) / (timer / 17);

            animationTimer.Enabled = true;

            while (img[0].Location.X > finalPosition.X)
            {
                for (int i = 0; i < img.Length; i++)
                {
                    newPosition[i].X -= offsetX;

                    img[i].Location = newPosition[i];
                }

                MainForm.Refresh();
            }


            animationTimer.Enabled = false;

            timerAnimation = 0;
        }

        public void TranslateX(int timer, PictureBox img, Point finalPosition)
        {
            Point initialPosition;
            Point newPosition;

            initialPosition = img.Location;

            newPosition = initialPosition;
            int offsetX = (initialPosition.X - finalPosition.X) / (timer / 17);

            animationTimer.Enabled = true;

            while (img.Location.X < finalPosition.X)
            {

                newPosition.X -= offsetX;

                img.Location = newPosition;

                CalibrationForm.Refresh();
            }


            animationTimer.Enabled = false;

            timerAnimation = 0;
        }

        public void TranslateX(ExistingGames E, int timer, PictureBox img, Point finalPosition)
        {
            Point initialPosition;
            Point newPosition;

            initialPosition = img.Location;

            newPosition = initialPosition;
            int offsetX = (initialPosition.X - finalPosition.X) / (timer / 17);

            animationTimer.Enabled = true;

            while (img.Location.X > finalPosition.X)
            {

                newPosition.X -= offsetX;

                img.Location = newPosition;

                E.Refresh();
            }


            animationTimer.Enabled = false;

            timerAnimation = 0;
        }
        

        public void TranslateY(int timer, PictureBox img, Point finalPosition)
        {
            Point initialPosition;
            Point newPosition;

            initialPosition = img.Location;

            newPosition = initialPosition;
            int offsetY = (initialPosition.Y - finalPosition.Y) / (timer / 17);

            animationTimer.Enabled = true;

            Console.WriteLine(initialPosition.Y + " vs" + finalPosition.Y);

            while (img.Location.Y > finalPosition.Y)
            {
                Console.WriteLine(img.Location.Y);

                newPosition.Y -= offsetY;

                img.Location = newPosition;

                CalibrationForm.Refresh();
            }


            animationTimer.Enabled = false;

            timerAnimation = 0;
        }

        public void FlipYAnimation(int timer, string pictureBox)
        {
            timerAnimation = 0;

            Point P = MainForm.Controls.Find(pictureBox, true)[0].Location;

            animationTimer.Enabled = true;

            Size initialSize = MainForm.Controls.Find(pictureBox, true)[0].Size;
            Size pointSize = MainForm.Controls.Find(pictureBox, true)[0].Size;
            Point pointLocation = MainForm.Controls.Find(pictureBox, true)[0].Location;

            Point CoM = new Point(((pointSize.Width / 2) + pointLocation.X), ((pointSize.Height / 2) + pointLocation.Y));

            double locationDelta = (CoM.X - pointLocation.X) / (timer / 17);
            int sizeDelta = pointSize.Width / (timer / 17);

            while (pointSize.Width > 0)
            {
                pointSize.Width -= sizeDelta;
                pointLocation.X += (int)locationDelta;

                MainForm.Invoke((Action)(() => { MainForm.Controls.Find(pictureBox, true)[0].Location = pointLocation; }));
                MainForm.Invoke((Action)(() => { MainForm.Controls.Find(pictureBox, true)[0].Size = pointSize; }));

                //MainForm.Controls.Find(pictureBox, true)[0].Location = pointLocation; 
                //MainForm.Controls.Find(pictureBox, true)[0].Size = pointSize.Width; 

                MainForm.Invoke((Action)(() => { MainForm.Refresh(); }));
                MainForm.Invoke((Action)(() => { MainForm.Update(); })); 
            }

            MainForm.Controls.Find(pictureBox, true)[0].Visible = false; 

            animationTimer.Enabled = false;
        }

        public void FlipXAnimation(int timer, string pictureBox)
        {
            timerAnimation = 0;

            Point P = MainForm.Controls.Find(pictureBox, true)[0].Location;

            animationTimer.Enabled = true;

            Size initialSize = MainForm.Controls.Find(pictureBox, true)[0].Size;
            Size pointSize = MainForm.Controls.Find(pictureBox, true)[0].Size;
            Point pointLocation = MainForm.Controls.Find(pictureBox, true)[0].Location;

            Point CoM = new Point(((pointSize.Width / 2) + pointLocation.X), ((pointSize.Height / 2) + pointLocation.Y));

            double locationDelta = (CoM.Y - pointLocation.Y) / (timer / 17);
            int sizeDelta = pointSize.Height / (timer / 17);

            while (pointSize.Height > 0)
            {
                pointSize.Height -= sizeDelta;
                pointLocation.Y += (int)locationDelta;

                MainForm.Invoke((Action)(() => { MainForm.Controls.Find(pictureBox, true)[0].Location = pointLocation; }));
                MainForm.Invoke((Action)(() => { MainForm.Controls.Find(pictureBox, true)[0].Size = pointSize; }));

                //MainForm.Controls.Find(pictureBox, true)[0].Location = pointLocation; 
                //MainForm.Controls.Find(pictureBox, true)[0].Size = pointSize.Width; 

                MainForm.Invoke((Action)(() => { MainForm.Refresh(); }));
                MainForm.Invoke((Action)(() => { MainForm.Update(); })); 
            }

            MainForm.Controls.Find(pictureBox, true)[0].Visible = false; 

            animationTimer.Enabled = false;
        }

        public void CloseMenuAnimation()
        {
            for (int i = 1; i <= 8; i++)
            {
                Random rand = new Random();

                int r = rand.Next(0, 2);

                if(r == 0)
                    FlipYAnimation(500, "pictureBox" + i.ToString());
                else
                    FlipXAnimation(500, "pictureBox" + i.ToString());
            }
        }
    }
}
