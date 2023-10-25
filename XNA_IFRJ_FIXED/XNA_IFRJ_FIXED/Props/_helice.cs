using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace XNA_IFRJ.Props
{
    internal class _helice
    {
        protected VertexPositionColor[] verts;
        protected VertexBuffer vertexBuffer;
        protected Vector3 position;
        protected float rotationAngle; // Add a rotation angle for Z-axis rotation
        protected float scale; // Add a scaling factor

        public _helice(GraphicsDevice graphicsDevice, Vector3 position)
        {
            this.position = position;
            rotationAngle = 0.0f; // Initialize the rotation angle to 0
            scale = 0.5f; // Adjust the scale as needed

            verts = new VertexPositionColor[6]; // Use 6 vertices for two rectangles

            // Define vertices for the first rectangle (longer in Y-axis)
            verts[0] = new VertexPositionColor(new Vector3(-1, 6, 0) * scale, Color.Red);
            verts[1] = new VertexPositionColor(new Vector3(1, 6, 0) * scale, Color.Green);
            verts[2] = new VertexPositionColor(new Vector3(-1, -6, 0) * scale, Color.Blue);
            verts[3] = new VertexPositionColor(new Vector3(1, 6, 0) * scale, Color.Green);
            verts[4] = new VertexPositionColor(new Vector3(-1, -6, 0) * scale, Color.Blue);
            verts[5] = new VertexPositionColor(new Vector3(1, -6, 0) * scale, Color.Blue);

            vertexBuffer = new VertexBuffer(graphicsDevice, typeof(VertexPositionColor), verts.Length, BufferUsage.None);
            vertexBuffer.SetData<VertexPositionColor>(verts);
        }

        public void Update(GameTime gameTime)
        {
            float rotationSpeed = 0.1f;
            rotationAngle += rotationSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public void Draw(BasicEffect effect)
        {
            // Apply Z-axis rotation and scaling in the world matrix
            effect.World = Matrix.CreateScale(scale) * Matrix.CreateRotationZ(rotationAngle) * Matrix.CreateTranslation(position);
            effect.CurrentTechnique.Passes[0].Apply();
            effect.GraphicsDevice.SetVertexBuffer(vertexBuffer);
            effect.GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleList, verts, 0, 2); // Draw both rectangles
        }
    }
}
