using BusinessLogic.Commons;
using Contract.Products;
using Data.Product;
using Microsoft.Extensions.Logging;

namespace BusinessLogic.Products
{
    public class GetListProductByIDsHandler : RequestResponseHandler<GetListProductByIDsRequest, Task<GetListProductByIDsResponse>>
    {
        private readonly ILogger _logger;
        public GetListProductByIDsHandler(ILogger logger)
        {
            _logger = logger;
        }

        public override async Task<GetListProductByIDsResponse> Handle(GetListProductByIDsRequest request)
        {
            var response = new GetListProductByIDsResponse()
            {
                Error = false,
                ErrorMsg = string.Empty,
            };

            try
            {
                var productos = new ProductsJSON(_logger).GetProductsData();
                response.products = productos.Where(x => request.IDs.Contains(x.Id)).ToList();
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
