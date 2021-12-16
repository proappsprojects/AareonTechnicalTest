using Xunit;
using AareonTechnicalTest.Models;
using AareonTechnicalTest.Services;
using AareonTechnicalTest.Data;
using Moq;


namespace AareonTechnicalTest.Tests.Services
{
    public class SelectTicketServiceTest
    {
        private readonly Ticket _newTicket;
        private readonly Mock<ITicketRepository> _mockTicketRepository;
        private readonly TicketService _service;
        public SelectTicketServiceTest()
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
        public async void Should_Return_A_Valid_Ticket_When_Submit_A_Valid_Ticket_Id()
        {
            //Arrange
            var newTicket = new Ticket
            {
                Content = "T-5000",
                PersonId = 5
            };
            var newTicketId = 5;

            _mockTicketRepository
                    .Setup(x => x.ReadByIdAsync(newTicketId))
                     .ReturnsAsync(newTicket);

            //Act
            Ticket newTicketResult = await _service.ReadByIdAsync(newTicketId);

            //Assert
            Assert.NotNull(newTicketResult);
            Assert.Equal(newTicketResult.Content, newTicket.Content);
            Assert.Equal(newTicketResult.PersonId, newTicket.PersonId);

        }


    }
}
