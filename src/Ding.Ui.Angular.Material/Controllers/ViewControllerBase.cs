﻿using Microsoft.AspNetCore.Mvc;
using Ding.Webs.Filters;

namespace Ding.Ui.Controllers {
    /// <summary>
    /// 视图控制器
    /// </summary>
    [Html(Template = "Typings/app/{area}/{controller}/html/{controller}-{action}.component.html" )]
    public class ViewControllerBase : Controller {
    }
}
