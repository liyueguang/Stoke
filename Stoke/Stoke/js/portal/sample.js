/*
 * Ext JS Library 2.2
 * Copyright(c) 2006-2008, Ext JS, LLC.
 * licensing@extjs.com
 * 
 * http://extjs.com/license
 */

Ext.onReady(function(){

    // NOTE: This is an example showing simple state management. During development,
    // it is generally best to disable state management as dynamically-generated ids
    // can change across page loads, leading to unpredictable results.  The developer
    // should ensure that stable state ids are set for stateful components in real apps.
    Ext.state.Manager.setProvider(new Ext.state.CookieProvider());

    var store1 = new Ext.data.Store({
    url:'contact_action.ashx?act=list',
    baseParams:{},
    reader:new Ext.data.JsonReader({
    	totalProperty: "results",
	  	root:"rows",
  		id:"contactID"
		},[{name: 'contactID'},{name:'userID'},
  		{name:'contactName'},{name:'age'},
		{name:'sex'},{name:'mobile'},
		{name:'email'},{name:'officeAddress'},
		{name:'officePhone'},{name:'officeZip'},
		{name:'homeAddress'},{name:'homePhone'},
		{name:'homeZip'}
		]),
    remoteSort: false
  })

    // create some portlet tools using built in Ext tool ids
    var tools = [{
        id:'gear',
        handler: function(){
            Ext.Msg.alert('Message', 'The Settings tool was clicked.');
        }
    },{
        id:'close',
        handler: function(e, target, panel){
            panel.ownerCt.remove(panel, true);
        }
    }];

    var viewport = new Ext.Viewport({
        layout:'border',
        items:[{
            xtype:'portal',
            region:'center',
            margins:'5 5 5 0',
            items:[{
                columnWidth:.33,
                style:'padding:10px 0 10px 10px',
                items:[{
                    title: 'Grid in a Portlet',
                    layout:'fit',
                    tools: tools,
                    items: new Ext.grid.GridPanel({width:600,
  	store:store1,
    columns:[
      {id:'contactID',header: "通讯录编号",width:120,dataIndex:'contactID',sortable: true,width:Ext.grid.GridView.autoFill},
      {header: "姓名", width: 160,dataIndex:'contactName',sortable: true},
//      {header: "年龄", width: 160,dataIndex:'age',sortable: true},
//      {header: "性别", width: 160,dataIndex:'sex',sortable: true},
      {header: "移动电话", width: 160,dataIndex:'mobile',sortable: true},
      {header: "邮箱", width: 160,dataIndex:'email',sortable: true},
      {header: "办公电话", width: 160,dataIndex:'officePhone',sortable: true},
      {header: "办公地址", width: 160,dataIndex:'email',sortable: true},
      {header: "家庭电话", width: 160,dataIndex:'homePhone',sortable: true}
      //app.CheckColumnLodked
    ]
  })
                },{
                    title: 'Another Panel 1',
                    tools: tools,
                    html: Ext.example.shortBogusMarkup
                }]
            },{
                columnWidth:.33,
                style:'padding:10px 0 10px 10px',
                items:[{
                    title: 'Panel 2',
                    tools: tools,
                    html: Ext.example.shortBogusMarkup
                },{
                    title: 'Another Panel 2',
                    tools: tools,
                    html: Ext.example.shortBogusMarkup
                }]
            },{
                columnWidth:.33,
                style:'padding:10px',
                items:[{
                    title: 'Panel 3',
                    tools: tools,
                    html: Ext.example.shortBogusMarkup
                },{
                    title: 'Another Panel 3',
                    tools: tools,
                    html: Ext.example.shortBogusMarkup
                }]
            }]
        }]
    });
});

