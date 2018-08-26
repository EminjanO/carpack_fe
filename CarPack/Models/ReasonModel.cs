using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarPack.Models
{
    public class ReasonModel
    {
        public int Id { get; set; }
        public string Eventreason_name { get; set; }
        public string Eventreason_alias { get; set; }

        public ReasonModel()
        {
            Id = -1;
        }

        public ReasonModel(string Eventreason_name, string eventreason_alias)
        {
            this.Id = Id;
            this.Eventreason_name = Eventreason_name;
            this.Eventreason_alias = eventreason_alias;
        }
    }
}