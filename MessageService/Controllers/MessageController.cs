
using DataService;
using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace MessageService.Controllers
{
    public class MessageController : ApiController
    {

        [HttpPost]
        public IHttpActionResult Post(MessageInput messageInput)
        {
            try
            {
                var url = ConfigurationManager.AppSettings["MessageRepositoryType"];
                MessageRepositoryType messageRepositoryType; 
                 
                if (!Enum.TryParse(url,out messageRepositoryType))
                {
                    return InternalServerError();
                }
                var myWriter = new StringWriter();
                HttpUtility.HtmlDecode(messageInput.input, myWriter);
                messageInput.input = myWriter.ToString();
                
                var task = new MessageHander().InsertMessage(messageInput, messageRepositoryType);

                if (task.Result == 0)
                    return Ok();
                else
                {
                    //TODO log exception
                    return BadRequest("Input is invalid");
                }
            }
            catch (System.Exception ex)
            {
                //TODO log exception
                return InternalServerError();
            }
        }

    }
}
