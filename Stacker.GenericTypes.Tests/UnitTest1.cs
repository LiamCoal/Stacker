using NUnit.Framework;

namespace Stacker.GenericTypes.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test] public void TestStackerManagerByteStackable() => Stacker.Tests.Tests.TestStackable<StackableByte>();
        [Test] public void TestStackerManagerShortStackable() => Stacker.Tests.Tests.TestStackable<StackableShort>();
        [Test] public void TestStackerManagerIntStackable() => Stacker.Tests.Tests.TestStackable<StackableInt>();
        [Test] public void TestStackerManagerLongStackable() => Stacker.Tests.Tests.TestStackable<StackableLong>();
        [Test] public void TestStackerManagerMultiByteStackable() => Stacker.Tests.Tests.TestStackable<StackableByte>(5);
        [Test] public void TestStackerManagerMultiShortStackable() => Stacker.Tests.Tests.TestStackable<StackableShort>(5);
        [Test] public void TestStackerManagerMultiIntStackable() => Stacker.Tests.Tests.TestStackable<StackableInt>(5);
        [Test] public void TestStackerManagerMultiLongStackable() => Stacker.Tests.Tests.TestStackable<StackableLong>(5);
    }
}