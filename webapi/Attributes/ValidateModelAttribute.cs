using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.ModelBinding;

namespace webapi.Attributes
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            //if (actionContext.ModelState.IsValid == false)
            //{
            //    //actionContext.Response = actionContext.Request.CreateErrorResponse(
            //    //    HttpStatusCode.BadRequest, actionContext.ModelState);
            //    var errors = new Dictionary<string, IEnumerable<string>>();
            //    foreach (KeyValuePair<string, ModelState> keyValue in actionContext.ModelState)
            //    {
            //        errors[keyValue.Key] = keyValue.Value.Errors.Select(e => e.ErrorMessage);
            //    }
            //    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.BadRequest, new
            //    {
            //        code = HttpStatusCode.BadRequest,//返回客户端的状态码
            //        success = false,
            //        error = errors//显示验证错误的信息
            //    });
            //}
            if (!actionContext.ModelState.IsValid)
            {
                ///实体验证未通过
                string ErrorMsg = string.Empty;
                var ErrorsModel = actionContext.ModelState.Values.Where(item => { return item.Errors.Count >0 ; }).ToList().FirstOrDefault();
                var ErrorsList = actionContext.ModelState.Values.Where(item => { return item.Errors.Count > 0; }).ToList();
               
                if (ErrorsList.Count>=0)
                {
                    var Errors = ErrorsList.Select(i => i.Errors).ToList() ;
                    List<string> errMsgs = new List<string>();
                    foreach (var err in Errors)
                    {
                        errMsgs.AddRange(err.Select(i => i.ErrorMessage));
                    }
                    ErrorMsg = string.Join(";", errMsgs);
                    //var test=Errors.Select(i=>)
                }
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.BadRequest, new
                {
                    code = HttpStatusCode.BadRequest,//返回客户端的状态码
                    success = false,
                    error = ErrorMsg//显示验证错误的信息
                });
            }
        }
    
    }
}