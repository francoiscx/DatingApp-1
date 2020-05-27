namespace udemyCourse.API.Dtos
{
    public class UserForUpdateDto
    {
            // Property we are allowing the user to edit. (include in automapper profiles)
        public string Introduction { get; set; }
        public string LookingFor { get; set; }
        public string Interests { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}