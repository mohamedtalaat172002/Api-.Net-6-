namespace MoviesAPI2022.DTO
{
    public class CreateGenreDTO
    {
        [MaxLength(100)]
        public string Name{ get; set; }
    }
}
