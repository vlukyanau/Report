using System;
using Moq;
using ReportClients.BLL.Interfaces;
using ReportClients.DAL.Entities;
using Xunit;
using ReportClients.BLL.Services;
using ReportClients.DAL.Interfaces;

namespace ReportClients.UnitTests
{
    public class ClientServiceTests
    {
        private readonly IClientService _clientServiceMock;
        private readonly Mock<IGenericAsyncRepository<ClientEntity>> _clientMock;

        public ClientServiceTests()
        {
            _clientMock = new Mock<IGenericAsyncRepository<ClientEntity>>();
            _clientServiceMock = new ClientService(_clientMock.Object);
        }

        [Fact]
        public void CreateClient_WhenNullClient_ShouldReturnException()
        {
            // Arrage
            
            // Act

            //Assert
            Assert.Throws<InvalidOperationException>(() => _clientServiceMock.CreateClient(null));
        }
    }
}
