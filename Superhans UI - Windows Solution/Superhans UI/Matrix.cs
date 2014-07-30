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
    class Matrix
    {
        public double[][] Rx;
        public double[][] Ry;

        public Matrix()
        {}

        ~Matrix()
        {}

        public double[][] computeRx(double angle)
        {
            double cx = Math.Cos(angle);
            double sx = Math.Sin(angle);

            Rx = new double[][] { new double[] { 1, 0, 0 }, new double[] { 0, cx, -sx }, new double[] { 0, sx, cx } };

            return Rx;
        }

        public double[][] computeRy(double angle)
        {
            double cy = Math.Cos(angle);
            double sy = Math.Sin(angle);

            Ry = new double[][] { new double[] { cy, 0, sy }, new double[] { 0, 1, 0 }, new double[] { -sy, 0, cy } };  

            return Ry;
        }

        public Point multiplyMatrix(double[][] M, Point pp)
        {
            double[] pt = new double[3];
            double[] P = new double[3];

            P[0] = pp.X; P[1] = pp.Y; P[2] = 0;

            pt[0] = 0; pt[1] = 0; pt[2] = 0;

            for (int i = 0; i < M.Length; i++)
            {
                for (int j = 0; j < M[i].Length; j++)
                {
                    pt[i] += M[i][j]*P[j];
                }
            }

            Point newPoint = new Point( (int)pt[0], (int)pt[1]);

            return newPoint;
        }

        public Point Translate(Point p, double angle)
        {
            angle = (angle * Math.PI)/360;

            Rx = computeRx(angle);

            double[] pt = new double[3];

            pt[0] = p.X;
            pt[1] = p.Y;
            pt[2] = 0;

            // Compute matrix rotation

            Point p1 = new Point( (int)pt[0], (int)pt[1] );
            return p1;
        }

        public void PrintMatrix(double[][] M)
        {
            Console.WriteLine("M: ");

            for (int i = 0; i < M.Length; i++)
            {
                for (int j = 0; j < M[i].Length; j++)
                {
                    Console.Write("M: " + M[i][j]);
                }

                Console.WriteLine();
            }

        }

    }
}
