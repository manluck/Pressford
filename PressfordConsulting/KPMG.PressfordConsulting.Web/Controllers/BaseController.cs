using System.Linq;
using System.Web.Mvc;
using KPMG.PressfordConsulting.Data;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Ninject;

namespace KPMG.PressfordConsulting.Controllers
{
    public class BaseController : Controller
    {
        [Inject]
        public IGenericRepository<UserLocation> UserLocationRepository { get; set; }

        [Inject]
        public IGenericRepository<Location> LocationRepository { get; set; }

        [Inject]
        public IEmailService EmailService { get; set; }

        [Inject]
        public ApplicationUserManager UserManager { get; set; }

        [Inject]
        public ApplicationRoleManager RoleManager { get; set; }

        [Inject]
        public ApplicationSignInManager SignInManager { get; set; }

        [Inject]
        public IAuthenticationManager AuthenticationManager { get; set; }

        public UserViewModel CurrentUser
        {
            get
            {
                if (User != null && User.Identity != null && User.Identity.IsAuthenticated)
                {
                    var applicationUser = UserManager.FindByName(User.Identity.Name);
                    var isAdmin = User.IsInRole("Admin");
                    var locations = isAdmin ? LocationRepository.GetAll().ToList() : UserLocationRepository.GetAll(x => x.UserId == applicationUser.Id).Select(x => x.Location).ToList();
                    return applicationUser.ToUserViewModel(locations);
                }

                return null;
            }
        }

        public bool IsAdmin
        {
            get { return User.IsInRole("Admin"); }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ViewBag.IsAdmin = IsAdmin;
            ViewBag.CurrentUser = CurrentUser;
            ViewBag.Locations = LocationRepository.GetAll().ToList();
            base.OnActionExecuting(filterContext);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (UserManager != null)
                {
                    UserManager.Dispose();
                    UserManager = null;
                }

                if (SignInManager != null)
                {
                    SignInManager.Dispose();
                    SignInManager = null;
                }

                if (RoleManager != null)
                {
                    RoleManager.Dispose();
                    RoleManager = null;
                }
            }

            base.Dispose(disposing);
        }

        protected void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        protected bool HasPassword()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PasswordHash != null;
            }
            return false;
        }
    }

}
