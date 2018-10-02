using System.Reflection;
using Microsoft.Xna.Framework;
using CocosSharp;
using CocosDenshion;
using testgame2.Display;
using testgame2.Classes;
using testgame2.Layers;
using GridGame.Library.Classes;

namespace testgame2
{
    public class AppDelegate : CCApplicationDelegate
    {

        public override void ApplicationDidFinishLaunching(CCApplication application, CCWindow mainWindow)
        {
            application.ContentRootDirectory = "Content";

            var screen = new ScreenDetails(application, mainWindow);

            var logger = new ConsoleLogger(GridGame.Library.Enums.LogLevel.debug);
            GameData gameData = new GameData(logger)
            {
                Screen = screen,
                Input = new EnvironmentInputs(),
                Player = new PlayerPosition(),
            };


            screen.SetDefaultDesignResolution();

            
            var scene = new CCScene(mainWindow);
            var introLayer = new TerrainLayer(gameData);
            var playerLayer = new PlayerLayer(gameData);

            scene.AddChild(introLayer);
            scene.AddChild(playerLayer);

            mainWindow.RunWithScene(scene);
        }





        public override void ApplicationDidEnterBackground(CCApplication application)
        {
            application.Paused = true;
        }

        public override void ApplicationWillEnterForeground(CCApplication application)
        {
            application.Paused = false;
        }
        
    }
}