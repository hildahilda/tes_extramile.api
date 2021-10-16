using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore;
using System.Web;
using Microsoft.AspNetCore.Mvc;


namespace tes_extramile.api.Models
{
    public class Weathermodel
    {
        public float lon{ get; set; }
        public float lat { get; set; }
        public int waktu { get; set; }
        public float windSp { get; set; }
        public int visibility { get; set; }
        public string skyCon { get; set; }
        public double tempCel { get; set; }
        public double tempFah { get; set; }
        public float dew { get; set; }
        public int humid { get; set; }
        public int press { get; set; }


        public double SetFahrenheitToCelsius(double fahrenheit)
        {
            double celsius = Math.Round((fahrenheit - 32) * 5 / 9, 2);
            Console.WriteLine($"{celsius}°C");
            return celsius;
        }
    }
    
}   
/*
namespace tes_extramile1.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public int PublicationYear { get; set; }

        public bool IsAvailable { get; set; }

        public string CallNumber { get; set; }

    }
}*/
