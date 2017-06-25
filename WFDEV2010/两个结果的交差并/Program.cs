using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 两个结果的交差并
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Sfxm> lsit1 = new List<Sfxm> 
            {
              new Sfxm{ Xmdj="12", Xmdm="X123", Xmmc="Abc"},
               new Sfxm{ Xmdj="122", Xmdm="X1243", Xmmc="Abcdd"},
                new Sfxm{ Xmdj="142", Xmdm="X1263", Xmmc="Abddc"}
            };
            List<Sfxm> lsit2 = new List<Sfxm> 
            {
              new Sfxm{ Xmdj="12", Xmdm="X123", Xmmc="Abc"},
               new Sfxm{ Xmdj="12112", Xmdm="X1243", Xmmc="Abcdd"},
            };
            List<Sfxm> tmp = lsit1.Except(lsit2,new CompareMy()).ToList<Sfxm>();
            List<Sfxm> tmp1 = lsit2.Except(lsit1, new CompareMy()).ToList<Sfxm>();
            //var bingji = oneStudents.Union(twoStudents, new StudentListEquality()).ToList();//并（全）集 
           // var jiaoji = oneStudents.Intersect(threeStudents, new StudentListEquality()).ToList();//交集 
           // var chaji = oneStudents.Except(threeStudents, new StudentListEquality()).ToList();//差集
            Console.Read();
        }
   
    }
    public class CompareMy:IEqualityComparer<Sfxm>
    {

        public bool Equals(Sfxm x, Sfxm y)
        {
            return x.Xmdm == y.Xmdm && x.Xmdj== y.Xmdj;
        }

        public int GetHashCode(Sfxm obj)
        {
            if (obj==null)
            {
                return 0;
            }
            else
            {
                return obj.ToString().GetHashCode();
            }
        }


    }
    public class Sfxm
    {
        public string Xmdm { get; set; }
        public string Xmmc { get; set; }
        public string Xmdj { get; set; }
    }
}
