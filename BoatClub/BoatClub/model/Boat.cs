using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace BoatClub.model
{
    class Boat
    {
        // Fields
        private int _BoatID;
        private string _BoatType;
        private int _Length = 0;
        BoatClubRepository xmlDb = new BoatClubRepository();

        // Properties
        public int BoatId
        {
            get { return this._BoatID; }
            set
            {
                this._BoatID = value;
            }
        }

        public string BoatType
        {
            get { return this._BoatType; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Null not allowed");
                }
                else
                {
                    this._BoatType = value;
                }
            }
        }

        public int Length
        {
            get { return this._Length; }
            set
            {
                this._Length = value;
            }
        }

        //Methods
        public void AddBoat(int memberId, string boatType, int length)
        {
            Random rnd = new Random();
            int boatId = rnd.Next(1, 999999999);

            var xml = xmlDb.GetDocument();

            xml.Element("BoatClub")
                .Element("Users")
                .Elements("User")
                .Where(User => (int)User.Attribute("memberId") == memberId).FirstOrDefault()
                .Element("Boats")
                .Add(new XElement("Boat",
                    new XAttribute("boatId", boatId),
                    new XAttribute("boatType", boatType),
                    new XAttribute("boatLength", length)
                ));
            
            xml.Save(xmlDb.XMLPath);
        }

        public void RemoveBoat(int boatId)
        {
            var xml = xmlDb.GetDocument();

            xml.Descendants("Boat")
                .Where(x => (int)x.Attribute("boatId") == boatId)
                .Remove();

            xml.Save(xmlDb.XMLPath);
        }

        public void UpdateBoat(int memberID, int boatId, string boatType = null, int length = 0)
        {
            var xml = xmlDb.GetDocument();

            if (boatType.Length > 1)
            {
                xml.Descendants("Boat").Where(x => (int)x.Attribute("boatId") == boatId).Single().SetAttributeValue("boatType", boatType);
            }
            if (length != 0)
            {
                xml.Descendants("Boat").Where(x => (int)x.Attribute("boatId") == boatId).Single().SetAttributeValue("boatLength", length);
            }

            //Changing the owner of the boat
            if (memberID != 0)
            {
                xml.Descendants("Boat").Where(x => (int)x.Attribute("boatId") == boatId).Single().SetAttributeValue("memberId", memberID);
            }

            xml.Save(xmlDb.XMLPath);
        }
    }
}