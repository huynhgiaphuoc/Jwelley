using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jewelly.Models
{
    public class Productss
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public string secondImg { get; set; }
        public decimal Price { get; set; }      
        public string Path { get; set; }

    }
    public class Join
    {
        public JwelleyEntities db = new JwelleyEntities();
        public List<Productss> SelectProduct()
        {

            var product = (from i in db.ItemMsts
                           join p in db.ProdMsts on i.Prod_ID equals p.Prod_ID
                           join m in db.Imgs on i.Img_ID equals m.ID
                           where i.Prod_ID == p.Prod_ID && i.Img_ID == m.ID
                           select new Productss()
                           {
                               ID = i.Style_Code,
                               Name = p.Prod_Type,
                               Img = m.pic_1,
                               secondImg = m.pic_2,
                               Path = m.path_img,
                               Price = i.MRP
                           }).ToList();

            return product;
        }
    }
}
 
    
        

  
       
        
