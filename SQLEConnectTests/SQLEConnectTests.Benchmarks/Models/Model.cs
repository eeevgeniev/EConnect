using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace SQLEConnectTests.Benchmarks.Models
{
    public class Model : IEquatable<Model>, IEquatable<Dictionary<string, object>>, IEquatable<StructModel>
    {
        public int Id { get; set; }
        
        public string Strp { get; set; }

        public string Chr { get; set; }

        [JsonProperty(PropertyName = "char")]
        public string Character { get; set; }

        public DateTime Date { get; set; }

        public DateTime NDate { get; set; }

        public string Strs { get; set; }

        public string Strw { get; set; }

        public decimal Dcml { get; set; }

        public long Lng { get; set; }

        public bool Equals([AllowNull] Model other)
        {
            if (other == null)
            {
                return false;
            }

            return this.Id == other.Id &&
                string.Equals(this.Strp, other.Strp, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(this.Chr, other.Chr, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(this.Character, other.Character, StringComparison.OrdinalIgnoreCase) &&
                this.Date.Equals(other.Date) &&
                this.NDate.Equals(other.NDate) &&
                string.Equals(this.Strs, other.Strs, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(this.Strw, other.Strw, StringComparison.OrdinalIgnoreCase) &&
                this.Dcml == other.Dcml &&
                this.Lng == other.Lng;
        }

        public bool Equals([AllowNull] Dictionary<string, object> other)
        {
            if (other == null)
            {
                return false;
            }

            object value;
            
            if (!(other.TryGetValue(nameof(this.Id), out value) || other.TryGetValue(nameof(this.Id).ToLower(), out value)) || !(value is int idValue ))
            {
                return false;
            }

            if (!(other.TryGetValue(nameof(this.Strp), out value) || other.TryGetValue(nameof(this.Strp).ToLower(), out value)) || !(value is string strpValue))
            {
                return false;
            }

            if (!(other.TryGetValue(nameof(this.Chr), out value) || other.TryGetValue(nameof(this.Chr).ToLower(), out value)) || !(value is string chrValue))
            {
                return false;
            }

            if (!(other.TryGetValue(nameof(this.Character), out value) || other.TryGetValue(nameof(this.Character).ToLower(), out value)) || !(value is string charValue))
            {
                return false;
            }

            if (!(other.TryGetValue(nameof(this.Date), out value) || other.TryGetValue(nameof(this.Date).ToLower(), out value)) || !(value is DateTime dateValue))
            {
                return false;
            }

            if (!(other.TryGetValue(nameof(this.NDate), out value) || other.TryGetValue(nameof(this.NDate).ToLower(), out value)) || !(value is DateTime nDateValue))
            {
                return false;
            }

            if (!(other.TryGetValue(nameof(this.Strs), out value) || other.TryGetValue(nameof(this.Strs).ToLower(), out value)) || !(value is string strsValue))
            {
                return false;
            }

            if (!(other.TryGetValue(nameof(this.Strw), out value) || other.TryGetValue(nameof(this.Strw).ToLower(), out value)) || !(value is string strwValue))
            {
                return false;
            }

            if (!(other.TryGetValue(nameof(this.Dcml), out value) || other.TryGetValue(nameof(this.Dcml).ToLower(), out value)) || !(value is decimal dcmlValue))
            {
                return false;
            }

            if (!(other.TryGetValue(nameof(this.Lng), out value) || other.TryGetValue(nameof(this.Lng).ToLower(), out value)) || !(value is long lngValue))
            {
                return false;
            }

            return this.Id == idValue &&
                string.Equals(this.Strp, strpValue, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(this.Chr, chrValue, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(this.Character, charValue, StringComparison.OrdinalIgnoreCase) &&
                this.Date.Equals(dateValue) &&
                this.NDate.Equals(nDateValue) &&
                string.Equals(this.Strs, strsValue, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(this.Strw, strwValue, StringComparison.OrdinalIgnoreCase) &&
                this.Dcml == dcmlValue &&
                this.Lng == lngValue;
        }

        public bool Equals([AllowNull] StructModel other)
        {
            if (other == null)
            {
                return false;
            }

            return this.Id == other.Id &&
                string.Equals(this.Strp, other.Strp, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(this.Chr, other.Chr, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(this.Character, other.Character, StringComparison.OrdinalIgnoreCase) &&
                this.Date.Equals(other.Date) &&
                this.NDate.Equals(other.NDate) &&
                string.Equals(this.Strs, other.Strs, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(this.Strw, other.Strw, StringComparison.OrdinalIgnoreCase) &&
                this.Dcml == other.Dcml &&
                this.Lng == other.Lng;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            dynamic other = obj;

            return this.Id == other.id &&
                string.Equals(this.Strp, other.strp, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(this.Chr, other.chr, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(this.Character, other.character, StringComparison.OrdinalIgnoreCase) &&
                this.Date.Equals(other.date) &&
                this.NDate.Equals(other.ndate) &&
                string.Equals(this.Strs, other.strs, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(this.Strw, other.strw, StringComparison.OrdinalIgnoreCase) &&
                this.Dcml == other.dcml &&
                this.Lng == other.lng;
        }

        public override int GetHashCode() => this.Id.GetHashCode();
    }
}
