namespace Vepeeta.Core.Features.Doctors.Queries.Results
{
    public class GetNerestDoctorResponse
    {
        public List<DoctorDto> Doctors { get; set; } = new();
    }
    public class DoctorDto
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public double? DistanceInKm { get; set; }
        public GetDoctorByIdResponse Data { get; set; } = new();

    }

}
