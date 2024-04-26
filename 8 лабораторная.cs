//1 задание
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;


//abstract class Zadanie
//{
//    public string Text { get; set; }

//    public Zadanie(string text)
//    {
//        Text = text;
//    }


//    public abstract void VypolnitZadanie();


//    public override string ToString()
//    {
//        return "Результаты задания:\n"; 
//    }
//}


//class ChastotaBukv : Zadanie
//{
//    public ChastotaBukv(string text) : base(text)
//    {
//        _result = ""; 
//    }

//    public override void VypolnitZadanie()
//    {

//        var bukvi = Text.ToLower().Where(char.IsLetter).GroupBy(c => c);


//        int totalBukv = bukvi.Sum(g => g.Count());
//        var chastota = bukvi.ToDictionary(g => g.Key, g => (double)g.Count() / totalBukv);


//        StringBuilder sb = new StringBuilder(base.ToString()); 
//        foreach (var para in chastota)
//        {
//            sb.AppendLine($"Буква '{para.Key}': {para.Value:P2}");
//        }

//        _result = sb.ToString(); 
//    }

//    private string _result;

//    public override string ToString()
//    {
//        return _result ?? base.ToString(); 
//    }
//}


//class Program
//{
//    static void Main(string[] args)
//    {
//        string text = "Первое кругосветное путешествие было осуществлено флотом, возглавляемым португальским исследователем Фернаном Магелланом. Путешествие началось 20 сентября 1519 года, когда флот, состоящий из пяти кораблей и примерно 270 человек, отправился из порту Сан-Лукас в Испании. Хотя Магеллан не закончил свое путешествие из-за гибели в битве на Филиппинах в 1521 году, его экспедиция стала первой, которая успешно обогнула Землю и доказала ее круглую форму. Это путешествие открыло новые морские пути и имело огромное значение для картографии и географических открытий.";
//        Zadanie zadanie = new ChastotaBukv(text);
//        zadanie.VypolnitZadanie();
//        Console.WriteLine(zadanie);  
//    }
//}



//3 задание 
//using System;
//using System.Collections.Generic;
//using System.Text;


//abstract class Zadanie
//{
//    public string Text { get; set; }

//    public Zadanie(string text)
//    {
//        Text = text;
//    }


//    public abstract void VypolnitZadanie();


//    public override string ToString()
//    {
//        return "Результаты задания:\n";
//    }
//}


//class RazbienieNaStroki : Zadanie
//{
//    private int MaxDlinaStroki { get; set; }

//    public RazbienieNaStroki(string text, int maxDlinaStroki = 50) : base(text)
//    {
//        MaxDlinaStroki = maxDlinaStroki;
//    }

//    public override void VypolnitZadanie()
//    {
//        string[] slova = Text.Split(' ');
//        StringBuilder sb = new StringBuilder();
//        int tekuschayaDlina = 0;

//        foreach (string slovo in slova)
//        {
//            if (tekuschayaDlina + slovo.Length + 1 > MaxDlinaStroki)
//            {
//                sb.AppendLine();
//                tekuschayaDlina = 0;
//            }

//            if (tekuschayaDlina > 0) sb.Append(" ");
//            sb.Append(slovo);
//            tekuschayaDlina += slovo.Length + 1;
//        }

//        _result = sb.ToString();
//    }

//    private string _result;

//    public override string ToString()
//    {
//        return _result ?? base.ToString();
//    }
//}


//class Program
//{
//    static void Main(string[] args)
//    {
//        string text = "После многолетних исследований ученые обнаружили тревожную тенденцию в вырубке лесов Амазонии. Анализ данных показал, что основной участник разрушения лесного покрова – человеческая деятельность. За последние десятилетия рост объема вырубки достиг критических показателей. Главными факторами, способствующими этому, являются промышленные рубки, производство древесины, расширение сельскохозяйственных угодий и незаконная добыча древесины. Это приводит к серьезным экологическим последствиям, таким как потеря биоразнообразия, ухудшение климата и угроза вымирания многих видов животных и растений. ";
//        Zadanie zadanie = new RazbienieNaStroki(text);
//        zadanie.VypolnitZadanie();
//        Console.WriteLine(zadanie);
//    }
//}



//6 задание 
//using System;
//using System.Collections.Generic;
//using System.Text;


//abstract class Zadanie
//{
//    public string Text { get; set; }

//    public Zadanie(string text)
//    {
//        Text = text;
//    }


//    public abstract void VypolnitZadanie();


//    public override string ToString()
//    {
//        return "Результаты задания:\n";
//    }
//}

//class PodschetSlogov : Zadanie
//{
//    public PodschetSlogov(string text) : base(text) { }

//    public override void VypolnitZadanie()
//    {
//        var slovarSlova = Text.Split(' ', StringSplitOptions.RemoveEmptyEntries)
//                              .GroupBy(slovo => KolichestvoSlogov(slovo))
//                              .ToDictionary(g => g.Key, g => g.Count());

//        StringBuilder sb = new StringBuilder(base.ToString());
//        foreach (var para in slovarSlova)
//        {
//            sb.AppendLine($"Слов с {para.Key} слогами: {para.Value}");
//        }
//        _result = sb.ToString();
//    }

//    private int KolichestvoSlogov(string slovo)
//    {
//        int slogi = 0;
//        char[] glasnye = { 'а', 'е', 'ё', 'и', 'о', 'у', 'ы', 'э', 'ю', 'я' };
//        bool bylaGlasnaya = false;

//        foreach (char c in slovo.ToLower())
//        {
//            if (glasnye.Contains(c))
//            {
//                if (!bylaGlasnaya) slogi++;
//                bylaGlasnaya = true;
//            }
//            else
//            {
//                bylaGlasnaya = false;
//            }
//        }

//        return slogi;
//    }

//    private string _result;

//    public override string ToString()
//    {
//        return _result ?? base.ToString();
//    }
//}


//class Program
//{
//    static void Main(string[] args)
//    {
//        string text = "Двигатель самолета – это сложная инженерная конструкция, обеспечивающая подъем, управление и движение в воздухе. Он состоит из множества компонентов, каждый из которых играет важную роль в общей работе механизма. Внутреннее устройство двигателя включает в себя компрессор, камеру сгорания, турбину и системы управления и охлаждения. Принцип работы основан на воздушно-топливной смеси, которая подвергается сжатию, воспламенению и расширению, обеспечивая движение воздушного судна.";
//        Zadanie zadanie = new PodschetSlogov(text);
//        zadanie.VypolnitZadanie();
//        Console.WriteLine(zadanie);
//    }
//}


//12 задание 
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;


//abstract class Zadanie
//{
//    public string Text { get; set; }

//    public Zadanie(string text)
//    {
//        Text = text;
//    }


//    public abstract void VypolnitZadanie();


//    public override string ToString()
//    {
//        return "Результаты задания:\n";
//    }
//}


//class ZamenaKodami : Zadanie
//{
//    private Dictionary<string, int> _slovarKodov; 

//    public ZamenaKodami(string text, Dictionary<string, int> slovarKodov) : base(text)
//    {
//        _slovarKodov = slovarKodov;
//    }

//    public override void VypolnitZadanie()
//    {
//        string[] slova = Text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
//        int[] kody = new int[slova.Length]; 

//        for (int i = 0; i < slova.Length; i++)
//        {
//            string slovo = slova[i].ToLower();  
//            kody[i] = _slovarKodov.ContainsKey(slovo) ? _slovarKodov[slovo] : -1;
//        }

//        _result = string.Join(" ", kody);  
//        _originalText = string.Join(" ", slova); 
//    }

//    private string _result;
//    private string _originalText;

//    public override string ToString()
//    {
//        if (_originalText == null) return base.ToString(); 

//        string[] kody = _result.Split(' ');
//        string[] slova = new string[kody.Length];

//        for (int i = 0; i < kody.Length; i++)
//        {
//            int kod = int.Parse(kody[i]);
//            slova[i] = _slovarKodov.ContainsValue(kod) ? _slovarKodov.First(p => p.Value == kod).Key : "???";
//        }

//        return string.Join(" ", slova);  
//    }
//}


//class Program
//{
//    static void Main(string[] args)
//    {

//        var slovarKodov = new Dictionary<string, int>()
//        {
//            { "это", 1 }, { "текст", 2 }, { "пример", 3 }, { "для", 4 },  { "задание", 5 } 

//        };

//        string text = "Это пример текста для задания по замене слов кодами.";
//        Zadanie zadanie = new ZamenaKodami(text, slovarKodov);
//        zadanie.VypolnitZadanie();
//        Console.WriteLine(zadanie); 
//    }
//}



//13 задание 
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;


//abstract class Zadanie
//{
//    public string Text { get; set; }

//    public Zadanie(string text)
//    {
//        Text = text;
//    }


//    public abstract void VypolnitZadanie();


//    public override string ToString()
//    {
//        return "Результаты задания:\n";
//    }
//}

//class DolyaSlovNaBukvu : Zadanie
//{
//    public DolyaSlovNaBukvu(string text) : base(text) { }

//    public override void VypolnitZadanie()
//    {
//        string[] slova = Text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
//        int vsegoSlov = slova.Length;

//        var slovarDoley = slova.GroupBy(slovo => char.ToLower(slovo[0])) // Группируем по первой букве (в нижнем регистре)
//                               .ToDictionary(g => g.Key, g => (double)g.Count() / vsegoSlov * 100);

//        StringBuilder sb = new StringBuilder(base.ToString());
//        foreach (var para in slovarDoley)
//        {
//            sb.AppendLine($"Буква '{para.Key}': {para.Value:F2}%");
//        }
//        _result = sb.ToString();
//    }

//    private string _result;

//    public override string ToString()
//    {
//        return _result ?? base.ToString();
//    }
//}


//class Program
//{
//    static void Main(string[] args)
//    {
//        string text = "Первое кругосветное путешествие было осуществлено флотом, возглавляемым португальским исследователем Фернаном Магелланом. Путешествие началось 20 сентября 1519 года, когда флот, состоящий из пяти кораблей и примерно 270 человек, отправился из порту Сан-Лукас в Испании. Хотя Магеллан не закончил свое путешествие из-за гибели в битве на Филиппинах в 1521 году, его экспедиция стала первой, которая успешно обогнула Землю и доказала ее круглую форму. Это путешествие открыло новые морские пути и имело огромное значение для картографии и географических открытий.";
//        Zadanie zadanie = new DolyaSlovNaBukvu(text);
//        zadanie.VypolnitZadanie();
//        Console.WriteLine(zadanie);
//    }
//}



//15 задание 
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;


//abstract class Zadanie
//{
//    public string Text { get; set; }

//    public Zadanie(string text)
//    {
//        Text = text;
//    }


//    public abstract void VypolnitZadanie();


//    public override string ToString()
//    {
//        return "Результаты задания:\n";
//    }
//}

//class SummaChiselVTexte : Zadanie
//{
//    public SummaChiselVTexte(string text) : base(text) { }

//    public override void VypolnitZadanie()
//    {
//        string[] elementi = Text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

//        int summa = 0;
//        foreach (string element in elementi)
//        {
//            if (int.TryParse(element, out int chislo))
//            {
//                summa += chislo;
//            }
//        }

//        _result = $"Сумма чисел в тексте: {summa}";
//    }

//    private string _result;

//    public override string ToString()
//    {
//        return _result ?? base.ToString();
//    }
//}

//class Program
//{
//    static void Main(string[] args)
//    {
//        string text = "Первое кругосветное путешествие было осуществлено флотом, возглавляемым португальским исследователем Фернаном Магелланом. Путешествие началось 20 сентября 1519 года, когда флот, состоящий из пяти кораблей и примерно 270 человек, отправился из порту Сан-Лукас в Испании. Хотя Магеллан не закончил свое путешествие из-за гибели в битве на Филиппинах в 1521 году, его экспедиция стала первой, которая успешно обогнула Землю и доказала ее круглую форму. Это путешествие открыло новые морские пути и имело огромное значение для картографии и географических открытий.";
//        Zadanie zadanie = new SummaChiselVTexte(text);
//        zadanie.VypolnitZadanie();
//        Console.WriteLine(zadanie);
//    }
//}