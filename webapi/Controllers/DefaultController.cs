using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webapi.Attributes;
using webapi.Models;
namespace webapi.Controllers
{
    public class DefaultController : ApiController
    {
        /// <summary>
        /// 测试方法
        /// </summary>
        /// <param name="str">显示值</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public string GetTestFun(string str)
        {
            return str;
        }
        [HttpGet]
        public string GetUserInfo()
        {
            var userInfo = new
            {
                UserName = "test",
                Tel = "123456789",
                Address = "testddd"
            };
            return JsonConvert.SerializeObject(userInfo);
        }

        [HttpPost]
        public string VaildModle(Common com)
        {
            return "Ok";
        }
    }
}
