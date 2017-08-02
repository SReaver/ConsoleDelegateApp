using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDelegateApp
{
   

    class Program
    {
        delegate void GetMessage(); // 1. Объявляем делегат

        delegate int Operation(int x, int y);

        delegate int Square(int x); // объявляем делегат, принимающий int и возвращающий int


        static void Main(string[] args)
        {
            #region
            //GetMessage del; // 2. Создаем переменную делегата

            //if (DateTime.Now.Hour < 12)
            //{
            //    del = GoodMorning; // 3. Присваиваем этой переменной адрес метода
            //}
            //else
            //{
            //    del = GoodEvening;
            //}

            //del.Invoke(); // 4. Вызываем метод



            //// присваивание адреса метода через контруктор
            //Operation del = new Operation(Add); // делегат указывает на метод Add

            //int result = del.Invoke(4, 5);
            //Console.WriteLine(result);

            //// присваивание адреса метода через метод
            //del = Multiply; // теперь делегат указывает на метод Multiply
            //result = del.Invoke(4, 5);
            //Console.WriteLine(result);




            ////делегат можно вызывать как обычный метод, передавая ему аргументы.
            //if (DateTime.Now.Hour < 12)
            //{
            //    Show_Message(GoodMorning);
            //}
            //else
            //{
            //    Show_Message(GoodEvening);
            //}
            #endregion

            #region 


            //EXMPL 1
            //наиболее сильная сторона делегатов состоит в том, что они позволяют создать функционал методов обратного вызова, 
            //уведомляя другие объекты о произошедших событиях
            //Допустим, в случае вывода денег с помощью метода Withdraw нам надо как-то уведомлять об этом самого клиента и, может быть, другие объекты.

            // создаем банковский счет
            //Account account = new Account(200, 6);
            //// Добавляем в делегат ссылку на метод Show_Message
            //// а сам делегат передается в качестве параметра метода RegisterHandler
            //account.RegisterHandler(Show_Message); //Поскольку делегат объявлен внутри класса Account
            //// Два раза подряд пытаемся снять деньги
            //account.Withdraw(100);
            //account.Withdraw(150);


            //Таким образом, мы создали механизм обратного вызова для класса Account, который срабатывает в случае снятия денег. 
            //Опять же может возникнуть вопрос: почему бы к коде метода Withdraw() не выводить сообщение о снятии денег? Зачем нужно задействовать какой-то делегат?
            //Дело в том, что не всегда у нас есть доступ к коду классов. Например, часть классов может создаваться и компилироваться одним человеком, 
            //который не будет знать, как эти классы будут использоваться. А использовать эти классы будет другой разработчик.
            //Так, здесь мы выводим сообщение на консоль. Однако для класса Account не важно, как это сообщение выводится. 
            //Классу Account даже не известно, что вообще будет делаться в результате списания денег. Он просто посылает уведомление об этом через делегат.


            //EXMPL 2
            //Хотя в примере наш делегат принимал адрес на один метод, в действительности он может указывать сразу на несколько методов. 

            //account = new Account(200, 6);
            //Account.AccountStateHandler colorDelegate = new Account.AccountStateHandler(Color_Message);

            //// Добавляем в делегат ссылку на методы
            //account.RegisterHandler(new Account.AccountStateHandler(Show_Message));
            //account.RegisterHandler(colorDelegate);
            //// Два раза подряд пытаемся снять деньги
            //account.Withdraw(100);
            //account.Withdraw(150);

            //// Удаляем делегат
            //account.UnregisterHandler(colorDelegate);
            //account.Withdraw(50);

            #endregion


            //GetMessage message = delegate
            //{
            //    Console.WriteLine("анонимный делегат");
            //};
            //message();

            //Operation op = delegate (int x, int y)
            //{
            //    return x * y;
            //};

            // var t =   op(5, 6);
            //Console.WriteLine(t);
            //Console.ReadLine();


            //Лямбда-выражения представляют упрощенную запись анонимных методов.

            // объекту делегата присваивается лямбда-выражение
            // i - это параметр
            //i*i - выражение
            Square squareInt = i => i * i;
            int z = squareInt(6); // используем делегат
            Console.WriteLine(z); // выводит число 36

            //параметров не требуется
            GetMessage message = () => { Console.WriteLine("Лямбда-выражение"); };

            //ссылку на метод

            GetMessage GetMessage = () => GoodMorning();

            GetMessage();








            //int[] integers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            //// найдем сумму чисел больше 5
            //int result1 = Sum(integers, x => x > 5);
            //Console.WriteLine(result1); // 30

            //// найдем сумму четных чисел
            //int result2 = Sum(integers, x => x % 2 == 0);
            //Console.WriteLine(result2);  //20

            //Console.Read();

            Console.ReadLine();
        }

        private static void GoodMorning()
        {
            Console.WriteLine("Good Morning");
        }
        private static void GoodEvening()
        {
            Console.WriteLine("Good Evening");
        }




        private static int Add(int x, int y)
        {
            return x + y;
        }
        private static int Multiply(int x, int y)
        {
            return x * y;
        }



        private static void Show_Message(GetMessage _del)
        {
            _del.Invoke();
        }



        private static void Show_Message(String message)
        {
            Console.WriteLine(message);
        }

        private static void Color_Message(string message)
        {
            // Устанавливаем красный цвет символов
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            // Сбрасываем настройки цвета
            Console.ResetColor();
        }



        //private static int Sum(int[] numbers, IsEqual func)
        //{
        //    int result = 0;
        //    foreach (int i in numbers)
        //    {
        //        if (func(i))
        //            result += i;
        //    }
        //    return result;
        //}
    }
}
