using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InOutFCA.DAL.Entity;

namespace CarPack.DAL.Entity
{
    class Transition : IEntity<int>
    {
        public int Transition_id { get; set; }
        public int CurrentState { get; set; }
        public int NextState { get; set; }
        public string Description { get; set; }

        public int Id
        {
            get
            {
                return Transition_id;
            }
            set
            {
                Transition_id = value;
            }
        }
    }
}
