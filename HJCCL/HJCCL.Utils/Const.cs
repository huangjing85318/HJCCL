﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HJCCL.Utils
{
    /// <summary>
    /// 常量
    /// </summary>
    public static class Const
    {
        #region FileExtensionDict(文件扩展类型字典)
        /// <summary>
        /// 文件扩展类型字典
        /// </summary>
        public static Dictionary<string, string> FileExtensionDict
        {
            get
            {
                return new Dictionary<string, string>()
                {
                    {".*", "application/octet-stream"},
                    {".tif", "image/tiff"},
                    {".001", "application/x-001"},
                    {".301", "application/x-301"},
                    {".323", "text/h323"},
                    {".906", "application/x-906"},
                    {".907", "drawing/907"},
                    {".a11", "application/x-a11"},
                    {".acp", "audio/x-mei-aac"},
                    {".ai", "application/postscript"},
                    {".aif", "audio/aiff"},
                    {".aifc", "audio/aiff"},
                    {".aiff", "audio/aiff"},
                    {".anv", "application/x-anv"},
                    {".asa", "text/asa"},
                    {".asf", "video/x-ms-asf"},
                    {".asp", "text/asp"},
                    {".asx", "video/x-ms-asf"},
                    {".au", "audio/basic"},
                    {".avi", "video/avi"},
                    {".awf", "application/vnd.adobe.workflow"},
                    {".biz", "text/xml"},
                    {".bmp", "application/x-bmp"},
                    {".bot", "application/x-bot"},
                    {".c4t", "application/x-c4t"},
                    {".c90", "application/x-c90"},
                    {".cal", "application/x-cals"},
                    {".cat", "application/vnd.ms-pki.seccat"},
                    {".cdf", "application/x-netcdf"},
                    {".cdr", "application/x-cdr"},
                    {".cel", "application/x-cel"},
                    {".cer", "application/x-x509-ca-cert"},
                    {".cg4", "application/x-g4"},
                    {".cgm", "application/x-cgm"},
                    {".cit", "application/x-cit"},
                    {".class", "java/*"},
                    {".cml", "text/xml"},
                    {".cmp", "application/x-cmp"},
                    {".cmx", "application/x-cmx"},
                    {".cot", "application/x-cot"},
                    {".crl", "application/pkix-crl"},
                    {".crt", "application/x-x509-ca-cert"},
                    {".csi", "application/x-csi"},
                    {".css", "text/css"},
                    {".cut", "application/x-cut"},
                    {".dbf", "application/x-dbf"},
                    {".dbm", "application/x-dbm"},
                    {".dbx", "application/x-dbx"},
                    {".dcd", "text/xml"},
                    {".dcx", "application/x-dcx"},
                    {".der", "application/x-x509-ca-cert"},
                    {".dgn", "application/x-dgn"},
                    {".dib", "application/x-dib"},
                    {".dll", "application/x-msdownload"},
                    {".doc", "application/msword"},
                    {".dot", "application/msword"},
                    {".drw", "application/x-drw"},
                    {".dtd", "text/xml"},
                    {".dwf", "Model/vnd.dwf"},
                    {".dwg", "application/x-dwg"},
                    {".dxb", "application/x-dxb"},
                    {".dxf", "application/x-dxf"},
                    {".edn", "application/vnd.adobe.edn"},
                    {".emf", "application/x-emf"},
                    {".eml", "message/rfc822"},
                    {".ent", "text/xml"},
                    {".epi", "application/x-epi"},
                    {".eps", "application/x-ps"},
                    {".etd", "application/x-ebx"},
                    {".exe", "application/x-msdownload"},
                    {".fax", "image/fax"},
                    {".fdf", "application/vnd.fdf"},
                    {".fif", "application/fractals"},
                    {".fo", "text/xml"},
                    {".frm", "application/x-frm"},
                    {".g4", "application/x-g4"},
                    {".gbr", "application/x-gbr"},
                    {".", "application/x-"},
                    {".gif", "image/gif"},
                    {".gl2", "application/x-gl2"},
                    {".gp4", "application/x-gp4"},
                    {".hgl", "application/x-hgl"},
                    {".hmr", "application/x-hmr"},
                    {".hpg", "application/x-hpgl"},
                    {".hpl", "application/x-hpl"},
                    {".hqx", "application/mac-binhex40"},
                    {".hrf", "application/x-hrf"},
                    {".hta", "application/hta"},
                    {".htc", "text/x-component"},
                    {".htm", "text/html"},
                    {".html", "text/html"},
                    {".htt", "text/webviewhtml"},
                    {".htx", "text/html"},
                    {".icb", "application/x-icb"},
                    {".ico", "image/x-icon"},
                    {".iff", "application/x-iff"},
                    {".ig4", "application/x-g4"},
                    {".igs", "application/x-igs"},
                    {".iii", "application/x-iphone"},
                    {".img", "application/x-img"},
                    {".ins", "application/x-internet-signup"},
                    {".isp", "application/x-internet-signup"},
                    {".IVF", "video/x-ivf"},
                    {".java", "java/*"},
                    {".jfif", "image/jpeg"},
                    {".jpe", "application/x-jpe"},
                    {".jpeg", "image/jpeg"},
                    {".jpg", "image/jpeg"},
                    {".js", "application/x-javascript"},
                    {".jsp", "text/html"},
                    {".la1", "audio/x-liquid-file"},
                    {".lar", "application/x-laplayer-reg"},
                    {".latex", "application/x-latex"},
                    {".lavs", "audio/x-liquid-secure"},
                    {".lbm", "application/x-lbm"},
                    {".lmsff", "audio/x-la-lms"},
                    {".ls", "application/x-javascript"},
                    {".ltr", "application/x-ltr"},
                    {".m1v", "video/x-mpeg"},
                    {".m2v", "video/x-mpeg"},
                    {".m3u", "audio/mpegurl"},
                    {".m4e", "video/mpeg4"},
                    {".mac", "application/x-mac"},
                    {".man", "application/x-troff-man"},
                    {".math", "text/xml"},
                    {".mdb", "application/msaccess"},
                    {".mfp", "application/x-shockwave-flash"},
                    {".mht", "message/rfc822"},
                    {".mhtml", "message/rfc822"},
                    {".mi", "application/x-mi"},
                    {".mid", "audio/mid"},
                    {".midi", "audio/mid"},
                    {".mil", "application/x-mil"},
                    {".mml", "text/xml"},
                    {".mnd", "audio/x-musicnet-download"},
                    {".mns", "audio/x-musicnet-stream"},
                    {".mocha", "application/x-javascript"},
                    {".movie", "video/x-sgi-movie"},
                    {".mp1", "audio/mp1"},
                    {".mp2", "audio/mp2"},
                    {".mp2v", "video/mpeg"},
                    {".mp3", "audio/mp3"},
                    {".mp4", "video/mpeg4"},
                    {".mpa", "video/x-mpg"},
                    {".mpd", "application/vnd.ms-project"},
                    {".mpe", "video/x-mpeg"},
                    {".mpeg", "video/mpg"},
                    {".mpg", "video/mpg"},
                    {".mpga", "audio/rn-mpeg"},
                    {".mpp", "application/vnd.ms-project"},
                    {".mps", "video/x-mpeg"},
                    {".mpt", "application/vnd.ms-project"},
                    {".mpv", "video/mpg"},
                    {".mpv2", "video/mpeg"},
                    {".mpw", "application/vnd.ms-project"},
                    {".mpx", "application/vnd.ms-project"},
                    {".mtx", "text/xml"},
                    {".mxp", "application/x-mmxp"},
                    {".net", "image/pnetvue"},
                    {".nrf", "application/x-nrf"},
                    {".nws", "message/rfc822"},
                    {".odc", "text/x-ms-odc"},
                    {".out", "application/x-out"},
                    {".p10", "application/pkcs10"},
                    {".p12", "application/x-pkcs12"},
                    {".p7b", "application/x-pkcs7-certificates"},
                    {".p7c", "application/pkcs7-mime"},
                    {".p7m", "application/pkcs7-mime"},
                    {".p7r", "application/x-pkcs7-certreqresp"},
                    {".p7s", "application/pkcs7-signature"},
                    {".pc5", "application/x-pc5"},
                    {".pci", "application/x-pci"},
                    {".pcl", "application/x-pcl"},
                    {".pcx", "application/x-pcx"},
                    {".pdf", "application/pdf"},
                    {".pdx", "application/vnd.adobe.pdx"},
                    {".pfx", "application/x-pkcs12"},
                    {".pgl", "application/x-pgl"},
                    {".pic", "application/x-pic"},
                    {".pko", "application/vnd.ms-pki.pko"},
                    {".pl", "application/x-perl"},
                    {".plg", "text/html"},
                    {".pls", "audio/scpls"},
                    {".plt", "application/x-plt"},
                    {".png", "image/png"},
                    {".pot", "application/vnd.ms-powerpoint"},
                    {".ppa", "application/vnd.ms-powerpoint"},
                    {".ppm", "application/x-ppm"},
                    {".pps", "application/vnd.ms-powerpoint"},
                    {".ppt", "application/vnd.ms-powerpoint"},
                    {".pr", "application/x-pr"},
                    {".prf", "application/pics-rules"},
                    {".prn", "application/x-prn"},
                    {".prt", "application/x-prt"},
                    {".ps", "application/x-ps"},
                    {".ptn", "application/x-ptn"},
                    {".pwz", "application/vnd.ms-powerpoint"},
                    {".r3t", "text/vnd.rn-realtext3d"},
                    {".ra", "audio/vnd.rn-realaudio"},
                    {".ram", "audio/x-pn-realaudio"},
                    {".ras", "application/x-ras"},
                    {".rat", "application/rat-file"},
                    {".rdf", "text/xml"},
                    {".rec", "application/vnd.rn-recording"},
                    {".red", "application/x-red"},
                    {".rgb", "application/x-rgb"},
                    {".rjs", "application/vnd.rn-realsystem-rjs"},
                    {".rjt", "application/vnd.rn-realsystem-rjt"},
                    {".rlc", "application/x-rlc"},
                    {".rle", "application/x-rle"},
                    {".rm", "application/vnd.rn-realmedia"},
                    {".rmf", "application/vnd.adobe.rmf"},
                    {".rmi", "audio/mid"},
                    {".rmj", "application/vnd.rn-realsystem-rmj"},
                    {".rmm", "audio/x-pn-realaudio"},
                    {".rmp", "application/vnd.rn-rn_music_package"},
                    {".rms", "application/vnd.rn-realmedia-secure"},
                    {".rmvb", "application/vnd.rn-realmedia-vbr"},
                    {".rmx", "application/vnd.rn-realsystem-rmx"},
                    {".rnx", "application/vnd.rn-realplayer"},
                    {".rp", "image/vnd.rn-realpix"},
                    {".rpm", "audio/x-pn-realaudio-plugin"},
                    {".rsml", "application/vnd.rn-rsml"},
                    {".rt", "text/vnd.rn-realtext"},
                    {".rtf", "application/msword"},
                    {".rv", "video/vnd.rn-realvideo"},
                    {".sam", "application/x-sam"},
                    {".sat", "application/x-sat"},
                    {".sdp", "application/sdp"},
                    {".sdw", "application/x-sdw"},
                    {".sit", "application/x-stuffit"},
                    {".slb", "application/x-slb"},
                    {".sld", "application/x-sld"},
                    {".slk", "drawing/x-slk"},
                    {".smi", "application/smil"},
                    {".smil", "application/smil"},
                    {".smk", "application/x-smk"},
                    {".snd", "audio/basic"},
                    {".sol", "text/plain"},
                    {".sor", "text/plain"},
                    {".spc", "application/x-pkcs7-certificates"},
                    {".spl", "application/futuresplash"},
                    {".spp", "text/xml"},
                    {".ssm", "application/streamingmedia"},
                    {".sst", "application/vnd.ms-pki.certstore"},
                    {".stl", "application/vnd.ms-pki.stl"},
                    {".stm", "text/html"},
                    {".sty", "application/x-sty"},
                    {".svg", "text/xml"},
                    {".swf", "application/x-shockwave-flash"},
                    {".tdf", "application/x-tdf"},
                    {".tg4", "application/x-tg4"},
                    {".tga", "application/x-tga"},
                    {".tiff", "image/tiff"},
                    {".tld", "text/xml"},
                    {".top", "drawing/x-top"},
                    {".torrent", "application/x-bittorrent"},
                    {".tsd", "text/xml"},
                    {".txt", "text/plain"},
                    {".uin", "application/x-icq"},
                    {".uls", "text/iuls"},
                    {".vcf", "text/x-vcard"},
                    {".vda", "application/x-vda"},
                    {".vdx", "application/vnd.visio"},
                    {".vml", "text/xml"},
                    {".vpg", "application/x-vpeg005"},
                    {".vsd", "application/vnd.visio"},
                    {".vss", "application/vnd.visio"},
                    {".vst", "application/vnd.visio"},
                    {".vsw", "application/vnd.visio"},
                    {".vsx", "application/vnd.visio"},
                    {".vtx", "application/vnd.visio"},
                    {".vxml", "text/xml"},
                    {".wav", "audio/wav"},
                    {".wax", "audio/x-ms-wax"},
                    {".wb1", "application/x-wb1"},
                    {".wb2", "application/x-wb2"},
                    {".wb3", "application/x-wb3"},
                    {".wbmp", "image/vnd.wap.wbmp"},
                    {".wiz", "application/msword"},
                    {".wk3", "application/x-wk3"},
                    {".wk4", "application/x-wk4"},
                    {".wkq", "application/x-wkq"},
                    {".wks", "application/x-wks"},
                    {".wm", "video/x-ms-wm"},
                    {".wma", "audio/x-ms-wma"},
                    {".wmd", "application/x-ms-wmd"},
                    {".wmf", "application/x-wmf"},
                    {".wml", "text/vnd.wap.wml"},
                    {".wmv", "video/x-ms-wmv"},
                    {".wmx", "video/x-ms-wmx"},
                    {".wmz", "application/x-ms-wmz"},
                    {".wp6", "application/x-wp6"},
                    {".wpd", "application/x-wpd"},
                    {".wpg", "application/x-wpg"},
                    {".wpl", "application/vnd.ms-wpl"},
                    {".wq1", "application/x-wq1"},
                    {".wr1", "application/x-wr1"},
                    {".wri", "application/x-wri"},
                    {".wrk", "application/x-wrk"},
                    {".ws", "application/x-ws"},
                    {".ws2", "application/x-ws"},
                    {".wsc", "text/scriptlet"},
                    {".wsdl", "text/xml"},
                    {".wvx", "video/x-ms-wvx"},
                    {".xdp", "application/vnd.adobe.xdp"},
                    {".xdr", "text/xml"},
                    {".xfd", "application/vnd.adobe.xfd"},
                    {".xfdf", "application/vnd.adobe.xfdf"},
                    {".xhtml", "text/html"},
                    {".xls", "application/vnd.ms-excel"},
                    {".xlw", "application/x-xlw"},
                    {".xml", "text/xml"},
                    {".xpl", "audio/scpls"},
                    {".xq", "text/xml"},
                    {".xql", "text/xml"},
                    {".xquery", "text/xml"},
                    {".xsd", "text/xml"},
                    {".xsl", "text/xml"},
                    {".xslt", "text/xml"},
                    {".xwd", "application/x-xwd"},
                    {".x_b", "application/x-x_b"},
                    {".sis", "application/vnd.symbian.install"},
                    {".sisx", "application/vnd.symbian.install"},
                    {".x_t", "application/x-x_t"},
                    {".ipa", "application/vnd.iphone"},
                    {".apk", "application/vnd.android.package-archive"},
                    {".xap", "application/x-silverlight-app"}
                };
            }
        }
        #endregion

        /// <summary>
        /// 图片路径
        /// </summary>
        public class ImgPath
        {
            /// <summary>
            /// 临时图片，路径：/Upload/Img/Temp/20170412143118_4425.jpg
            /// </summary>
            public const string Temp = "/Upload/Img/Temp/";

            /// <summary>
            /// 富文本图片，路径：/Upload/Img/RichText/20170412143118_4425.jpg
            /// </summary>
            public const string RichTextImg = "/Upload/Img/RichText/";

            /// <summary>
            /// 头像图片，路径：/Upload/Img/Avatar/用户ID.jpg
            /// </summary>
            public const string Avatar = "/Upload/Img/Avatar/";

            /// <summary>
            /// 广告位图片，路径：/Upload/Img/Ad/广告位ID/广告位ID.jpg
            /// </summary>
            public const string Ad = "/Upload/Img/Ad/";

            /// <summary>
            /// 自定义页面图片，路径：/Upload/Img/DefinePage/自定义页面ID/自定义页面ID.jpg
            /// </summary>
            public const string DefinePage = "/Upload/Img/DefinePage/";

            /// <summary>
            /// 文章封面图片，路径：/Upload/Img/Article/文章ID/文章ID.jpg
            /// </summary>
            public const string Article = "/Upload/Img/Article/";

            /// <summary>
            /// 商品图片，路径：/Upload/Img/Goods/商品ID/商品ID.jpg
            /// </summary>
            public const string Goods = "/Upload/Img/Goods/";

            /// <summary>
            /// 拍卖活动图片，路径：/Upload/Img/Goods/拍卖活动ID/拍卖活动ID.jpg
            /// </summary>
            public const string Auction = "/Upload/Img/Auction/";

            /// <summary>
            /// 退货单凭证图片，路径：/Upload/Img/RefundOrder/退货单ID/退货单ID.jpg
            /// </summary>
            public const string RefundOrder = "/Upload/Img/RefundOrder/";

            /// <summary>
            /// 商品标签图片，路径：/Upload/Img/GoodsIcon/商品标签ID/商品标签ID.jpg
            /// </summary>
            public const string GoodsIcon = "/Upload/Img/GoodsIcon/";

            /// <summary>
            /// 积分兑换活动图片，路径：/Upload/Img/IntegralActive/积分兑换活动ID/积分兑换活动ID.jpg
            /// </summary>
            public const string IntegralActive = "/Upload/Img/IntegralActive/";

            /// <summary>
            /// 景点图片，路径：/Upload/Img/Attractions/景点ID/景点ID.jpg
            /// </summary>
            public const string Attractions = "/Upload/Img/Attractions/";

            /// <summary>
            /// 酒店图片，路径：/Upload/Img/Attractions/酒店ID/酒店ID.jpg
            /// </summary>
            public const string Hotel = "/Upload/Img/Hotel/";

            /// <summary>
            /// 房型图片，路径：/Upload/Img/Attractions/房型ID/房型ID.jpg
            /// </summary>
            public const string RoomType = "/Upload/Img/RoomType/";

            /// <summary>
            /// 教室图片，路径：/Upload/Img/Attractions/教室ID/教室ID.jpg
            /// </summary>
            public const string Classroom = "/Upload/Img/Classroom/";
        }

        /// <summary>
        /// 文件路径
        /// </summary>
        public class FilePath
        {
            /// <summary>
            /// 临时文件，路径：/Upload/File/Temp/20170412143118_4425.后缀名
            /// </summary>
            public const string Temp = "/Upload/File/Temp/";
        }
    }
}
