using CocosSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace testgame2.Classes
{
    public class EnvironmentInputs
    {
        public HashSet<CCKeys> CurrentInput { get; set; }

        public float FrameTimeInSeconds { get; set; }

        public EnvironmentInputs()
        {
            CurrentInput = new HashSet<CCKeys>();
        }
    }
}
