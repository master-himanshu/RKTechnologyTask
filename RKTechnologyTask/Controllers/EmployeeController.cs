using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using RKTechnologyTask.Models;
using RKTechnologyTask.SQlConnect;
using System.Data;

namespace RKTechnologyTask.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            var list = new List<EmployeeListModel>();
            Connection conn = new Connection();
            DataTable dt = new DataTable();
            dt = conn.FillQry("Select EmployeeId,  EmployeeName,Email,MobileNumber,DOB,Cu.CountryName,S.StateName,C.CityName,Hobbies,Gendar From EmployeeTable E inner join Country Cu on Cu.CountryId=E.CountryId Inner Join State S on S.StateId=E.StateId Inner Join City C on C.CityId =E.CityId Where Isdelete=1");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EmployeeListModel model = new EmployeeListModel()
                {
                    EmployeeId = Convert.ToInt32(dt.Rows[i]["EmployeeId"]),
                    EmployeeName = dt.Rows[i]["EmployeeName"].ToString(),
                    Email = dt.Rows[i]["Email"].ToString(),
                    MobileNumber = dt.Rows[i]["MobileNumber"].ToString(),
                    DOB = Convert.ToDateTime(dt.Rows[i]["DOB"]),
                    CountryName = dt.Rows[i]["CountryName"].ToString(),
                    StateName = dt.Rows[i]["StateName"].ToString(),
                    CityName = dt.Rows[i]["CityName"].ToString(),
                    Hobbies = dt.Rows[i]["Hobbies"].ToString(),
                    Gendar = dt.Rows[i]["Gendar"].ToString(),
                };
                list.Add(model);
            }

            return View(list);
        }
        public IActionResult CreateEmployee()
        {
            var model = new EmployeeModel();

            model.HobbiesList = new List<string>
              {
                   "Cricket",
                   "Music",
                   "Reading",
                   "Traveling"
             };
            ViewBag.CountryDDL = CountryDDL();
            return View(model);
        }
        public List<SelectListItem> CountryDDL()
        {
            List<SelectListItem> _list = new List<SelectListItem>();

            Connection conn = new Connection();
            DataTable dt = new DataTable();
            dt = conn.FillQry("Select CountryId,CountryName From Country");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                _list.Add(new SelectListItem
                {
                    Value = dt.Rows[i]["CountryId"].ToString(),
                    Text = dt.Rows[i]["CountryName"].ToString()
                });
            }
            return _list;
        }

        public JsonResult GetStateByCountry(int countryId)
        {
            Connection conn = new Connection();
            DataTable dt = conn.FillQry("SELECT StateId, StateName, CountryId FROM State WHERE CountryId = " + countryId);

            List<SelectListItem> stateList = new List<SelectListItem>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                stateList.Add(new SelectListItem
                {
                    Value = dt.Rows[i]["StateId"].ToString(),
                    Text = dt.Rows[i]["StateName"].ToString()
                });
            }

            return Json(stateList);
        }
        public JsonResult GetCityByState(int stateId)
        {
            Connection conn = new Connection();
            DataTable dt = conn.FillQry("SELECT CityId, CityName FROM City WHERE StateId = " + stateId);

            List<SelectListItem> cityList = new List<SelectListItem>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cityList.Add(new SelectListItem
                {
                    Value = dt.Rows[i]["CityId"].ToString(),
                    Text = dt.Rows[i]["CityName"].ToString()
                });
            }

            return Json(cityList);
        }

        public IActionResult SaveOrUpdate(EmployeeModel model)
        {

            string hobbies = model.HobbiesList != null
              ? string.Join(",", model.HobbiesList)
              : "";
            Connection conn = new Connection();
            SqlConnection sqlConn = conn.Connect();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlConn;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "SpEmployee";

            sqlcmd.Parameters.AddWithValue("@EmployeeId ", model.EmployeeId);
            sqlcmd.Parameters.AddWithValue("@EmployeeName", model.EmployeeName);
            sqlcmd.Parameters.AddWithValue("@Email", model.Email);
            sqlcmd.Parameters.AddWithValue("@MobileNumber", model.MobileNumber);
            sqlcmd.Parameters.AddWithValue("@DOB", model.DOB);
            sqlcmd.Parameters.AddWithValue("@CountryId", model.CountryId);
            sqlcmd.Parameters.AddWithValue("@StateId", model.StateId);
            sqlcmd.Parameters.AddWithValue("@CityId", model.CityId);
            sqlcmd.Parameters.AddWithValue("@Hobbies", hobbies);
            sqlcmd.Parameters.AddWithValue("@Gendar", model.Gender);
            if (model.EmployeeId == 0)
            {
                sqlcmd.Parameters.AddWithValue("@flag", "I");
            }
            else
            {
                sqlcmd.Parameters.AddWithValue("@flag", "U");
            }
            sqlcmd.ExecuteNonQuery();
            return RedirectToAction("CreateEmployee");
        }
        public IActionResult GeyById(int id)
        {
            ViewBag.CountryDDL = CountryDDL();
            Connection conn = new Connection();
            DataTable dt = new DataTable();
            dt = conn.FillQry("Select EmployeeId,EmployeeName,Email,MobileNumber,DOB,CountryId,StateId,CityId,Hobbies,Gendar From EmployeeTable Where EmployeeId="+id);
            EmployeeModel model = new EmployeeModel()
            {
                EmployeeId = Convert.ToInt32(dt.Rows[0]["EmployeeId"]),
                EmployeeName = dt.Rows[0]["EmployeeName"].ToString(),
                Email = dt.Rows[0]["Email"].ToString(),
                MobileNumber = dt.Rows[0]["MobileNumber"].ToString(),
                DOB = Convert.ToDateTime(dt.Rows[0]["DOB"]),
                CountryId = Convert.ToInt32(dt.Rows[0]["CountryId"]),
                StateId = Convert.ToInt32(dt.Rows[0]["StateId"]),
                CityId = Convert.ToInt32(dt.Rows[0]["CityId"]),
                HobbiesList = dt.Rows[0]["Hobbies"].ToString().Split(',').ToList(),
                Gender = dt.Rows[0]["Gendar"].ToString(),

            };

            return View("CreateEmployee", model);
        }
        public IActionResult SoftDetele(int id )
        {
            Connection conn = new Connection();
            DataTable dt = new DataTable();
            dt = conn.FillQry(" Update EmployeeTable Set Isdelete =0");
            return RedirectToAction("Index");
        }
        public JsonResult SearchEmployee(string search)
        {
            var list = new List<EmployeeListModel>();
            Connection conn = new Connection();
            DataTable dt = new DataTable();
            dt = conn.FillQry("Select EmployeeId,  EmployeeName,Email,MobileNumber,DOB,Cu.CountryName,S.StateName,C.CityName,Hobbies,Gendar From EmployeeTable E inner join Country Cu on Cu.CountryId=E.CountryId Inner Join State S on S.StateId=E.StateId Inner Join City C on C.CityId =E.CityId WHERE EmployeeName LIKE '%"+ search+"%'");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                list.Add(new EmployeeListModel
                {
                    EmployeeId = Convert.ToInt32(dt.Rows[i]["EmployeeId"]),
                    EmployeeName = dt.Rows[i]["EmployeeName"].ToString(),
                    Email = dt.Rows[i]["Email"].ToString(),
                    MobileNumber = dt.Rows[i]["MobileNumber"].ToString(),
                    DOB = Convert.ToDateTime(dt.Rows[i]["DOB"]),
                    CountryName = dt.Rows[i]["CountryName"].ToString(),
                    StateName = dt.Rows[i]["StateName"].ToString(),
                    CityName = dt.Rows[i]["CityName"].ToString(),
                    Hobbies = dt.Rows[i]["Hobbies"].ToString(),
                    Gendar = dt.Rows[i]["Gendar"].ToString()
                });

            }
            return Json(list);
        }

    }
}
