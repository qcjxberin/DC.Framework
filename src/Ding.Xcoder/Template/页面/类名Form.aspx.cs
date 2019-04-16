using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ding.Log;
using Ding.Web;
using <#=Config.NameSpace#>;

public partial class <#=Config.EntityConnName+"_"+Table.Name#>Form : MyEntityForm<<#=Table.Name#>>
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
}