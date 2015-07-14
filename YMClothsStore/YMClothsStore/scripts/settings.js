
// 手机号修改－验证手机号是否输入正确
function phoneInput(event){
	var isMobile=/^(?:13\d|15\d|18\d)\d{5}(\d{3}|\*{3})$/; //手机号码验证规则
    if (!isMobile.test(event.target.value)) {
    	$("#newphone-check").replaceWith('<label class="check-wrong" id="newphone-check"><span class="glyphicon glyphicon-remove" aria-hidden="true"></span></label>');
    	return false;
    }else{
    	$("#newphone-check").replaceWith('<label class="check-ok" id="newphone-check"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span></label>');
    	return true;
    };
}

// 手机号修改－验证重复输入是否正确
function conphoneInput(event){
	var mobile = $("#id-newphone").val(); //获取第一次输入的手机号
    if (mobile != event.target.value) {
    	$("#conphone-check").replaceWith('<label class="check-wrong" id="conphone-check"><span class="glyphicon glyphicon-remove" aria-hidden="true"></span></label>');
    	return false;
    }else{
    	$("#conphone-check").replaceWith('<label class="check-ok" id="conphone-check"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span></label>');
    	return true;
    };
}

// 验证新密码
function pwdChange(v) {
    var num = 0;
    var reg = /\d/; //如果有数字
    if (reg.test(v)) {
        num++;
    }
    reg = /[a-zA-Z]/; //如果有字母
    if (reg.test(v)) {
        num++;
    }
    reg = /[^0-9a-zA-Z]/; //如果有特殊字符
    if (reg.test(v)) {
        num++;
    }
    if (v.length < 6) { //如果密码小于6
        num--;
    }
    return num;
}

function isPassword(event)   
{   
    var pwd = event.target.value;
    var num = pwdChange(pwd);
    if (pwd.length<6) {
        $("#newpwd-check").replaceWith('<label class="pwd-too-short" id="newpwd-check">密码需超过6字符</label>');
        return false;
    }else{
        if(num==0||num==1){
            $("#newpwd-check").replaceWith('<label class="pwd-weak" id="newpwd-check">弱</label>');
        }else if(num==2){
            $("#newpwd-check").replaceWith('<label class="pwd-middle" id="newpwd-check">中</label>');
        }else{
            $("#newpwd-check").replaceWith('<label class="pwd-strong" id="newpwd-check">强</label>');
        }
        return true;
    }
}

// 重复输入新密码验证
function confirmPassword(event)
{
    var newpwd = $("#id-newpwd").val(); //获取第一次输入的手机号
    var conpwd = event.target.value;
    if (conpwd != newpwd) {
        $("#conpwd-check").replaceWith('<label class="check-wrong" id="conpwd-check"><span class="glyphicon glyphicon-remove" aria-hidden="true"></span></label>');
        return false;
        // return false;
    }else{
        $("#conpwd-check").replaceWith('<label class="check-ok" id="conpwd-check"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span></label>');
        return true;
    }
}