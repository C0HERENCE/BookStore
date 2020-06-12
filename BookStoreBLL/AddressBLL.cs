using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookStoreDAL;
using BookStoreMisc;

namespace BookStoreBLL
{
    public class AddressBLL
    {
        public static AddressModel GetAddressByID(int id)
        {
            AddressModel address = new AddressModel();
            var reader = AddressDAL.SelectAddressByID(id);
            if (reader == null) return address;
            address.id = reader.GetInt32(0);
            address.tel = reader.GetString(1);
            address.add = reader.GetString(2);
            address.name = reader.GetString(3);
            address.user_id = reader.GetInt32(4);
            return address;
        }

        public static List<AddressModel> GetAddressesByUserID(int id)
        {
            List<AddressModel> addresses = new List<AddressModel>();
            var reader = AddressDAL.SelectAddressByUserID(id);
            while (reader.Read())
            {
                AddressModel address = new AddressModel();
                address.id = reader.GetInt32(0);
                address.tel = reader.GetString(1);
                address.add = reader.GetString(2);
                address.name = reader.GetString(3);
                address.user_id = reader.GetInt32(4);
                addresses.Add(address);
            }
            return addresses;
        }

        public static string AddAdderss(AddressModel address)
        {
            if (AddressDAL.InsertAddress(address)==0)
            {
                return "操作失败";
            }
            else
            {
                return "操作成功";
            }
        }
    }
}