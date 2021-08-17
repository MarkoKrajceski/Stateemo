using Microsoft.Owin.Security.DataHandler.Encoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using PagedList;

namespace Stateemo.Models
{
    public class ChampionModel
    {
        public int Id { get; set; }
        [DisplayName("Role")]
        public int RoleId { get; set; }
        public string Name { set; get; } //Leona
        public string Title { set; get; }
        public virtual RoleModel Role { set; get; }
        [DisplayName("Icon")]
        public string IconURL { set; get; }
        public bool Ranged { set; get; }
        [DisplayName("Base Attack Damage (+ per level)")]
        [RegularExpression(@"\d+ \(\+ \d+\)|\d+ \(\+ \d+\.{1}\d+\)|\d+\.{1}\d+ \(\+ \d+\)|\d+\.{1}\d+ \(\+ \d+\.{1}\d+\)")]
        public string AttackDamage { set; get; }
        [DisplayName("Base Health (+ per level)")]
        [RegularExpression(@"\d+ \(\+ \d+\)|\d+ \(\+ \d+\.{1}\d+\)|\d+\.{1}\d+ \(\+ \d+\)|\d+\.{1}\d+ \(\+ \d+\.{1}\d+\)")]
        public string Health { set; get; }
        [DisplayName("Base Health Regeneration (+ per level)")]
        [RegularExpression(@"\d+ \(\+ \d+\)|\d+ \(\+ \d+\.{1}\d+\)|\d+\.{1}\d+ \(\+ \d+\)|\d+\.{1}\d+ \(\+ \d+\.{1}\d+\)")]
        public string HealthRegen { set; get; }
        [DisplayName("Base Mana/Energy (+ per level)")]
        [RegularExpression(@"\d+ \(\+ \d+\)|\d+ \(\+ \d+\.{1}\d+\)|\d+\.{1}\d+ \(\+ \d+\)|\d+\.{1}\d+ \(\+ \d+\.{1}\d+\)|\d+")]
        public string Mana { set; get; }
        [DisplayName("Base Mana/Energy Regeneration (+ per level)")]
        [RegularExpression(@"\d+ \(\+ \d+\)|\d+ \(\+ \d+\.{1}\d+\)|\d+\.{1}\d+ \(\+ \d+\)|\d+\.{1}\d+ \(\+ \d+\.{1}\d+\)|\d+")]
        public string ManaRegen { set; get; }
        [DisplayName("Base Armor (+ per level)")]
        [RegularExpression(@"\d+ \(\+ \d+\)|\d+ \(\+ \d+\.{1}\d+\)|\d+\.{1}\d+ \(\+ \d+\)|\d+\.{1}\d+ \(\+ \d+\.{1}\d+\)")]
        public string Armor { set; get; }
        [DisplayName("Base Magic Resistance (+ per level)")]
        [RegularExpression(@"\d+ \(\+ \d+\)|\d+ \(\+ \d+\.{1}\d+\)|\d+\.{1}\d+ \(\+ \d+\)|\d+\.{1}\d+ \(\+ \d+\.{1}\d+\)")]
        public string MagicResist { set; get; }
        [DisplayName("Base Movement Speed")]
        public string MovementSpeed { set; get; }
        /*
        public ChampionModel()
        {

        }

        public ChampionModel(int Id, string name, string title, string iconURL, bool ranged, string attackDamage, string health, string healthRegen, string mana, string manaRegen, string armor, string magicResist, string movementSpeed, RoleModel Role)
        {
            this.Id = Id;
            Name = name;
            Title = title;
            IconURL = iconURL;
            Ranged = ranged;
            AttackDamage = attackDamage;
            Health = health;
            HealthRegen = healthRegen;
            Mana = mana;
            ManaRegen = manaRegen;
            Armor = armor;
            MagicResist = magicResist;
            MovementSpeed = movementSpeed;
            this.Role = Role;
        }*/


    }
}