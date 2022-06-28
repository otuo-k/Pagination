using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pagination.KNO.Database;
using Pagination.KNO.Models;
using Pagination.KNO.SeedWork;

namespace Pagination.KNO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpPost]
        public ActionResult GetProducts(Pager pager)
        {
            return Ok(Database.ProductDb.GetAllProducts()
                           .SortByDynamic(pager.SortField, pager.SortDirection.ToUpper())  //#A
                           .PageEntities(pager));
        }
        /**********************************************************
         * As I said earlier, paging works only if the data is ordered. Otherwise, SQL Server will
           throw an exception. That’s because relational databases don’t guarantee the order in
           which data is handed back; there’s no default row order in a relational database.
          Reference: Entity Framework Core book 
         */
    }
}
