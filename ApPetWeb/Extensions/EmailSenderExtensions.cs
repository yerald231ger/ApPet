using System.Threading.Tasks;
using System.Web;

namespace ApPet.Services
{
    public static class EmailSenderExtensions
    {
        public static Task SendEmailConfirmationAsync(this IEmailSender emailSender, string email, string link)
        {            
            return emailSender.SendEmailAsync(email, "Confirm your email",
                $"Please confirm your account by clicking this link: <a href='{HttpUtility.UrlEncode(link)}'>link</a>");
        }
    }
}
