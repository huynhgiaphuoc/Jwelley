using Jewelly.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jwelley.Controllers
{
    public class ProductController : Controller
    {
        public JwelleyEntities db = new JwelleyEntities();
        // GET: Product
        public ActionResult Cart()
        {
            return View();
        }
        public ActionResult Jewelry(decimal? MinPrice, decimal? MaxPrice,int? Brandtype,int? jewelry,int? Gold,int? Categorytype,int? stoneq,string prices) {
                var model = new Join().SelectProduct(MinPrice,MaxPrice,Brandtype,Gold,jewelry,Categorytype,stoneq,prices).ToList();       
                List<BrandMst> brand = db.BrandMsts.ToList();
                List<JewelTypeMst> jewe = db.JewelTypeMsts.ToList();
                List<CatMst> gold = db.CatMsts.ToList();
                List<GoldKrtMst> gold_t = db.GoldKrtMsts.ToList();
                List<StoneQltyMst> stone = db.StoneQltyMsts.ToList();
                dynamic models1 = new ExpandoObject();
                models1.Brand = brand;
                models1.Producter = model;
                models1.Jewe = jewe;
                models1.Cate = gold;
                models1.GoldType = gold_t;
                models1.Stone = stone;
           
               

                return View(models1);

        }
    }
}