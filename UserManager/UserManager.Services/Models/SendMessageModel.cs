using System.ComponentModel.DataAnnotations;

namespace UserManager.Services.Models
{
    public class SendMessageModel
    {
        [Required(ErrorMessage = "Email not specified")]
        [EmailAddress(ErrorMessage = "Incorrect email")]
        public string SenderEmail { get; set; }
        [Required(ErrorMessage = "Email not specified")]
        [EmailAddress(ErrorMessage = "Incorrect email")]
        public string RecipientEmail { get; set; }
        [Required(ErrorMessage = "Topic not specified")]
        public string MessageTopic { get; set; }
        [Required(ErrorMessage = "Text not specified")]
        public string MessageText { get; set; }
    }
}
