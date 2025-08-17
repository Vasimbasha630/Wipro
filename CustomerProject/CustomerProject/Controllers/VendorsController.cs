using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorsController : ControllerBase
    {
        private readonly CmsDbContext _ctx;
        public VendorsController(CmsDbContext ctx) => _ctx = ctx;

        // GET  api/Vendors
        [HttpGet]
        public async Task<IEnumerable<Vendor>> GetAll() =>
            await _ctx.Vendors.ToListAsync();
    }
}
