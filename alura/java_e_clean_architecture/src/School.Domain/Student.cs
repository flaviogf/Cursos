using System.Collections.Generic;

namespace School.Domain
{
    public class Student
    {
        public Student(Cpf cpf, string name, Email email)
        {
            Cpf = cpf;
            Name = name;
            Email = email;
        }

        public Cpf Cpf { get; }

        public string Name { get; }

        public Email Email { get; }

        public IList<Phone> Phones = new List<Phone>();

        public void AddPhone(string ddd, string number)
        {
            var phone = new Phone(ddd, number);

            Phones.Add(phone);
        }
    }
}
