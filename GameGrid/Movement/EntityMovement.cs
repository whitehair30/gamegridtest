using CocosSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testgame2.Classes;

namespace GridGame.Movement
{
    public class EntityMovement
    {
        CCSpriteSheet charactersheet;
        public CCNode currentSprite { get; set; }
        private CCNode parent;
        private bool isLeft;
        private float timeelapsed;
        private string previousImage;
        public EntityMovement(CCNode parent, ScreenDetails screen)
        {
            previousImage = "leftstill.png";
            charactersheet = new CCSpriteSheet("Iconmap/mexicanmovement.plist", "Iconmap/mexicanmovement.png");
            var frame = charactersheet.Frames.Find(item => item.TextureFilename == previousImage);
            currentSprite = new CCSprite(frame);
            isLeft = true;
            this.parent = parent;
            parent.AddChild(currentSprite);
            timeelapsed = 0.0F;

        }

        public void MoveAndAnimate(float time, GameData game)
        {
            string direction;
            string movement;

            timeelapsed += time;
            
            switch(game.Player.FacingDirection)
            {
                case 1:
                    direction = "right";
                    break;
                case 2:
                    direction = "down";
                    break;
                case 3:
                    direction = "left";
                    break;
                case 0:
                    direction = "up";
                    break;
                default:
                    throw new NotImplementedException($"direction is {game.Player.FacingDirection }");
            }
            
            if (game.Player.VelocityX != 0 || game.Player.VelocityY != 0)
            {
                int step = Convert.ToInt32((timeelapsed * 6.0F)) % 3 + 1;
                movement = step.ToString();
            }
            else
                movement = "still";


            string newStep = $"{direction}{movement}.png";
            if (!previousImage.Equals(newStep))
            {
                currentSprite.RemoveFromParent();
                currentSprite.Dispose();
                currentSprite = new CCSprite(charactersheet.Frames.Find(item => item.TextureFilename == newStep));
                parent.AddChild(currentSprite);
            }
            
            currentSprite.PositionX = game.PlayerPositionX;
            currentSprite.PositionY = game.PlayerPositionY;
        }
        //public EntityMovement(CCNode parent, ScreenDetails screen)
        //{

        //    charactersheet = new CCSpriteSheet("Iconmap/NEStalgia_Icons_nobackground.plist", "Iconmap/NEStalgia_Icons_nobackground.png");
        //    var frame = charactersheet.Frames.Find(item => item.TextureFilename == "left.png");
        //    currentSprite = new CCSprite(frame);
        //    isLeft = true;
        //    this.parent = parent;
        //    parent.AddChild(currentSprite);
        //    timeelapsed = 0.0F;

        //}

        //public void MoveAndAnimate(float time, GameData game)
        //{
        //    timeelapsed += time;
        //    if (timeelapsed % 1.0F > 0.5F && isLeft)
        //    {
        //        currentSprite.RemoveFromParent();
        //        currentSprite.Dispose();
        //        isLeft = false;
        //        currentSprite = new CCSprite(charactersheet.Frames.Find(item => item.TextureFilename == "right.png"));
        //        parent.AddChild(currentSprite);
        //    }
        //    else if (timeelapsed % 1.0F < 0.5F && !isLeft)
        //    {
        //        currentSprite.RemoveFromParent();
        //        currentSprite.Dispose();
        //        isLeft = true;
        //        currentSprite = new CCSprite(charactersheet.Frames.Find(item => item.TextureFilename == "left.png"));
        //        parent.AddChild(currentSprite);
        //    }

        //    currentSprite.PositionX = game.PlayerPositionX;
        //    currentSprite.PositionY = game.PlayerPositionY;
        //}


    }
}
