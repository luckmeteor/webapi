using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webapi.Helper
{
    public static class RegValidationTypes
    {
        /// <summary>
        /// 数字
        /// </summary>
        public static string Numeric = @"^(\d+[\s,]*)+\.?\d*$";
        /// <summary>
        /// 正数
        /// </summary>
        public static string PositiveNumber = @"^(0\.0*[1-9]+[0-9]*$|[1-9]+[0-9]*\.[0-9]*[0-9]$|[1-9]+[0-9]*$)";
        /// <summary>
        /// 负数
        /// </summary>
        public static string NegativeNumber = @"^-(0\.0*[1-9]+[0-9]*$|[1-9]+[0-9]*\.[0-9]*[0-9]$|[1-9]+[0-9]*$)";
        /// <summary>
        /// 整数
        /// </summary>
        public static string Integer = @"^-?[1-9]+[0-9]*$|^0$";
        /// <summary>
        /// 金钱类型
        /// </summary>
        public static string Money = @"^(([0-9]|([1-9][0-9]{0,9}))((\.[0-9]{1,2})?))$";
        /// <summary>
        /// 日期类型
        /// </summary>
        public static string Date = @"^(?:(?:1[6-9]|[2-9][0-9])[0-9]{2}([-/.]?)(?:(?:0?[1-9]|1[0-2])\1(?:0?[1-9]|1[0-9]|2[0-8])|(?:0?[13-9]|1[0-2])\1(?:29|30)|(?:0?[13578]|1[02])\1(?:31))|(?:(?:1[6-9]|[2-9][0-9])(?:0[48]|[2468][048]|[13579][26])|(?:16|[2468][048]|[3579][26])00)([-/.]?)0?2\2(?:29))(\s+([01][0-9]:|2[0-3]:)?[0-5][0-9]:[0-5][0-9])?$";
        /// <summary>
        /// 时间类型
        /// </summary>
        public static string Time = @"^(\d{1,2})(:)?(\d{1,2})\2(\d{1,2})$";
        /// <summary>
        /// 身份证号码
        /// </summary>
        public static string IDCard = @"(^\d{15}$)|(^\d{18}$)|(^\d{17}(\d|X|x)$)";
        /// <summary>
        /// 邮政编码
        /// </summary>
        public static string PostCode = @"^[0-9]{6}$";
        /// <summary>
        /// 手机号码
        /// </summary>
        public static string PhoneNumber = @"^13[0-9]{9}$|14[0-9]{9}|15[0-9]{9}$|16[0-9]{9}$|17[0-9]{9}$|18[0-9]{9}$|19[0-9]{9}$";
        /// <summary>
        /// 固话格式
        /// </summary>
        public static string Telephone = @"(^[0-9]{3,4}\-[0-9]{3,8}$)|(^[0-9]{3,8}$)|(^\([0-9]{3,4}\)[0-9]{3,8}$)|(^0{0,1}13[0-9]{9}$)";
        /// <summary>
        /// 手机或固话类型
        /// </summary>
        public static string PhoneOrTelNumber = @"(^13[0-9]{9}$|14[0-9]{9}|15[0-9]{9}$|16[0-9]{9}$|17[0-9]{9}$|18[0-9]{9}$|19[0-9]{9}$)|((^[0-9]{3,4}\-[0-9]{3,8}$)|(^[0-9]{3,8}$)|(^\([0-9]{3,4}\)[0-9]{3,8}$)|(^0{0,1}13[0-9]{9}$))";
        /// <summary>
        /// 邮件类型
        /// </summary>
        public static string EmailAddress = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
        /// <summary>
        /// 表达式：^(\w+:\/\/)?\w+(\.\w+)+.*$
        /// </summary>
        public static string Url = @"^(\w+:\/\/)?\w+(\.\w+)+.*$";
        /// <summary>
        /// 颜色类型
        /// </summary>
        public static string Color = @"(^#([0-9a-f]{6}|[0-9a-f]{3})$)|(^rgb\(([0-9]|[0-9][0-9]|25[0-5]|2[0-4][0-9]|[0-1][0-9][0-9])\,([0-9]|[0-9][0-9]|25[0-5]|2[0-4][0-9]|[0-1][0-9][0-9])\,([0-9]|[0-9][0-9]|25[0-5]|2[0-4][0-9]|[0-1][0-9][0-9])\)$)|(^rgba\(([0-9]|[0-9][0-9]|25[0-5]|2[0-4][0-9]|[0-1][0-9][0-9])\,([0-9]|[0-9][0-9]|25[0-5]|2[0-4][0-9]|[0-1][0-9][0-9])\,([0-9]|[0-9][0-9]|25[0-5]|2[0-4][0-9]|[0-1][0-9][0-9])\,(1|1.0|0.[0-9])\)$)";
        /// <summary>
        /// 中文
        /// </summary>
        public static string Chinese = @"^[\u4e00-\u9fa5]+$";
        /// <summary>
        /// IPv4 类型
        /// </summary>
        public static string IPv4 = @"^((25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\.){3}(25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})$";
        /// <summary>
        /// IPv6 类型
        /// </summary>
        public static string IPv6 = @"/^\s*((([0-9A-Fa-f]{1,4}:){7}([0-9A-Fa-f]{1,4}|:))|(([0-9A-Fa-f]{1,4}:){6}(:[0-9A-Fa-f]{1,4}|((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3})|:))|(([0-9A-Fa-f]{1,4}:){5}(((:[0-9A-Fa-f]{1,4}){1,2})|:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3})|:))|(([0-9A-Fa-f]{1,4}:){4}(((:[0-9A-Fa-f]{1,4}){1,3})|((:[0-9A-Fa-f]{1,4})?:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3}))|:))|(([0-9A-Fa-f]{1,4}:){3}(((:[0-9A-Fa-f]{1,4}){1,4})|((:[0-9A-Fa-f]{1,4}){0,2}:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3}))|:))|(([0-9A-Fa-f]{1,4}:){2}(((:[0-9A-Fa-f]{1,4}){1,5})|((:[0-9A-Fa-f]{1,4}){0,3}:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3}))|:))|(([0-9A-Fa-f]{1,4}:){1}(((:[0-9A-Fa-f]{1,4}){1,6})|((:[0-9A-Fa-f]{1,4}){0,4}:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3}))|:))|(:(((:[0-9A-Fa-f]{1,4}){1,7})|((:[0-9A-Fa-f]{1,4}){0,5}:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3}))|:)))(%.+)?\s*$";
        /// <summary>
        /// 年龄
        /// </summary>
        public static string Age = @"^[1-99]?\d*$";
        /// <summary>
        /// 中文名
        /// </summary>
        public static string ChineseName = @"^[\u0391-\uFFE5]{2,15}$";
        /// <summary>
        /// 英文名
        /// </summary>
        public static string EnglishName = @"^[A-Za-z]{1,161}$";
        /// <summary>
        /// 纯大写
        /// </summary>
        public static string Capital = @"^[A-Z]+$";
        /// <summary>
        /// 纯小写
        /// </summary>
        public static string Lowercase = @"^[a-z]+$";
        /// <summary>
        /// ASCII 编码
        /// </summary>
        public static string Ascii = @"^[\x00-\xFF]+$";
        /// <summary>
        /// MD5 加密字符串
        /// </summary>
        public static string Md5 = @"^([a-fA-F0-9]{32})$";
        /// <summary>
        /// 压缩文件格式
        /// </summary>
        public static string Zip = @"(.*)\.(rar|zip|7zip|tgz)$";
        /// <summary>
        /// 图片格式
        /// </summary>
        public static string Image = @"(.*)\.(jpg|gif|ico|jpeg|png)$";
        /// <summary>
        /// 文档格式
        /// </summary>
        public static string Document = @"(.*)\.(doc|xls|docx|xlsx|pdf|md)$";
        /// <summary>
        /// MP3 格式
        /// </summary>
        public static string Mp3 = @"(.*)\.(mp3)$";
        /// <summary>
        /// 视频文件格式
        /// </summary>
        public static string Video = @"(.*)\.(rm|rmvb|wmv|avi|mp4|3gp|mkv)$";
        /// <summary>
        ///字母加数字组合
        /// </summary>
        public static string WordWithNumber = @"^(?![0-9]+$)(?![a-zA-Z]+$)[0-9A-Za-z]*$";
        

    }
}