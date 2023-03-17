using System;


namespace TestWasm.Server.Services.ProductService
{
	public interface IProductService
	{
		Task<ServiceResponse<List<Product>>> GetProduct();

		Task<ServiceResponse<ProductDetailsVM>> GetProduct(int Id);
	}
}

