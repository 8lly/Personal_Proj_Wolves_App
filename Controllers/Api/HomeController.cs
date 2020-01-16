using MyFootballWebsite.Models;
using System.Net;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using MyFootballWebsite.App_Data;
using System;
using System.Web.Http;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MyFootballWebsite.Context;

namespace MyFootballWebsite.Controllers.Api
{
    [RoutePrefix("api/Home")]
    public class HomeController : ApiController
    {
        private readonly MyFootballDatabaseEntities1 _db;
        private readonly HomeContext _hc;

        public HomeController() { 
            _db = new MyFootballDatabaseEntities1();
            _hc = new HomeContext();
        }

        // GetArticle/1
        [HttpGet]
        [Route("GetArticle/{id}")]
        public async Task<IHttpActionResult> GetArticle(int id, MyFootballDatabaseEntities1 _db)
        {
            try
            {
                var toReturn = _hc.GetArticle(id, _db);
                return Content(HttpStatusCode.OK, toReturn);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }

        // GetHeadlineNews
        [HttpGet]
        [Route("GetHeadlineNews")]
        public async Task<IHttpActionResult> GetHeadlineNews()
        {
            try
            {
                var toReturn = _hc.GetHeadlineNews();
                return Content(HttpStatusCode.OK, toReturn);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }

    }
}
