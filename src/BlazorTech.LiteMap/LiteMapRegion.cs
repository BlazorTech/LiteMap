namespace BlazorTech.LiteMap
{
    public class LiteMapRegion
    {
        public required string Title { get; set; }
        public required string Path { get; set; }

        public string BackgroundColor { get; set; } = "#00000000";
        
        internal bool IsHovered { get; set; } = false;
    }
}
