using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;


namespace Ababi_Exerciutiu_8
{
    class SimpleWindow3D : GameWindow
    {
        private static Color triangleColor = Color.Red;
        private static float rotationAngle = 0.0f;
        private float[][] vertices;

        public SimpleWindow3D() : base(800, 600)
        {
            VSync = VSyncMode.On;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(Color.White);
            vertices = ReadVerticesFromFile("Vertex.txt");

        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, Width, Height);
            double aspect_ratio = Width / (double)Height;
            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver6, (float)aspect_ratio, 1, 256);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspective);
        }
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            var keyboard = Keyboard.GetState();
            var mouse = Mouse.GetState();

            if (keyboard.IsKeyDown(Key.R))
            {
                triangleColor = Color.Red;
            }
            else if (keyboard.IsKeyDown(Key.G))
            {
                triangleColor = Color.Green;
            }
            else if (keyboard.IsKeyDown(Key.B))
            {
                triangleColor = Color.Blue;
            }

            rotationAngle += (float)e.Time * 50.0f * mouse.X;
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.Rotate(rotationAngle, Vector3.UnitZ);

            GL.Begin(PrimitiveType.Triangles);

            GL.Color3(triangleColor.R / 255.0, triangleColor.G / 255.0, triangleColor.B / 255.0);

            foreach (var vertex in vertices)
            {
                GL.Vertex2(vertex[0], vertex[1]);
            }

            GL.End();
            SwapBuffers();
        }

        private float[][] ReadVerticesFromFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    var verticesList = new List<float[]>();

                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        if (line.StartsWith("v "))
                        {
                            string[] parts = line.Split(' ');
                            if (parts.Length == 4)
                            {
                                float x = float.Parse(parts[1], CultureInfo.InvariantCulture);
                                float y = float.Parse(parts[2], CultureInfo.InvariantCulture);
                                float z = float.Parse(parts[3], CultureInfo.InvariantCulture);

                                verticesList.Add(new float[] { x, y, z });
                            }
                        }
                    }

                    return verticesList.ToArray();
                }
            }
            else
            {
                Console.WriteLine("Fisierul nu exista.");
                return new float[0][];
            }
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
