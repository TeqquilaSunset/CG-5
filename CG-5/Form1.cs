using System;
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

namespace CG_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            sim.InitializeContexts();
        }

        private void linesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Gl.glViewport(0, 0, sim.Width, sim.Height);
            Gl.glClearColor(255, 255, 255, 1); //Цвет фона
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            DrawAxes();
            Gl.glColor3f(0, 1.0f, 0); // цвет
            Gl.glLineWidth(3);
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2f(-0.5f, 0.7f);
            Gl.glVertex2f(0f, 0f);
            Gl.glVertex2f(0.5f, 0.7f);
            Gl.glVertex2f(0.6f, -0.3f);
            Gl.glVertex2f(-0.1f, -0.7f);
            Gl.glVertex2f(-0.55f, -0.3f);
            Gl.glEnd();
            sim.Invalidate();
        }

        private void polygonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Gl.glViewport(0, 0, sim.Width, sim.Height);
            Gl.glClearColor(255, 255, 255, 1); //Цвет фона
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            Gl.glClear(Gl.GL_DEPTH_BUFFER_BIT);
            DrawAxes();
            Gl.glLineWidth(3);
            Gl.glBegin(Gl.GL_POLYGON);
            Gl.glColor3f(0, 0, 1.0f); 
            Gl.glVertex2f(0f, 0f); //2
            Gl.glColor3f(1.0f, 0, 0); 
            Gl.glVertex2f(0.5f, 0.7f); // 3
            Gl.glColor3f(0, 0, 1.0f);
            Gl.glVertex2f(0.6f, -0.3f); // 4
            Gl.glColor3f(0, 1.0f, 0);
            Gl.glVertex2f(-0.1f, -0.7f); //5
            Gl.glColor3f(0, 0, 1.0f);
            Gl.glVertex2f(-0.55f, -0.3f); // 6
            Gl.glColor3f(0, 1.0f, 0);
            Gl.glVertex2f(-0.5f, 0.7f); //1
            Gl.glEnd();
            sim.Invalidate();
        }

        void DrawAxes()
        {
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(1);
            Gl.glBegin(Gl.GL_LINES);
            Gl.glVertex2f(-0.9f, 0); //х
            Gl.glVertex2f(0.9f, 0);
            Gl.glVertex2f(0, 0.9f); //у
            Gl.glVertex2f(0, -0.9f);
            Gl.glEnd();

            Gl.glBegin(Gl.GL_TRIANGLES);
            Gl.glVertex2f(0.9f, 0.025f);
            Gl.glVertex2f(0.9f, -0.025f);
            Gl.glVertex2f(0.925f, 0);

            Gl.glVertex2f(0.02f, 0.9f);
            Gl.glVertex2f(-0.02f, 0.9f);
            Gl.glVertex2f(0, 0.925f);
            Gl.glEnd();
        }

    }
}
