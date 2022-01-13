using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnDelegate2
{
    class Item
    {

        public Item() { }
    }

    class Marine
    {
        private int hp;
        private int maxHP;
        public Action OnDie;
        public Marine(int maxHp)
        {
            this.maxHP = maxHp;
            this.hp = this.maxHP;

        }
        public void Hit(int damage)
        {
            this.hp -= damage;
            if(this.hp <= 0)
            {
                this.OnDie();
            }
        }

    }
    class App
    {
        public delegate void DelSayHello();
        public delegate void Del(string message);

        delegate void Delegate1();
        delegate void Delegate2();
        delegate void Delegate3();

        private Action action;
        private Func<string> func;

        Func<int, int> square = x => x * x;


        public App()
        {
            Marine marine = new Marine(10);
            marine.OnDie = () =>
            {
                Console.WriteLine("마린이 죽었습니다.");
            };
            marine.Hit(5);
            marine.Hit(5);
        }

        /*
        public App()
        {
            
            Console.WriteLine(square(5));
        }



        /*
        public App()
        {
            //action = this.SayHello;
            //action();
            this.func = this.Helloo;
            string message = this.func();
            Console.WriteLine(message);
        }


        /*
        public App()
        {
            Delegate1 d1 = this.Hello;
            Delegate2 d2 = this.World;
            Delegate3 d3 = this.Say;
            this.Method(d1, d2, (Delegate)d3);
        }

        /*
        public App()
        {
            var obj = new MethodClass();
            Del d1 = obj.Method1;
            Del d2 = obj.Method2;
            Del d3 = this.DelegateMethod;

            Del allMethodsDelegate = d1 + d2;
            allMethodsDelegate += d3;
            allMethodsDelegate -= d1;
            //allMethodsDelegate("Hello World!");

            Del oneMethodDelgate = allMethodsDelegate - d2;

            //oneMethodDelgate("hello~");
            //d1("hello");
        }
        /*
        public App()
        {
            //Console.WriteLine("Hello World!");
            DelSayHello handler = this.SayHello;
            handler();
        }
        */

        public void SayHello()
        {
            Console.WriteLine("Hello Delegate");
        }

        private void DelegateMethod(string message)
        {
            Console.WriteLine("DelegateMethod :" + message);
        }

        private void Hello() { }
        private void World() { }
        private void Say() { }
        private void Method(Delegate1 d,Delegate2 e,Delegate f)
        {
            // Compile-time error.
            //Console.WriteLine(d == e);

            // OK at compile-time. False if the run-time type of f
            // is not the same as that of d.
            Console.WriteLine((Delegate)d == f);
        }

        private string Helloo() 
        {
            return "Hello world!";
        }
    }
}
