namespace MebelDesign71.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using Ganss.XSS;

    using MebelDesign71.Data;
    using MebelDesign71.Data.Models;
    using MebelDesign71.Data.Repositories;
    using MebelDesign71.Services.Data.Contracts;
    using MebelDesign71.Web.ViewModels.Orders;

    using Microsoft.AspNetCore.Hosting.Internal;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;

    using Moq;

    using Xunit;

    public class OrdersServiceTests : IDisposable
    {
        private readonly IFilesService filesService;
        private readonly IOrdersService ordersService;

        private EfDeletableEntityRepository<Order> orderRepository;
        private EfDeletableEntityRepository<OrderDocument> orderDocumentRepository;
        private EfRepository<FileOnFileSystem> filesRepository;

        private ApplicationDbContext connection;

        private HostingEnvironment environment;
        private IHtmlSanitizer htmlSanitizer;

        private IFormFile file;
        private OrderInputModel orderInputModel;

        public OrdersServiceTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
              .UseInMemoryDatabase(databaseName: "TestDb").Options;
            this.connection = new ApplicationDbContext(options);

            this.orderRepository = new EfDeletableEntityRepository<Order>(this.connection);
            this.orderDocumentRepository = new EfDeletableEntityRepository<OrderDocument>(this.connection);
            this.filesRepository = new EfRepository<FileOnFileSystem>(this.connection);

            this.environment = new HostingEnvironment();
            this.htmlSanitizer = new HtmlSanitizer();

            this.InitializeFields();

            this.filesService = new FilesService(this.filesRepository, this.environment);
            this.ordersService = new OrdersService(this.orderDocumentRepository, this.orderRepository, this.filesService, this.htmlSanitizer);
        }

        public void Dispose()
        {
            this.connection.Database.EnsureDeleted();
            this.connection.Dispose();
        }

        [Fact]
        public async Task TestAddDocumentToOrder()
        {
            var orderId = "some orderId";
            var userId = "some userId";
            var orderNumber = "201201234501";

            var documentId = await this.ordersService.AddDocumentToOrderAsync(this.file, orderId, userId, orderNumber);

            Assert.NotNull(documentId);
        }

        [Fact]
        public async Task TestAddOrder()
        {
            var orderId = await this.ordersService.AddOrderAsync(this.orderInputModel);

            Assert.NotNull(orderId);
        }

        [Fact]
        public async Task TestGetAllOrders()
        {
            var orderId = await this.ordersService.AddOrderAsync(this.orderInputModel);

            var orders = this.ordersService.GetAllOrders();

            Assert.NotNull(orders);
        }

        [Fact]
        public async Task TestGetOrderById()
        {
            var orderId = await this.ordersService.AddOrderAsync(this.orderInputModel);

            var orders = this.ordersService.GetOrderById(orderId);

            Assert.NotNull(orders);
        }

        [Fact]
        public async Task TestUpdateOrder()
        {
            var orderId = await this.ordersService.AddOrderAsync(this.orderInputModel);

            var orderViewModel = new OrderViewModel
            {
                OrderId = orderId,
                UserId = "some userId",
                ServiceId = 2,
                Description = "test",
                Price = 10,
            };

            await this.ordersService.UpdateOrderAsync(orderViewModel);

            var order = this.orderRepository.All().FirstOrDefault();

            Assert.Equal(10, order.Price);
            Assert.Equal("test", order.Description);
        }

        [Fact]
        public async Task TestDeletedOrder()
        {
            var orderId = await this.ordersService.AddOrderAsync(this.orderInputModel);
            var orderIdTwo = await this.ordersService.AddOrderAsync(this.orderInputModel);

            await this.ordersService.DeletedOrderAsync(orderId);

            var order = this.orderRepository.All().FirstOrDefault();

            Assert.Equal(orderIdTwo, order.Id);
        }

        // End Testing ---------------------------------------------------------------------------------------------------------------

        private void InitializeFields()
        {
            var fileMock = new Mock<IFormFile>();
            var content = "Hello World from a Fake File";
            var fileName = "test.pdf";
            var ms = new MemoryStream();
            var writer = new StreamWriter(ms);
            writer.Write(content);
            writer.Flush();
            ms.Position = 0;
            fileMock.Setup(_ => _.OpenReadStream()).Returns(ms);
            fileMock.Setup(_ => _.FileName).Returns(fileName);
            fileMock.Setup(_ => _.Length).Returns(ms.Length);

            this.file = fileMock.Object;

            this.orderInputModel = new OrderInputModel
            {
                UserId = "some userId",
                ServiceId = 1,
                Description = "Lorem Ipsum is simply dummy text ",
                Documents = new List<IFormFile>() { this.file },
            };
        }
    }
}
