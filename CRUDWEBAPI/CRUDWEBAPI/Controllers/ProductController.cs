using CRUDWEBAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDWEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductRepository productRepository;

        public ProductController()
        {
            productRepository = new ProductRepository();
          
        }
        
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return productRepository.GetAll();
        }
        
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return productRepository.GetById(id);
        }

        [HttpPost]
        public void Post([FromBody] Product prod)
        {
            if (ModelState.IsValid)
                productRepository.Add(prod);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Product prod)
        {

            prod.ProductId = id;
            if (ModelState.IsValid)
                productRepository.Update(prod);
        }
        [HttpDelete]
        public void Delete(int id)
        {
            productRepository.Delete(id);
            
        }


    }


}
