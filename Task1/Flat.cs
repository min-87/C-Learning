using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
     class Flat
    {
        private double Area;
        private int Rooms;
        private int CountResidents;
        private string Address;

        public Flat(double area, int rooms, int countResidents, string address) {
            Area = area;
            Rooms = rooms;
            CountResidents = countResidents;
            Address = address;
        }
        public Flat() {
            Area = 120.5;
            Rooms = 4;
            CountResidents = 3;
            Address = "Unknown";
        }
        public Flat(double area, int rooms) {
            Area = area;
            Rooms = rooms;
            CountResidents = 3;
            Address = "Unknown";
        }
        public void PrintFlat() {
            Console.WriteLine($"Flat Details:\nArea: {Area} sq.m\nRooms: {Rooms}\nResidents: {CountResidents}\nAddress: {Address}");
        }
    }
}
