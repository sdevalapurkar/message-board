﻿using System;
using System.Linq;
using System.Web.Mvc;
using MessageBoard.Data;
using MessageBoard.Models;
using MessageBoard.Services;

namespace MessageBoard.Controllers
{
    public class HomeController : Controller
    {
        private IMailService _mail;
        private IMessageBoardRepository _repo;

        public HomeController(IMailService mail, IMessageBoardRepository repo)
        {
            _mail = mail;
            _repo = repo;
        }

        public ActionResult Index()
        {

            var topics = _repo.GetTopics().
                OrderByDescending(t => t.Created)
                .Take(25)
                .ToList();

            return View(topics);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        /*public ActionResult Contact(string name, string email, string website, string comment)*/
        /*instead of passing these 4 parameters, we can pass a model instead*/
        public ActionResult Contact(ContactModel model)
        {
            var msg = string.Format("Comment From: {1}{0}Email:{2}{0}Website: {3}{0}Comment", 
                Environment.NewLine, 
                model.Name, 
                model.Email, 
                model.Website, 
                model.Comment);

            if (_mail.SendMail("noreply@yourdomain.com",
                "foo@yourdomain.com",
                "Website contact",
                msg))
            {
                ViewBag.MailSent = true;
            }

            return View();
        }

        [Authorize]
        public ActionResult MyMessages()
        {
            return View();
        }

        [Authorize(Roles="Admin")]
        public ActionResult Moderation()
        {
            return View();
        }
    }
}