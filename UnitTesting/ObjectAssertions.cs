using FluentAssertions;
using Xunit;

namespace UnitTesting
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Person Father { get; set; }
    }

    public class Test
    {
        [Fact]
        public void Will_Not_Err_If_Parents_Do_Not_Match()
        {
            var expected = new Person { Id = 1, Name = "Matt", Father = new Person { Id = 7, Name = "Steve" } };
            var actual = new Person { Id = 1, Name = "Matt", Father = new Person { Id = 7, Name = "Steve" } };
            expected.Should().BeEquivalentTo(actual);
        }

        //[Fact]
        [Theory]
        [InlineData(7)]
        [InlineData(8)]
        public void Will_Err_If_Parents_Do_Not_Match(int id)
        {
            var expected = new Person { Id = 1, Name = "Matt", Father = new Person { Id = 7, Name = "Steve" } };
            var actual = new Person { Id = 1, Name = "Matt", Father = new Person { Id = id, Name = "Steve" } };
            expected.Should().BeEquivalentTo(actual);
        }
    }
}
