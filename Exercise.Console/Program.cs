using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Devices;

namespace Exercise.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //var a = exercise1(36);
            // exercise2(AppDomain.CurrentDomain.BaseDirectory+"exercise2.txt", AppDomain.CurrentDomain.BaseDirectory+"copy\\","newName.txt");

            // var c = exercise3(10, 1, 1, 3);
            exercise4();
            System.Console.ReadLine();
        }
        /// <summary>
        /// 1.输入任意一个整数a， 输出所有2个整数相乘的积为a的所有组合
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        static Dictionary<int, int> exercise1(int input)
        {
            var result = new Dictionary<int, int>();
            if (input == 0)
            {
                return result;
            }

            if (input > 0)
            {
                for (int i = -input; i < input; i++)
                {
                    if (i == 0)
                    {
                        continue;
                    }
                    var y = input % i;

                    if (y == 0)
                    {
                        var z = input / i;
                        result.Add(z, i);
                         
                    }
                }

            }
            if (input < 0)
            {
                for (int i = input; i < -input; i++)
                {
                    if (i == 0)
                    {
                        continue;
                    }
                    var y = input % i;

                    if (y == 0)
                    {
                        var z = input / i;
                        result.Add(z, i);
                    }
                }

            }

            return result;

        }
        /// <summary>
        /// 2.编程实现对一个大文件(大小超过100M)的重命名， 复制， 和删除
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="copyFileDirectory"></param>
        static void exercise2(string filePath,string copyFileDirectory,string newName) {
            if (!File.Exists(filePath)) {
                return;
            }

            if (!Directory.Exists(copyFileDirectory)) {
                Directory.CreateDirectory(copyFileDirectory);
            }
            FileInfo file = new FileInfo(filePath);
            //复制
            File.Copy(filePath, copyFileDirectory+file.Name, true);

            //重命名                      
            try
            {
                Computer MyComputer = new Computer();
                MyComputer.FileSystem.RenameFile(filePath, newName);
            }
            catch (IOException e) { 
            
            //已存在
            }
            
            //删除
            File.Delete(filePath);

        }
        /// <summary>
        /// 3.写一个递归计算：一个用户做投资, 起始资金为money, 每年的投资收益率是b(b>0), 每年追加的钱为add, n年后的账户总额是多少?
        /// </summary>
        static decimal exercise3(decimal money,decimal b, int add,int n) {
            var result = money + money * b;
            n--;
            if (n== 0) {
                return result;
            }
            return exercise3(result+add,b,add,n);
        }
        /// <summary>
        /// 4.先准备一个任意的纯文本文件，
        /// 预先输入任意内容，编程实现输出， 文件的大小, 创建时间, 
        /// 一共有多少字符， 有多少个字母， 多少个数字， 
        /// 多少个符号， 多少个空格
        /// </summary>
        static void exercise4() {
            string filePath= AppDomain.CurrentDomain.BaseDirectory + "exercise4.txt";
            FileInfo fi = new FileInfo(filePath);
            System.Console.WriteLine($"文件的大小:" + System.Math.Ceiling(fi.Length / 1024.0) + " KB");
            System.Console.WriteLine($"创建时间：{fi.CreationTime.ToString("yyyy-MM-dd HH:mm:ss")}");

            string text = File.ReadAllText(filePath);
            
            System.Console.WriteLine($"字符个数：{_strLength(text)}");
            
            var zm = Regex.Matches(text, "[a-zA-Z]");
            System.Console.WriteLine($"字母个数：{zm.Count}");

            var sz = Regex.Matches(text, "[0-9]");
            System.Console.WriteLine($"数字个数：{sz.Count}");
             

            var kg = Regex.Matches(text, "\\s");
            System.Console.WriteLine($"空格：{kg.Count}");

        }

        /// <summary>
        /// 得到字符串长度，一个汉字长度为2
        /// </summary>
        /// <param name="inputString">参数字符串</param>
        /// <returns></returns>
        static int _strLength(string inputString)
        {
            System.Text.ASCIIEncoding ascii = new System.Text.ASCIIEncoding();
            int tempLen = 0;
            byte[] s = ascii.GetBytes(inputString);
            for (int i = 0; i < s.Length; i++)
            {
                if ((int)s[i] == 63)
                    tempLen += 2;
                else
                    tempLen += 1;
            }
            return tempLen;
        }
    }
}
