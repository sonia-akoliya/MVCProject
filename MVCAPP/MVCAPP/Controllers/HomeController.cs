﻿using Login_MVC_Project.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAPP.Controllers
{
    public class HomeController : Controller
    {
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Student student)
        {
            string query = "select Count(*) from Student where ( Email = @Email and Password = @Password)";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@Email", student.Email);
                cmd.Parameters.AddWithValue("@Password", student.Password);

                con.Open();
                int i = int.Parse(cmd.ExecuteScalar().ToString());
                con.Close();
                if (i > 0)
                {
                    return Content("Welcome, login successfully.");
                }
                else
                {
                    ModelState.AddModelError("", "something went wrong try later!");
                }
            }
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Student student)
        {
            string query = "insert into Student values(@Name,@Phone,@Email,@Password)";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@Email", student.Email);
                cmd.Parameters.AddWithValue("@Phone", student.Phone);
                cmd.Parameters.AddWithValue("@Name", student.Name);
                cmd.Parameters.AddWithValue("@Password", student.Password);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
            return View();
        }
    }
}