using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Demo : System.Web.UI.Page
{
    public string Databindind = "Databind Test";
    protected void Page_Init(object sender, EventArgs e)
    {

    }

    public string databinddemo()
    {
        return Databindind;
    }
    protected void Page_Load(object sender, EventArgs e)
    {


        //Txt_Text.EnableViewState = false;
        if (!this.IsPostBack)
        {
            lbl_Text.Text = "Premier Acces";
            FillDropdownType();
            FillGridView();
        }
        else
        {
            //ddl_DemoType.EnableViewState = false;
            lbl_Text.Text = "Post back";
        }

    }

    protected void btn_Compteur_Click(object sender, EventArgs e)
    {
        long compteur;
        long.TryParse(Txt_Text.Text, out compteur);
        compteur += 1;

        Txt_Text.Text = compteur.ToString();

        

    }


    private void FillDropdownType()
    {
        ddl_DemoType.Items.Clear();
        ddl_DemoType.DataTextField = "Name";
        ddl_DemoType.DataValueField = "Id";
        ddl_DemoType.DataSource = TypeIdentification.LoadTypeIdentification();
        ddl_DemoType.DataBind();
    }
    private void FillGridView()
    {
        GridViewDemo.DataSource = TypeIdentification.LoadTypeIdentification();
        GridViewDemo.DataBind();
    }
   
    protected void Page_UnLoad(object sender, EventArgs e)
    {

    }

    //public void GridDemoDatabound(Object sender, DataGridItemEventArgs e)
    //{
    //    DropDownList uidd =(DropDownList) e.Item.FindControl("DemoGridItem");

    //    uidd.Items.Clear();
    //    uidd.DataTextField = "Name";
    //    uidd.DataValueField = "Id";
    //    uidd.DataSource = TypeIdentification.LoadTypeIdentification();
    //    uidd.DataBind();
    //}

   

    protected void DemoRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList uidd = (DropDownList)e.Row.FindControl("DemoGridItem");
            uidd.Items.Clear();
            uidd.DataTextField = "Name";
            uidd.DataValueField = "Id";
            uidd.DataSource = TypeIdentification.LoadTypeIdentification();
            uidd.DataBind();
        }
       
    }
}