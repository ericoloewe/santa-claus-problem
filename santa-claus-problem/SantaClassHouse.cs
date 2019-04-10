using System.Collections.Generic;
using System.Linq;

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
                    var awakeMessage = new ReindeerAwakeMessage(ReindeerGroup.ToList());

                    foreach (var reindeerToRemove in awakeMessage.Group)
                    {
                        ReindeerGroup.Remove(reindeerToRemove);
                    }

                    NorthPole.Events.OnReindeersAwakeSanta(awakeMessage);
                    Santa.Awake(awakeMessage);
                }
            }
        }

        internal void Meet(Elve elve)
        {
            lock (ElveGroup)
            {
                ElveGroup.Add(elve);

                if (ElveGroup.Count == 3)
                {
                    var awakeMessage = new ElveAwakeMessage(ElveGroup.ToList());

                    foreach (var elveToRemove in awakeMessage.Group)
                    {
                        ElveGroup.Remove(elveToRemove);
                    }

                    NorthPole.Events.OnElvesAwakeSanta(awakeMessage);
                    Santa.Awake(awakeMessage);
                }
            }
        }
    }
}