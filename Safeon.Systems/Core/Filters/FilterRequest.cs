namespace Safeon.Systems.Core.Filters
{ 
    public class FilterRequest
    {
        public int Draw { get; set; }
        public int Start { get; set; }
        public int Length { get; set; }
        public SearchFilterRequest Search { get; set; }

        public bool? ExecuteCount { get; set; } = true;
    }
}