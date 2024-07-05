using Bogus;
using StudentAPIFakeDataCRUD.API.Models;
using System.Collections.Specialized;

namespace StudentAPIFakeDataCRUD.API.Data.FakeData
{
    public class FakeDatas
    {
        public static List<Student> GenerateStudent(int count)
        {
            var students = new Faker<Student>()
                .RuleFor(x=>x.Name,x=>x.Name.FirstName())
                .RuleFor(x=>x.Surname,x=>x.Name.LastName())
                .RuleFor(x=>x.StudentClass,x=>x.PickRandom("A","B","C","D"))
                .Generate(count);

            return students;
        }
    }
}
