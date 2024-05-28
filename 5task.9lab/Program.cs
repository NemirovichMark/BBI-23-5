using Newtonsoft.Json;
namespace _5task._9lab;

public class students
{
    public string fio { get; set; }
    public int mark { get; set; }
    public int misses { get; set; }
    public string lesson { get; set; }
    public students(string fio, int mark, int misses, string lesson)
    {
        this.fio = fio;
        this.mark = mark;
        this.misses = misses;
        this.lesson = lesson;
    }
    public override string ToString()
    {
        return $"{fio} {mark} {misses}";
    }
}
public class informatics : students
{
    public informatics(string fio, int mark, int misses, string lesson) : base(fio, mark, misses, lesson)
    {

    }
    public override string ToString()
    {
        return $"{fio} {mark} {misses}";
    }
}
public class maths : students
{
    public maths(string fio, int mark, int misses, string lesson) : base(fio, mark, misses, lesson)
    {

    }
    public override string ToString()
    {
        return $"{fio} {mark} {misses}";
    }
}


class Program
{
    public static void insert(List<students> a)
    {
        for (int i = 0; i < a.Count; i++)
        {
            students l = a[i];
            int g = i - 1;
            while (g >= 0 && a[g].misses < l.misses)
            {
                a[g + 1] = a[g];
                g--;
            }
            a[g + 1] = l;
        }
    }
    static void Main(string[] args)
    {
        List<students> b = new List<students>();
        b.Add(new maths("Сидоров", 4, 3, "Математика"));
        b.Add(new informatics("Арбузов", 2, 20, "Информатика"));
        b.Add(new informatics("Иванов", 2, 10, "Информатика"));
        b.Add(new maths("Зайцев", 2, 7, "Математика"));
        b.Add(new maths("Яковлев", 2, 3, "Математика"));
        List<students> bad_students = new List<students>();
        foreach (students i in b)
        {
            if (i.mark == 2)
            {
                bad_students.Add(i);
            }
        }
        insert(bad_students);
        string path_file = "Students.json";
        if (File.Exists(path_file))
        {
            File.Delete(path_file);
        }
        json_serialisation.serilase_to_json(bad_students, path_file);
        var bad = json_serialisation.deserilase_to_json<students>(path_file);
        string json = File.ReadAllText(path_file);
        var list = JsonConvert.DeserializeObject<List<students>>(json);
        foreach (var student in list)
        {
            Console.WriteLine(student.lesson + " " + student.fio + " " + student.misses);
        }
    }
}