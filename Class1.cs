using System;
//Сделать абстрактный класс, и от него создать 2-х наследников: человек года и открытие года.
//Собрать 2 таблицы с ответами и вывести 2 таблицы (независимые).

namespace P1
{
    abstract class ObjectOfVote
    {
        public int VotesCount;

        public void Vote()
        {
            VotesCount++;
        }

        protected double GetPercentegeOfVote(int nominalVotes)
        {
            var result = VotesCount / (double)nominalVotes * 100;
            return (double)Math.Round(result, 4);
        }

        public abstract string ConvertToReportString(int nominalVotes);
    }

    class PersonOfTheYear : ObjectOfVote
    {
        private string _name;
        public string Name => _name;

        public PersonOfTheYear(string name)
        {
            _name = name;
        }

        public override string ConvertToReportString(int nominalVotes) =>
            $"{Name} Кол-во. голосов: {VotesCount} Процент: {GetPercentegeOfVote(nominalVotes)}%";
    }

    class EventOfTheYear : ObjectOfVote
    {
        private string _eventname;
        public string EventName => _eventname;
        private DateTime _date;

        public EventOfTheYear(string eventName, DateTime date)
        {
            _eventname = eventName;
            _date = date;
        }

        public override string ConvertToReportString(int nominalVotes) =>
            $"{EventName} Дата: {_date.Day}/{_date.Month}/{_date.Year} Кол-во. голосов: {VotesCount} Процент: {GetPercentegeOfVote(nominalVotes)}%";
    }
}

