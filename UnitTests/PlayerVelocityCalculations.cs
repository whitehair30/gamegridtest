using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using testgame2.Classes;

namespace UnitTests
{
  [TestClass]
    public class PlayerVelocityCalculations
    {
        [TestMethod]
        public void CalculatePlayerPosition_AboveLowerCoordinate()
        {
            float NewPosition = 105;
            float LowerCoordinate = 100;
            float HigherCoordinate = 200;
            float MiddlePositionScreen = 100;
            float ExpectedScreenPosition = 100;
            var CalculatedScreenPosition = MapCalculations.GetRelativePlayerPosition(NewPosition, LowerCoordinate,HigherCoordinate, MiddlePositionScreen);
            Assert.AreEqual(ExpectedScreenPosition, CalculatedScreenPosition);

        }

        [TestMethod]
        public void CalculatePlayerPosition_BelowLowerCoordinate()
        {
            float NewPosition = 95;
            float LowerCoordinate = 100;
            float HigherCoordinate = 200;
            float MiddlePositionScreen = 100;
            float ExpectedScreenPosition = 95;
            var CalculatedScreenPosition = MapCalculations.GetRelativePlayerPosition(NewPosition, LowerCoordinate, HigherCoordinate, MiddlePositionScreen);
            Assert.AreEqual(ExpectedScreenPosition, CalculatedScreenPosition);

        }

        [TestMethod]
        public void CalculatePlayerPosition_AboveHigherCoordinate()
        {
            float NewPosition = 205;
            float LowerCoordinate = 100;
            float HigherCoordinate = 200;
            float MiddlePositionScreen = 100;
            float ExpectedScreenPosition = 105;
            var CalculatedScreenPosition = MapCalculations.GetRelativePlayerPosition(NewPosition, LowerCoordinate, HigherCoordinate, MiddlePositionScreen);
            Assert.AreEqual(ExpectedScreenPosition, CalculatedScreenPosition);

        }

        [TestMethod]
        public void AdjustVelocityForCalculation_CloseToLowerEdge_NegativeVelocity_VelocityAdjusted()
        {

            float CurrentPosition = 4;
            float NewVelocity = -10;
            float DimensionLength = 200;
            float ExpectedAdjustedVelocity = -4;
            float ReductionFactor = 0;
            var CalculatedAdjustedVelocity = PlayerPosition.AdjustVelocityForlevelEdge(CurrentPosition, NewVelocity, DimensionLength, ReductionFactor);
            Assert.AreEqual(ExpectedAdjustedVelocity, CalculatedAdjustedVelocity);
        }

        [TestMethod]
        public void AdjustVelocityForCalculation_CloseToLowerEdge_PositiveVelocity_NoVelocityChange()
        {

            float CurrentPosition = 5;
            float NewVelocity = 10;
            float DimensionLength = 200;
            float ExpectedAdjustedVelocity = 10;
            float ReductionFactor = 0;
            var CalculatedAdjustedVelocity = PlayerPosition.AdjustVelocityForlevelEdge(CurrentPosition, NewVelocity, DimensionLength, ReductionFactor);
            Assert.AreEqual(ExpectedAdjustedVelocity, CalculatedAdjustedVelocity);
        }

        [TestMethod]
        public void AdjustVelocityForCalculation_CloseToUpperEdge_PositiveVelocity_VelocityAdjusted()
        {

            float CurrentPosition = 196;
            float NewVelocity = 10;
            float DimensionLength = 200;
            float ReductionFactor = 0;
            float ExpectedAdjustedVelocity = 4;
            var CalculatedAdjustedVelocity = PlayerPosition.AdjustVelocityForlevelEdge(CurrentPosition, NewVelocity, DimensionLength, ReductionFactor);
            Assert.AreEqual(ExpectedAdjustedVelocity, CalculatedAdjustedVelocity);
        }


        [TestMethod]
        public void AdjustVelocityForCalculation_CloseToUpperEdge_NegativeVelocity_NoVelocityChange()
        {

            float CurrentPosition = 196;
            float NewVelocity = -10;
            float DimensionLength = 200;
            float ReductionFactor = 0;
            float ExpectedAdjustedVelocity = -10;
            var CalculatedAdjustedVelocity = PlayerPosition.AdjustVelocityForlevelEdge(CurrentPosition, NewVelocity, DimensionLength, ReductionFactor);
            Assert.AreEqual(ExpectedAdjustedVelocity, CalculatedAdjustedVelocity);
        }


        [TestMethod]
        public void AdjustVelocityForCalculation_AdjustForReductionFactor_PositiveVelocity()
        {

            float CurrentPosition = 100;
            float NewVelocity = 10;
            float DimensionLength = 200;
            float ReductionFactor = 2;
            float ExpectedAdjustedVelocity = 8;
            var CalculatedAdjustedVelocity = PlayerPosition.AdjustVelocityForlevelEdge(CurrentPosition, NewVelocity, DimensionLength, ReductionFactor);
            Assert.AreEqual(ExpectedAdjustedVelocity, CalculatedAdjustedVelocity);
        }

        [TestMethod]
        public void AdjustVelocityForCalculation_AdjustForReductionFactor_NegativeVelocity()
        {

            float CurrentPosition = 100;
            float NewVelocity = -10;
            float DimensionLength = 200;
            float ReductionFactor = -2;
            float ExpectedAdjustedVelocity = -8;
            var CalculatedAdjustedVelocity = PlayerPosition.AdjustVelocityForlevelEdge(CurrentPosition, NewVelocity, DimensionLength, ReductionFactor);
            Assert.AreEqual(ExpectedAdjustedVelocity, CalculatedAdjustedVelocity);
        }

        [TestMethod]
        public void TestAngleCalculations()
        {
            //  var sinval = Math.Sin(45.0);

            var angle =  Math.Atan(1);
            var cosval = Math.Cos(angle);
            var sinval = Math.Sin(angle);
            Assert.AreEqual(Math.Round(cosval,6, MidpointRounding.AwayFromZero), Math.Round(sinval, 6, MidpointRounding.AwayFromZero));

        }

        [TestMethod]
        public void Calculate_reductionfactor_negative_withnegative()
        {
            float XVelocity = -8;
            float YVelocity = -8;
            double angle = Math.Atan(1);
            var totalVal = Math.Sqrt(XVelocity * XVelocity + YVelocity * YVelocity);
            float ExpectedReduction = (float)((Math.Cos(angle) * totalVal - Math.Cos(angle) * 10));
            var CalculatedReduction = PlayerPosition.GetSpeedReduction(XVelocity, YVelocity);
            Assert.AreEqual(Math.Round(-ExpectedReduction, 6, MidpointRounding.AwayFromZero), Math.Round(CalculatedReduction.ReductionY, 6, MidpointRounding.AwayFromZero));
            Assert.AreEqual(Math.Round(-ExpectedReduction, 6, MidpointRounding.AwayFromZero), Math.Round(CalculatedReduction.ReductionX, 6, MidpointRounding.AwayFromZero));
        }


        [TestMethod]
        public void Calculate_reductionfactor_negative_withnegative_nochange()
        {

            float XVelocity = -4;
            float YVelocity = -4;
            float ExpectedReduction = 0;
            var CalculatedReduction = PlayerPosition.GetSpeedReduction(XVelocity, YVelocity);
            Assert.AreEqual(ExpectedReduction, CalculatedReduction.ReductionX);
        }


        [TestMethod]
        public void Calculate_reductionfactor_negative_withpositive()
        {

            float XVelocity = -8;
            float YVelocity = 8;
            double angle = Math.Atan(1);
            var totalVal = Math.Sqrt(XVelocity * XVelocity + YVelocity * YVelocity);
            float ExpectedReduction = (float)((Math.Cos(angle) * totalVal - Math.Cos(angle) * 10));
            var CalculatedReduction = PlayerPosition.GetSpeedReduction(XVelocity, YVelocity);
            Assert.AreEqual(Math.Round(ExpectedReduction, 6, MidpointRounding.AwayFromZero), Math.Round(CalculatedReduction.ReductionY, 6, MidpointRounding.AwayFromZero));
            Assert.AreEqual(Math.Round(-ExpectedReduction, 6, MidpointRounding.AwayFromZero), Math.Round(CalculatedReduction.ReductionX, 6, MidpointRounding.AwayFromZero));
        }

        [TestMethod]
        public void Calculate_reductionfactor_negative_withpositive_nochange()
        {

            float XVelocity = -4;
            float YVelocity = 4;
            float ExpectedReduction = 0;
            var CalculatedReduction = PlayerPosition.GetSpeedReduction(XVelocity, YVelocity);
            Assert.AreEqual(ExpectedReduction, CalculatedReduction.ReductionY);
        }


        [TestMethod]
        public void Calculate_reductionfactor_positive_withnegative()
        {

            float XVelocity = 8;
            float YVelocity = -8;
            double angle = Math.Atan(1);
            var totalVal = Math.Sqrt(XVelocity * XVelocity + YVelocity * YVelocity);
            float ExpectedReduction = (float)((Math.Cos(angle) * totalVal - Math.Cos(angle) * 10));
            var CalculatedReduction = PlayerPosition.GetSpeedReduction(XVelocity, YVelocity);
            Assert.AreEqual(Math.Round(-ExpectedReduction, 6, MidpointRounding.AwayFromZero), Math.Round(CalculatedReduction.ReductionY, 6, MidpointRounding.AwayFromZero));
            Assert.AreEqual(Math.Round(ExpectedReduction, 6, MidpointRounding.AwayFromZero), Math.Round(CalculatedReduction.ReductionX, 6, MidpointRounding.AwayFromZero));
        }

        [TestMethod]
        public void Calculate_reductionfactor_positive_withnegative_nochange()
        {

            float XVelocity = 4;
            float YVelocity = -4;
            float ExpectedReduction = 0;
            var CalculatedReduction = PlayerPosition.GetSpeedReduction(XVelocity, YVelocity);
            Assert.AreEqual(ExpectedReduction, CalculatedReduction.ReductionX);
        }

        [TestMethod]
        public void Calculate_reductionfactor_positive_withpositive()
        {

            float XVelocity = 8;
            float YVelocity = 8;
            double angle = Math.Atan(1);
            var totalVal = Math.Sqrt(XVelocity * XVelocity + YVelocity * YVelocity);
            float ExpectedReduction = (float)((Math.Cos(angle) * totalVal - Math.Cos(angle) * 10));
            var CalculatedReduction = PlayerPosition.GetSpeedReduction(XVelocity, YVelocity);
            Assert.AreEqual(Math.Round(ExpectedReduction, 6, MidpointRounding.AwayFromZero), Math.Round(CalculatedReduction.ReductionY, 6, MidpointRounding.AwayFromZero));
            Assert.AreEqual(Math.Round(ExpectedReduction, 6, MidpointRounding.AwayFromZero), Math.Round(CalculatedReduction.ReductionX, 6, MidpointRounding.AwayFromZero));
        }

        [TestMethod]
        public void Calculate_reductionfactor_positive_withpositive_nochange()
        {

            float XVelocity = 4;
            float YVelocity = 4;
            float ExpectedReduction = 0;
            var CalculatedReduction = PlayerPosition.GetSpeedReduction(XVelocity, YVelocity);
            Assert.AreEqual(ExpectedReduction, CalculatedReduction.ReductionX);
        }


        [TestMethod]
        public void Calculate_reductionfactor_positive_withpositive_different_lengths()
        {

            float XVelocity = 5;
            float YVelocity = 10;
            double angle = Math.Atan(10/5);
            var totalVal = Math.Sqrt(XVelocity * XVelocity + YVelocity * YVelocity);

            var XBackCalc = (Math.Cos(angle) * totalVal);
            Assert.AreEqual(5, (int)XBackCalc);

            float ExpectedReductionX = (float)((Math.Cos(angle) * totalVal - Math.Cos(angle) * 10));
            float ExpectedReductionY = (float)((Math.Sin(angle) * totalVal - Math.Sin(angle) * 10));
            var CalculatedReduction = PlayerPosition.GetSpeedReduction(XVelocity, YVelocity);
            Assert.AreEqual(Math.Round(ExpectedReductionY, 6, MidpointRounding.AwayFromZero), Math.Round(CalculatedReduction.ReductionY, 6, MidpointRounding.AwayFromZero));
            Assert.AreEqual(Math.Round(ExpectedReductionX, 6, MidpointRounding.AwayFromZero), Math.Round(CalculatedReduction.ReductionX, 6, MidpointRounding.AwayFromZero));
        }


        [TestMethod]
        public void CacculateDirection_1()
        {
            float XVelocity = 5;
            float YVelocity = 10;
            double angle = Math.Atan(YVelocity / XVelocity);

            var direction = PlayerPosition.GetDirectionIndexFourDirections(angle, XVelocity, YVelocity);
            Assert.AreEqual(0, direction);

        }

        [TestMethod]
        public void CacculateDirection_2()
        {
            float XVelocity = 10;
            float YVelocity = 5;
            double angle = Math.Atan(YVelocity / XVelocity);

            var direction = PlayerPosition.GetDirectionIndexFourDirections(angle, XVelocity, YVelocity);
            Assert.AreEqual(1, direction);

        }

        [TestMethod]
        public void CacculateDirection_3()
        {
            float XVelocity = -5;
            float YVelocity = -10;
            double angle = Math.Atan(YVelocity / XVelocity);

            var direction = PlayerPosition.GetDirectionIndexFourDirections(angle, XVelocity, YVelocity);
            Assert.AreEqual(2, direction);

        }

        [TestMethod]
        public void CacculateDirection_4()
        {
            float XVelocity = -10;
            float YVelocity = 5;
            double angle = Math.Atan(YVelocity / XVelocity);

            var direction = PlayerPosition.GetDirectionIndexFourDirections(angle, XVelocity, YVelocity);
            Assert.AreEqual(3, direction);

        }


    }
}
