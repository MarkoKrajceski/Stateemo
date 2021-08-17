using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Stateemo.Models
{
    public class RoleModel
    {
        public int Id { get; set; }
        public List <int> ChampionIds { set; get; }
        [DisplayName ("Role")]
        public string Name { set; get; } //Tank
        public string Description { set; get; }
        public virtual List<ChampionModel> Champions { get; set; }
        /*public RoleModel(int Id, string name, string description)
        {
            this.Id = Id;
            Name = name;
            Description = description;
            Champions = new List<ChampionModel>();
        }*/
    }
}