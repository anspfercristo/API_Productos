using BusinessLogic.Commons;
using Contract.Products;
using Data.Product;
using Microsoft.Extensions.Logging;

namespace BusinessLogic.Products
{
    internal class GetProductByIDHandler : RequestResponseHandler<GetProductByIDRequest, Task<GetProductByIDResponse>>
    {
        private readonly ILogger _logger;
        public GetProductByIDHandler(ILogger logger)
        {
            _logger = logger;
        }

        public override async Task<GetProductByIDResponse> Handle(GetProductByIDRequest request)
        {
            var response = new GetProductByIDResponse()
            {
                Error = false,
                ErrorMsg = string.Empty,
            };

            try
            {
                var productos = new ProductsJSON(_logger).GetProductsData();
                response.product = productos.FirstOrDefault(p => p.Id == request.ID);
            }
            catch (Exception e)
            {
                response.Error = true;
                response.ErrorMsg = e.Message;
                _logger.LogError(e.Message);
            }

            return response;
        }
    }
}
