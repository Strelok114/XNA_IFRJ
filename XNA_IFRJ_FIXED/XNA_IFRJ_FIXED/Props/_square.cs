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

    internal class _square
{

    protected VertexPositionColor[] verts;
    protected VertexBuffer vertexBuffer;
    protected Vector3 position;

    public _square(GraphicsDevice graphicsDevice, Vector3 position)
    {
        this.position = position;

        verts = new VertexPositionColor[42];

        // Define vertices for the front face (Triangle 1)
        verts[0] = new VertexPositionColor(new Vector3(-1, 1, 1), Color.Red);
        verts[1] = new VertexPositionColor(new Vector3(1, 1, 1), Color.Green);
        verts[2] = new VertexPositionColor(new Vector3(1, -1, 1), Color.Blue);

        // Define vertices for the front face (Triangle 2)
        verts[3] = new VertexPositionColor(new Vector3(-1, 1, 1), Color.Red);
        verts[4] = new VertexPositionColor(new Vector3(1, -1, 1), Color.Blue);
        verts[5] = new VertexPositionColor(new Vector3(-1, -1, 1), Color.Yellow);

        // Define vertices for the back face (Triangle 1)
        verts[6] = new VertexPositionColor(new Vector3(-1, 1, -1), Color.Red);
        verts[7] = new VertexPositionColor(new Vector3(1, 1, -1), Color.Green);
        verts[8] = new VertexPositionColor(new Vector3(1, -1, -1), Color.Blue);

        // Define vertices for the back face (Triangle 2)
        verts[9] = new VertexPositionColor(new Vector3(-1, 1, -1), Color.Red);
        verts[10] = new VertexPositionColor(new Vector3(1, -1, -1), Color.Blue);
        verts[11] = new VertexPositionColor(new Vector3(-1, -1, -1), Color.Yellow);

        // Define vertices for the left side face (facing left)
        verts[12] = new VertexPositionColor(new Vector3(-1, 1, 1), Color.Red);
        verts[13] = new VertexPositionColor(new Vector3(-1, -1, 1), Color.Green);
        verts[14] = new VertexPositionColor(new Vector3(-1, -1, -1), Color.Blue);

        // Define vertices for the left side face (continuation)
        verts[15] = new VertexPositionColor(new Vector3(-1, 1, 1), Color.Red);
        verts[16] = new VertexPositionColor(new Vector3(-1, -1, -1), Color.Blue);
        verts[17] = new VertexPositionColor(new Vector3(-1, 1, -1), Color.Yellow);

        // Define vertices for the right side face (facing right)
        verts[18] = new VertexPositionColor(new Vector3(1, 1, 1), Color.Red);
        verts[19] = new VertexPositionColor(new Vector3(1, -1, -1), Color.Green);
        verts[20] = new VertexPositionColor(new Vector3(1, -1, 1), Color.Blue);

        // Define vertices for the right side face (continuation)
        verts[21] = new VertexPositionColor(new Vector3(1, 1, 1), Color.Red);
        verts[22] = new VertexPositionColor(new Vector3(1, 1, -1), Color.Green);
        verts[23] = new VertexPositionColor(new Vector3(1, -1, -1), Color.Yellow);

        // Parte de Cima
        verts[24] = new VertexPositionColor(new Vector3(-1, 1, 1), Color.Red);
        verts[25] = new VertexPositionColor(new Vector3(1, 1, -1), Color.Green);
        verts[26] = new VertexPositionColor(new Vector3(1, 1, 1), Color.Blue);

        // Parte de Cima
        verts[27] = new VertexPositionColor(new Vector3(-1, 1, 1), Color.Red);
        verts[28] = new VertexPositionColor(new Vector3(1, 1, -1), Color.Green);
        verts[29] = new VertexPositionColor(new Vector3(-1, 1, -1), Color.Yellow);

        //  Parte de Baixo
        verts[30] = new VertexPositionColor(new Vector3(-1, -1, 1), Color.Red);
        verts[31] = new VertexPositionColor(new Vector3(1, -1, -1), Color.Green);
        verts[32] = new VertexPositionColor(new Vector3(1, -1, 1), Color.Blue);

        // Parte de Baixo
        verts[33] = new VertexPositionColor(new Vector3(-1, -1, 1), Color.Red);
        verts[34] = new VertexPositionColor(new Vector3(1, -1, -1), Color.Green);
        verts[35] = new VertexPositionColor(new Vector3(-1, -1, -1), Color.Yellow);


        vertexBuffer = new VertexBuffer(graphicsDevice, typeof(VertexPositionColor), verts.Length, BufferUsage.None);
        vertexBuffer.SetData<VertexPositionColor>(verts);
    }

    public void Draw(BasicEffect effect)
    {
        effect.World = Matrix.CreateTranslation(position);
        effect.CurrentTechnique.Passes[0].Apply();
        effect.GraphicsDevice.SetVertexBuffer(vertexBuffer);
        effect.GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleList, verts, 0, 14);
    }
}
}
