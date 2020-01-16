using MyFootballWebsite.App_Data;
using MyFootballWebsite.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace MyFootballWebsite.Context
{
    public class HomeContext
    {

        public Article GetArticle(int id, MyFootballDatabaseEntities1 _db)
        {
            var article = _db.tbl_Articles.First(x => x.Id == id);
            var author = _db.tbl_Authors.First(o => o.Id == article.ArticleSubmittedBy);

            Article toReturn = new Article
            {
                Id = article.Id,
                ArticleTitle = article.ArticleTitle,
                ArticleContent = article.ArticleContent,
                ArticleSubmittedBy = author.AuthorFirstName + ' ' + author.AuthorLastName,
                ArticleCreated = article.ArticleCreated.ToShortDateString()
            };
            return toReturn;
        }

        public List<Article> GetHeadlineNews()
        {
            string cs;
            List<Article> toReturn = new List<Article>();

            // put this into a method in ~/helper?
            cs = ConfigurationManager.ConnectionStrings["MyFootballDatabaseEntities1"].ConnectionString;

            var dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(cs))
            using (var cmd = new SqlCommand("dbo.GetHeadlineNews", conn))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }

            foreach (DataRow dr in dt.Rows)
            {
                Article article = new Article
                {
                    Id = (int)dr["id"],
                    ArticleTitle = dr["ArticleTitle"].ToString(),
                    ArticleContent = dr["ArticleContent"].ToString(),
                    ArticleCreated = dr["ArticleCreated"].ToString(),
                    ArticleSubmittedBy = dr["AuthorFirstName"].ToString() + ' ' + dr["AuthorLastName"].ToString()
                };

                toReturn.Add(article);
            }
            return toReturn;
        }
    }
}