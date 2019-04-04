using System;
using System.Collections.Generic;

namespace santa_claus_problem
{
    class Sleigh
    {
        public IList<Reindeer> Reindeers { get; private set; } = new List<Reindeer>();

        public void Tie(Reindeer reindeer)
        {
            Reindeers.Add(reindeer);
            reindeer.Sleigh = this;
        }

        public void UntieAll()
        {
            foreach (var reindeer in Reindeers)
            {
                reindeer.Sleigh = null;
            }

            Reindeers = new List<Reindeer>();
        }
    }
}
