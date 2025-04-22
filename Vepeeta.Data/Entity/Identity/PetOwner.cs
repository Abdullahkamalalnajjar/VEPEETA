namespace Vepeeta.Data.Entity.Identity
{
    public class PetOwner : User
    {
        public string? FristName { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;
        public string? FullName => $"{FristName} {LastName}";
        public string? Animalname { get; set; }
        public string? AnimalGender { get; set; }
        public string? AnimalType { get; set; }
        public string? AnimalCategory { get; set; }
        public DateTime? AnimalBornDate { get; set; }
        public decimal? Weight { get; set; }
        public string? ReproductiveStatus { get; set; }
        public string? sensitivity { get; set; }
        public string? Image { get; set; }
        public string? Address { get; set; }
        public string? Description { get; set; }
    }
} 