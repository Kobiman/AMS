using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AMS.Server
{
    public class AuditFilterAttribute : ActionFilterAttribute
    {
        private readonly IAuditService _auditService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuditFilterAttribute(IAuditService auditService, IHttpContextAccessor httpContextAccessor)
        {
            _auditService = auditService;
            _httpContextAccessor = httpContextAccessor;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var request = filterContext.HttpContext.Request;
            Audit audit = new Audit();

            if (_httpContextAccessor.HttpContext != null)
            {
                audit.IPAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
                audit.UserName = _httpContextAccessor.HttpContext.User.Identity.Name;
            }

            audit.ControllerName = ((ControllerBase)filterContext.Controller).ControllerContext.ActionDescriptor.ControllerName;
            audit.ActionName = ((ControllerBase)filterContext.Controller).ControllerContext.ActionDescriptor.ActionName;
            audit.TimeAccessed = DateTime.UtcNow;
            audit.PageAccessed = request.Path.ToString();
            _auditService.InsertAuditRecord(audit);
            //base.OnActionExecuting(filterContext);

        }
    }
}
