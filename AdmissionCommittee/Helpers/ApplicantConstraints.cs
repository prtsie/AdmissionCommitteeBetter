﻿namespace AdmissionCommittee.Helpers
{
    /// <summary>Ограничения полей для <see cref="Models.Applicant"/></summary>
    static internal class ApplicantConstraints
    {
        public const int MaxLength = 50;
        public const int MinAge = 18;
        public const int MaxAge = 21;
    }
}
