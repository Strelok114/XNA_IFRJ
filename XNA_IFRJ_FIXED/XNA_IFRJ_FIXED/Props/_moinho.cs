using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XNA_IFRJ.Props;
namespace XNA_IFRJ.Props
{
    internal class _moinho : _square
      
    {
        
        private GraphicsDevice graphicsDevice;

        public _moinho(GraphicsDevice graphicsDevice, Vector3 position)
            : base(graphicsDevice, position)
        {

            // Faz ele ficar Branco
            Color[] colors = new Color[]
            {
                Color.White, Color.White, Color.White,
                Color.White, Color.White, Color.White,
            };
            for (int i = 0; i < verts.Length; i++) // Loop de todos os vertices
            {
                verts[i].Color = Color.White;
            }

            for (int i = 0; i < verts.Length; i++) // Loop de todos os vertices
            {
                verts[i].Position.Y *= 2.0f; // Dobra a Altura do Quadrado
            }

            // vertex modificados
            vertexBuffer = new VertexBuffer(graphicsDevice, typeof(VertexPositionColor), verts.Length, BufferUsage.None);
            vertexBuffer.SetData<VertexPositionColor>(verts);
        }

       
    }
}
