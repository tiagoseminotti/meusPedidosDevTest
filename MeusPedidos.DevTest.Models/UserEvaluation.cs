using System;
using System.ComponentModel.DataAnnotations;

namespace MeusPedidos.DevTest.Models
{
    /// <summary>
    /// User evaluation model
    /// </summary>
    public partial class UserEvaluation
    {
        /// <summary>
        /// Code
        /// </summary>
        [Key]
        public Guid CD_USEREVALUATION { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [Required(ErrorMessage = "Please enter your name")]
        [StringLength(200)]
        [Display(Name = "Name")]
        public string DS_NAME { get; set; }

        /// <summary>
        /// E-mail
        /// </summary>
        [Required(ErrorMessage = "Please enter an e-mail address")]
        [EmailAddress(ErrorMessage = "Invalid e-mail address")]
        [StringLength(300)]
        [Display(Name = "E-Mail")]
        public string DS_EMAIL { get; set; }

        /// <summary>
        /// HTML
        /// </summary>
        [Display(Name = "HTML")]
        [Range(0,10, ErrorMessage = "HTML evaluation value should be between 0 and 10")]
        public int? NR_EVAL_HTML { get; set; }

        /// <summary>
        /// CSS
        /// </summary>
        [Display(Name = "CSS")]
        [Range(0, 10, ErrorMessage = "CSS evaluation value should be between 0 and 10")]
        public int? NR_EVAL_CSS { get; set; }

        /// <summary>
        /// Javascript
        /// </summary>
        [Display(Name = "Javascript")]
        [Range(0, 10, ErrorMessage = "Javascript evaluation value should be between 0 and 10")]
        public int? NR_EVAL_JAVASCRIPT { get; set; }

        /// <summary>
        /// Python
        /// </summary>
        [Display(Name = "Python")]
        [Range(0, 10, ErrorMessage = "Python evaluation value should be between 0 and 10")]
        public int? NR_EVAL_PYTHON { get; set; }

        /// <summary>
        /// Django
        /// </summary>
        [Display(Name = "Django")]
        [Range(0, 10, ErrorMessage = "Django evaluation value should be between 0 and 10")]
        public int? NR_EVAL_DJANGO { get; set; }

        /// <summary>
        /// Dev. iOS
        /// </summary>
        [Display(Name = "Dev. iOS")]
        [Range(0, 10, ErrorMessage = "iOS evaluation value should be between 0 and 10")]
        public int? NR_EVAL_IOS { get; set; }

        /// <summary>
        /// Dev. Android
        /// </summary>
        [Display(Name = "Dev. Android")]
        [Range(0, 10, ErrorMessage = "Android evaluation value should be between 0 and 10")]
        public int? NR_EVAL_ANDROID { get; set; }
    }
}
