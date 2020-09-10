using System;
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
        [Test] public void TestStackerManagerSingleByteStackable() => Stacker.Tests.Tests.TestSingleTypeStackable<StackableByte>();
        [Test] public void TestStackerManagerSingleShortStackable() => Stacker.Tests.Tests.TestSingleTypeStackable<StackableShort>();
        [Test] public void TestStackerManagerSingleIntStackable() => Stacker.Tests.Tests.TestSingleTypeStackable<StackableInt>();
        [Test] public void TestStackerManagerSingleLongStackable() => Stacker.Tests.Tests.TestSingleTypeStackable<StackableLong>();
        [Test] public void TestStackerManagerSingleMultiByteStackable() => Stacker.Tests.Tests.TestSingleTypeStackable<StackableByte>(5);
        [Test] public void TestStackerManagerSingleMultiShortStackable() => Stacker.Tests.Tests.TestSingleTypeStackable<StackableShort>(5);
        [Test] public void TestStackerManagerSingleMultiIntStackable() => Stacker.Tests.Tests.TestSingleTypeStackable<StackableInt>(5);
        [Test] public void TestStackerManagerSingleMultiLongStackable() => Stacker.Tests.Tests.TestSingleTypeStackable<StackableLong>(5);
    }
}