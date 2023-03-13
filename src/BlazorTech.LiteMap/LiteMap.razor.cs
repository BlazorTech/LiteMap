using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace BlazorTech.LiteMap;

public partial class LiteMap
{
    [Parameter] public string HoverColor { get; set; } = "#f5e72dd9";
    [Parameter] public required IEnumerable<LiteMapRegion> Regions { get; set; }

    [Parameter] public EventCallback<LiteMapRegion> OnHoverCallback { get; set; }

    LiteMapRegion? _hoveredRegion { get; set; }
    double _pageX { get; set; }
    double _pageY { get; set; }

    void MouseMove(MouseEventArgs e)
    {
        _pageX = e.PageX;
        _pageY = e.PageY + 30;
    }

    async Task MouseOverAsync(MouseEventArgs e, LiteMapRegion region)
    {
        region.IsHovered = true;
        _pageX = e.PageX;
        _pageY = e.PageY + 30;
        _hoveredRegion = region;
        await OnHoverCallback.InvokeAsync(region);
    }
    async Task MouseOutAsync(LiteMapRegion region)
    {
        region.IsHovered = false;
        _hoveredRegion = null;
        await OnHoverCallback.InvokeAsync(region);
    }
}
