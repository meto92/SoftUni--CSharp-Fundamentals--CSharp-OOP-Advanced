using System.Collections.Generic;

public interface IController : IEntityRepository
{
    string Register(IList<string> args);

    string Produce();
}