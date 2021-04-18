using System;
using System.Reflection.Metadata.Ecma335;


/*----------------------------Lecture 19--------------------------------------*/


namespace Lecture19
{
    delegate int MathOperation(int x, int y);
    delegate void MyDelegate();
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("---Delegate Example---");

            MathOperation op = delegate (int x, int y) {
                Console.WriteLine("Add");
                return x + y;
            };
            //lambda Statement
            op += (x, y) => {
                Console.WriteLine("Subtract");
                return x - y;
            };

            //Lambda Expression
            op += (x, y) => x * y;

            MyDelegate d1 = () => Console.WriteLine("AOA...");

            d1();
            /*MyDelegate d1 = delegate () {
                Console.WriteLine("I am in anonymous method");
            };
            d1();*/
            Console.WriteLine(op(2, 3));
            /*MathOperation op = Calculator.Add;
            //int result = op(6, 3);
            //Console.WriteLine($"result : {result}");
            op += Calculator.Subtract;
            op += Calculator.Multiply;
            int result = op(5, 4);
            Console.WriteLine(result);
            op -= Calculator.Subtract;
             result = op(5, 4);
            Console.WriteLine(result);*/

        }
    }
}

/*----------------------------Lecture 20--------------------------------------*/



/*
Microsoft introduced some pre-built delegates so that we don't have to declare delegates
every time. Action is one of the pre-built delegates.
Action in C# represents a delegate that has void return type and optional parameters. 
There are two variants of Action delegate.
1-Action
2-Action<in T>
1- Action
First variant is non-generic delegate that takes no parameters and has void return type. 
In this Action delegate, we can store only those methods which has no parameters and 
void return type.
2- Action<in T>
The second variant is a family of 16 generic delegates.
These delegates can take upto 16 parameters and all have void return type.
 //
namespace Lecture20
{
    class Program
    {
        public static void DoWorkWithOneParameter(int arg)
        {
            Console.WriteLine(arg);
        }
        public static void DoWorkWithTwoParameters(int arg1, int arg2)
        {
            Console.WriteLine(arg1 + "-" + arg2);
        }
        public static void DoWorkWithThreeParameters(int arg1, int arg2, int arg3)
        {
            Console.WriteLine(arg1 + "-" + arg2 + "-" + arg3);
        }
        public static void DoWork()
        {
            Console.WriteLine("Hi, I am doing work.");
        }
        static void Main(string[] args)
        {
            Action doWorkAction = new Action(DoWork);
            doWorkAction(); //Print "Hi, I am doing work."
            Action<int> firstAction = DoWorkWithOneParameter;
            Action<int, int> secondAction = DoWorkWithTwoParameters;
            Action<int, int, int> thirdAction = DoWorkWithThreeParameters;
            firstAction(1); // Print 1
            secondAction(1, 2); // Print 1-2
            thirdAction(1, 2, 3); //Print 1-2-3
        }
    }
}*/





/*----------------------------Lecture 21--------------------------------------*/


//using System;
//using Microsoft.Data.SqlClient;
//namespace Lecture21
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
//            SqlConnection con = new SqlConnection(connString);
//            con.Open();
//            string query = "Select * from person";
//            SqlCommand cmd = new SqlCommand(query, con);
//            SqlDataReader dr = cmd.ExecuteReader();
//            while (dr.Read())
//            {
//                Console.WriteLine($"id : {dr.GetValue(0)}, Name: {dr[1]}, Age: {dr.GetValue(2)}");
//            }
//            con.Close();
//        }
//    }
//}




/*-----------------------------------Lecture 22--------------------------------*/

//using System;
//using Microsoft.Data.SqlClient;
//namespace Lecture22
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyNewDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
//            SqlConnection connection = new SqlConnection(conString);
//            Console.Write("Enter User Name: ");
//            string userName = Console.ReadLine();
//            //Console.Write("Enter Password");
//            //string pwd = Console.ReadLine();

//            //string query = "insert into Users(UserName, Password) values('admin','123')";
//            //string query = $"insert into Users(UserName, Password) values('{userName}','{pwd}')";
//            //string query = $"Update  Users set Password ='{pwd}' where username  = '{userName}'";
//            string query = $"delete from  Users where username  = '{userName}'";
//            SqlCommand cmd = new SqlCommand(query, connection);
//            connection.Open();
//            int insertedRows = cmd.ExecuteNonQuery();
//            if (insertedRows >= 1)
//            {
//                Console.WriteLine("row inserted/updated/deleted");

//            }
//            else
//            {
//                Console.WriteLine("failed");

//            }
//            connection.Close();
//        }
//    }
//}



/*-----------------------------------Lecture 23--------------------------------*/

//using System;
//using Microsoft.Data.SqlClient;
//namespace Lecture22
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyNewDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
//            SqlConnection connection = new SqlConnection(conString);
//            Console.Write("Enter User Name: ");
//            string userName = Console.ReadLine();
//            // Console.Write("Enter Password: ");
//            // string pwd = Console.ReadLine();


//            /*string query = $"select * from users " +
//                $"where username = @u and password = @p";*/
//            /*string query = $"insert into users (username, password)" +
//                $"  values(@u,@p)";//*/
//            //string query = $"update users set password=@p where username=@u";
//            string query = $"delete from users where username=@u";
//            SqlParameter p1 = new SqlParameter("u", userName);
//            //SqlParameter p2 = new SqlParameter("p", pwd);
//            SqlCommand cmd = new SqlCommand(query, connection);
//            cmd.Parameters.Add(p1);
//            // cmd.Parameters.Add(p2);
//            connection.Open();
//            cmd.ExecuteNonQuery();
//            /*SqlDataReader dr = cmd.ExecuteReader();
//            if (dr.HasRows)
//            {
//                Console.WriteLine("User Authenticated");
//            }
//            else {
//                Console.WriteLine("Invalid User name or Password");
//            }*/

//            connection.Close();
//        }
//    }
//}