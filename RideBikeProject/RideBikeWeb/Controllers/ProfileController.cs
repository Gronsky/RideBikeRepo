using System;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using RideBikeProjectBLL.Interfaces;
using System.IO;
using RideBike.Infrastructure.Models;
using RideBike.Infrastructure.DTO;

namespace RideBikeWeb.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        IUserService _userService;
        public ProfileController(IUserService userServ)
        {
            _userService = userServ;
        }

        // GET: Profile
        public ActionResult Index(long Id)
        {
            var userDto = _userService.GetUser(Id);
            var model = Mapper.Map<UserDTO, UserViewModel>(userDto);
            return View(model);
        }

        public ActionResult Update(long Id)
        {
            var userDto = _userService.GetUser(Id);
            var model = Mapper.Map<UserDTO, UserViewModel>(userDto);
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(UserViewModel model)
        {
            var userDto = Mapper.Map<UserViewModel, UserDTO>(model);
            _userService.UpdateUser(userDto);

            return RedirectToAction("Index", "Profile", new { Id = model.Id });
        }

        [HttpPost]
        public ActionResult FileUpload(HttpPostedFileBase file, long userId)
        {
            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = Path.Combine(Server.MapPath("~/Content/Img/users"), pic);
                file.SaveAs(path);

                // save the image path to the database [Image].[Source]
                string imagePath = String.Concat("../../Content/Img/users/", pic);
                _userService.ChangeImage(imagePath, userId);
            }

            return RedirectToAction("Index", "Profile", new { Id = userId });
        }
    }
}