using System;
using Business.CommandHandlers;
using Business.Commands;
using Business.Implementation.CommandHandlers;
using DataAccess.DbContexts;
using DataAccess.Queries;
using Moq;
using NUnit.Framework;

namespace BusinessTests.CommandHandlerTests
{
    [TestFixture]
    public class GetPersonAddressesCommandHandlerTests
    {
        private ICommandHandler<GetAddressesByPersonCommand> commandHandler;
        private Mock<IAppContextAdapter> appContextMock;

        [Test]
        public void ExecuteMethodShouldThrowArgumentNullExceptionIfInputArgumentIsNull()
        {
            appContextMock = new Mock<IAppContextAdapter>();
            commandHandler = new GetPersonAddressesCommandHandler(appContextMock.Object);

            Assert.Throws<ArgumentNullException>(() => commandHandler.Execute(null));
        }

        [Test]
        public void ExecuteMethodShouldThrowInvalidOperationExceptionIfPersonIdIsLessOrEqualZero(
            [Values(0, -1, -100, -1000, -1000000000)] int personId)
        {
            appContextMock = new Mock<IAppContextAdapter>();
            commandHandler = new GetPersonAddressesCommandHandler(appContextMock.Object);

            var command = new GetAddressesByPersonCommand()
            {
                PersonId = personId
            };

            Assert.Throws<InvalidOperationException>(() => commandHandler.Execute(command));
        }

        [Test]
        public void ExecuteMethodShouldThrowNullReferenceExceptionIfQueryReturnsNothing(
            [Values(1, 100)] int personId)
        {
            appContextMock = new Mock<IAppContextAdapter>();
            appContextMock.Setup(context => context.Select(It.Is<GetAddressesByPersonIdQuery>(x => x.PersonId == personId)))
                .Returns(null as QueryResult);
            commandHandler = new GetPersonAddressesCommandHandler(appContextMock.Object);

            Assert.Throws<NullReferenceException>(() => commandHandler.Execute(new GetAddressesByPersonCommand()
            {
                PersonId = personId
            }));
        }

        [Test]
        public void ExecuteMethodShouldReturnObjectWithTheSamePersonIdAsInput(
            [Values(1, 100, 1000, 1000000000)] int personId)
        {
            appContextMock = new Mock<IAppContextAdapter>();
            appContextMock.Setup(context => context.Select(It.Is<GetAddressesByPersonIdQuery>(x => x.PersonId == personId)))
                .Returns(new GetAddressesByPersonIdQueryResult()
                {
                    PersonId = personId
                });
            commandHandler = new GetPersonAddressesCommandHandler(appContextMock.Object);

            var commandResult = commandHandler.Execute(new GetAddressesByPersonCommand()
            {
                PersonId = personId
            }) as GetAddressesByPersonCommandResult;

            Assert.AreEqual(personId, commandResult.PersonId);
        }
    }
}