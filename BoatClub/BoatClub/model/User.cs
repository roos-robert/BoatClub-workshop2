using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("~/data/BoatClub.xml");
            XmlNode rootNode = xmlDoc.GetElementById("Users");
            xmlDoc.AppendChild(rootNode);

            XmlNode userNode = xmlDoc.CreateElement("User");
            XmlAttribute xName = xmlDoc.CreateAttribute("Name");
            xName.Value = name;

            XmlAttribute xSocialSecurity = xmlDoc.CreateAttribute("SocialSecurity");
            xSocialSecurity.Value = socialSecurity.ToString();

            XmlAttribute xMemberId = xmlDoc.CreateAttribute("MemberId");
            xMemberId.Value = memberId.ToString();

            xmlDoc.Save("~/data/BoatClub.xml");
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
    