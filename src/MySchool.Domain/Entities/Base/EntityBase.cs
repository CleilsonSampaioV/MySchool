using prmToolkit.NotificationPattern;
using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class EntityBase : Notifiable, IEquatable<EntityBase>
{
    public Guid Id { get; private set; }

    public EntityBase()
    {
        Id = Guid.NewGuid();
    }

    public bool Equals(EntityBase other)
    {
        return Id == other.Id;
    }
}