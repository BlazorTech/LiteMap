using Microsoft.AspNetCore.Components;

namespace BlazorTech.LiteMap;

internal class LiteMapCascadingValue
{
    public RenderFragment? RenderFragment { get; set; }

    public required Action UpdateUI { get; init; }
    public double PositionX { get; set; }
    public double PositionY { get; set; }
}
