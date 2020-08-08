using System;
using Xunit;

namespace RegionApiTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var a = 2 + 2;
            Assert.Equal(4, a);
        }
    }
}
