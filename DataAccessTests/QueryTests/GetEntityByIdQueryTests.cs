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
    public class GetEntityByIdQueryTests
    {
        private Mock<IAppContext> appContextMock;
        private InMemoryDbSet<Address> inMemoryAddressSet;

        [SetUp]
        public void Setup()
        {
            inMemoryAddressSet = InMemoryAddressSet.Build();
        }

        [Test]
        public void ExecuteMethodShouldReturnRequestedEntity([Values(1, 2, 3, 4, 5)] int entityId)
        {
            appContextMock = new Mock<IAppContext>();
            appContextMock.Setup(context => context.Set<Address>()).Returns(inMemoryAddressSet);
            var query = new GetEntityByIdQuery<Address>()
            {
                Id = entityId
            };

            var result = query.Execute(appContextMock.Object) as GetEntityByIdQueryResult<Address>;

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Entity, Is.Not.Null);
            Assert.That(result.Entity.Id, Is.EqualTo(query.Id));
        }
    }
}