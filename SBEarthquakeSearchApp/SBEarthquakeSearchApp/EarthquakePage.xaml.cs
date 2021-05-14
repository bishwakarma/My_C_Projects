using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SBEarthquakeSearchApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EarthquakePage : ContentPage
    {
        /// <summary>
        /// Passing list of earthquakes as eqList from main page. So that the result can be displayed in the label.
        /// </summary>
        /// <param name="eqList"></param>
        public EarthquakePage(List<EarthquakeGV> eqList)
        {
            InitializeComponent();
            //Update the labels to display results
            Random random = new Random();
            int randeq = random.Next(1, eqList.Count + 1);
            if(eqList.Count > 0)
            {
                EarthquakeGV displayEQ = eqList[randeq];
                lblResults.Text = $"There were {eqList.Count} earthquakes during this time.\n\n" +
                   $"Details of one of them:\nPlace: {displayEQ.EQMag}, \nMagnitude: {displayEQ.EQMag}.";
            }
            else
            {
                lblResults.Text = "No earthquakes";
            }
        }
    }
}