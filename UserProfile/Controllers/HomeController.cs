using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.SessionState;
using UserProfile.Models;

namespace UserProfile.Controllers
{
    public class HomeController : Controller
    {
        static String str = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=laukik;Integrated Security=True;Pooling=False;MultipleActiveResultSets=true";
        SqlConnection cn = new SqlConnection(connectionString : str);
       
        // GET: User
        public ActionResult Index()
        {
            try
            {
                 
                if (Request.Cookies["user"] == null)
                {
                    Users u1 = new Users();
                    return View(u1);
                }
                
                int userId = Convert.ToInt32(Request.Cookies["user"].Value);
                Debug.WriteLine("useridLogin =" + userId);
                Users user1 = (Users)Session["user"];
                if (user1 != null)
                {
                    return RedirectToAction("HomePage");

                }
                else if (userId > 0)
                {
                    return RedirectToAction("HomePage");

                }
                Users u = new Users();
                return View(u);
            }
            catch (Exception ex)
            {
                Users u = new Users();
                Debug.WriteLine(ex.Message);
                return View(u);
                
            }
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Users user)
        {
            try {


                
             SqlCommand cmd = new SqlCommand();
            cn.Open();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from Users where emailId=@id and password=@password ";
            cmd.Parameters.AddWithValue("@id",user.emailId);
            cmd.Parameters.AddWithValue("@password", user.password);

            SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                   
                    user.fullName = dr["fullName"].ToString();
                   
                    user.phoneNo = Convert.ToInt64(dr["phoneNo"]);
                    
                    user.cityId = Convert.ToInt32(dr["cityId"]);
                    
                    user.userName = dr["userName"].ToString();
                    
                    user.userId = Convert.ToInt32(dr["userId"]);

                    //SessionIDManager manager = new SessionIDManager();

                    if (user.RememberMe)
                    {
                        HttpCookie objCookie = new HttpCookie("user");
                        objCookie.Expires = DateTime.Now.AddDays(1);
                        objCookie.Value = user.userId.ToString();
                        objCookie.Expires = DateTime.Now.AddDays(2d);
                        Response.Cookies.Add(objCookie);
                    }
                    

                    Session["user"] = user;
                    
                    cn.Close();
                    ViewBag.msg = "You Have Logged In Successful.";
                    //string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                    //string url = "http:://localhost:50759/"+ controllerName + "/" + "HomePage";
                    //Debug.WriteLine(url);
                    //ViewBag.contr = url;
                    return RedirectToAction("SuccessMsg");
                
                }
                else
                {
                    ViewBag.msg = "Invalid Login Credentials.";
                    string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                    string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                    ViewBag.contr = controllerName+"/"+actionName;

                    cn.Close();
                    return View("ErrorView");
                }

            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return View();
            }


              
        }

        public ActionResult LogOut()
        {
            Debug.WriteLine("Logged out");
            Session.Abandon();
            Response.Cookies["user"].Expires = DateTime.Now.AddDays(-10); 
            return RedirectToAction("Index");
        }
        public ActionResult SuccessMsg()
        {
            try
            {
                //Debug.WriteLine("sucess started");
                if (Request.Cookies["user"] == null)
                {
                    Users u1 = new Users();
                    return RedirectToAction("index");
                }
                Debug.WriteLine("cokies are present ");
                int userId = Convert.ToInt32(Request.Cookies["user"].Value);
                Debug.WriteLine("useridLogin =" + userId);
                Users user1 = (Users)Session["user"];
                if (user1 != null || userId > 0)
                {
                    ViewBag.msg = "You Have Logged In Successful.";
                    string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                    ViewBag.contr = "/" + controllerName + "/" + "HomePage";
                    
                    return View();

                }
                else
                {
                    ViewBag.msg = "You Have Been Logged Out.Please Log In gain";
                    string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                    ViewBag.contr = controllerName + "/" + "Index";
                    return RedirectToAction("ErrorView");
                }
            }catch(Exception ex)
            {
                return View();
            }
            
        }

        public ActionResult Details(int id)
        {
            Users u1 = new Users(); 
            try
            {
                if (Request.Cookies["user"] == null)
                {
                    Users u2 = new Users();
                    return RedirectToAction("index");
                }
                Debug.WriteLine("cokies are present ");
                int userId = Convert.ToInt32(Request.Cookies["user"].Value);
                Debug.WriteLine("useridLogin =" + userId);
                Users user2 = (Users)Session["user"];
                if (user2 == null || userId <= 0)
                {
                    ViewBag.msg = "You Have Logged Out.Please Log In";

                    
                    return RedirectToAction("ErrorView");

                }
                SqlCommand cmd = new SqlCommand();
                cn.Open();
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select * from Users where userid=@id ";
                cmd.Parameters.AddWithValue("@id",id);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    u1 = new Users() { userId = Convert.ToInt32(dr["userId"]), userName = dr["userName"].ToString(), fullName = dr["fullName"].ToString(), emailId = dr["emailId"].ToString(), password = dr["emailId"].ToString(), phoneNo = Convert.ToInt64(dr["phoneNo"]), cityId = Convert.ToInt32(dr["cityId"]) };
                }

             

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
            return View(u1);
        }

     

        public ActionResult HomePage()
        {
            try
            {
                if (Request.Cookies["user"] == null)
                {
                    Users u1 = new Users();
                    return RedirectToAction("Index");
                }
                int userId = Convert.ToInt32(Request.Cookies["user"].Value);
                Debug.WriteLine("userid ="+userId);
                Users user = (Users)Session["user"];
                if (user != null  )
                {
                    return View(user);

                }
                else if (userId > 0)
                {
                    SqlCommand cmd = new SqlCommand();
                    cn.Open();
                    Users u1 = new Users();
                    cmd.Connection = cn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    Debug.WriteLine("useridElseif =" + userId);
                    cmd.CommandText = "select * from Users where userid=@id ";
                    cmd.Parameters.AddWithValue("@id", userId);
                    SqlDataReader dr = cmd.ExecuteReader();
                    bool flag = false;
                    if (dr.Read())
                    {
                        flag = true;
                        u1 = new Users() { userId = Convert.ToInt32(dr["userId"]), userName = dr["userName"].ToString(), fullName = dr["fullName"].ToString(), emailId = dr["emailId"].ToString(), password = dr["emailId"].ToString(), phoneNo = Convert.ToInt64(dr["phoneNo"]), cityId = Convert.ToInt32(dr["cityId"]) };
                    }
                    Debug.WriteLine("user.userid =" + u1.userId);
                    if (flag)
                    {
                        return View(u1);
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                    
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }catch(Exception ex)
            {
                Debug.Write(ex.Message);
                return View();
            }
            
        }
      
        // GET: User/Create
        public ActionResult Create()
        {
            Users u1 = new Users(); ;
            try
            {

                SqlCommand cmd = new SqlCommand();
                cn.Open();
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select * from city ";
                List<SelectListItem> city = new List<SelectListItem>();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    city.Add(new SelectListItem {Text=dr["cityName"].ToString(),Value=dr["cityId"].ToString() });
                    Debug.WriteLine(dr["cityId"]);
                }
                
                u1.Cities = city;
               
            }catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
            return View(u1);

        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(Users user)
        {
            try
            {
                // TODO: Add insert logic here
                
                cn.Open();
                SqlCommand cmdExist = new SqlCommand("IsUserExist",cn);
                
                cmdExist.CommandType = System.Data.CommandType.StoredProcedure;
                cmdExist.Parameters.AddWithValue("@param1",user.emailId);
                Debug.WriteLine("Executing procedure 1 "+user.cityId);
                SqlDataReader dr1 = cmdExist.ExecuteReader();
                int check = 0;
                if (dr1.Read())
                {
                     check = Convert.ToInt32(dr1["userId"]);
                }
               
                Debug.WriteLine("Executed procedure 1 result = "+check);
                if (check>0)
                {
                    ViewBag.message = "User Already Exist. Please Log In";
                    return RedirectToAction("Index");
                }


                SqlCommand cmd1 = new SqlCommand("userIdIncrement",cn);
                
                cmd1.CommandType = System.Data.CommandType.Text;

                cmd1.CommandText = "SELECT isnull(max(userid),0)+1 from Users";
                Debug.WriteLine("Executed procedure 1 result ");
                SqlDataReader dr = cmd1.ExecuteReader();
                if (dr.Read())
                {
                   user.userId = Convert.ToInt32(dr[0]);
                    Debug.WriteLine("Executed procedure 1 result = " + user.userId);

                }


                Debug.WriteLine("Executed procedure 2 result = " + user.userId);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "insert into Users values(@userid,@username,@name,@Email,@password,@cityid,@phone) ";
                cmd.Parameters.AddWithValue("@userid", user.userId);
                cmd.Parameters.AddWithValue("@name",user.fullName);
                cmd.Parameters.AddWithValue("@Email",user.emailId);
                cmd.Parameters.AddWithValue("@password",user.password);
                cmd.Parameters.AddWithValue("@phone",user.phoneNo);
                cmd.Parameters.AddWithValue("@username",user.userName);
                cmd.Parameters.AddWithValue("@cityid",user.cityId);
                Debug.WriteLine("Executing query");
                int n = cmd.ExecuteNonQuery();
                Debug.WriteLine("Executing query result = " + n);
                ViewBag.message = "Created Successfuly Please Log In.";
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id=0)
        {
            Users u1 = new Users(); ;
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select * from city ";
                List<SelectListItem> city = new List<SelectListItem>();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    city.Add(new SelectListItem { Text = dr["cityName"].ToString(), Value = dr["cityId"].ToString() });
                    Debug.WriteLine(dr["cityId"]);


                }


                SqlCommand cmd1 = new SqlCommand();
               
                cmd1.Connection = cn;
                cmd1.CommandType = System.Data.CommandType.Text;

                cmd1.CommandText = "select * from Users where userId = @id";
                cmd1.Parameters.AddWithValue("@id", id);
                SqlDataReader datar = cmd1.ExecuteReader();
                if (datar.Read())
                {
                    u1 = new Users() { userId = Convert.ToInt32(datar["userId"]), userName = datar["userName"].ToString(), fullName = datar["fullName"].ToString(), emailId = datar["emailId"].ToString(), password = datar["emailId"].ToString(), phoneNo = Convert.ToInt64(datar["phoneNo"]), cityId = Convert.ToInt32(datar["cityId"]), Cities = city };
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
            return View(u1);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Users user)
        {
            try
            {
                // TODO: Add insert logic here

                cn.Open();
               
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "update Users set userName=@username,fullName=@name,emailId=@Email,password=@password,cityId=@cityid,phoneNo=@phone where userId=@id ";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", user.fullName);
                cmd.Parameters.AddWithValue("@Email", user.emailId);
                cmd.Parameters.AddWithValue("@password", user.password);
                cmd.Parameters.AddWithValue("@phone", user.phoneNo);
                cmd.Parameters.AddWithValue("@username", user.userName);
                cmd.Parameters.AddWithValue("@cityid", user.cityId);
                Debug.WriteLine("Executing query");
                int n = cmd.ExecuteNonQuery();
                Debug.WriteLine("Executing query result = " + n);
                ViewBag.message = "Created Successfuly Please Log In.";
                return RedirectToAction("HomePage");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
