#数据库连接方式
1. 安装ODT.exe(问安老板要)
2. Visual Studio 2013 -> 工具 -> 连接到数据库
3. 用户名：yuanmu
4. 口令：wzywman(王泽宇我们爱你)
5. 不要以SYSDBA角色进行连接
5. 连接类型：EZ
6. 数据库主机名：WzyYooooooo
7. 端口号：1521
8. 数据库服务名：yuanmu

------
#接口列表
####public string createNewId(string tableName)
* 创建对应表的主键
* 参数：表名称
* 返回值：主键

##DBModel类
####1.public staff[] findStaffsByShopId(string shopId)
* 查找店铺员工信息
* 参数：店铺id：shopId
* 返回值：成功返回该店铺所有员工数组，失败返回空数组
 
####2.public staff addNewStaff(string newStaffName, string newStaffPassword, string newShopId, int newStaffJob, string newGender)
* 添加新员工
* 参数：新员工名字
* 返回值：成功返回员工实例，失败返回null

####3.public bool deleteStaffByStaffId(string deletedStaffId)
* 删除员工
* 参数：员工id
* 返回值：成功返回true，失败或员工不存在返回false
  
####4.public staff modifyPersonalInformation(string staffId , string staffPhone , string newPassword)
* 更改员工信息
* 参数：员工id，姓名(存疑)，电话，密码
* 返回值：成功返回staff实例以便立刻放入session，失败返回null
* 原来的参数是(staff currentInfo)，与上文不符，且姓名不应该允许自行修改

####5.public shop addNewShopWithManagerIdAndAddressIdAndShopPhone(string newShopManagerId, string newShopAddress, string newShopPhone)
* 增加新门店
* 参数：店长ID，新门店地址ID，新门店电话
* 返回值：门店实例，失败返回null
* 接口和实现方式已经过讨论更改

####6.public shop deletdShopByShopId(string shopId)
* 删除门店，实际上是把shopStatus置为0
* 参数：门店id
* 返回值：shop实例

####7.public bool modifyShopInfo(string shopId, string newAddress, string newPhone)
* 修改门店信息
* 参数：门店id，新地址，新电话，不修改的值为null
* 返回值：bool

####8.public staff findStaffByStaffId(string id)
* 根据ID查找员工
* 参数：员工id
* 返回值：staff实例

####9.public staff loginWithStaffLoginNameAndPassword(string userName, string password)
* 9.员工登陆接口
* 参数：userName，password
* 返回值：bool

####10.public address addAddressInfo(string newAddressName , srting newAddressDetail)[未完成]
* 添加新的地址以供选择
* 参数：新地址名称或代号，新地址详细信息（街道等）
* 返回值：address实例

####11.public shop findShopByShopId(string shopId)
* 根据shopId获取shop，返回shop实例或空
* 参数：店铺的ID
* 返回：获取到的shop

####12.public staff[] getStaffWithStaffName(string staffName)[未测试]
* 使用模糊查询,通过员工姓名查找员工
* 参数：员工名字的全部或一部分
* 符合条件的员工数组

####13.public order[] getAllOrderInfo(string staffId)[未完成]
* 员工查看订单信息
* 参数：员工Id
* 返回：所有的订单的数组

####14.public order getOrderInfoByOrderId(string orderId)[未完成]
* 员工查看某个订单普通信息
* 参数：订单Id
* 返回：订单实例

####15.public orderDetail[] getOrderDetailInfoByOrderId(string orderId)[未完成]
* 查看订单的详细信息
* 参数：订单Id
* 返回：员工所在商店的某件商品的详情数组

####16.public string getShopIdByStaffId(string staffId)[未完成]
* 通过员工Id获取所在Shop的Id(供其他方法调用)
* 参数：员工Id
* 返回：员工所在商店的Id

####17.public order addOrderInfo(string staffId)[未完成]
* 员工增加订单记录
* 参数：员工staffId,
* 返回：本次订单

####18.public bool addOrderDetailToOrderWithOrderIdAndItemIdAndItemAmount(string orderId, string itemId , int itemAmount)[未完成]
* 员工在订单中添加一条订单详细信息
* 参数：订单Id,货物Id,货物数量
* 返回：成功或者失败：成功返回true,失败返回false
* 注意：不要重复添加某一条商品的信息

####19.public stock getShopStockInfoByStaffId(string staffId)[未完成]
* 员工查看本店库存
* 参数：员工Id
* 返回：员工所在商店的所有库存信息

####20.public stock getItemStockInThisShop(string staffId,string itemId)[未完成]
* 员工查看某商品在本店的库存
* 参数：员工Id,商品Id
* 返回：员工所在商店的某件商品的库存

####21.public stock getItemStockInSystem(string itemId)[未完成]
* 员工查看某商品在系统的库存
* 参数：货物Id
* 返回：系统中的某件商品的库存

####22.public stock[] getSystemStockInfo()[未完成]
* 员工查看总库库存
* 参数：无
* 返回：原木衣橱所有的库存信息

####23.public inBase addNewIn(string staffId)[未完成]
* 员工新建入库登记表
* 参数：员工Id
* 返回：一个新添加的入库登记表

####24.public bool addInDetailToInWithItemIdAndItemAmount(string itemId, int itemAmount)[未完成]
* 员工为新建的入库登记表填写详细信息
* 参数：商品Id,商品数量Amount
* 返回：是否成功入库

####25.public outBase addNewOut(string staffId,string outType)[未完成]
* 员工新建出库登记表
* 参数：员工Id,出库类型
* 返回：员工新建一个出库登记表

####26.public bool addOutDetailToOutWithItemIdAndItemAmount(string itemId, int itemAmount)[未完成]
* 员工为新建的出库登记表添加详细信息
* 参数：货物Id，货物数量
* 返回：是否成功出库

####27.public item[] topFiveItems()[未完成]
* 员工页面显示最近五件最热商品
* 参数：无（根据当前月查询）
* 返回：商品数组（数量5）

####28.public float[] getEverySumOfThisMonth()[未完成]
* 员工页面显示这个月每日销售总价（？需要每个月都传么？No）
* 参数：无
* 返回：本月每日销售价格的集合

####29.public item[] getAllItemsOfThisShop(string staffId)[未完成]
* 员工查询商品信息
* 参数：员工Id
* 返回：本店所有商品信息的集合

####30.public item getItemByItemId(string itemId)[未完成]
* 通过商品Id查询商品详细信息(查完库存调用此接口显示某商品详细信息)
* 参数：商品Id
* 返回：本店某一个商品

####31.public item getItemByItemName(string itemName)[未完成]
* 通过商品名查找商品
* 参数：商品Name
* 返回：本店某一个商品
* 备注：模糊搜索

####32.public checkDetail[] getCheckDetailInfoWithStaffId(string staffId)[未完成]
* 店长进行盘点(最终目的是检查是否有人偷东西)
* 参数：员工Id
* 返回：最近现在各个商品集合（包括名称和）
* 备注：其实可以通过库存方法来获取

####33.public order modifyOrderInfoWithOrderIdByShopManager(string originOrderId, string staffId)[未完成]
* 店长更改订单信息
* 参数：要修改的Order的Id,店长的Id
* 返回：返回修改过的Order实例

####34.public apply addApplyFromSystem(string staffId)[未完成]
* 店长申请从总库补货
* 参数：店长的Id
* 返回：新建的补货申请表
* 备注：申请表的状态默认同意状态

####35.public bool addApplyDetailInfoFromSystemWithApplyIdItemIdAndItemAmount(string applyId，string itemId, int itemAmount)[未完成]
* 店长为申请添加条目(补货)
* 参数：申请表Id，货物Id和货物数量
* 返回：是否成功添加了申请表细节

####36.public apply addApplyFromOtherShop(string staffId,string otherShopId)[未完成]
* 店长申请从其他店面调货
* 参数：店长的Id，对方店面的Id
* 返回：新建的调货申请表
* 备注：申请表的状态需要设置为申请状态

####37.public bool addApplyDetailInfoFromOtherShopWithApplyIdItemIdAndItemAmount(string applyId，string itemId, int itemAmount)[未完成]
* 店长为申请添加条目(调货)
* 参数：申请表Id，货物Id和货物数量
* 返回：是否成功添加了申请表细节

####38.public bool dealWithApplyFromOtherShop(string staffId,bool dealFlag)[未完成]
* 店长对其他店的申请进行审批
* 参数：店长Id，是否同意bool值
* 返回：审批是否成功的bool值

####39.public item addItemByBoss(string itemName, string itemSize, string itemColor, float itemPrice)[未完成]
* Boss增加商品
* 参数：新增商品的名字、尺寸、颜色、价格
* 返回：商品实例

####40.public image addImageToItem(string itemId, string imagePath)[未完成]
* Boss增加商品的图片信息
* 参数：需要增加的商品的Id，图片的地址（或者编号）
* 返回：图片实例

####41.public item modifyItemByBoss(string itemName, string itemSize, string itemColor, float itemPrice)[未完成]
* Boss修改商品信息
* 参数：修改后的商品的名字、尺寸、颜色、价格
* 返回：商品实例

####42.public bool modifyStatusOfItem(string itemId, int newStatus)[未完成]
* Boss修改商品状态
* 参数：商品Id，商品的新状态
* 返回：是否修改成功

####43.public staff assignManagerToShop(string shopId, string managerId)[未完成]
* Boss指派店长
* 参数：商店Id，新店长的Id
* 返回：新店长的实例

####44.public address addNewAddress(string addressName, string addressDetail)[未完成]
* Boss新增地址信息
* 参数：地址名称，详细地址
* 返回：新的地址的实例

####45.public apply[] checkAllApplyByStaffId(string staffId)[未完成]
* 查看调货纪录
* 参数：staffId
* 返回值：调货记录数组








