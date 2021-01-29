using MySchool.Domain.ValueObjects;

/// <summary>
/// Summary description for Class1
/// </summary>
public class School : EntityBase
{
    public School(string name, string cnpj, Address address)
    {
        if (string.IsNullOrEmpty(name))
        {
            AddNotification("Escola", "Informe um nome para a escola");
        }
        Name = name;

        if (cnpj.Length > 14)
        {
            AddNotification("Escola.Cnpj", "Informe um cnpj válido para a escola");
        }

        Address = address;
    }

    public string Name { get; private set; }
    public string Cnpj { get; private set; }

    public Address Address { get; private set; }

    public void UpdateName(string name)
    {
        this.Name = name;

        if (Name == null)
        {
            AddNotification("Escola", "Informe um nome para a escola");
        }
    }

    public void UpdateAddress(Address address)
    {
        this.Address = address;
    }

}
