using CocosSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace testgame2.Classes
{
    public class ScreenDetails
    {

        const float DESIRED_WIDTH = 1024.0F;
        const float DESIRED_HEIGHT = 768.0F;

        private CCWindow window;
        private CCApplication application;
        public ScreenDetails(CCApplication application, CCWindow window)
        {
            this.window = window;
            this.application = application;
        }


        public void SetDefaultDesignResolution(CCSceneResolutionPolicy policy = CCSceneResolutionPolicy.ShowAll)
        {
            // This will set the world bounds to be (0,0, w, h)
            // CCSceneResolutionPolicy.ShowAll will ensure that the aspect ratio is preserved
            CCScene.SetDefaultDesignResolution(DESIRED_WIDTH, DESIRED_HEIGHT, policy);


            // Determine whether to use the high or low def versions of our images
            // Make sure the default texel to content size ratio is set correctly
            // Of course you're free to have a finer set of image resolutions e.g (ld, hd, super-hd)
            application.ContentSearchPaths.Remove("hd");
            application.ContentSearchPaths.Remove("ld");
            if (DESIRED_WIDTH < Width)
            {
                application.ContentSearchPaths.Add("hd");
                CCSprite.DefaultTexelToContentSizeRatio = 2.0f;
            }
            else
            {
                application.ContentSearchPaths.Add("ld");
                CCSprite.DefaultTexelToContentSizeRatio = 1.0f;
            }
        }

        public float Width { get { return window.WindowSizeInPixels.Width; } }
        public float Height { get { return window.WindowSizeInPixels.Height; } }
        
        public float MiddleX
        {
            get { return Width / 2; }
        }

        public float MiddleY
        {
            get { return Height / 2; }
        }

 

    }
}
