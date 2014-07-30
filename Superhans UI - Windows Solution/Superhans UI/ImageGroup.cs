using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Timers;
using System.Text;
using System.Windows.Forms;
using System.IO;
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
    public class ImageGroup
    {
        //------------- Variables ------------

        private string[] formPictures;
        public string texturePath = Directory.GetCurrentDirectory() + @"\Textures\";
        public string subDirectoryLeft, subDirectoryRight;

        int subGroup;

        public MainMenu MainForm;
        public CalibrationForm CalibrationForm;

        public ImageGroup(MainMenu GUI)
        {
            // Only 8 picture boxes on form
            formPictures = new string[8];

            // Initialize subGroup
            subGroup = 0;

            // Initialize picture boxes as null
            for (int i = 0; i < 8; i++)
                formPictures[i] = null;

            // Store reference to Form1
            MainForm = GUI;

            // Store subDirectory
            subDirectoryLeft = texturePath + "MainMenu" + @"\";
            subDirectoryRight = texturePath + "MainMenu" + @"\";
        }

        public ImageGroup(CalibrationForm GUI)
        {
            // Only 8 picture boxes on form
            formPictures = new string[8];

            // Initialize subGroup
            subGroup = 0;

            // Initialize picture boxes as null
            for (int i = 0; i < 8; i++)
                formPictures[i] = null;

            // Store reference to Form1
            CalibrationForm = GUI;

            // Store subDirectory
            subDirectoryLeft = texturePath + "MainMenu" + @"\";
            subDirectoryRight = texturePath + "MainMenu" + @"\";
        }


        ~ImageGroup()
        {
        }

        //------------- Constructors && Destructors ---------------

        public void SubDirectory(string newPath,  int subDir)
        {
            if(subDir == 0)
                subDirectoryLeft += newPath + @"\";
            else
                subDirectoryRight += newPath + @"\";
        }

        // Reads visible picture boxes from file. Stores texture against picture box.
        //
        // Assumes .png in texture path
        public void ReadTexturesFromFile(string FileName, int subDir)
        {
            string subDirectory;

            if (subDir == 0)
                subDirectory = subDirectoryLeft;
            else
                subDirectory = subDirectoryRight;

            // Check if file exists
            if ( !System.IO.File.Exists(subDirectory + FileName + ".txt") )
            {
                Console.WriteLine("File Does Not Exist: " + subDirectory + FileName + ".txt");
                return;
            }

            string[] fileLines = System.IO.File.ReadAllLines(subDirectory + FileName + ".txt");

            int i = 0;

            // Decide subGroup to Render
            if (fileLines[0].Substring(0, 1) == "1")
                subGroup = 0;
            else
                subGroup = 1;

            foreach (string line in fileLines)
            {
                // Read texture.png name. if no name must be null
                if (line.Substring(2) == "")
                    formPictures[i] = null;
                else
                    formPictures[i] = line.Substring(2);
                i++;
            }
        }

        // Reads content of file stored in texture path
        public void PrintFileContents(string fileName, int subDir)
        {
            string subDirectory;

            if (subDir == 0)
                subDirectory = subDirectoryLeft;
            else
                subDirectory = subDirectoryRight;

            // Check if file exists
            if ( !File.Exists(subDirectory + fileName + ".txt") )
            {
                Console.WriteLine("File Does Not Exist");
                return;
            }

            Console.WriteLine("Contents of " + fileName + ".png is: " + "\n" + File.ReadAllText(subDirectory + fileName + ".txt") ); 
        }

        public void RenderSingleTexture(PictureBox img, int subDir)
        {
            img.Visible = true;

            int index = Convert.ToInt16(img.Name[img.Name.Length - 1].ToString()) - (subGroup * 4);

            if (formPictures[index - 1] == null)
                img.Visible = false;
            else
                img.Image = (Bitmap)Bitmap.FromFile(texturePath + formPictures[index - 1] + ".png");
        }

        //Renders subGroups. Only existing texture pictureBoxes are made visible
        public void RenderFile()
        {
            for (int i = ((4*subGroup) + 1); i <= formPictures.Length; i++)
            {
                //Console.WriteLine("i: " + i + " Pics: " + formPictures[i - 1]);

                // if null, disable pictureBox visibility
                if (formPictures[i - 1 - (4 * subGroup)] == null)
                    MainForm.Controls.Find("pictureBox" + i.ToString(), true)[0].Visible = false;
                else
                {
                    PictureBox img = (PictureBox)MainForm.Controls.Find("pictureBox" + i.ToString(), true)[0];

                    img.Visible = true;
                    img.Image = (Bitmap)Bitmap.FromFile(texturePath + formPictures[i - 1 - (4 * subGroup)] + ".png");

                   // Console.WriteLine(i.ToString() + " is " + formPictures[i - 1 - (4 * subGroup)]);
                }
            }

            if (subGroup == 1)
            {
                for(int i = 0; i < 4; i++)
                    formPictures[i+4] = formPictures[i];
            }
        }


    }
}
