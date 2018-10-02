using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using testgame2.Classes;

namespace UnitTests
{
    [TestClass]
    public class ScreenPositioningCalculations
    {
        [TestMethod]
        public void DisplacementCalculation_PositiveVelocity_CrossOverAtMinPosition_ExpectVelocityAdjustment1()
        {
            float NewPosition = 105F;
            float MinPlayerCoordinate = 100F;
            float MaxPlayerCoordinate = 200F;
            float Velocity = 10F;
            float expectedMapDisplacement = 5F;

            var calculatedMapDisplacement =  MapCalculations.GetMapDisplacement(
                NewPosition,
                MinPlayerCoordinate,
                MaxPlayerCoordinate,
                Velocity);

            Assert.AreEqual(expectedMapDisplacement, calculatedMapDisplacement);
        }

        [TestMethod]
        public void DisplacementCalculation_PositiveVelocity_CrossOverAtMinPosition_ExpectVelocityAdjustment2()
        {
            float NewPosition = 105F;
            float MinPlayerCoordinate = 100F;
            float MaxPlayerCoordinate = 200F;
            float Velocity = 5.5F;
            float expectedMapDisplacement = 5F;

            var calculatedMapDisplacement = MapCalculations.GetMapDisplacement(
                NewPosition,
                MinPlayerCoordinate,
                MaxPlayerCoordinate,
                Velocity);

            Assert.AreEqual(expectedMapDisplacement, calculatedMapDisplacement);
        }


        [TestMethod]
        public void DisplacementCalculation_PositiveVelocity_CrossOverAtMinPosition_ExpectVelocityAdjustment3()
        {
            float NewPosition = 102F;
            float MinPlayerCoordinate = 100F;
            float MaxPlayerCoordinate = 200F;
            float Velocity = 5.5F;
            float expectedMapDisplacement = 2F;

            var calculatedMapDisplacement = MapCalculations.GetMapDisplacement(
                NewPosition,
                MinPlayerCoordinate,
                MaxPlayerCoordinate,
                Velocity);

            Assert.AreEqual(expectedMapDisplacement, calculatedMapDisplacement);
        }

        [TestMethod]
        public void DisplacementCalculation_NegativeVelocity_CrossOverAtMinPosition_ExpectVelocityAdjustment1()
        {
            float NewPosition = 95F;
            float MinPlayerCoordinate = 100F;
            float MaxPlayerCoordinate = 200F;
            float Velocity = -10F;
            float expectedMapDisplacement = -5F;

            var calculatedMapDisplacement = MapCalculations.GetMapDisplacement(
                NewPosition,
                MinPlayerCoordinate,
                MaxPlayerCoordinate,
                Velocity);

            Assert.AreEqual(expectedMapDisplacement, calculatedMapDisplacement);
        }


        [TestMethod]
        public void DisplacementCalculation_NegativeVelocity_CrossOverAtMinPosition_ExpectVelocityAdjustment2()
        {
            float NewPosition = 95F;
            float MinPlayerCoordinate = 100F;
            float MaxPlayerCoordinate = 200F;
            float Velocity = -5.5F;
            float expectedMapDisplacement = -0.5F;

            var calculatedMapDisplacement = MapCalculations.GetMapDisplacement(
                NewPosition,
                MinPlayerCoordinate,
                MaxPlayerCoordinate,
                Velocity);

            Assert.AreEqual(expectedMapDisplacement, calculatedMapDisplacement);
        }

        [TestMethod]
        public void DisplacementCalculation_NegativeVelocity_CrossOverAtMinPosition_ExpectVelocityAdjustment3()
        {
            float NewPosition = 98F;
            float MinPlayerCoordinate = 100F;
            float MaxPlayerCoordinate = 200F;
            float Velocity = -5.5F;
            float expectedMapDisplacement = -3.5F;

            var calculatedMapDisplacement = MapCalculations.GetMapDisplacement(
                NewPosition,
                MinPlayerCoordinate,
                MaxPlayerCoordinate,
                Velocity);

            Assert.AreEqual(expectedMapDisplacement, calculatedMapDisplacement);
        }


        [TestMethod]
        public void DisplacementCalculation_PositiveVelocity_BelowMinPosition_ExpectNoVelocity1()
        {
            float NewPosition = 100F;
            float MinPlayerCoordinate = 100F;
            float MaxPlayerCoordinate = 200F;
            float Velocity = 10F;
            float expectedMapDisplacement = 0F;

            var calculatedMapDisplacement = MapCalculations.GetMapDisplacement(
                NewPosition,
                MinPlayerCoordinate,
                MaxPlayerCoordinate,
                Velocity);

            Assert.AreEqual(expectedMapDisplacement, calculatedMapDisplacement);
        }

        [TestMethod]
        public void DisplacementCalculation_NegativeVelocity_BelowMinPosition_ExpectNoVelocity1()
        {
            float NewPosition = 90F;
            float MinPlayerCoordinate = 100F;
            float MaxPlayerCoordinate = 200F;
            float Velocity = -10F;
            float expectedMapDisplacement = 0F;

            var calculatedMapDisplacement = MapCalculations.GetMapDisplacement(
                NewPosition,
                MinPlayerCoordinate,
                MaxPlayerCoordinate,
                Velocity);

            Assert.AreEqual(expectedMapDisplacement, calculatedMapDisplacement);
        }

        [TestMethod]
        public void DisplacementCalculation_PositiveVelocity_AboveMinPosition_ExpectFullVelocity1()
        {
            float NewPosition = 110F;
            float MinPlayerCoordinate = 100F;
            float MaxPlayerCoordinate = 200F;
            float Velocity = 10F;
            float expectedMapDisplacement = 10F;

            var calculatedMapDisplacement = MapCalculations.GetMapDisplacement(
                NewPosition,
                MinPlayerCoordinate,
                MaxPlayerCoordinate,
                Velocity);

            Assert.AreEqual(expectedMapDisplacement, calculatedMapDisplacement);
        }

        [TestMethod]
        public void DisplacementCalculation_NegativeVelocity_AboveMinPosition_ExpectFullVelocity1()
        {
            float NewPosition = 100F;
            float MinPlayerCoordinate = 100F;
            float MaxPlayerCoordinate = 200F;
            float Velocity = -10F;
            float expectedMapDisplacement = -10F;

            var calculatedMapDisplacement = MapCalculations.GetMapDisplacement(
                NewPosition,
                MinPlayerCoordinate,
                MaxPlayerCoordinate,
                Velocity);

            Assert.AreEqual(expectedMapDisplacement, calculatedMapDisplacement);
        }



        [TestMethod]
        public void DisplacementCalculation_PositiveVelocity_CrossOverAtMaxPosition_ExpectVelocityAdjustment1()
        {
            float NewPosition = 205F;
            float MinPlayerCoordinate = 100F;
            float MaxPlayerCoordinate = 200F;
            float Velocity = 10F;
            float expectedMapDisplacement = 5F;

            var calculatedMapDisplacement = MapCalculations.GetMapDisplacement(
                NewPosition,
                MinPlayerCoordinate,
                MaxPlayerCoordinate,
                Velocity);

            Assert.AreEqual(expectedMapDisplacement, calculatedMapDisplacement);
        }

        [TestMethod]
        public void DisplacementCalculation_PositiveVelocity_CrossOverAtMaxPosition_ExpectVelocityAdjustment2()
        {
            float NewPosition = 205F;
            float MinPlayerCoordinate = 100F;
            float MaxPlayerCoordinate = 200F;
            float Velocity = 5.5F;
            float expectedMapDisplacement = 0.5F;

            var calculatedMapDisplacement = MapCalculations.GetMapDisplacement(
                NewPosition,
                MinPlayerCoordinate,
                MaxPlayerCoordinate,
                Velocity);

            Assert.AreEqual(expectedMapDisplacement, calculatedMapDisplacement);
        }


        [TestMethod]
        public void DisplacementCalculation_PositiveVelocity_CrossOverAtMaxPosition_ExpectVelocityAdjustment3()
        {
            float NewPosition = 202F;
            float MinPlayerCoordinate = 100F;
            float MaxPlayerCoordinate = 200F;
            float Velocity = 5.5F;
            float expectedMapDisplacement = 3.5F;

            var calculatedMapDisplacement = MapCalculations.GetMapDisplacement(
                NewPosition,
                MinPlayerCoordinate,
                MaxPlayerCoordinate,
                Velocity);

            Assert.AreEqual(expectedMapDisplacement, calculatedMapDisplacement);
        }

        [TestMethod]
        public void DisplacementCalculation_NegativeVelocity_CrossOverAtMaxPosition_ExpectVelocityAdjustment1()
        {
            float NewPosition = 195F;
            float MinPlayerCoordinate = 100F;
            float MaxPlayerCoordinate = 200F;
            float Velocity = -10F;
            float expectedMapDisplacement = -5F;

            var calculatedMapDisplacement = MapCalculations.GetMapDisplacement(
                NewPosition,
                MinPlayerCoordinate,
                MaxPlayerCoordinate,
                Velocity);

            Assert.AreEqual(expectedMapDisplacement, calculatedMapDisplacement);
        }


        [TestMethod]
        public void DisplacementCalculation_NegativeVelocity_CrossOverAtMaxPosition_ExpectVelocityAdjustment2()
        {
            float NewPosition = 195F;
            float MinPlayerCoordinate = 100F;
            float MaxPlayerCoordinate = 200F;
            float Velocity = -5.5F;
            float expectedMapDisplacement = -5F;

            var calculatedMapDisplacement = MapCalculations.GetMapDisplacement(
                NewPosition,
                MinPlayerCoordinate,
                MaxPlayerCoordinate,
                Velocity);

            Assert.AreEqual(expectedMapDisplacement, calculatedMapDisplacement);
        }

        [TestMethod]
        public void DisplacementCalculation_NegativeVelocity_CrossOverAtMaxPosition_ExpectVelocityAdjustment3()
        {
            float NewPosition = 198F;
            float MinPlayerCoordinate = 100F;
            float MaxPlayerCoordinate = 200F;
            float Velocity = -5.5F;
            float expectedMapDisplacement = -2F;

            var calculatedMapDisplacement = MapCalculations.GetMapDisplacement(
                NewPosition,
                MinPlayerCoordinate,
                MaxPlayerCoordinate,
                Velocity);

            Assert.AreEqual(expectedMapDisplacement, calculatedMapDisplacement);
        }


        [TestMethod]
        public void DisplacementCalculation_PositiveVelocity_BelowMaxPosition_ExpectFullVelocity1()
        {
            float NewPosition = 200F;
            float MinPlayerCoordinate = 100F;
            float MaxPlayerCoordinate = 200F;
            float Velocity = 10F;
            float expectedMapDisplacement = 10F;

            var calculatedMapDisplacement = MapCalculations.GetMapDisplacement(
                NewPosition,
                MinPlayerCoordinate,
                MaxPlayerCoordinate,
                Velocity);

            Assert.AreEqual(expectedMapDisplacement, calculatedMapDisplacement);
        }

        [TestMethod]
        public void DisplacementCalculation_NegativeVelocity_BelowMaxPosition_ExpectFullVelocity1()
        {
            float NewPosition = 190F;
            float MinPlayerCoordinate = 100F;
            float MaxPlayerCoordinate = 200F;
            float Velocity = -10F;
            float expectedMapDisplacement = -10F;

            var calculatedMapDisplacement = MapCalculations.GetMapDisplacement(
                NewPosition,
                MinPlayerCoordinate,
                MaxPlayerCoordinate,
                Velocity);

            Assert.AreEqual(expectedMapDisplacement, calculatedMapDisplacement);
        }

        [TestMethod]
        public void DisplacementCalculation_PositiveVelocity_AboveMaxPosition_ExpectNoVelocity1()
        {
            float NewPosition = 210F;
            float MinPlayerCoordinate = 100F;
            float MaxPlayerCoordinate = 200F;
            float Velocity = 10F;
            float expectedMapDisplacement = 0F;

            var calculatedMapDisplacement = MapCalculations.GetMapDisplacement(
                NewPosition,
                MinPlayerCoordinate,
                MaxPlayerCoordinate,
                Velocity);

            Assert.AreEqual(expectedMapDisplacement, calculatedMapDisplacement);
        }

        [TestMethod]
        public void DisplacementCalculation_NegativeVelocity_AboveMaxPosition_ExpectNoVelocity1()
        {
            float NewPosition = 200F;
            float MinPlayerCoordinate = 100F;
            float MaxPlayerCoordinate = 200F;
            float Velocity = -10F;
            float expectedMapDisplacement = 0F;

            var calculatedMapDisplacement = MapCalculations.GetMapDisplacement(
                NewPosition,
                MinPlayerCoordinate,
                MaxPlayerCoordinate,
                Velocity);

            Assert.AreEqual(expectedMapDisplacement, calculatedMapDisplacement);
        }


        [TestMethod]
        public void Calculateandomlimit()
        {
            int currentCoordinate;
            int mindistance;
            int maxdistance;

            float random = MapCalculations.GetDistanceWithRandom(1000, 50, true);
            Assert.IsFalse(MapCalculations.IsNewSeedAcceptable(2501, 3000, random));
        }

    }
}
