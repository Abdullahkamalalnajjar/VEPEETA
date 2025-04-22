namespace Vepeeta.Core.Features.AppUser.Quers.Response
{

    public class GetUserPaginatedListResponse
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? Animalname { get; set; }
        public string? AnimalGender { get; set; }
        public string? AnimalType { get; set; }
        public string? AnimalCategory { get; set; }
        public DateTime? AnimalBornDate { get; set; }
        public decimal? Weight { get; set; }
        public string? ReproductiveStatus { get; set; }
        public string? Description { get; set; }

        public string? sensitivity { get; set; }
        public string? Image { get; set; }

    }
}
