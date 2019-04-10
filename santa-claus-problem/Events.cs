using System;
using System.Collections.Generic;

namespace santa_claus_problem
{
    public class NorthPoleEvents
    {
        public Action OnSantaClausAwake { internal get; set; } = () => { };
        public Action OnSantaClausSleep { internal get; set; } = () => { };
        public Action OnSantaDiscussToyProjects { internal get; set; } = () => { };
        public Action OnSantaGiveToys { internal get; set; } = () => { };
        public Action OnSantaTieReindeerGroup { internal get; set; } = () => { };
        public Action OnSantaUntieReindeerGroup { internal get; set; } = () => { };
        public Action<ElveAwakeMessage> OnElvesAwakeSanta { internal get; set; } = i => { };
        public Action<int> OnCreateElve { internal get; set; } = i => { };
        public Action<int> OnCreateReindeer { internal get; set; } = i => { };
        public Action<int> OnElveBuildToys { internal get; set; } = i => { };
        public Action<int> OnElveMeetSantaHouse { internal get; set; } = i => { };
        public Action<int> OnReindeerGoToVacation { internal get; set; } = i => { };
        public Action<int> OnReindeerMeetSantaHouse { internal get; set; } = i => { };
        public Action<ReindeerAwakeMessage> OnReindeersAwakeSanta { internal get; set; } = i => { };
    }
}