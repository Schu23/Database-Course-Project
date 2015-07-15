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
        private DBModel()
        { }
        //构成单例子
        public static DBModel sharedDBModel()
        {
            if (dbModel == null)
            {
                dbModel = new DBModel();
            }
            return dbModel;
        }

        /**
         * 创建对应表的主键
         * 参数：表名称
         * 返回值：主键
         * 需要测试
         */
        public string createNewId(string tableName)
        {
            //id格式：数据库表名+"_"+ 行号 + "_" + 日期后六位
            //例如：staff_1_000000
            string newId = tableName + "_";
            using (YMDBEntities db = new YMDBEntities())
            {
                int countNum = db.Database.ExecuteSqlCommand("select count(*) from \"" + tableName + "\"");
                newId += countNum;
                newId = newId + "_";
            }

            DateTime currentTime = DateTime.Now;
            string timeStr = currentTime.Ticks.ToString();
            Console.WriteLine("time:" + timeStr);
            timeStr = timeStr.Substring(timeStr.Length - 6, 6);
            newId += timeStr;

            return newId;
        }

        /**
         * 1.查询店铺员工信息
         * 参数：店铺id：shopId
         * 返回值：成功返回该店铺员工信息Array，失败返回null
         * 需要测试
         */
        public staff[] findStaffInformationById(string shopId)
        {
            staff[] staffs = { };
            using (YMDBEntities db = new YMDBEntities())
            {
                staffs = db.staff.Where(p => p.shopId == shopId).ToArray();
            }

            return staffs;
        }
        /**
         * 2.添加新员工
         * 参数：新员工名字
         * 返回值：成功返回员工id，失败返回0
         * 需要测试
         */
        public staff addNewStaff(string newStaffName)
        {
            string newId = "1234567890";// createNewId("staff");//根据一个算法产生ID
            const string defaultPassword = "12345678";//初始密码12345678,需要设为全局

            staff newStaff = new staff
            {
                staffId = newId,
                staffName = newStaffName,
                password = defaultPassword,
                staffLoginName = newStaffName,
                shopId = "121",
                staffJob = 1,
                staffGender = "male",
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
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }


            return newStaff;
        }

        /*
         * 3.删除员工
         * 参数：员工id
         * 返回值：成功返回true，失败或员工不存在返回false
         * 需要测试
         */
        public bool deleteStaffById(string deletedStaffId)
        {
            bool deletdSucceed = false;

            //从数据库中查询要删除的员工
            using (YMDBEntities db = new YMDBEntities())
            {

                //数据库删除员工
                //成功后将deletedSucceed赋值为true
                db.staff.Remove(db.staff.Where(p => p.staffId == deletedStaffId).SingleOrDefault());
                db.SaveChanges();
                deletdSucceed = true;
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

            using (YMDBEntities db = new YMDBEntities())
            {
                try
                {
                    staff oldStaff = db.staff.Where(p => p.staffId == currentInfo.staffId).FirstOrDefault();
                    System.Diagnostics.Debug.WriteLine(oldStaff.password);
                    oldStaff.staffName = currentInfo.staffName;
                    oldStaff.password = currentInfo.password;
                    oldStaff.staffPhone = currentInfo.staffPhone;
                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }

            return false;
        }

        /*
         * 5.增加新门店
         * 参数：店长id，新门店地址，新门店电话
         * 返回值：门店id，失败返回"false"
         */
        public string addNewShop(string newShopAddress, string newShopPhone)
        {
            string isSecceed = "新建门店失败";
            shop newShop = new shop
            {
                shopAddress = newShopAddress,
                shopPhone = newShopPhone,
                shopId = createNewId("shop"),   //需要设计一个算法给出shop的id
            };
            //写入数据库
            using (YMDBEntities db = new YMDBEntities())
            {
                try
                {
                    db.shop.Add(newShop);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }

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
            using (YMDBEntities db = new YMDBEntities())
            {
                //根据门店ID来查询并删除数据库中的门店
                db.shop.Remove(db.shop.Where(p => p.shopId == shopId).SingleOrDefault());
                db.SaveChanges();
                isSucceed = true;
            }
            return isSucceed;
        }

        /*
         * 7.修改门店信息
         * 参数：门店id，新地址，新电话，不修改的值为null
         * 返回值：bool,成功返回true，失败返回false
         */
        public bool modifyShopInfo(string shopId, string newAddress, string newPhone)
        {
            bool isSucceed = false;
            using (YMDBEntities db = new YMDBEntities())
            {
                try
                {
                    shop shopToChangeInfo = db.shop.Where(p => p.shopId == shopId).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }

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
                try
                {
                    wantStaff = db.staff.Where(p => p.staffId == id).FirstOrDefault();
                    return wantStaff;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }

            return null;
        }

        /**
          * 9.员工登陆接口
          * 参数：userName，password
          * 返回值：bool
          */
        public staff loginWithStaffLoginNameAndPassword(string userName, string pass)
        {
            staff loginStaff = null;
            using (YMDBEntities db = new YMDBEntities())
            {
                try
                {
                    loginStaff = db.staff.Where(p => p.staffName == userName).FirstOrDefault();
                    if (loginStaff.password.Equals(pass))
                    {
                        return loginStaff;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                    return null;
                }

            }

        }
        /**
         * 10.增加地址接口
         * 参数：
         */
        public address addAddressInfo(string newAddressName, string newAddressDetail)
        {
            return null;
        }

        /**
         * 11.根据员工姓名查找员工信息(支持部分查询)
         * 参数：员工姓名
         * 返回值：员工staff数组
         */
        public staff[] findStaffsByName(string name)
        {
            staff[] staffs = { };
            using (YMDBEntities db = new YMDBEntities())
            {
                string sql = "select * from \"staff\" where \"staffName\" like '%" + name + "%'";
                staffs = db.Database.SqlQuery<staff>(sql).ToArray();
            }

            return staffs;
        }

    }
}