using API_Productos.Infraestructure;
using Contract.Products;
using Microsoft.AspNetCore.Mvc;

namespace API_Productos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _ProductService;
        public ProductsController(IProductService ProductService)
        {
            _ProductService = ProductService;
        }

        /// <summary>
        /// Retorna un producto por un ID puntual
        /// </summary>
        /// <param name="id">Codigo identificativo del producto</param>
        /// <returns>Datos del producto solicitado</returns>
        [HttpGet, Route("GetProductByID")]
        [ApiKeyAuth]
        public Task<GetProductByIDResponse> GetProductByID(int id)
        {
            var response = _ProductService.GetProductByID(
                    new GetProductByIDRequest() { ID = id }
                );
            return response;
        }

        /// <summary>
        /// Retorna una Lista de Productos por sus IDs
        /// </summary>
        /// <param name="IDs">Lista de IDs de los productos a Recuperar</param>
        /// <returns>Una Lista de Productos</returns>
        [HttpPost, Route("GetListProductByIDs")]
        [ApiKeyAuth]
        public Task<GetListProductByIDsResponse> GetListProductByIDs([FromBody] List<int> IDs)
        {
            var response = _ProductService.GetListProductByIDs(
                new GetListProductByIDsRequest() { IDs = IDs }
                );

            return response;
        }
    }
}
