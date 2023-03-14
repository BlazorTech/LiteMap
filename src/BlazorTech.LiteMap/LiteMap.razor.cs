using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace BlazorTech.LiteMap;

public partial class LiteMap
{
    [Parameter] public string HoverColor { get; set; } = "#f5e72dd9";
    [Parameter] public required string ViewBox { get; set; }
    [Parameter] public required IEnumerable<LiteMapRegion> Regions { get; set; }

    [Parameter] public EventCallback<LiteMapRegion> OnHoverCallback { get; set; }

    [Parameter] public double PopupOffsetX { get; set; } = 30;
    [Parameter] public double PopupOffsetY { get; set; } = 30;

    LiteMapRegion? _hoveredRegion { get; set; }

    void MouseMove(MouseEventArgs e)
    {
        LiteMapCascadingValue.PositionX = e.PageX + PopupOffsetX;
        LiteMapCascadingValue.PositionY = e.PageY + PopupOffsetY;
        LiteMapCascadingValue.UpdateUI();
    }

    async Task MouseOverAsync(MouseEventArgs e, LiteMapRegion region)
    {
        region.IsHovered = true;
        _hoveredRegion = region;

        LiteMapCascadingValue.PositionX = e.PageX + PopupOffsetX;
        LiteMapCascadingValue.PositionY = e.PageY + PopupOffsetY;
        LiteMapCascadingValue.RenderFragment = PopupTemplate(_hoveredRegion);
        LiteMapCascadingValue.UpdateUI();
        
        await OnHoverCallback.InvokeAsync(region);
    }
    async Task MouseOutAsync(LiteMapRegion region)
    {
        region.IsHovered = false;
        _hoveredRegion = null;

        LiteMapCascadingValue.RenderFragment = null;
        LiteMapCascadingValue.UpdateUI();
        
        await OnHoverCallback.InvokeAsync(region);
    }
}
