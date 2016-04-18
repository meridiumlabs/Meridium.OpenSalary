using System.Collections.Generic;

namespace OpenSalary.Web.Core.Entities {
    public class JudgmentModel {
        public JudgmentModel() {
            CurrentStatus = JudgmentStatus.Initiated;
            Judgment = new Dictionary<JudgmentCategory, JudgmentLevel>();
        }
        public Dictionary<JudgmentCategory, JudgmentLevel> Judgment { get; set; }
        public string FreeMotivation { get; set; }      
        public JudgmentStatus CurrentStatus { get; set; }
    }  
}