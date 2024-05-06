using System.Text.Json;

namespace app.main.serialize;

public class MyJsonSerializer<T> : IMySerializer<T> where T : class
{
    public bool Write(T t, string fileName)
    {
        using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
        {
            try
            {
                JsonSerializer.Serialize(fs, t);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        return true;
    }

    public T Read(string fileName)
    {
        using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
        {
            try
            {
                return JsonSerializer.Deserialize<T>(fs);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}