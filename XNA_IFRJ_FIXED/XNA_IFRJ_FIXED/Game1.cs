using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using XNA_IFRJ.Props;
using XNA_IFRJ.Content;
using XNA_IFRJ.Content.Camera;
using Microsoft.Xna.Framework.Content;
using System.Windows.Forms;

namespace XNA_IFRJ
{
    public class Game1 : Game
    {
        Matrix world, view, projection;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Model model;
        Model model2;
        Model model3;
        Model model4;
        Matrix modelMatrix;
        Vector3 modelPos, modelScale;
        float modelAngleY;
        float modelAngleX;
        float modelAngleZ;

        Matrix model2Matrix;
        Vector3 model2Pos, model2Scale;
        float model2AngleY;
        float model2AngleX;
        float model2AngleZ;

        Matrix model3Matrix;
        Vector3 model3Pos, model3Scale;
        float model3AngleY;
        float model3AngleX;
        float model3AngleZ;

        Matrix model4Matrix;
        Vector3 model4Pos, model4Scale;
        float model4AngleY;
        float model4AngleX;
        float model4AngleZ;


        BasicEffect effect;
        _square square;
        _floor floor;
        _square[] squares;
        _moinho[] moinhos;
        _helice[] helices;
        _camera cameraController;
        _moinho moinho;
        _helice helice;
        

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            cameraController = new _camera(new Vector3(0, 0, 5), 0.1f, 0.05f);


        }

        protected override void Initialize()
        {
            effect = new BasicEffect(GraphicsDevice);
            this.world = Matrix.Identity;
            this.world *= Matrix.CreateTranslation(0, 0, 10);
            this.view = Matrix.CreateLookAt(new Vector3(0, 0, 5), Vector3.Zero, Vector3.Up);
            this.projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4,
                Window.ClientBounds.Width / (float)Window.ClientBounds.Height, 1, 100);

            GraphicsDevice.RasterizerState = RasterizerState.CullNone;

            square = new _square(GraphicsDevice, Vector3.Zero);
            floor = new _floor(GraphicsDevice, Vector3.Zero);
            moinho = new _moinho(GraphicsDevice, Vector3.Zero);
            helice = new _helice(GraphicsDevice, Vector3.Zero);

            


            Vector3[] helicePositions = new Vector3[]
          {
                new Vector3(-5, 2, 2),
                new Vector3(5, 2, 2),

          };

            helices = new _helice[helicePositions.Length];

            for (int i = 0; i < helicePositions.Length; i++)
            {
                helices[i] = new _helice(GraphicsDevice, helicePositions[i]);
            }

            squares = new _square[]
            {
              new _square(GraphicsDevice, Vector3.Zero),
            };

            moinhos = new _moinho[]
            {
             new _moinho(GraphicsDevice, new Vector3(-5, 1, 0)),
             new _moinho(GraphicsDevice, new Vector3(5, 1, 0)),
            };

           

            this.modelMatrix = Matrix.Identity;
            this.modelPos = new Vector3(0, -1, -0.1f);
            this.modelScale = new Vector3(0.05f);
            this.modelAngleY = 0;
            this.modelAngleZ = 0;
            this.modelAngleX = 0;

            this.model2Matrix = Matrix.Identity;
            this.model2Pos = new Vector3(10, -28, -10);
            this.model2Scale = new Vector3(0.20f);
            this.model2AngleY = 0;
            this.model2AngleZ = 0;
            this.model2AngleX = -90;

            this.model3Matrix = Matrix.Identity;
            this.model3Pos = new Vector3(-10, -28, -10);
            this.model3Scale = new Vector3(0.20f);
            this.model3AngleY = 0;
            this.model3AngleZ = 0;
            this.model3AngleX = -90;

            this.model4Matrix = Matrix.Identity;
            this.model4Pos = new Vector3(0, -15, -15);
            this.model4Scale = new Vector3(0.50f);
            this.model4AngleY = 0;
            this.model4AngleZ = 0;
            this.model4AngleX = -90;



            this.modelMatrix = Matrix.CreateScale(modelScale)
           * Matrix.CreateRotationY(MathHelper.ToRadians(modelAngleY)) * Matrix.CreateRotationY(MathHelper.ToRadians(modelAngleZ)) 
           * Matrix.CreateRotationY(MathHelper.ToRadians(modelAngleX))
           * Matrix.CreateTranslation(modelPos);

            this.model2Matrix = Matrix.CreateScale(model2Scale)
           * Matrix.CreateRotationY(MathHelper.ToRadians(model2AngleY)) * Matrix.CreateRotationY(MathHelper.ToRadians(model2AngleZ))
           * Matrix.CreateRotationY(MathHelper.ToRadians(model2AngleX))
           * Matrix.CreateTranslation(model2Pos);

            this.model3Matrix = Matrix.CreateScale(model3Scale)
           * Matrix.CreateRotationY(MathHelper.ToRadians(model3AngleY)) * Matrix.CreateRotationY(MathHelper.ToRadians(model3AngleZ))
           * Matrix.CreateRotationY(MathHelper.ToRadians(model3AngleX))
           * Matrix.CreateTranslation(model3Pos);

            this.model4Matrix = Matrix.CreateScale(model4Scale)
          * Matrix.CreateRotationY(MathHelper.ToRadians(model4AngleY)) * Matrix.CreateRotationY(MathHelper.ToRadians(model4AngleZ))
          * Matrix.CreateRotationY(MathHelper.ToRadians(model4AngleX))
          * Matrix.CreateTranslation(model4Pos);

            base.Initialize();
        }


        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            this.model = Content.Load<Model>(@"model\RobotFella");
            this.model2 = Content.Load<Model>(@"model\Windmill");
            this.model3 = Content.Load<Model>(@"model\Windmill");
            this.model4 = Content.Load<Model>(@"model\tower");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == Microsoft.Xna.Framework.Input.ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Escape))
                Exit();

            KeyboardState keyboardState = Keyboard.GetState();

            cameraController.Update(keyboardState, effect);
            view = cameraController.GetViewMatrix();

            foreach (var helice in helices)
            {
                helice.Update(gameTime);
            }

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            effect.World = this.world;
            effect.View = this.view;
            effect.Projection = this.projection;
            effect.VertexColorEnabled = true;
            floor.Draw(effect);

            foreach (var square in squares)
            {
                square.Draw(effect);
            }

            foreach (var moinho in moinhos)
            {
                moinho.Draw(effect);
            }
            foreach (var helice in helices)
            {
                helice.Draw(effect);
            }
            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (BasicEffect be in mesh.Effects)
                {
                    be.EnableDefaultLighting();
                    be.World = modelMatrix * mesh.ParentBone.Transform;
                    be.Projection = projection ;
                    be.View = view; 
                }
                mesh.Draw();
            }
            foreach (ModelMesh mesh in model2.Meshes)
            {
                foreach (BasicEffect be in mesh.Effects)
                {
                    be.EnableDefaultLighting();
                    be.World = model2Matrix * mesh.ParentBone.Transform;
                    be.Projection = projection;
                    be.View = view;
                }
                mesh.Draw();
            }

            foreach (ModelMesh mesh in model3.Meshes)
            {
                foreach (BasicEffect be in mesh.Effects)
                {
                    be.EnableDefaultLighting();
                    be.World = model3Matrix * mesh.ParentBone.Transform;
                    be.Projection = projection;
                    be.View = view;
                }
                mesh.Draw();
            }

            foreach (ModelMesh mesh in model4.Meshes)
            {
                foreach (BasicEffect be in mesh.Effects)
                {
                    be.EnableDefaultLighting();
                    be.World = model4Matrix * mesh.ParentBone.Transform;
                    be.Projection = projection;
                    be.View = view;
                }
                mesh.Draw();
            }



        }
    }
}
