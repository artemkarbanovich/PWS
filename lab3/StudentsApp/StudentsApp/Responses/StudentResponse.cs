using System.Xml.Serialization;

namespace StudentsApp.Responses
{
    [XmlType("Student")]
    public class StudentResponse
    {
        public StudentResponse(int id, string name, string phone)
        {
            Id = id;
            Name = name;
            Phone = phone;
        }

        public StudentResponse() { }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}