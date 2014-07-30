using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
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
    public partial class ExistingGames : Form
    {

        MainMenu previousForm;

        ArrayList Games;

        public ExistingGames(MainMenu GUI)
        {
            InitializeComponent();

            // Trigger Form Shown
            Shown += Form2_Shown;

            previousForm = GUI;

            listBox2.MouseDoubleClick += new MouseEventHandler(listBox2_MouseDoubleClick);

            Games = new ArrayList();
        }

        private void Form2_Shown(object sender, EventArgs e)
        {
            Point pictureBox2Location = new Point(12, 12);

            System.Threading.Thread.Sleep(150);

            pictureBox1.Location = new Point(12, 12);

            listBox2.Visible = true;

            pictureBox2.Visible = true;

        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            this.Hide();
            System.Threading.Thread.Sleep(250);

            previousForm = new MainMenu();
            previousForm.Show();
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        void listBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.listBox2.IndexFromPoint(e.Location);

            if (listBox2.Items[index].ToString() == "Add Control")
            {
                listBox2.Items[index] = Interaction.InputBox("Enter Control Name eg. Shoot or Look Up", "Add Control", "") + ":";
                listBox2.Items.Add("Add Control");
            }
            else
            {
                int i = listBox2.Items[index].ToString().IndexOf(":");
                string s = listBox2.Items[index].ToString().Substring(0, i);
                s += ": " + Interaction.InputBox("Enter Superhans button eg. Index Finger or Tilt Left","Add Control","");

                listBox2.Items[index] = s;
            }
        }

        private void ExistingGames_Load(object sender, EventArgs e)
        {

        }
    }
}
