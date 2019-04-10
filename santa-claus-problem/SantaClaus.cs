using System;
using System.Collections.Generic;
using System.Threading;

namespace santa_claus_problem
{
    class SantaClaus
    {
        public bool IsSleeping { get; private set; } = true;
        private static Random random = new Random();

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
            Thread.Sleep(NorthPole.MINIMAL_TIME_TO_WAIT * random.Next(0, 11));

            foreach (var elve in group)
            {
                elve.OnFinishToDiscussToyProject();
            }
        }

        private void GiveToys()
        {
            NorthPole.Events.OnSantaGiveToys();
            Thread.Sleep(NorthPole.MINIMAL_TIME_TO_WAIT * random.Next(0, 11));
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
            NorthPole.Events.OnSantaUntieReindeerGroup();
            NorthPole.SantaClausHouse.Sleigh.UntieAll();
        }
    }
}
