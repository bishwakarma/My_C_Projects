using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SBEarthquakeSearchApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Event Handler for the Find button in this backend code
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnFind_Clicked(object sender, EventArgs e)
        {
            //Make an API CALL
            using (WebClient webClient = new WebClient())
            {
                //Set the header
                webClient.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";

                //Create try-catch block. If the code breaks an exception will be handled.
              
                    //Get the request for earchquake search.
                    //String variable to get the json code from the server. DownloadString() is a get request from the header.
                    //Using geojson format to get into metadata json object
                    string jsonText =
                        webClient.DownloadString($"https://earthquake.usgs.gov/fdsnws/event/1/query?format=geojson&starttime={EntryStartDate.Text}&endtime={EntryEndDate.Text}&minmagnitude={EntryEarthquakeSize.Text}&");
                    //Installed Newtonsoft.Json pacakge. Parse the json text and get the objects
                    JObject jo = JObject.Parse(jsonText);
                    //Create jason pbject for metadata object
                    JObject metadata = JObject.Parse(jo["metadata"].ToString());
                    //As features json object contains a list of array, i am using JArray class to parse the list of array.
                    JArray features = JArray.Parse(jo["features"].ToString());
                    // Creates a list of earthquakes and gets values from the API
                    List<EarthquakeGV> eqList = new List<EarthquakeGV>();

                //Using try-catch block to loop through the features and grab the values.
                try
                {
                    int idx = 1;
                    foreach (var eq in features)
                    {
                        //create an instance of JObject for earthquake jason object. Passing in properties from the  features jason object. 
                        JObject eqJObj = JObject.Parse(eq["properties"].ToString());
                        //Created an instance global variable class
                        EarthquakeGV earthquake = new EarthquakeGV
                        {
                            //assigning global variable properties. Here ID is required for identifying each json objects, but not used in this application
                            EQid = idx,
                            //Parse magnitude jason object to string
                            EQMag = double.Parse(eqJObj["mag"].ToString()),
                            //parse location jason object to string
                            EQLocation = eqJObj["place"].ToString()
                        };
                        //List also counts of eatchquakes added to the eatchquake variable
                        eqList.Add(earthquake);
                    }
                    //Code to display the labels navigating from the main page asynchronously.
                    Navigation.PushAsync(new EarthquakePage(eqList));

                }
                catch (Exception ex)
                {
                    //Alert the user and provide an opton to close the alert message.
                   DisplayAlert("Request Error", ex.Message, "Close");
                }
            }

        }
    }
}
