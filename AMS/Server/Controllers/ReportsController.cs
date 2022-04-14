using AMS.Shared;
using AspNetCore.Reporting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Reflection;

namespace AMS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
     private readonly IWebHostEnvironment webHostEnvironment;
        public ReportsController(IWebHostEnvironment _webHostEnvironment)
        {
            webHostEnvironment = _webHostEnvironment;
        }
        public IActionResult SalesReport(List<Sales> sales)
        {
            var dt = new DataTable();
            dt = ToDataTable(sales);
            int extension = 1;
            string mimetype = "";
            var path = $"{ this.webHostEnvironment.WebRootPath}\\Reports\\SalesReport.rdlc";

            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("dsSales", dt);
            var result = localReport.Execute(RenderType.Pdf, extension, null, mimetype);

            return File(result.MainStream, "application/pdf");
        }
        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
    }
}
