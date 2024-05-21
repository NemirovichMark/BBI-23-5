//using _9_лаба.Serialises;
namespace _9_лаба;

public abstract class students
{
    public string fio { get; set; }
    public int mark { get; set; }
    public int misses { get; set; }
    public students(string fio, int mark, int misses)
    {
        this.fio = fio;
        this.mark = mark;
        this.misses = misses;
    }
    public override string ToString()
    {
        return $"{fio} {mark} {misses}";
    }
}
public class informatics : students
{
    public informatics(string fio, int mark, int misses) : base(fio, mark, misses)
    {

    }
    public override string ToString()
    {
        return $"{fio} {mark} {misses}";
    }
}
public class maths : students
{
    public maths(string fio, int mark, int misses) : base(fio, mark, misses)
    {

    }
    public override string ToString()
    {
        return $"{fio} {mark} {misses}";
    }
}


class Program
{
    public static void insert(students[] a)
    {
        for (int i = 0; i < a.Length; i++)
        {
            students l = a[i];
            int g = i - 1;
            while (g >= 0 && a[g].misses > l.misses)
            {
                a[g + 1] = a[g];
                g--;
            }
            a[g + 1] = l;
        }
    }
    static void Main(string[] args)
    {
        students[] list = { new maths("Сидоров", 4, 3), new informatics("Арбузов", 2, 20), new maths("Зайцев", 2, 7), new informatics("Иванов", 2, 10), new maths("Яковлев", 2, 3) };

        int countBadStudents_maths = 0;
        int countBadStudents_informatics = 0;
        for (int i = 0; i < list.Length; i++)
        {
            if (list[i] is maths && list[i].mark == 2)
            {
                countBadStudents_maths++;
            }
            if (list[i] is informatics && list[i].mark == 2)
            {
                countBadStudents_informatics++;
            }
        }
        students[] bad_students_maths = new students[countBadStudents_maths];
        students[] bad_students_informatics = new students[countBadStudents_informatics];
        int index_maths = 0;
        int index_informatics = 0;
        for (int i = 0; i < list.Length; i++)
        {
            if (list[i] is maths && list[i].mark == 2)
            {
                bad_students_maths[index_maths] = list[i];
                index_maths++;
            }
            if (list[i] is informatics && list[i].mark == 2)
            {
                bad_students_informatics[index_informatics] = list[i];
                index_informatics++;
            }
        }
        insert(bad_students_maths);
        insert(bad_students_informatics);
        string path_file = @"C:\Users\liliyakhvoshch\Desktop\Students.json";
        if (File.Exists(path_file)) File.Delete(path_file);
        json_serialisation.serilase_to_json(bad_students_maths, path_file);
        json_serialisation.serilase_to_json(bad_students_informatics, path_file);
        json_serialisation.deserilase_to_json(path_file);

        List<students> b = json_serialisation.deserilase_to_json(path_file);
        foreach (students student in b)
        {
            Console.WriteLine(student.ToString());
        }
    }
}