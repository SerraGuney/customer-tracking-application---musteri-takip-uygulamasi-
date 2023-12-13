using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp21
{
    internal class Program
    {
        abstract class Customer
        {
            public static  string name, surname, email, phnumber;
            public double bill;
            public void SetİnformationWrite(string a, string s, string e, string t,double h)
            {
                name = a;
                surname= s;
                email = e;
                phnumber = t;
                bill = h;
            }
            public override string ToString()
            {
                string information = string.Format("name:{0}\n surname:{1}\n email:{2}\n phone number:{3}\n hesabi:{4}", name, surname, email, phnumber,bill);
                return information;
            }
            public void SetBill(double b)
            {
                bill = b;

            }
            public double GetBill()
            {
                return bill;
            }
            public abstract void billİnformation(double bill1);
            public abstract void discountBill(double discount);

        }
        class vipCustomer : Customer
        {
            public vipCustomer(string a, string s, string e, string t, int h)
            {
                base.SetİnformationWrite(a, s, e, t, h);

            }

            public override void discountBill(double discount)
            {
                base.SetBill(GetBill()*discount);
            }

            public override void billİnformation(double bill1)
            {
                base.SetBill(GetBill());
            }

        }
        interface ICustomerManagement
        {
            void informationEnter();
            void informationDelete();

        }
        class CustomerManagemntService : ICustomerManagement
        {
            public static List<string> list = new List<string>();
            public void informationEnter()
            {
                Console.Write("How many customers will you add?:");
                int customerNumber = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < customerNumber; i++)
                {
                    Console.Write("name of customer:");
                    string names = Console.ReadLine();
                    Console.Write("surname of customer:");
                    string surnames = Console.ReadLine();
                    Console.Write("email of customer:");
                    string emails = Console.ReadLine();
                    Console.Write("phone number of customer:");
                    string phoneNumbers = Console.ReadLine();
                    Console.WriteLine(" ");
                    list.Add(names);
                    list.Add(surnames);
                    list.Add(emails);
                    list.Add(phoneNumbers);

                }
                foreach (string s in list)
                {
                    
                    Console.WriteLine(s);
                }
            }
            public void informationDelete()
            {
                Console.Write("How many customers will you delete?: ");
                int personNumber=Convert.ToInt32(Console.ReadLine());
                for(int i = 0; i < personNumber; i++)
                {
                    Console.Write("name of the person to be deleted:");
                    string name=Console.ReadLine();
                    list.Remove(name);
                }
                foreach(string s in list)
                {
                    Console.WriteLine(s);
                }
            }
            static void Main(string[] args)
            {
                ICustomerManagement ım = new CustomerManagemntService();
                ım.informationEnter();
                ım.informationDelete();
                Customer m = new vipCustomer("serra","guney","guneyserra2@gmailcom","123456777",10000);
                Console.WriteLine(m.ToString());
                Console.WriteLine(" ");
                m.billİnformation(1000);
                m.discountBill(0.25);
                Console.WriteLine(" ");
                Console.WriteLine(m.ToString());
                Console.ReadLine();
            }

            
        }
    }
}
