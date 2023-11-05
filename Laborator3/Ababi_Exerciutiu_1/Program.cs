using System;
using System.Drawing;
using System.Threading;

using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace Ababi_Exerciutiu_1

{
    //Partea din exercitiul unu in care se indica desenarea axecol intr-un singur GL.Begin()
    class SimpleWindow3D : GameWindow
    {
        public SimpleWindow3D() : base(800, 600)
        {
            VSync = VSyncMode.On;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.ClearColor(Color.GreenYellow);
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, Width, Height);
            double aspect_ratio = Width / (double)Height;
            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)aspect_ratio, 1, 54);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspective);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
        }
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            //am specificat pozitionarea camerei pentru a fi vizibile toate 3 axe
            Matrix4 lookat = Matrix4.LookAt(new Vector3(5, 5, 5), Vector3.Zero, Vector3.UnitY);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);

            DrawAxes();
            SwapBuffers();
        }
        //functia de desenare a axelor
        private void DrawAxes()
        {
            GL.Begin(PrimitiveType.Lines);

            //se desenează axa OX (roșu)
            GL.Color3(1.0, 0.0, 0.0);
            GL.Vertex3(0.0, 0.0, 0.0);
            GL.Vertex3( 1.0, 0.0, 0.0);

            //se desenează axa OY (negru)
            GL.Color3(0.0, 0.0, 0.0);
            GL.Vertex3(0.0, 0.0,  0.0);
            GL.Vertex3(0.0, 1.0, 0.0);

            //se deseneaza axa OZ(albastru)
            GL.Color3(0.0, 0.0, 1.0);
            GL.Vertex3(0.0, 0.0, 0.0);
            GL.Vertex3(0.0, 0.0, 1.0);

            GL.End();
        }
        [STAThread]
        static void Main(string[] args)
        {
            using (SimpleWindow3D example = new SimpleWindow3D())
            {
                example.Run(30.0, 0.0);
            }
        }
    }

}
