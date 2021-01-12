using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.ViewModels
{
    public class ProductDetailCM
    {
        public String ImangeUrl { get; set; }

        public String Color { get; set; }


    }

    public class ProductDetailUM
    {
        public int Id { get; set; }

        public String ImangeUrl { get; set; }

        public String Color { get; set; }
    }

    public class ProductDetailVM
    {
        public int Id { get; set; }

        public String ImangeUrl { get; set; }

        public String Color { get; set; }

        public String ColorHex { get; set; }
    }
}
