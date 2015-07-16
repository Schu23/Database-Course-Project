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

            DateTime currentTime = DateTime.Now;
            string timeStr = currentTime.Ticks.ToString();
            Console.WriteLine("time:" + timeStr);
            timeStr = timeStr.Substring(timeStr.Length - 10, 10);
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
                staffLoginName = newId,
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
            //从数据库中查询要删除的员工
            using (YMDBEntities db = new YMDBEntities())
            {
                try
                {                
                    //数据库删除员工
                    //成功后将deletedSucceed赋值为true
                    db.staff.Remove(db.staff.Where(p => p.staffId == deletedStaffId).FirstOrDefault());
                    db.SaveChanges();
                    return true;
                }
                catch (ArgumentNullException ex)
                {
                    System.Diagnostics.Debug.WriteLine("输入的staffId有问题.");
                    System.Diagnostics.Debug.WriteLine(ex.StackTrace);
                    return false;
                }
            }
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
                    oldStaff.staffLoginName = currentInfo.staffLoginName;
                    oldStaff.password = currentInfo.password;
                    oldStaff.staffPhone = currentInfo.staffPhone;
                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("修改失败，没有这员工.");
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                    return false;
                }
            }
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
                shopId = createNewId("shop"), 
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
                    System.Diagnostics.Debug.WriteLine("Address输入有误.");
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                    return null;
                }
            }

            return newShop;
        }


        /*
         * 7.修改门店信息
         * 参数：门店id，新地址，新电话,新的门店状态，不修改的值为null
         * 返回值：bool,成功返回true，失败返回false
         */
        public bool modifyShopInfo(string shopId, string newAddress,int newStatus, string newPhone)
        {
            bool isSucceed = false;
            using(YMDBEntities db = new YMDBEntities())
            {
                 try
                 {
                     shop shopToChangeInfo = db.shop.Where(p => p.shopId == shopId).FirstOrDefault();
                     shopToChangeInfo.shopAddress = newAddress;
                     shopToChangeInfo.shopStatus = newStatus;
                     shopToChangeInfo.shopPhone = newPhone;
                     db.SaveChanges();
                     isSucceed = true;
                  }
                catch(Exception ex)
                 {
                     System.Diagnostics.Debug.WriteLine("没找到shop或者输入参数绝对有问题，仔细查外键约束!!!!");
                     System.Diagnostics.Debug.WriteLine(ex.Message);
                     return false;
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
            using (YMDBEntities db = new YMDBEntities())
            {
                try
                {
                    staff wantStaff = db.staff.Where(p => p.staffId == id).FirstOrDefault();
                    return wantStaff;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("没找到这员工，输入有问题.");
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                    return null;
                }
            }
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
         * 12.使用模糊查询，通过员工姓名查找员工(测试通过)
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
         * 13.员工查看自己店铺的订单信息(测试通过)
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
        public order[] getOrderInfoByOrderId(string orderId)
        {
            using (YMDBEntities db = new YMDBEntities())
            {
                order[] targetOrder = db.order.Where(p => p.orderId == orderId).ToArray();
                return targetOrder;
            }
            
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
         * 返回值：员工所在shop的id,失败返回null（通过测试）
         */
        public string getShopIdByStaffId(string targetStaffId)
        {
            using (YMDBEntities db = new YMDBEntities())
            {
                try
                {
                    staff currentStaff = db.staff.Where(p => p.staffId == targetStaffId).FirstOrDefault();
                    string targetShopId = currentStaff.shopId;
                    return targetShopId;
                }
                catch (NullReferenceException ex)
                {
                    System.Diagnostics.Debug.WriteLine("该员工不存在或者该员工还不属于任何一个店.");
                    System.Diagnostics.Debug.WriteLine(ex.StackTrace);
                    return "";
                }
                
            }

        }

        /**
         * 17.员工增加订单记录
         * 参数：staffId, 这次订单的详细信息数组
         * 返回值：本次订单（需要修改stock）             //个人感觉这个不需要修改库存，在添加细节的时候再修改库存------->请注意
         */
        public order addOrderInfo(string staffId)
        {
            string newId = createNewId("order");
            string newId2 = "outBase_";
            for (int i = 6; i < newId.Length; i++)
            {
                newId2 = newId2 + newId[i];
            }
            string shopId = getShopIdByStaffId(staffId);

            using (YMDBEntities db = new YMDBEntities())
            {
                try
                {
                    staff targetStaff = findStaffByStaffId(staffId);
                    order targetOrder = new order
                    {
                        orderId = newId,
                        shopId = targetStaff.shopId,
                        totalPrice = 0,
                        orderTime = DateTime.Now,
                    };
                    db.order.Add(targetOrder);

                    outBase newOutBase = new outBase
                    {
                        outId = newId2,
                        shopId = shopId,
                        staffId = staffId,
                        outTime = DateTime.Now,
                        outType = "sell",
                    };
                    db.outBase.Add(newOutBase);

                    db.SaveChanges();
                    return targetOrder;
                }
                catch (NullReferenceException ex)
                {
                    System.Diagnostics.Debug.WriteLine("输入staffId的时候有问题，回去查!!!!!");
                    System.Diagnostics.Debug.WriteLine(ex.StackTrace);
                    return null;
                }
            }
        }

        /**
         * 18.员工在订单中添加一条订单详细信息
         * 参数：订单Id,货物Id,货物数量
         * 返回：成功返回true,失败返回false
         * 注意：不要重复添加某一条商品的信息(通过测试)
         */
        public bool addOrderDetailToOrderWithOrderIdAndItemIdAndItemAmount(string newOrderId, string newItemId, int newItemAmount)
        {
            using(YMDBEntities db = new YMDBEntities())
            {
                try
                {
                    string newId2 = "outBase_";
                    for (int i = 6; i < newOrderId.Length; i++)
                    {
                        newId2 = newId2 + newOrderId[i];
                    }

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
                    currentStock.saleAmount = currentStock.saleAmount + newItemAmount;

                    outDetail newOutBase = new outDetail
                    {
                        outId = newId2,
                        itemId = newItemId,
                        outAmount = newItemAmount,
                    };
                    db.outDetail.Add(newOutBase);

                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("添加orderDetail错误,可能是参数错误.");
                    System.Diagnostics.Debug.WriteLine(ex.StackTrace);
                    return false;
                }
                
                
            }
        }

        /**
         * 19.员工查看本店库存
         * 参数：员工Id
         * 返回值：员工所在商店的所有库存信息(通过测试)
         */
        public stock[] getShopStockInfoByStaffId(string staffId)
        {
            stock[] targetStock = { };

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
         * 返回：商品数组（数量5）(通过测试)
         */
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

                string[] nameItem = new string[5];
                string[] imageItem = new string[5];
                string[] itemId = new string[5];
                int j = 0;

                for (int i = allItems.Length - 1; i >= 0; i--)
                {
                    string id = allItems[i].itemId;
                    item currenItem = db.item.Where(p => p.itemId == id).FirstOrDefault();
                    image currentItemImage = db.image.Where(p => p.itemId == id).FirstOrDefault();
                    itemId[j] = allItems[i].itemId;
                    nameItem[j] = currenItem.itemName;
                    imageItem[j] = currentItemImage.imagePath;
                    returnItems[j, 0] = itemId[j];
                    returnItems[j, 1] = nameItem[j];
                    returnItems[j, 2] = imageItem[j];
                    j++;
                }


            }
            return returnItems;
        }


        /**
         * 28.员工页面显示这个月每日销售总价（？需要每个月都传么？No）
         * 参数：无
         * 返回：本月每日销售总价的集合
         * 备注：不太确定返回值类型是float还是decimal(测试通过)
         */
        public decimal[] getEverySumOfThisMonth(string staffId)
        {
            string shopId = getShopIdByStaffId(staffId);

            decimal[] returnOrders = new decimal[30];
            using (YMDBEntities db = new YMDBEntities())
            {
                for (int i = 0; i < 30; i++)
                {
                    DateTime d = DateTime.Now;
                    DateTime tempDate = d.AddDays(0 - i);
                    int tempYear = tempDate.Year;
                    int tempMonth = tempDate.Month;
                    int tempDay = tempDate.Day;
                    string tempDate0 = tempYear + "-" + tempMonth + "-" + tempDay + " 00:00:00";
                    string tempDate24 = tempYear + "-" + tempMonth + "-" + tempDay + " 23:59:59";
                    //DateTime tempDateTime0 = DateTime.ParseExact(tempDate0, "yyyy-MM-dd HH:mm:ss", null);
                    //DateTime tempDateTime24 = DateTime.ParseExact(tempDate24, "yyyy-MM-dd HH:mm:ss", null);
                    DateTime tempDateTime0 = Convert.ToDateTime(tempDate0);
                    DateTime tempDateTime24 = Convert.ToDateTime(tempDate24);
                    //datetime tempdatetime0 = tempdate;
                    //datetime tempdatetime24 = tempdate;
                    order[] tempOrderArray = db.order.Where(p => p.orderTime >= tempDateTime0 & p.orderTime <= tempDateTime24 & p.shopId == shopId).ToArray();
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
         * 返回：本店所有商品信息的集合(通过测试)
         */
        public item[] getAllItemsOfThisShop(string staffId) {
            string shopId = getShopIdByStaffId(staffId);

            using (YMDBEntities db = new YMDBEntities())
            {
                stock[] currentStock = db.stock.Where(p => p.shopId == shopId).ToArray();
                item[] items = new item[currentStock.Length];
                for (int i = 0; i < currentStock.Length; i++)
                {
                    string currentItemId = currentStock[i].itemId;
                    items[i] = db.item.Where(p => p.itemId == currentItemId).FirstOrDefault();
                }
                return items;
            }
        }

        /**
         * 30.通过商品Id查询商品详细信息(查完库存调用此接口显示某商品详细信息)
         * 参数：商品Id
         * 返回：本店某一个商品(未测)
         */
        public item[] getItemByItemId(string itemId)
        {

            using (YMDBEntities db = new YMDBEntities())
            {
                item[] newItem = db.item.Where(p => p.itemId == itemId).ToArray();
                return newItem;
            }

            
        }

        /**
         * 31.通过商品名查找商品
         * 参数：商品Name
         * 返回：本店某一个商品
         * 备注：模糊搜索(通过测试)
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
         * 备注：其实可以通过库存方法来获取(通过测试)
         */
        public checkDetail[] getCheckDetailInfoWithStaffId(string currentCheckId, string staffId)
        {
            string shopId = getShopIdByStaffId(staffId);

            using (YMDBEntities db = new YMDBEntities())
            {
                try
                {
                    stock[] itemStock = db.stock.Where(p => p.shopId == shopId).ToArray();
                    checkDetail[] currentCheckDetail = new checkDetail[itemStock.Length];
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
                    return currentCheckDetail;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("检查checkId和staffId是否在checkDetail已经存在，或者两者输入错误.");
                    System.Diagnostics.Debug.WriteLine(ex.StackTrace);
                    checkDetail[] emptyArray = { };
                    return emptyArray;
                }
               
            }
        }

        /**
         * 33.店长更改订单信息
         * 参数：要修改的Order的Id,店长的Id
         * 返回：返回修改过的Order实例(通过测试)
         */
        public orderDetail modifyOrderInfoWithOrderIdByShopManager(string originOrderId, string staffId, string currentItemId, int currentItemAmount)
        {
            orderDetail newOrder = null;

            using(YMDBEntities db = new YMDBEntities())
            {
                order currentOrder = db.order.Where(p => p.orderId == originOrderId).FirstOrDefault();
                newOrder = db.orderDetail.Where(p => p.itemId == currentItemId & p.orderId == originOrderId).FirstOrDefault();
                item currentItem = db.item.Where(p => p.itemId == currentItemId).FirstOrDefault();
                
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
         * 备注：申请表的状态默认同意状态(通过测试)
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
         * 返回：是否成功添加了申请表细节(通过测试，需要先增加apply条目然后再增加applyDetail)
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
                isSucceed = true;
            }

            return isSucceed;
        }

        /**
         * 36.店长申请从其他店面调货
         * 参数：店长的Id，对方店面的Id
         * 返回：新建的调货申请表
         * 备注：申请表的状态需要设置为申请状态(通过测试)
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
         * 返回：是否成功添加了申请表细节(需要优化)
         * 注意：如果申请调货的店没有对应的货会报空指针错误
         */
        public bool addApplyDetailInfoFromOtherShopWithApplyIdItemIdAndItemAmount(string currentApplyId,string currentItemId, int currentItemAmount) 
        {
            bool isSucceed = false;

            using (YMDBEntities db = new YMDBEntities())
            {
                try
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
                        isSucceed = true;
                        return isSucceed;
                    } 
                }
                catch(NullReferenceException ex) 
                {
                    System.Diagnostics.Debug.WriteLine("店长申请增加条目失败，对应的店没有相应货物或是applyId不存在.");
                    System.Diagnostics.Debug.WriteLine(ex.StackTrace);
                    return false;
                }
            }
        }
            

        /**
         * 38.店长对其他店的申请进行审批
         * 参数：店长Id，是否同意bool值
         * 返回：审批是否成功的bool值(需要优化)
         * 注意：如果staffId不是店长会有空指针错误，或者currentApplyId不存在也会有空指针，Debug监视会打印异常
         */
        public bool dealWithApplyFromOtherShop(string currentApplyId, string staffId, bool dealFlag)
        {
            bool isAgree = true;

            string shopId = getShopIdByStaffId(staffId);

            using (YMDBEntities db = new YMDBEntities())
            {
                try
                {
                    apply currentApply = db.apply.Where(p => p.applyId == currentApplyId & p.outShop == shopId).FirstOrDefault();
                    if (dealFlag == true)
                    {
                        currentApply.state = "yes";
                    }
                    else
                    {
                        currentApply.state = "no";//Null point
                        isAgree = false;
                    }
                    db.SaveChanges();
                    return isAgree;
                }
                catch (NullReferenceException ex)
                {
                    System.Diagnostics.Debug.WriteLine("店长审批调货申请失败，空指针异常，未输入正确的参数.");
                    System.Diagnostics.Debug.WriteLine(ex.StackTrace);
                    return false;
                }
            }
        }

        /**
         * 39.Boss增加商品
         * 参数：新增商品的名字、尺寸、颜色、价格
         * 返回：商品实例(测试通过)
         * size不可大于5个字符
         */
        public item addItemByBoss(string currentItemName, string currentItemSize, string currenttemColor, double currentItemPrice)
        {
            string newId = createNewId("item");

            using (YMDBEntities db = new YMDBEntities())
            {
                //decimal newItem = new item().itemPrice;
                item newItem = new item
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

                return newItem;
            }

        }


        /**
         * 40.Boss增加商品的图片信息
         * 参数：需要增加的商品的Id，图片的地址（或者编号）
         * 返回：图片实例(通过测试)
         * currentItemId必须存在
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
         * 返回：商品实例(通过测试)
         */
        public item modifyItemByBoss(string currentItemId, string currentItemName, string currentItemSize, string currentItemColor, double currentItemPrice)
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
         * 返回：是否修改成功(通过测试)
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
         * 返回：新店长的实例(通过测试)
         */
        public staff assignManagerToShop(string shopId, string managerId)
        {
            //写入数据库
            using (YMDBEntities db = new YMDBEntities())
            {
                try
                {
                    staff manager = db.staff.Where(p => p.staffId == managerId).First();
                    manager.staffJob = 1;
                    manager.shopId = shopId;
                    db.SaveChanges();
                    return manager;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                    return null;
                }
            }
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
                    return null;
                }
            }

            return newAddress;
        }

        /**
         * 45.根据员工查看该店调货纪录
         * 参数：staffId
         * 返回值：调货记录数组(通过测试)
         */
        public apply[] checkAllApplyByStaffId(string staffId)
        {
            string shopId = getShopIdByStaffId(staffId);

            using (YMDBEntities db = new YMDBEntities())
            {
                apply[] applys = db.apply.Where(p => p.outShop == shopId | p.inShop == shopId).ToArray();

                return applys;
            }
        }

        /**
         * 46.根据商品Id获取图片路径
         * 参数：商品Id
         * 返回值：图片路径string(通过测试)
         */
        public string getImagePathWithItemId(string itemId)
        {
            using (YMDBEntities db = new YMDBEntities())
            {
                try
                {
                    image currentImage = db.image.Where(p => p.itemId == itemId).FirstOrDefault();
                    return currentImage.imagePath;
                }
                catch (NullReferenceException ex)
                {
                    System.Diagnostics.Debug.WriteLine("未找到image路径，可能是imageId错误.");
                    System.Diagnostics.Debug.WriteLine(ex.StackTrace);
                    return "";
                }
                
            }
        }

        /**
         * 47.根据员工Id查询向此店申请信息数组(通过测试)
         * 参数：员工Id
         * 返回值：申请书组
         */
        public apply[] getAllApllyToThisShop(string staffId)
        {
            string shopId = getShopIdByStaffId(staffId);

            using (YMDBEntities db = new YMDBEntities())
            {
                apply[] allApply = db.apply.Where(p => p.outShop == shopId).ToArray();
                return allApply;
            }
        }

        /**
         * 48.如果盘点后商品数量不一致，进行更改，修改库存(通过测试)
         * 参数：店长Id，货物Id，现有数量
         * 返回值：库存信息
         */
        public stock changeStockByStaffIdAndItemId(string staffId, string itemId, int currentAmount)
        {
            try
            {
                if (currentAmount < 0)
                {
                    return null;
                }
                string shopId = getShopIdByStaffId(staffId);
                using (YMDBEntities db = new YMDBEntities())
                {
                    stock currentItem = db.stock.Where(p => p.itemId == itemId & p.shopId == shopId).FirstOrDefault();
                    currentItem.stockAmount = currentAmount;
                    db.SaveChanges();
                    return currentItem;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("输入有误，总之我不给你修改数据库，自己看着办.");
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
                return null;
            }
            
            
        }

        /**
         * 49.返回所有地点信息(通过测试)
         * 参数：无
         * 返回值：地点信息数组
         */
        public address[] getAllAddressInfo()
        {
            using (YMDBEntities db = new YMDBEntities()){
                address[] allAddress = db.address.Where(p => p.addressId == p.addressId).ToArray();

                return allAddress;
            }
        }

        /**
         * 50.拿到该员工商店所有的入库信息(测试通过)
         * 参数：staffId
         * 返回值：inBase[]
         */
        public inBase[] getAllinBaseInfoByStaffId(string targetStaffId)
        {
            string shopId = getShopIdByStaffId(targetStaffId);

            using (YMDBEntities db = new YMDBEntities())
            {
                inBase[] currentInBase = db.inBase.Where(p => p.shopId == shopId).ToArray();
                return currentInBase;
                System.Diagnostics.Debug.WriteLine(currentInBase.Length);
            }
        }

        /** 
         * 51.拿到该员工商店所有的出库信息(通过测试)
         * 参数：staffId
         * 返回值：outBase[]
         */
        public outBase[] getAllOutBaseInfoByStaffId(string targetStaffId)
        {
            string shopId = getShopIdByStaffId(targetStaffId);

            using (YMDBEntities db = new YMDBEntities())
            {
                outBase[] currentOutBase = db.outBase.Where(p => p.shopId == shopId).ToArray();
                return currentOutBase;
            }
        }
        
        /**
         * 54.根据申请id拿到详细信息表(测试通过)
         * 参数：申请id
         * 返回值：详细信息[]
         */
        public applyDetail[] getAllApplyDetailByApplyId(string targetApplyId)
        {
            using (YMDBEntities db = new YMDBEntities())
            {
                applyDetail[] currentApplyDetail = db.applyDetail.Where(p => p.applyId == targetApplyId).ToArray();
                return currentApplyDetail;
            }
        }

        /**
        * 55.店长通过入库ID查找入库表
        * 参数：入库表id
        * 返回值：入库表实例（测试通过）
        */
        public inBase[] getInBaseInfoByInBaseId(string inBaseId)
        {
            using (YMDBEntities db = new YMDBEntities())
            {
                inBase[] targetOrder = db.inBase.Where(p => p.inId == inBaseId).ToArray();
                return targetOrder;
            }

        }
       /**
       * 56.店长通过出库ID查找出库表
       * 参数：出库表id
       * 返回值：出库表实例（测试通过）
       */
        public outBase[] getOutBaseInfoByOutBaseId(string outBaseId)
        {
            using (YMDBEntities db = new YMDBEntities())
            {
                outBase[] targetOrder = db.outBase.Where(p => p.outId == outBaseId).ToArray();
                return targetOrder;
            }

        }

        /**
         * 57.返回员工所在店铺所有的盘点信息(通过测试)
         * 参数：员工Id
         * 返回值：盘点信息数组
         */
        public check[] getAllCheckInfo(string staffId)
        {
            string shopId = getShopIdByStaffId(staffId);

            using (YMDBEntities db = new YMDBEntities())
            {
                check[] allCheckInfo = db.check.Where(p => p.shopId == shopId).ToArray();
                return allCheckInfo;
            }
        } 

        /**
         * 58.新增盘点记录(测试通过)
         * 参数：员工Id
         * 返回值：盘点记录
         */
        public check addNewCheckRecord(string staffId)
        {
            string shopId = getShopIdByStaffId(staffId);
            string newCheckId = createNewId("check");
            using (YMDBEntities db = new YMDBEntities())
            {
                try
                {
                    check newCheck = new check
                    {
                        checkerId = staffId,
                        shopId = shopId,
                        checkTime = DateTime.Now,
                        checkId = newCheckId,
                    };
                    db.check.Add(newCheck);
                    db.SaveChanges();

                    return newCheck;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("没找到shopId导致完整性约束不满足，拒绝插入数据库，请检查staffId.");
                    System.Diagnostics.Debug.WriteLine(ex.StackTrace);
                    return null;
                }

                
                
            }
        }

        /**
        * 59.店长通过员工号查询入库报表
        * 参数：员工Id
        * 返回值：入库表实例（测试通过）
        */
        public inBase[] getInBaseInfoByStaffId(string staffId)
        {
            string shopId = getShopIdByStaffId(staffId);

            using (YMDBEntities db = new YMDBEntities())
            {
                inBase[] targetOrder = db.inBase.Where(p => p.shopId == shopId).ToArray();
                return targetOrder;
            }

        }
        /**
        * 60.店长通过员工号查询出库报表
        * 参数：员工Id
        * 返回值：出库表实例（测试通过）
        */
        public outBase[] getOutBaseInfoByStaffId(string staffId)
        {
            string shopId = getShopIdByStaffId(staffId);

            using (YMDBEntities db = new YMDBEntities())
            {
                outBase[] targetOrder = db.outBase.Where(p => p.shopId == shopId).ToArray();
                return targetOrder;
            }

        }

        /**
         * 61.增加商店入库记录(测试通过)
         * 参数：员工Id
         * 返回值：入库记录
         */
        public inBase addNewInBaseRecord(string staffId)
        {
            string shopId = getShopIdByStaffId(staffId);
            string newId = createNewId("inBase");
            using (YMDBEntities db = new YMDBEntities())
            {
                try
                {
                    inBase newInBase = new inBase
                    {
                        inId = newId,
                        shopId = shopId,
                        staffId = staffId,
                        inTime = DateTime.Now,
                    };
                    db.inBase.Add(newInBase);
                    db.SaveChanges();
                    return newInBase;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("没找到shopId导致完整性约束不满足，拒绝插入数据库，请检查staffId.");
                    System.Diagnostics.Debug.WriteLine(ex.StackTrace);
                    return null;
                }
            }
        }

        /**
         * 62.增加商店出库记录(测试通过)
         * 参数：员工Id
         * 返回值：出库记录
         */
        public outBase addNewOutBaseRecord(string staffId)
        {
            string shopId = getShopIdByStaffId(staffId);
            string newId = createNewId("outBase");
            using (YMDBEntities db = new YMDBEntities())
            {
                try
                {
                    outBase newOutBase = new outBase
                    {
                        outId = newId,
                        shopId = shopId,
                        staffId = staffId,
                        outTime = DateTime.Now,
                        outType = "export",
                    };
                    db.outBase.Add(newOutBase);
                    db.SaveChanges();
                    return newOutBase;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("没找到shopId导致完整性约束不满足，拒绝插入数据库，请检查staffId.");
                    System.Diagnostics.Debug.WriteLine(ex.StackTrace);
                    return null;
                }
                
            }
        }

        /**
         * 63.增加商店出库记录(测试通过)
         * 参数：无
         * 返回值：shop[]
         */
        public shop[] getAllShop()
        {
            using (YMDBEntities db = new YMDBEntities())
            {
                shop[] allShops = db.shop.Where(p => p.shopId == p.shopId).ToArray();
                return allShops;
            }
        }
        
        /*
        * 64.根据员工Id查询此店发出的申请数组
        * 参数：员工Id
        * 返回值：申请数组
        */
        public apply[] getAllApllyFromThisShop(string staffId)
        {
            string shopId = getShopIdByStaffId(staffId);

            using (YMDBEntities db = new YMDBEntities())
            {
                apply[] allApply = db.apply.Where(p => p.inShop == shopId).ToArray();
                return allApply;
            }
        }
    }
}