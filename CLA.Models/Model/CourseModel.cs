using System;
using System.Collections.Generic;
using System.Text;

namespace CLA.Models.Model
{
    public class CourseModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string CourseGroupId { get; set; }
        public int NumberStudent { get; set; }
        public decimal CourseFee { get; set; }
        public string Description { get; set; }
        public string Room { get; set; }
        public string TeacherId { get; set; }
        public int TotalSession { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Thumbnail { get; set; }
        public short Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
