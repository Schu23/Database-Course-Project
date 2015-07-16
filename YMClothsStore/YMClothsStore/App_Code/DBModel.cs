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
         * 创建对应表的主键
         * 参数：表名称
         * 返回值：主键
         * 需要测试
         */
        public string createNewId(string tableName)
        {
            //id格式：数据库表名 + "_" + 日期后六位
            //例如：staff_000000
            string newId = tableName + "_";
            /*using (YMDBEntities db = new YMDBEntities())
            {
                int countNum;
                switch (tableName)
                {
                    case "staff":
                        countNum = db.staff.Count();
                        break;
                    case "shop":
                        countNum = db.shop.Count();
                        break;
                    default:
                        countNum = -2;
                        break;
                }
                countNum++;
                newId += countNum;
                newId = newId + "_";
            }*/

            DateTime currentTime = DateTime.Now;
            string timeStr = currentTime.Ticks.ToString();
            Console.WriteLine("time:" + timeStr);
            timeStr = timeStr.Substring(timeStr.Length - 6, 6);
            newId += timeStr;

            return newId;
        }

        /**
         * 1.根据shopId查询店铺员工信息
         * 参数：店铺id：shopId
         * 返回值：成功返回该店铺员工信息Array，失败返回空数组
         * 需要测试
         */
        public staff[] findStaffsByShopId(string shopId)
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
         */
        public staff addNewStaff(string newStaffName, string newStaffPassword, string newShopId, int newStaffJob, string newGender)
        {
            string newId = createNewId("staff");//根据一个算法产生ID

            staff newStaff = new staff
            {
                staffId = newId,
                staffName = newStaffName,
                password = newStaffPassword,
                staffLoginName = newStaffName,
                shopId = newShopId,
                staffJob = newStaffJob,
                staffGender = newGender,
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
                    System.Diagnostics.Debug.WriteLine("员工添加异常");
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
            return newStaff;
        }

        /*
         * 3.删除员工
         * 参数：员工id
         * 返回值：成功返回true，失败或员工不存在返回false
         */
        public bool deleteStaffByStaffId(string deletedStaffId)
        {
            bool deletdSucceed = false;

            //从数据库中查询要删除的员工
            using (YMDBEntities db = new YMDBEntities())
            {
                
                //数据库删除员工
                //成功后将deletedSucceed赋值为true
                db.staff.Remove(db.staff.Where(p => p.staffId == deletedStaffId).FirstOrDefault());
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
                    oldStaff.staffLoginName = currentInfo.staffLoginName;
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
         * 返回值：门店实例，失败返回null
         */
        public shop addNewShopWithManagerIdAndAddressIdAndShopPhone(string newShopManagerId, string newShopAddress, string newShopPhone)
        {
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

            return newShop;
        }

        /*
         * 6.删除门店
         * 参数：门店id
         * 返回值：bool
         */
        public bool deletdShopByShopId(string shopId)
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
            using(YMDBEntities db = new YMDBEntities())
            {
                 try
                 {
                     shop shopToChangeInfo = db.shop.Where(p => p.shopId == shopId).FirstOrDefault();
                  }
                catch(Exception ex)
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
        public staff findStaffByStaffId(string id)
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
                    loginStaff = db.staff.Where(p => p.staffLoginName == userName).FirstOrDefault();
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
         * 10.添加新的地址以供选择
         * 参数：新地址名称或代号，新地址详细信息（街道等）
         * 返回值：address实例
         */
        /*public address addAddressInfo(string newAddressName, string newAddressDetail)
        {
            address newAddress = null;

            return newAddress;
        }*/

        /**
         * 11.根据shopId查找shop
         * 参数：shopId
         * 返回值：staff
         */
        public shop findShopByShopId(string targetShopId)
        {
            using (YMDBEntities db = new YMDBEntities())
            {
                shop targetShop = db.shop.Where(p => p.shopId == targetShopId).FirstOrDefault();
                return targetShop;
            }

        }

        /**
         * 12.使用模糊查询，通过员工姓名查找员工
         * 参数：员工名字的全部或是一部分
         * 返回值：符合条件的staff[]
         */
        public staff[] getStaffWithStaffName(string staffName)
        {

            staff[] staffs = { };
            using (YMDBEntities db = new YMDBEntities())
            {
                string sql = "select * from \"staff\" where \"staffName\" like '%" + staffName + "%'";
                staffs = db.Database.SqlQuery<staff>(sql).ToArray();
            }

            return staffs;
        }

        /**
         * 13.员工查看自己店铺的订单信息(未测)
         * 参数：员工id
         * 返回值：order[]
         */
        public order[] getAllOrderInfo(string staffId)
        {
            order[] orders = { };

            string shopId = getShopIdByStaffId(staffId);

            //员工只可以查看自己店铺的订单
            using (YMDBEntities db = new YMDBEntities()) 
            {
                orders = db.order.Where(p => p.shopId == shopId).ToArray();
            }

            return orders;
        }

        /**
         * 14.员工查看某个订单的普通信息
         * 参数：订单id
         * 返回值：订单实例(测试通过)
         */
        public order getOrderInfoByOrderId(string orderId)
        {
            order targetOrder = null;


            using (YMDBEntities db = new YMDBEntities())
            {
                targetOrder = db.order.Where(p => p.orderId == orderId).FirstOrDefault();
            }
            return targetOrder;
        }

        /**
         * 15.员工查看订单的详细信息
         * 参数：订单Id
         * 返回值：员工所在商店的某件商品的订单详情数组（通过测试）
         */
        public orderDetail[] getOrderDetailInfoByOrderId(string orderId)
        {
            orderDetail[] currentOrderDetails = { };

            using (YMDBEntities db = new YMDBEntities())
            {
                currentOrderDetails = db.orderDetail.Where(p => p.orderId == orderId).ToArray();
            }

            return currentOrderDetails;
        }

        /**
         * 16.通过员工id获取所在shop的id
         * 参数：员工Id
         * 返回值：员工所在shop的id（通过测试）
         */
        public string getShopIdByStaffId(string targetStaffId)
        {
            string targetShopId = "";

            using (YMDBEntities db = new YMDBEntities())
            {
                targetShopId = db.staff.Where(p => p.staffId == targetStaffId).FirstOrDefault().shopId;
            }

            return targetShopId;
        }

        /**
         * 17.员工增加订单记录
         * 参数：staffId, 这次订单的详细信息数组
         * 返回值：本次订单（需要修改stock）             //个人感觉这个不需要修改库存，在添加细节的时候再修改库存------->请注意
         */
        public order addOrderInfo(string staffId)
        {
            string newId = createNewId("order");

            using (YMDBEntities db = new YMDBEntities())
            {
                staff staff = db.staff.Where(p => p.staffId == staffId).FirstOrDefault();
                order targetOrder = new order
                {
                    orderId = newId,
                    shopId =staff.shopId,
                    totalPrice = 0,
                    orderTime = DateTime.Now,
                };
                db.order.Add(targetOrder);
                return targetOrder;
            }
            return null;
        }

        /**
         * 18.员工在订单中添加一条订单详细信息
         * 参数：订单Id,货物Id,货物数量
         * 返回：成功返回true,失败返回false
         * 注意：不要重复添加某一条商品的信息（需要修改stock）(未测)
         */
        public bool addOrderDetailToOrderWithOrderIdAndItemIdAndItemAmount(string newOrderId, string newItemId, int newItemAmount)
        {
            bool isSucceed = false;

            using(YMDBEntities db = new YMDBEntities())
            {
                order currentOrder = db.order.Where(p => p.orderId == newOrderId).FirstOrDefault();
                orderDetail currentOrderDetail = new orderDetail
                {
                    orderId = newOrderId,
                    itemId = newItemId,
                    itemAmount = newItemAmount,
                };
                db.orderDetail.Add(currentOrderDetail);
                item currentItem = db.item.Where(p => p.itemId == newItemId).FirstOrDefault();
                currentOrder.totalPrice = currentOrder.totalPrice + currentItem.itemPrice * newItemAmount;

                stock currentStock = db.stock.Where(p => p.shopId == currentOrder.shopId & p.itemId == newItemId).FirstOrDefault();
                currentStock.stockAmount = currentStock.stockAmount - newItemAmount;
                currentStock.saleAmount = newItemAmount;

                db.SaveChanges();
                
            }

            return isSucceed;
        }

        /**
         * 19.员工查看本店库存
         * 参数：员工Id
         * 返回值：员工所在商店的所有库存信息(通过测试)
         */
        public stock[] getShopStockInfoByStaffId(string staffId)
        {
            stock[] targetStock = null;

            using (YMDBEntities db = new YMDBEntities())
            {
                string shopId = getShopIdByStaffId(staffId);
                targetStock = db.stock.Where(p => p.shopId == shopId).ToArray();
            }

            return targetStock;
        }

        /**
         * 20.员工查看某商品在本店的库存
         * 参数：员工Id, 商品Id
         * 返回：员工所在商店的某件商品的库存(通过测试)
         */
        public stock getItemStockInThisShop(string staffId, string itemId)
        {
            stock currentStock = null;

            using (YMDBEntities db = new YMDBEntities())
            {
                string shopId = getShopIdByStaffId(staffId);
                currentStock = db.stock.Where(p => p.shopId == shopId & p.itemId == itemId).FirstOrDefault();
            }

            return currentStock;
        }

        /**
         * 21.员工查看某商品在系统的库存
         * 参数：货物Id
         * 返回值：系统中的某件商品的所有库存(通过测试)
         */
        public stock[] getItemStockInSystem(string itemId)
        {
            stock[] currentAllStock = null;

            using (YMDBEntities db = new YMDBEntities())
            {
                currentAllStock = db.stock.Where(p => p.itemId == itemId).ToArray();
            }

            return currentAllStock;              
        }

        /**
         * 22.员工查看总库库存
         * 返回值：原木衣橱总库库存信息数组(通过测试)
         */
        public stock[] getSystemStockInfo()
        {
            stock[] currentSystemStock = null;

            using (YMDBEntities db = new YMDBEntities())
            {
                string sql = "select * from \"stock\"";
                currentSystemStock = db.Database.SqlQuery<stock>(sql).ToArray();
            }

            return currentSystemStock;
        }

        /**
         * 23.员工新建入库登记表
         * 参数：员工Id
         * 返回：一个新添加的入库登记表(通过测试)                      //个人感觉这个不需要修改库存，在添加细节的时候再修改库存------->请注意
         */
        public inBase addNewIn(string inStaffId){
            inBase newInBase = null;
            string currentShopId = getShopIdByStaffId(inStaffId);

            using (YMDBEntities db = new YMDBEntities())
            {
                string newId = createNewId("inBase");
                newInBase = new inBase
                {
                    inId = newId,
                    shopId = currentShopId,
                    staffId = inStaffId,
                    inTime = DateTime.Now,
                };
                db.inBase.Add(newInBase);
                db.SaveChanges();
            }

            return newInBase;
        }

        /**
         * 24.员工为新建的入库登记表填写详细信息
         * 参数：入库Id,商品Id,商品数量Amount
         * 返回：是否成功入库(未测)                          //增加修改库存信息
         */
        public bool addInDetailToInWithItemIdAndItemAmount(string currentInId, string currentItemId, int currentItemAmount)
        {
            bool isSucceed = false;

            using (YMDBEntities db = new YMDBEntities())
            {
                inDetail currentInDetail = new inDetail
                {
                    inId = currentInId,
                    itemId = currentItemId,
                    inAmount = currentItemAmount,
                };
                db.inDetail.Add(currentInDetail);

                inBase currentInBase = db.inBase.Where(p => p.inId == currentInId).FirstOrDefault();

                stock currentStock = db.stock.Where(p => p.shopId == currentInBase.shopId & p.itemId == currentItemId).FirstOrDefault();
                currentStock.stockAmount = currentStock.stockAmount + currentItemAmount;

                db.SaveChanges();
            }

            return isSucceed;
        }

        /**
         * 25.员工新建出库登记表
         * 参数：员工Id,出库类型
         * 返回：员工新建一个出库登记表(未测)                              //个人感觉这个不需要修改库存，在添加细节的时候再修改库存------->请注意
         */
        public outBase addNewOut(string outStaffId,string currentOutType)
        {
            outBase newOutBase = null;
            string currentShopId = getShopIdByStaffId(outStaffId);

            using (YMDBEntities db = new YMDBEntities())
            {
                string newId = createNewId("outBase");
                newOutBase = new outBase
                {
                    outId = newId,
                    shopId = currentShopId,
                    staffId = outStaffId,
                    outType = currentOutType,
                    outTime = DateTime.Now,
                };
                db.outBase.Add(newOutBase);
                db.SaveChanges();
            }

            return newOutBase;
        }

        /**
         * 26.员工为新建的出库登记表添加详细信息
         * 参数：货物Id，货物数量
         * 返回：是否成功出库(未测)                                   //增加修改库存信息
         */
        public bool addOutDetailToOutWithItemIdAndItemAmount(string currentOutId, string currentItemId, int currentItemAmount)
        {
            bool isSucceed = false;

            using (YMDBEntities db = new YMDBEntities())
            {
                outDetail currentOutDetail = new outDetail
                {
                    outId = currentOutId,
                    itemId = currentItemId,
                    outAmount = currentItemAmount,
                };
                db.outDetail.Add(currentOutDetail);

                outBase currentOutBase = db.outBase.Where(p => p.outId == currentOutId).FirstOrDefault();

                stock currentStock = db.stock.Where(p => p.shopId == currentOutBase.shopId & p.itemId == currentItemId).FirstOrDefault();
                currentStock.stockAmount = currentStock.stockAmount - currentItemAmount;

                db.SaveChanges();
            }

            return isSucceed;
        }

        /**
         * 27.员工页面显示最近五件最热商品
         * 参数：无（根据当前月查询）
         * 返回：商品数组（数量5）(未测试)
         */
        public string[,] topFiveItems(string staffId)
        {
            string[,] returnItems = new string[5, 3];
            stock[] allItems = { };
            using (YMDBEntities db = new YMDBEntities())
            {
                //string sql = "select * from \"orderDetail\"";
                //allItems = db.Database.SqlQuery<stock>(sql).ToArray();

                string shopId = getShopIdByStaffId(staffId);

                //默认为升序
                allItems = db.stock.OrderBy(p => p.saleAmount).Where(p => p.shopId == shopId).ToArray();

                string[] nameItem = { };
                string[] imageItem = { };
                string[] itemId = { };

                for (int i = allItems.Length - 1; i > 0; i--)
                {
                    item currenItem = db.item.Where(p => p.itemId == allItems[i].itemId).FirstOrDefault();
                    image currentItemImage = db.image.Where(p => p.itemId == allItems[i].itemId).FirstOrDefault();
                    itemId[i] = allItems[i].itemId;
                    nameItem[i] = currenItem.itemName;
                    imageItem[i] = currentItemImage.imagePath;
                    returnItems[i, 0] = itemId[i];
                    returnItems[i, 1] = nameItem[i];
                    returnItems[i, 2] = imageItem[i];
                }

                   
            }
            return returnItems;
        }

        /**
         * 28.员工页面显示这个月每日销售总价（？需要每个月都传么？No）
         * 参数：无
         * 返回：本月每日销售总价的集合
         * 备注：不太确定返回值类型是float还是decimal(未测试)
         */
        public decimal[] getEverySumOfThisMonth(string staffId)
        {
            //dictionary<datetime,float> returnorders = new dictionary<datetime,float>();
            //datetime now = datetime.now;
            //int currentmonth = now.month;
            //int currentyear = now.year;
            //datetime currentdate =  now.date;
            //string currentdatestr = currentyear.tostring() + currentmonth.tostring() + currentdate.tostring();
            //datetime currentdatetime = convert.todatetime(currentdatestr);
            //order[] allorders = { };
            //using(ymdbentities db = new ymdbentities())
            //{
            //    allorders = db.order.where(p => p.ordertime >= currentdatetime).toarray();
            //    for (int i = 0; i < allorders.length; i++)
            //{
            //    if (currentmonth == 1 || currentmonth == 3 || currentmonth == 5 || currentmonth == 7 || currentmonth == 8 || currentmonth == 10 || currentmonth == 12)
            //    {
            //        for (int i = 0; i < 31; i++)
            //        {
            //            if(db.order.where(p=>p.ordertime == allorders[i].ordertime))
            //        }
            //    }
            //    else if (currentmonth == 4 || currentmonth == 6 || currentmonth == 9 || currentmonth == 11)
            //    {
            //        for (int i = 0; i < 30; i++)
            //        {

            //        }
            //    }
            //    else
            //    {
            //        if ((currentyear % 4 == 0 && currentyear %100 != 0)||currentyear%400 == 0)
            //        {
            //            for (int i = 0; i < 29; i++)
            //            {

            //            }
            //        }else
            //        {
            //            for (int i = 0; i < 28; i++)
            //            {

            //            }
            //        }
            //    }
            //}
                
            //}

            string shopId = getShopIdByStaffId(staffId);

            decimal[] returnOrders = new decimal[30];
            using (YMDBEntities db = new YMDBEntities())
            {
                for (int i = 0; i < 30; i++)
                {
                    DateTime d = DateTime.Now;
                    DateTime tempDate = d.AddDays(0 - i);
                    order[] tempOrderArray = db.order.Where(p => p.orderTime == tempDate & p.shopId == shopId).ToArray();
                    System.Diagnostics.Debug.WriteLine("tempOrderArraySize:"+tempOrderArray.Length);
                    System.Diagnostics.Debug.WriteLine(tempDate);
                    if (tempOrderArray.Length == 0)
                    {
                        returnOrders[i] = 0;
                    }
                    else
                    {
                        //这个类型不太确定
                        decimal tempSumPrice = 0;
                        for (int j = 0; j < tempOrderArray.Length; j++)
                        {
                            tempSumPrice += tempOrderArray[j].totalPrice;
                        }
                        returnOrders[i] = tempSumPrice;
                    }
                }
            }
            return returnOrders;
        }

        /**
         * 29.员工查询商品信息
         * 参数：员工Id
         * 返回：本店所有商品信息的集合(未测)
         */
        public item[] getAllItemsOfThisShop(string staffId) {
            item[] items = { };

            string shopId = getShopIdByStaffId(staffId);

            using (YMDBEntities db = new YMDBEntities())
            {
                stock[] currentStock = db.stock.Where(p => p.shopId == shopId).ToArray();
                for (int i = 0; i < currentStock.Length; i++)
                {
                    items[i] = db.item.Where(p => p.itemId == currentStock[i].itemId).FirstOrDefault();
                }
            }

            return items;
        }

        /**
         * 30.通过商品Id查询商品详细信息(查完库存调用此接口显示某商品详细信息)
         * 参数：商品Id
         * 返回：本店某一个商品(未测)
         */
        public item getItemByItemId(string itemId)
        {
            item newItem = null;

            using (YMDBEntities db = new YMDBEntities())
            {
                newItem = db.item.Where(p => p.itemId == itemId).FirstOrDefault();
            }

            return newItem;
        }

        /**
         * 31.通过商品名查找商品
         * 参数：商品Name
         * 返回：本店某一个商品
         * 备注：模糊搜索(未测)
         */
        public item[] getItemByItemName(string itemName)
        {
            item[] items = { };

            using (YMDBEntities db = new YMDBEntities())
            {
                string sql = "select * from \"item\" where \"itemName\" like '%" + itemName + "%'";
                items = db.Database.SqlQuery<item>(sql).ToArray();
            }

            return items;
        }

        /**
         * 32.店长进行盘点(最终目的是检查是否有人偷东西)
         * 参数：员工Id
         * 返回：最近现在各个商品集合（包括名称和）
         * 备注：其实可以通过库存方法来获取(未测)
         */
        public checkDetail[] getCheckDetailInfoWithStaffId(string currentCheckId, string staffId)
        {
            checkDetail[] checks = { };

            currentCheckId = createNewId("checkDetail");

            string shopId = getShopIdByStaffId(staffId);

            using (YMDBEntities db = new YMDBEntities())
            {
                stock[] itemStock = db.stock.Where(p => p.shopId == shopId).ToArray();
                checkDetail[] currentCheckDetail = { };
                for (int i = 0; i < itemStock.Length; i++)
                {
                    currentCheckDetail[i] = new checkDetail
                    {
                        itemId = itemStock[i].itemId,
                        checkId = currentCheckId,
                        currentAmount = itemStock[i].stockAmount,
                    };
                    db.checkDetail.Add(currentCheckDetail[i]);
                }
                db.SaveChanges();
            }

            return checks;
        }

        /**
         * 33.店长更改订单信息
         * 参数：要修改的Order的Id,店长的Id
         * 返回：返回修改过的Order实例(未测)
         */
        public orderDetail modifyOrderInfoWithOrderIdByShopManager(string originOrderId, string staffId, string currentItemId, int currentItemAmount)
        {
            orderDetail newOrder = null;

            using(YMDBEntities db = new YMDBEntities())
            {
                order currentOrder = db.order.Where(p => p.orderId == originOrderId).FirstOrDefault();
                newOrder = db.orderDetail.Where(p => p.itemId == currentItemId & p.orderId == originOrderId).FirstOrDefault();
                item currentItem = db.item.Where(p => p.itemId == newOrder.itemId).FirstOrDefault();
                decimal itemPrice = currentItem.itemPrice;
                decimal oldItemAmount = newOrder.itemAmount;
                newOrder.itemAmount = currentItemAmount;
                currentOrder.totalPrice = currentOrder.totalPrice - itemPrice * oldItemAmount + itemPrice * currentItemAmount;
                db.SaveChanges();
            }
            return newOrder;
        }

        /**
         * 34.店长申请从总库补货
         * 参数：店长的Id
         * 返回：新建的补货申请表
         * 备注：申请表的状态默认同意状态(未测)
         */
        public apply addApplyFromSystem(string staffId)
        {
            apply newApply = null;

            string newId = createNewId("apply");
            string shopId = getShopIdByStaffId(staffId);

            using (YMDBEntities db = new YMDBEntities())
            {
                newApply = new apply
                {
                    applyId = newId,
                    outShop = "SYSTEM",
                    inShop = shopId,
                    state = "ok",
                    applyTime = DateTime.Now,
                };
                db.apply.Add(newApply);
                db.SaveChanges();
            }

            return newApply;
        }

        /**
         * 35.店长为申请添加条目(补货)
         * 参数：申请表Id，货物Id和货物数量
         * 返回：是否成功添加了申请表细节(未测)
         */
        public bool addApplyDetailInfoFromSystemWithApplyIdItemIdAndItemAmount(string currentApplyId,string currentItemId, int currentItemAmount) 
        {
            bool isSucceed = false;

            using (YMDBEntities db = new YMDBEntities())
            {
                applyDetail tem = db.applyDetail.Where(p => p.applyId == currentApplyId & p.itemId == currentApplyId).FirstOrDefault();
                if (tem == null)
                {
                    applyDetail newApplyDetail = new applyDetail
                    {
                        applyId = currentApplyId,
                        itemId = currentItemId,
                        applyAmount = currentItemAmount,
                    };
                    db.applyDetail.Add(newApplyDetail);
                }
                else
                {
                    tem.applyAmount = tem.applyAmount + currentItemAmount;
                }
                db.SaveChanges();
            }

            return isSucceed;
        }

        /**
         * 36.店长申请从其他店面调货
         * 参数：店长的Id，对方店面的Id
         * 返回：新建的调货申请表
         * 备注：申请表的状态需要设置为申请状态(未测)
         */
        public apply addApplyFromOtherShop(string staffId, string otherShopId)
        {
            apply newApply = null;

            string shopId = getShopIdByStaffId(staffId);
            string newId = createNewId("apply");

            using (YMDBEntities db = new YMDBEntities())
            {
                newApply = new apply
                {
                    applyId = newId,
                    outShop = otherShopId,
                    inShop = shopId,
                    state = "ok",
                    applyTime = DateTime.Now,
                };
                db.apply.Add(newApply);
                db.SaveChanges();
            }

            return newApply;
        }

        /**
         * 37.店长为申请添加条目(调货)
         * 参数：申请表Id，货物Id和货物数量
         * 返回：是否成功添加了申请表细节(未测)
         */
        public bool addApplyDetailInfoFromOtherShopWithApplyIdItemIdAndItemAmount(string currentApplyId,string currentItemId, int currentItemAmount) 
        {
            bool isSucceed = false;

            using (YMDBEntities db = new YMDBEntities())
            {
                apply outShop = db.apply.Where(p => p.applyId == currentApplyId).FirstOrDefault();
                stock itemStock = db.stock.Where(p => p.shopId == outShop.outShop & p.itemId == currentItemId).FirstOrDefault();
                decimal realAmount = itemStock.stockAmount;
                if (currentItemAmount > realAmount)
                {
                    return false;
                }
                else
                {
                    applyDetail tem = db.applyDetail.Where(p => p.applyId == currentApplyId & p.itemId == currentApplyId).FirstOrDefault();

                    if (tem == null)
                    {
                        applyDetail newApplyDetail = new applyDetail
                        {
                            applyId = currentApplyId,
                            itemId = currentItemId,
                            applyAmount = currentItemAmount,
                        };
                        db.applyDetail.Add(newApplyDetail);
                    }
                    else
                    {
                        if (tem.applyAmount + currentItemAmount > realAmount)
                        {
                            return false;
                        }
                        else
                        {
                            tem.applyAmount = tem.applyAmount + currentItemAmount;
                        }
                    }
                    db.SaveChanges();
                }
            }

            return isSucceed;
        }

        /**
         * 38.店长对其他店的申请进行审批
         * 参数：店长Id，是否同意bool值
         * 返回：审批是否成功的bool值(未测)
         */
        public bool dealWithApplyFromOtherShop(string currentApplyId, string staffId, bool dealFlag)
        {
            bool isAgree = true;

            string shopId = getShopIdByStaffId(staffId);

            using (YMDBEntities db = new YMDBEntities())
            {
                apply currentApply = db.apply.Where(p => p.applyId == currentApplyId & p.outShop == shopId).FirstOrDefault();
                if(dealFlag == true)
                {
                    currentApply.state = "pass";
                }
                else
                {
                    currentApply.state = "not_pass";
                    isAgree = false;
                }
                db.SaveChanges();
            }

            return isAgree;
        }

        /**
         * 39.Boss增加商品
         * 参数：新增商品的名字、尺寸、颜色、价格
         * 返回：商品实例(未测)
         */
        public item addItemByBoss(string currentItemName, string currentItemSize, string currenttemColor, float currentItemPrice)
        {
            item newItem = null;

            string newId = createNewId("item");

            using (YMDBEntities db = new YMDBEntities())
            {
                newItem = new item
                {
                    itemName = currentItemName,
                    itemSize = currentItemSize,
                    itemPrice = (decimal)currentItemPrice,
                    itemColor = currenttemColor,
                    itemDate = DateTime.Now,
                    itemId = newId,
                    itemStatus = 1,
                };
                db.item.Add(newItem);
                db.SaveChanges();
            }

            return newItem;
        }


        /**
         * 40.Boss增加商品的图片信息
         * 参数：需要增加的商品的Id，图片的地址（或者编号）
         * 返回：图片实例(未测)
         */
        public image addImageToItem(string currentItemId, string currentImagePath)
        {
            image newImage = null;

            using (YMDBEntities db = new YMDBEntities())
            {
                newImage = new image
                {
                    imagePath = currentImagePath,
                    itemId = currentItemId,
                };
                db.image.Add(newImage);
                db.SaveChanges();
            }

            return newImage;
        }

        /**
         * 41.Boss修改商品信息
         * 参数：修改后的商品的名字、尺寸、颜色、价格
         * 返回：商品实例(未测)
         */
        public item modifyItemByBoss(string currentItemId, string currentItemName, string currentItemSize, string currentItemColor, float currentItemPrice)
        {
            item newItem = null;

            using (YMDBEntities db = new YMDBEntities())
            {
                newItem = db.item.Where(p => p.itemId == currentItemId).FirstOrDefault();
                newItem.itemName = currentItemName;
                newItem.itemSize = currentItemSize;
                newItem.itemColor = currentItemColor;
                newItem.itemPrice = (decimal)currentItemPrice;
                db.SaveChanges();
            }

            return newItem;
        }

        /**
         * 42.Boss修改商品状态
         * 参数：商品Id，商品的新状态
         * 返回：是否修改成功(未测)
         */
        public bool modifyStatusOfItem(string currentItemId, int newStatus)
        {
            bool isSucceed = false;

            using (YMDBEntities db = new YMDBEntities())
            {
                item currentItem = db.item.Where(p => p.itemId == currentItemId).FirstOrDefault();
                currentItem.itemStatus = newStatus;
                db.SaveChanges();
                isSucceed = true;
            }
            return isSucceed;
        }

        /**
         * 43.Boss指派店长
         * 参数：商店Id，新店长的Id
         * 返回：新店长的实例(未测)
         */
        public staff assignManagerToShop(string currentStaffName, string currentStaffPassword, string currentShopId, string currentGender, string currentStaffLoginName)
        {
            staff newStaff = null;

            string newId = createNewId("staff");//根据一个算法产生ID

            newStaff = new staff
            {
                staffId = newId,
                shopId = currentShopId,
                staffName = currentStaffName,
                password = currentStaffPassword,
                staffGender = currentGender,
                staffLoginName = currentStaffLoginName,
                staffJob = 1,
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

        /**
         * 44.Boss新增地址信息
         * 参数：地址名称，详细地址
         * 返回：新的地址的实例
         * 完成测试
         */
        public address addNewAddress(string addressName, string addressDetail)
        {
            address newAddress = new address
            {
                addressId = createNewId("address"),
                addressName = addressName,
                addressDetail = addressDetail,
            };
            //写入数据库
            using(YMDBEntities db = new YMDBEntities())
            {
                try
                {
                    db.address.Add(newAddress);
                    db.SaveChanges();
                }
                catch(Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }

            return newAddress;
        }

        /**
         * 45.根据员工查看该店调货纪录
         * 参数：staffId
         * 返回值：调货记录数组(未测)
         */
        public apply[] checkAllApplyByStaffId(string staffId)
        {
            apply[] applys = { };

            string shopId = getShopIdByStaffId(staffId);

            using (YMDBEntities db = new YMDBEntities())
            {
                applys = db.apply.Where(p => p.outShop == shopId | p.inShop == shopId).ToArray();
            }

            return applys;
        }
        
    }
}