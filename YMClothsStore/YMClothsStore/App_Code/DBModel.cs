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
         * 10.添加新的地址以供选择
         * 参数：新地址名称或代号，新地址详细信息（街道等）
         * 返回值：address实例
         */
        public address addAddressInfo(string newAddressName, string newAddressDetail)
        {
            address newAddress = null;

            return newAddress;
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
         * 13.员工查看自己店铺的订单信息
         * 参数：员工id
         * 返回值：order[]
         */
        public order[] getAllOrderInfo(string staffId)
        {
            order[] orders = { };
            System.Diagnostics.Debug.WriteLine("staffId:" + staffId);

            //ArrayList test = new ArrayList();
            //order[] test2 = (order[])test.ToArray();

            //员工只可以查看自己店铺的订单
            using (YMDBEntities db = new YMDBEntities()) 
            {
                ArrayList orderList = new ArrayList();
                //先根据staffId查到员工所属店铺
                string targetShopId = db.staff.Where(p => p.staffId == staffId).FirstOrDefault().shopId;

                foreach (var i in db.order.Where(p => p.shopId == targetShopId))
                {
                    order newTargetOrder = new order
                    {
                        orderId = i.orderId,
                        shopId = i.shopId,
                        totalPrice = i.totalPrice,
                        orderTime = i.orderTime
                    };

                    orderList.Add(newTargetOrder);
                }

                orders = (order[])orderList.ToArray();                
            }

            return orders;
        }

        /**
         * 14.员工查看某个订单的普通信息
         * 参数：订单id
         * 返回值：订单实例(未测)
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
         * 返回值：员工所在商店的某件商品的订单详情数组（未测）
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
         * 返回值：员工所在shop的id（未测）
         */
        public string getShopIdByStaffId(string targetStaffId)
        {
            string targetShopId = "";

            using (YMDBEntities db = new YMDBEntities())
            {
                staff targetStaff = db.staff.Where(p => p.staffId == targetShopId).FirstOrDefault();
                targetShopId = targetStaff.shopId;
            }

            return targetShopId;
        }

        /**
         * 17.员工增加订单记录
         * 参数：staffId, 这次订单的详细信息数组
         * 返回值：本次订单（未测）
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
         * 注意：不要重复添加某一条商品的信息（未测）
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
                db.SaveChanges();
                
            }

            return isSucceed;
        }

        /**
         * 19.员工查看本店库存
         * 参数：员工Id
         * 返回值：员工所在商店的所有库存信息(未测)
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
         * 返回：员工所在商店的某件商品的库存(未测)
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
         * 返回值：系统中的某件商品的所有库存(未测)
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
         * 返回值：原木衣橱总库库存信息数组(未测)
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
         * 返回：一个新添加的入库登记表(未测)
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
         * 返回：是否成功入库(未测)
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
                db.SaveChanges();
            }

            return isSucceed;
        }

        /**
         * 25.员工新建出库登记表
         * 参数：员工Id,出库类型
         * 返回：员工新建一个出库登记表(未测)
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
         * 返回：是否成功出库(未测)
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
                db.SaveChanges();
            }

            return isSucceed;
        }

        /**
         * 27.员工页面显示最近五件最热商品
         * 参数：无（根据当前月查询）
         * 返回：商品数组（数量5）
         */
        public item[] topFiveItems()
        {
            item[] items = { };

            using (YMDBEntities db = new YMDBEntities())
            {

            }

            return items;
        }

        /**
         * 28.员工页面显示这个月每日销售总价（？需要每个月都传么？No）
         * 参数：无
         * 返回：本月每日销售价格的集合
         */
        public float[] getEverySumOfThisMonth()
        {
            float[] floats = { };

            return floats;
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
         * 备注：模糊搜索
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
         * 返回：是否成功添加了申请表细节
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
         * 返回：审批是否成功的bool值
         */
        public bool dealWithApplyFromOtherShop(string staffId, bool dealFlag)
        {
            bool isAgree = true;

            return isAgree;
        }

        /**
         * 39.Boss增加商品
         * 参数：新增商品的名字、尺寸、颜色、价格
         * 返回：商品实例
         */
        public item addItemByBoss(string itemName, string itemSize, string itemColor, float itemPrice)
        {
            item newItem = null;

            return newItem;
        }


        /**
         * 40.Boss增加商品的图片信息
         * 参数：需要增加的商品的Id，图片的地址（或者编号）
         * 返回：图片实例
         */
        public image addImageToItem(string itemId, string imagePath)
        {
            image newImage = null;

            return newImage;
        }

        /**
         * 41.Boss修改商品信息
         * 参数：修改后的商品的名字、尺寸、颜色、价格
         * 返回：商品实例
         */
        public item modifyItemByBoss(string itemName, string itemSize, string itemColor, float itemPrice)
        {
            item newItem = null;

            return newItem;
        }

        /**
         * 42.Boss修改商品状态
         * 参数：商品Id，商品的新状态
         * 返回：是否修改成功
         */
        public bool modifyStatusOfItem(string itemId, int newStatus)
        {
            bool isSucceed = false;

            return isSucceed;
        }

        /**
         * 43.Boss指派店长
         * 参数：商店Id，新店长的Id
         * 返回：新店长的实例
         */
        public staff assignManagerToShop(string shopId, string managerId)
        {
            staff newStaff = null;

            return newStaff;
        }

        /**
         * 44.Boss新增地址信息
         * 参数：地址名称，详细地址
         * 返回：新的地址的实例
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
         * 返回值：调货记录数组
         */
        public apply[] checkAllApplyByStaffId(string staffId)
        {
            apply[] applys = { };

            return applys;
        }
        
    }
}