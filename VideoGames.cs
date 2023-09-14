/**       
 *--------------------------------------------------------------------
 * 	   File name: VideoGames.cs
 * 	Project name: Lab2
 *--------------------------------------------------------------------
 * Author’s name and email:	 Dylan Grampp gramppd@etsu.edu			
 *          Course-Section: CSCI 2910-800
 *           Creation Date:	09/14/23
 * -------------------------------------------------------------------
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GramppLab2.VideoGames;

namespace GramppLab2
{
    internal class VideoGames : IComparable<VideoGames>
    {
        public string Title { get; set; }
        public string Platform { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public string Publisher { get; set; }
        public double NaSales { get; set; }
        public double EuSales { get; set; }
        public double JpSales { get; set; }
        public double OtherSales { get; set; }
        public double GlobalSales { get; set; }

        public VideoGames(string title, string platform, int year, string genre, string publisher, double naSales, double euSales, double jpSales, double otherSales, double globalSales)
        {
            Title = title;
            Platform = platform;
            Year = year;
            Genre = genre;
            Publisher = publisher;
            NaSales = naSales;
            EuSales = euSales;
            JpSales = jpSales;
            OtherSales = otherSales;
            GlobalSales = globalSales;
        }

        public override string ToString()
        {
            return Title + "," + Platform + "," + Year + "," + Genre + "," + Publisher + "," + NaSales + "," + EuSales + "," + JpSales + "," + OtherSales + "," + GlobalSales;
        }

        public int CompareTo(VideoGames other)
        {
            return Title.CompareTo(other.Title);
        }
    }
}
