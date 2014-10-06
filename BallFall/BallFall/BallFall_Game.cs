using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SharpDX;
using SharpDX.Toolkit;

namespace BallFall 
{
    using SharpDX.Toolkit.Graphics;
    using SharpDX.Toolkit.Input;

    class BallFall_Game : Game
    {
        private GraphicsDeviceManager graphicsDeviceManager;
        private KeyboardManager keyboardManager;
        private KeyboardState keyboardState;
   
        //Initializes the game
        public BallFall_Game()
        {
            // Creates a graphics manager. This is mandatory.
            graphicsDeviceManager = new GraphicsDeviceManager(this);

            // Setup the relative directory to the executable directory
            // for loading contents with the ContentManager
            Content.RootDirectory = "Content";

            // Create the keyboard manager
            keyboardManager = new KeyboardManager(this);
        }

        //Loads the game content
        protected override void LoadContent()
        {

            //model = new Landscape(this, 6.0f, 1.0f);
            
            base.LoadContent();
        }

        protected override void Initialize()
        {
            Window.Title = "Project 1";

            base.Initialize();
        }

        protected override void Update(GameTime gameTime)
        {
            keyboardState = keyboardManager.GetState();

            //model.Update(gameTime);

            // Handle base.Update
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // Clears the screen with the Color.CornflowerBlue
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //model.Draw(gameTime);

            // Handle base.Draw
            base.Draw(gameTime);
        }
    }
}
