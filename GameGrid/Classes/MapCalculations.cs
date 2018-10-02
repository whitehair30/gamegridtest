using GridGame.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace testgame2.Classes
{
    public static class MapCalculations
    {
        /// <summary>
        /// Calculates the map displacement
        /// </summary>
        /// <param name="NewPosition">is already adjusted for the Velocity</param>
        /// <param name="LowerPlayerCoordinate">Distance of the player to the map edge, before the map stops moving, and the player starts moving</param>
        /// <param name="HigherPlayerCoordinate"></param>
        /// <param name="Veloctiy"></param>
        /// <returns></returns>
        public static float GetMapDisplacement(float NewPosition, float LowerPlayerCoordinate, float HigherPlayerCoordinate, float Veloctiy)
        {
            float oldPosition = NewPosition - Veloctiy;
            if (Veloctiy >= 0)
            {
                if (oldPosition >= HigherPlayerCoordinate || NewPosition <= LowerPlayerCoordinate)
                    return 0F;
                if (oldPosition >= LowerPlayerCoordinate && NewPosition <= HigherPlayerCoordinate)
                {
                    return Veloctiy;
                }
                if (oldPosition <= LowerPlayerCoordinate)
                {
                    return NewPosition - LowerPlayerCoordinate;
                }
                return HigherPlayerCoordinate - oldPosition;
            }
            else
            {
                if (NewPosition >= HigherPlayerCoordinate || oldPosition <= LowerPlayerCoordinate)
                    return 0F;
                if (NewPosition >= LowerPlayerCoordinate && oldPosition <= HigherPlayerCoordinate)
                {
                    return Veloctiy;
                }
                if (NewPosition <= LowerPlayerCoordinate)
                {
                    return LowerPlayerCoordinate - oldPosition;
                }
                return NewPosition - HigherPlayerCoordinate;
            }
        }

        /// <summary>
        /// Calculates the Player position on the screen
        /// </summary>
        /// <param name="NewCoorinate"></param>
        /// <param name="LowerCoordinate"></param>
        /// <param name="HigherCoordinate"></param>
        /// <param name="MiddlePosition"></param>
        /// <returns></returns>
        public static float GetRelativePlayerPosition(float NewCoorinate, float LowerCoordinate, float HigherCoordinate, float MiddlePosition)
        {
            if (NewCoorinate < LowerCoordinate)
            {
                return NewCoorinate;
            }
            if (NewCoorinate > HigherCoordinate)
            {
                return NewCoorinate - HigherCoordinate + MiddlePosition;
            }
            return MiddlePosition;
        }



        private static Random tacoCalc = new Random();
        public static float RandomizeCoordinate(float playerPosition, float PlayerCoordinate, float screenDimension, float mapDimension, ILogging log)
        {
            float returnval = -1;
            int lastFiftyProcent;
            lastFiftyProcent = tacoCalc.Next(50);
            bool IsIncrease = lastFiftyProcent % 2 == 0;
            returnval = GetDistanceWithRandom(screenDimension, lastFiftyProcent, IsIncrease);
            log.Debug($"POS {playerPosition} COOR { PlayerCoordinate} DIM {screenDimension} MAP {mapDimension} CHANGE POS {returnval}");
            if (!IsNewSeedAcceptable(PlayerCoordinate, mapDimension, returnval))
            {
                log.Debug("CHANGE INVERSED");
                returnval *= -1 ;
            }
            return playerPosition += returnval;
        }

        public static float GetDistanceWithRandom(float screenSize, int random, bool IsIncrease)
        {
            if(IsIncrease)
            {
                return screenSize / 200F * (50F + random);
            }
            else
            {
                return -(screenSize / 200F * (50F + random));
            }
        }

        public static bool IsNewSeedAcceptable( float PlayerCoordinate, float mapDimension, float delta)
        {
            float adjusteval = PlayerCoordinate += delta;
            return (adjusteval > 0 && adjusteval < mapDimension) ;
        }

    }
}
