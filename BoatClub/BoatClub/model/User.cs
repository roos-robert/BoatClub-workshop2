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
        private int _socialSecurity = 0;
        private string XMLPath = "../../data/BoatClub.xml";

        // Properties
        public int MemberId
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
        public void AddUser(string name, int socialSecurity)
        {
            Random rnd = new Random();
            int memberId = rnd.Next(1, 999999999);
            XDocument xml = XDocument.Load(XMLPath);

            xml.Root.Element("Users").Add(new XElement("User",
                    new XAttribute("name", name),
                    new XAttribute("socialSecurity", socialSecurity),
                    new XAttribute("memberId", memberId)
                ));
            xml.Save(XMLPath);
        }

        public void RemoveUser(int memberId)
        {
            XDocument xml = XDocument.Load(XMLPath);

            xml.Descendants("User")
                .Where(x => (int)x.Attribute("memberId") == memberId)
                .Remove();

            xml.Save(XMLPath);
        }

        public void UpdateUser(int memberId, string name = null, int socialSecurity = 0 )
        {
            XDocument xml = XDocument.Load(XMLPath);

            if (name != null)
            {
                xml.Descendants("User").Where(x => (int)x.Attribute("memberId") == memberId).Single().SetAttributeValue("name", name);                    
            }
            if (socialSecurity != 0)
            {
                xml.Descendants("User").Where(x => (int)x.Attribute("memberId") == memberId).Single().SetAttributeValue("socialSecurity", socialSecurity);
            }
            xml.Save(XMLPath);

        }

        public User ShowUser()
        {
            

            throw new NotImplementedException();
        }

        public IEnumerable<User> ShowUsersSimple()
        {
            XDocument xml = XDocument.Load(XMLPath);

            var userList = (from user in xml.Descendants("User")
                     select new User
                     {
                         Name = (string)user.Attribute("name"),
                         SocialSecurity = (int)user.Attribute("socialSecurity"),
                         MemberId = (int)user.Attribute("memberId")
                     }).ToList();

            return userList;         
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
    