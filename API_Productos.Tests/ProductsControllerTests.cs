using API_Productos.Controllers; 
using Contract.Products;
using Models;
using Moq;
using Xunit;

namespace API_Productos.ProductsControllerTests
{
    /// <summary>
    /// Casos de prueba para validar EPs
    /// Valido: Existencia, Calidad de dato y Cantidad de registros esperados
    /// </summary>
    public class ProductsControllerTests
    {
        private readonly Mock<IProductService> _mockProductService;
        private readonly ProductsController _controller;

        public ProductsControllerTests()
        {
            _mockProductService = new Mock<IProductService>();
            _controller = new ProductsController(_mockProductService.Object);
        }

        [Fact]
        public async Task GetProductByID_ReturnsExpectedResponse()
        {
            int testId = 1;
            var expectedResponse = new GetProductByIDResponse
            {
                product = new Products { Id = 1, Name = "Auriculares Bluetooth Marca 1" }
            };

            _mockProductService
                .Setup(s => s.GetProductByID(It.Is<GetProductByIDRequest>(r => r.ID == testId)))
                .ReturnsAsync(expectedResponse);

            var result = await _controller.GetProductByID(testId);
            Assert.NotNull(result);
            Assert.Equal(testId, result.product?.Id);
            Assert.Equal("Auriculares Bluetooth Marca 1", result.product?.Name);
        }

        [Fact]
        public async Task GetListProductByIDs_ReturnsExpectedResponse()
        {
            var testIds = new List<int> { 1, 2, 3 };
            var expectedResponse = new GetListProductByIDsResponse
            {
                products = new List<Products>
            {
                new Products { Id = 1, Name = "Auriculares Bluetooth Marca 1" },
                new Products { Id = 2, Name = "Auriculares Bluetooth Marca 2" },
                new Products { Id = 3, Name = "Auriculares Bluetooth Marca 3" }
            }
            };

            _mockProductService
                .Setup(s => s.GetListProductByIDs(It.Is<GetListProductByIDsRequest>(r => r.IDs == testIds)))
                .ReturnsAsync(expectedResponse);

            var result = await _controller.GetListProductByIDs(testIds);
            Assert.NotNull(result);
            Assert.Equal(3, result.products?.Count);
            Assert.Contains(result.products, p => p.Id == 2 && p.Name == "Auriculares Bluetooth Marca 2");
        }
    }

}
