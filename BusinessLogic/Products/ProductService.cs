using Contract.Products;
using Microsoft.Extensions.Logging;


namespace BusinessLogic.Products
{

    public class ProductService : IProductService
    {
        private readonly ILogger _logger;

        public ProductService(ILogger<ProductService> logger)
        {
            _logger = logger;
        }

        public async Task<GetListProductByIDsResponse> GetListProductByIDs(GetListProductByIDsRequest request)
        {
            return await new GetListProductByIDsHandler(_logger).Execute(request);
        }

        public async Task<GetProductByIDResponse> GetProductByID(GetProductByIDRequest request)
        {
            return await new GetProductByIDHandler(_logger).Execute(request);
        }
    }
}
