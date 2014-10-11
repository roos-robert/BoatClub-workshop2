using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace BoatClub.model
{
    class BoatClubRepository
    {
        // Fields
        private string _XMLPath = "../../data/BoatClub.xml";
        XDocument xml;

        // Properties
        public string XMLPath
        {
            get { return this._XMLPath; }
            set { this._XMLPath = value; }
        }

        // Methods
        public XDocument GetDocument()
        {
            return xml;
        }

        // Constructor
        public BoatClubRepository()
        {
            xml = XDocument.Load(XMLPath);
        }
    }
}