using System;
using DataAccess.DbContexts;
using DataAccess.Queries;
using DataAccessTests.Infrastructure;
using Models.Entities.AppContext;
using Moq;
using NUnit.Framework;

namespace DataAccessTests.QueryTests
{
    [TestFixture]
    public class GetAddressesByPersonIdQueryTests
    {
        private Mock<IAppContext> appContextMock;
        private InMemoryDbSet<Address> inMemoryAddressSet;

        [SetUp]
        public void Setup()
        {
            inMemoryAddressSet = InMemoryAddressSet.Build();
        }

        [Test]
        public void ExecuteMethodShouldThrowArgumentNullExceptionIfInputArgumentIsNull()
        {
            appContextMock = new Mock<IAppContext>();
            var query = new GetAddressesByPersonIdQuery();

            Assert.Throws<ArgumentNullException>(() => query.Execute(null));
        }

        [Test]
        public void ExecuteMethodShouldReturnEmptyAddressListIfPersonIsNotFound()
        {
            appContextMock = new Mock<IAppContext>();
            appContextMock.Setup(context => context.Set<Address>()).Returns(inMemoryAddressSet);
            var query = new GetAddressesByPersonIdQuery()
            {
                PersonId = 2000000000
            };

            var result = query.Execute(appContextMock.Object) as GetAddressesByPersonIdQueryResult;

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Addresses, Is.Empty);
        }
    }
}