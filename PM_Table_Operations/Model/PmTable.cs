
namespace PM_Table_Operations.Model
{
    public class PmTable
    {
        public required string TableName { get; set; }
        public ObjectType ObjectType { get; set; }
        public required string PK { get; set; }
        public required string Counters { get; set; }
    }
}
