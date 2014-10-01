using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace BoatClub.model
{
    class User
    {
        // Fields
        private int _memberID;
        private string _name;
        private int _socialSecurity;

        // Properties
        public int MemberID
        {
            get { return this._memberID; }
            set { this._memberID = value; }
        }

        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        public int SocialSecurity
        {
            get { return this._socialSecurity; }
            set { this._socialSecurity = value; }
        }

        // Methods
        public void AddUser(string name, int socialSecurity, int memberId)
        {
            XDocument xml = XDocument.Load("../../data/BoatClub.xml");

            xml.Root.Element("Users").Add(new XElement("User",
                    new XAttribute("name", name),
                    new XAttribute("socialSecurity", socialSecurity),
                    new XAttribute("memberId", memberId)
                ));
            xml.Save("../../data/BoatClub.xml");
        }

        public void RemoveUser()
        {

        }

        public void UpdateUser()
        {

        }

        public User ShowUser()
        {
            throw new NotImplementedException();
        }

        public User ShowUsersSimple()
        {
            throw new NotImplementedException();
        }

        public User ShowUsersFull()
        {
            throw new NotImplementedException();
        }

        // Constructor
        public User()
        {
            // TOM!
        }
    }
}
    