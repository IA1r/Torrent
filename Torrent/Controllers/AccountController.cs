using Core.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessModel.Managers;
using System.Web.Security;
using Torrent.RequestModel;
using Torrent.ViewModels;
using Core.Dto;
using PagedList;

namespace Torrent.Controllers
{

    /// <summary>
    /// The Account Controller
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class AccountController : Controller
    {

        /// <summary>
        /// The user manager
        /// </summary>
        private UserManager userManager;

        /// <summary>
        /// The profile model
        /// </summary>
        private ProfileViewModel profileModel;

        /// <summary>
        /// The send message model
        /// </summary>
        private SendMessageViewModel sendMessageModel;

        /// <summary>
        /// The private message model
        /// </summary>
        private PrivateMessagesViewModel privateMessageModel;

        /// <summary>
        /// The message manger
        /// </summary>
        private MessageManager messageManger;
        public AccountController()
        {
            userManager = new UserManager();
            messageManger = new MessageManager();
        }

        /// <summary>
        /// View of registration page.
        /// </summary>
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        /// <summary>
        /// Register the specified user.
        /// </summary>
        /// <param name="user">The user object.</param>
        [HttpPost]
        public ActionResult Registration(User user)
        {
            this.userManager.CreateUser(user);
            FormsAuthentication.SetAuthCookie(user.Login, false);

            return RedirectToAction("Torrents", "Torrent");
        }

        /// <summary>
        /// View of login page.
        /// </summary>
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Login the specified user.
        /// </summary>
        /// <param name="user">The user object.</param>
        [HttpPost]
        public ActionResult Login(LoginRequestModel user)
        {
            if (this.userManager.ValidateUser(user.Login, user.Password))
                FormsAuthentication.SetAuthCookie(user.Login, user.RememberMe);
            return RedirectToAction("Torrents", "Torrent");
        }

        /// <summary>
        /// Log out.
        /// </summary>
        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Torrents", "Torrent");
        }

        /// <summary>
        /// View of specified user profile.
        /// </summary>
        /// <param name="login">The user login.</param>
        [HttpGet]
        public ActionResult UserProfile(string login)
        {
            try
            {
                this.profileModel = new ProfileViewModel
                {
                    UserProfile = userManager.GetUserProfile(login)
                };
            }
            catch (ArgumentException ex)
            {
                return RedirectToAction("ErrorPage", new { error = ex.Message });
            }

            return View(profileModel);
        }

        /// <summary>
        /// View of send the message.
        /// </summary>
        /// <param name="ToUserID">Recipient identifier.</param>
        [HttpGet]
        public ActionResult SendMessage(int ToUserID)
        {
            try
            {
                this.sendMessageModel = new SendMessageViewModel
                {
                    ToUser = new UserDto
                    {
                        ID = ToUserID,
                        Login = userManager.GetUserLogin(ToUserID)
                    }
                };
            }
            catch (ArgumentException ex)
            {
                return RedirectToAction("ErrorPage", new { error = ex.Message });
            }
            return View(this.sendMessageModel);
        }

        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="request">The meesage request.</param>
        [HttpPost]
        public ActionResult SendMessage(SendMessageViewModel request)
        {
            messageManger.SendMessage(request.PrivateMessage, new MessageTitleDto { Title = request.Title, ToUser = new UserDto { ID = request.ToUser.ID } });
            return RedirectToAction("PrivateMessages", "Account");
        }

        /// <summary>
        /// View of Privates messages.
        /// </summary>
        /// <param name="type">The meesage type.</param>
        [HttpGet]
        public ActionResult PrivateMessages(string type = "input")
        {
            privateMessageModel = new PrivateMessagesViewModel
            {
                Titles = messageManger.GetTitles(type),
                Type = type
            };

            return View(privateMessageModel);
        }

        /// <summary>
        /// View of Private message.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult PrivateMessage(int id, int page = 1)
        {
            int pageSize = 20;
            privateMessageModel = new PrivateMessagesViewModel
            {
                Title = messageManger.GetTitle(id),
                Messages = messageManger.GetMessages(id).ToPagedList(page, pageSize)
            };

            return View(privateMessageModel);
        }

        /// <summary>
        /// Sends answer.
        /// </summary>
        /// <param name="id">The user identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult PrivateMessage(int id, string message)
        {
            messageManger.SendAnswer(id, message);
            return RedirectToAction("PrivateMessage", "Account", routeValues: new { id = id });
        }

        /// <summary>
        /// View of errors.
        /// </summary>
        /// <param name="error">The error.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ErrorPage(string error)
        {
            return View("Error", null, error);
        }

    }
}
