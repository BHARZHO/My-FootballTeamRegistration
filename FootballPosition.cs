using System.ComponentModel;

namespace FootballTeamRegistration
{
    public enum FootballPosition
    {
        [Description("Goal Keeper")]
        GoalKeeper = 1,

        [Description("Defender")]
        Defender,

        [Description("Mid Feilder")]
        MidFeilder,

        [Description("Striker")]
        Striker
    }
}