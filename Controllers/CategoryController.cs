using Blog.Data;
using Blog.Extensions;
using Blog.Models;
using Blog.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers
{
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet("v1/categories")]
        public async Task<IActionResult> GetAsync([FromServices] BlogDataContext context)
        {
            try
            {
                var categories = await context.Categories.ToListAsync();

                return Ok(new ResultViewModel<List<Category>>(categories));
            }
            catch
            {
                return StatusCode(500,new ResultViewModel<List<Category>>( "05X12 Falha interna no servidor"));
            }
        }

        [HttpGet("v1/categories/{id:int}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromRoute]int id, 
            [FromServices]BlogDataContext context)
        {
            try
            {
                var category = await context
               .Categories
               .FirstOrDefaultAsync(c => c.Id == id);

                if (category == null)
                    return NotFound(new ResultViewModel<Category>("Conteúdo não encontrado"));

                return Ok(new ResultViewModel<Category>(category));
            }
                 catch
            {
                return StatusCode(500, new ResultViewModel<Category> ( "05X12 Falha interna no servidor"));
            }
           
        }
        [HttpPost("v1/categories")]
        public async Task<IActionResult> PostAsync(
                [FromBody] EditorCategoryViewModel model,
                [FromServices] BlogDataContext context)
        {
            if(!ModelState.IsValid)
                return BadRequest(new ResultViewModel<Category>(ModelState.GetErrors()));

            try
            {
                var category = new Category
                {
                    Id = 0,
                    Posts = [],
                    Name = model.Name,
                    Slug = model.Slug,
                };
                await context.Categories.AddAsync(category);
                await context.SaveChangesAsync();
                return Created($"v1/categories/{category.Id}",new ResultViewModel<Category>(category));
            }
            catch(DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<Category>("05XE9 Não foi possivel incluir a categoria"));
            }
            catch 
            {
                return StatusCode(500,new ResultViewModel<Category>( "05X10 Falha interna no servidor")); 
            }
        }

        [HttpPut("v1/categories/{id:int}")]
        public async Task<IActionResult> PutAsync(
            [FromRoute]int id,
            [FromBody] Category model,
            [FromServices]BlogDataContext context)
        {
            try
            {
                var category = await context
               .Categories
               .FirstOrDefaultAsync(c => c.Id == id);

                if (category == null) return NotFound(new ResultViewModel<Category>("Conteúdo não encontrado"));

                category.Name = model.Name;
                category.Slug = model.Slug;

                context.Categories.Update(category);
                await context.SaveChangesAsync();

                return Ok( new ResultViewModel<Category>(category));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<Category>("05XE8 Não foi possivel alterar a categoria"));
            }
            catch 
            {
                return StatusCode(500, new ResultViewModel<Category>( "05X11 Falha interna no servidor"));
            }
        }
        [HttpDelete("v1/categories/{id:int}")]
        public async Task<IActionResult> DeleteAsync(
                    [FromRoute]int id,
                    [FromServices]BlogDataContext context)
        {
            try
            {
                var category = await context
                .Categories
                .FirstOrDefaultAsync(c => c.Id == id);

                if (category == null) return NotFound(new ResultViewModel<Category>("Conteudo não entroncado"));

                context.Categories.Remove(category);
                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<Category>( category));

            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500,new ResultViewModel<Category>( "05XE7 Não foi possivel excluir a categoria"));
            }
            catch 
            {
                return StatusCode(500,new ResultViewModel<Category>( "05X12 Falha interna no servidor"));
            }
        }
                    
    }
}
