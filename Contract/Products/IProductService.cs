namespace Contract.Products
{
    /// <summary>
    /// Interfaz encargada de generar los contratos para los metodos de products
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        ///  Tarea a Implementar: Retornar un producto por su ID
        /// </summary>
        /// <param name="request">Objeto con parametros de Busqueda</param>
        /// <returns>Objeto producto y estado de respuesta</returns>
        Task<GetProductByIDResponse> GetProductByID(GetProductByIDRequest request);

        /// <summary>
        /// Tarea a Implementar: Retornar una Lista de productos por sus IDs
        /// </summary>
        /// <param name="request">Objeto con parametros de Busqueda</param>
        /// <returns>Objeto con lista de productos y estado de respuesta</returns>
        Task<GetListProductByIDsResponse> GetListProductByIDs(GetListProductByIDsRequest request);

    }
}
