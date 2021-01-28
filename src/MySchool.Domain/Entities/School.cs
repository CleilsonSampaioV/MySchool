/// <summary>
/// Summary description for Class1
/// </summary>
public class School : EntityBase
{
    public School(string name, string zipCode, string address, string complement, string neighborhood, string city, string state, string country)
    {
        Name = name;

        if (Name == null)
        {
            AddNotification("Escola", "Informe um nome para a escola");
        }

        ZipCode = zipCode;
        Address = address;
        Complement = complement;
        Neighborhood = neighborhood;
        City = city;
        State = state;
        Country = country;
    }

    public School(string name, string address, string complement, string neighborhood, string city, string state, string country)
    {
        Name = name;

        if (Name == null)
        {
            AddNotification("Escola", "Informe um nome para a escola");
        }

        Address = address;
        Complement = complement;
        Neighborhood = neighborhood;
        City = city;
        State = state;
        Country = country;
    }

    public string Name { get; private set; }
    public string ZipCode { get; private set; }
    public string Address { get; private set; }
    public string Complement { get; private set; }
    public string Neighborhood { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Country { get; private set; }

    public void UpdateName(string name)
    {
        Name = name;

        if (Name == null)
        {
            AddNotification("Escola", "Informe um nome para a escola");
        }
    }

    public void UpdateAddress(string zipCode, string address, string complement, string neighborhood, string city, string state, string country)
    {
        ZipCode = zipCode;
        Address = address;
        Complement = complement;
        Neighborhood = neighborhood;
        City = city;
        State = state;
        Country = country;
    }

}
