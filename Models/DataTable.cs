using System;
using System.Collections.Generic;

namespace Calender_TestCase.Models
{
    public partial class DataTable
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public string? MeetingDetails { get; set; }
    }
}
