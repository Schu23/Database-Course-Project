using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
//用来从数据库获取数据并封装
namespace YMClothsStore.App_Code
{
    public class Item//1服装信息表
    {
        public string itemId { get; set; }
        public string itemName { get; set; }
        public string itemSize { get; set; }
        public string itemColor { get; set; }
        public string itemImage { get; set; }
        public int itemPrice { get; set; }
        public DateTime itemDate { get; set; }
    }

    public class Shop//2门店信息表
    {
        public string shopId { get; set; }
        public string shopAddress { get; set; }
        public string shopPhone { get; set; }
    }

    public class Stock//3库存表
    {
        public string itemId { get; set; }
        public string shopId { get; set; }
        public int stockAmount { get; set; }
        public int saleAmount { get; set; }
        public int stockLimit { get; set; }
        public int purchaseAmount { get; set; }
    }

    public class In//4入库登记表
    {
        public string inId { get; set; }
        public string shopId { get; set; }
        public string staffId { get; set; }
        public DateTime inTime { get; set; }
    }

    public class InDetail//5入库明细表
    {
        public string inId { get; set; }
        public string itemId { get; set; }
        public int inAmount { get; set; }
    }
    
    public class Out//6出库登记表
    {
        public string outId { get; set; }
        public string shopId { get; set; }
        public string outType { get; set; }
        public string staffId { get; set; }
    }

    public class OutDetail//7出库明细表
    {
        public string outId { get; set; }
        public string tiemId { get; set; }
        public int outAmount { get; set; }
    }

    public class Order//8订单登记表
    {
        public string orderId { get; set; }
        public string shopId { get; set; }
        public int totalPrice { get; set; }
        public DateTime orderTime { get; set; }
    }

    public class OrderDetail//9订单明细
    {
        public string orderId { get; set; }
        public string itemId { get; set; }
        public int itemAmount { get; set; }
    }

    public class Check//10盘点表
    {
        public string checkId { get; set; }
        public string shopId { get; set; }
        public string checkerId { get; set; }
        public DateTime checkTime { get; set; }
    }

    public class CheckDetail//11盘点明细表
    {
        public string checkId { get; set; }
        public string itemId { get; set; }
        public int currentAmount { get; set; }
    }

    public class Apply//12申请表
    {
        public string applyId { get; set; }
        public string outShop { get; set; }
        public string inShop { get; set; }
        public string state { get; set; }
        public DateTime applyTime { get; set; }
    }

    public class ApplyDetail//13申请明细表
    {
        public string applyId { get; set; }
        public string itemId { get; set; }
        public int applyAmount { get; set; }
    }

    public class Staff//14员工信息表
    {
        public string staffId { get; set; }
        public string staffLogId { get; set;}
        public string staffName { get; set; }
        public string staffGender { get; set; }
        public string staffPhone { get; set; }
        public string staffJob { get; set; }
        public int shopId { get; set; }
        public string password { get; set; }
    }

    public class Image//15产品图片表
    {
        public string imageId { get; set; }
        public string imagePath { get; set; }
    }

    public class Address//16地址表
    {
        public string addressId { get; set; }
        public string addressName { get; set; }
        public float addressX { get; set; }
        public float addressY { get; set; }
    }

    public class DBModel
    {
        // 单例
       private static DBModel dbModel;
        // 构造函数私有
        private DBModel ()
       { }
     //构成单例子
        public static DBModel sharedDBModel()
        {
         if(dbModel == null)
         {
             dbModel = new DBModel();
         }
         return dbModel;
        }   

        /**
         * 1.查询店铺员工信息
         * 参数：店铺id：shopId
         * 返回值：成功返回该店铺员工信息ArrayList，失败返回null
         */
        public ArrayList findStaffInformationById(string shopId)
        {
            ArrayList staffs = null;
            /* using (YMClothsStoreContext db = new YMClothsStoreContext())
            {
                try
                {
                    string sql = "select * from STAFF where STAFF_ID = " + id;
                    staff = db.Database.SqlQuery<STAFF>(sql).FirstOrDefault();
                    return staff;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
            */

            return staffs;
        }
        /**
         * 2.添加新员工
         * 参数：新员工名字
         * 返回值：成功返回员工id，失败返回0
         */
        public string addStaff(string newStaffName)
        {
            string newStaffId = "00000000";//需要生成一个id，或者数据库设为自增

            Staff newStaff = new Staff
            {
                staffName = newStaffName,
                password = "12345678"//初始密码12345678
            };
            
            //写入数据库
            /* using (YMClothsContext db = new YMClothsContext())
            {
                try
                {
                    db.QUESTION.Add(newStaff);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("添加新员工异常");
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            } */


            return newStaffId;
        }

        /*
         * 3.删除员工
         * 参数：员工id
         * 返回值：成功返回true，失败或员工不存在返回false
         */
        public bool deleteStaffById(string deletedStaffId)
        {
            bool deletdSucced = false;

            //从数据库中查询要删除的员工
            /* using (YMClothsCotext db = new YMClothsCotext())
            {

            } */

            return deletdSucced;
        }


        /**
         * 4.更改员工信息
         * 参数：员工id，姓名，电话，密码
         * 返回值：成功返回true，失败返回false
         */
        public bool modifyPersonalInformation(Staff currentInfo)
        {

            /* using (YMClothsStoreContext db = new YMClothsStoreContext())
            {
                try
                {
                    Staff oldInfo = db.STAFF.Where(p => p.STAFF_ID == currentInfo.STAFF_ID).SingleOrDefault();
                    oldInfo.staffName = currentInfo.staffName;
                    oldInfo.staffPhone = currentInfo.staffPhone;
                    oldInfo.password = currentInfo.password;
                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
             */
            return false;
        }

        /*
         * 5.增加新门店
         * 参数：店长id，新门店地址，新门店电话
         * 返回值：门店id，失败返回"false"
         */
        public string addNewShop(string newShopManagerId, string newShopAddress, string newShopPhone) 
        {
            string isSecceed = "false";

            /*
             * 在Shop表中新加一条记录，并将对应店长shopId改为新门店
             */

            return isSecceed;
        }

        /*
         * 6.删除门店
         * 参数：门店id
         * 返回值：bool
         */
        public bool deletdShop(string shopId)
        {
            bool isSucceed = false;

            /*
             * 根据shopId删除门店
             */

            return isSucceed;
        }

        /*
         * 7.修改门店信息
         * 参数：门店id，新地址，新电话，不修改的值为null
         * 返回值：bool
         */
        public bool modifyShopInfo(string shopId, string newAddress, string newPhone)
        {
            bool isSucceed = false;

            return isSucceed;
        }


    }
}