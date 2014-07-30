using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;


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
    public partial class CalibrationForm : Form
    {
        public static System.Timers.Timer MainMenuAnimationTimer;

        public string texturePath = Directory.GetCurrentDirectory() + @"\Textures\";

        const int NoPictureBox = 2;

        static float timerAnimation;

        CalibrationForm CalibrationWindow;

        List<ImageGroup> imageGroupList = new List<ImageGroup>();

        ImageGroup displayFunc;
        Matrix Mat;
        Animation animate;

        MainMenu previousForm;

        public CalibrationForm(MainMenu Form)
        {
            InitializeComponent();

            // Store reference to main form
            previousForm = Form;

            // Initialize Image Class
            displayFunc = new ImageGroup(this);

            // Initialize Animation Class
            animate = new Animation(this);

            // Initialize Animation Timer
            timerAnimation = 0;

            // Trigger Form Shown
            Shown += Form2_Shown;
            //CalibrationForm.Close += Form2_FormClosing;
        }

        private void Form2_Shown(object sender, EventArgs e)
        {
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            this.Hide();
            System.Threading.Thread.Sleep(250);

            previousForm = new MainMenu();
            previousForm.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();

            System.Threading.Thread.Sleep(250);

            previousForm = new MainMenu();
            previousForm.Show();
        }

        private void CalibrationForm_Load(object sender, EventArgs e)
        {

        }
    }
}
