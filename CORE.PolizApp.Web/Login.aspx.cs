using System.Web.UI;
using DevExpress.ExpressApp.Web.Templates;

public partial class LoginPage : BaseXafPage
{
    public override Control InnerContentPlaceHolder
    {
        get { return Content; }
    }
}