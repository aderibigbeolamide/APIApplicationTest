namespace APIApplication.DTOs.RequestModel
{
    public class CreateAppProgramRequestModel
    {
        public string ProgramTitle { get; set; }
        public string SummaryOfTheProgram { get; set; }
        public string ProgramDescription { get; set; }
        public string KeySkillsRequiredForTheProgram { get; set; }
        public string ProgramBenefits { get; set; }
        public string ApplicationCriteria { get; set; }
        public string ProgramType { get; set; }
        public DateTime ProgramStart { get; set; }
        public DateTime ApplicationOpen { get; set; }
        public DateTime ApplicationClose { get; set; }
        public string Duration { get; set; }
        public string ProgramLocation { get; set; }
        public string MinQualification { get; set; }
        public int MaxNumberOfApplication { get; set; }
    }

    public class UpdateAppProgramRequestModel
    {
        public string ProgramTitle { get; set; }
        public string SummaryOfTheProgram { get; set; }
        public string ProgramDescription { get; set; }
        public string KeySkillsRequiredForTheProgram { get; set; }
        public string ProgramBenefits { get; set; }
        public string ApplicationCriteria { get; set; }
        public string ProgramType { get; set; }
        public DateTime ProgramStart { get; set; }
        public DateTime ApplicationOpen { get; set; }
        public DateTime ApplicationClose { get; set; }
        public string Duration { get; set; }
        public string ProgramLocation { get; set; }
        public string MinQualification { get; set; }
        public int MaxNumberOfApplication { get; set; }
    }
}