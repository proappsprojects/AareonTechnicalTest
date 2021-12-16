using Xunit;
using AareonTechnicalTest.Models;
using AareonTechnicalTest.Services;
using AareonTechnicalTest.Data;
using Moq;

namespace AareonTechnicalTest.Tests
{
    public class CreateTicketServiceTest
    {
        private readonly Ticket  _newTicket;
        private readonly Mock<ITicketRepository> _mockTicketRepository;
        private readonly TicketService _service;
        public CreateTicketServiceTest()
        {
            _newTicket = new Ticket
            {
                Content = "T-5000",
                PersonId = 5
            };

            _mockTicketRepository = new Mock<ITicketRepository>();

            _service = new TicketService(_mockTicketRepository.Object);
        }


        [Fact]
        public async void Should_Return_A_Valid_Ticket_When_Successfully_Created()
        {
            //Arrange
            var newTicket = new Ticket
            {
                Content = "T-5000",
                PersonId = 5
            };

            _mockTicketRepository
                .Setup(x => x.CreateAsync(It.IsAny<Ticket>()))
                .ReturnsAsync(newTicket);

            //Act
            Ticket newTicketResult = await _service.CreateAsync(newTicket);

            //Assert
            Assert.NotNull(newTicketResult);
            Assert.Equal(newTicketResult.Content, newTicket.Content);
            Assert.Equal(newTicketResult.PersonId, newTicket.PersonId);
        }
    }
}
