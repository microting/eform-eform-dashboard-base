using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormDashboardBase.Infrastructure.Data.Entities
{
    public class DashboardItemIgnoredFieldValueVersion : BaseEntity
    {
        public int FieldOptionId { get; set; }
        public string FieldValue { get; set; }
        public int DashboardItemId { get; set; }
        public int DashboardItemIgnoredFieldValueId { get; set; }
    }
}