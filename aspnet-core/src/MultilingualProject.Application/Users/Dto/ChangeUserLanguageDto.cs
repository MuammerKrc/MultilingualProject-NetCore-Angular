using System.ComponentModel.DataAnnotations;

namespace MultilingualProject.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}