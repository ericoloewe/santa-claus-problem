using System;
using System.Collections.Generic;

namespace santa_claus_problem
{
    class SantaClausHouse
    {
        public SantaClaus Santa { get; private set; }
        public Sleigh Sleigh { get; private set; }
        private IList<Reindeer> ReindeerGroup { get; set; } = new List<Reindeer>();
        private IList<Elve> ElveGroup { get; set; } = new List<Elve>();

        public SantaClausHouse(SantaClaus santa, Sleigh sleigh)
        {
            Santa = santa;
            Sleigh = sleigh;
        }

        internal void Meet(Reindeer reindeer)
        {
            ReindeerGroup.Add(reindeer);

            lock (ReindeerGroup)
            {
                if (ReindeerGroup.Count == 9)
                {
                    var awakeMessage = new ReindeerAwakeMessage(ReindeerGroup);

                    ReindeerGroup = new List<Reindeer>();
                    NorthPole.Events.OnReindeersAwakeSanta(awakeMessage);
                    Santa.Awake(awakeMessage);
                }
            }
        }

        internal void Meet(Elve elve)
        {
            ElveGroup.Add(elve);

            lock (ElveGroup)
            {
                if (ElveGroup.Count == 3)
                {
                    var awakeMessage = new ElveAwakeMessage(ElveGroup);

                    ElveGroup = new List<Elve>();
                    NorthPole.Events.OnElvesAwakeSanta(awakeMessage);
                    Santa.Awake(awakeMessage);
                }
            }
        }
    }
}