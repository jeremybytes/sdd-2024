﻿namespace PeopleViewer.Common;

public interface IPersonReader
{
    Task<IReadOnlyCollection<Person>> GetPeople();
    Task<Person> GetPerson(int id);
}
