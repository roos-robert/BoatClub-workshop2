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
        BoatClubRepository xmlDb = new BoatClubRepository();

        // Properties
        public int MemberId
        {
            get { return this._memberID; }
            set 
            {                                
                //IEnumerable<User> users = ShowUsersSimple();

                //foreach(var user in users)
                //{
                //    if (user.MemberId == value)
                //    {
                //        throw new Exception("MemberID already in use");
                //    }
                //}
                   
                //this._memberID = value;

                this._memberID = value;
            }
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
            var xml = xmlDb.GetDocument();

            xml.Root.Element("Users").Add(new XElement("User",
                    new XAttribute("name", name),
                    new XAttribute("socialSecurity", socialSecurity),
                    new XAttribute("memberId", memberId)
                ));
            xml.Save(xmlDb.XMLPath);
        }

        public void RemoveUser(int memberId)
        {
            var xml = xmlDb.GetDocument();

            if (GetUser(memberId) != null)
            {
                xml.Descendants("User")
                    .Where(x => (int)x.Attribute("memberId") == memberId)
                    .Remove();

                xml.Save(xmlDb.XMLPath);
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public void UpdateUser(int memberId, string name = null, int socialSecurity = 0 )
        {
            var xml = xmlDb.GetDocument();

            if (name != null)
            {
                xml.Descendants("User").Where(x => (int)x.Attribute("memberId") == memberId).Single().SetAttributeValue("name", name);                    
            }
            if (socialSecurity != 0)
            {
                xml.Descendants("User").Where(x => (int)x.Attribute("memberId") == memberId).Single().SetAttributeValue("socialSecurity", socialSecurity);
            }
            xml.Save(xmlDb.XMLPath);

        }

        public User GetUser(int memberId)
        {
            var xml = xmlDb.GetDocument();

            var singleUser = (from user in xml.Descendants("User").Where(x => (int)x.Attribute("memberId") == memberId)
                         select new User
                         {
                             Name = (string)user.Attribute("name"),
                             SocialSecurity = (int)user.Attribute("socialSecurity"),
                             MemberId = (int)user.Attribute("memberId")
                         }).Single();

            return singleUser;
        }

        public IEnumerable<User> ShowUsersSimple()
        {
            var xml = xmlDb.GetDocument();

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
    