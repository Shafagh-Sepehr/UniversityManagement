using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemGroup.Framework.StateManagement.ProtoType;

namespace SystemGroup.General.UniversityManagement.Common
{
    public class EnrollmentItemStateMachine : StateMachine<EnrollmentItem, EnrollmentItemGradeState>
    {
        protected override void InitializeStates()
        {
            var notEntered = new State(EnrollmentItemGradeState.NotEntered, "NotEntered", "EnrollmentItem_NotEntered");
            var entered = new State(EnrollmentItemGradeState.Entered, "Entered", "EnrollmentItem_NotEntered");
            var announced = new State(EnrollmentItemGradeState.Announced, "Announced", "EnrollmentItem_Announced");

            States.Add(notEntered);
            States.Add(entered);
            States.Add(announced);

            Transitions.Add(new Transition(notEntered, entered));
            Transitions.Add(new ManualTransition(entered, announced, "EnrollmentItem_Announce"));
        }

        protected override void DoChangeState(EnrollmentItem record, EnrollmentItemGradeState state, StateChangeContext context)
        {
            record.GradeState = state;
        }

        protected override EnrollmentItemGradeState GetCurrentStateCodeAsEnum(EnrollmentItem record)
        {
            return record.GradeState;
        }
    }
}
