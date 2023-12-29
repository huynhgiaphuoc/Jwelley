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
        public ActionResult Index() {
        var model = new Join().SelectProduct().ToList();
        List<BrandMst> brand = db.BrandMsts.ToList();
        List<JewelTypeMst> jewe = db.JewelTypeMsts.ToList();
        List<CatMst> gold = db.CatMsts.ToList();
        List<GoldKrtMst> gold_t = db.GoldKrtMsts.ToList();
        List<StoneQltyMst> stone = db.StoneQltyMsts.ToList();
        dynamic models = new ExpandoObject();
        models.Brand = brand;
        models.Producter = model;
        models.Jewe = jewe;
        models.Cate = gold;
        models.GoldType = gold_t;
        models.Stone = stone;
        return View(models);
        }
        [HttpGet]
        public ActionResult Index(decimal priceto,decimal pricefrom,string brand,string jewe, string gold,string stone,string goldst)
        {
            if(brand != null)
            {
                if(jewe != null)
                {
                    if(gold != null)
                    {
                        if(stone != null)
                        {
                            if(goldst != null)
                            {
                               var s1 = 

                            }
                        }
                    }
                }
            }

            return View();

        }

    }
}