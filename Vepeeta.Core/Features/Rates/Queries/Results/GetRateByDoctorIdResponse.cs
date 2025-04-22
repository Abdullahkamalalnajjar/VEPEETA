using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vepeeta.Core.Features.Rates.Queries.Results
{
    public class GetRateByDoctorIdResponse
    {
        public double Avaragerate { get; set; } 
        public List<RateCommentDto>? Comments { get; set; }

    }
    public class RateCommentDto
    {
        public double Rate { get; set; }   
        public string? Comment { get; set; }
    }
}
