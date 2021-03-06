﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;

        /*
private string firstname;
private string middlename = "none";
private string lastname = "none";
private string nickname = "none";
private string title = "none";
private string company = "none";
private string address = "none";
private string home = "none";
private string mobile = "none";
private string work = "none";
private string fax = "none";
private string email = "none";
private string email2 = "none";
private string homepage = "none";
private string address2 = "none";
private string notes = "none";
private string phone2 = "none";
private string email3 = "none";
*/
        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public string Firstname { get; set; }

        public string Middlename { get; set; }

        public string Lastname { get; set; }
        
        public string Nickname { get; set; }

        public string Title { get; set; }

        public string Company { get; set; }

        public string Address { get; set; }

        public string Home { get; set; }

        public string Mobile { get; set; }

        public string Work { get; set; }

        public string Fax { get; set; }

        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Homepage { get; set; }

        public string Address2 { get; set; }

        public string Notes { get; set; }

        public string Phone2 { get; set; }

        public string Email3 { get; set; }

        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(Home) + CleanUp(Mobile) + CleanUp(Work)).Trim();
                }
            }
                set
            {
                allPhones = value;
            }
        }

        public string CleanUp(string phone)
        {
            if( phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ -()]", "") + "\r\n";
        }

        public bool Equals(ContactData other)
             {
                 if (Object.ReferenceEquals(other, null))
                 {
                     return false;
                 }
                 if (Object.ReferenceEquals(this, other))
                 {
                     return true;
                 }
                 return Firstname == other.Firstname && Lastname == other.Lastname;
             }
        
         public override int GetHashCode()
             {
                 return (Firstname + " " + Lastname).GetHashCode();
             }

         public override string ToString()
             {
                 return Firstname + Lastname;
             }

         public int CompareTo(ContactData other)
             {
                 if (Object.ReferenceEquals(other, null))
                 {
                     return 1;
                  }
            int result = Lastname.CompareTo(other.Lastname);
            if (result != 0)
                 {
                     return result;
                 }
                 else
            {
                return Firstname.CompareTo(other.Firstname) + Lastname.CompareTo(other.Lastname);
            }
         }
    }
}
