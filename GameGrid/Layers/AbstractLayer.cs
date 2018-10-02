using CocosSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using testgame2.Classes;

namespace testgame2.Layers
{
    public abstract class AbstractLayer : CCLayerColor
    {
        protected GameData GameData { get; private set; }
        protected EnvironmentInputs environmentInputs { get { return GameData.Input; } }
        protected PlayerPosition player { get { return GameData.Player; } }
        protected ScreenDetails screen { get { return GameData.Screen; } }
        protected Level CurrentLevel { get { return GameData.CurrentLevel; } }
        public AbstractLayer(GameData gameData, CCColor4B color)
            : base (color)
        {
            this.GameData = gameData;
        }

    }
}
