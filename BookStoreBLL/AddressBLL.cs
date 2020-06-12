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
            reader.Read();
            address.id = reader.GetInt32(0);
            address.tel = reader.GetString(1);
            address.add = reader.GetString(2);
            address.name = reader.GetString(3);
            address.user_id = reader.GetInt32(4);
            address.enabled = reader.GetInt32(5);
            address.isdefault = reader.GetInt32(6);
            reader.Close();
            return address;
        }

        public static int GetAddressNumByUserID(int id)
        {
            return AddressDAL.SelectAddressCountByUserID(id);
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
                address.enabled = reader.GetInt32(5);
                address.isdefault = reader.GetInt32(6);
                addresses.Add(address);
            }
            reader.Close();
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

        public static string SetDefaultAddress(AddressModel addressModel)
        {
            if (AddressDAL.UpdateDefaultAddress(addressModel.id) > 0)
            {
                return "设为默认收货地址成功";
            }
            return "设为默认收货地址失败";
        }

        public static string UpdateAddress(AddressModel addressModel)
        {
            if (AddressDAL.UpdateAddress(addressModel)>0)
            {
                return "收货地址修改成功";
            }
            return "收货地址修改失败";
        }

        public static string DisableAddress(int id)
        {
            if (AddressDAL.UpdateAddressEnabled(id)>0)
            {
                return "删除成功";
            }
            else
            {
                return "删除失败";
            }
        }

        public static AddressModel GetUserDefaultAddress(int UserID)
        {
            List<AddressModel> addresses = new List<AddressModel>();
            var reader =  AddressDAL.SelectDefaultAddress(UserID);
            while (reader.Read())
            {
                AddressModel address = new AddressModel();
                address.id = reader.GetInt32(0);
                address.tel = reader.GetString(1);
                address.add = reader.GetString(2);
                address.name = reader.GetString(3);
                address.user_id = reader.GetInt32(4);
                address.enabled = reader.GetInt32(5);
                address.isdefault = reader.GetInt32(6);
                addresses.Add(address);
            }
            reader.Close();
            if (addresses.Count>0)
            {
                return addresses.First();
            }
            else
            {
                return new AddressModel();
            }
        }
    }
}