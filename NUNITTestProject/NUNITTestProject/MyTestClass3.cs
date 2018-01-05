using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUNITTestProject
{
    [TestFixture]
    public class MyTestClass5
    {
        [Test, TestCaseSource("DataSuppy")]
        public void TestMethod5(String username, String password, String email, String city)
        {
            Console.WriteLine(username + "--" + password + "--" + email + "--" + city );
        }

        public static object[] DataSuppy()
        {
            object[][] data = new object[4][];

            data[0] = new object[4];
            data[0][0] = "user0";
            data[0][1] = "pass0";
            data[0][2] = "email0";
            data[0][3] = "city0";

            data[1] = new object[4];
            data[1][0] = "user1";
            data[1][1] = "pass1";
            data[1][2] = "email1";
            data[1][3] = "city1";

            data[2] = new object[4];
            data[2][0] = "user2";
            data[2][1] = "pass2";
            data[2][2] = "email2";
            data[2][3] = "city2";

            //data[3] = new object[4];
            //data[3][0] = "user3";
            //data[3][1] = "pass3";
            //data[3][2] = "email3";
            //data[3][3] = "city3";

            return data;
        }
    }
}
