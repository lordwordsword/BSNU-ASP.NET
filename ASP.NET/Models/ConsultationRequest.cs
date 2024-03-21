using System.ComponentModel.DataAnnotations;

public class ConsultationRequest
{
    [Required(ErrorMessage = "Поле Ім'я прізвище є обов'язковим")]
    public string FullName { get; set; }

    [Required(ErrorMessage = "Поле Email є обов'язковим")]
    [EmailAddress(ErrorMessage = "Введіть коректний Email")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Поле Бажана дата консультації є обов'язковим")]
    [FutureDate(ErrorMessage = "Дата має бути у майбутньому")]
    [NotOnWeekend(ErrorMessage = "Консультація не може проходити вихідними")]
    [NotOnMondayIfBasics(ErrorMessage = "Консультація з основ програмування не може бути у понеділок")]
    public DateTime ConsultationDate { get; set; }

    [Required(ErrorMessage = "Поле Продукт є обов'язковим")]
    public string Type { get; set; }
}