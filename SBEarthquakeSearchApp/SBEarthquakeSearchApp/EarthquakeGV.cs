using System;
using System.Collections.Generic;
using System.Text;

namespace SBEarthquakeSearchApp
{
    /// <summary>
    /// This is a custom class prepared to hold teh properties for the global variables
    /// Making class public and static, this way the values will stay in the memory as it moves on for the next one.
    /// </summary>
    public class EarthquakeGV
    {
        //Global variable for ID event
        public int EQid;
        /// <summary>
        /// Global variable for location: Place
        /// </summary>
        public string EQLocation { get; set; }
        /// <summary>
        /// Global variable for magnitude
        /// </summary>
        public double EQMag { get; set; }
        /// <summary>
        /// Global variable for how many times the earthquake occured
        /// </summary>
        public string EQCount { get; set; }
    }
}
