using System;

namespace VismaSummitDemo2015
{
    public class Customer
    {
        public int internalId { get; set; }
        public string number { get; set; }
        public string name { get; set; }
        public int status { get; set; }
        public Mainaddress mainAddress { get; set; }
        public Maincontact mainContact { get; set; }
        public Customerclass customerClass { get; set; }
        public Creditterms creditTerms { get; set; }
        public string currencyId { get; set; }
        public int creditVerification { get; set; }
        public float creditLimit { get; set; }
        public int creditDaysPastDue { get; set; }
        public Invoiceaddress invoiceAddress { get; set; }
        public Invoicecontact invoiceContact { get; set; }
        public bool printInvoices { get; set; }
        public bool acceptAutoInvoices { get; set; }
        public bool sendInvoicesByEmail { get; set; }
        public bool printStatements { get; set; }
        public bool sendStatementsByEmail { get; set; }
        public bool printMultiCurrencyStatements { get; set; }
        public int statementType { get; set; }
        public Deliveryaddress deliveryAddress { get; set; }
        public Deliverycontact deliveryContact { get; set; }
        public Vatzone vatZone { get; set; }
        public Location location { get; set; }
        public DateTime lastModifiedDateTime { get; set; }
        public string accountReference { get; set; }
    }

    public class Mainaddress
    {
        public int addressId { get; set; }
        public Country country { get; set; }
    }

    public class Country
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Maincontact
    {
        public int contactId { get; set; }
        public string name { get; set; }
    }

    public class Customerclass
    {
        public string id { get; set; }
        public string description { get; set; }
    }

    public class Creditterms
    {
        public string id { get; set; }
        public string description { get; set; }
    }

    public class Invoiceaddress
    {
        public int addressId { get; set; }
        public Country1 country { get; set; }
    }

    public class Country1
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Invoicecontact
    {
        public int contactId { get; set; }
        public string name { get; set; }
    }

    public class Deliveryaddress
    {
        public int addressId { get; set; }
        public Country2 country { get; set; }
    }

    public class Country2
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Deliverycontact
    {
        public int contactId { get; set; }
        public string name { get; set; }
    }

    public class Vatzone
    {
        public string id { get; set; }
        public string description { get; set; }
    }

    public class Location
    {
        public string countryId { get; set; }
        public string id { get; set; }
        public string name { get; set; }
    }
}