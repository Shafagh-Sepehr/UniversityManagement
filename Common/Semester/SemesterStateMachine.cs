using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemGroup.Framework.StateManagement.ProtoType;

namespace SystemGroup.General.UniversityManagement.Common
{
    public class SemesterStateMachine : StateMachine<Semester, SemesterState>
    {
        protected override void InitializeStates()
        {
            //var active = new State(SemesterStatus.Active, "Active", "Labels_Active");
            //States.Add(active);
            //Transitions.Add(new ManualTransition(active, active, "Labels_Active"));
        }

        protected override void DoChangeState(Semester record, SemesterState state, StateChangeContext context)
        {
            //record.State = state
        }

        protected override SemesterState GetCurrentStateCodeAsEnum(Semester record)
        {
            throw new NotImplementedException();
            //return record.State;
        }
    }
}
