# JSONSharp #

JSONSharp is a C# library for constructing JSON-compliant data strings.  It's lightweight and object-oriented, using a set of abstract classes to separate data from implementation. The library was created out of a need for a generic and flexible way to generate JSON from a server-side .Net application.


## Structure ##
JSONSharp objects have two jobs:
  1. accept/hold data values, and
  1. write them as JSON-compliant strings.

The base object of JSONSharp is the JSONValue.  Everything in JSONSharp inherits from JSONValue.  JSONValue is an abstract class, requiring implementors to override two methods: ToString() and PrettyPrint().

The second most-important base object is the JSONValueCollection.  JSONValueCollection represents the multi-element objects permitted in JSON (object collections and arrays) and is itself a JSONValue.  JSONValueCollection is an abstract class, requiring implementors to override two additional methods: CollectionToString() and CollectionToPrettyPrint().

## Value types ##
JSONSharp supports three value types: strings, numbers, and booleans.

  * JSONStringValue takes a string and will write the value in JSON-compliant format (from ToString()).
  * JSONNumberValue takes either an int, single, double, decimal, or byte and writes the value in proper numeric format, per the JSON RFC specification.
  * JSONBooleanValue takes a boolean and writes either "true" or "false".

## Collection types ##
JSONSharp supports two collection types: object collections and arrays.

  * JSONObjectCollection accepts a Dictionary of name/value pairs, passed as either an instance of type Dictionary<JSONStringValue,JSONValue> or through individual Add() method calls.  The "name" of an entry is a JSONStringValue; the "value" of the pair is any JSONValue, which could be a JSONSharp value type OR collection type.
  * JSONArrayCollection accepts a generic List of JSONValue objects, passed as either an instance of type List

&lt;JSONValue&gt;

 or through individual Add() method calls.

## How it works ##
A JSON object is either an unordered object collection of random name/value pairs, or an array of elements. Members of both object collections or arrays are either strings, numbers, booleans, null, or other object collections or arrays.

Given that, the premise behind JSONSharp is pretty simple. Using the abstracted ToString() method in JSONValue, the JSONObjectCollection and JSONArrayCollection objects walk their internal collections and write the data using the implementation's given rules, as defined in ToString().

## An example ##
This fully-working example is available in the [source tree](http://jsonsharp.googlecode.com/svn/trunk/dotnet2.0/JSONSharpExample/). As a disclaimer, this code is intentionally verbose to show as many parts of the library as feasible.

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
```