<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainTabs.aspx.cs" Inherits="Stoke.USL.MainForm.MainTabs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="Stylesheet" href="../../js/lib/ext/resources/css/ext-all.css" />

    <script type="text/javascript" src="../../js/lib/ext/ext-base.js"></script>

    <script type="text/javascript" src="../../js/lib/ext/ext-all.js"></script>

    <script type="text/javascript" src="../../js/lib/ext/locale/ext-lang-zh_CN.js"></script>
    
    <script type="text/javascript" src="../../js/lib/ext/TabCloseMenu.js"></script>
    
    <style type="text/css">
       .x-tab-panel-bwrap,.x-tab-panel-bwrap *{
            height: 100%;
       }
       .x-tab-strip-text{
            text-align:center;
       }
    </style>
</head>
<body>
    <script type="text/javascript">

    	Ext.onReady(function(){
    		Ext.BLANK_IMAGE_URL = '../../../js/lib/ext/resources/images/default/s.gif';

    		tabs = new Ext.TabPanel({
    		    id: 'tonzocTab',
    			region: 'center',
    			margins: '0 0 5 0',
    			resizeTabs: true,
    			minTabWidth: 120,
    			tabWidth: 120,
    			enableTabScroll: true,
    			hideParent: true,
    			hideMode: 'offsets',
    			activeTab: 0,
    			frame:true,
    			style: 'height: 100%;width:100%;',
    			defaults: {
    			    closable: true
    			},
    			items: [
    			    {id:'welcomepage', title:'首  页', html:'<iframe src="mainWin.aspx" width="100%" height="100%" frameBorder="0"></iframe>', closable: false}
    			],
    			plugins: new Ext.ux.TabCloseMenu()
    		});
    		
    		var viewport = new Ext.Viewport({
    			frame: true,
    			layout: 'fit',
    			items: [tabs]
    		});
    	})
    </script>
</body>
</html>
