using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OnionPattern.Mapping.Tests
{
    public class BaseTypeConverterTests
    {

        [TestClass]
        public class MethodsTests
        {
            private readonly MockTypeConveter converter;

            public MethodsTests()
            {
                converter = new MockTypeConveter();
            }

            [TestMethod]
            public void SourceIsNull()
            {
                var destination = new DummyObject();
                Action guard = () => converter.TestGuard(null, ref destination);

                guard.Should()
                    .Throw<ArgumentNullException>()
                    .WithMessage($"Value cannot be null.{Environment.NewLine}Parameter name: source");
            }

            [TestMethod]
            public void DestinationIsNull()
            {
                var source = new DummyObject();
                DummyObject destination = null;

                converter.TestGuard(source, ref destination);

                destination.Should().NotBeNull();
            }

            [TestMethod]
            public void DestinationIsNotNull()
            {
                const int EXPECTEDID = 1;
                const string EXPECTEDNAME = "Thingy";

                var source = new DummyObject();
                var destination = new DummyObject{ Id = EXPECTEDID, Name = EXPECTEDNAME };
                
                converter.TestGuard(source, ref destination);

                destination.Should().NotBeNull();
                destination.Id.Should().Be(EXPECTEDID);
                destination.Name.Should().BeEquivalentTo(EXPECTEDNAME);
            }
        }

        internal class MockTypeConveter : BaseTypeConverter<DummyObject, DummyObject>
        {
            public void TestGuard(DummyObject source, ref DummyObject destination)
            {
                Guard(source, ref destination);
            }
        }

        internal class DummyObject
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
