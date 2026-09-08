using NUnit.Framework;

namespace HordeProtocol.Tests
{
    public class AlwaysTrueTests
    {
        [Test]
        public void AlwaysTrue()
        {
            Assert.That(true, Is.True);
        }
    }
}
