using System;
using System.Diagnostics.CodeAnalysis;

namespace SQLEConnectTests.Benchmarks.Models
{
    public class StructModel
    {
        public int Id { get; set; }
        
        public string Strp { get; set; }

        public string Chr { get; set; }

        public string Character { get; set; }

        public DateTime Date { get; set; }

        public DateTime NDate { get; set; }

        public string Strs { get; set; }

        public string Strw { get; set; }

        public decimal Dcml { get; set; }

        public long Lng { get; set; }
    }
}
