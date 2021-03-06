﻿using System;
using System.Net.Mail;

namespace MessageBoard.Services
{
    public interface IMailService
    {
        bool SendMail(string from, string to, string subject, string body);
    }

    public class MailService : IMailService
    {
        public bool SendMail(string from, string to, string subject, string body)
        {
            try
            {
                var msg = new MailMessage(from, to, subject, body);

                var client = new SmtpClient();
                client.Send(msg);
            }
            catch (Exception e)
            {
                //add logging
                return false;
            }

            return true;
        }
    }
}