using System;
using System.Collections.Generic;

namespace santa_claus_problem
{
    interface AwakeMessage
    {
    }

    public class ReindeerAwakeMessage : AwakeMessage
    {
        internal IList<Reindeer> Group { get; private set; }

        internal ReindeerAwakeMessage(IList<Reindeer> Group)
        {
            if (Group.Count < 9)
            {
                throw new ArgumentException("Santa just awake with at least 9 reinders!");
            }

            this.Group = Group;
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
    }
}