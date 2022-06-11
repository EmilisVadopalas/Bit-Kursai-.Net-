using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManoPirmasDotNetProjektas.Paskaitos.Networking
{
    public class ProcessorListing
    {
        public string Name { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set; }

        public ProcessorListing(string name, string pictureUrl, string price)
        {
            Name = name;
            PictureUrl = pictureUrl;

            if(decimal.TryParse(price.Replace("€", "").Trim(), out decimal priceDecimal))
            { 
                Price = priceDecimal / 100;
            }
            else
            {
                Price = -1;
            }
        }
    }
}
