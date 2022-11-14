class main
{
     static void Main(string[] args)
    {
        sum obj = new sum();
        obj.Assign();
        obj.add();
    }
}
class sum
{
    int a,b;
    public void Assign() { 
        a=10;
        b=20;
    }
    public void add()
    {
        Console.WriteLine("Sum is " + (a + b));
    }
}