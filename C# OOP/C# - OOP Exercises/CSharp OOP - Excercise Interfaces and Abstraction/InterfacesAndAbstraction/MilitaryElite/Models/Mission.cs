using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Mission : IMisson
    {
        public Mission(string codeName, string state)
        {
            this.CodeName = codeName;
            this.State = TryParseState(state);
        }

        private State TryParseState(string state)
        {
            bool passed = Enum.TryParse<State>(state, false, out State result);

            if (!passed)
            {
                throw new InvalidStateException();
            }
            return result;
        }

        public string CodeName { get; private set; }

        public State State { get; private set; }

        public void CompleteMission()
        {
            if (this.State == State.Finished)
            {
                throw new InvalidMissionCompletionException();
            }
            this.State = State.Finished;
        }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State}";
        }
    }
}
