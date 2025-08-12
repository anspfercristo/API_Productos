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
                string path = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\..\", "Data", "Product", "Product.json"));

                if (!File.Exists(path))
                {
                    _logger.LogWarning("El archivo Product.json no existe en la ruta: {Path}", path);
                    return products;
                }

                string data = @"[
                          {
                            ""id"": 1,
                            ""name"": ""Auriculares Bluetooth Marca 1"",
                            ""imageUrl"": ""https://ejemplo.com/img/auricular1.jpg"",
                            ""description"": ""Auriculares inalámbricos con cancelación de ruido"",
                            ""price"": 79000.00,
                            ""rating"": 4.4,
                            ""specs"": {
                              ""batteryHours"": 24,
                              ""color"": ""Negro"",
                              ""connectivity"": ""Bluetooth 5.2""
                            }
                          },
                          {
                            ""id"": 2,
                            ""name"": ""Auriculares Bluetooth Marca 2"",
                            ""imageUrl"": ""https://ejemplo.com/img/auricular2.jpg"",
                            ""description"": ""Auriculares con micrófono integrado"",
                            ""price"": 75000.0,
                            ""rating"": 4.0,
                            ""specs"": {
                              ""batteryHours"": 18,
                              ""color"": ""Blanco"",
                              ""connectivity"": ""Bluetooth 5.0""
                            }
                          },
                          {
                            ""id"": 3,
                            ""name"": ""Auriculares Bluetooth Marca 3"",
                            ""imageUrl"": ""https://ejemplo.com/img/auricular2.jpg"",
                            ""description"": ""Auriculares sin cancelación de ruido"",
                            ""price"": 60000.0,
                            ""rating"": 4.0,
                            ""specs"": {
                              ""batteryHours"": 18,
                              ""color"": ""Blanco"",
                              ""connectivity"": ""Bluetooth 5.0""
                            }
                          }
                        ]";

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
