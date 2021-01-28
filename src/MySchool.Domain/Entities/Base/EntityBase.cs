using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class EntityBase
{
    public Guid Id { get; set; }

    public EntityBase()
    {
        Id = Guid.NewGuid();
    }
}