# Execview - Engineer coding challenge #2

 ### Problem statement:

Process the attached CSV file (chicago-bulls.csv), load the file, and create a report in JSON which will contain the following:

Sort the players based on the PPG descending, calculate the average point for the team (based on the PPG), find the gold, silver and bronze player based on PPG, count the number of players playing on each position and the average height in cm. Please see the example expected report file (chicago-bulls.json).

### Current Implementation

Written in C# in the Visual Studio Community IDE, this projects uses:

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualBasic.FileIO;
using System.Web.UI;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
//NewtonsoftJSON NuGet package had to be installed to deal with json output files



Table data is imported and fomatted from the chicago-bulls.csv file. A ``text field parser`` method is used to deal with lack of format in the input data. The data is divided into arrays and lists in order to output it in JSON.







