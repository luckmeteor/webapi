﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using JWT;
using JWT.Serializers;
using webapi.Models;
using System.Text;
using System.Net;
using System.Net.Http;
using JWT.Algorithms;

namespace webapi.Attributes
{
    /// <summary>
    /// 身份认证拦截器
    /// </summary>
    public class ApiAuthorizeAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// 指示指定的控件是否已获得授权
        /// </summary>
        /// <param name="actionContext"></param>
        /// <returns></returns>
        //protected override bool IsAuthorized(HttpActionContext actionContext)
        //{
        //    //前端请求api时会将token存放在名为"auth"的请求头中
        //    var authHeader = from t in actionContext.Request.Headers where t.Key == "auth" select t.Value.FirstOrDefault();
        //    if (authHeader != null)
        //    {
        //        const string secretKey = "Hello World";//加密秘钥
        //        string token = authHeader.FirstOrDefault();//获取token
        //        if (!string.IsNullOrEmpty(token))
        //        {
        //            try
        //            {
        //                byte[] key = Encoding.UTF8.GetBytes(secretKey);
        //                IJsonSerializer serializer = new JsonNetSerializer();
        //                IDateTimeProvider provider = new UtcDateTimeProvider();
        //                IJwtValidator validator = new JwtValidator(serializer, provider);
        //                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
        //                var algorithm = new HMACSHA256Algorithm();
        //                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder, algorithm);
        //                //解密
        //                var json = decoder.DecodeToObject<AuthInfo>(token, key, verify: true);
        //                if (json != null)
        //                {
        //                    //判断口令过期时间
        //                    if (json.ExpiryDateTime < DateTime.Now)
        //                    {
        //                        return false;
        //                    }
        //                    actionContext.RequestContext.RouteData.Values.Add("auth", json);
        //                    return true;
        //                }
        //                return false;
        //            }
        //            catch (Exception ex)
        //            {
        //                return false;
        //            }
        //        }
        //    }
        //    return false;
        //}

        /// <summary>
        /// 处理授权失败的请求
        /// </summary>
        /// <param name="actionContext"></param>
        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            var erModel = new
            {
                Success = "false",
                ErrorCode = "401"
            };
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.OK, erModel, "application/json");
        }

        private AuthInfo ValidateTicket(HttpActionContext actionContext)
        {
            AuthInfo auinfo=null;
            var authHeader = from t in actionContext.Request.Headers where t.Key == "auth" select t.Value.FirstOrDefault();
            if (authHeader != null)
            {
                const string secretKey = "Hello World";//加密秘钥
                string token = authHeader.FirstOrDefault();//获取token
                try
                {
                    byte[] key = Encoding.UTF8.GetBytes(secretKey);
                    IJsonSerializer serializer = new JsonNetSerializer();
                    IDateTimeProvider provider = new UtcDateTimeProvider();
                    IJwtValidator validator = new JwtValidator(serializer, provider);
                    IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                    var algorithm = new HMACSHA256Algorithm();
                    IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder, algorithm);
                    //解密
                    auinfo = decoder.DecodeToObject<AuthInfo>(token, key, verify: true);
                    ////管道传参
                    var obj = new { username = auinfo.UserName, usercode = "testcode" };
                    HttpContext.Current.Items["UserName"] = obj;
                }
                catch(Exception ex)
                {
                    throw ex;
                }
              }
               return auinfo;
        }
        // <summary>
        //  为操作授权时调用
        // </summary>
        // <param name = "actionContext" ></ param >
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            bool skipAuthorization = actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().OfType<AllowAnonymousAttribute>().Any(c => c is AllowAnonymousAttribute)
                                     || actionContext.ActionDescriptor.ControllerDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().OfType<AllowAnonymousAttribute>().Any(c => c is AllowAnonymousAttribute);
            if (skipAuthorization)
            {
                base.OnAuthorization(actionContext);
                return;
            }
            try
            {
                var json = ValidateTicket(actionContext);
                if (json != null)
                {
                    string UserIP =webapi.Helper.GetUserAgentInfo.GetIP();

                    if (json.ExpiryDateTime < DateTime.Now)
                    {
                        var erModel = new
                        {
                            Success = "false,token 超时",
                            ErrorCode = "401"
                        };
                        actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.OK, erModel, "application/json");
                        return;
                    }
                    else if (json.ReqeustIP!= UserIP)
                    {
                        var erModel = new
                        {
                            Success = "false,非法请求IP",
                            ErrorCode = "401"
                        };
                        actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.OK, erModel, "application/json");
                        return;
                    }
                    else {
                        base.IsAuthorized(actionContext);
                        return;
                    }
                }
                else
                {
                    var erModel = new
                    {
                        Success = "false,token 不能为空",
                        ErrorCode = "401"
                    };
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.OK, erModel, "application/json");
                    return;
                }
            }
            catch (Exception ex)
            {
                var erModel = new
                {
                    Success = "false,"+ex.Message,
                    ErrorCode = "401"
                };
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.OK, erModel, "application/json");
                return;
            }
            
        }
    }
}
