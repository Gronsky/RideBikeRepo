using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using RideBikeProjectBLL.DTO;
using RideBikeProjectBLL.Infrastructure;
using RideBikeProjectBLL.Interfaces;
using RideBikeProjectBLL.Services;
using RideBikeWeb.Models;
using System.IO;

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

        [HttpPost]
        public ActionResult Change(long Id)
        {
            var userDto = _userService.GetUser(Id);
            var model = Mapper.Map<UserDTO, UserViewModel>(userDto);
            return View(model);
        }

        [HttpPost]
        public ActionResult FileUpload(HttpPostedFileBase file, long userId)
        {
            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = Path.Combine(Server.MapPath("~/Content/Img/users"), pic);

                file.SaveAs(path);

                // save the image path path to the database
                string imagePath = String.Concat("../../Content/Img/users/", pic);
                _userService.ChangeImage(imagePath, userId);
            }

            return RedirectToAction("Index", "Profile", new { Id = userId });
        }
    }
}