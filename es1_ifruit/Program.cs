using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace es1_ifruit
{
    class Program
    {
        static void Main(string[] args)
        {
            var basket = new List<IFruit>();
            var seed = new Random(DateTime.Now.Second);

            for (int i = 0; i < 10; i++)
            {
                switch(seed.Next(0, 3))
                {
                    case 0:
                        basket.Add(new Ananas());
                        break;
                    case 1:
                        basket.Add(new Apple());
                        break;
                    case 2:
                        basket.Add(new Orange());
                        break;
                }
                
            }

            var quantityForType = new Dictionary<string, int>();

            foreach (var item in basket)
            {
                if (quantityForType.ContainsKey(item.getName()))
                    quantityForType[item.getName()]++;
                else
                    quantityForType.Add(item.getName(), 1);
            }

            ObjectHandle handle;
            IFruit fruit;

            Console.WriteLine("fruit - n - subtotal\n");
            foreach (var item in quantityForType)
            {
                handle = Activator.CreateInstance(null, "es1_ifruit." + item.Key);
                fruit = (IFruit)handle.Unwrap();

                Console.WriteLine(item.Key + " - " + item.Value.ToString() + " - " + fruit.getPrice() * item.Value);
            }

            Console.WriteLine();

            double sum = 0;
            foreach (var item in basket)
            {
                Console.WriteLine(item.getName());
                sum += item.getPrice();
            }

            Console.WriteLine("\ntotal: " + sum);

            ConsoleKeyInfo select;
            double tot = 0;
            int n;
            do
            {
                Console.WriteLine("\n1)ananas 2)apple 3)orange 9)total 0)exit");
                select = Console.ReadKey();
                switch (select.KeyChar)
                {
                    case '1':
                        Console.WriteLine("\nquantity: ");
                        try
                        {
                            n = Convert.ToInt32(Console.ReadLine());
                            if (n > 0)
                                tot += (new Ananas().getPrice() * n);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("\nquantity NOT correct !");
                            Console.Beep(1000, 1000);
                        }
                        break;
                    case '2':
                        Console.WriteLine("\nquantity: ");
                        try
                        {
                            n = Convert.ToInt32(Console.ReadLine());
                            if (n > 0)
                                tot += (new Apple().getPrice() * n);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("\nquantity NOT correct !");
                        }
                        break;
                        break;
                    case '3':
                        Console.WriteLine("\nquantity: ");
                        try
                        {
                            n = Convert.ToInt32(Console.ReadLine());
                            if (n > 0)
                                tot += (new Orange().getPrice() * n);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("nquantity NOT correct !");
                        }
                        break;
                    case '9':
                        Console.WriteLine("\n" + tot + " euro");
                        break;
                    case '0':
                        return;
                    default:
                        Console.WriteLine("\nselect error !");
                        break;
                }
            } while (true);
        }
    }
}
