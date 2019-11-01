
using System.Text.RegularExpressions;
using Xunit;

namespace ParkMyBike.Tests
{
    public class BikeRackTests : BaseTestClass
    {
        [Fact]
        public void LatLongIsProperFormat()
        {
            var rack = GenerateTestBikeRack(1);
            var latLong = rack.LatLong;

            bool isProperFormat = Regex.IsMatch(latLong, @"^[-+]?([1-8]?\d(\.\d+)?|90(\.0+)?),\s*[-+]?(180(\.0+)?|((1[0-7]\d)|([1-9]?\d))(\.\d+)?)$");

            Assert.True(isProperFormat);
        }
    }
}
