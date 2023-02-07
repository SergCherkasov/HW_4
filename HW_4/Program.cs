using HW_4.UserInterface;
using static HW_4.UserInterface.UInterface;

namespace HW_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UInterface uInterface= new UInterface(new ConsoleIO());
            uInterface.Calculate();
        }
    }
}