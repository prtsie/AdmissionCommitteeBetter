﻿using System.ComponentModel.DataAnnotations;

namespace AdmissionCommittee.Models
{
    /// <summary>Формы обучения для <see cref="Applicant"/></summary>
    public enum FormOfEducation
    {
        [Display(Name = "Очная")]
        Intramural,
        [Display(Name = "Заочная")]
        Extramural,
        [Display(Name = "Очно-заочная")]
        PartTime
    }
}
