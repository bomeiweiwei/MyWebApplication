using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace AllShowMVCApplication.Models
{
    [MetadataType(typeof(MessageMD))]
    public partial class Message
    {
        public class MessageMD //:IValidatableObject
        {
            [ScaffoldColumn(false)]
            public int Id { get; set; }
            [Required]
            [Display(Name = "標題")]
            [StringLength(50)]
            public string Subject { get; set; }
            [Required]
            [Display(Name = "內容")]
            public string Content { get; set; }
            [Required]
            [Display(Name = "發文日期")]
            public Nullable<System.DateTime> PostDateTime { get; set; }
            [Required]
            [Display(Name = "作者")]
            [StringLength(10,
                ErrorMessage = "{0}的長度需介於{2}到{1}",
                MinimumLength = 4)]
            public string author { get; set; }
            [Required]
            [Display(Name = "次數")]
            [CustomValidation(typeof(IntegerValidator), "Invalid")]
            public Nullable<int> times { get; set; }
            [Required]
            [Display(Name = "電子郵件")]
            [DataType(DataType.EmailAddress)]
            public string e_mail { get; set; }

            //public IEnumerable<ValidationResult> Validate(ValidationContext valContext)
            //{
            //    if (times < 1)
            //        yield return new ValidationResult("需大於0", new[] { "times" });
            //}
        }
    }

    public class IntegerValidator
    {
        public static ValidationResult Invalid(int times, ValidationContext valContext)
        {
            return times > 0 ? ValidationResult.Success : new ValidationResult("需大於0");
        }
    }
}