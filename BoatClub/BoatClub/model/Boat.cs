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
        BoatClubRepository xmlDb = new BoatClubRepository();

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
        public void AddBoat(int memberId, string boatType, int length)
        {
            Random rnd = new Random();
            int boatId = rnd.Next(1, 999999999);

            var xml = xmlDb.GetDocument();

            xml.Root.Element("Boats").Add(new XElement("Boat",
                    new XAttribute("memberId", memberId),
                    new XAttribute("boatId", boatId),
                    new XAttribute("boatType", boatType),
                    new XAttribute("length", length)
                ));
            xml.Save("../../data/BoatClub.xml");
        }

        public void RemoveBoat(int boatId)
        {
            var xml = xmlDb.GetDocument();

            xml.Descendants("Boat")
                .Where(x => (int)x.Attribute("boatId") == boatId)
                .Remove();

            xml.Save("../../data/BoatClub.xml");
        }

        public void UpdateBoat(int memberID, int boatId, string boatType = null, int length = 0)
        {
            var xml = xmlDb.GetDocument();

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

            xml.Save(xmlDb.XMLPath);

        }

        public Boat GetBoatInfo(int boatId)
        {
            var xml = xmlDb.GetDocument();

            var boatInfo = (from boat in xml.Descendants("Boat").Where(x => (int)x.Attribute("boatId") == boatId)
                            select new Boat
                            {
                                BoatId = (int)boat.Attribute("boatId"),
                                MemberID = (int)boat.Attribute("memberId"),
                                BoatType = (string)boat.Attribute("boatType"),
                                Length = (int)boat.Attribute("boatLength")
                            }).Single();                                

            return boatInfo;
        }

        public int NumberOfBoats(int memberId)
        {
            var xml = xmlDb.GetDocument();

            return xml.Descendants("Boat")
                    .Where(x => (int)x.Attribute("memberId") == memberId).Count();
        }
    }
}
