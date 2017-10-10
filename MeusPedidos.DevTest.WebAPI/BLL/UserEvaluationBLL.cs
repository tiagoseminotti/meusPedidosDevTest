using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace MeusPedidos.DevTest.WebAPI.BLL
{
    /// <summary>
    /// Business logic class for user evaluation
    /// </summary>
    public class UserEvaluationBLL
    {
        /// <summary>
        /// Checks the applicant scores and sends e-mails
        /// </summary>
        /// <param name="pApplicant">Applicant data</param>
        public static void CheckApplicantScores(Models.UserEvaluation pApplicant)
        {
            //An applicant is approved for a front end opening when HTML, CSS and JavaScript are between the approved scores
            bool frontEndMail = IsApprovedScore(pApplicant.NR_EVAL_HTML) && IsApprovedScore(pApplicant.NR_EVAL_CSS) && IsApprovedScore(pApplicant.NR_EVAL_JAVASCRIPT) ? true : false;
            //An applicant is approved for a back end opening when Python and Django are between the approved scores
            bool backEndMail = IsApprovedScore(pApplicant.NR_EVAL_PYTHON) && IsApprovedScore(pApplicant.NR_EVAL_DJANGO) ? true : false;
            //An applicant is approved for a back end opening when iOS and Android are between the approved scores
            bool mobileEmail = IsApprovedScore(pApplicant.NR_EVAL_IOS) && IsApprovedScore(pApplicant.NR_EVAL_ANDROID) ? true : false;

            SendEmail(frontEndMail, backEndMail, mobileEmail, pApplicant.DS_EMAIL).Wait();
        }

        private static async Task SendEmail(bool pFrontEnd, bool pBackEnd, bool pMobile, string pEmail)
        {
            var apiKey = System.Environment.GetEnvironmentVariable("SENDGRID_APIKEY");
            var client = new SendGridClient(apiKey);
            string msgContent = "We would like to thank you for your application, we shall contact you as soon as we have an opening for a {0}programmer.";

            SendGridMessage msg = new SendGridMessage()
            {
                From = new EmailAddress("tiago@meuspedidosdevtest.com", "MeusPedidos Dev Test"),
                Subject = "Thank you for applying"
            };

            msg.AddTo(new EmailAddress(pEmail));
            
            //Sends default e-mail if the applicant is not approved in any other position
            if (!pFrontEnd && !pBackEnd && !pMobile)
            {
                msg.PlainTextContent = string.Format(msgContent, string.Empty);

                await client.SendEmailAsync(msg).ConfigureAwait(false);
            }
            else
            {
                //Checks and sends front-end programmer e-mail
                if (pFrontEnd)
                {
                    msg.PlainTextContent = string.Format(msgContent, "Front-End ");
                    await client.SendEmailAsync(msg);
                }
                //Checks and sends back-end programmer e-mail
                if (pBackEnd)
                {
                    msg.PlainTextContent = string.Format(msgContent, "Back-End ");
                    await client.SendEmailAsync(msg);
                }
                //Checks and sends mobile programmer e-mail
                if (pMobile)
                {
                    msg.PlainTextContent = string.Format(msgContent, "Mobile ");
                    await client.SendEmailAsync(msg);
                }
            }
        }
        
        /// <summary>
        /// Checks if the score is between 7 and 10
        /// </summary>
        /// <param name="pScore">Score</param>
        /// <returns></returns>
        private static bool IsApprovedScore(int? pScore)
        {
            if (pScore >= 7 && pScore <= 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}