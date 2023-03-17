using System;

namespace TestWasm.Server.Services.ProductService
{
	public class ProductService : IProductService
	{

        private readonly DataContext _context;
        private readonly ILogger<ProductService> _logger;

        public ProductService(DataContext context, ILogger<ProductService> logger)
		{
            _context = context;
            _logger = logger;

        }

        public async Task<ServiceResponse<List<Product>>> GetProduct()
        {
            //throw new NotImplementedException();
            var response = new ServiceResponse<List<Product>>();
            try
            {
                var result = await _context.Products.ToListAsync();
                if(result.Count > 0)
                {
                    response.Data = result;
                }
                else
                {
                    response.Success = false;
                    response.Message = "No record FOund";
                }
            }catch(Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }
            return response;
        }

        public async Task<ServiceResponse<ProductDetailsVM>> GetProduct(int Id)
        {
            //throw new NotImplementedException();
            var response = new ServiceResponse<ProductDetailsVM>();
            try
            {
                var result = await _context.Products.Where(x => x.Id == Id).FirstOrDefaultAsync();
                if(result != null)
                {
                    var r1 = new ProductDetailsVM
                    {
                        Description = result.Description,
                        Id = result.Id,
                        ImageUrl = result.ImageUrl,
                        Price = result.Price,
                        status = result.status,
                        Title = result.Title
                    };
                    response.Data = r1;
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                response.Message = ex.Message;
                response.Success = false;
            }
            return response;
        }
    }
}

