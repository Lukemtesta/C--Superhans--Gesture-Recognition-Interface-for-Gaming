using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Timers;
using System.Text;
using System.Windows.Forms;
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
    class TextureGroups
    {
        TextureGroups()
        { }

        ~TextureGroups()
        { }

        void MenuGroupOne()
        {
            const int NoImages = 3;

            // Load Picture Names

            string[] Menu = new String[NoImages];
            Menu[0] = "Setup.png";
            Menu[1] = "Connectivity.png";
            Menu[2] = "Exit.png";

            // Point to associate PictureBox

            PictureBox[] pictureBoxes = new PictureBox[NoImages];
        }
    }
}
