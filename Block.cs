using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallFall
{
    using SharpDX.Toolkit.Graphics;
    using SharpDX.Toolkit.Input;

    class Block : GameObject
    {
        public static int blockHeight = 50;
        public static int blockWidth = 100;


        public Block(BallFall_Game game)
        {
            this.game = game;
            type = GameObjectType.Block;
            myModel = game.assests.GetModel("block", CreateBlockModel);
            pos = new SharpDX.Vector3(0, game.boundaryBottom);
            GetParamsFromModel();
        }

        //***Need to insert the correct arguments****
        public MyModel CreateBlockModel()
        {
            return game.assets.CreateTexturedCube("brickTexture.png", index, blockWidth, blockHeight);
        }  
        
        // Frame update.
        public override void Update(GameTime gameTime)
        {
      
        }

    }
}


