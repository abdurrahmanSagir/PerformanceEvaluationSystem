using PerformanceEvaluationSystem.App_Classes;
using PerformanceEvaluationSystem.App_Classes.Enums;
using PerformanceEvaluationSystem.App_Classes.ResponseViewModel;
using PerformanceEvaluationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PerformanceEvaluationSystem.Controllers
{
    public class EmployeeController : Controller
    {
        PerformanceEvaluation ctx = new PerformanceEvaluation();

        public ActionResult Index()
        {

            List<User> userList = ctx.Users.ToList();
            List<UsersDto> userFilteredList = new List<UsersDto>();

            foreach (var item in userList)
            {
                var UsersDtoItem = new UsersDto();
                UsersDtoItem.TargetAssignmentManagerName = userList.Where(i => i.ID == item.TargetAssignmentManagerID).FirstOrDefault()?.Name + " " + userList.Where(i => i.ID == item.TargetAssignmentManagerID).FirstOrDefault()?.Surname;
                UsersDtoItem.FirstManagerName = userList.Where(i => i.ID == item.FirstManagerID).FirstOrDefault()?.Name + " " + userList.Where(i => i.ID == item.FirstManagerID).FirstOrDefault()?.Surname;
                UsersDtoItem.SecondManagerName = userList.Where(i => i.ID == item.SecondManagerID).FirstOrDefault()?.Name + " " + userList.Where(i => i.ID == item.SecondManagerID).FirstOrDefault()?.Surname;
                UsersDtoItem.CompanyName = item.CompanyName;
                UsersDtoItem.Name = item.Name;
                UsersDtoItem.Surname = item.Surname;
                UsersDtoItem.PhoneNumber = item.PhoneNumber;
                UsersDtoItem.RegistryNumber = item.RegistryNumber;
                UsersDtoItem.Email = item.Email;
                UsersDtoItem.IsActive = item.IsActive;

                userFilteredList.Add(UsersDtoItem);

            }


            return View(userFilteredList);
        }

        public string ConvertTRCharToENChar(string text, bool isEmail)
        {
            text = text.Replace('ö', 'o');
            text = text.Replace('ü', 'u');
            text = text.Replace('ğ', 'g');
            text = text.Replace('ş', 's');
            text = text.Replace('ı', 'i');
            text = text.Replace('ç', 'c');
            text = text.Replace('Ö', 'O');
            text = text.Replace('Ü', 'U');
            text = text.Replace('Ğ', 'G');
            text = text.Replace('Ş', 'S');
            text = text.Replace('İ', 'I');
            text = text.Replace('Ç', 'C');
            if(isEmail)
                text = text.Replace(' ', '.');


            return text;
        }

        public ActionResult AddEmployee()
        {
            var list = from tu in ctx.Users.ToList()
                       join ur in ctx.UserRoles.ToList() on tu.ID equals ur.UserID
                       where ur.RoleID == (int)RoleEnums.BirinciYonetici
                       select tu
                       ;
            var list1 = from tu in ctx.Users.ToList()
                        join ur in ctx.UserRoles.ToList() on tu.ID equals ur.UserID
                        where ur.RoleID == (int)RoleEnums.IkinciYonetici
                        select tu
                       ;
            var list2 = from tu in ctx.Users.ToList()
                        join ur in ctx.UserRoles.ToList() on tu.ID equals ur.UserID
                        where ur.RoleID == (int)RoleEnums.HedefYoneticisi
                        select tu
                       ;

            ViewBag.FirstManagerID = list.Select(c => new SelectListItem
            {
                Value = c.ID.ToString(),
                Text = c.Name + ' ' + c.Surname
            });

            ViewBag.SecondManagerID = list1.Select(c => new SelectListItem
            {
                Value = c.ID.ToString(),
                Text = c.Name + ' ' + c.Surname

            });
            ViewBag.TargetAssignmentManagerID = list2.Select(c => new SelectListItem
            {
                Value = c.ID.ToString(),
                Text = c.Name + ' ' + c.Surname

            });

            //ViewBag.Role = ctx.Roles.ToList().Select(c => new SelectListItem
            //{
            //    Value = c.ID.ToString(),
            //    Text = c.Name

            //});

            ViewBag.Role = ctx.Roles.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployee(User u, int ID)
        {
            #region Adding User
            u.CreationTime = DateTime.Now;
            //değiştirelecek
            u.CreUser = ((User)Session["CurrentUser"]).ID;
            u.IsDeleted = false;
            u.UserStatus = "1";
            u.IsActive = true;
            string mail = u.Name.ToLower() + u.Surname.ToLower() + "@peres.com";
            
            u.Email = ConvertTRCharToENChar(mail,true);
            ctx.Users.Add(u);
            ctx.SaveChanges();
            #endregion

            #region Adding UserRole to Last Added User
            UserRole userRole = new UserRole();
            User usr = ctx.Users.OrderByDescending(x => x.ID).FirstOrDefault();
            userRole.UserID = usr.ID;
            userRole.RoleID = ID;
            //değiştirelecek
            userRole.CreUser = ((User)Session["CurrentUser"]).ID;
            userRole.IsDeleted = false;
            userRole.CreationTime = DateTime.Now;
            ctx.UserRoles.Add(userRole);
            ctx.SaveChanges();
            #endregion

            LoginInformation lg = new LoginInformation();
            lg.Username = ConvertTRCharToENChar((usr.Name.Substring(0, 1) + usr.Surname).ToLower(), false);
            lg.Password = "123456";
            lg.CreationTime = DateTime.Now;
            lg.IsDeleted = false;
            //değiştirelecek
            lg.CreUser = ((User)Session["CurrentUser"]).ID;
            ctx.LoginInformations.Add(lg);
            ctx.SaveChanges();

            LoginInformation login = ctx.LoginInformations.OrderByDescending(x => x.ID).FirstOrDefault();
            usr.LoginID = login.ID;
            ctx.SaveChanges();



            return RedirectToAction("Index", "Employee");
        }

        public ActionResult DeleteEmployee(int id)
        {

            User u = ctx.Users.FirstOrDefault(o => o.RegistryNumber == id.ToString());
            u.IsActive = false;
            u.DeletionTime = DateTime.Now;
            //değiştirelecek
            u.ModUser = ((User)Session["CurrentUser"]).ID;
            u.IsDeleted = true;

            ctx.SaveChanges();
            return RedirectToAction("Index", "Employee");
        }

        public ActionResult UpdateEmployee(string id)
        {
            User u = ctx.Users.FirstOrDefault(o => o.RegistryNumber == id.ToString());

            var list = from tu in ctx.Users.ToList()
                       join ur in ctx.UserRoles.ToList() on tu.ID equals ur.UserID
                       where ur.RoleID == (int)RoleEnums.BirinciYonetici
                       select tu
                     ;
            var list1 = from tu in ctx.Users.ToList()
                        join ur in ctx.UserRoles.ToList() on tu.ID equals ur.UserID
                        where ur.RoleID == (int)RoleEnums.IkinciYonetici
                        select tu
                       ;
            var list2 = from tu in ctx.Users.ToList()
                        join ur in ctx.UserRoles.ToList() on tu.ID equals ur.UserID
                        where ur.RoleID == (int)RoleEnums.HedefYoneticisi
                        select tu
                       ;

            ViewBag.FirstManagerID = list.Select(c => new SelectListItem
            {
                Value = c.ID.ToString(),
                Text = c.Name + ' ' + c.Surname,
                Selected = (u.FirstManagerID == c.ID ? true : false) //(ctx.Users.Select(x => x.ID == u.FirstManagerID).FirstOrDefault())
            });

            ViewBag.SecondManagerID = list1.Select(c => new SelectListItem
            {
                Value = c.ID.ToString(),
                Text = c.Name + ' ' + c.Surname,
                Selected = (u.SecondManagerID == c.ID ? true : false)//(ctx.Users.Select(x => x.ID == u.SecondManagerID).FirstOrDefault())

            });
            ViewBag.TargetAssignmentManagerID = list2.Select(c => new SelectListItem
            {
                Value = c.ID.ToString(),
                Text = c.Name + ' ' + c.Surname,
                Selected = (u.TargetAssignmentManagerID == c.ID ? true : false) //(ctx.Users.Select(x => x.ID == u.TargetAssignmentManagerID).FirstOrDefault())

            });

            ViewBag.Role = ctx.Roles.ToList();


            return View(u);
        }

        [HttpPost]
        public ActionResult UpdateEmployee(User u)
        {
            User user = ctx.Users.FirstOrDefault(x => x.RegistryNumber == u.RegistryNumber);

            user.Name = u.Name;
            user.Surname = u.Surname;
            user.RegistryNumber = u.RegistryNumber;
            user.PhoneNumber = u.PhoneNumber;
            user.Email = u.Email;
            user.CompanyName = u.CompanyName;
            user.TargetAssignmentManagerID = u.TargetAssignmentManagerID;
            user.FirstManagerID = u.FirstManagerID;
            user.SecondManagerID = u.SecondManagerID;
            //değiştirelecek
            user.ModUser = ((User)Session["CurrentUser"]).ID;
            ctx.SaveChanges();

            return RedirectToAction("Index", "Employee");
        }
    }
}