using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly CmsDbContext _ctx;
        public MenuController(CmsDbContext ctx) => _ctx = ctx;

        // GET  api/Menu
        [HttpGet]
        public async Task<IEnumerable<Menu>> GetAll() =>
            await _ctx.Menus.ToListAsync();
    }
}
