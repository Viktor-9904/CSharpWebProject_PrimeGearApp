using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeGearApp.Web.ViewModels.FavoritesViewModels
{
    public class FavoriteProductViewModel
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Brand { get; set; } = null!;
        public string? ProductImagePath { get; set; }
        public string ProductPrice { get; set; } = null!;
        public string AddedToFavoritesDate { get; set; } = null!;
    }

}
