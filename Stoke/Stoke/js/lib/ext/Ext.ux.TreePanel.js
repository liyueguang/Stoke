
Ext.namespace('Ext.ux.TreePanel');


Ext.ux.TreePanel = function(config){
  var default_config = {
    title: '标题', 
    actionUrl:'',
		animate:false,
		region:'west',
		split:true,
		width: 200,
		minSize: 175,
		maxSize: 400,
		collapsible: true,
		hideCollapseTool:true,
		collapseMode:'mini',
		margins:'0 0 5 0',
		rootVisible:true,
		autoScroll:true,
		enableDD:true,
		border:false,
		enableDrop:true,
		rootVisible:false,
  };
  config = Ext.applyIf(config || {}, default_config);
  config.layout = 'fit';

	Ext.ux.TreePanel.superclass.constructor.call(this, config);

};


Ext.extend(Ext.ux.TreePanel, Ext.tree.TreePanel, {
	
	enableChange:true,
	
	AddNode:function(){
		Ext.MessageBox.prompt('新增类别', '请输入类别名称',function(btn, text){
			if (btn == 'ok' & text.trim()!=''){
				if(typeof this.actionUrl=='string'){
	        Ext.Ajax.request({
			      url: this.actionUrl+'?act=add&value='+escape(text),
		        scripts:true,
				    scope:this,
		        success:function(oResponse,op){
				    	var msg=oResponse.responseText;
				    	var returnData=Ext.util.JSON.decode(msg);
				    	if(typeof returnData == "object"){
				    		if(returnData.success=="true"){
		   	      		this.root.reload();
				    			return;
				    		}else{
				    			msg=returnData.data;
				    		}
				    	}					    	
				      Ext.Msg.alert('信息',msg);
				   	},//success
				   	failure:function(oResponse,op){
			      	Ext.Msg.alert('信息',oResponse.responseText);
				   	}//failure
	 				});
	 			}
			}
		},this);
	},
	
	DelNode:function(){
		var node=this.getSelectionModel().getSelectedNode();
		if(typeof node=="object"){
		  var id=isNaN(node.id)?0:parseInt(node.id);
			if(id>0){
				Ext.MessageBox.confirm('删除类别','确定删除当前选择类别：'+node.text+
					'？<br><font color="red">当前类别所属图片将调整未分类图片</font>',function(btn){
					if(btn=='yes'){
		        Ext.Ajax.request({
				      url: this.actionUrl+'?act=del&id='+node.id,
			        scripts:true,
			        scope:this,
			        success:function(oResponse,op){
					    	var msg=oResponse.responseText;
					    	var returnData=Ext.util.JSON.decode(msg);
					    	if(typeof returnData == "object"){
					    		if(returnData.success=="true"){
										var node=this.getSelectionModel().getSelectedNode();
										if(typeof node=="object"){
											this.root.removeChild(node);
											if(this.root.childNodes[0]){
												this.root.childNodes[0].select();
												this.setTitle("全部");
												this.store.baseParams.classid=-99;
												this.store.baseParams.key='';
												this.store.load();
											}
										}
										this.delButton.disable();
							      //Ext.Msg.alert('信息',returnData.data);
					    			return;
					    		}else{
					    			msg=returnData.data;
					    		}
					    	}					    	
					      Ext.Msg.alert('信息',msg);
			       	},//success
			       	failure:function(oResponse,op){
				      	Ext.Msg.alert('信息',oResponse.responseText);
			       	}
			      });
					}
				},this)
			}else{
       	Ext.Msg.alert('信息','默认类别不允许删除！');
			}
		}else{
     	Ext.Msg.alert('信息','请选择要删除的类别！');
    }
	},
	
	RefreshTree:function(){
		this.root.reload();
	},

	onNodeDrop:function(nodeData,source,e,data){
		var nodeid=parseInt(nodeData.node.id);
		if(nodeid>0 | nodeid==-1){
			var len=data.nodes.length;
			var ids='';
			for(var i=0;i<len;i++){
				ids+=data.nodes[i].id+',';
			}
			ids=ids.substr(0,ids.length-1);
		  Ext.Ajax.request({
		    url: this.actionUrl+'?act=classedit&value='+escape(ids)+'&id='+nodeid,
		    scripts:true,
		    scope:this,
		    callback:function(oElement, bSuccess, oResponse){
		    	if(bSuccess){
	    			this.store.load();
		      }else
		      	Ext.Msg.alert('信息',oResponse.responseText);
		   	}//callback
		  });
		}
	},

	initComponent : function(ct, position){
	
		this.onNodeDropDelegate=this.onNodeDrop.createDelegate(this);

		this.dropConfig={ddGroup:"treeDD",onNodeDrop:this.onNodeDropDelegate};

		
		this.addButton=new Ext.Button({
			text:'增加',
			scope:this,
			handler:this.AddNode
		});

		this.delButton=new Ext.Button({
			text:'删除',
			disabled:true,
			scope:this,
			handler:this.DelNode
		});

		this.refreshButton=new Ext.Button({
			text:'刷新',
			scope:this,
			handler:this.RefreshTree
		});

		this.tbar=[this.addButton,this.delButton,'-',this.refreshButton];

    this.root=new Ext.tree.AsyncTreeNode({
    	text:this.title,
    	id:'0',
    	expanded:true,
    	allowDrag:false,
    	allowDrop:false,
    	loader:new Ext.tree.TreeLoader({dataUrl :this.actionUrl+'?act=list',clearOnLoad:true})
    })		
    Ext.ux.TreePanel.superclass.initComponent.call(this);

	},
	
	onRender : function(ct, position){
		Ext.ux.TreePanel.superclass.onRender.call(this, ct, position);
		
		this.on('textchange',function(node, text, oldText){
			if(this.enableChange){
			  var id=isNaN(node.id)?0:parseInt(node.id);
				if(id>0){
					if(text!=oldText | text.trim()!=""){
						this.selected=node;
						this.oldText=oldText;
						this.newText=text;
					  Ext.Ajax.request({
					  	scope:this,
					    url: this.actionUrl+'?act=edit&value='+escape(text)+'&id='+escape(node.id),
					    scripts:true,
					    callback:function(oElement, bSuccess, oResponse){
					    	var msg=oResponse.responseText;
					    	if(bSuccess){
		   	      		var data=Ext.util.JSON.decode(msg);
		   	      		if(data){
	   	      				msg=data.data;
		   	      			if(data.success=="false"){
											this.enableChange =false;											
											this.selected.setText(this.oldText);
										}else{
											this.setTitle(this.newText);
										}										
							      return;
							    }
					      }else{
									this.enableChange =false;											
									this.selected.setText(this.oldText);
					      	Ext.Msg.alert('信息',msg);
					      }
					   	}//callback
					  });
					}
				}else{
					this.enableChange =false;											
					node.setText(oldText);
				}
			}else{
				this.enableChange=true;
			}
		},this);
		
		
		this.on('click',function(node){
		  var id=isNaN(node.id)?0:parseInt(node.id);
			this.delButton. setDisabled((id>0)?false:true);
			this.setTitle(node.text);
			this.store.baseParams.classid=node.id;
			this.store.baseParams.key='';			
			this.store.load();			
		},this)
		
	}	
	
});

//uiTreePanel-end
