using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//用来从数据库获取数据并封装
namespace YMClothsStore.App_Code
{
    public class Staff
    {
        public int staffId { get; set; }
        public string staffName { get; set; }
        public string staffGender { get; set; }
        public string staffPhone { get; set; }
        public string staffJob { get; set; }
        public int shopId { get; set; }
        public string password { get; set; }
    }

    public class DBModel
    {

        /**
         * 查找员工信息
         * 参数：员工id：staffId
         * 返回值：成功返回员工信息，失败返回null
         */
        public Staff findStaffInformationById(string id)
        {
            Staff staff;

            using (YMClothsStoreContext db = new YMClothsStoreContext())
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

            return staff;
        }

        /**
         * 添加新员工
         * 参数：新员工名字
         * 返回值：成功返回员工id，失败返回0
         * 初始密码12345678
         */
        public int addStaff(string newStaffName)
        {
            int newStaffId;

            Staff newStaff = new Staff
            {
                staffName = newStaffName,
                password = "12345678"
            };
            
            //写入数据库
            using (YMClothsStoreContext db = new YMClothsStoreContext())
            {
                try
                {
                    db.QUESTION.Add(question);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Unique");
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }


            return newStaffId;
        }

        /**
         * 更改员工信息
         * 参数：员工id，姓名，电话，密码
         * 返回值：成功返回true，失败返回false
         */
        public bool modifyPersonalInformation(Staff currentInfo)
        {

            using (YMClothsStoreContext db = new YMClothsStoreContext())
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
            return false;
        }
    }
}