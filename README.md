本项目安装使用需要vs2019 preveiew最新版及最新版net core 3.0 sdk


常用方法：

截取字符串：  StringExtensions文件中SubString方法
截取清空Html字符串：CutString方法
提取摘要方法：GetContentSummary()
获取全拼：WordsHelper.GetPinYin("")
获取简拼：WordsHelper.GetFirstPinYin("")
获取拼音首字母：WordsHelper.GetFirstPinYin(“”).Substring(0, 1)

生成0到9随机数：Randoms.RndNum(10)
生成时间随机文件名：Randoms.MakeFileRndName()

将1,2,3转为List<int>的方法：Ding.Helpers.Convert.ToList<int>(“”);
将List<T>转为string的方法：ListExtensions 中JoinT<T> 或者 Ding.Core中的StringHelp中的Join<T>
将List<T>转为string且带引号和逗号的方法：List<T>.JoinT<string>("'", ",");

判断字符串是否为空：UserName.IsNullOrEmpty()
转为GuId：Id.ToGuid()
转换对象：MapTo<T>()   MapToList<T>()   ToEntity()    ToDto()

Json转字符串： .ToJson()

转为bool, .ToBoolean()

判断字符串是否在字符串中：ArrayExtensions.IsInArray

验证码：
           services.AddCaptchaService(o => {
                o.SecretKey = SiteSetting.Current.CaptchaSecretKey;
            });
            services.AddTransient<VerificationCode>();

转为安全string: SafeString()
转为安全Object:SafeValue()

SqlQuery获取映射字段的方法  
.Select<T>(true)     
.Select<T>(t => t.GzryGzkh, "yhgh")  
.Select<T>(t => new Dictionary<object, string> { { t.Id, "wyhmxid" }, { t.WyhlbmxYhxm, "yhxm" } })
.Select<T>(t => new object[] { t.CdMc, t.CdPx }, true)

SqlQuery设置Join的方法
.LeftJoin<AuthPermissions>("sp").On<SysMenu, AuthPermissions>(x => x.Id, x => x.MenuId, Operator.Equal)

SqlQuery设置WhereIf方法
.WhereIf<CmsArticle>(x => x.ColumnId == parm.id, parm.id != 0)
.WhereIf<CmsArticle>(x => x.Title.Contains(parm.key) || x.Tag.Contains(parm.key), !parm.key.IsNullOrEmpty())
.WhereIf<CmsArticle>(x => x.Audit, true, parm.audit == 0)

获取文件扩展名：FileHelper.GetFileExtension("文件名")
上传文件路径（根据文件类型分配路径）：FileUtil.AssigendPath
如果文件夹不存在，则创建文件夹：DirectoryUtil.CreateIfNotExists("文件夹")
下载远程文件：FileHelper.DownLoadFileFromUrl(远程URL，物理路径)
判断文件或者文件夹是否存在: FileSystemObject.IsExist

获取枚举字段的注释：EnumHelper.GetDescription
获取枚举字段的所有字段注释： EnumHelper.GetDescriptions

获取针对wwwroot的物理路径：FileHelper.WebMapPath
获取针对根目录的物理路径：FileHelper.MapPath

返回相差的秒数：DateTimeUtil.StrDateDiffSeconds
返回相差的分钟：DateTimeUtil.StrDateDiffMinutes
返回相差的小时：DateTimeUtil.StrDateDiffHours

从指定字节数组创建图片： ImageUtil.FromBytes(byte[])
获取图片扩展名: ImageUtil.GetImageExtension(Image)

数据库备份：DbBackup.BackupDb(物理路径)

文件压缩："被压缩文件物理路径".AsFile().Compress(“压缩文件物理路径”);  //压缩文件
文件删除：FileHelper.DeleteFiles(物理路径, false);
文件夹删除：FileHelper.DeleteFiles(物理路径, true);

获取文件夹所有文件，返回为List<路径>:FileUtil.GetAllFiles(物理路径)
获取文件夹所有文件，返回为List<文件对象实体>:FileSystemObject.GetDirectoryAllInfos(物理路径, FsoMethod.File);

Vs Code 打开新的窗口："workbench.editor.enablePreview": false,

时间戳： DateTimeUtil.PHP_Time()
时间戳转普通时间：DateTimeUtil.PHPTOCTime(long)

获取当前站点Url: Web.GetSiteUrl()  返回：http(s)://www.baidu.com

获取Body内容：Web.Body和Web.GetBodyAsync

获取访问的上一页：Web.RefererUrl