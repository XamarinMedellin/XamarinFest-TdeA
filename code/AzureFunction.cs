using System.Net;
using System.Net.Mail;
public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
{ 
    // Get request body 
    dynamic data = await req.Content.ReadAsAsync<object>();
    string to =data?.Destinatario;
    string subject =data?.Asunto;
    string body =data?.Mensaje;
    
    var result=SendMail(to,subject,body);
    return !result
        ? req.CreateResponse(HttpStatusCode.BadRequest, false)
        : req.CreateResponse(HttpStatusCode.OK, true);
} 

public static  bool SendMail(string to, string subject, string body)
{ 
    try{
        MailMessage mailMsg = new MailMessage();
        mailMsg.To.Add(new MailAddress(to));
        mailMsg.From = new MailAddress("andreslon@outlook.com", "Xamarin Fest");
        mailMsg.Subject = subject;
        mailMsg.Body = body;
        SmtpClient smtpClient = new SmtpClient("smtp.sendgrid.net", 587);
        System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("azure_753dbaa66fc5b9c8fe56e32b428229a4@azure.com", "@xamarinfest1");
        smtpClient.Credentials = credentials;
        smtpClient.Send(mailMsg);
        return true;
    }
    catch(Exception ex){
        return false;
    }
}        