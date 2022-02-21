using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using System.Web.Script.Serialization;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;
using System.Security.Cryptography;


/// <summary>
/// Summary description for GeneralF
/// </summary>
public class MGeneral
{
	public MGeneral()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string GetQueryValue(string strSQL, string strConnectionStringKey)
    {
        SqlConnection conGlobal = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[strConnectionStringKey].ConnectionString);
        DataTable dt = new DataTable();
        string[] a = new string[1];
        string ls_return = "";
        try
        {
            if (conGlobal.State == ConnectionState.Closed)
                conGlobal.Open();
            SqlCommand cmd = new SqlCommand(strSQL, conGlobal);
            SqlDataReader DA = cmd.ExecuteReader();
            while (DA.Read())
                ls_return = DA.GetValue(0).ToString();
            return ls_return;
        }
        catch (Exception ex)
        {
            conGlobal.Close();
            return ex.Message.Trim();
            
        }
        finally
        {
            if (conGlobal.State == ConnectionState.Open)
                conGlobal.Close();
        }
    }

    public string ComputeHash(string plainText, string civiid, string hashAlgorithm, byte[] saltBytes)
    {
        // If salt is not specified, generate it.
        if (saltBytes == null)
        {
            // Define min and max salt sizes.
            int minSaltSize = 4;
            int maxSaltSize = 8;

            // Generate a random number for the size of the salt.
            Random random = new Random();
            int saltSize = random.Next(minSaltSize, maxSaltSize);

            // Allocate a byte array, which will hold the salt.
            saltBytes = new byte[saltSize];

            // Initialize a random number generator.
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

            // Fill the salt with cryptographically strong byte values.
            rng.GetNonZeroBytes(saltBytes);
        }

        // Convert plain text into a byte array.
        byte[] plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText + civiid);

        // Allocate array, which will hold plain text and salt.
        byte[] plainTextWithSaltBytes =
        new byte[plainTextBytes.Length + saltBytes.Length];

        // Copy plain text bytes into resulting array.
        for (int i = 0; i < plainTextBytes.Length; i++)
            plainTextWithSaltBytes[i] = plainTextBytes[i];

        // Append salt bytes to the resulting array.
        for (int i = 0; i < saltBytes.Length; i++)
            plainTextWithSaltBytes[plainTextBytes.Length + i] = saltBytes[i];

        HashAlgorithm hash;

        // Make sure hashing algorithm name is specified.
        if (hashAlgorithm == null)
            hashAlgorithm = "";

        // Initialize appropriate hashing algorithm class.
        switch (hashAlgorithm.ToUpper())
        {

            case "SHA384":
                hash = new SHA384Managed();
                break;

            case "SHA512":
                hash = new SHA512Managed();
                break;

            default:
                hash = new MD5CryptoServiceProvider();
                break;
        }

        // Compute hash value of our plain text with appended salt.
        byte[] hashBytes = hash.ComputeHash(plainTextWithSaltBytes);

        // Create array which will hold hash and original salt bytes.
        byte[] hashWithSaltBytes = new byte[hashBytes.Length +
        saltBytes.Length];

        // Copy hash bytes into resulting array.
        for (int i = 0; i < hashBytes.Length; i++)
            hashWithSaltBytes[i] = hashBytes[i];

        // Append salt bytes to the result.
        for (int i = 0; i < saltBytes.Length; i++)
            hashWithSaltBytes[hashBytes.Length + i] = saltBytes[i];

        // Convert result into a base64-encoded string.
        string hashValue = Convert.ToBase64String(hashWithSaltBytes);

        // Return the result.
        return hashValue;
    }



    public bool VerifyHash(string plainText, string civilid, string hashAlgorithm, string hashValue)
    {

        // Convert base64-encoded hash value into a byte array.
        byte[] hashWithSaltBytes = Convert.FromBase64String(hashValue);

        // We must know size of hash (without salt).
        int hashSizeInBits, hashSizeInBytes;

        // Make sure that hashing algorithm name is specified.
        if (hashAlgorithm == null)
            hashAlgorithm = "";

        // Size of hash is based on the specified algorithm.
        switch (hashAlgorithm.ToUpper())
        {

            case "SHA384":
                hashSizeInBits = 384;
                break;

            case "SHA512":
                hashSizeInBits = 512;
                break;

            default: // Must be MD5
                hashSizeInBits = 128;
                break;
        }

        // Convert size of hash from bits to bytes.
        hashSizeInBytes = hashSizeInBits / 8;

        // Make sure that the specified hash value is long enough.
        if (hashWithSaltBytes.Length < hashSizeInBytes)
            return false;

        // Allocate array to hold original salt bytes retrieved from hash.
        byte[] saltBytes = new byte[hashWithSaltBytes.Length - hashSizeInBytes];

        // Copy salt from the end of the hash to the new array.
        for (int i = 0; i < saltBytes.Length; i++)
            saltBytes[i] = hashWithSaltBytes[hashSizeInBytes + i];

        // Compute a new hash string.
        string expectedHashString = ComputeHash(plainText, civilid, hashAlgorithm, saltBytes);

        // If the computed hash matches the specified hash,
        // the plain text value must be correct.
        return (hashValue == expectedHashString);
    }




    public string GetErrTag(string strErrMsg)
    {
        return "<div class=\"alert alert-danger\"><button type=\"button\" class=\"close\" data-dismiss=\"alert\"><i class=\"ace-icon fa fa-times\"></i></button><strong>" + strErrMsg + "</strong> </div>";
    }
    public string GetSucTag(string strErrMsg)
    {
        return "<div class=\"alert alert-info\"><button type=\"button\" class=\"close\" data-dismiss=\"alert\"><i class=\"ace-icon fa fa-times\"></i></button><strong>" + strErrMsg + "</strong> </div>";
    }

    public string GenerateOTP()
    {
        string alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string small_alphabets = "abcdefghijklmnopqrstuvwxyz";
        string numbers = "1234567890";

        string characters = numbers;

        // characters += alphabets + small_alphabets + numbers;

        int length = 6;
        string otp = string.Empty;
        for (int i = 0; i < length; i++)
        {
            string character = string.Empty;
            do
            {
                int index = new Random().Next(0, characters.Length);
                character = characters.ToCharArray()[index].ToString();
            } while (otp.IndexOf(character) != -1);
            otp += character;
        }
        return otp;
    }

    public DataInsertReturn ExecuteNonQueryReturn(string strSQL, string strConnectionStringKey)
    {
        SqlConnection conGlobal = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[strConnectionStringKey].ConnectionString);

        string[] a = new string[1];
        DataInsertReturn dtr = new DataInsertReturn();
        try
        {

            dtr.DataInsert = true;

            if (conGlobal.State == ConnectionState.Closed)
                conGlobal.Open();


            SqlCommand cmd = new SqlCommand(strSQL, conGlobal);
            cmd.ExecuteNonQuery();

            dtr.ErrorMsg = "Insert Sucessfully";


            return dtr;
        }
        catch (Exception ex)
        {           
            dtr.DataInsert = false;
            dtr.ErrorMsg = ex.Message;
            conGlobal.Close();
            return dtr;
        }
        finally
        {
            if (conGlobal.State == ConnectionState.Open)
                conGlobal.Close();
        }
    }


    public static bool IsNumeric(object Expression)
    {
        double retNum;

        bool isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
        return isNum;
    }

    public fnReturnCivilId CheckCivilId(string ls_civilid)
    {
        fnReturnCivilId dtr = new fnReturnCivilId();
        dtr.ValidCivil = false;

        if (IsNumeric(ls_civilid).Equals(false))
        {
            dtr.ValidCivil = false;
        }
        else
        {
            int cnt = 0;
            if (ls_civilid != string.Empty && (ls_civilid.Length == 12))
            {

                string civil = ls_civilid.ToString();


                int c1 = int.Parse(civil.Substring(0, 1));
                int c2 = int.Parse(civil.Substring(1, 1));
                int c3 = int.Parse(civil.Substring(2, 1));
                int c4 = int.Parse(civil.Substring(3, 1));
                int c5 = int.Parse(civil.Substring(4, 1));
                int c6 = int.Parse(civil.Substring(5, 1));
                int c7 = int.Parse(civil.Substring(6, 1));
                int c8 = int.Parse(civil.Substring(7, 1));
                int c9 = int.Parse(civil.Substring(8, 1));
                int c10 = int.Parse(civil.Substring(9, 1));
                int c11 = int.Parse(civil.Substring(10, 1));
                int c12 = int.Parse(civil.Substring(11, 1));

                int vresult = ((c1 * 2) + (c2) + (c3 * 6) + (c4 * 3) + (c5 * 7) + (c6 * 9) + (c7 * 10) + (c8 * 5) + (c9 * 8) + (c10 * 4) + (c11 * 2));
                double vresult1 = (vresult / 11);
                double tvresult1 = Math.Floor(vresult1);
                double tvresult2 = (tvresult1 * 11);
                double totvresult = (vresult - tvresult2);
                double alltotvresult = (11 - totvresult);
                if (alltotvresult == c12)
                {
                    //txtCivil.Text = civil;

                    string dob = DobFromCivil(ls_civilid);
                    string[] Arrdob = dob.Split('~');

                    cnt = Convert.ToInt16(Arrdob[0]);
                    if (cnt == 1)
                    {
                        dtr.ValidCivil = false;

                    }
                    else
                    {
                        dob = Arrdob[1];
                        dtr.ValidCivil = true;
                        dtr.Dob = dob;
                        DateTime StartDate = Convert.ToDateTime(dob);
                        dtr.age = GetDifferenceInYears(StartDate, DateTime.Today);
                    }

                }
                else
                {
                    dtr.ValidCivil = false;
                }



            }
        }

        return dtr;
    }


    public int GetDifferenceInYears(DateTime startDate, DateTime endDate)
    {
        //Excel documentation says "COMPLETE calendar years in between dates"
        int years = endDate.Year - startDate.Year;

        if (startDate.Month == endDate.Month &&// if the start month and the end month are the same
            endDate.Day < startDate.Day// AND the end day is less than the start day
            || endDate.Month < startDate.Month)// OR if the end month is less than the start month
        {
            years--;
        }

        return years;
    }

    public string toEnglishNumber(string input)
    {
        string EnglishNumbers = "";

        for (int i = 0; i < input.Length; i++)

        {
            if (Char.IsDigit(input[i]))
            {
                EnglishNumbers += char.GetNumericValue(input, i);

            }
            else
            {
                EnglishNumbers += input[i].ToString();
            }

        }
        return EnglishNumbers;
    }



    public string DobFromCivil(string civil_id)
    {
        int year;
        int cnt = 0;
        string returndob = null;

        //if input is arabic numberes. 
        string enddate1 = toEnglishNumber(civil_id);

        string first_digit = enddate1.Substring(0, 1);
        string sub = enddate1.Substring(1, 6);
        string year1 = sub.Substring(0, 2);
        string month = sub.Substring(2, 2);
        string date = sub.Substring(4, 2);
        int diff = 0;
        string dob = date + "/" + month + "/" + year1;



        DateTime foundDate;
        Match matchResult = Regex.Match(dob,
            "^(?<day>[0-3]?[0-9])/(?<month>[0-3]?[0-9])/(?<year>(?:[0-9]{2})?[0-9]{2})$");
        if (matchResult.Success)
        {
            year = int.Parse(matchResult.Groups["year"].Value);

            if ((first_digit == "3") || (first_digit == "2"))
            {
                if (first_digit == "3") year += 2000;
                else if (first_digit == "2") year += 1900;

                //if (year > DateTime.Now.Year) year += 2000;
                //else if (year < 100) year += 1900;
                try
                {
                    foundDate = new DateTime(year, int.Parse(matchResult.Groups["month"].Value), int.Parse(matchResult.Groups["day"].Value));
                    //int dobyear = Convert.ToInt32(year1);// Convert.ToInt32(DateTime.Parse(dob1).Year);
                    int years = Convert.ToInt32(DateTime.Now.Year);
                    diff = (years - year);
                    string dateformate = year + "/" + month + "/" + date;
                    if (diff < 1)
                    {
                        cnt = 1;

                    }
                    else
                    {
                        if ((DateTime.Parse(dateformate).Month > DateTime.Now.Month) || (DateTime.Parse(dateformate).Month == DateTime.Now.Month && DateTime.Parse(dateformate).Day > DateTime.Now.Day))

                            diff = diff - 1;

                        returndob = year + "/" + month + "/" + date;

                    }
                }
                catch (Exception ex)
                {
                    cnt = 1;

                }
            }
            else
            {
                cnt = 1;

            }
        }
        else
        {
            cnt = 1;

        }
        string a = cnt + "~" + returndob + "~" + diff;
        return a;

    }


    public string DobFromCivil2(string civil_id)
    {
        int year;
        int cnt = 0;
        string returndob = null;

        //if input is arabic numberes.
        string enddate1 = toEnglishNumber(civil_id);

        string first_digit = enddate1.Substring(0, 1);
        string sub = enddate1.Substring(1, 6);
        string year1 = sub.Substring(0, 2);
        string month = sub.Substring(2, 2);
        string date = sub.Substring(4, 2);
        int diff = 0;
        string dob = date + "/" + month + "/" + year1;



        DateTime foundDate;
        Match matchResult = Regex.Match(dob,
            "^(?<day>[0-3]?[0-9])/(?<month>[0-3]?[0-9])/(?<year>(?:[0-9]{2})?[0-9]{2})$");
        if (matchResult.Success)
        {
            year = int.Parse(matchResult.Groups["year"].Value);

            if ((first_digit == "3") || (first_digit == "2"))
            {
                if (first_digit == "3") year += 2000;
                else if (first_digit == "2") year += 1900;

                //if (year > DateTime.Now.Year) year += 2000;
                //else if (year < 100) year += 1900;
                try
                {
                    foundDate = new DateTime(year, int.Parse(matchResult.Groups["month"].Value), int.Parse(matchResult.Groups["day"].Value));
                    //int dobyear = Convert.ToInt32(year1);// Convert.ToInt32(DateTime.Parse(dob1).Year);
                    int years = Convert.ToInt32(DateTime.Now.Year);
                    diff = (years - year);
                    string dateformate = year + "/" + month + "/" + date;
                    if (diff < 1)
                    {
                        cnt = 1;

                    }
                    else
                    {
                        if ((DateTime.Parse(dateformate).Month > DateTime.Now.Month) || (DateTime.Parse(dateformate).Month == DateTime.Now.Month && DateTime.Parse(dateformate).Day > DateTime.Now.Day))

                            diff = diff - 1;

                        returndob = year + "/" + month + "/" + date;

                    }
                }
                catch (Exception ex)
                {
                    cnt = 1;

                }
            }
            else
            {
                cnt = 1;

            }
        }
        else
        {
            cnt = 1;

        }
        string a = cnt + "~" + returndob + "~" + diff;
        return returndob;

    }

    

    public DataInsertReturn ExecuteNonQuery(string strSQL, string strConnectionStringKey)
    {

        SqlConnection conGlobal = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[strConnectionStringKey].ConnectionString);


        string[] a = new string[1];
        DataInsertReturn dtr = new DataInsertReturn();
        try
        {

            dtr.DataInsert = true;

            if (conGlobal.State == ConnectionState.Closed)
                conGlobal.Open();


            SqlCommand cmd = new SqlCommand(strSQL, conGlobal);
            cmd.ExecuteNonQuery();

            if (conGlobal.State == ConnectionState.Closed)
                conGlobal.Open();

            //string ssql;
            //ssql = "Insert Into dataexport (ExpSql,TableName,sta,Companyid)Values('" + Strings.Replace(strSQL, "'", "''") + "','" + as_TableName + "','I'," + li_comid + ")";
            //SqlCommand cmd1 = new SqlCommand(ssql, conGlobal);
            //cmd1.ExecuteNonQuery();


            return dtr;
        }
        catch (Exception ex)
        {
            // ExecuteNonQuery = ex.Message.Trim
            //if (conGlobal.State == ConnectionState.Closed)
            //    conGlobal.Open();
            //SqlCommand cmd1 = new SqlCommand("Insert Into ErrorLog (ErrorSql,ErrorDesc,ErrorDT,SendSta) Values('" + Replace(strSQL, "'", "''") + "','" + ex.Message.Trim + "','" + Strings.Format((DateTime)DateTime.Now, "yyyy-MM-dd HH:mm:ss") + "','N')", conGlobal);
            //cmd1.ExecuteNonQuery();
            dtr.DataInsert = false;
            dtr.ErrorMsg = ex.Message;
            conGlobal.Close();
            return dtr;
        }
        finally
        {
            if (conGlobal.State == ConnectionState.Open)
                conGlobal.Close();
        }
    }



    public DataTable msgResponse(string flag, string err, string errmsg, int li_id)
    {
        DataTable DtTb = new DataTable("Table");
        DataRow DtRow;
        DtTb.Columns.Add("Error");
        DtTb.Columns.Add("message");
        DtTb.Columns.Add("ids");
        DtRow = DtTb.NewRow();
        DtRow["Error"] = err;
        if (err == "False")
        {
            if (flag == "I")
                DtRow["message"] = "Record Added Sucessfully.";
            else if (flag == "U")
                DtRow["message"] = "Record Updated Sucessfully.";
            else if (flag == "D")
                DtRow["message"] = "Record Deleted.";
            DtRow["ids"] = li_id;
        }
        else
        {
            DtRow["message"] = errmsg;
            DtRow["ids"] = li_id;
        }

        DtTb.Rows.Add(DtRow);
        return DtTb;
    }

    //public String myConnectionStringMaleabna()
    //{
    //    return "Data Source=tcp:192.168.13.7,49480;Initial Catalog=MYA_Maleabna;User Id=Moya@kwtbU$er;Password=pRU=4EkWt-e3et;MultipleActiveResultSets=True;Pooling=false;Connection Timeout=120;Persist Security Info=False;";
    //}


    public DataSet GetDS(string strSQL, string strConnectionStringKey, string strTableName, bool blnIsSrno)
    {
        DataTable dt = new DataTable();
        //General gm = new General();


        SqlConnection conGlobal = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MalebnaDB"].ConnectionString);
        string[] a = new string[1];
        DataRow dr;
        DataTable dtDataTable;
        if (conGlobal.State == ConnectionState.Closed)
            conGlobal.Open();
        var SDA = new SqlDataAdapter(strSQL, conGlobal);
        DataSet DS = new DataSet();
        try
        {
            dtDataTable = new DataTable(strTableName);
            DataColumn dcolSrNo;
            if ((blnIsSrno == true))
            {
                dcolSrNo = new DataColumn("SlNo");
                dcolSrNo.AutoIncrement = true;
                dcolSrNo.AutoIncrementSeed = 1;
                dcolSrNo.AutoIncrementStep = 1;
                dtDataTable.Columns.Add(dcolSrNo);
            }
            DS.Tables.Add(dtDataTable);
            SDA.Fill(DS, strTableName);
            SDA.Dispose();
            return DS;
        }
        catch (Exception ex)
        {
            dt.Columns.Clear();
            dt.Columns.Add("Error");
            dr = dt.NewRow();
            dr["Error"] = ex.Message.Trim();
            dt.Rows.Add(dr);
            DS.Tables.Add(dt);
            conGlobal.Close();
            return DS;
        }
        finally
        {
            if (conGlobal.State == ConnectionState.Open)
                conGlobal.Close();
        }
    }


    public DataTable GetDt(string query)
    {
        DataTable dtDataTable = new DataTable();

        SqlConnection conGlobal = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MalebnaDB"].ConnectionString);


        string[] a = new string[1];
        DataRow dr;
       
        if (conGlobal.State == ConnectionState.Closed)
            conGlobal.Open();
        var SDA = new SqlDataAdapter(query, conGlobal);
        DataSet DS = new DataSet();
        try
        {
            SDA.Fill(dtDataTable);
            SDA.Dispose();

            return dtDataTable;
        }
        catch (Exception ex)
        {
            //dtDataTable.Columns.Clear();
            //dtDataTable.Columns.Add("Error");
            //dr = dtDataTable.NewRow();
            //dr["Error"] = ex.Message.Trim();
            //dtDataTable.Rows.Add(dr);
            //DS.Tables.Add(dtDataTable);
            //conGlobal.Close();

            return dtDataTable;
        }
        finally
        {
            if (conGlobal.State == ConnectionState.Open)
                conGlobal.Close();
        }
        
    }


    public DataSet GetDSY(string query)
    {
        DataSet ds = new DataSet();

        SqlConnection conGlobal = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MalebnaDB"].ConnectionString);


        string[] a = new string[1];
        DataRow dr;

        if (conGlobal.State == ConnectionState.Closed)
            conGlobal.Open();
        var SDA = new SqlDataAdapter(query, conGlobal);
        DataSet DS = new DataSet();
        try
        {
            SDA.Fill(ds);
            SDA.Dispose();

            return ds;
        }
        catch (Exception ex)
        {
            //dtDataTable.Columns.Clear();
            //dtDataTable.Columns.Add("Error");
            //dr = dtDataTable.NewRow();
            //dr["Error"] = ex.Message.Trim();
            //dtDataTable.Rows.Add(dr);
            //DS.Tables.Add(dtDataTable);
            //conGlobal.Close();

            return ds;
        }
        finally
        {
            if (conGlobal.State == ConnectionState.Open)
                conGlobal.Close();
        }

    }


    //public string EncryptDecrypt(string Password, string EncryptOrDecrypt)
    //{
    //    /// Encrypting Password As Ascii And
    //    ///         '''Decrypting Ascii as Password

    //    string TempPassword;
    //    string ReturnPassword;
    //    int Min;
    //    int sec;
    //    int TempSec;
    //    int RepSec;
    //    int SpaceSec;
    //    int I;
    //    int k;
    //    TempPassword = Password;
    //    ReturnPassword = "";
    //    RepSec = 255;
    //    if (EncryptOrDecrypt == "E")
    //    {
    //        var date = DateTime.Now;            

    //        Min = date.Minute;
    //        sec = date.Second;
    //        TempSec = Min + sec;
    //        Min = Min + 139;
    //        sec = sec + 128;
    //        ReturnPassword = (char)Min;
    //        ReturnPassword = ReturnPassword + Strings.Chr(sec);
    //        for (I = 1; I <= Strings.Len(Strings.Trim(Password)); I++)
    //            ReturnPassword = ReturnPassword + Strings.Chr(Strings.Asc(Strings.Mid(Password, I, 1)) + (TempSec + 12));
    //        k = 1;
    //        for (I = Strings.Len(Strings.Trim(ReturnPassword)) + 1; I <= 8; I++)
    //        {
    //            SpaceSec = RepSec - (TempSec % 10);
    //            RepSec = SpaceSec;
    //            if (k == 1)
    //            {
    //                ReturnPassword = ReturnPassword + Strings.Chr(255);
    //                k = 2;
    //            }
    //            else
    //                ReturnPassword = ReturnPassword + Strings.Chr(SpaceSec);
    //        }
    //    }
    //    else if (EncryptOrDecrypt == "D" & Password != "")
    //    {
    //        Min = Strings.Asc(Strings.Mid(Password, 1, 1));
    //        sec = Strings.Asc(Strings.Mid(Password, 2, 1));
    //        if ((Min >= 65 & Min <= 122) & (sec >= 65 & sec <= 122))
    //        {
    //            EncryptDecrypt = Strings.Trim(Password);
    //            return;
    //        }
    //        Min = Min - 139;
    //        sec = sec - 128;
    //        TempSec = Min + sec;
    //        for (I = 3; I <= Strings.Len(Strings.Trim(Password)); I++)
    //        {
    //            k = Strings.Asc(Strings.Mid(Password, I, 1)) - (TempSec + 12);
    //            if (k == 255 - (TempSec + 12))
    //                break;
    //            ReturnPassword = ReturnPassword + Strings.Chr(k);
    //        }
    //    }
    //    else if (EncryptOrDecrypt == "C" & Password != "")
    //    {
    //        Min = Strings.Asc(Strings.Mid(Password, 1, 1));
    //        sec = Strings.Asc(Strings.Mid(Password, 2, 1));
    //        if ((Min >= 65 & Min <= 122) & (sec >= 65 & sec <= 122))
    //        {
    //            EncryptDecrypt = Strings.Trim(Password);
    //            return;
    //        }
    //        Min = Min - 139;
    //        sec = sec - 128;
    //        TempSec = Min + sec;
    //        Min = Min + 139;
    //        sec = sec + 128;
    //        ReturnPassword = Strings.Chr(Min);
    //        ReturnPassword = ReturnPassword + Strings.Chr(sec);
    //        for (I = 1; I <= Strings.Len(Strings.Trim(Password)); I++)
    //            ReturnPassword = ReturnPassword + Strings.Chr(Strings.Asc(Strings.Mid(Password, I, 1)) + (TempSec + 12));
    //        k = 1;
    //        for (I = Strings.Len(Strings.Trim(ReturnPassword)) + 1; I <= 8; I++)
    //        {
    //            SpaceSec = RepSec - (TempSec % 10);
    //            RepSec = SpaceSec;
    //            if (k == 1)
    //            {
    //                ReturnPassword = ReturnPassword + Strings.Chr(255);
    //                k = 2;
    //            }
    //            else
    //                ReturnPassword = ReturnPassword + Strings.Chr(SpaceSec);
    //        }
    //    }
    //    EncryptDecrypt = ReturnPassword;
    //}

    public List<Dictionary<string, object>> GetJSon(DataTable dt)
    {
        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row;

        // Return JsonConvert.SerializeObject(dt).ToList
        // Return JSONString

        foreach (DataRow dr in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                if (col.DataType == typeof(DateTime))
                {
                    DateTime dtt = DateTime.Parse(dr[col].ToString());
                    row.Add(col.ColumnName, dtt.ToString("dd-MM-yyyy hh:mm:ss"));
                }
                else
                    row.Add(col.ColumnName, dr[col]);
            }
            rows.Add(row);
        }
        return rows;
    }


}


public struct DataInsertReturn
{
    public bool DataInsert;
    public string ErrorMsg;
    public int li_id;     
}

public struct fnReturnCivilId
{
    public bool ValidCivil;
    public string Dob;
    public int age;
}

