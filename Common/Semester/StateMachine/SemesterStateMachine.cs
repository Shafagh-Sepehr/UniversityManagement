using SystemGroup.Framework.StateManagement.ProtoType;

namespace SystemGroup.General.UniversityManagement.Common
{
    public class SemesterStateMachine : StateMachine<Semester, SemesterState>
    {
        protected override void InitializeStates()
        {
            var registered = new State(SemesterState.Registered, "Semester_Registered");
            var enrollmentPhase = new State(SemesterState.EnrollmentPhase, "Semester_EnrollmentPhase");
            var active = new State(SemesterState.Active, "Semester_Active");
            var finished = new State(SemesterState.Finished, "Semester_Finished");

            States.Add(registered);
            States.Add(enrollmentPhase);
            States.Add(active);
            States.Add(finished);

            Transitions.Add(new ManualTransition(registered, enrollmentPhase, "Semester_ActivateEnrollmentPhase",true));
            Transitions.Add(new ManualTransition(enrollmentPhase, active, "Semester_EndEnrollmentPhase",true));
            Transitions.Add(new ManualTransition(active, finished, "Semester_EndSemester",true));
        }

        protected override void DoChangeState(Semester record, SemesterState state, StateChangeContext context)
        {
            record.State = state;
        }

        protected override SemesterState GetCurrentStateCodeAsEnum(Semester record)
        {
            return record.State;
        }
    }
}
