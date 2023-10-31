using System;
abstract class Worker //абстрактний клас 
{
    protected double salary; //зарплата
    protected double prize; //премія
    public abstract string Info(); //інформація про поля об'єкта
    public abstract void SalaryA(); //обчислення зарплатні
    public abstract void PrizeA(); //обчислення премії
}
class BetWork : Worker //дочірній клас
{
    public BetWork(double rate) //конструктор
    {
        salary = rate;
    }
    public override string Info() //виведення
    {
        return $"Робітник на ставці: Ставка: {salary:C2}, " +
            $"Зарплата: {salary:C2}, Премія: {prize:C2}";
    }
    public override void SalaryA() //обчислення зарплатні
    {
        //зарплата залишається незмінною
    }
    public override void PrizeA() //обчислення премії
    {
        prize = salary * 0.25;
    }
}
class HourWork : Worker //дочірній клас
{
    private int hours; //кількість годин
    private double cost; //вартість 1 години 
    public HourWork(int hours, double cost) //конструктор
    {
        this.hours = hours;
        this.cost = cost;
    }
    public override string Info() //виведення
    {
        return $"Погодинний робітник: Години: {hours}, Вартість 1 години: " +
            $"{cost:C2}, Зарплата: {salary:C2}, Премія: {prize:C2}";
    }
    public override void SalaryA() //зарплата
    {
        salary = hours * cost;
    }
    public override void PrizeA() //премія
    {
        prize = 2000;
    }
}
class PercentWork : Worker //дочірній клас
{
    private double sales; //сума продажу
    public PercentWork(double sales) //конструктор
    {
        this.sales = sales;
    }
    public override string Info() //виведення
    {
        return $"Робітник на відсотку від продажів: Сума продажу:" +
            $" {sales:C2}, Зарплата: {salary:C2}, Премія: {prize:C2}";
    }
    public override void SalaryA() //зарплата
    {
        salary = sales * 0.10;
    }
    public override void PrizeA() //премія
    {
        prize = salary * 0.20;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Random rand = new Random();
        for (int i = 0; i < 5; i++)
        {
            int workerType = rand.Next(1, 4);
            Worker worker = null; //створення об'єкта
            switch (workerType)
            {
                case 1: //робітник на ставці
                    double rate = rand.Next(1000, 5000);
                    worker = new BetWork(rate);
                    break;
                case 2: //погодинний робітник 
                    int hours = rand.Next(80, 200);
                    double cost = rand.Next(10, 20);
                    worker = new HourWork(hours, cost);
                    break;
                case 3: //робітник на відсотках
                    double sales = rand.Next(5000, 20000);
                    worker = new PercentWork(sales);
                    break;
            }
            worker.SalaryA();
            worker.PrizeA();
            //для виведення знаку гривні
            Console.OutputEncoding = System.Text.Encoding.UTF8; 
            Console.WriteLine(worker.Info());
            Console.WriteLine();
        }
    }
}
