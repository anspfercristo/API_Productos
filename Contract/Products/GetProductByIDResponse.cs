namespace Contract.Products
{
    using Models;

    public class GetProductByIDResponse
    {
        public bool Error { get; set; }
        public string? ErrorMsg { get; set; }
        public Products? product { get; set; }
    }
}
