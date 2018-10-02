using CocosSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using testgame2.Extension;

namespace testgame2.Display
{
    public class DisplayTerrain :CCNode
    {
        // still ugl, and dificult to create. 
        static Random randomizer = new Random(219837371);
        private static int GetRandom(int x, int y)
        {
            if(randomizer.Next(100) > 95)
            {
                return 4;
            }
            return (x * y) % 4;
        }

        static DisplayTerrain()
        {
            defaultTerrain = new int[20, 20];
            defaultTerrain.FillWithDefault(GetRandom);

          
            defaultTypes = new Dictionary<int, string>
            {
                {0, "weed1" },
                {1, "weed2" },
                {2, "weed3" },
                {3, "weed4" },
                {4, "bush" }
            };
        }
        public static int[,] defaultTerrain;
        public static Dictionary<int, string> defaultTypes;


        private CCSprite[,] sprites;



        public DisplayTerrain(Dictionary<int, string> spriteKey, int[,] terrainMap)
        : base()
        {
            float width = 0f;
            float height = 0f;
            sprites = new CCSprite[terrainMap.GetLength(0), terrainMap.GetLength(1)];
            for (int x = 0; x < terrainMap.GetLength(0); x++)
            {

                for (int y = 0; y < terrainMap.GetLength(1); y++)
                {
                    var terrainSprite = spriteKey[terrainMap[x, y]];
                    var grassSprite = new CCSprite(terrainSprite);
                    if (y==0)
                    {
                        width += grassSprite.ContentSize.Width;
                    }
                    if (x == 0)
                    {
                        height += grassSprite.ContentSize.Height;
                    }
                    grassSprite.PositionX = grassSprite.ContentSize.Center.X + grassSprite.ContentSize.Width * x;
                    grassSprite.PositionY = grassSprite.ContentSize.Center.Y + grassSprite.ContentSize.Height * y;
                    AddChild(grassSprite);
                    sprites[x, y] = grassSprite;
                }
            }
            this.ContentSize = new CCSize(width, height);
        }

        public DisplayTerrain(Dictionary<int, string> spriteKey, int[,] terrainMap, CCLayerColor layer  )
            : this (spriteKey, terrainMap) 
        {
          
           
        }

        public DisplayTerrain()
       : this(defaultTypes, defaultTerrain)
        {

        }



    }
}
