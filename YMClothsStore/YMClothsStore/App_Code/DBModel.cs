using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
//用来从数据库获取数据并封装
namespace YMClothsStore
{
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
         * 需要测试
         */
        public string addNewStaff(string newStaffName)
        {
            const string tempId = "00000000";//根据一个算法产生ID
            const string defaultPassword = "12345678";//初始密码12345678,需要设为全局

            staff newStaff = new staff
            {
                staffId = tempId,
                staffName = newStaffName,
                password = defaultPassword
            };
            
            //写入数据库
            using (YMDBEntities db = new YMDBEntities())
            {
                try
                {
                    db.staff.Add(newStaff);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("添加新员工异常");
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }


            return newStaff.staffId;
        }

        /*
         * 3.删除员工
         * 参数：员工id
         * 返回值：成功返回true，失败或员工不存在返回false
         * 未完成
         */
        public bool deleteStaffById(string deletedStaffId)
        {
            bool deletdSucceed = false;
            string queryDeletedStaffSql = "delete from staff where staff.staffId=" + deletedStaffId;

            //从数据库中查询要删除的员工
            using (YMDBEntities db = new YMDBEntities())
            {
                
                //数据库删除员工
                //成功后将deletedSucceed赋值为true
                
            }

            return deletdSucceed;
        }


        /**
         * 4.更改员工信息
         * 参数：员工id，姓名，电话，密码
         * 返回值：成功返回true，失败返回false
         */
        public bool modifyPersonalInformation(staff currentInfo)
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

        /*
         * 8.根据ID查找员工
         * 参数：员工id
         * 返回值：员工类
         */
        public staff findStaffById(string id)
        {
            staff wantStaff = null;

            using (YMDBEntities db = new YMDBEntities())
            {

            }

            return wantStaff;
        }

    }
}