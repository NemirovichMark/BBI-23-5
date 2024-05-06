namespace app.main.serialize;

public interface IMySerializer<T>
{
    public abstract T Read(string filename);

    public abstract bool Write(T t, string filename);
}