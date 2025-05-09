﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace DeliverySimulator
{
    public class Db
    {
        public static List<Courier> couriers=new List<Courier>();
        public static List<Package> packages=new List<Package>();

        public static void GetData() //iei date din fisier
        {
            couriers.Clear();
            packages.Clear();

            StreamReader sr = new StreamReader("couriers.txt");
            string line;
            while((line = sr.ReadLine()) != null)
            {
                string[] fields = line.Split(';');

                Courier.circle zona = new Courier.circle(new Point(Convert.ToInt32(fields[2]),
                    Convert.ToInt32(fields[3])), Convert.ToInt32(fields[4]));

                couriers.Add(new Courier(Convert.ToInt16(fields[0]), fields[1],zona));
            }
            sr.Close();

            sr = new StreamReader("streets.txt"); //in fisierul asta ai asssigned streets pt fiecare curier
            while ((line = sr.ReadLine()) != null)
            {
                string[] fields = line.Split(';');

                couriers[Convert.ToInt16(fields[0])].assignedStreets.Add(fields[1]);
            }
            sr.Close();

            sr = new StreamReader("packages.txt");
            while ((line = sr.ReadLine()) != null)
            {
                string[] fields = line.Split(';');

                Package.adr adresa= new Package.adr(fields[2], Convert.ToInt16(fields[3]));
                Point locatie = new Point(Convert.ToInt16(fields[4]), Convert.ToInt16(fields[5]));

                packages.Add(new Package(Convert.ToInt16(fields[0]),fields[1], adresa, locatie, Convert.ToBoolean(fields[6])));
            }
            sr.Close();
        }

        public static void SaveData() //salvezi date in fisier
        {
            using(StreamWriter sr = new StreamWriter("couriers.txt", false))
            {
                foreach (Courier courier in couriers)
                {
                    sr.WriteLine(courier.ToString());
                }
            }
            using (StreamWriter sr = new StreamWriter("streets.txt", false))
            {
                foreach (Courier courier in couriers)
                {
                    foreach(string street in courier.assignedStreets)
                    {
                        sr.WriteLine(courier.id + ";" + street);
                    }
                }
            }
            using (StreamWriter sr = new StreamWriter("packages.txt", false))
            {
                foreach (Package package in packages)
                {
                    sr.WriteLine(package.ToString());
                }
            }
        }
    }
}
