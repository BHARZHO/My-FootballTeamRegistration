using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballTeamRegistration;

public class FootballRegistration : BaseClass
{
    public string Name { get; set; } = default!;
    public string ShirtNumber { get; set; } = default!;
    public string? Adress { get; set; }
    public FootballPosition FootballPosition { get; set; }
}
