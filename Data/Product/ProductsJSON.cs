using Microsoft.Extensions.Logging;
using Models;
using System.Text.Json;

namespace Data.Product
{
    public class ProductsJSON
    {
        private readonly ILogger _logger;
        public ProductsJSON(ILogger logger)
        {
            _logger = logger;
        }

        public List<Products> GetProductsData()
        {
            List<Products> products = new List<Products>();

            try
            {
                var path = Path.Combine(AppContext.BaseDirectory, "Data", "Product", "Product.json");

                if (!File.Exists(path))
                {
                    _logger.LogWarning("El archivo Product.json no existe en la ruta: {Path}", path);
                    return products;
                }

                string data = File.ReadAllText(path);

                var productos = JsonSerializer.Deserialize<List<Products>>(data);

                if (productos != null)
                    products = productos;
                else
                    _logger.LogWarning("El archivo JSON está vacío o con formato inválido: {Path}", path);
            }
            catch (JsonException jsonEx)
            {
                _logger.LogError(jsonEx, "Error de formato al deserializar el archivo JSON.");
                throw;
            }
            catch (IOException ioEx)
            {
                _logger.LogError(ioEx, "Error de E/S al intentar leer el archivo JSON.");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error inesperado al obtener datos de productos.");
                throw;
            }


            return products;
        }
    }
}
