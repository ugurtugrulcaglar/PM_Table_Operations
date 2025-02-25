
namespace PM_Table_Operations.Model
{
    public class CounterDefinition
    {
        public required string TableName { get; set; }
        public required string CounterName { get; set; }
        public required string Aggregation { get; set; }
        public required string Alias { get; set; }
        public required string CounterOSSName { get; set; }
        public required string CounterLongName { get; set; }
        public string? HwiFuncsetId { get; set; }
        public string? HwiMuId { get; set; }
    }
}
