using Microsoft.AspNetCore.Components;

namespace BlazorTech.LiteMap;

public partial class LiteMap
{
    [Parameter] public string? DefaultColor { get; set; }
    [Parameter] public required IEnumerable<LiteMapRegion> Regions { get; set; }
}
