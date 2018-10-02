using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using testgame2.Display;
using testgame2.Extension;
using testgame2.Layers;

namespace testgame2.Classes
{
    public class Level
    {
        public float LevelWidth { get; set; }
        public float LevelHeight { get; set; }

        

        public DisplayTerrain[,] terrains { get; set; }

        public void InitiateLevel(AbstractLayer terrainLayer, int dimensionX, int dimensionY)
        {
            terrains = new DisplayTerrain[dimensionX, dimensionY];
            terrains.FillWithDefault(terrainLayer);
            terrains.SetPosition();

            LevelWidth = terrains[0, 0].ContentSize.Width * dimensionX;
            LevelHeight = terrains[0, 0].ContentSize.Height * dimensionY;
        }

     
    }
}
