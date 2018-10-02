using System;
using System.Collections.Generic;
using CocosSharp;
using testgame2.Display;
using testgame2.Extension;

using testgame2.Classes;

namespace testgame2.Layers
{
    public class TerrainLayer : AbstractLayer
    {

           
        
        

        public TerrainLayer(GameData gameData)
            : base(gameData, CCColor4B.Black)
        {
            gameData.LoadLevel(this);

            Schedule(RunGameLogic);


        }


        void RunGameLogic(float frameTimeInSeconds)
        {
            environmentInputs.FrameTimeInSeconds = frameTimeInSeconds;
            player.Handleinput(environmentInputs, CurrentLevel);
            GameData.CalculateGameStep();
            CurrentLevel.terrains.RepositionPosition(GameData.RelativeDisplaceMentX, GameData.RelativeDisplacementY);
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

            environmentInputs.CurrentInput.Remove(keyevent.Keys);
        }


        void OnKeyPressed(CCEventKeyboard keyevent)
        {
            environmentInputs.CurrentInput.Add(keyevent.Keys);
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