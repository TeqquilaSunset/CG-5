﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao.Platform;
using Tao.OpenGl;
using System.Data.SqlTypes;
using Tao.FreeGlut;
using Tao.Platform.Windows;
using System.Xml.Linq;
using System.Runtime.CompilerServices;
using System.Reflection;

namespace CG_5
{
    public partial class Form1 : Form
    {
        // положение фигуры A
        static float Ax = -0.7f;
        static float Ay = 0;
        static float Aalfa = 0;
        static float Aalfa2 = 0;
        static float Asx = 1;
        static float Asy = 1;

        // положение фигуры В
        static float Bx = 0;
        static float By = 0;
        static float Balfa = 0;
        static float Bsx = 1;
        static float Bsy = 1;

        static bool flag = false;
        static bool flag2 = false;
        public Form1()
        {
            InitializeComponent();
            sim.InitializeContexts();
            Gl.glViewport(0, 0, sim.Width, sim.Height);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            Gl.glClearColor(255, 255, 255, 1);
            //Draw();
            sim.Invalidate();
        }

        private void sim_Load(object sender, EventArgs e)
        {
            FigureMove("1",1,1,1,1,1);
            //DrawB();
            //DrawA();
        }

        private float[,] Polygon(int n, float r, float x, float y)
        {
            float[,] array = new float[2, n+1];
            int angel = 360 / (n * 2);

            for (int i = 0; i < n; i++)
            {
                array[0, i] = r * (float)Math.Cos((angel * Math.PI) / 180);
                array[1, i] = r * (float)Math.Sin((angel * Math.PI) / 180);
                angel += 360 / n;
            }

            return array;
        }
       
        private void DrawA()
        {
            //Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            int n = 6;
            var array = Polygon(n, 0.25f, -0.7f, 0);

            Gl.glColor4f(0.207f, 0.407f, 0.1f, 0.01f);
            Gl.glBegin(Gl.GL_POLYGON);
            for (int i = 0; i < n; i++)
            {
                Gl.glVertex2f(array[0, i], array[1, i]);
            }
            Gl.glEnd();

            Gl.glColor3f(0, 0.7f, 0);
            Gl.glLineWidth(3);
            Gl.glBegin(Gl.GL_LINE_LOOP);
            for (int i = 0; i < 6; i++)
            {
                Gl.glVertex2f(array[0, i], array[1, i]);
            }
            Gl.glEnd();

            Gl.glPointSize(5f);
            Gl.glColor3f(0, 0, 0);
            Gl.glEnable(Gl.GL_POINT_SMOOTH);
            Gl.glBegin(Gl.GL_POINTS);
            for (int i = 0; i < 6; i++)
            {
                Gl.glVertex2f(array[0, i], array[1, i]);
            }
            Gl.glEnd();

            Gl.glColor3f(0.101f, 0.7f, 0.8f);
            Gl.glLineWidth(3);
            Gl.glBegin(Gl.GL_POLYGON);
            for (int i = 1; i < 6; i = i + 2)
            {
                Gl.glVertex2f(array[0, i], array[1, i]);
            }
            Gl.glEnd();

            Gl.glColor3f(0, 0.12f, 0.7f);
            Gl.glLineWidth(3);
            Gl.glBegin(Gl.GL_LINE_LOOP);
            for (int i = 1; i < 6; i = i + 2)
            {
                Gl.glVertex2f(array[0, i], array[1, i]);
            }
            Gl.glEnd();

            Gl.glPointSize(10);
            Gl.glColor3f(0, 0, 0);
            Gl.glEnable(Gl.GL_POINT_SMOOTH);
            Gl.glBegin(Gl.GL_POINTS);
            Gl.glVertex2f(array[0, 6], array[1, 6]);
            Gl.glEnd();

            sim.Invalidate();
        }

        private  void DrawB()
        {
            //Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(3);
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2f(-0.3f, 0.2f);
            Gl.glVertex2f(-0.3f, -0.2f);
            Gl.glVertex2f(0.3f, -0.2f);
            Gl.glVertex2f(0.3f, 0.2f);
            Gl.glEnd();

            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2f(-0.3f, 0.2f);
            Gl.glVertex2f(-0.3f, 0.5f);
            Gl.glVertex2f(-0.1f, 0.2f);
            Gl.glEnd();

            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2f(0.3f, -0.2f);
            Gl.glVertex2f(0.3f, -0.5f);
            Gl.glVertex2f(0.1f, -0.2f);
            Gl.glEnd();

            Gl.glPointSize(10);
            Gl.glEnable(Gl.GL_POINT_SMOOTH);
            Gl.glBegin(Gl.GL_POINTS);
                Gl.glVertex2f(0, 0);
            Gl.glEnd();

            sim.Invalidate();
        }

        

        private void sim_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Application.Exit();
            //фигура B
            if (e.KeyCode == Keys.W)
                FigureMove("B", Bx, By += 0.1f, Bsx, Bsy, Balfa);

            if (e.KeyCode == Keys.S)
                FigureMove("B", Bx, By -= 0.1f, Bsx, Bsy, Balfa);

            if (e.KeyCode == Keys.A)
                FigureMove("B", Bx -= 0.1f, By, Bsx, Bsy, Balfa);

            if (e.KeyCode == Keys.D)
                FigureMove("B", Bx += 0.1f, By, Bsx, Bsy, Balfa);

            if (e.KeyCode == Keys.Q)
                FigureMove("B", Bx, By, Bsx, Bsy, Balfa += 2);

            if (e.KeyCode == Keys.E)
                FigureMove("B", Bx, By, Bsx, Bsy, Balfa -= 2);

            if (e.KeyCode == Keys.Z)
                FigureMove("B", Bx, By, Bsx += 0.1f, Bsy, Balfa);

            if (e.KeyCode == Keys.X)
                FigureMove("B", Bx, By, Bsx -= 0.1f, Bsy, Balfa);

            if (e.KeyCode == Keys.C)
                FigureMove("B", Bx, By, Bsx, Bsy += 0.1f, Balfa);

            if (e.KeyCode == Keys.V)
                FigureMove("B", Bx, By, Bsx, Bsy -= 0.1f, Balfa);

            //фигура А
            if (e.KeyCode == Keys.Y)
                FigureMove("A", Ax, Ay += 0.1f, Asx, Asy, Aalfa);

            else if (e.KeyCode == Keys.H)
                FigureMove("A", Ax, Ay -= 0.1f, Asx, Asy, Aalfa);

            if (e.KeyCode == Keys.G)
                FigureMove("A", Ax -= 0.1f, Ay, Asx, Asy, Aalfa);

            if (e.KeyCode == Keys.J)
                FigureMove("A", Ax += 0.1f, Ay, Asx, Asy, Aalfa);

            if (e.KeyCode == Keys.T)
                FigureMove("A", Ax, Ay, Asx, Asy, Aalfa += 2);

            if (e.KeyCode == Keys.U)
                FigureMove("A", Ax, Ay, Asx, Asy, Aalfa -= 2);

            if (e.KeyCode == Keys.B)
                FigureMove("A", Ax, Ay, Asx += 0.1f, Asy, Aalfa);

            if (e.KeyCode == Keys.N)
                FigureMove("A", Ax, Ay, Asx -= 0.1f, Asy, Aalfa);

            if (e.KeyCode == Keys.K)
                FigureMove("A", Ax, Ay, Asx, Asy += 0.1f, Aalfa);

            if (e.KeyCode == Keys.L)
                FigureMove("A", Ax, Ay, Asx, Asy -= 0.1f, Aalfa);

            if (e.KeyCode == Keys.D0)
            {
                flag = true;
                FigureMove("A", Ax, Ay, Asx, Asy, Aalfa);
            }

            if (e.KeyCode == Keys.O)
            {
                flag2 = true;
                FigureMove("A", Ax, Ay, Asx, Asy, Aalfa2 +=2);
            }
            if (e.KeyCode == Keys.P)
            {
                flag2 = true;
                FigureMove("A", Ax, Ay, Asx, Asy, Aalfa2 -=2);
            }
        }

        private void Draw()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            DrawA();
            DrawB();
            sim.Invalidate();
        }

        private void FigureMove(string name, float x, float y, float sx, float sy, float alfa)
        {
            // A
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);

             // сохранить матрицу
            if (flag == true)
            {
                
                float temp = 0;
                //Gl.glScalef(Bsx, Bsy, 1);
                for (int i = 0; i < 100; i++)
                {
                    temp -= 2;
                    Gl.glPushMatrix();
                    Gl.glTranslatef(Bx, By, 0);
                    Gl.glRotatef(temp, 0, 0, 1);
                    Gl.glTranslatef(Ax, Ay, 0);
                    Gl.glScalef(Asx, Asy, 1);
                    DrawA();
                    Gl.glPopMatrix();
                }
                flag = false;
                //Gl.glLoadIdentity(); 
            }
            else if (flag2 == true)
            {
                flag2 = false;
                Gl.glPushMatrix();
                Gl.glTranslatef(Bx, By, 0);
                Gl.glRotatef(Aalfa2, 0, 0, 1);
                Gl.glTranslatef(Ax, Ay, 0);
                Gl.glTranslatef(-Bx, -By, 0);
                Gl.glScalef(Asx, Asy, 1);
                DrawA();
                Gl.glPopMatrix();
            }
            else
            {
                //Gl.glPushMatrix();
                //Gl.glScalef(Asx, Asy, 1);
                //Gl.glTranslatef(Bx, By, 0);
                //Gl.glTranslatef(Ax, Ay, 0);
                //Gl.glTranslatef(-Bx, -By, 0);
                //Gl.glRotatef(Aalfa, 0, 0, 1);  // от порядка транслейт и ротейт зависит относительность поворота
                //Gl.glRotatef(-Aalfa, 0, 0, 1);
                //Gl.glLoadIdentity();

                //Gl.glScalef(Asx, Asy, 1);
                //Gl.glTranslatef(Ax, Ay, 0);
                //Gl.glRotatef(Aalfa, 0, 0, 1);

                Gl.glPushMatrix();
                Gl.glTranslatef(Bx, By, 0);
                Gl.glRotatef(Aalfa2, 0, 0, 1);
                Gl.glTranslatef(-Bx, -By, 0);
                Gl.glTranslatef(Ax, Ay, 0);
                Gl.glRotatef(Aalfa, 0, 0, 1);
                Gl.glScalef(Asx, Asy, 1);
                DrawA();
                Gl.glPopMatrix();
            }
            

            
            // B
            Gl.glPushMatrix(); // сохранить матрицу
                Gl.glScalef(Bsx, Bsy, 1);
                Gl.glTranslatef(Bx, By, 0);
                Gl.glRotatef(Balfa, 0, 0, 1);  // от порядка транслейт и ротейт зависит относительность поворота
                DrawB();
            Gl.glPopMatrix(); // вернуть матрицу
            //Draw();
        }
    }
}
