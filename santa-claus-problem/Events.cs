using System;
using System.Collections.Generic;

namespace santa_claus_problem
{
    public class NorthPoleEvents
    {
        public Action OnSantaClausSleep { get; set; } = () => { };
        public Action OnSantaClausAwake { get; set; } = () => { };
        public Action OnSantaDiscussToyProjects { get; set; } = () => { };
        public Action OnSantaGiveToys { get; set; } = () => { };
        public Action OnSantaTieReindeerGroup { get; set; } = () => { };
        public Action OnSantaUntieReindeerGroup { get; set; } = () => { };
        public Action<int> OnCreateElve { get; set; } = i => { };
        public Action<int> OnElveMeetSanta { get; set; } = i => { };
        public Action<int> OnElveBuildToys { get; set; } = i => { };
        public Action<int> OnReindeerGoToVacation { get; set; } = i => { };
        public Action<int> OnCreateReindeer { get; set; } = i => { };
        public Action<int> OnReindeerMeetSanta { get; set; } = i => { };
        public Action<ReindeerAwakeMessage> OnReindeersAwakeSanta { get; set; } = i => { };
        public Action<ElveAwakeMessage> OnElvesAwakeSanta { get; set; } = i => { };
    }
}