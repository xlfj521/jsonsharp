# Release 1.1 #

Release 1.1 is marked by the addition of the JSONReflector class.  JSONReflector accepts an instance of any object and uses standard reflection routines to generate a JSON object.

JSONReflector has initially been constructed to generate JSON objects from both value and reference object types, but is constrained to value-type public properties.  Generics aren't yet supported, though we expect to add those in the future.

An example application is included in the **[source code](http://jsonsharp.googlecode.com/svn/trunk/)** as well as the **[zip downloads](http://code.google.com/p/jsonsharp/downloads/list)**.


## A working Release 1.1 example ##
This fully-working example is available in the [source tree](http://jsonsharp.googlecode.com/svn/trunk/dotnet2.0/JSONSharpExample/).

```
using System;
using System.Collections.Generic;
using System.Text;
using JSONSharp;
using JSONSharp.Collections;
using JSONSharp.Values;

namespace JSONSharpExample
{
    class Program
    {
        /// <summary>
        /// An example implementation of JSONSharp. The location of a purveyor of fine ales is used 
        /// to show how different data types are handled when converted to JSON format at render time.
        /// </summary>
        /// <param name="args">command-line arguments; none used in this example</param>
        static void Main(string[] args)
        {
            Program.ManualWay();
            Program.ReflectiveWay();
        }

        static void ReflectiveWay()
        {
            //Construct my own custom object
            Tavern tavern = new Tavern();
            tavern.Business = "Tractor Tavern";
            tavern.Address = "5213 Ballard Ave NW";
            tavern.City = "Seattle";
            tavern.State = "WA";
            tavern.Zipcode = 98107;
            tavern.Latitude = 47.665663;
            tavern.Longitude = -122.382343;
            tavern.CoverCharge = true;
            tavern.Url = "http://tractortavern.citysearch.com/";
            tavern.AddPaymentMethod(PaymentMethod.Cash);
            tavern.AddPaymentMethod(PaymentMethod.Visa);
            tavern.AddPaymentMethod(PaymentMethod.Mastercard);
            tavern.AddPaymentMethod(PaymentMethod.AmericanExpress);

            //Pass it to our static reflector, which will build
            JSONReflector jsonReflector = new JSONReflector(tavern);

            // The ToString() is the compact representation of the object's JSON output
            Console.WriteLine("JSONReflector.ToString()");
            Console.WriteLine("===============================");
            Console.WriteLine(jsonReflector.ToString());
            Console.WriteLine("===============================");
            Console.WriteLine();
            // PrettyPrint() is great for readability
            Console.WriteLine("JSONReflector.PrettyPrint()");
            Console.WriteLine("===============================");
            Console.WriteLine(jsonReflector.PrettyPrint());
            Console.WriteLine("===============================");
            
        }

        static void ManualWay()
        {
            // Create a Dictionary of name/value pairs for the entire JSON object
            Dictionary<JSONStringValue, JSONValue> jsonNameValuePairs = new Dictionary<JSONStringValue, JSONValue>();

            // Create and add name/value pairs for business, address, city, state,
            // zipcode, latitude, longitude, covercharge and url
            JSONStringValue jsv_name_Business = new JSONStringValue("business");
            JSONStringValue jsv_value_Business = new JSONStringValue("Tractor Tavern");
            jsonNameValuePairs.Add(jsv_name_Business, jsv_value_Business);

            JSONStringValue jsv_name_Address = new JSONStringValue("address");
            JSONStringValue jsv_value_Address = new JSONStringValue("5213 Ballard Ave NW");
            jsonNameValuePairs.Add(jsv_name_Address, jsv_value_Address);

            JSONStringValue jsv_name_City = new JSONStringValue("city");
            JSONStringValue jsv_value_City = new JSONStringValue("Seattle");
            jsonNameValuePairs.Add(jsv_name_City, jsv_value_City);

            JSONStringValue jsv_name_State = new JSONStringValue("state");
            JSONStringValue jsv_value_State = new JSONStringValue("WA");
            jsonNameValuePairs.Add(jsv_name_State, jsv_value_State);

            JSONStringValue jsv_name_Zipcode = new JSONStringValue("zipcode");
            JSONNumberValue jsv_value_Zipcode = new JSONNumberValue(98107);
            jsonNameValuePairs.Add(jsv_name_Zipcode, jsv_value_Zipcode);

            JSONStringValue jsv_name_Latitude = new JSONStringValue("latitude");
            JSONNumberValue jsv_value_Latitude = new JSONNumberValue(47.665663);
            jsonNameValuePairs.Add(jsv_name_Latitude, jsv_value_Latitude);

            JSONStringValue jsv_name_Longitude = new JSONStringValue("longitude");
            JSONNumberValue jsv_value_Longitude = new JSONNumberValue(-122.382343);
            jsonNameValuePairs.Add(jsv_name_Longitude, jsv_value_Longitude);

            JSONStringValue jsv_name_CoverCharge = new JSONStringValue("covercharge");
            JSONBoolValue jsv_value_CoverCharge = new JSONBoolValue(true);
            jsonNameValuePairs.Add(jsv_name_CoverCharge, jsv_value_CoverCharge);

            JSONStringValue jsv_name_Url = new JSONStringValue("url");
            JSONStringValue jsv_value_Url = new JSONStringValue("http://tractortavern.citysearch.com/");
            jsonNameValuePairs.Add(jsv_name_Url, jsv_value_Url);


            // Add an array of payment methods
            JSONStringValue jsv_name_PaymentMethods = new JSONStringValue("paymentmethods");
            List<JSONValue> listPaymentMethods = new List<JSONValue>();
            listPaymentMethods.Add(new JSONStringValue("Cash"));
            listPaymentMethods.Add(new JSONStringValue("Visa"));
            listPaymentMethods.Add(new JSONStringValue("Mastercard"));
            listPaymentMethods.Add(new JSONStringValue("American Express"));
            JSONArrayCollection jsv_value_PaymentMethods = new JSONArrayCollection(listPaymentMethods);
            jsonNameValuePairs.Add(jsv_name_PaymentMethods, jsv_value_PaymentMethods);

            // Construct our object, passing the Dictionary of name/value pairs.  We could have
            // created our JSONObjectCollection first, then called the Add() method to populate
            // the object's internal Dictionary.
            JSONObjectCollection jsonObjectCollection = new JSONObjectCollection(jsonNameValuePairs);

            // The ToString() is the compact representation of the object's JSON output
            Console.WriteLine("JSONObjectCollection.ToString()");
            Console.WriteLine("===============================");
            Console.WriteLine(jsonObjectCollection.ToString());
            Console.WriteLine("===============================");
            Console.WriteLine();
            // PrettyPrint() is great for readability
            Console.WriteLine("JSONObjectCollection.PrettyPrint()");
            Console.WriteLine("===============================");
            Console.WriteLine(jsonObjectCollection.PrettyPrint());
            Console.WriteLine("===============================");
        }
    }
}


//==============================================================
// The tavern class
//==============================================================
using System;
using System.Collections.Generic;
using System.Text;

namespace JSONSharpExample
{

    public enum PaymentMethod
    {
        Cash,
        Check,
        Visa,
        Mastercard,
        AmericanExpress
    }

    public class Tavern
    {

        public Tavern()
        {
        }


        private string _business;
        public string Business
        {
            get { return this._business; }
            set { this._business = value; }
        }

        private string _address;
        public string Address
        {
            get { return this._address; }
            set { this._address = value; }
        }

        private string _city;
        public string City
        {
            get { return this._city; }
            set { this._city = value; }
        }

        private string _state;
        public string State
        {
            get { return this._state; }
            set { this._state = value; }
        }

        private int _zipcode;
        public int Zipcode
        {
            get { return this._zipcode; }
            set { this._zipcode = value; }
        }

        private double _latitude;
        public double Latitude
        {
            get { return this._latitude; }
            set { this._latitude = value; }
        }

        private double _longitude;
        public double Longitude
        {
            get { return this._longitude; }
            set { this._longitude = value; }
        }

        private bool _coverCharge;
        public bool CoverCharge
        {
            get { return this._coverCharge; }
            set { this._coverCharge = value; }
        }

        private string _url;
        public string Url
        {
            get { return this._url; }
            set { this._url = value; }
        }

        private List<PaymentMethod> _paymentMethods;
        public PaymentMethod[] PaymentMethods
        {
            get { return this._paymentMethods.ToArray(); }
        }

        public void AddPaymentMethod(PaymentMethod paymentMethod)
        {
            if (this._paymentMethods == null)
            {
                this._paymentMethods = new List<PaymentMethod>();
            }
            if (!this._paymentMethods.Contains(paymentMethod))
            {
                this._paymentMethods.Add(paymentMethod);
            }
        }
    }
}

```