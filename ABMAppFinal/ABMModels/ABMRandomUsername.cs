﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABMAppFinal.ABMModels
{
        public class Address
    {
        public string city { get; set; }
        public string street_name { get; set; }
        public string street_address { get; set; }
        public string zip_code { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public Coordinates coordinates { get; set; }
    }

    public class Coordinates
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class CreditCard
    {
        public string cc_number { get; set; }
    }

    public class Employment
    {
        public string title { get; set; }
        public string key_skill { get; set; }
    }

    public class Root
    {
        public int id { get; set; }
        public string uid { get; set; }
        public string password { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string avatar { get; set; }
        public string gender { get; set; }
        public string phone_number { get; set; }
        public string social_insurance_number { get; set; }
        public string date_of_birth { get; set; }
        public Employment employment { get; set; }
        public Address address { get; set; }
        public CreditCard credit_card { get; set; }
        public Subscription subscription { get; set; }
    }

    public class Subscription
    {
        public string plan { get; set; }
        public string status { get; set; }
        public string payment_method { get; set; }
        public string term { get; set; }
    }

}
