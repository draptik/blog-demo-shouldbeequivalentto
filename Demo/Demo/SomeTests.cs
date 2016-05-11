using FluentAssertions;
using Xunit;

namespace Demo
{
    public class SomeTests
    {
        [Fact]
        public void Given_Customer_Should_ConvertTo_Person()
        {
            //Arrange
            const string firstname = "foo";
            const string lastname = "bar";

            var customer = new Customer
            {
                FirstName = firstname,
                LastName = lastname
            };

            MyMapping.Init();

            // Act
            var person = MyMapping.Mapper.Map<Customer, Person>(customer);

            // Assert
            person.FirstName.Should().Be(firstname);
            person.LastName.Should().Be(lastname);
        }

        [Fact]
        public void Given_Customer_Should_ConvertTo_Person_With_CurrentProperties()
        {
            //Arrange
            const string firstname = "foo";
            const string lastname = "bar";

            var customer = new Customer
            {
                FirstName = firstname,
                LastName = lastname,
                Email = "foo@bar.com"
            };

            MyMapping.Init();

            // Act
            var person = MyMapping.Mapper.Map<Customer, Person>(customer);

            // Assert
            // NOTE: This test should fail!
            customer.ShouldBeEquivalentTo(person);
        }

        [Fact]
        public void Given_Customer_Should_ConvertTo_Person_With_CurrentProperties_Excluding_Email()
        {
            //Arrange
            const string firstname = "foo";
            const string lastname = "bar";

            var customer = new Customer
            {
                FirstName = firstname,
                LastName = lastname,
                Email = "foo@bar.com"
            };

            MyMapping.Init();

            // Act
            var person = MyMapping.Mapper.Map<Customer, Person>(customer);

            // Assert
            customer.ShouldBeEquivalentTo(person,
                options =>
                    options.Excluding(x => x.Email));
        }
    }
}