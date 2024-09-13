using Microsoft.AspNet.FriendlyUrls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PageTypeIdentification : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            IList<string> segments = Request.GetFriendlyUrlSegments();
            if (segments.Count > 0)
            {
                long ID;
                long.TryParse(segments[0], out ID);
                // Lbl_TypeIdentification.Text = "Le type Identification est : " + segments[0];
                LoadData(ID);
            }
        }
    }

    private void LoadData(long Id)
    {
        List<TypeIdentification> types = TypeIdentification.LoadTypeIdentification();
            
          TypeIdentification item = (from i in types
                                      where i.Id == Id
                                       select i
                                      ).FirstOrDefault();
        if (item != null )
        {
            Txt_LibelleType.Text = item.Name;
        }
        
    }
}