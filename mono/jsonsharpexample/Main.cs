// project created on 5/22/2007 at 12:39 AM
using System;
using System.Collections.Generic;
using System.Text;
using JSONSharp;
using JSONSharp.Collections;
using JSONSharp.Values;

namespace jsonsharpexample
{
	class MainClass
	{
        /// <summary>
        /// An example implementation of JSONSharp. The location of a purveyor of fine aleas is used 
        /// to show how different data types are handled when converted to JSON format at render time.
        /// </summary>
        /// <param name="args">command-line arguments; none used in this example</param>
		public static void Main(string[] args)
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