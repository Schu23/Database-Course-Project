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

####12.public staff[] getStaffWithStaffName(string staffName)[未完成]
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







