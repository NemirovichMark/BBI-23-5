using System;
//Сделать абстрактный класс, и от него создать 2-х наследников: человек года и открытие года.
//Собрать 2 таблицы с ответами и вывести 2 таблицы (независимые).

abstract class ObjectOfVote
{
    private int _votescount;
    public int VotesCount => _votescount;

    public void Vote()
    {
        _votescount++;
    }

    public double GetPercentegeOfVote(int nominalVotes)
    {
        var result = VotesCount / (double)nominalVotes * 100;

        return (double)Math.Round(result, 4);
    }
    public abstract string ConvertToReportString(int nominalVotes);

}
internal class PersonOfTheYear : ObjectOfVote
{
    public string Name;

    public PersonOfTheYear(string name)
    {
        Name = name;
    }

    public override string ConvertToReportString(int nominalVotes) =>
        $"{Name} Кол-во. голосов: {VotesCount} Процент: {GetPercentegeOfVote(nominalVotes)}%";
}

internal class EventOfTheYear : ObjectOfVote
{
    private string _eventname;
    public string EventName => _eventname;
    private DateTime _date;
    public DateTime Date => _date;

    public EventOfTheYear(string eventName, DateTime date)
    {
        _eventname = eventName;
        _date = date;
    }

    public override string ConvertToReportString(int nominalVotes) =>
        $"{EventName} Дата: {Date.Day}/{Date.Month}/{Date.Year} Кол-во. голосов: {VotesCount} Процент: {GetPercentegeOfVote(nominalVotes)}%";
}
class Programm
{
    public static void Main()
    {
        var countOfVotes = 35;

        var persons = new PersonOfTheYear[] {
            new PersonOfTheYear("Эмма Уотсон"),
            new PersonOfTheYear("Анастатися Ивлеева"),
            new PersonOfTheYear("Джон Смит"),
            new PersonOfTheYear("Александра Бортич"),
            new PersonOfTheYear("Билл Гейтс"),
            new PersonOfTheYear("Марк Цукерберг"),
            new PersonOfTheYear("Денис Петров"),
            new PersonOfTheYear("Павел Дуров"),
            new PersonOfTheYear("Алла Пугачёва"),
            new PersonOfTheYear("Волтер Вайт"),
            new PersonOfTheYear("Жанна Дарк"),
            new PersonOfTheYear("Стив Джопс")
        };

        CalculatePersonOfYear(countOfVotes, persons);

        var events = new EventOfTheYear[] {
            new EventOfTheYear("Событие 1", new DateTime(2001, 9, 11)),
            new EventOfTheYear("Событие 2", new DateTime(2007, 1, 1)),
            new EventOfTheYear("Событие 3", new DateTime(2008, 5, 5)),
            new EventOfTheYear("Событие 4", new DateTime(2020, 6, 6)),
            new EventOfTheYear("Событие 5", new DateTime(2022, 12, 7)),
            new EventOfTheYear("Событие 6", new DateTime(2002, 11, 8)),
            new EventOfTheYear("Событие 7", new DateTime(2003, 7, 6)),
            new EventOfTheYear("Событие 8", new DateTime(2005, 8, 9)),
            new EventOfTheYear("Событие 9", new DateTime(2016, 9, 2)),
            new EventOfTheYear("Событие 10", new DateTime(2019, 2, 5)),
            new EventOfTheYear("Событие 11", new DateTime(2017, 1, 2)),
            new EventOfTheYear("Событие 12", new DateTime(2012, 3, 4))
        };

        CalculateEventOfYear(countOfVotes, events);


    }

    public static void CalculatePersonOfYear(int countOfVotes, PersonOfTheYear[] persons)
    {
        CalculateObjectsOfTheYear(countOfVotes, persons);

        InsertionSort(persons);

        Console.WriteLine("============= Результаты (Люди года) =============");
        foreach (PersonOfTheYear person in persons)
            Console.WriteLine(person.ConvertToReportString(countOfVotes));
        Console.WriteLine("==================================================");
    }

    public static void CalculateEventOfYear(int countOfVotes, EventOfTheYear[] events)
    {
        CalculateObjectsOfTheYear(countOfVotes, events);

        InsertionSort(events);

        Console.WriteLine("============= Результаты (События года) =============");
        foreach (EventOfTheYear currentEvent in events)
            Console.WriteLine(currentEvent.ConvertToReportString(countOfVotes));
        Console.WriteLine("==================================================");
    }

    public static void CalculateObjectsOfTheYear(int countOfVotes, ObjectOfVote[] objectsOfVotes)
    {
        for (int i = 0; i < countOfVotes; i++)
        {
            var idOfObject = new Random().Next(0, objectsOfVotes.Length);

            objectsOfVotes[idOfObject].Vote();
        }
    }


    static void InsertionSort(ObjectOfVote[] objectsOfVotes)
    {
        for (int i = 1; i < objectsOfVotes.Length; i++)
        {
            ObjectOfVote k = objectsOfVotes[i];

            int j = i - 1;

            while (j >= 0 && objectsOfVotes[j].VotesCount < k.VotesCount)
            {
                objectsOfVotes[j + 1] = objectsOfVotes[j];
                j--;
            }
            objectsOfVotes[j + 1] = k;
        }
    }

}