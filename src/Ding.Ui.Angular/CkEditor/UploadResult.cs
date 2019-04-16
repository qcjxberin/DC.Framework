using Microsoft.AspNetCore.Mvc;

namespace Ding.Ui.CkEditor {
    /// <summary>
    /// CkEdtitor上传结果
    /// </summary>
    public class UploadResult : ContentResult {
        /// <summary>
        /// 初始化CkEdtitor上传结果
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="message">消息</param>
        public UploadResult( string path, string message ) {
            var num = Ding.Helpers.Web.HttpContext.Request.Query["CKEditorFuncNum"].SafeString();
            Content = $"<script type='text/javascript'>window.parent.CKEDITOR.tools.callFunction({num}, '{path}', '{message}');</script>";
            ContentType = "text/html; charset=utf-8";
        }
    }
}
