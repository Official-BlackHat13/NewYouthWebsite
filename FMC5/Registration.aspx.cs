using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FMC_Registration : System.Web.UI.Page
{
    General gm = new General();
    general_fn gfn = new general_fn();
    fn_General fn = new fn_General();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Session["page"] = "FMC_Info";
            //if (Session["userid"] != null)
            //{

            //    string id = userid();
                // Boolean val =  CheckApplied(id);

               // Boolean val = fn.CheckApplied(id, "tbl_FMC_Season3");
               // if (val)
                //{
                //    pnlForm.Visible = true;
                //    alert.Visible = false;
                //    Fileshow(id);
                //}
                //else
                //{

                //    Response.Redirect("UpdateRegistration.aspx", false);

                //}
            //}
            //else
            //    Response.Redirect("../user/login.aspx", false);
        }
    }
    public string userid()
    {
        general_fn gfn = new general_fn();
        string strUserid = Session["userid"].ToString();
        strUserid = gfn.SessionDecrypt(strUserid, SHA512.Create().ToString());
        strUserid = strUserid.Substring(strUserid.IndexOf("&") + 1);
        return strUserid;
    }


    protected void Fileshow(string id)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = gm.ConnectionString();
        con.Open();
        try
        {
            string UID = userid();
            string query = "ViewUserDetails";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            cmd.Parameters.AddWithValue("@id", SqlDbType.NVarChar).Value = UID;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                txtFname.Text = dt.Rows[0]["Name"].ToString();
                txtMname.Text = dt.Rows[0]["Mname"].ToString();
                txtThirdName.Text = dt.Rows[0]["TName"].ToString();
                txtsurname.Text = dt.Rows[0]["Lname"].ToString();
                txtCivil.Text = dt.Rows[0]["civil"].ToString();

                if (string.IsNullOrEmpty(txtFname.Text))
                    txtFname.Enabled = true;
                if (string.IsNullOrEmpty(txtMname.Text))
                    txtMname.Enabled = true;
                if (string.IsNullOrEmpty(txtThirdName.Text))
                    txtThirdName.Enabled = true;
                if (string.IsNullOrEmpty(txtsurname.Text))
                    txtsurname.Enabled = true;
                if (string.IsNullOrEmpty(txtCivil.Text))
                    txtCivil.Enabled = true;


                string dob = gfn.DobFromCivil(txtCivil.Text);
                // string dob = fn.DobFromCivil(txtCivil.Text);
                string[] Arrdob = dob.Split('~');
                txtAge.Text = Arrdob[2].ToString();

                int age = int.Parse(txtAge.Text);
                string gender = dt.Rows[0]["gender"].ToString();

                DivAge.Visible = false;
                Divgender.Visible = false;
                pnlForm.Visible = true;



            }


        }
        catch (Exception ex)
        {
            Response.Write(ex);
        }
        finally
        {
            con.Close();
        }
    }


    protected string FileSave(FileUpload fp, string str)
    {
        string result = string.Empty;

        if (fp.FileContent.Length > 0)
        {
            result = @"Files\" + txtCivil.Text + "-" + str + Path.GetExtension(fp.PostedFile.FileName.ToString());
            fp.PostedFile.SaveAs(Server.MapPath(result));
        }

        return result;
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //if (Session["userid"] != null)
        //{
            Page.Validate("submitionform");
            if (Page.IsValid)
            {

                lblerror.Text = "";
                string fpcivil = string.Empty;  //filecivil

                string fQualification = string.Empty;

                string fpacademy = string.Empty;  //FileAcademicCertificate

                string fpConcern = string.Empty;  //FileConcernCertificate

                string fphigher = string.Empty; //FileHigherEdu
                string fpgrad = string.Empty; //Filegraduation
                string fpCV = string.Empty; //FileCV

                string fpphoto = string.Empty; //Filephoto


               // if (filecivil.FileContent.Length > 0 && FileAcademicCertificate.FileContent.Length > 0 && FileConcernCertificate.FileContent.Length > 0 && Filephoto.FileContent.Length > 0)
                {
                    fpcivil = FileSave(filecivil, "CivilId");
                    fQualification = FileSave(fpQualification, "Qalification");
                    fpacademy = FileSave(FileAcademicCertificate, "Academy");
                    fpConcern = FileSave(FileConcernCertificate, "Concern");
                    fphigher = FileSave(FileHigherEdu, "HigherEducation");
                    //fpgrad = FileSave(Filegraduation, "Graduation");
                    fpCV = FileSave(FileCV, "CV");

                    fpphoto = FileSave(Filephoto, "Photo");



                    SqlConnection cnn = new SqlConnection();
                    cnn.ConnectionString = gm.ConnectionString();
                    cnn.Open();
                    string query = "SP_FMCSeason3Registration";
                    SqlCommand cmd = new SqlCommand(query, cnn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        cmd.Parameters.AddWithValue("@fname", SqlDbType.Int).Value = txtFname.Text.ToString();
                        cmd.Parameters.AddWithValue("@mname", SqlDbType.Int).Value = txtMname.Text.ToString();
                        cmd.Parameters.AddWithValue("@tname", SqlDbType.Int).Value = txtThirdName.Text.ToString();
                        cmd.Parameters.AddWithValue("@lname", SqlDbType.Int).Value = txtsurname.Text.ToString();
                        cmd.Parameters.AddWithValue("@uid", SqlDbType.NVarChar).Value = "";// userid();
                        cmd.Parameters.AddWithValue("@age", SqlDbType.Int).Value = txtAge.Text;
                        cmd.Parameters.AddWithValue("@average", SqlDbType.NVarChar).Value = txtaverage.Text;
                        cmd.Parameters.AddWithValue("@civil", SqlDbType.NVarChar).Value = txtCivil.Text.Trim();
                        cmd.Parameters.AddWithValue("@education", SqlDbType.NVarChar).Value = radioEdu.SelectedItem.Text;


                        cmd.Parameters.AddWithValue("@fpCivilID", SqlDbType.NVarChar).Value = fpcivil;
                        cmd.Parameters.AddWithValue("@fpQualification", SqlDbType.NVarChar).Value = fQualification;
                        cmd.Parameters.AddWithValue("@fpAcademy", SqlDbType.NVarChar).Value = fpacademy;
                        cmd.Parameters.AddWithValue("@fpHigherEducation", SqlDbType.NVarChar).Value = fphigher;
                        cmd.Parameters.AddWithValue("@fpConcern", SqlDbType.NVarChar).Value = fpConcern;
                        //cmd.Parameters.AddWithValue("@fpgraduation", SqlDbType.NVarChar).Value = fpgrad;
                        cmd.Parameters.AddWithValue("@fpCV", SqlDbType.NVarChar).Value = fpCV;
                        cmd.Parameters.AddWithValue("@fpphoto", SqlDbType.NVarChar).Value = fpphoto;
                        cmd.Parameters.AddWithValue("@graduationDate", SqlDbType.Date).Value = txtGraduationDate.Text;
                        cmd.Parameters.AddWithValue("@phone", SqlDbType.Date).Value = txtPhone.Text;
                        cmd.Parameters.Add("@result", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        string result = cmd.Parameters["@result"].Value.ToString();

                        if (!string.IsNullOrEmpty(result))
                        {
                            cnn.Close();
                            Session["FMCS3ID"] = result;
                            Response.Redirect("thankyou.aspx", false);
                        }


                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex);
                    }
                }
                //else
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('Please Attach all Necessary Files...');</script>", false);
                //}
            }
        //}
        //else
        //    Response.Redirect("../user/login.aspx", false);
    }

    bool IsDigitsOnly(string str)
    {
        foreach (char c in str)
        {
            if (c < '0' || c > '9')
                return false;
        }

        return true;
    }
    protected void txtCivil_TextChanged(object sender, EventArgs e)
    {

        int cnt = 0;
        lblCivil.Visible = false;
        string civil_id = Server.HtmlEncode(txtCivil.Text.Trim());

        bool num_result = IsDigitsOnly(civil_id);
        if ((num_result == true) && (civil_id.Length == 12))
        {

            string civil = civil_id;


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
                txtCivil.Text = civil;
                general_fn gfn = new general_fn();
                string dob = gfn.DobFromCivil(civil_id);
                string[] Arrdob = dob.Split('~');

                cnt = Convert.ToInt16(Arrdob[0]);


                if (cnt == 1)
                {
                    lblCivil.Visible = true;

                }
                else
                {
                    dob = Arrdob[1];
                    txtAge.Text = Arrdob[2];
                   // CheckAge(txtCivil.Text.Trim());
                }
            }
            else
            {
                txtCivil.Text = "";
                lblCivil.Visible = true;
                lblCivil.Text = "الرقم المدني غير صحيح";
            }
        }
        else
        {
            RegularExpressionValidator1.Validate();
        }
    }

    protected void CheckAge(string civil)
    {
        general_fn gn = new general_fn();
        int age = gn.DobFromCivilAge(civil);

        if (age > 18 && age < 35)
        {
            DivAge.Visible = false;            
            btnSubmit.Visible = true;

        }
        else
        {
            DivAge.Visible = true;
            btnSubmit.Visible = false;
        }
    }
   
}