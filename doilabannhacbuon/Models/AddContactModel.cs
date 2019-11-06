using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;
using doilabannhacbuon.Entity;
using doilabannhacbuon.Utils;

namespace doilabannhacbuon.Models
{
    class AddContactModel
    {
        public bool Insert(UserContact user)
        {
            try
            {
                using (var stt = SQLiteUtil.GetIntances().Connection.Prepare("INSERT INTO User (Name, Phone_Number) VALUES (?, ?)"))
                {
                    stt.Bind(1, user.Name);
                    stt.Bind(2, user.Phone_Number);
                    stt.Step();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return false;
        }

        public List<UserContact> Select()
        {
            try
            {
                List<UserContact> lstUserContacts = new List<UserContact>();
                using (var stt = SQLiteUtil.GetIntances().Connection.Prepare("SELECT * from User"))
                {
                    while (stt.Step() == SQLitePCL.SQLiteResult.ROW)
                    {
                        var getNote = new UserContact();
                        getNote.Name = (string)stt[0];
                        getNote.Phone_Number = (string)stt[1];
                        lstUserContacts.Add(getNote);
                    }
                    return lstUserContacts;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
