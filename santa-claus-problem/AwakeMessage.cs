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
            this.Group = Group;
        }
    }

    public class ElveAwakeMessage : AwakeMessage
    {
        internal IList<Elve> Group { get; set; }

        internal ElveAwakeMessage(IList<Elve> Group)
        {
            this.Group = Group;
        }
    }
}