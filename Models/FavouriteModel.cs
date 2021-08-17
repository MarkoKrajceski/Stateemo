using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stateemo.Models
{
    public class FavouriteModel
    {
        public int Id { set; get; }
        public int FavouriteChampionId { get; set; }
        public virtual ChampionModel FavouriteChampion { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { set; get; }
        public FavouriteModel() { }
        public FavouriteModel(int FavouriteChampionId, ChampionModel FavouriteChampion, string UserId, ApplicationUser User )
        {
            this.FavouriteChampionId = FavouriteChampionId;
            this.FavouriteChampion = FavouriteChampion;
            this.UserId = UserId;
            this.User = User;
        }
        
    }
}