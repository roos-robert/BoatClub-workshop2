using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClub.model
{
    class User
    {
        // Fields
        private int memberID;
        private string name;
        private int socialSecurity;

        // Properties
        public int MemberID
        {
            get { return this.memberID; }
            set { this.memberID = value; }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int SocialSecurity
        {
            get { return this.socialSecurity; }
            set { this.socialSecurity = value; }
        }

        // Methods
        public void AddUser()
        {

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
    