using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webapi.Attributes;
using webapi.Models;
using Mapster;
using System.Web;

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
        /// <summary>
        /// token判断
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string GetUserInfo()
        {
            var userInfo = new
            {
                UserName = "test",
                Tel = "123456789",
                Address = "testddd"
            };
            //获取管道传参
            var userData= HttpContext.Current.Items["UserName"];
            return JsonConvert.SerializeObject(userInfo);
        }
        /// <summary>
        /// 实体校验
        /// </summary>
        /// <param name="com"></param>
        /// <returns></returns>
        [HttpPost]
        public string VaildModle(Common com)
        {
            return "Ok";
        }
        /// <summary>
        /// 实体映射
        /// </summary>
        /// <param name="modle"></param>
        /// <returns></returns>
        [AllowAnonymous]
        public UserDto ModleMapper(User modle)
        {
            var dto = modle.Adapt<UserDto>();//映射为新对象
            return dto;
        }

        [AllowAnonymous]
        public StudentDto ModleMapper1()
        {
            Cource cource = new Cource();
            cource.ID = "1";
            cource.CourceName = "数学";
            cource.Grade = 80.56;

            Student stu = new Student();
            stu.AGE = 25;
            stu.ID = "1";
            stu.CID = "321281199505290919";
            stu.NAME = "陈兆杰";
            stu.Cource = cource;
            StudentDto stuDto = new StudentDto();
            {
                TypeAdapterConfig config = new TypeAdapterConfig();
                //建立映射关系一， NewConfig 删除任何现有配置
                {
                    config.NewConfig<Student, StudentDto>()
            .Map(dto => dto.ID, d => d.ID).Map(dto => dto.NAME, d => d.NAME).Map(dto => dto.CourceName, s => s.Cource.CourceName);
                }
                //建立映射关系二，而 ForType 创建或增强配置。
                {
                    //        config.ForType<Student, StudentDto>()
                    //.Map(dto => dto.ID, d => d.ID).Map(dto => dto.NAME, d => d.NAME).Map(dto => dto.CourceName, s => s.Cource.CourceName);
                }
                stuDto = stu.Adapt<StudentDto>(config);//根据config配置，映射stu实体为StudentDto类型
            }
            return stuDto;
        }
    }
    

}
