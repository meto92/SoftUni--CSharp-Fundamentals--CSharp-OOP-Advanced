using System.Collections.Generic;

public interface IEntityRepository
{
    IReadOnlyCollection<IEntity> Entities { get; }
}