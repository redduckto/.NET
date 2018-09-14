using System;

public partial class Controls_Banner : System.Web.UI.UserControl
{
    /* Banner'a attribute eklendi. Eğer bir değer atanırsa o döndürülecek.
     * Değer atanmamışsa default olarak "http://bilmuh.ege.edu.tr" döndürülecek.
     */
    public string NavigateUrl
    {
        get
        {
            object _navigateUrl = ViewState["NavigateUrl"];
            if (_navigateUrl != null)
            {
                return (string)_navigateUrl;
            }
            else
            {
                return "http://bilmuh.ege.edu.tr"; // Return a default value
            }
        }
        set
        {
            ViewState["NavigateUrl"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}