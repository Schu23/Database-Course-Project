#接口列表
-----
##DBModel类
####public Staff findStaffInformationById(string id)
* 查找员工信息* 参数：员工id：staffId* 返回值：成功返回员工信息，失败返回null
 
####public string addStaff(string newStaffName)
* 添加新员工
* 参数：新员工名字* 返回值：成功返回员工id，失败返回0

####public bool deleteStaffById(string deletedStaffId)
* 删除员工* 参数：员工id* 返回值：成功返回true，失败或员工不存在返回false  
####public bool modifyPersonalInformation(Staff currentInfo)
* 更改员工信息* 参数：员工id，姓名，电话，密码* 返回值：成功返回true，失败返回false
####public string addNewShop(string newShopManagerId, string newShopAddress, string newShopPhone)* 增加新门店* 参数：店长id，新门店地址，新门店电话* 返回值：门店id，失败返回"false"

####public bool deletdShop(string shopId)
* 删除门店* 参数：门店id* 返回值：bool

####public bool modifyShopInfo(string shopId, string newAddress, string newPhone)
* 修改门店信息* 参数：门店id，新地址，新电话，不修改的值为null* 返回值：bool