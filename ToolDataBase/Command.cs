using System.Collections.Generic;

namespace ToolDataBase
{
    public class Command
    {
        private string _Query;
        private Dictionary<string, object> _Params;

        public string Query
        {
            get { return _Query; }
            private set { _Query = value; }
        }

        public Dictionary<string, object> Params
        {
            get { return _Params; }
            private set { _Params = value; }
        }

        public Command(string Query)
        {
            this.Query = Query;
            this.Params = new Dictionary<string, object>();
        }

        public void AddParameter(string Name, object Value)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                return;
            }

            _Params.Add(Name, Value);
        }

    }
}
