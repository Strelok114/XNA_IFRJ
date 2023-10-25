using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace XNA_IFRJ.Content.Camera
{
    internal class _camera
    {
        private Vector3 cameraPosition;
        private float cameraSpeed;
        private float cameraSpeedBackward;

        public _camera(Vector3 initialPosition, float speed, float speedBackward)
        {
            cameraPosition = initialPosition;
            cameraSpeed = speed;
            cameraSpeedBackward = speedBackward;
        }

        public Matrix GetViewMatrix()
        {
            Vector3 cameraForward = Vector3.Transform(Vector3.Forward, Matrix.CreateFromYawPitchRoll(0, 0, 0));
            Vector3 cameraTarget = cameraPosition + cameraForward;
            return Matrix.CreateLookAt(cameraPosition, cameraTarget, Vector3.Up);
        }

        public void Update(KeyboardState keyboardState, BasicEffect effect)
        {
            if (keyboardState.IsKeyDown(Keys.Left))
                cameraPosition.X -= cameraSpeed;
            if (keyboardState.IsKeyDown(Keys.Right))
                cameraPosition.X += cameraSpeed;
            if (keyboardState.IsKeyDown(Keys.Up))
                cameraPosition.Y += cameraSpeed;
            if (keyboardState.IsKeyDown(Keys.Down))
                cameraPosition.Y -= cameraSpeed;
            if (keyboardState.IsKeyDown(Keys.W))
                cameraPosition += cameraSpeed * Vector3.Forward; // Move forward
            if (keyboardState.IsKeyDown(Keys.S))
                cameraPosition -= cameraSpeedBackward * Vector3.Forward; // Move backward

            effect.View = GetViewMatrix();
        }
    }
}
