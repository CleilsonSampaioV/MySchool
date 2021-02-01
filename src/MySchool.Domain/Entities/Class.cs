using System;
/// <summary>
/// Summary description for Class
/// </summary>
namespace MySchool.Domain.Entities
{
    public class Class : EntityBase
    {
        protected Class() { }

        public Class(string name, string shift, string degree, string schoolId)
        {
            Name = name;
            if (string.IsNullOrEmpty(Name))
            {
                AddNotification("Turma", "Informe um nome para a turma");
            }

            Shift = shift;
            if (string.IsNullOrEmpty(Shift))
            {
                AddNotification("Turma.Turno", "Informe um turno para a turma");
            }

            Degree = degree;
            if (string.IsNullOrEmpty(Degree))
            {
                AddNotification("Turma.Grau", "Informe o grau para a turma");
            }

            SchoolId = Guid.Parse(schoolId);
            if (SchoolId == Guid.NewGuid())
            {
                AddNotification("Turma.Escola", "Informe o uma escola válida para realizar o cadastro da turma");
            }
        }

        public string Name { get; set; }
        public string Shift { get; set; }
        public string Degree { get; set; }
        public Guid SchoolId { get; set; }
        public virtual School School { get; set; }

        public void UpdateName(string name)
        {
            this.Name = name;

            if (Name == null)
            {
                AddNotification("Escola", "Informe um nome para a escola");
            }
        }

        public void UpdateShift(string shift)
        {
            this.Shift = shift;

            if (Shift == null)
            {
                AddNotification("Turno", "Informe um turno para a turma");
            }
        }
    }
}
