using System;
using System.Collections.Generic;

public class TakingTurnsQueue
{
    private Queue<Person> queue = new Queue<Person>();

    public int Length => queue.Count;

    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        queue.Enqueue(person);
    }

    public Person GetNextPerson()
    {
        if (queue.Count == 0)
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        var person = queue.Dequeue();

        bool infiniteTurns = person.Turns <= 0;

        if (!infiniteTurns)
        {
            person.Turns--;
            if (person.Turns > 0)
            {
                queue.Enqueue(person);
            }
        }
        else
        {
            queue.Enqueue(person);
        }

        return person;
    }
}