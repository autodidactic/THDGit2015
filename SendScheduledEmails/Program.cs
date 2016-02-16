using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using SendScheduledEmails.Model;
using SendScheduledEmails.EmailDAL;
using Quote_Email;
using Quote_Detail;
using HdmsCommonLogger;


namespace SendScheduledEmails
{
    public class Program
    {

        #region Setup 
       // private static readonly IHdmsLogger logger;
        #endregion
       // private static string SuccessResponseText = "Email send out successfully";
        //private static string FailureResponseText = "Failed to send email out";
        private static DataModel dbmodel = new DataModel();
        static void Main(string[] args)
        {
            string dateTimeString = DateTime.Now.ToString();
            HdmsLogger logger = new HdmsLogger();
            
            //add scheduling information( or make it a windows service)
            try
            {  
                logger.Log.Info("Scheduled Email job :: Initializing");
                SendEmail();
                logger.Log.Info("Scheduled Email job :: Done");
            }
            catch (Exception ex1)
            {
                logger.Log.ErrorFormat("Processing Email service running at {0} failed.{1}", dateTimeString, ex1.Message);
            }
        
        }

        public static void SendEmail()
        {
            string dateTimeString = DateTime.Now.ToString();
      
            
            HdmsLogger logger = new HdmsLogger();
            
            Quote_Email.Controllers.EmailController controller = new Quote_Email.Controllers.EmailController();
            logger.Log.InfoFormat("Scheduled Closer Email Job :: Started new schedular cycle {0}", dateTimeString);
            List<SendScheduledEmails.EmailDAL.EMAILQUEUE> emailstoSend = null;
            try
            {
                //Get list of all emails to be sent
                emailstoSend = dbmodel.getEmailqueue.Where(x => x.RESPONSECODE == 0).ToList();
            }

            catch (Exception ex2)
            {
                logger.Log.ErrorFormat("Scheduled Closer Email Job ::Connecting to the database at {0} failed {1}", dateTimeString, ex2.Message);
            }

            if (emailstoSend.Count > 0)
            {
                foreach (var i in emailstoSend)
                {
                    controller.GenerateToken(i.QUOTEID);
                    EmailDAL.EMAILQUEUE messageId = dbmodel.getEmailqueue.Find(i.MESSAGEID);
                    logger.Log.ErrorFormat("Scheduled Closer Email Job ::Found Emails to send" );
                    try
                    {
                        controller.Email(i.QUOTEID.ToString(), i.EMAILTO,"#");
                        logger.Log.ErrorFormat("Scheduled Closer Email Job :: Sending Email at {0} Succeeded.", dateTimeString);
                    }

                    catch (Exception ex2)
                    {
                        logger.Log.ErrorFormat("Scheduled Closer Email Job :: Sending Email at {0} failed {1}", dateTimeString, ex2.Message);
                        messageId.RESPONSETEXT = "";
                    }
       

                    messageId.RESPONSECODE = 1;
                    messageId.RESPONSETEXT = "";
                    dbmodel.SaveChanges();
                }
            }
            else
            {
                logger.Log.InfoFormat("Processing Closer Email service:: No emails to send at  {0}", dateTimeString);
            }
              
        }

        //public static void SendEmail(string quoteId, string emailAddress)
        //{
        //    HDMSEmail.HDMSSMTPEmail smtp = new HDMSEmail.HDMSSMTPEmail("mail2.homedepot.com");
        //    string body = Render.get("QuoteEmail", EmailsVewData, ViewEngineCollection, ControllerContext);
        //    int rtnValue = 0;
     
        //     if (!smtp.SendEmailMessage("", "Your Quote", "hdms_noreply@homedepot.com", emailAddress))
        //    {
                
        //    }
        //    else
        //    {
                
        //    } 

        //}
    }
}
