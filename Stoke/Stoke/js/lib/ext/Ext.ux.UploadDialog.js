Ext.namespace('Ext.ux.UploadDialog');


Ext.ux.UploadDialog = function(config){
  var default_config = {
    border: false,
    width: 600,
    height: 400,
    minWidth: 450,
    minHeight: 300,
    plain: true,
    constrainHeader: true,
    draggable: true,
    closable: true,
    maximizable: false,
    minimizable: false,
    resizable: true,
    autoDestroy: true,
    closeAction: 'hide',
    title: "图片上传对话框",
    url: '',
		flash_url : "swfupload_f9.swf" ,
		file_size_limit : 0,
		file_upload_limit:0,
		file_queue_limit:0,
		file_types : "*.jpg;*.gif",
		file_post_name : "Filedata",
		post_params : {},
		file_types_description:'图片',
		swfu:null		
  }
  config = Ext.applyIf(config || {}, default_config);
  config.layout = 'fit';

	Ext.ux.UploadDialog.superclass.constructor.call(this, config);
	
	this.file_queued_handlerDelegate = this.file_queued_handler.createDelegate(this);
	this.upload_start_handlerDelegate =this.upload_start_handler.createDelegate(this);
	this.upload_progress_handlerDelegate = this.upload_progress_handler.createDelegate(this);
	this.upload_success_handlerDelegate = this.upload_success_handler.createDelegate(this);
	this.upload_error_handlerDelegate = this.upload_error_handler.createDelegate(this);
	this.file_queue_error_handlerDelegate = this.file_queue_error_handler.createDelegate(this);
	
	this.swfu=new SWFUpload({
		upload_url : this.url, 
		flash_url : this.flash_url ,
		file_size_limit : this.file_size_limit,
		file_types : this.file_types,
		file_post_name:this.file_post_name,
		post_params : this.post_params,
		file_types_description:this.file_types_description,
 		flash_color : "#FFFFFF", 
 		debug : false,
 		file_queued_handler :this.file_queued_handlerDelegate ,
 		upload_start_handler:this.upload_start_handlerDelegate,
 		upload_progress_handler:this.upload_progress_handlerDelegate,
 		upload_success_handler:this.upload_success_handlerDelegate,
 		upload_error_handler:this.upload_error_handlerDelegate,
 		file_queue_error_handler:this.file_queue_error_handlerDelegate
	});

}

Ext.extend(Ext.ux.UploadDialog, Ext.Window, {
	progressBarText:'正在上传：{0}，{1}%完成',
	
	statuBarText:'文件总数：{0}个  ，大小：{1}',

	uploading:false,

	file_queued_handler:function(file){
		var filetype=(file.type.substr(1)).toUpperCase();
		if(filetype=='JPG' | filetype=='GIF'){
			var data=[];
			data.push([file.id,'准备上传',file.name,file.size,filetype]);
			this.store.loadData(data,true);
			this.resetButton.enable();
			this.uploadButton.enable();
		}
	},

		
	upload_start_handler:function(file){
		var index=this.store.find('id',file.id);
		if(index>=0){
			this.store.getAt(index).set('state','正在上传……');
		}
		this.progressBar.updateProgress(0,String.format(this.progressBarText,file.name,0));
		return true;
	},

		
	upload_progress_handler:function(file,bytesloaded){
		var percent = Math.ceil((bytesloaded / file.size) * 100);
		this.progressBar.updateProgress(percent/100,String.format(this.progressBarText,file.name,percent));
	},
		
	upload_success_handler:function(file, server_data){
		var msg=Ext.util.JSON.decode(server_data);
		if(msg){
			var index=this.store.find('id',file.id);
			if(msg.success){
				if(index>=0)
					this.store.getAt(index).set('state',"上传成功");
				var stats=this.swfu.getStats();
				if(stats.files_queued==0){
					this.progressBar.updateProgress(0,"文件已全部上传");
					this.uploading = false;
					this.uploadButton.setText("上传");
					this.addButton.enable();
					this.closeButton.enable();
					this.delButton.enable();
					this.resetButton.enable();
				}else{
					this.swfu.startUpload();
				}
			}else{
			if(index>=0)
				this.store.getAt(index).set('state',msg.data);
			}
		}else{
			if(index>=0)
				this.store.getAt(index).set('state',msg);
		}
	},
		
	upload_error_handler:function(file,errcode,msg){
		var index=this.store.find('id',file.id);
		if(errcode==-290)msg="用户中止";
		if(index>=0)
			this.store.getAt(index).set('state',msg);
	},
		
	uploadCancel:function(file, queuelength){
		var index=this.store.find('id',file.id);
		if(index>=0)
			this.store.getAt(index).set('state','取消上传');
	},
	
	file_queue_error_handler:function(file,error_code,message){
		switch (error_code) {
		case SWFUpload.QUEUE_ERROR.FILE_EXCEEDS_SIZE_LIMIT:
			Ext.Msg.alert('错误',"文件不允许超过300k！<br> 文件名: " + file.name + "<br> 大小: " + file.size );
			break;
		case SWFUpload.QUEUE_ERROR.ZERO_BYTE_FILE:
			Ext.Msg.alert('错误',"不允许上传0字节文件！<br> 文件名: " + file.name + "<br> 大小: " + file.size );
			break;
		case SWFUpload.QUEUE_ERROR.QUEUE_LIMIT_EXCEEDED:
			Ext.Msg.alert('错误',"已超出上传文件数量！<br> 文件名: " + file.name + "<br> 大小: " + file.size );
			break;
		case SWFUpload.QUEUE_ERROR.INVALID_FILETYPE:
			Ext.Msg.alert('错误',"不允许上传该类文件！<br> 文件名: " + file.name + "<br> 大小: " + file.size );
			break;
		default:
			Ext.Msg.alert('错误',error_code);
			break;	
		}
	},
	
	initComponent : function(ct, position){
    Ext.ux.UploadDialog.superclass.initComponent.call(this);


	},

	onRender : function(ct, position){
		Ext.ux.UploadDialog.superclass.onRender.call(this, ct, position);
	

    this.store = new Ext.data.SimpleStore({fields: ["id","state", "file","size","type"],data:[]});
    
    var cm = new Ext.grid.ColumnModel([
     	new Ext.grid.RowNumberer(),
      {id:'id',header: "id",hidden:true,width:150,dataIndex:'id',resizable:false,sortable:false},
      {header: "文件名",width:Ext.grid.GridView.autoFill,dataIndex:'file',sortable:true},
      {header: "大小", width: 80,renderer:Ext.util.Format.fileSize,dataIndex:'size',sortable:true},
      {header: "类型", width: 80,dataIndex:'type',sortable:true},
      {header: "状态", width: 100,dataIndex:'state',sortable:true}
    ]);

		this.addButton=new Ext.Button({
			text:'添加',
			scope:this,
			handler:function(){
				if(this.swfu)
					this.swfu.selectFiles();
			}
		});

		this.delButton=new Ext.Button({
			text:'删除',
			scope:this,
			disabled:true,
			handler:function(){
				var recs=this.grid.getSelectionModel().getSelections();
				if(recs.length>0){
					for(var i=0;i<recs.length;i++){
						this.swfu.cancelUpload(recs[i].data.id);
						this.store.remove(recs[i]);
					}
				}
				this.delButton.disable();
				if(this.store.getCount()==0){
					this.resetButton.disable();
					this.uploadButton.disable();
				}
			}
		});

		this.resetButton=new Ext.Button({
			text:'清空',
			 disabled:true,
			scope:this,
			handler:function(){
				this.delButton.disable();
				this.resetButton.disable();
				this.uploadButton.disable();
				var len=this.store.getCount();
				for(var i=0;i<len;i++){
					var rec=this.store.getAt(i);
					this.swfu.cancelUpload(rec.data.id);
				}
				this.store.removeAll();				
			}
		});

		this.uploadButton=new Ext.Button({
			text:'上传',
			disabled:true,
			scope:this,
			handler:function(){
				if(! this.uploading){
					this.uploadButton.setText("中止");
					this.swfu.startUpload();
					this.uploading=true;
					this.closable=false;
					this.addButton.disable();
					this.closeButton.disable();
					this.delButton.disable();
					this.resetButton.disable();
				}else{
					this.uploadButton.setText("上传");
					this.swfu.stopUpload();
					this.uploading=false;
					this.closable=true;					
					this.addButton.enable();
					this.closeButton.enable();
					this.delButton.enable();
					this.resetButton.enable();
				}
			}
		});

		this.closeButton=new Ext.Button({
			text:'关闭',
			scope:this,
			handler:function(){
				this.hide();
			}
		});

		this.progressBar=new Ext.ProgressBar({anchor:'100%'});

    this.grid = new Ext.grid.GridPanel({
    	ds: this.store,
    	cm: cm,    
  	  anchor: '100% 100%',
    	border: true,      
      viewConfig: {
      autoFill: true,
        forceFit: true
      },      
      tbar : [
      	this.addButton,this.delButton,this.resetButton,'-',
      	this.uploadButton,'->',this.closeButton
      ],
      bbar:this.progressBar
    });
    
    this.add(this.grid);
    this.grid.on('rowclick', function(grid,rowIndex,e){
    	if(grid.getSelectionModel().hasSelection())
    		this.delButton.enable();
    }, this);		
		
		this.on("beforeclose",function(){if(this.uploading)return false},this);
		this.on("beforehide",function(){if(this.uploading)return false},this);
	}

});

