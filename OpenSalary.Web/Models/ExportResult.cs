using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenSalary.Web.Models {
    public class ExportResult {
        [Meridium.ExcelExport.ExcelCell(Heading="Namn", Column = 0)]
        public string Name { get; set; }
        [Meridium.ExcelExport.ExcelCell(Heading = "Kunskap", Column = 1)]
        public string Knowledge { get; set; }
        [Meridium.ExcelExport.ExcelCell(Heading = "Företagskultur", Column = 2)]
        public string Culture { get; set; }
        [Meridium.ExcelExport.ExcelCell(Heading = "Coachning", Column = 3)]
        public string Coaching { get; set; }
        [Meridium.ExcelExport.ExcelCell(Heading = "Engagemang", Column = 4)]
        public string Commitment { get; set; }
        [Meridium.ExcelExport.ExcelCell(Heading = "Kundförståelse", Column = 5)]
        public string CustomerValue { get; set; }
        [Meridium.ExcelExport.ExcelCell(Heading = "Motivering", Column = 6)]
        public string FreeMotivation { get; set; }
    }
}