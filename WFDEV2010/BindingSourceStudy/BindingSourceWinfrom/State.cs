using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindingSourceWinfrom
{
  public  class State
    {

        public int ID { get; set; }
        public string stateName { get; set; }

        public string stateCapital { get; set; }

        public State()
        {

        }
			public State ( string name, string capital,int id)
			{
                stateName = name;
                stateCapital = capital;
                this.ID = id;
			}
		}
    
}
