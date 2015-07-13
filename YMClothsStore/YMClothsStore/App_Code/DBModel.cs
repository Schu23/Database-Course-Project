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
            using (LFMSContext db = new LFMSContext())
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
    }
}