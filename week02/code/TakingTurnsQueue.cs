using System;
using System.Collections.Generic;

public class Person
{
    public string Name { get; private set; }
    public int Turns { get; set; }

    public Person(string name, int turns)
    {
        Name = name;
        Turns = turns;
    }
}

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

        // Determine if this person has infinite turns
        bool infiniteTurns = person.Turns <= 0;

        // For finite turns, decrement and requeue if > 1
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
            queue.Enqueue(person); // infinite turns, always requeue
        }

        return person;
    }
}