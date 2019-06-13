﻿#if __WIN__

namespace Ding.Tools.Mvc.Mime
{
    /// <summary>
    /// 默认MIME映射器，可以根据文件扩展名获取标准内容类型。
    /// </summary>
    public static class ContentType
    {
        /// <summary>
        /// 默认Mime  - 如果没有找到任何其他映射则作为默认的Mime-Type
        /// </summary>
        public const string DefaultMime = "application/octet-stream";
        public const string Abs = "audio/x-mpeg";
        public const string Ai = "application/postscript";
        public const string Aif = "audio/x-aiff";
        public const string Aifc = "audio/x-aiff";
        public const string Aiff = "audio/x-aiff";
        public const string Aim = "application/x-aim";
        public const string Art = "image/x-jg";
        public const string Asf = "video/x-ms-asf";
        public const string Asx = "video/x-ms-asf";
        public const string Au = "audio/basic";
        public const string Avi = "video/x-msvideo";
        public const string Avx = "video/x-rad-screenplay";
        public const string Bcpio = "application/x-bcpio";
        public const string Bin = "application/octet-stream";
        public const string Bmp = "image/bmp";
        public const string Body = "text/html";
        public const string Cdf = "application/x-cdf";
        public const string Cer = "application/x-x509-ca-cert";
        public const string Class = "application/java";
        public const string Cpio = "application/x-cpio";
        public const string Csh = "application/x-csh";
        public const string Css = "text/css";
        public const string Dib = "image/bmp";
        public const string Doc = "application/msword";
        public const string Dtd = "application/xml-dtd";
        public const string Dv = "video/x-dv";
        public const string Dvi = "application/x-dvi";
        public const string Eps = "application/postscript";
        public const string Etx = "text/x-setext";
        public const string Exe = "application/octet-stream";
        public const string FormData = "multipart/form-data";
        public const string FormUrlencoded = "application/x-www-form-urlencoded";
        public const string Gif = "image/gif";
        public const string Gtar = "application/x-gtar";
        public const string Gz = "application/x-gzip";
        public const string Ogv = "video/ogg";
        public const string Oga = "audio/ogg";
        public const string Ogg = "audio/ogg";
        public const string Hdf = "application/x-hdf";
        public const string Htc = "text/x-component";
        public const string Htm = "text/html";
        public const string Html = "text/html";
        public const string Hqx = "application/mac-binhex40";
        public const string Ief = "image/ief";
        public const string Jad = "text/vnd.sun.j2me.app-descriptor";
        public const string Jar = "application/java-archive";
        public const string Java = "text/plain";
        public const string Jnlp = "application/x-java-jnlp-file";
        public const string Jpe = "image/jpeg";
        public const string Jpeg = "image/jpeg";
        public const string Jpg = "image/jpeg";
        public const string Js = "text/javascript";
        public const string Jsf = "text/plain";
        public const string Jspf = "text/plain";
        public const string Kar = "audio/x-midi";
        public const string Latex = "application/x-latex";
        public const string M3u = "audio/x-mpegurl";
        public const string Mac = "image/x-macpaint";
        public const string Man = "application/x-troff-man";
        public const string Mathml = "application/mathml+xml";
        public const string Me = "application/x-troff-me";
        public const string Mid = "audio/x-midi";
        public const string Midi = "audio/x-midi";
        public const string Mif = "application/x-mif";
        public const string Mov = "video/quicktime";
        public const string Movie = "video/x-sgi-movie";
        public const string Mp1 = "audio/x-mpeg";
        public const string Mp2 = "audio/x-mpeg";
        public const string Mp3 = "audio/x-mpeg";
        public const string Mp4 = "video/mp4";
        public const string Mpa = "audio/x-mpeg";
        public const string Mpe = "video/mpeg";
        public const string Mpeg = "video/mpeg";
        public const string Mpega = "audio/x-mpeg";
        public const string Mpg = "video/mpeg";
        public const string Mpv2 = "video/mpeg2";
        public const string Ms = "application/x-wais-source";
        public const string Nc = "application/x-netcdf";
        public const string Oda = "application/oda";
        public const string Odb = "application/vnd.oasis.opendocument.database";
        public const string Odc = "application/vnd.oasis.opendocument.chart";
        public const string Odf = "application/vnd.oasis.opendocument.formula";
        public const string Odg = "application/vnd.oasis.opendocument.graphics";
        public const string Odi = "application/vnd.oasis.opendocument.image";
        public const string Odm = "application/vnd.oasis.opendocument.text-master";
        public const string Odp = "application/vnd.oasis.opendocument.presentation";
        public const string Ods = "application/vnd.oasis.opendocument.spreadsheet";
        public const string Odt = "application/vnd.oasis.opendocument.text";
        public const string Otg = "application/vnd.oasis.opendocument.graphics-template";
        public const string Oth = "application/vnd.oasis.opendocument.text-web";
        public const string Otp = "application/vnd.oasis.opendocument.presentation-template";
        public const string Ots = "application/vnd.oasis.opendocument.spreadsheet-template ";
        public const string Ott = "application/vnd.oasis.opendocument.text-template";
        public const string Pbm = "image/x-portable-bitmap";
        public const string Pct = "image/pict";
        public const string Pdf = "application/pdf";
        public const string Pgm = "image/x-portable-graymap";
        public const string Pic = "image/pict";
        public const string Pict = "image/pict";
        public const string Pls = "audio/x-scpls";
        public const string Png = "image/png";
        public const string Pnm = "image/x-portable-anymap";
        public const string Pnt = "image/x-macpaint";
        public const string Ppm = "image/x-portable-pixmap";
        public const string Ppt = "application/vnd.ms-powerpoint";
        public const string Pps = "application/vnd.ms-powerpoint";
        public const string Ps = "application/postscript";
        public const string Psd = "image/x-photoshop";
        public const string Qt = "video/quicktime";
        public const string Qti = "image/x-quicktime";
        public const string Qtif = "image/x-quicktime";
        public const string Ras = "image/x-cmu-raster";
        public const string Rdf = "application/rdf+xml";
        public const string Rgb = "image/x-rgb";
        public const string Rm = "application/vnd.rn-realmedia";
        public const string Roff = "application/x-troff";
        public const string Rtf = "application/rtf";
        public const string Rtx = "text/richtext";
        public const string Sh = "application/x-sh";
        public const string Shar = "application/x-shar";
        public const string Smf = "audio/x-midi";
        public const string Sit = "application/x-stuffit";
        public const string Snd = "audio/basic";
        public const string Src = "application/x-wais-source";
        public const string Sv4cpio = "application/x-sv4cpio";
        public const string Sv4crc = "application/x-sv4crc";
        public const string Svg = "image/svg+xml";
        public const string Svgz = "image/svg+xml";
        public const string Swf = "application/x-shockwave-flash";
        public const string T = "application/x-troff";
        public const string Tar = "application/x-tar";
        public const string Tcl = "application/x-tcl";
        public const string Tex = "application/x-tex";
        public const string Texi = "application/x-texinfo";
        public const string Texinfo = "application/x-texinfo";
        public const string Tif = "image/tiff";
        public const string Tiff = "image/tiff";
        public const string Tr = "application/x-troff";
        public const string Tsv = "text/tab-separated-values";
        public const string Txt = "text/plain";
        public const string Ulw = "audio/basic";
        public const string Ustar = "application/x-ustar";
        public const string Vxml = "application/voicexml+xml";
        public const string Xbm = "image/x-xbitmap";
        public const string Xht = "application/xhtml+xml";
        public const string Xhtml = "application/xhtml+xml";
        public const string Xls = "application/vnd.ms-excel";
        public const string Xml = "application/xml";
        public const string Xpm = "image/x-xpixmap";
        public const string Xsl = "application/xml";
        public const string Xslt = "application/xslt+xml";
        public const string Xul = "application/vnd.mozilla.xul+xml";
        public const string Xwd = "image/x-xwindowdump";
        public const string Vsd = "application/x-visio";
        public const string Wav = "audio/x-wav";
        public const string Wbmp = "image/vnd.wap.wbmp";
        public const string Wml = "text/vnd.wap.wml";
        public const string Wmlc = "application/vnd.wap.wmlc";
        public const string Wmls = "text/vnd.wap.wmlscript";
        public const string Wmlscriptc = "application/vnd.wap.wmlscriptc";
        public const string Wmv = "video/x-ms-wmv";
        public const string Wrl = "x-world/x-vrml";
        public const string Wspolicy = "application/wspolicy+xml";
        public const string Z = "application/x-compress";
        public const string z = "application/x-compress";
        public const string Zip = "application/zip";
    }
}
#endif