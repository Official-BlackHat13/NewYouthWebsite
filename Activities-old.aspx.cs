using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Activities : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillNews();
        }

        FillPager();
    }

    private void FillNews()
    {
        try
        {
            DateTime date = DateTime.Now.Date;
            DataTable dt = GetDataTable("exec Sp_GetActivities");

            if (dt.Rows.Count > 0)
            {
                lstNews.DataSource = dt;
                lstNews.DataBind();

                if (Page.IsPostBack)
                    FillPager();
                int i = newsPager.PageSize;
                if (dt.Rows.Count <= newsPager.PageSize)
                    newsPager.Visible = false;
            }


        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    protected void lstNews_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
    {
        newsPager.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);

        //rebind List View
        FillNews();
    }

    protected void pager_OnPagerCommand(object sender, DataPagerCommandEventArgs e)
    {
        e.NewMaximumRows = e.Item.Pager.MaximumRows;
        int pageIndex;
        bool isNumber = int.TryParse(e.CommandName, out pageIndex);

        if (!isNumber)
        {

            switch (e.CommandName)
            {
                case "First":
                    e.NewStartRowIndex = 0;
                    break;
                case "Previous":
                    if (e.Item.Pager.StartRowIndex > 0)
                        e.NewStartRowIndex = e.Item.Pager.StartRowIndex - e.NewMaximumRows;
                    break;

                case "Next":
                    if (e.Item.Pager.StartRowIndex + e.NewMaximumRows < e.Item.Pager.TotalRowCount)
                        e.NewStartRowIndex = e.Item.Pager.StartRowIndex + e.NewMaximumRows;
                    break;
                case "Last":
                    int rowIndex = (e.Item.Pager.TotalRowCount / e.Item.Pager.PageSize) * e.Item.Pager.PageSize;
                    e.NewStartRowIndex = rowIndex;
                    break;
            }

        }
        else
        {
            pageIndex -= 1;
            e.NewStartRowIndex = pageIndex * e.Item.Pager.PageSize;
        }
    }

    private void FillPager()
    {
        //
        var item = newsPager.Controls[0].FindControl("pagerItems") as HtmlGenericControl;
        if (item != null)
        {
            HtmlGenericControl li = new HtmlGenericControl();
            li.TagName = "li";
            LinkButton a = new LinkButton();
            a.ID = "lnkPrevious";
            a.CommandName = "Previous";
            a.Text = "«";

            li.Controls.Add(a);
            item.Controls.Add(li);
            int CurrentPage = ((newsPager.StartRowIndex) / newsPager.MaximumRows) + 1;
            int numberOfPages = Convert.ToInt32(Math.Ceiling(((decimal)newsPager.TotalRowCount / (decimal)newsPager.PageSize)));
            for (int i = 1; i <= numberOfPages; i++)
            {
                li = new HtmlGenericControl();
                li.TagName = "li";
                if (CurrentPage == i)
                    li.Attributes.Add("class", "active");
                a = new LinkButton();
                a.ID = "lnk" + i.ToString();
                a.CommandName = i.ToString();
                a.Text = i.ToString();

                li.Controls.Add(a);
                item.Controls.Add(li);
            }
            li = new HtmlGenericControl();
            li.TagName = "li";
            a = new LinkButton();
            a.ID = "lnkNext";
            a.CommandName = "Next";
            a.Text = "»";

            li.Controls.Add(a);
            item.Controls.Add(li);

        }
    }

    public DataTable GetDataTable(string SQLstring)
    {

        General gm = new General();


        using (SqlConnection cnn = new SqlConnection())
        {
            cnn.ConnectionString = gm.YPA();
            cnn.Open();

            // SqlCommand cmd = new SqlCommand(SQLstring, cnn);
            var SDA = new SqlDataAdapter(SQLstring, cnn);
            DataTable DS = new DataTable();

            SDA.Fill(DS);
            SDA.Dispose();
            return DS;

        }
    }

    public DataSet GetDataDS(string SQLstring)
    {

        General gm = new General();


        using (SqlConnection cnn = new SqlConnection())
        {
            cnn.ConnectionString = gm.YPA();
            cnn.Open();

            // SqlCommand cmd = new SqlCommand(SQLstring, cnn);
            var SDA = new SqlDataAdapter(SQLstring, cnn);
            DataSet DS = new DataSet();

            SDA.Fill(DS);
            SDA.Dispose();
            return DS;

        }
    }
    protected void lstNews_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
           // string img = DataBinder.Eval(e.Item.DataItem, "ActivityImage").ToString();
            //newsImage.Src = imageUrl;
            string imageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])DataBinder.Eval(e.Item.DataItem, "ActivityImage"));
            HtmlImage img = e.Item.FindControl("Activityimg") as HtmlImage;
            img.Src = imageUrl;
            
        }
    }
}