using Ecom.Commands;
using Ecom.Framework;
using Ecom.Queries;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.WebApi.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProductQueryController : ControllerBase
    {
        private readonly QueryManager queryManager;
        private readonly IHttpContextAccessor httpContextAccessor;

        public ProductQueryController(QueryManager queryManager, IHttpContextAccessor httpContextAccessor)
        {
            this.queryManager = queryManager;
            this.httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public async Task<QueryResult> SearchProducts([FromQuery] ProductSearchQuery query)
        {
            var user = httpContextAccessor.HttpContext.User;

            QueryResult result = await  queryManager.ExecuteAsync<ProductSearchQuery, QueryResult>(query);

            return result;
        }
    }
}
