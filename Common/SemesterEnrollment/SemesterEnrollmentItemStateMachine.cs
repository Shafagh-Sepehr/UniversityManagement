using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemGroup.Framework.StateManagement.ProtoType;

namespace SystemGroup.General.UniversityManagement.Common
{
    public class SemesterEnrollmentItemStateMachine : StateMachine<SemesterEnrollmentItem, SemesterEnrollmentItemState>
    {
        protected override void InitializeStates()
        {
            //var active = new State(SemesterEnrollmentItemStatus.Active, "Active", "Labels_Active");
            //States.Add(active);
            //Transitions.Add(new ManualTransition(active, active, "Labels_Active"));
        }

        protected override void DoChangeState(SemesterEnrollmentItem record, SemesterEnrollmentItemState state, StateChangeContext context)
        {
            //record.State = state
        }

        protected override SemesterEnrollmentItemState GetCurrentStateCodeAsEnum(SemesterEnrollmentItem record)
        {
            throw new NotImplementedException();
            //return record.State;
        }
    }
}
