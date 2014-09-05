<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="left.aspx.cs" Inherits="Stoke.USL.MainForm.left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        <!--
        html{
            height:100%;
        }
        body {
	        margin-left: 0px;
	        margin-top: 0px;
	        margin-right: 0px;
	        margin-bottom: 0px;
	        height:100%;
        }
        
        .divout{
            background:url("");
            font-weight:normal;
            width:70px; 
            height:63px;
            float:left;
            margin-left:8px;
            margin-top:12px;
            margin-right:8px;
            text-align:center;
            padding-top:7px;
            font-family:微软雅黑;
            font-size:14px;
            color:#246190;
            cursor:pointer;
        }
        
        .divover{
            background:url("../../images/left11.jpg");
            font-weight:bold;
            width:70px; 
            height:63px;
            float:left;
            margin-left:8px;
            margin-top:12px;
            margin-right:8px;
            text-align:center;
            padding-top:7px;
            font-family:微软雅黑;
            font-size:14px;
            color:#246190;
            cursor:pointer;
        }
        
        .menucss
        {
            font-family:楷体; 
            color:#476074; 
            font-size:16px;
            background:url('../../images/left05.jpg');
        }
        
        .menucss1
        {
            font-family:楷体; 
            color:#476074; 
            font-size:16px;
            font-weight:bold;
            background:url('../../images/left07.jpg');
        }
        -->
    </style>
    <link rel="Stylesheet" href="../../js/lib/ext/resources/css/ext-all.css" />
    
    <script type="text/javascript" src="../../js/lib/ext/ext-base.js"></script>

    <script type="text/javascript" src="../../js/lib/ext/ext-all.js"></script>

    <script type="text/javascript" src="../../js/lib/ext/locale/ext-lang-zh_CN.js"></script>
    
    <script language="javascript">
        var flag = 0;
        function showsubmenu(sid)
        {    
            //下边是对一个div的打开和关闭
            whichEl = eval("submenu" + sid);
            imgmenu = eval("imgmenu" + sid);
            if (whichEl.style.display == "none")
            {
                eval("submenu" + sid + ".style.display=\"\";");
                imgmenu.className="menucss1";
                imgmenu.onmouseout = "";
                imgmenu.onmouseover= "";
                flag = sid;
            }
            else
            {
                eval("submenu" + sid + ".style.display=\"none\";");
                imgmenu.className="menucss";
                imgmenu.onmouseout=function (){
                   this.className='menucss';
                }
                imgmenu.onmouseover=function (){
                   this.className='menucss1';
                }
                flag = 0;
            }
            
            //下边是判断所有的div  只有一个显示其它关闭
            if(flag==sid){  //如果是打开当前这个，其它需要关闭，如果是关闭当前这个，其它不用管
                for(var i=0;i<100;i++){
                    if(i!=sid){
                        if(document.getElementById("submenu"+i)){
                            imgmenu = eval("imgmenu" + i);
                            eval("submenu" + i + ".style.display=\"none\";");
                            imgmenu.className="menucss";
                            imgmenu.onmouseout=function (){
                               this.className='menucss';
                            }
                            imgmenu.onmouseover=function (){
                               this.className='menucss1';
                            }
                        }
                    }
                }
            }
        }
    </script>
    
    <script language="javascript">
        Ext.onReady(function(){
            <%if (Session["permrange"] != null && Session["permrange"].ToString().IndexOf("020100") >= 0)
                                      { %>
            Ext.get('xjgzBtn').on({
                click: function() {
                    var tabs = window.parent.frames['maintabs'].Ext.getCmp('tonzocTab');
                    var objxjgz = window.parent.frames['maintabs'].Ext.getCmp('tabxjgz');
                    if(objxjgz) {
                        tabs.setActiveTab('tabxjgz');
                        window.parent.frames['maintabs'].frames["iframe1"].location.replace("../Workflow/ListFlow.aspx");
                    }
                    else {
                        tabs.add({id:'tabxjgz', title:'新建工作',html:'<iframe id="iframe1" src="../Workflow/ListFlow.aspx" width="100%" height="100%" frameBorder="0"></iframe>'});
                        tabs.setActiveTab('tabxjgz');
                    }
                }
            });
            
            <%} if (Session["permrange"] != null && Session["permrange"].ToString().IndexOf("020200") >= 0)
                                      { %>
            
            Ext.get('dbsxBtn').on({
                click: function() {
                    var tabs = window.parent.frames['maintabs'].Ext.getCmp('tonzocTab');
                    var objdbsx = window.parent.frames['maintabs'].Ext.getCmp('tabdbsx');
                    if(objdbsx) {
                        tabs.setActiveTab('tabdbsx');
                        window.parent.frames['maintabs'].frames["iframe2"].location.replace("../Workflow/Work_Manage.aspx");
                    }
                    else {
                        tabs.add({id:'tabdbsx', title:'待办事项',html:'<iframe id="iframe2" src="../Workflow/Work_Manage.aspx" width="100%" height="100%" frameBorder="0"></iframe>'});
                        tabs.setActiveTab('tabdbsx');
                    }
                }
            });
            
            <%} if (Session["permrange"] != null && Session["permrange"].ToString().IndexOf("020300") >= 0)
                                      { %>
            
            Ext.get('gzckBtn').on({
                click: function() {
                    var tabs = window.parent.frames['maintabs'].Ext.getCmp('tonzocTab');
                    var objgzck = window.parent.frames['maintabs'].Ext.getCmp('tabgzck');
                    if(objgzck) {
                        tabs.setActiveTab('tabgzck');
                        window.parent.frames['maintabs'].frames["iframe3"].location.replace("../Workflow/Work_Record.aspx");
                    }
                    else {
                        tabs.add({id:'tabgzck', title:'工作查看',html:'<iframe id="iframe3" src="../Workflow/Work_Record.aspx" width="100%" height="100%" frameBorder="0"></iframe>'});
                        tabs.setActiveTab('tabgzck');
                    }
                }
            });
            
            <%} if (Session["permrange"] != null && Session["permrange"].ToString().IndexOf("010100") >= 0)
                                      { %>
            
            Ext.get('userBtn').on({
                click: function() {
                    var tabs = window.parent.frames['maintabs'].Ext.getCmp('tonzocTab');
                    var obj = window.parent.frames['maintabs'].Ext.getCmp('tab1');
                    if(obj) {
                        tabs.setActiveTab('tab1');
                        window.parent.frames['maintabs'].frames["iframe4"].location.replace("../SysManager/SystemUser.aspx");
                    }
                    else {
                        tabs.add({id:'tab1', title:'用户管理',html:'<iframe id="iframe4" src="../SysManager/SystemUser.aspx" width="100%" height="100%" frameBorder="0"></iframe>'});
                        tabs.setActiveTab('tab1');
                    }
                }
            });
            
            <%} if (Session["permrange"] != null && Session["permrange"].ToString().IndexOf("010200") >= 0)
                                      { %>
            Ext.get('roleBtn').on({
                click: function() {
                    var tabs = window.parent.frames['maintabs'].Ext.getCmp('tonzocTab');
                    var obj2 = window.parent.frames['maintabs'].Ext.getCmp('tab2');
                    if(obj2) {
                        tabs.setActiveTab('tab2');
                        window.parent.frames['maintabs'].frames["iframe5"].location.replace("../SysManager/SystemRole.aspx");
                    }
                    else {
                        tabs.add({id:'tab2', title:'角色管理',html:'<iframe id="iframe5" src="../SysManager/SystemRole.aspx" width="100%" height="100%" frameBorder="0"></iframe>'});
                        tabs.setActiveTab('tab2');
                    }
                }
            });
            
            <%} if (Session["permrange"] != null && Session["permrange"].ToString().IndexOf("010300") >= 0)
                                      { %>
                                      
            Ext.get('rightBtn').on({
                click: function() {
                    var tabs = window.parent.frames['maintabs'].Ext.getCmp('tonzocTab');
                    var obj3 = window.parent.frames['maintabs'].Ext.getCmp('tab3');
                    if(obj3) {
                        tabs.setActiveTab('tab3');
                        window.parent.frames['maintabs'].frames["iframe6"].location.replace("../SysManager/SystemModule.aspx");
                    }
                    else {
                        tabs.add({id:'tab3', title:'权限管理',html:'<iframe id="iframe6" src="../SysManager/SystemModule.aspx" width="100%" height="100%" frameBorder="0"></iframe>'});
                        tabs.setActiveTab('tab3');
                    }
                }
            });
            <%} if (Session["permrange"] != null && Session["permrange"].ToString().IndexOf("030100") >= 0)
                                      { %>
            
            Ext.get('msgBtn').on({
                click: function() {
                    var tabs = window.parent.frames['maintabs'].Ext.getCmp('tonzocTab');
                    var objmsg = window.parent.frames['maintabs'].Ext.getCmp('tabmsg');
                    if(objmsg) {
                        tabs.setActiveTab('tabmsg');
                        window.parent.frames['maintabs'].frames["iframe7"].location.replace("../Message/MsgSend.aspx");
                    }
                    else {
                        tabs.add({id:'tabmsg', title:'发送消息',html:'<iframe id="iframe7" src="../Message/MsgSend.aspx" width="100%" height="100%" frameBorder="0"></iframe>'});
                        tabs.setActiveTab('tabmsg');
                    }
                }
            });
            
            <%} if (Session["permrange"] != null && Session["permrange"].ToString().IndexOf("030200") >= 0)
                                      { %>
            
            Ext.get('sendmsgBtn').on({
                click: function() {
                    var tabs = window.parent.frames['maintabs'].Ext.getCmp('tonzocTab');
                    var objsendmsg = window.parent.frames['maintabs'].Ext.getCmp('tabsendmsg');
                    if(objsendmsg) {
                        tabs.setActiveTab('tabsendmsg');
                        window.parent.frames['maintabs'].frames["iframe8"].location.replace("../Message/MsgSendList.aspx");
                    }
                    else {
                        tabs.add({id:'tabsendmsg', title:'发送消息列表',html:'<iframe id="iframe8" src="../Message/MsgSendList.aspx" width="100%" height="100%" frameBorder="0"></iframe>'});
                        tabs.setActiveTab('tabsendmsg');
                    }
                }
            });
            
            <%} if (Session["permrange"] != null && Session["permrange"].ToString().IndexOf("030300") >= 0)
                                      { %>
            Ext.get('receivemsgBtn').on({
                click: function() {
                    var tabs = window.parent.frames['maintabs'].Ext.getCmp('tonzocTab');
                    var objrecmsg = window.parent.frames['maintabs'].Ext.getCmp('tabrecmsg');
                    if(objrecmsg) {
                        tabs.setActiveTab('tabrecmsg');
                        window.parent.frames['maintabs'].frames["iframe9"].location.replace("../Message/MsgReceiveList.aspx");
                    }
                    else {
                        tabs.add({id:'tabrecmsg', title:'接收消息列表',html:'<iframe id="iframe9" src="../Message/MsgReceiveList.aspx" width="100%" height="100%" frameBorder="0"></iframe>'});
                        tabs.setActiveTab('tabrecmsg');
                    }
                }
            });
            
            <%} if (Session["permrange"] != null && Session["permrange"].ToString().IndexOf("040100") >= 0)
                                      { %>
            //人力资源相关设置
            Ext.get('zgjbxxglBtn').on({
                click: function() {
                    var tabs = window.parent.frames['maintabs'].Ext.getCmp('tonzocTab');
                    var objzgjbxx = window.parent.frames['maintabs'].Ext.getCmp('tabzgjbxx');
                    if(objzgjbxx) {
                        tabs.setActiveTab('tabzgjbxx');
                        window.parent.frames['maintabs'].frames["iframe10"].location.replace("../Staff/ManageStaff.aspx");
                    }
                    else {
                        tabs.add({id:'tabzgjbxx', title:'职工信息管理',html:'<iframe id="iframe10" src="../Staff/ManageStaff.aspx" width="100%" height="100%" frameBorder="0"></iframe>'});
                        tabs.setActiveTab('tabzgjbxx');
                    }
                }
            });
            
            <%} if (Session["permrange"] != null && Session["permrange"].ToString().IndexOf("040200") >= 0)
                                      { %>
            
            Ext.get('bmxxglBtn').on({
                click: function() {
                    var tabs = window.parent.frames['maintabs'].Ext.getCmp('tonzocTab');
                    var objbmxxgl = window.parent.frames['maintabs'].Ext.getCmp('tabbmxxgl');
                    if(objbmxxgl) {
                        tabs.setActiveTab('tabbmxxgl');
                        window.parent.frames['maintabs'].frames["iframe11"].location.replace("../Staff/department_list.aspx");
                    }
                    else {
                        tabs.add({id:'tabbmxxgl', title:'部门人员管理',html:'<iframe id="iframe11" src="../Staff/department_list.aspx" width="100%" height="100%" frameBorder="0"></iframe>'});
                        tabs.setActiveTab('tabbmxxgl');
                    }
                }
            });
            
            <%} if (Session["permrange"] != null && Session["permrange"].ToString().IndexOf("040300") >= 0)
                                      { %>
            
            Ext.get('bmglBtn').on({
                click: function() {
                    var tabs = window.parent.frames['maintabs'].Ext.getCmp('tonzocTab');
                    var objbmgl = window.parent.frames['maintabs'].Ext.getCmp('tabbmgl');
                    if(objbmgl) {
                        tabs.setActiveTab('tabbmgl');
                        window.parent.frames['maintabs'].frames["iframe12"].location.replace("../Staff/bm_list.aspx");
                    }
                    else {
                        tabs.add({id:'tabbmgl', title:'部门管理',html:'<iframe id="iframe12" src="../Staff/bm_list.aspx" width="100%" height="100%" frameBorder="0"></iframe>'});
                        tabs.setActiveTab('tabbmgl');
                    }
                }
            });
            
            <%} if (Session["permrange"] != null && Session["permrange"].ToString().IndexOf("040400") >= 0)
                                      { %>
            
            Ext.get('zwxxglBtn').on({
                click: function() {
                    var tabs = window.parent.frames['maintabs'].Ext.getCmp('tonzocTab');
                    var objzwxxgl = window.parent.frames['maintabs'].Ext.getCmp('tabzwxxgl');
                    if(objzwxxgl) {
                        tabs.setActiveTab('tabzwxxgl');
                        window.parent.frames['maintabs'].frames["iframe13"].location.replace("../Staff/position_manage.aspx");
                    }
                    else {
                        tabs.add({id:'tabzwxxgl', title:'职位信息管理',html:'<iframe id="iframe13" src="../Staff/position_manage.aspx" width="100%" height="100%" frameBorder="0"></iframe>'});
                        tabs.setActiveTab('tabzwxxgl');
                    }
                }
            });
            
            <%} if (Session["permrange"] != null && Session["permrange"].ToString().IndexOf("040500") >= 0)
                                      { %>
            
            Ext.get('jxkhhztjBtn').on({
                click: function() {
                    var tabs = window.parent.frames['maintabs'].Ext.getCmp('tonzocTab');
                    var objjxkh = window.parent.frames['maintabs'].Ext.getCmp('tabjxkhhztj');
                    if(objjxkh) {
                        tabs.setActiveTab('tabjxkhhztj');
                        window.parent.frames['maintabs'].frames["iframe14"].location.replace("../Staff/jxkh_hz.aspx");
                    }
                    else {
                        tabs.add({id:'tabjxkhhztj', title:'绩效汇总',html:'<iframe id="iframe14" src="../Staff/jxkh_hz.aspx" width="100%" height="100%" frameBorder="0"></iframe>'});
                        tabs.setActiveTab('tabjxkhhztj');
                    }
                }
            });
            
            <%} if (Session["permrange"] != null && Session["permrange"].ToString().IndexOf("050100") >= 0)
                                      { %>
            
            //工作流管理设置
            Ext.get('drqxszBtn').on({
                click: function() {
                    var tabs = window.parent.frames['maintabs'].Ext.getCmp('tonzocTab');
                    var objdrqxsz = window.parent.frames['maintabs'].Ext.getCmp('tabdrqxsz');
                    if(objdrqxsz) {
                        tabs.setActiveTab('tabdrqxsz');
                        window.parent.frames['maintabs'].frames["iframe15"].location.replace("../Workflow/Work_right.aspx");
                    }
                    else {
                        tabs.add({id:'tabdrqxsz', title:'单人权限设置',html:'<iframe id="iframe15" src="../Workflow/Work_right.aspx" width="100%" height="100%" frameBorder="0"></iframe>'});
                        tabs.setActiveTab('tabdrqxsz');
                    }
                }
            });
            
            <%} if (Session["permrange"] != null && Session["permrange"].ToString().IndexOf("050200") >= 0)
                                      { %>
            
            Ext.get('duorqxszBtn').on({
                click: function() {
                    var tabs = window.parent.frames['maintabs'].Ext.getCmp('tonzocTab');
                    var objduorqxsz = window.parent.frames['maintabs'].Ext.getCmp('tabduorqxsz');
                    if(objduorqxsz) {
                        tabs.setActiveTab('tabduorqxsz');
                        window.parent.frames['maintabs'].frames["iframe16"].location.replace("../Workflow/Work_rights.aspx");
                    }
                    else {
                        tabs.add({id:'tabduorqxsz', title:'多人权限设置',html:'<iframe id="iframe16" src="../Workflow/Work_rights.aspx" width="100%" height="100%" frameBorder="0"></iframe>'});
                        tabs.setActiveTab('tabduorqxsz');
                    }
                }
            });
            
            
            <%} if (Session["permrange"] != null && Session["permrange"].ToString().IndexOf("050300") >= 0)
                                      { %>
            Ext.get('gzlryszBtn').on({
                click: function() {
                    var tabs = window.parent.frames['maintabs'].Ext.getCmp('tonzocTab');
                    var objgzrysz = window.parent.frames['maintabs'].Ext.getCmp('tabgzrysz');
                    if(objgzrysz) {
                        tabs.setActiveTab('tabgzrysz');
                        window.parent.frames['maintabs'].frames["iframe17"].location.replace("../Workflow/Work_RoleSet.aspx");
                    }
                    else {
                        tabs.add({id:'tabgzrysz', title:'工作流人员设置',html:'<iframe id="iframe17" src="../Workflow/Work_RoleSet.aspx" width="100%" height="100%" frameBorder="0"></iframe>'});
                        tabs.setActiveTab('tabgzrysz');
                    }
                }
            });

                <%} if (Session["permrange"] != null && Session["permrange"].ToString().IndexOf("060100") >= 0)
                                      { %>
             
            Ext.get('mbxzBtn').on({
                click: function() {
                    var tabs = window.parent.frames['maintabs'].Ext.getCmp('tonzocTab');
                    var objmbxz = window.parent.frames['maintabs'].Ext.getCmp('tabmbxz');
                    if(objmbxz) {
                        tabs.setActiveTab('tabmbxz');
                        window.parent.frames['maintabs'].frames["iframe18"].location.replace("../Disclosure/DocLoad.aspx");
                    }
                    else {
                        tabs.add({id:'tabmbxz', title:'模板下载',html:'<iframe id="iframe18" src="../Disclosure/DocLoad.aspx" width="100%" height="100%" frameBorder="0"></iframe>'});
                        tabs.setActiveTab('tabmbxz');
                    }
                }
            });
            
            <%} if (Session["permrange"] != null && Session["permrange"].ToString().IndexOf("060200") >= 0)
                                      { %>
              
            Ext.get('jrzsBtn').on({
                click: function() {
                    var tabs = window.parent.frames['maintabs'].Ext.getCmp('tonzocTab');
                    var objjrzs = window.parent.frames['maintabs'].Ext.getCmp('tabjrzs');
                    if(objjrzs) {
                        tabs.setActiveTab('tabjrzs');
                        window.parent.frames['maintabs'].frames["iframe19"].location.replace("../Disclosure/Finance.aspx");
                    }
                    else {
                        tabs.add({id:'tabjrzs', title:'金融知识',html:'<iframe id="iframe19" src="../Disclosure/Finance.aspx" width="100%" height="100%" frameBorder="0"></iframe>'});
                        tabs.setActiveTab('tabjrzs');
                    }
                }
            });
            
            <%} if (Session["permrange"] != null && Session["permrange"].ToString().IndexOf("060300") >= 0)
                                      { %>
              
            Ext.get('gglbBtn').on({
                click: function() {
                    var tabs = window.parent.frames['maintabs'].Ext.getCmp('tonzocTab');
                    var objgglb = window.parent.frames['maintabs'].Ext.getCmp('tabgglb');
                    if(objgglb) {
                        tabs.setActiveTab('tabgglb');
                        window.parent.frames['maintabs'].frames["iframe20"].location.replace("../Disclosure/ReportList.aspx");
                    }
                    else {
                        tabs.add({id:'tabgglb', title:'公告列表',html:'<iframe id="iframe20" src="../Disclosure/ReportList.aspx" width="100%" height="100%" frameBorder="0"></iframe>'});
                        tabs.setActiveTab('tabgglb');
                    }
                }
            });
            
            <%} if (Session["permrange"] != null && Session["permrange"].ToString().IndexOf("060400") >= 0)
                                      { %>
            
            Ext.get('xjggBtn').on({
                click: function() {
                    var tabs = window.parent.frames['maintabs'].Ext.getCmp('tonzocTab');
                    var objxjgg = window.parent.frames['maintabs'].Ext.getCmp('tabxjgg');
                    if(objxjgg) {
                        tabs.setActiveTab('tabxjgg');
                        window.parent.frames['maintabs'].frames["iframe21"].location.replace("../Disclosure/NewReport.aspx");
                    }
                    else {
                        tabs.add({id:'tabxjgg', title:'新建公告',html:'<iframe id="iframe21" src="../Disclosure/NewReport.aspx" width="100%" height="100%" frameBorder="0"></iframe>'});
                        tabs.setActiveTab('tabxjgg');
                    }
                }
            });
            
            <%} if (Session["permrange"] != null && Session["permrange"].ToString().IndexOf("010400") >= 0)
                                      { %>
            
            Ext.get('annualBtn').on({
                click: function() {
                    var tabs = window.parent.frames['maintabs'].Ext.getCmp('tonzocTab');
                    var objannual = window.parent.frames['maintabs'].Ext.getCmp('tabannual');
                    if(objannual) {
                        tabs.setActiveTab('tabannual');
                        window.parent.frames['maintabs'].frames["iframe22"].location.replace("../SysManager/SystemAnnual.aspx");
                    }
                    else {
                        tabs.add({id:'tabannual', title:'年报提醒',html:'<iframe id="iframe22" src="../SysManager/SystemAnnual.aspx" width="100%" height="100%" frameBorder="0"></iframe>'});
                        tabs.setActiveTab('tabannual');
                    }
                }
            });
            
            <%} if (Session["permrange"] != null && Session["permrange"].ToString().IndexOf("010500") >= 0)
                                      { %>
            
            Ext.get('initBtn').on({
                click: function() {
                    var tabs = window.parent.frames['maintabs'].Ext.getCmp('tonzocTab');
                    var objinit = window.parent.frames['maintabs'].Ext.getCmp('tabinit');
                    if(objinit) {
                        tabs.setActiveTab('tabinit');
                        window.parent.frames['maintabs'].frames["iframe23"].location.replace("../SysManager/SystemInit.aspx");
                    }
                    else {
                        tabs.add({id:'tabinit', title:'缺省设置',html:'<iframe id="iframe23" src="../SysManager/SystemInit.aspx" width="100%" height="100%" frameBorder="0"></iframe>'});
                        tabs.setActiveTab('tabinit');
                    }
                }
            });
            
            <%} if (Session["permrange"] != null && Session["permrange"].ToString().IndexOf("050400") >= 0)
                                      { %>
                        
            Ext.get('cshszBtn').on({
                click: function() {
                    var tabs = window.parent.frames['maintabs'].Ext.getCmp('tonzocTab');
                    var objcshsz = window.parent.frames['maintabs'].Ext.getCmp('tabcshsz');
                    if(objcshsz) {
                        tabs.setActiveTab('tabcshsz');
                        window.parent.frames['maintabs'].frames["iframe24"].location.replace("../Workflow/Default_rights_set.aspx");
                    }
                    else {
                        tabs.add({id:'tabcshsz', title:'初始化设置',html:'<iframe id="iframe24" src="../Workflow/Default_rights_set.aspx" width="100%" height="100%" frameBorder="0"></iframe>'});
                        tabs.setActiveTab('tabcshsz');
                    }
                }
            });
            
            <%} if (Session["permrange"] != null && Session["permrange"].ToString().IndexOf("040600") >= 0)
                                      { %>
            
            Ext.get('txlBtn').on({
                click: function() {
                    var tabs = window.parent.frames['maintabs'].Ext.getCmp('tonzocTab');
                    var objtxl = window.parent.frames['maintabs'].Ext.getCmp('tabtxl');
                    if(objtxl) {
                        tabs.setActiveTab('tabtxl');
                        window.parent.frames['maintabs'].frames["iframe25"].location.replace("../zhxxgl/contact.aspx");
                    }
                    else {
                        tabs.add({id:'tabtxl', title:'通讯录',html:'<iframe id="iframe25" src="../zhxxgl/contact.aspx" width="100%" height="100%" frameBorder="0"></iframe>'});
                        tabs.setActiveTab('tabtxl');
                    }
                }
            });
            
            <%} if (Session["permrange"] != null && Session["permrange"].ToString().IndexOf("010600") >= 0)
                                      { %>
                        
            Ext.get('grzlBtn').on({
                click: function() {
                    var tabs = window.parent.frames['maintabs'].Ext.getCmp('tonzocTab');
                    var objgrzl = window.parent.frames['maintabs'].Ext.getCmp('tabgrzl');
                    if(objgrzl) {
                        tabs.setActiveTab('tabgrzl');
                        window.parent.frames['maintabs'].frames["iframe26"].location.replace("../SysManager/SystemUserInfo.aspx");
                    }
                    else {
                        tabs.add({id:'tabgrzl', title:'个人资料',html:'<iframe id="iframe26" src="../SysManager/SystemUserInfo.aspx" width="100%" height="100%" frameBorder="0"></iframe>'});
                        tabs.setActiveTab('tabgrzl');
                    }
                }
            });
            
            <%} if (Session["permrange"] != null && Session["permrange"].ToString().IndexOf("060500") >= 0)
                                      { %>
                        
            Ext.get('mbscBtn').on({
                click: function() {
                    var tabs = window.parent.frames['maintabs'].Ext.getCmp('tonzocTab');
                    var objmbsc = window.parent.frames['maintabs'].Ext.getCmp('tabmbsc');
                    if(objmbsc) {
                        tabs.setActiveTab('tabmbsc');
                        window.parent.frames['maintabs'].frames["iframe27"].location.replace("../Disclosure/DocUpload.aspx");
                    }
                    else {
                        tabs.add({id:'tabmbsc', title:'模板上传',html:'<iframe id="iframe27" src="../Disclosure/DocUpload.aspx" width="100%" height="100%" frameBorder="0"></iframe>'});
                        tabs.setActiveTab('tabmbsc');
                    }
                }
            });
            
            <%} if (Session["permrange"] != null && Session["permrange"].ToString().IndexOf("050500") >= 0)
                                      { %>
                        
            Ext.get('rssdBtn').on({
                click: function() {
                    var tabs = window.parent.frames['maintabs'].Ext.getCmp('tonzocTab');
                    var objrssd = window.parent.frames['maintabs'].Ext.getCmp('tabrssd');
                    if(objrssd) {
                        tabs.setActiveTab('tabrssd');
                        window.parent.frames['maintabs'].frames["iframe28"].location.replace("../Workflow/StaffManageSet.aspx");
                    }
                    else {
                        tabs.add({id:'tabrssd', title:'人事设定',html:'<iframe id="iframe28" src="../Workflow/StaffManageSet.aspx" width="100%" height="100%" frameBorder="0"></iframe>'});
                        tabs.setActiveTab('tabrssd');
                    }
                }
            });
            
            <%} %>
            
        });
    
        function changepage(src) {
            if (src != "") {
                window.parent.document.getElementById('man_zone').innerHTML = "<iframe src='" + src + "' height='100%' width='100%' frameborder='0'></iframe> ";
            }
        }
    </script>
</head>
<body>
    <form runat="server" id="form1" style="height:100%;">
    <table width="192px" height="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#8fc8f5">
        <tr>
            <td height="80px" background="../../images/left03.jpg">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="45%" style="padding-left:10px; padding-top:3px;">
                            <asp:Image ID="touxiang" runat="server" ImageUrl="../../images/left08.jpg" width="75px" height="68px"/>
                        </td>
                        <td style="padding-top:5px;" align="center"><font face="楷体" size="3px" color="#246190">
                                <div style="height:25px;"><asp:Label ID="yh" runat="server"></asp:Label></div>
                                <asp:LinkButton ID="logoff" runat="server" OnClick="Logoff" OnClientClick="return confirm('您确认注销吗？');">注销</asp:LinkButton>
                                <asp:LinkButton ID="logout" runat="server" OnClick="Logout" OnClientClick="return confirm('您确认退出吗？');">退出</asp:LinkButton>
                            </font>
                        </td>
                    </tr>
                </table>
            </td>
            <td rowspan="5" width="1px">
            </td>
            <td rowspan="5" width="7px" background="../../images/left01.jpg">
        </tr>
        <tr>
            <td height="5px"></td>
        </tr>
        <tr>
            <td height="26px" background="../../images/left04.jpg" align="center" style="font-family:隶书; font-size:19px; color:White;">
                工作台
            </td>
        </tr>
        <tr>
            <td valign="top" height="100%">
                <table width="185px" border="0" align="center" cellpadding="0" cellspacing="0">
                    <%if(Session["permrange"]!=null&&Session["permrange"].ToString().IndexOf("020000")>=0){ %>
                    <tr>
                        <td>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td colspan="2" height="31px" align="center" background="../../images/left05.jpg" id="imgmenu0" onclick="showsubmenu(0)"
                                        style="cursor: pointer"  onmouseover="this.className='menucss1'" onmouseout="this.className='menucss'">
                                        <table width="100%">
                                            <tr>
                                                <td width="60px" align="right">
                                                    <img src="../../images/left14.jpg" height="18px" width="18px"/>
                                                </td>
                                                <td style="font-family:楷体; color:#476074; font-size:16px;" align="left">工作流</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="2px"></td>
                                    <td id="submenu0" style="display:none;padding-bottom:15px; padding-left:5px;" bgcolor="#f2f6ff";>
                                        <%if (Session["permrange"] != null && Session["permrange"].ToString().IndexOf("020100") >= 0)
                                      { %>
                                        <div id="xjgzBtn" class="divout" onmouseover="this.className='divover'" onmouseout="this.className='divout'">
                                            <img src="../../images/left16.jpg"  width="40px" height="40px"/><br/>
                                            新建工作
                                        </div>
                                        <%} if (Session["permrange"] != null && Session["permrange"].ToString().IndexOf("020200") >= 0)
                                      { %>
                                        <div id="dbsxBtn" class="divout" onmouseover="this.className='divover'" onmouseout="this.className='divout'">
                                            <img src="../../images/left17.jpg"  width="40px" height="40px"/><br/>
                                            待办事项
                                        </div>
                                        <%} if (Session["permrange"] != null && Session["permrange"].ToString().IndexOf("020300") >= 0)
                                      { %>
                                        <div id="gzckBtn" class="divout" onmouseover="this.className='divover'" onmouseout="this.className='divout'">
                                            <img src="../../images/left18.jpg"  width="40px" height="40px"/><br/>
                                            工作查看
                                        </div>
                                        <%} %>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <%} %>
                    <%if(Session["permrange"]!=null&&Session["permrange"].ToString().IndexOf("010000")>=0){ %>
                    <tr>
                        <td>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td colspan="2" height="31px" align="center" background="../../images/left05.jpg" id="imgmenu1" onclick="showsubmenu(1)"
                                        style="cursor: pointer"  onmouseover="this.className='menucss1'" onmouseout="this.className='menucss'">
                                        <table width="100%">
                                            <tr>
                                                <td width="60px" align="right">
                                                    <img src="../../images/left09.jpg" height="18px" width="18px"/>
                                                </td>
                                                <td style="font-family:楷体; color:#476074; font-size:16px;" align="left">系统管理</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="2px"></td>
                                    <td id="submenu1" style="display:none;padding-bottom:15px; padding-left:6px;" bgcolor="#f2f6ff";>
                                    <%if (Session["permrange"] != null && Session["permrange"].ToString().IndexOf("010100") >= 0)
                                      { %>
                                        <div id="userBtn" class="divout" onmouseover="this.className='divover'" onmouseout="this.className='divout'">
                                            <img src="../../images/left10.jpg"  width="40px" height="40px"/><br/>
                                            用户管理
                                        </div>
                                    <%} if (Session["permrange"] != null && Session["permrange"].ToString().IndexOf("010200") >= 0)
                                      { %>
                                        <div id="roleBtn" class="divout" onmouseover="this.className='divover'" onmouseout="this.className='divout'">
                                            <img src="../../images/left13.jpg"  width="40px" height="40px"/><br/>
                                            角色管理
                                        </div>
                                    <%} if (Session["permrange"] != null && Session["permrange"].ToString().IndexOf("010300") >= 0)
                                      { %>
                                        <div id="rightBtn" class="divout" onmouseover="this.className='divover'" onmouseout="this.className='divout'">
                                            <img src="../../images/left12.jpg"  width="40px" height="40px"/><br/>
                                            权限管理
                                        </div>
                                    <%} if (Session["permrange"] != null && Session["permrange"].ToString().IndexOf("010400") >= 0)
                                      { %>
                                        <div id="annualBtn" class="divout" onmouseover="this.className='divover'" onmouseout="this.className='divout'">
                                            <img src="../../images/left37.jpg"  width="40px" height="40px"/><br/>
                                            年报提醒
                                        </div>
                                     <%} if (Session["permrange"] != null && Session["permrange"].ToString().IndexOf("010500") >= 0)
                                      { %>
                                        <div id="initBtn" class="divout" onmouseover="this.className='divover'" onmouseout="this.className='divout'">
                                            <img src="../../images/left38.jpg"  width="40px" height="40px"/><br/>
                                            缺省设置
                                        </div>
                                      <%} if (Session["permrange"] != null && Session["permrange"].ToString().IndexOf("010600") >= 0)
                                      { %>
                                        <div id="grzlBtn" class="divout" onmouseover="this.className='divover'" onmouseout="this.className='divout'">
                                            <img src="../../images/left24.jpg"  width="40px" height="40px"/><br/>
                                            个人资料
                                        </div>
                                    <%} %>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <%} %>
                    <%if(Session["permrange"]!=null&&Session["permrange"].ToString().IndexOf("030000")>=0){ %>
                    <tr>
                        <td>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td colspan="2" height="31px" align="center" background="../../images/left05.jpg" id="imgmenu2" onclick="showsubmenu(2)"
                                        style="cursor: pointer"  onmouseover="this.className='menucss1'" onmouseout="this.className='menucss'">
                                        <table width="100%">
                                            <tr>
                                                <td width="60px" align="right">
                                                    <img src="../../images/left15.jpg" height="18px" width="18px"/>
                                                </td>
                                                <td style="font-family:楷体; color:#476074; font-size:16px;" align="left">消息管理</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="2px"></td>
                                    <td id="submenu2" style="display:none;padding-bottom:15px; padding-left:5px;" bgcolor="#f2f6ff";>
                                        <%if (Session["permrange"] != null && Session["permrange"].ToString().IndexOf("030100") >= 0)
                                      { %>
                                        <div id="msgBtn" class="divout" onmouseover="this.className='divover'" onmouseout="this.className='divout'">
                                            <img src="../../images/left19.jpg"  width="40px" height="40px"/><br/>
                                            发送消息
                                        </div>
                                        <%} if (Session["permrange"] != null && Session["permrange"].ToString().IndexOf("030200") >= 0)
                                      { %>
                                        <div id="sendmsgBtn" class="divout" onmouseover="this.className='divover'" onmouseout="this.className='divout'">
                                            <img src="../../images/left20.jpg"  width="40px" height="40px"/><br/>
                                            发送列表
                                        </div>
                                        <%} if (Session["permrange"] != null && Session["permrange"].ToString().IndexOf("030300") >= 0)
                                      { %>
                                        <div id="receivemsgBtn" class="divout" onmouseover="this.className='divover'" onmouseout="this.className='divout'">
                                            <img src="../../images/left21.jpg"  width="40px" height="40px"/><br/>
                                            接收列表
                                        </div>
                                        <%} %>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <%} %>
                    <%if(Session["permrange"]!=null&&Session["permrange"].ToString().IndexOf("040000")>=0){ %>
                    <tr>
                        <td>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td colspan="2" height="31px" align="center" background="../../images/left05.jpg" id="imgmenu3" onclick="showsubmenu(3)"
                                        style="cursor: pointer"  onmouseover="this.className='menucss1'" onmouseout="this.className='menucss'">
                                        <table width="100%">
                                            <tr>
                                                <td width="60px" align="right">
                                                    <img src="../../images/left30.jpg" height="18px" width="18px"/>
                                                </td>
                                                <td style="font-family:楷体; color:#476074; font-size:16px;" align="left">人力资源</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="2px"></td>
                                    <td id="submenu3" style="display:none;padding-bottom:15px; padding-left:5px;" bgcolor="#f2f6ff";>
                                        <%if (Session["permrange"] != null && Session["permrange"].ToString().IndexOf("040100") >= 0)
                                      { %>
                                        <div id="zgjbxxglBtn" class="divout" onmouseover="this.className='divover'" onmouseout="this.className='divout'">
                                            <img src="../../images/left23.jpg"  width="40px" height="40px"/><br/>
                                            职工信息
                                        </div>
                                        <%} if (Session["permrange"] != null && Session["permrange"].ToString().IndexOf("040200") >= 0)
                                      { %>
                                        <div id="bmxxglBtn" class="divout" onmouseover="this.className='divover'" onmouseout="this.className='divout'">
                                            <img src="../../images/left24.jpg"  width="40px" height="40px"/><br/>
                                            部门人员
                                        </div>
                                        <%} if (Session["permrange"] != null && Session["permrange"].ToString().IndexOf("040300") >= 0)
                                      { %>
                                        <div id="bmglBtn" class="divout" onmouseover="this.className='divover'" onmouseout="this.className='divout'">
                                            <img src="../../images/left25.jpg"  width="40px" height="40px"/><br/>
                                            部门管理
                                        </div>
                                        <%} if (Session["permrange"] != null && Session["permrange"].ToString().IndexOf("040400") >= 0)
                                      { %>
                                        <div id="zwxxglBtn" class="divout" onmouseover="this.className='divover'" onmouseout="this.className='divout'">
                                            <img src="../../images/left26.jpg"  width="40px" height="40px"/><br/>
                                            职位信息
                                        </div>
                                        <%} if (Session["permrange"] != null && Session["permrange"].ToString().IndexOf("040500") >= 0)
                                      { %>
                                        <div id="jxkhhztjBtn" class="divout" onmouseover="this.className='divover'" onmouseout="this.className='divout'">
                                            <img src="../../images/left22.jpg"  width="40px" height="40px"/><br/>
                                            绩效汇总
                                        </div>
                                        <%} if (Session["permrange"] != null && Session["permrange"].ToString().IndexOf("040600") >= 0)
                                      { %>
                                        <div id="txlBtn" class="divout" onmouseover="this.className='divover'" onmouseout="this.className='divout'">
                                            <img src="../../images/left29.png"  width="40px" height="40px"/><br/>
                                             通讯录
                                        </div>
                                        <%} %>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <%} %>
                    <%if(Session["permrange"]!=null&&Session["permrange"].ToString().IndexOf("050000")>=0){ %>
                    <tr>
                        <td>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td colspan="2" height="31px" align="center" background="../../images/left05.jpg" id="imgmenu4" onclick="showsubmenu(4)"
                                        style="cursor: pointer"  onmouseover="this.className='menucss1'" onmouseout="this.className='menucss'">
                                        <table width="100%">
                                            <tr>
                                                <td width="60px" align="right">
                                                    <img src="../../images/left31.jpg" height="18px" width="18px"/>
                                                </td>
                                                <td style="font-family:楷体; color:#476074; font-size:16px;" align="left">工作流管理</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="2px"></td>
                                    <td id="submenu4" style="display:none;padding-bottom:15px; padding-left:5px;" bgcolor="#f2f6ff";>
                                        <%if (Session["permrange"] != null && Session["permrange"].ToString().IndexOf("050100") >= 0)
                                      { %>
                                        <div id="drqxszBtn" class="divout" onmouseover="this.className='divover'" onmouseout="this.className='divout'">
                                            <img src="../../images/left29.jpg"  width="40px" height="40px"/><br/>
                                            单人权限
                                        </div>
                                        <%} if (Session["permrange"] != null && Session["permrange"].ToString().IndexOf("050200") >= 0)
                                      { %>
                                        <div id="duorqxszBtn" class="divout" onmouseover="this.className='divover'" onmouseout="this.className='divout'">
                                            <img src="../../images/left27.jpg"  width="40px" height="40px"/><br/>
                                            多人权限
                                        </div>
                                        <%} if (Session["permrange"] != null && Session["permrange"].ToString().IndexOf("050300") >= 0)
                                      { %>
                                        <div id="gzlryszBtn" class="divout" onmouseover="this.className='divover'" onmouseout="this.className='divout'">
                                            <img src="../../images/left28.jpg"  width="40px" height="40px"/><br/>
                                            人员设置
                                        </div>                                        
                                        <%} if (Session["permrange"] != null && Session["permrange"].ToString().IndexOf("050400") >= 0)
                                      { %>
                                        <div id="cshszBtn" class="divout" onmouseover="this.className='divover'" onmouseout="this.className='divout'">
                                            <img src="../../images/left28.png"  width="40px" height="40px"/><br/>
                                            初始化设置
                                        </div>
                                        <%} if (Session["permrange"] != null && Session["permrange"].ToString().IndexOf("050500") >= 0)
                                      { %>
                                        <div id="rssdBtn" class="divout" onmouseover="this.className='divover'" onmouseout="this.className='divout'">
                                            <img src="../../images/rssd.png"  width="40px" height="40px"/><br/>
                                            人员配置
                                        </div>
                                        <%} %>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <%} %>
                    <%if(Session["permrange"]!=null&&Session["permrange"].ToString().IndexOf("060000")>=0){ %>
                    <tr>
                        <td>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td colspan="2" height="31px" align="center" background="../../images/left05.jpg" id="imgmenu5" onclick="showsubmenu(5)"
                                        style="cursor: pointer"  onmouseover="this.className='menucss1'" onmouseout="this.className='menucss'">
                                        <table width="100%">
                                            <tr>
                                                <td width="60px" align="right">
                                                    <img src="../../images/left32.jpg" height="18px" width="18px"/>
                                                </td>
                                                <td style="font-family:楷体; color:#476074; font-size:16px;" align="left">信息披露</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="2px"></td>
                                    <td id="submenu5" style="display:none;padding-bottom:15px; padding-left:5px;" bgcolor="#f2f6ff";>
                                        <%if (Session["permrange"] != null && Session["permrange"].ToString().IndexOf("060500") >= 0)
                                      { %>
                                      <div id="mbscBtn" class="divout" onmouseover="this.className='divover'" onmouseout="this.className='divout'">
                                            <img src="../../images/left20.jpg"  width="40px" height="40px"/><br/>
                                            模板上传
                                        </div>
                                        <%} if (Session["permrange"] != null && Session["permrange"].ToString().IndexOf("060100") >= 0)
                                      { %>
                                        <div id="mbxzBtn" class="divout" onmouseover="this.className='divover'" onmouseout="this.className='divout'">
                                            <img src="../../images/left33.jpg"  width="40px" height="40px"/><br/>
                                            模板下载
                                        </div>
                                        <%} if (Session["permrange"] != null && Session["permrange"].ToString().IndexOf("060200") >= 0)
                                      { %>
                                        <div id="jrzsBtn" class="divout" onmouseover="this.className='divover'" onmouseout="this.className='divout'">
                                            <img src="../../images/left35.jpg"  width="40px" height="40px"/><br/>
                                            金融知识
                                        </div>
                                        <%} if (Session["permrange"] != null && Session["permrange"].ToString().IndexOf("060300") >= 0)
                                      { %>
                                        <div id="xjggBtn" class="divout" onmouseover="this.className='divover'" onmouseout="this.className='divout'">
                                            <img src="../../images/left34.jpg"  width="40px" height="40px"/><br/>
                                            新建公告
                                        </div>
                                        <%} if (Session["permrange"] != null && Session["permrange"].ToString().IndexOf("060400") >= 0)
                                      { %>
                                        <div id="gglbBtn" class="divout" onmouseover="this.className='divover'" onmouseout="this.className='divout'">
                                            <img src="../../images/left36.jpg"  width="40px" height="40px"/><br/>
                                            公告列表
                                        </div>
                                        <%} %>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <%} %>
                </table>
            </td>
        </tr>
    </table>
</form>
</body>
</html>
