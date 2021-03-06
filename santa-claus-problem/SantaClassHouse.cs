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
            lock (ReindeerGroup)
            {
                ReindeerGroup.Add(reindeer);

                if (ReindeerGroup.Count == 9)
                {
                    var awakeMessage = new ReindeerAwakeMessage(ReindeerGroup.ToList());

                    foreach (var reindeerToRemove in awakeMessage.Group)
                    {
                        ReindeerGroup.Remove(reindeerToRemove);
                    }

                    Santa.Awake(awakeMessage);
                }
            }
        }

        internal void Meet(Elve elve)
        {
            lock (ElveGroup)
            {
                ElveGroup.Add(elve);

                lock (ReindeerGroup)
                {
                    if (ElveGroup.Count >= 3 && ReindeerGroup.Count < 9)
                    {
                        var awakeMessage = new ElveAwakeMessage(ElveGroup.Take(3).ToList());

                        foreach (var elveToRemove in awakeMessage.Group)
                        {
                            ElveGroup.Remove(elveToRemove);
                        }

                        Santa.Awake(awakeMessage);
                    }
                }
            }
        }
    }
}