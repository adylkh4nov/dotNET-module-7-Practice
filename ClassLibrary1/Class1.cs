using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class MyCustomClass
    {
        public int Property1 { get; set; }
        public string Property2 { get; set; }

        public static bool operator ==(MyCustomClass a, MyCustomClass b)
        {
            return a.Property1 == b.Property1 && a.Property2 == b.Property2;
        }

        public static bool operator !=(MyCustomClass a, MyCustomClass b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if (obj is MyCustomClass other)
            {
                return this == other;
            }
            return false;
        }
    }
    public class MyArrayContainer
    {
        private int[] data;

        public MyArrayContainer(int[] array)
        {
            data = array;
        }

        public static bool operator <(MyArrayContainer a, MyArrayContainer b)
        {
            return a.data.Sum() < b.data.Sum();
        }

        public static bool operator >(MyArrayContainer a, MyArrayContainer b)
        {
            return a.data.Sum() > b.data.Sum();
        }
    }
    public class MoneyConverter
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }

        public static decimal operator +(MoneyConverter a, MoneyConverter b)
        {
            return a.Amount + b.Amount;
        }

        public static bool operator ==(MoneyConverter a, MoneyConverter b)
        {
            return a.Amount == b.Amount && a.Currency == b.Currency;
        }

        public static bool operator !=(MoneyConverter a, MoneyConverter b)
        {
            return !(a == b);
        }
    }
    public class MyArrayOperator
    {
        private long[] data;

        public MyArrayOperator(long[] array)
        {
            data = array;
        }

        public long this[int index]
        {
            get { return data[index]; }
            set { data[index] = value; }
        }
        public static bool operator ==(MyArrayOperator a, MyArrayOperator b)
        {

            if (a.data.Length != b.data.Length)
                return false;

            for (int i = 0; i < a.data.Length; i++)
            {
                if (a.data[i] != b.data[i])
                    return false;
            }

            return true;
        }

        public static bool operator !=(MyArrayOperator a, MyArrayOperator b)
        {
            return !(a == b);
        }

        public static long operator *(MyArrayOperator a, MyArrayOperator b)
        {
            long sum = 0;
            for (int i = 0; i < a.data.Length; i++)
            {
                sum *= a.data[i];
            }
            for (int i = 0; i < b.data.Length; i++)
            {
                sum *= b.data[i];
            }
            return sum;
        }

        public static bool operator true(MyArrayOperator a)
        {

            for (int i = 0; i < a.data.Length; i++)
            {
                if (a.data[i] == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool operator false(MyArrayOperator a)
        {
            return false;
        }
    }


public class UnsignedDecimal
    {
        private char[] digits = new char[1000];

        public UnsignedDecimal(string value)
        {
            if (value.Length != 100)
                throw new ArgumentException("Input value must be 100 characters long.");
            if (!value.All(char.IsDigit))
                throw new ArgumentException("Input value must contain only decimal digits.");
            for (int i = 0; i < 100; i++)
            {
                digits[i] = value[i];
            }
        }

        public override string ToString()
        {
            return new string(digits);
        }
        public static UnsignedDecimal operator +(UnsignedDecimal a, UnsignedDecimal b)
        {
            char[] result = new char[100];
            int carry = 0;

            for (int i = 99; i >= 0; i--)
            {
                int digitA = a.digits[i] - '0';
                int digitB = b.digits[i] - '0';
                int sum = digitA + digitB + carry;

                result[i] = (char)((sum % 10) + '0');
                carry = sum / 10;
            }

            return new UnsignedDecimal(new string(result));
        }

        public static UnsignedDecimal operator -(UnsignedDecimal a, UnsignedDecimal b)
        {
            char[] result = new char[100];
            int borrow = 0;

            for (int i = 99; i >= 0; i--)
            {
                int digitA = a.digits[i] - '0' - borrow;
                int digitB = b.digits[i] - '0';

                if (digitA < digitB)
                {
                    digitA += 10;
                    borrow = 1;
                }
                else
                {
                    borrow = 0;
                }

                int diff = digitA - digitB;
                result[i] = (char)(diff + '0');
            }

            return new UnsignedDecimal(new string(result));
        }

        public static UnsignedDecimal operator *(UnsignedDecimal a, UnsignedDecimal b)
        {
            // Реализация умножения десятичных чисел
            char[] result = new char[200]; // Максимальная длина результата - сумма длин множителей

            // Инициализация результата нулями
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = '0';
            }

            // Перебор цифр в обратном порядке, начиная с последних цифр множителей
            for (int i = 99; i >= 0; i--)
            {
                int digitA = a.digits[i] - '0';
                int carry = 0;

                for (int j = 99; j >= 0; j--)
                {
                    int digitB = b.digits[j] - '0';
                    int product = digitA * digitB + carry + (result[i + j + 1] - '0');
                    carry = product / 10;
                    result[i + j + 1] = (char)((product % 10) + '0');
                }
            }

            return new UnsignedDecimal(new string(result, 1, 100)); // Пропускаем первый символ (нулевой разряд)
        }

    }
}
