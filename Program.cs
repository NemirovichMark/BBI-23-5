Random k = new Random();
double[] a = new double[5];
double s = 0;
double c = 0;
for (int i = 0; i < 5; i++)
{
    a[i] = k.Next(10, 50);
    Console.Write("{0:f0} ", a[i]);
    s = s + a[i];
    c = c + 1;
}
Console.WriteLine();
double sred = s / c;
Console.WriteLine(sred);
for (int i = 0; i < 5; i++)
{
    a[i] = a[i] - sred;
    Console.Write("{0:f0} ", a[i]);
}
