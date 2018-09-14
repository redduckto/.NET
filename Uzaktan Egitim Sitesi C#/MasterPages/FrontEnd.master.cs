using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPages_FrontEnd : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            string selectedTheme = Page.Theme;
            HttpCookie preferredTheme = Request.Cookies.Get("AlgoAkademiTheme");
            if(preferredTheme != null)
            {
                selectedTheme = preferredTheme.Value;
            }
            if(!string.IsNullOrEmpty(selectedTheme) && ThemeList.Items.FindByValue(selectedTheme) != null)
            {
                ThemeList.Items.FindByValue(selectedTheme).Selected = true;
            }
        }
    }

    protected void ThemeList_SelectedIndexChanged(object sender, EventArgs e)
    {
        HttpCookie preferredTheme = new HttpCookie("AlgoAkademiTheme");
        // Cookie, 3 ay sonra kendi kendine silinecek.
        preferredTheme.Expires = DateTime.Now.AddMonths(3);
        preferredTheme.Value = ThemeList.SelectedValue;
        Response.Cookies.Add(preferredTheme);
        // Bulunulan sayfaya yeniden yönlendiriliyor. (Refresh yani)
        Response.Redirect(Request.Url.ToString());
    }
}
