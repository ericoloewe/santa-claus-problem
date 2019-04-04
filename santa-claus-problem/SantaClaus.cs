using System;
using System.Collections.Generic;
using System.Threading;

namespace santa_claus_problem
{
    class SantaClaus
    {
        public bool IsSleeping { get; private set; } = true;
        private static Random random = new Random(10);

        private void Sleep()
        {
            NorthPole.Events.OnSantaClausSleep();
        }

        internal void Awake(AwakeMessage awakeMessage)
        {
            NorthPole.Events.OnSantaClausAwake();

            if (awakeMessage is ReindeerAwakeMessage)
            {
                var reindeerAwakeMessage = (ReindeerAwakeMessage)awakeMessage;

                TieReindeerGroup(reindeerAwakeMessage.Group);
                GiveToys();
                UntieReindeerGroup(reindeerAwakeMessage.Group);
            }
            else if (awakeMessage is ElveAwakeMessage)
            {
                DiscussToyProjects(((ElveAwakeMessage)awakeMessage).Group);
            }

            Sleep();
        }

        private void DiscussToyProjects(IList<Elve> group)
        {
            NorthPole.Events.OnSantaDiscussToyProjects();
            Thread.Sleep(NorthPole.MINIMAL_TIME_TO_WAIT * random.Next());

            foreach (var elve in group)
            {
                elve.RestartLifeCycle();
            }
        }

        private void GiveToys()
        {
            NorthPole.Events.OnSantaGiveToys();
            Thread.Sleep(NorthPole.MINIMAL_TIME_TO_WAIT * random.Next());
        }

        private void TieReindeerGroup(IList<Reindeer> group)
        {
            NorthPole.Events.OnSantaTieReindeerGroup();
            foreach (var reindeer in group)
            {
                NorthPole.SantaClausHouse.Sleigh.Tie(reindeer);
            }
        }

        private void UntieReindeerGroup(IList<Reindeer> group)
        {
            NorthPole.Events.OnSantaTieReindeerGroup();
            NorthPole.SantaClausHouse.Sleigh.UntieAll();
        }
    }
}
