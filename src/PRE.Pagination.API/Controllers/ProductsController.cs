using Microsoft.AspNetCore.Mvc;
using PRE.Pagination.API.Application.InputModels;
using PRE.Pagination.API.Application.Services;
using PRE.Pagination.API.Data.Entities;
using PRE.Pagination.API.ExtensionsMethods;

namespace PRE.Pagination.API.Controllers
{
    [Produces("application/json")]
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET api/products
        /// <summary>
        /// Obtém todos os produtos
        /// </summary>   
        /// <returns>Lista de Produtos</returns>                
        /// <response code="200">Sucesso</response>                
        /// <response code="204">Nenhum registro localizado</response>         
        /// <response code="400">Falha na requisição</response>           
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllProduct()
        {
            var result = await _productService.GetAllAsync();

            return result.Count == 0 ? NoContent() : Ok(result);
        }

        // GET api/products/paged-list
        /// <summary>
        /// Obtém todos os produtos utilizando a estratégia estendendo List
        /// </summary>   
        /// <param name="PageNumber">Índice da página</param>
        /// <param name="PageSize">Quantidade de registros por página</param>        
        /// <returns>Lista de Produtos</returns>                
        /// <response code="200">Sucesso</response>                
        /// <response code="204">Nenhum registro localizado</response>         
        /// <response code="400">Falha na requisição</response>           
        [HttpGet("paged-list")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllList([FromQuery] FindAllListInputModel query)
        {
            var result = await _productService.GetAllPagedAsync(query);

            Response.AddPagination<ProductModel>(result);

            return result.Count == 0 ? NoContent() : Ok(result);
        }

        // GET api/products/paged-queryable
        /// <summary>
        /// Obtém todos os produtos utilizando a estratégia com IQueryable
        /// </summary>   
        /// <param name="Offset">Índice da página</param>
        /// <param name="Limit">Quantidade de registros por página</param>        
        /// <returns>Lista de Produtos</returns>                
        /// <response code="200">Sucesso</response>                
        /// <response code="204">Nenhum registro localizado</response>         
        /// <response code="400">Falha na requisição</response>           
        [HttpGet("paged-queryable")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllQueryable([FromQuery] FindAllQueryableInputModel query)
        {
            var result = await _productService.GetAllQueryableAsync(query);

            return result.Count == 0 ? NoContent() : Ok(result);
        }

    }
}
