using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;



    public class Globals
    {
        //public static void WriteLog(Page page, string ErrorMessage, bool IsHandled = true, string pageName = "")
        //{
        //    try
        //    {
        //        string userName = "-";

        //        try
        //        {
        //            //userName = Global.CurrentUser.KSUser.IsMasterUser.Value ? Global.CurrentUser.KSUser.DisplayUsername : Global.CurrentUser.EdgeUser.DisplayUsername;

        //        }
        //        catch (Exception ex)
        //        {
        //        }

        //        string UserIP = GetIPAddress();
        //        System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace();
        //        if (IsHandled)
        //        {
        //            pageName = Path.GetFileName(page.Request.PhysicalPath);
        //        }

        //        if (ErrorMessage != "Thread was being aborted.")
        //        {
        //            using (YPADBContext ctx = new YPADBContext())
        //            {
        //                var exception = new LogException();
        //                exception.ExceptionDate = DateTime.UtcNow;
        //                exception.IsHandled = IsHandled;
        //                exception.UserName = userName;
        //                exception.PageName = pageName;
        //                exception.FunctionName = stackTrace.GetFrame(1).GetMethod().Name + " on {" + (stackTrace.GetFrame(1).GetMethod()).ReflectedType.Name + "}";
        //                exception.ErrorMessage = ErrorMessage;
        //                exception.UserIPAdress = UserIP;
        //                exception.Remarks = GetBrowsersDetails();

        //                ctx.LogExceptions.Add(exception);
        //                ctx.SaveChanges();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public static string GetIPAddress()
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string sIPAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(sIPAddress))
            {
                return context.Request.ServerVariables["REMOTE_ADDR"];
            }
            else
            {
                string[] ipArray = sIPAddress.Split(new Char[] { ',' });
                return ipArray[0];
            }
        }

        public static string GetBrowsersDetails()
        {
            string s = "";
            System.Web.HttpContext context = System.Web.HttpContext.Current;

            var _with1 = context.Request.Browser;

            s += "Browser Capabilities <br />";
            s += "Type = " + _with1.Type + "<br />";
            s += "Name = " + _with1.Browser + "<br />";
            s += "Version = " + _with1.Version + "<br />";
            s += "Major Version = " + _with1.MajorVersion + "<br />";
            s += "Minor Version = " + _with1.MinorVersion + "<br />";
            s += "Platform = " + _with1.Platform + "<br />";
            s += "Is Beta = " + _with1.Beta + "<br />";
            s += "Is Crawler = " + _with1.Crawler + "<br />";
            s += "Is AOL = " + _with1.AOL + "<br />";
            s += "Is Win16 = " + _with1.Win16 + "<br />";
            s += "Is Win32 = " + _with1.Win32 + "<br />";
            s += "Supports Frames = " + _with1.Frames + "<br />";
            s += "Supports Tables = " + _with1.Tables + "<br />";
            s += "Supports Cookies = " + _with1.Cookies + "<br />";
            s += "Supports VBScript = " + _with1.VBScript + "<br />";
            s += "Supports JavaScript = " + _with1.EcmaScriptVersion.ToString() + "<br />";
            s += "Supports Java Applets = " + _with1.JavaApplets + "<br />";
            s += "Supports ActiveX Controls = " + _with1.ActiveXControls + "<br />";
            s += "Supports JavaScript Version = " + context.Request.Browser["JavaScriptVersion"] + "<br />";
            return s;
        }

        public static DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
            TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }
    }

