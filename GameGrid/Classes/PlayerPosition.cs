using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace testgame2.Classes
{
    public class PlayerPosition
    {

        public float VelocityX { get; private set; }
        public float VelocityY { get; private set; }

        public float CoordinateX { get; set; }
        public float CoordinateY { get; set; }

        const float MAX_VELOCITY = 10;

        public int FacingDirection { get; private set; } = 4;

        float leftVelocityX = 0;
        float rightVelocityX = 0;
        float upVelocityY = 0;
        float downVelocityY = 0;


        float tempVelocityX { get { return (rightVelocityX - leftVelocityX); } }
        float tempVelocityY { get { return (upVelocityY - downVelocityY); } }

        bool IsVelocityXPositive { get { return tempVelocityX > 0; } }
        bool IsVelocityYPositive { get { return tempVelocityY > 0; } }
        
        public void Handleinput(EnvironmentInputs inputs, Level level)
        {
            bool leftButtonDown = inputs.CurrentInput.Contains(CocosSharp.CCKeys.Left);
            bool rightButtonDown = inputs.CurrentInput.Contains(CocosSharp.CCKeys.Right);
            bool upButtonDown = inputs.CurrentInput.Contains(CocosSharp.CCKeys.Up);
            bool downButtonDown = inputs.CurrentInput.Contains(CocosSharp.CCKeys.Down);

            leftVelocityX = UpdateVelocity(leftButtonDown, leftVelocityX);
            rightVelocityX = UpdateVelocity(rightButtonDown, rightVelocityX);
            upVelocityY = UpdateVelocity(upButtonDown, upVelocityY);
            downVelocityY = UpdateVelocity(downButtonDown, downVelocityY);

            // adjust for max total speed
            var reduction = GetSpeedReduction(tempVelocityX, tempVelocityY);
            
            // adjust for level's edge
            VelocityX = AdjustVelocityForlevelEdge(CoordinateX, tempVelocityX, level.LevelWidth, reduction.ReductionX);
            VelocityY = AdjustVelocityForlevelEdge(CoordinateY, tempVelocityY, level.LevelHeight, reduction.ReductionY);

            // direction of the character
            FacingDirection = GetDirectionIndexFourDirections(reduction.Angle, VelocityX, VelocityY);

            // set position 
            CoordinateX += VelocityX;
            CoordinateY += VelocityY;
            
        }
        static double angle45degree = Math.PI * 45.0 / 180;
        static double angle90degree = Math.PI * 90.0 / 180;
        public static int GetDirectionIndexFourDirections(double angle, float velocityX, float velocityY)
        {
            int directionChange;
            if (velocityY > 0)
            {
                if (velocityX > 0)
                {
                    angle = (angle90degree - angle);
                }
                directionChange = (velocityX > 0 ? 0 : 3);
            }
            else
            {
                if(velocityX<0)
                {
                    angle = (angle90degree - angle);
                }
                directionChange = (velocityX > 0 ? 1 : 2);
            }
            directionChange += (angle > angle45degree ? 1 : 0);
            return directionChange % 4;
        }

        //public static int GetDirectionIndex(double angle, float velocityX, float velocityY)
        //{
        //    int directionChange;
        //    if (velocityY > 0)
        //    {
        //        angle = (90.0 - angle);
        //        directionChange = (velocityX > 0 ? 0 : 6);
        //    }
        //    else
        //    {
        //        directionChange = (velocityX > 0 ? 2 : 4);
        //    }
        //    directionChange += (angle > 67.5 ? 2 : (angle > 22.4 ? 1 : 0));
        //    return directionChange;
        //}



        public static float AdjustVelocityForlevelEdge(float currentPostion, float newVelocity, float dimensionLength, float reductionFactor)
        {
            newVelocity -= reductionFactor;
            if(currentPostion + newVelocity < 0)
            {
                return -currentPostion;
            }
            if(currentPostion + newVelocity > dimensionLength)
            {
                return dimensionLength - currentPostion;
            }
            return newVelocity;
        }


        private static float UpdateVelocity(bool relevantButtonPreessed, float currentVelocity)
        {
            if (relevantButtonPreessed && currentVelocity < MAX_VELOCITY)
            {
                currentVelocity++;
            }
            else if (!relevantButtonPreessed && currentVelocity > 0)
            {
                currentVelocity--;
            }
            return currentVelocity;
        }

        public static AngleReduction GetSpeedReduction(float tempVelocityX, float tempVelocityY)
        {
            var returnVal = new AngleReduction();
            var angle = Math.Atan(tempVelocityY / tempVelocityX);
            returnVal.Angle = angle;
            if (tempVelocityX * tempVelocityX + tempVelocityY * tempVelocityY > MAX_VELOCITY * MAX_VELOCITY)
            {
                var newX = Math.Cos(angle) * MAX_VELOCITY;
                var newY = Math.Sin(angle) * MAX_VELOCITY;
                if (tempVelocityX < 0)
                {
                    newX *= -1;
                    newY *= -1;
                }
                returnVal.ReductionX = tempVelocityX - (float)newX;
                returnVal.ReductionY = tempVelocityY - (float)newY;
            }
            return returnVal;    
        }

        public class AngleReduction
        {
            public AngleReduction()
            {
                ReductionX = 0;
                ReductionY = 0;
            }
            public float ReductionX { get; set; }
            public float ReductionY { get; set; }
            public double Angle { get; set; }

        }

    }
}
