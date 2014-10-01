﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BoatClub.model
{
    class Boat
    {
        //fields
        private int _BoatID;
        private int _MemberID;
        private string _BoatType;
        private int _Length;

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
        public void AddBoat()
        {
            XmlDocument xmldoc = new XmlDocument();
            XmlNode rootNode = xmldoc.GetElementById("Boats");
            xmldoc.AppendChild(rootNode);

        }

        public void RemoveBoat()
        {

        }

        public void UpdateBoat()
        {

        }

        public static string GetBoatInfo()
        {
            throw new NotImplementedException("Finns ej");
        }
    }
}
