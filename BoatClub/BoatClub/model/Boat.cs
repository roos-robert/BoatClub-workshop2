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
        //fields
        private int _BoatID;
        private int _MemberID = 0;
        private string _BoatType;
        private int _Length = 0;
        private string XMLPath = "../../data/BoatClub.xml";

        //properties
        public int BoatId
        {
            get { return this._BoatID; }
            set
            {
                this._BoatID = value;
            }
        }

        public int MemberID
        {
            get { return this._MemberID; }
            set
            {
                this._MemberID = value;
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
        public void AddBoat(int memberID, int boatID, string boatType, int length)
        {
            XDocument xml = XDocument.Load("../../data/BoatClub.xml");

            xml.Root.Element("Users").Add(new XElement("Boat",
                    new XAttribute("memberId", memberID),
                    new XAttribute("boatId", boatID),
                    new XAttribute("boatType", boatType),
                    new XAttribute("length", length)
                ));
            xml.Save("../../data/BoatClub.xml");
        }

        public void RemoveBoat(int boatId)
        {
            XDocument xml = XDocument.Load("../../data/BoatClub.xml");

            xml.Descendants("Boat")
                .Where(x => (int)x.Attribute("boatId") == boatId)
                .Remove();

            xml.Save("../../data/BoatClub.xml");
        }

        public void UpdateBoat(int memberID, int boatId, string boatType = null, int length = 0)
        {
            XDocument xml = XDocument.Load(XMLPath);

            if (boatType != null)
            {
                xml.Descendants("Boat").Where(x => (int)x.Attribute("boatId") == boatId).Single().SetAttributeValue("boatType", boatType);
            }
            if (length != 0)
            {
                xml.Descendants("Boat").Where(x => (int)x.Attribute("boatId") == boatId).Single().SetAttributeValue("length", length);
            }
            //Changing the owner of the boat
            if (memberID != 0)
            {
                xml.Descendants("Boat").Where(x => (int)x.Attribute("boatId") == boatId).Single().SetAttributeValue("memberID", memberID);
            }

            xml.Save(XMLPath);

        }

        public static string GetBoatInfo()
        {
            throw new NotImplementedException("Finns ej");
        }
    }
}
