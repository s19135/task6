namespace lesson6_1.Models
{
    public class Student
    {
        public Student(string id, string firstName, string lastName, string indexNumber)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.IndexNumber = indexNumber;
        }

        public Student() { }
        
        public int IdStudent { get; set; }
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IndexNumber { get; set; }
    }
}