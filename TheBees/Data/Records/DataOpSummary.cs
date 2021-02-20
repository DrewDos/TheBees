using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheBees.Records
{
    public class DataOpSummary
    {
        public int AffectedAmt;
        public SpaceGroupSummary BeforeProgramOp;
        public SpaceGroupSummary BeforeUserOp;
        public SpaceGroupSummary AfterProgramOp;
        public SpaceGroupSummary AfterUserOp;

        public DataOpSummary(int srcAffectedAmt, SpaceGroupSummary programBefore, SpaceGroupSummary programAfter, SpaceGroupSummary userBefore, SpaceGroupSummary userAfter)
        { 
            AffectedAmt = srcAffectedAmt;
            BeforeProgramOp = programBefore;
            BeforeUserOp = userBefore;
            AfterProgramOp = programAfter;
            AfterUserOp = userAfter;
        }

        public string GetFinalSummaryString()
        {
            string nl = Environment.NewLine;
            string summary = "";
            summary += "Before Data Removal: " + nl + nl;
            summary += GetGroupSummaryString(BeforeProgramOp)+nl;
            summary += GetGroupSummaryString(BeforeUserOp)+nl+nl;
            summary += "After Data Removal: " + nl + nl;
            summary += GetGroupSummaryString(AfterProgramOp) + nl;
            summary += GetGroupSummaryString(AfterUserOp) + nl + nl;

            return summary;
        }

        private string GetGroupSummaryString(SpaceGroupSummary groupSumary)
        {
            string nl = Environment.NewLine;
            string summary = "";

            summary += groupSumary.GroupName + ": " + nl;
            summary += "Free Space: " + groupSumary.FreeSpace.ToString() + nl;
            summary += "Largest Block Available: " + groupSumary.LargestBlockAvailable.ToString() + nl;

            return summary;

        }
    }
}
