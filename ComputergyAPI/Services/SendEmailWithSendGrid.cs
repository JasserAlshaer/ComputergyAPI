using SendGrid;
using SendGrid.Helpers.Mail;

namespace ComputergyAPI.Services
{
   
        public class SendEmailWithSendGrid
        {
            private readonly SendGridClient _sendGridClient;
            private readonly IConfiguration _configuration;
            private readonly ILogger<SendEmailWithSendGrid> _logger;

            public SendEmailWithSendGrid(


                SendGridClient sendGridClient,
                IConfiguration configuration,
                ILogger<SendEmailWithSendGrid> logger)
            {
                _sendGridClient = sendGridClient;
                _configuration = configuration;
                _logger = logger;
            }

            public async Task SendEmailAsync(string toEmail, string toName, string subject, string plainText, string htmlContent)
            {
                var fromEmail = _configuration["EmailSettings:FromEmail"];
                var fromName = _configuration["EmailSettings:FromName"];
                var from = new EmailAddress(fromEmail, fromName);
                var to = new EmailAddress(toEmail, toName);

                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainText, htmlContent);
                var response = await _sendGridClient.SendEmailAsync(msg);

                if (response.StatusCode != System.Net.HttpStatusCode.Accepted)
                {
                    var responseBody = await response.Body.ReadAsStringAsync();
                    _logger.LogError($"Email send failed: {response.StatusCode}, {responseBody}");
                    throw new Exception($"Email send failed: {response.StatusCode}, {responseBody}");
                }

                _logger.LogInformation($"Email sent successfully to {toEmail} with subject '{subject}'");
            }
        }
    }
