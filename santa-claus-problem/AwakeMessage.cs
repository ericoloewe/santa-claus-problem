using System;
using System.Collections.Generic;
using System.Linq;

namespace santa_claus_problem
{
    interface AwakeMessage
    {
        void OnAwake();
    }

    public class ReindeerAwakeMessage : AwakeMessage
    {
        internal IList<Reindeer> Group { get; private set; }

        public void OnAwake()
        {
            NorthPole.Events.OnReindeersAwakeSanta(this);
        }

        internal ReindeerAwakeMessage(IList<Reindeer> Group)
        {
            if (Group.Count < 9)
            {
                throw new ArgumentException("Santa just awake with at least 9 reinders!");
            }

            this.Group = Group;
        }

        public override string ToString()
        {
            return $"[{string.Join(",", Group.Select(e => e.Index).ToArray())}]";
        }
    }

    public class ElveAwakeMessage : AwakeMessage
    {
        internal IList<Elve> Group { get; set; }

        internal ElveAwakeMessage(IList<Elve> Group)
        {
            if (Group.Count < 3)
            {
                throw new ArgumentException("Santa just awake with at least 3 elves!");
            }

            this.Group = Group;
        }

        public void OnAwake()
        {
            NorthPole.Events.OnElvesAwakeSanta(this);
        }

        public override string ToString()
        {
            return $"[{string.Join(",", Group.Select(e => e.Index).ToArray())}]";
        }
    }
}