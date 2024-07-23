using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTerminalApp.Entities
{
    public record User : IEntity
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("firstname")]
        public string? FirstName { get; set; }
        [JsonProperty("lastname")]
        public string? LastName { get; set; }
        [JsonProperty("salaryperhour")]
        public decimal? SalaryPerHour { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("===========");
            sb.AppendLine(this.Id.ToString());
            sb.AppendLine(this.FirstName.ToString());
            sb.AppendLine(this.LastName.ToString());
            sb.AppendLine(this.SalaryPerHour.ToString());
            sb.AppendLine("===========");

            return sb.ToString();
        }
    }
}
