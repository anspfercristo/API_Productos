
namespace Contract.Products
{
    using Models;

    public class GetListProductByIDsResponse
    {
        public bool Error { get; set; }
        public string? ErrorMsg { get; set; }
        public List<Products>? products { get; set; }
    }
}
