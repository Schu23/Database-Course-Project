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
##DBModel类
####1.public ArrayList findStaffInformationById(string shopId)
* 查找店铺员工信息
* 参数：店铺id：shopId
* 返回值：成功返回该店铺所有员工信息ArrayList，失败返回null
 
####2.public string addStaff(string newStaffName)
* 添加新员工
* 参数：新员工名字
* 返回值：成功返回员工id，失败返回0

####3.public bool deleteStaffById(string deletedStaffId)
* 删除员工
* 参数：员工id
* 返回值：成功返回true，失败或员工不存在返回false
  
####4.public bool modifyPersonalInformation(Staff currentInfo)
* 更改员工信息
* 参数：员工id，姓名，电话，密码
* 返回值：成功返回true，失败返回false


####5.public string addNewShop(string newShopManagerId, string newShopAddress, string newShopPhone)
* 增加新门店
* 参数：店长id，新门店地址，新门店电话
* 返回值：门店id，失败返回"false"

####6.public bool deletdShop(string shopId)
* 删除门店
* 参数：门店id
* 返回值：bool

####7.public bool modifyShopInfo(string shopId, string newAddress, string newPhone)
* 修改门店信息
* 参数：门店id，新地址，新电话，不修改的值为null
* 返回值：bool

####8.public staff findStaffById(string id)
* 根据ID查找员工* 参数：员工id* 返回值：员工类staff

