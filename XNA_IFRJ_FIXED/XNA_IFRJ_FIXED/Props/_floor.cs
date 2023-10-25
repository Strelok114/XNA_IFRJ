using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;


namespace XNA_IFRJ.Props
{
    internal class _floor
{
            private VertexPositionColor[] verts;
            private VertexBuffer vertexBuffer;
            private Vector3 position;

            public _floor(GraphicsDevice graphicsDevice, Vector3 position)
            {
                this.position = position;

                verts = new VertexPositionColor[42];

                //  Parte de Baixo
                verts[0] = new VertexPositionColor(new Vector3(-60, -1, 60), Color.Green);
                verts[1] = new VertexPositionColor(new Vector3(60, -1, -60), Color.Green);
                verts[2] = new VertexPositionColor(new Vector3(60, -1, 60), Color.Green);

                // Parte de Baixo
                verts[3] = new VertexPositionColor(new Vector3(-60, -1, 60), Color.Green);
                verts[4] = new VertexPositionColor(new Vector3(60, -1, -60), Color.Green);
                verts[5] = new VertexPositionColor(new Vector3(-60, -1, -60), Color.Green);


                vertexBuffer = new VertexBuffer(graphicsDevice, typeof(VertexPositionColor), verts.Length, BufferUsage.None);
                vertexBuffer.SetData<VertexPositionColor>(verts);
            }

            public void Draw(BasicEffect effect)
            {
                effect.World = Matrix.CreateTranslation(position);
                effect.CurrentTechnique.Passes[0].Apply();
                effect.GraphicsDevice.SetVertexBuffer(vertexBuffer);
                effect.GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleList, verts, 0, 4);
            }
        }

   }

