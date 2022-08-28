using AppCore.Common;
using AppCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Managers
{

    public class NewsLetterSubscriptionManager
    {
        private readonly AppCoreContext context;

        public NewsLetterSubscriptionManager(AppCoreContext context)
        {
            this.context = context;
        }

        public bool EmailExists(string email)
        {
            var result = context.NewsletterSubscriptions.FirstOrDefault(x => x.Email.ToLower().Trim() == email.ToLower().Trim());
            return (result != null);
        }

        public Result AddSubscription(string email)
        {
            if (!EmailExists(email))
            {
                var subscriptionEntity = new NewsletterSubscription();

                subscriptionEntity.Email = email;
                subscriptionEntity.SubscriptionDate = DateTime.Now;

                try
                {
                    context.NewsletterSubscriptions.Add(subscriptionEntity);
                    context.SaveChanges();
                    return Result.Ok();
                }
                catch (Exception ex)
                {
                    return Result.Fail(ex.Message);
                }
            }
            else
            {
                return Result.Fail("Email already exist !!");
            }
        }

    }
}
