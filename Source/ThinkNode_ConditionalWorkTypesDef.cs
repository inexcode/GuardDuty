using System.Collections.Generic;
using Verse;
using Verse.AI;

namespace GuardDuty
{
    public class ThinkNode_ConditionalWorkTypesDef : ThinkNode_Conditional
    {
        private List<WorkTypeDef> workTypeDefs = new List<WorkTypeDef>();

        protected override bool Satisfied(Pawn pawn)
        {
            foreach (var _def in workTypeDefs)
            {
                if (pawn.IsColonist && (pawn?.workSettings?.WorkIsActive(_def) ?? false))
                    return true;
            }


            return false;
        }
    }
}