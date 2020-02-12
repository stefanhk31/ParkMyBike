using ParkMyBike.Resources.Regexes;
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

            var isProperFormat = Regex.IsMatch(latLong, LatLongString.Format);

            Assert.True(isProperFormat);
        }
    }
}
