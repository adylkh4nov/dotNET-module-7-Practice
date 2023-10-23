using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    using ClassLibrary1;
    using System;

    namespace YourNamespace
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Примеры для класса MyCustomClass
                MyCustomClass obj1 = new MyCustomClass { Property1 = 1, Property2 = "A" };
                MyCustomClass obj2 = new MyCustomClass { Property1 = 1, Property2 = "A" };
                MyCustomClass obj3 = new MyCustomClass { Property1 = 2, Property2 = "B" };

                Console.WriteLine("MyCustomClass:");
                Console.WriteLine("obj1 == obj2: " + (obj1 == obj2)); // true
                Console.WriteLine("obj1 != obj3: " + (obj1 != obj3)); // true
                Console.WriteLine("obj2 == obj3: " + (obj2 == obj3)); // false
                Console.WriteLine("obj1.Equals(obj2): " + obj1.Equals(obj2)); // true

                // Примеры для класса MyArrayContainer
                MyArrayContainer array1 = new MyArrayContainer(new int[] { 1, 2, 3 });
                MyArrayContainer array2 = new MyArrayContainer(new int[] { 4, 5, 6 });
                MyArrayContainer array3 = new MyArrayContainer(new int[] { 7, 8, 9 });

                Console.WriteLine("\nMyArrayContainer:");
                Console.WriteLine("array1 < array2: " + (array1 < array2)); // true
                Console.WriteLine("array1 > array3: " + (array1 > array3)); // false

                // Примеры для класса MoneyConverter
                MoneyConverter money1 = new MoneyConverter { Amount = 100, Currency = "USD" };
                MoneyConverter money2 = new MoneyConverter { Amount = 50, Currency = "USD" };
                MoneyConverter money3 = new MoneyConverter { Amount = 50, Currency = "EUR" };

                Console.WriteLine("\nMoneyConverter:");
                Console.WriteLine("money1 + money2: " + (money1 + money2)); // 150
                Console.WriteLine("money1 == money2: " + (money1 == money2)); // false
                Console.WriteLine("money2 != money3: " + (money2 != money3)); // true

                // Примеры для класса MyArrayOperator
                MyArrayOperator arr1 = new MyArrayOperator(new long[] { 1, 2, 3 });
                MyArrayOperator arr2 = new MyArrayOperator(new long[] { 1, 2, 3 });
                MyArrayOperator arr3 = new MyArrayOperator(new long[] { 4, 5, 6 });

                Console.WriteLine("\nMyArrayOperator:");
                Console.WriteLine("arr1 == arr2: " + (arr1 == arr2)); // true
                Console.WriteLine("arr1 != arr3: " + (arr1 != arr3)); // true
                Console.WriteLine("arr1 * arr2: " + (arr1 * arr2)); // 14
                Console.WriteLine("arr2 * arr3: " + (arr2 * arr3)); // 30

                // Примеры для класса UnsignedDecimal (перегрузка операторов +, -, *)
                UnsignedDecimal decimal1 = new UnsignedDecimal("1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890");
                UnsignedDecimal decimal2 = new UnsignedDecimal("9876543210987654321098765432109876543210987654321098765432109876543210987654321098765432109876543210");

                Console.WriteLine("\nUnsignedDecimal:");
                UnsignedDecimal sum = decimal1 + decimal2;
                UnsignedDecimal difference = decimal1 - decimal2;
                UnsignedDecimal product = decimal1 * decimal2;

                Console.WriteLine("Sum: " + sum.ToString());
                Console.WriteLine("Difference: " + difference.ToString());
                Console.WriteLine("Product: " + product.ToString());
            }
        }
    }

}
