using System;
using System.Collections.Generic;
using CocosSharp;
using System.Linq;
using testgame2.Classes;
using GridGame.Movement;

namespace testgame2.Layers
{
    public class PlayerLayer : AbstractLayer
    {
        CCLabel positionDisplay;
        // CCNode playerSprite;
        EntityMovement playerthing;
        bool TacoEaten = false;
        CCNode taco;
        int tacoseaten;
        CCTileMap map;
        CCSpriteSheet characters;

        public PlayerLayer(GameData data )
            : base(data, CCColor4B.Transparent)
        {

  //          characters = new CCSpriteSheet("Iconmap/NEStalgia_Icons_nobackground");
            //characters.Frames


            //var csvFile = new CCTileMapInfo("Iconmap/tutorial.tmx");
            //var fileInfo = new CCTileMapInfo("Iconmap/dudes32.tmx");
            
          //  map = new CCTileMap("Iconmap/moving characters/dudes32.tmx");

            // new code:
            //map.Antialiased = false;
            //playerSprite = map;
            //this.AddChild(map);


            positionDisplay = new CCLabel("", "Arial", 20, CCLabelFormat.SystemFont);
            positionDisplay.PositionX = 30;
            positionDisplay.PositionY = screen.Height - 20;
            positionDisplay.AnchorPoint = CCPoint.AnchorUpperLeft;
            AddChild(positionDisplay);
            playerthing = new EntityMovement(this, screen);

            //playerSprite = new CCSprite("ball");
            //playerSprite.Color = CCColor3B.Orange;
            playerthing.currentSprite.PositionX = screen.MiddleX;
            playerthing.currentSprite.PositionY = screen.MiddleY;
            //AddChild(playerSprite);

            player.CoordinateX = screen.MiddleX;
            player.CoordinateY = screen.MiddleY;


            taco = new CCSprite("taco");
            
            taco.PositionX = MapCalculations.RandomizeCoordinate(playerthing.currentSprite.PositionX, player.CoordinateX, screen.Width, CurrentLevel.LevelWidth, GameData.Log);
            taco.PositionY = MapCalculations.RandomizeCoordinate(playerthing.currentSprite.PositionY, player.CoordinateY, screen.Height, CurrentLevel.LevelHeight, GameData.Log);
            AddChild(taco);

            Schedule(RunGameLogic);

        }
     

        void RunGameLogic(float frameTimeInSeconds)
        {
            
            positionDisplay.Text = $"Tacos eaten: {tacoseaten}";
            playerthing.MoveAndAnimate(frameTimeInSeconds, GameData);

            //playerSprite.currentSprite.PositionX = GameData.PlayerPositionX;
            //playerSprite.PositionY = GameData.PlayerPositionY;
            
            if(TacoEaten)
            {


                taco.PositionX = MapCalculations.RandomizeCoordinate(playerthing.currentSprite.PositionX, player.CoordinateX, screen.Width, CurrentLevel.LevelWidth, GameData.Log);
                taco.PositionY = MapCalculations.RandomizeCoordinate(playerthing.currentSprite.PositionY, player.CoordinateY, screen.Height, CurrentLevel.LevelHeight, GameData.Log);
                tacoseaten++;
                TacoEaten = false;
            }
            else
            {
                taco.PositionX -= GameData.RelativeDisplaceMentX;
                taco.PositionY -= GameData.RelativeDisplacementY;
                TacoEaten = CanPlayerEatTaco(taco, playerthing.currentSprite);
            }


        }

        public bool CanPlayerEatTaco(CCNode taco, CCNode player)
        {
            var tacoPosition = taco.ContentSize;
            var playerPosition  = player.ContentSize;
            return (DoesAxisOverlap(taco.PositionX, tacoPosition.Width, player.PositionX, playerPosition.Width) &&
                DoesAxisOverlap(taco.PositionY, tacoPosition.Height, player.PositionY, playerPosition.Height));
            
        }

        public static bool DoesAxisOverlap(float position1, float dimension1, float position2, float dimension2)
        {
            return (position1 <= position2 + dimension2 && position1 >= position2
                || position1 + dimension1 >= position2 && position1 <= position2);
        }

        protected override void AddedToScene()
        {
            base.AddedToScene();
            // Use the bounds to layout the positioning of our drawable assets
            CCRect bounds = VisibleBoundsWorldspace;
            // Register for touch events
            var touchListener = new CCEventListenerTouchAllAtOnce();
            touchListener.OnTouchesEnded = OnTouchesEnded;
            AddEventListener(touchListener, this);


            var keylistener = new CCEventListenerKeyboard();
            keylistener.OnKeyPressed = OnKeyPressed;
            keylistener.OnKeyReleased = OnKeyReleased;
            AddEventListener(keylistener);


        }

        void OnKeyReleased(CCEventKeyboard keyevent)
        {

           // environmentInputs.CurrentInput.Remove(keyevent.Keys);
        }


        void OnKeyPressed(CCEventKeyboard keyevent)
        {
            //environmentInputs.CurrentInput.Add(keyevent.Keys);
        }

        void OnTouchesEnded(List<CCTouch> touches, CCEvent touchEvent)
        {
            if (touches.Count > 0)
            {
                // Perform touch handling here
            }
        }
        
    }
}