﻿using Jewelly.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Jwelley.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public JwelleyEntities db = new JwelleyEntities();
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string password, string username)
        {

            if (ModelState.IsValid)
            {

                var f_password = GetMD5(password);
                var data_cus = db.UserRegMsts.Where(s => s.Username == username && s.password.Equals(f_password));
                var data_ad = db.AdminLoginMsts.Where(s => s.userName == username && s.Password.Equals(f_password));
                
                if (data_cus.Count() > 0)
                {
                    //add session
                    Session["userFname"] = data_cus.FirstOrDefault().userFname;
                    Session["userLname"] = data_cus.FirstOrDefault().userLname;
                    Session["address"] = data_cus.FirstOrDefault().address;
                    Session["city"] = data_cus.FirstOrDefault().city;
                    Session["state"] = data_cus.FirstOrDefault().state;
                    Session["mobNo"] = data_cus.FirstOrDefault().mobNo;
                    Session["emailID"] = data_cus.FirstOrDefault().emailID;
                    Session["dob"] = data_cus.FirstOrDefault().dob;
                    Session["cdate"] = data_cus.FirstOrDefault().cdate;
                    Session["password"] = data_cus.FirstOrDefault().password;
                    Session["photo"] = data_cus.FirstOrDefault().photo;
                    Session["Username"] = data_cus.FirstOrDefault().Username;
                    Session["Path_photo"] = data_cus.FirstOrDefault().Path_photo;
                    return RedirectToAction("General", "Account");
                }


                else if (data_ad.Count() > 0)
                {
                    //add session
                    Session["Name_employee"] = data_ad.FirstOrDefault().Name_employee;
                    Session["Avatar"] = data_ad.FirstOrDefault().Avatar;
                    Session["Path_avt"] = data_ad.FirstOrDefault().Path_avt;
                    Session["Birthday"] = data_ad.FirstOrDefault().Birthday;
                    Session["Email"] = data_ad.FirstOrDefault().Email;
                    Session["Phone"] = data_ad.FirstOrDefault().Phone;
                    Session["Address"] = data_ad.FirstOrDefault().Address;
                    Session["PasswordAd"] = f_password;
                    Session["userName"] = data_ad.FirstOrDefault().userName;
                    //return View("~/Areas/Admin/Views/HomeAdmin/Index.cshtml");
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
            return RedirectToAction("Index", "Home");

        }
       

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(FormCollection form, UserRegMst user, string username)
        {
            if (ModelState.IsValid)
            {
                var check = db.UserRegMsts.FirstOrDefault(s => s.Username == username);
                if (check == null)
                {

                    user.userLname = form["userLname"];
                    user.userFname = form["userFname"];
                    user.address = form["address"];
                    user.city = form["city"];
                    user.state = "Online";
                    user.mobNo = form["mobNo"];
                    user.emailID = form["emailID"];
                    user.dob = form["dob"];
                    user.cdate = DateTime.Now.ToString();
                    user.password = GetMD5(form["password"]);
                    user.Username = form["Username"];
                    db.UserRegMsts.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ViewBag.error = "Username already exists";
                    return View();
                }
            }
            return View();
        }
         public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Index");
        }
        public ActionResult General()
        {
            return View();
        }
        

        public ActionResult Change()
        {
           
              return View();
        }
        [HttpPost]
        public ActionResult Change(string Password, UserRegMst userReg, string New)
        {
 
            var username = Session["Username"].ToString();

            var cpass = GetMD5(Password);
            var newpass = GetMD5(New);
            var data = db.UserRegMsts.Where(s => s.Username == username && s.password == cpass);
            if (data != null)
            {

                var cus = db.UserRegMsts.Where(s => s.Username == username && s.password == newpass).FirstOrDefault();
                if (cus == null)
                {
                    var users = db.UserRegMsts.FirstOrDefault(s => s.Username == username);
                    users.password = newpass;
                   
                    db.SaveChanges(); 
                    return RedirectToAction("General", "Account");

                }
                else
                {

                    return RedirectToAction("Change","Account");

                }
            }

            else
            {
                return RedirectToAction("Change", "Account");


            }


        }
    
    public ActionResult Information()
        {
            if (Session["Username"] == null)
            {
                return View();
            }
            else
            {
  var username = Session["Username"].ToString();

                UserRegMst users = db.UserRegMsts.Where(s => s.Username == username).FirstOrDefault();
            return View(users);
            }
          
            
           
        }
        [HttpPost]
        public ActionResult Information(UserRegMst users,HttpPostedFileBase imageFiles)
        {
           
                var username = Session["Username"].ToString();
                var testuser = db.UserRegMsts.FirstOrDefault(s => s.Username == username);
                if (testuser != null)
                {
                    UserRegMst user = db.UserRegMsts.Where(row => row.Username == username).FirstOrDefault();
               
                    user.userLname = users.userLname;
                    user.userFname = users.userFname;
                    user.address = users.address;
                    user.city = users.city;
                    user.dob = users.dob;
                    user.emailID = users.emailID;
                    user.mobNo = users.mobNo;
              

                var filename = user.Username + ".jpg";
                var path = Path.Combine(Server.MapPath("~/Content/Image/Customer"), filename);
                user.photo = filename;
                user.Path_photo = "/Content/Image/Customer/";
                imageFiles.SaveAs(path);
                db.SaveChanges();
                return RedirectToAction("General", "Account");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            
          
        }
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }
    }
}