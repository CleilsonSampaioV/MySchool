
using MySchool.Domain.Entities;
using System.Collections.Generic;
/// <summary>
/// Summary description for Class1
/// </summary>
public class School : EntityBase
{
    protected School() { }

    public School(string name, string cnpj)
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
    }

    public School(string name, string cnpj, string street, string number, string neighborhood, string city, string state, string country, string zipCode)
    {
        Name = name;
        if (string.IsNullOrEmpty(Name))
        {
            AddNotification("Escola", "Informe um nome para a escola");
        }

        Cnpj = cnpj;
        if (Cnpj.Length > 14)
        {
            AddNotification("Escola.Cnpj", "Informe um cnpj válido para a escola");
        }

        Street = street;
        if (string.IsNullOrEmpty(Street) && Street.Length > 255)
        {
            AddNotification("Escola.Rua", "Nome da rua inválido.");
        }

        Number = number;
        if (string.IsNullOrEmpty(Number))
        {
            AddNotification("Escola.Numero", "Informe o numero.");
        }

        Neighborhood = neighborhood;
        if (string.IsNullOrEmpty(Neighborhood))
        {
            AddNotification("Escola.Bairro", "Informe o bairro.");
        }

        City = city;
        if (string.IsNullOrEmpty(City))
        {
            AddNotification("Escola.Cidade", "Informe a cidade.");
        }

        State = state;
        if (string.IsNullOrEmpty(State))
        {
            AddNotification("Escola.Estado", "Informe o estado.");
        }
        Country = country;
        if (string.IsNullOrEmpty(Country))
        {
            AddNotification("Escola.Pais", "Informe o pais.");
        }
        ZipCode = zipCode;
    }

    public string Name { get; private set; }
    public string Cnpj { get; private set; }
    public string Street { get; private set; }
    public string Number { get; private set; }
    public string Neighborhood { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Country { get; private set; }
    public string ZipCode { get; private set; }

    public IEnumerable<Class> Classes { get; set; }

    public void UpdateName(string name)
    {
        this.Name = name;

        if (Name == null)
        {
            AddNotification("Escola", "Informe um nome para a escola");
        }
    }
    public void UpdateAddress(string street, string number, string neighborhood, string city, string state, string country, string zipCode)
    {
        Street = street;
        Number = number;
        Neighborhood = neighborhood;
        City = city;
        State = state;
        Country = country;
        ZipCode = zipCode;
    }
}
