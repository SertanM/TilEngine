using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;


namespace TileEngine
{
    public class Canvas : Form
    {
        public Canvas()
        {
            this.DoubleBuffered = true;
        }
    }

    public abstract class Tilengine
    {
        public static Vector ScreanSize = new Vector(500, 500);
        public string Title = "";
        public Color BackgroundColor = Color.Black;
        public static Canvas Window = null;
        private Thread GameLoopThread = null;
        public static List<Shape> RenderStack  = new List<Shape>();
        public static bool keyW, keyA, keyS, keyD;
        public Tilengine(Vector screanSize, string title, Color bgColor)
        {
            ScreanSize = screanSize;
            Title = title;
            BackgroundColor = bgColor;

            Window = new Canvas();
            Window.Size = new Size((int)ScreanSize.x, (int)ScreanSize.y);
            Window.Text = Title;
            Window.Paint += Renderer;
            Window.KeyDown += isKeyDown;
            Window.KeyUp += isKeyUp;
            GameLoopThread = new Thread(GameLoop);
            GameLoopThread.SetApartmentState(ApartmentState.STA);
            GameLoopThread.Start();

            System.Windows.Forms.Application.Run(Window);
        }

        public static void RegisterShape(Shape s)
        {
            if (s != null)
            {
                RenderStack.Add(s);
            }
        }

        public static List<Shape> GetShapesWithTag(string tag)
        {
            List<Shape> found = new List<Shape>();
            foreach(Shape s in RenderStack)
            {
                if (s.tag == tag)
                {
                    found.Add(s);
                }
            }
            return found;
        }

        private void isKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W) keyW = true;
            else if (e.KeyCode == Keys.A) keyA = true;
            else if (e.KeyCode == Keys.S) keyS = true;
            else if (e.KeyCode == Keys.D) keyD = true;
        }

        private void isKeyUp(object sender, System.Windows.Forms.KeyEventArgs e) 
        {
            if (e.KeyCode == Keys.W) keyW = false;
            else if (e.KeyCode == Keys.A) keyA = false;
            else if (e.KeyCode == Keys.S) keyS = false;
            else if (e.KeyCode == Keys.D) keyD = false;
        }

        private void GameLoop()
        {
            Load();
            

            while (true)
            {
                try
                {
                    Window.BeginInvoke((MethodInvoker)delegate { Window.Refresh(); });
                    Update();
                    Thread.Sleep(1);
                }
                catch(Exception) { }
            }
        }


        private void Renderer(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(BackgroundColor);
            List<Shape> Render = new List<Shape>(RenderStack);
            foreach (Shape s in Render) 
            {
                if (s.activeSelf) g.FillRectangle(new SolidBrush(s.color), (int)s.position.x, (int)s.position.y, (int)s.scale.x, (int)s.scale.y);
            }
        }
        public abstract void Load(); 
        public abstract void Update();
    }
}
