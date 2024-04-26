using System;

abstract class Task
{
    protected string text;

    public Task(string text)
    {
        this.text = text;
    }
}

class Task1 : Task
{
    protected int[] counter;
    protected int total;
    protected string result;
    public Task1(string text) : base(text)
    {
        counter = new int[32];
    }


    public override string ToString()
    {
        foreach (char i in text.ToLower())
        {
            if (i >= 'а' && i <= 'я')
            {
                counter[i - 'а']++;
                total++;
            }
        }
        double[] temp = new double[32];
        for (int i = 0; i < temp.Length; i++)
        {
            temp[i] = (double)counter[i] / total;
        }
        result = "";
        for (int i = 0; i < temp.Length; i++)
        {
            char letter = (char)('а' + i);
            result += $"Буква '{letter}': {temp[i]:P2}\n";
        }
        return result;
    }
}

class Task3 : Task
{
    protected int maxim;
    protected string[] words;

    public Task3(string text) : base(text)
    {
        maxim = 50;
    }

    public override string ToString()
    {
        words = text.Split(' ');
        string result = "";
        string current = "";
        foreach (string word in words)
        {
            if ((current + word).Length > maxim)
            {
                result += current + "\n";
                current = "";
            }
            current += word + " ";
        }
            result += current;
        return result;
    }
}

class Task7 : Task
{
    protected string[] words;
    protected string New;
    protected string sequence;
    public Task7(string text, string sequence) : base(text)
    {
        words = text.Split(new char[] { ' ', ',', '.', ';', ':', '!', '?' });
        this.sequence = sequence;
    }

    public override string ToString()
    {
        int count = 0;
        foreach (string word in words)
        {
            if (word.Contains(sequence))
            {
                count++;
            }
        }

        string[] foundWords = new string[count];

        int index = 0;
        foreach (string word in words)
        {
            if (word.Contains(sequence))
            {
                foundWords[index] = word;
                index++;
            }
        }

        for (int i = 0; i < foundWords.Length; i++)
        {
            New += foundWords[i] + " ";
        }
        return New;
    }
}


class Task11 : Task
{
    protected string[] names;

    public Task11(string text) : base(text)
    {
        names = text.Split(',');
    }

    private bool IsFirst(string name1, string name2)
    {
        int minLength = Math.Min(name1.Length, name2.Length);
        for (int i = 0; i < minLength; i++)
        {
            if (name1[i] < name2[i])
                return true;
            else if (name1[i] > name2[i])
                return false;
        }
        return name1.Length < name2.Length;
    }

    public override string ToString()
    {
        int n = names.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (!IsFirst(names[j], names[j + 1]))
                {
                    string temp = names[j];
                    names[j] = names[j + 1];
                    names[j + 1] = temp;
                }
            }
        }
        return string.Join(", ", names);
    }
}


class Task14 : Task
{
    protected int sum;
    protected int number;
    protected bool numberBool;
    public Task14(string text) : base(text){}

    public override string ToString()
    {
        sum = 0;
        number = 0;
        numberBool = false;

        foreach (char i in text)
        {
            if (i >= '0' && i <= '9')
            {
                if (numberBool)
                {
                    number = number * 10 + (i - '0');
                }
                else
                {
                    numberBool = true;
                    number = i - '0';
                }
            }
            else if (numberBool)
            {
                sum += number;
                numberBool = false;
                number = 0;
            }
        }
        if (numberBool)
        {
            sum += number;
        }

        return sum.ToString();
    }
}



