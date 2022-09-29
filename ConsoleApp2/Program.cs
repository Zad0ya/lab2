using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Linq;


namespace Lab2;

internal class Program
{
    static void Main(string[] args)
    {
        Address address = new Address();
        address.Street = "Peremohy AVE";
        address.House = "67B";
        address.Apartment = "25";
        address.City = "Kyiv";
        address.Country = "Ukraine";
        address.Index = 03117;
        Console.WriteLine($"Street: {address.Street}, House: {address.House}, Apartment: {address.Apartment},City: {address.City}, Country: {address.Country}Index: {address.Index}.");

        Converter converter = new Converter(40.0, 40.0, 0.00001);
        converter.ConvertChooseStart();

    }
}
class Address
{
    private int index;
    private string country = "";
    private string city = "";
    private string street = "";
    private string house = "";
    private string apartment = "";

    public int Index
    {
        get { return index; }
        set
        {
            if (value.GetType() == typeof(int))
                index = value;
            else
                Console.WriteLine("Помилка");
        }
    }
    public string Country
    {
        get { return country; }
        set
        {
            if (value.GetType() == typeof(string))
                country = value;
            else
                Console.WriteLine("Помилка");
        }
    }
    public string City
    {
        get { return city; }
        set
        {
            if (value.GetType() == typeof(string))
                city = value;
            else
                Console.WriteLine("Помилка");
        }
    }
    public string Street
    {
        get { return street; }
        set
        {
            if (value.GetType() == typeof(string))
                street = value;
            else
                Console.WriteLine("Помилка");
        }
    }
    public string House
    {
        get { return house; }
        set
        {
            if (value.GetType() == typeof(string))
                house = value;
            else
                Console.WriteLine("Помилка");
        }
    }
    public string Apartment
    {
        get { return apartment; }
        set
        {
            if (value.GetType() == typeof(string))
                apartment = value;
            else
                Console.WriteLine("Помилка");
        }
    }
}
class Converter
{
    private double usd;
    private double eur;
    private double rub;
    public Converter(double usd, double eur, double rub)
    {

        this.usd = usd;
        this.eur = eur;
        this.rub = rub;
    }
    public void ConvertChooseStart()
    {
        int choose = 0;
        do
        {
            Console.WriteLine("Оберіть операцію: \n 1 - Гривню у іноземну валюту (USD/EUR/RUB), 2 - Іноземну валюту (USD/EUR/RUB) у гривню: \n (Щоб скасувати операцію натисніть 0) ");
            choose = Convert.ToInt32(Console.ReadLine());
            if (choose < 0 || choose > 3)
                Console.WriteLine("Операцію не знайдено");
            else if (choose == 0)
            {
                Console.WriteLine("вихід");
                break;
            }
            else
                break;
        } while (true);
        switch (choose)
        {
            case 1:
                double uahv = 0;
                int Curs = 0;

                while (true)
                {

                    Console.Write("UAH: ");
                    uahv = Convert.ToDouble(Console.ReadLine());
                    if (uahv < 100)
                    {
                        Console.WriteLine("(!!!) Помилка! Конвертація можлива лише від 100 гривень!");
                        continue;
                    }

                    Console.Write("USD - 1, EUR - 2, RUB - 3: ");
                    Curs = Convert.ToInt32(Console.ReadLine());
                    if (Curs < 1 || Curs > 3)
                    {
                        Console.WriteLine("Валюту не знайдено");
                        continue;
                    }
                    break;
                }
                switch (Curs)
                {
                    case 1:
                        Console.WriteLine($"Сума у доларах складає:{UAHEDR(uahv, Curs)}");
                        Console.Write("---------------------------------------------------------------------------");
                        break;
                    case 2:
                        Console.WriteLine($"Сума у евро складає:{UAHEDR(uahv, Curs)}");
                        Console.Write("---------------------------------------------------------------------------");
                        break;
                    case 3:
                        Console.WriteLine($"Сума у рублях складає:{UAHEDR(uahv, Curs)}");
                        Console.Write("---------------------------------------------------------------------------");
                        break;
                }
                break;
            case 2:
                int Curs2 = 0;
                double Curva = 0;

                while (true)
                {
                    Console.Write("USD - 1, EUR - 2, RUB - 3: ");
                    Curs2 = Convert.ToInt32(Console.ReadLine());
                    if (Curs2 < 1 || Curs2 > 3)
                    {
                        Console.WriteLine("Валюту не знайдено");
                        continue;
                    }
                    Console.Write("Value: ");
                    Curva = Convert.ToDouble(Console.ReadLine());
                    if (Curva < 1)
                    {
                        Console.WriteLine("(!!!) Помилка! Конвертація неможлива при значенні 0!");
                        continue;
                    }
                    break;
                }
                switch (Curs2)
                {
                    case 1:
                        Console.WriteLine($"Сума у гривнях після конвертації з доларів:{EDRUAH(Curva, Curs2)}");
                        Console.Write("---------------------------------------------------------------------------");
                        break;
                    case 2:
                        Console.WriteLine($"Сума у гривнях після конвертації з євро:{EDRUAH(Curva, Curs2)}");
                        Console.Write("---------------------------------------------------------------------------");
                        break;
                    case 3:
                        Console.WriteLine($"Сума у гривнях після конвертації з рублів:{EDRUAH(Curva, Curs2)}");
                        Console.Write("---------------------------------------------------------------------------");
                        break;
                }
                break;
        }
    }
    public double UAHEDR(double uah, int currency)
    {
        double converted = 0;
        switch (currency)
        {
            case 0:
                Console.WriteLine("Вихід");
                break;
            case 1:
                converted = uah / usd;
                break;
            case 2:
                converted = uah / eur;
                break;
            case 3:
                converted = uah / eur;
                break;
            default:
                Console.WriteLine("Трапилась помилка");
                break;
        }
        return converted;
    }
    public double EDRUAH(double cur, int currency)
    {
        double converted = 0;
        switch (currency)
        {
            case 0:
                Console.WriteLine("");
                break;
            case 1:
                converted = cur * usd;
                break;
            case 2:
                converted = cur * eur;
                break;
            case 3:
                converted = cur * rub;
                break;
            default:
                Console.WriteLine("Помилка");
                break;
        }
        return converted;
    }
}

class Prog
{
    static void Main3(string[] args)
    {
        Employee converter = new Employee(31487, 54167, 15765, 26951, 8658, 0.20);
        converter.main();
        Console.ReadKey();
    }
}
class Employee
{
    private double buh { get; set; }
    private double boss { get; set; }
    private double prod { get; set; }
    private double otdpr { get; set; }
    private double ubor { get; set; }
    private double podatok { get; set; }


    public Employee(double buh, double boss, double prod, double otdpr, double ubor, double podatok)
    {
        this.buh = buh;
        this.boss = boss;
        this.prod = prod;
        this.otdpr = otdpr;
        this.ubor = ubor;
        this.podatok = podatok;
    }

    public void main()
    {
        Console.WriteLine("----------------------------Система управління бухгалтерського обліку Макс3000----------------------------");
        Console.WriteLine("Оберіть операцію:");
        Console.WriteLine("\n1.Пошук працівників за ініцалами \n2.Пошук прізвища ");
        int vol = Convert.ToInt32(Console.ReadLine());
        switch (vol)
        {
            case 1:
                Console.WriteLine("Оберіть Працівника:");
                Console.WriteLine("\n1.ЗМО \n2.ВАП \n3.ГСМ \n4.МОЕ");
                int vol2 = Convert.ToInt32(Console.ReadLine());
                switch (vol2)
                {
                    case 1:
                        Console.WriteLine("Заробітна плаата працівника без податкового збору скаладає " + boss);
                        Console.WriteLine("Податковий збір" + podatok);
                        double zboss = boss - (boss * podatok);
                        Console.WriteLine("Заробітна плата працівника з податковим збором: " + zboss);
                        Console.WriteLine("Можлива надбавка за стаж");
                        Console.WriteLine("\n1.<3 років \n2.3-5 років \n3.7> років");
                        int voln = Convert.ToInt32(Console.ReadLine());
                        switch (voln)
                        {
                            case 1:
                                Console.WriteLine("Можлива надбавка за стаж відсутня");
                                break;
                            case 2:
                                Console.WriteLine("Надбавка за стаж +3%");
                                double zbossnad1 = zboss * 1.03;
                                Console.WriteLine("Заробітна плата працівника з податковим збором та надбавкою складає: " + zbossnad1);
                                break;
                            case 3:
                                Console.WriteLine("Надбавка за стаж +5%");
                                double zbossnad2 = zboss * 1.05;
                                Console.WriteLine("Заробітна плата працівника з податковим збором та надбавкою складає: " + zbossnad2);
                                break;
                        }
                        break;
                    case 2:
                        Console.WriteLine("Заробітна плаата працівника без податкового збору скаладає " + buh);
                        Console.WriteLine("Податковий збір" + podatok);
                        double zbuh = buh - (buh * podatok);
                        Console.WriteLine("Заробітна плата працівника з податковим збором: " + zbuh);
                        Console.WriteLine("Можлива надбавка за стаж");
                        Console.WriteLine("\n1.<3 років \n2.3-5 років \n3.7> років");
                        int vola = Convert.ToInt32(Console.ReadLine());
                        switch (vola)
                        {
                            case 1:
                                Console.WriteLine("Можлива надбавка за стаж відсутня");
                                Console.WriteLine("Заробітна плата працівника з податковим збором та надбавкою складає: " + zbuh);
                                break;
                            case 2:
                                Console.WriteLine("Надбавка за стаж +3%");
                                double zbuhnad1 = zbuh * 1.03;
                                Console.WriteLine("Заробітна плата працівника з податковим збором та надбавкою складає: " + zbuhnad1);
                                break;
                            case 3:
                                Console.WriteLine("Надбавка за стаж +5%");
                                double zbuhnad2 = zbuh * 1.05;
                                Console.WriteLine("Заробітна плата працівника з податковим збором та надбавкою складає: " + zbuhnad2);
                                break;
                        }
                        break;
                    case 3:
                        Console.WriteLine("Заробітна плаата працівника без податкового збору скаладає " + prod);
                        Console.WriteLine("Податковий збір" + podatok);
                        double zprod = prod - (prod * podatok);
                        Console.WriteLine("Заробітна плата працівника з податковим збором: " + zprod);
                        Console.WriteLine("Можлива надбавка за стаж");
                        Console.WriteLine("\n1.<3 років \n2.3-5 років \n3.7> років");
                        int volb = Convert.ToInt32(Console.ReadLine());
                        switch (volb)
                        {
                            case 1:
                                Console.WriteLine("Можлива надбавка за стаж відсутня");
                                Console.WriteLine("Заробітна плата працівника з податковим збором та надбавкою складає: " + zprod);
                                break;
                            case 2:
                                Console.WriteLine("Надбавка за стаж +3%");
                                double zprodnad1 = zprod * 1.03;
                                Console.WriteLine("Заробітна плата працівника з податковим збором та надбавкою складає: " + zprodnad1);
                                break;
                            case 3:
                                Console.WriteLine("Надбавка за стаж +5%");
                                double zprodnad2 = zprod * 1.05;
                                Console.WriteLine("Заробітна плата працівника з податковим збором та надбавкою складає: " + zprodnad2);
                                break;
                        }
                        break;
                    case 4:
                        Console.WriteLine("Заробітна плаата працівника без податкового збору скаладає " + otdpr);
                        Console.WriteLine("Податковий збір" + podatok);
                        double zotdpr = otdpr - (otdpr * podatok);
                        Console.WriteLine("Заробітна плата працівника з податковим збором: " + zotdpr);
                        Console.WriteLine("Можлива надбавка за стаж");
                        Console.WriteLine("\n1.<3 років \n2.3-5 років \n3.7> років");
                        int volc = Convert.ToInt32(Console.ReadLine());
                        switch (volc)
                        {
                            case 1:
                                Console.WriteLine("Можлива надбавка за стаж відсутня");
                                Console.WriteLine("Заробітна плата працівника з податковим збором та надбавкою складає: " + zotdpr);
                                break;
                            case 2:
                                Console.WriteLine("Надбавка за стаж +3%");
                                double zotdprnad1 = zotdpr * 1.03;
                                Console.WriteLine("Заробітна плата працівника з податковим збором та надбавкою складає: " + zotdprnad1);
                                break;
                            case 3:
                                Console.WriteLine("Надбавка за стаж +5%");
                                double zotdprnad2 = zotdpr * 1.05;
                                Console.WriteLine("Заробітна плата працівника з податковим збором та надбавкою складає: " + zotdprnad2);
                                break;
                        }
                        break;
                    case 5:
                        Console.WriteLine("Заробітна плаата працівника без податкового збору скаладає " + ubor);
                        Console.WriteLine("Податковий збір" + podatok);
                        double zubor = ubor - (ubor * podatok);
                        Console.WriteLine("Заробітна плата працівника з податковим збором: " + zubor);
                        Console.WriteLine("Можлива надбавка за стаж");
                        Console.WriteLine("\n1.<3 років \n2.3-5 років \n3.7> років");
                        int vold = Convert.ToInt32(Console.ReadLine());
                        switch (vold)
                        {
                            case 1:
                                Console.WriteLine("Можлива надбавка за стаж відсутня");
                                Console.WriteLine("Заробітна плата працівника з податковим збором та надбавкою складає: " + zubor);
                                break;
                            case 2:
                                Console.WriteLine("Надбавка за стаж +3%");
                                double zubornad1 = zubor * 1.03;
                                Console.WriteLine("Заробітна плата працівника з податковим збором та надбавкою складає: " + zubornad1);
                                break;
                            case 3:
                                Console.WriteLine("Надбавка за стаж +5%");
                                double zubornad2 = zubor * 1.05;
                                Console.WriteLine("Заробітна плата працівника з податковим збором та надбавкою складає: " + zubornad2);
                                break;
                        }
                        break;
                }
                break;


        }
    }
class User
    {
        private string firstname = "Maksym";
        private string forname = "Zadoya";
                private int age = 18;
        private string login = "Zadoya_";
        private DateTime currentDateTime = DateTime.Now;
        public void AboutUser()
        {
            Console.WriteLine($"Прізвище: {forname} \n І'мя: {firstname}\n Вік: {age}\n Логін: {login}\n Дата заповнення анкети: {currentDateTime}\n");
        }
    }
}

