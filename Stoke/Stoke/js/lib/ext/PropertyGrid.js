Ext.namespace('Ext.ux.wam');

Ext.ux.wam.PropertyRecord = Ext.data.Record.create([
	{name:'pid'},
  {name:'name',type:'string'},
	{name:'text',type:'string'},
	'value',
	{name:'disabled',type:'boolean'},
	'editor',
	'groupname',
	'renderer',
	{name:'checked',type:'boolean'},	
]);

Ext.ux.wam.PropertyColumnModel = function(store,id){
    if(!id){
        this.id = Ext.id();
    }	else
    	this.id=id;
	this.store = store;
    Ext.ux.wam.PropertyColumnModel.superclass.constructor.call(this, [
        {header: Ext.grid.PropertyColumnModel.prototype.nameText, width:50, sortable: true, dataIndex:'name', id: 'name'},
        {header: Ext.grid.PropertyColumnModel.prototype.valueText, width:50, resizable:false, dataIndex: 'value', id: 'value'},
        {header: '选择?', width:30, dataIndex:'checked', id: 'checked'},
{header: 'groupname', hidden: true, dataIndex:'groupname',id:'groupname'}
    ]);

    this.bselect = Ext.DomHelper.append(document.body, {
        tag: 'select', cls: 'x-grid-editor x-hide-display', children: [
            {tag: 'option', value: 'true', html: '是'},
            {tag: 'option', value: 'false', html: '否'}
        ]
    });
    var bfield = new Ext.form.Field({
        el:this.bselect,
        bselect : this.bselect,
        autoShow: true,
        getValue : function(){
            return this.bselect.value == 'true';
        }
    });

    this.editors = {
        'date' : new Ext.grid.GridEditor(new Ext.form.DateField({selectOnFocus:true})),
        'string' : new Ext.grid.GridEditor(new Ext.form.TextField({selectOnFocus:true})),
        'number' : new Ext.grid.GridEditor(new Ext.form.NumberField({selectOnFocus:true, style:'text-align:left;'})),
       'boolean' : new Ext.grid.GridEditor(bfield)
    };
    this.renderCheckDelegate = this.renderCheck.createDelegate(this);
    this.renderCellDelegate = this.renderCell.createDelegate(this);
    this.renderPropDelegate = this.renderProp.createDelegate(this);
};

Ext.extend(Ext.ux.wam.PropertyColumnModel, Ext.grid.ColumnModel, {
    // private
    renderDate : function(dateVal){
        return dateVal.dateFormat(Ext.grid.PropertyColumnModel.prototype.dateFormat);
    },

    // private
    renderBool : function(bVal){
        return bVal ? '是' : '否';
    },

    // private
    isCellEditable : function(colIndex, rowIndex){
    	if(colIndex==2){
        return true;
      }
    	else
        return (colIndex == 1) && (this.store.getAt(rowIndex).data['disabled']!==true);
    },
	
    // private
    getRenderer : function(col){
       return col == 1 ? 
           this.renderCellDelegate:(col==2?this.renderCheckDelegate:this.renderPropDelegate);
    },

    renderCheck : function(v, p, record){
//        return bVal ? 'true' : 'false';
        p.css += ' x-grid3-check-col-td'; 
        return '<div class="x-grid3-check-col'+(v?'-on':'')+' x-grid3-cc-'+this.id+'">&#160;</div>';
    },

    // private
    renderProp : function(value,metadata,record){
        return record.data['text'] || record.data['name'];
    },

    // private
    renderCell : function(value,metadata,record){
        var rv = value;
		if (record.data['renderer'] == "") {
			if (value instanceof Date) {
				rv = this.renderDate(value);
			}
			else 
				if (typeof value == 'boolean') {
					rv=this.renderCheck(value,metadata,record);
					//rv = this.renderBool(value);
				}
			if (typeof value != 'boolean')
				rv = Ext.util.Format.htmlEncode(rv);
		}
		else {
			rv = record.data['renderer'].call(this, value);
		} 
		return rv;
    },

    // private
    getCellEditor : function(colIndex, rowIndex){
        var p = this.store.getAt(rowIndex);
				var val = p.data['value'];				
				if(colIndex==2) {
					val = p.data['checked'];
				}
        if(p.data['editor']!=="" & colIndex==1){
            return p.data['editor'];
        }
        if(val instanceof Date){
            return this.editors['date'];
        }else if(typeof val == 'number'){
            return this.editors['number'];
        }else if(typeof val == 'boolean'){
            return this.editors['boolean'];
       }else{
            return this.editors['string'];
        }
    }
});

Ext.ux.wam.PropertyGrid = Ext.extend(Ext.grid.EditorGridPanel, {

    // private config overrides
    enableColumnMove:false,
    stripeRows:false,
    trackMouseOver: false,
    clicksToEdit:1,
    enableHdMenu : false,
    /*viewConfig : {
        forceFit:true,
		getRowClass: function(record) {
			return (record.data['disabled']==true) ? "x-item-disabled" : "";
		}
    },*/

    // private
    initComponent : function(){
		    if(!this.id){
		        this.id = Ext.id();
		    }
	       this.lastEditRow = null;
        var cm = new Ext.ux.wam.PropertyColumnModel(this.store,this.id);
        this.store.sort('name', 'ASC');
        this.addEvents(
            'beforepropertychange',
            'propertychange'
        );
        this.cm = cm;
        Ext.ux.wam.PropertyGrid.superclass.initComponent.call(this);

        this.selModel.on('beforecellselect', function(sm, rowIndex, colIndex){
            if (this.store.getAt(rowIndex).data['disabled']==true) {return false;}
			if(colIndex === 0){
                this.startEditing.defer(200, this, [rowIndex, 1]);
                return false;
            }
        }, this);
    },

    // private
    onRender : function(){
        Ext.ux.wam.PropertyGrid.superclass.onRender.apply(this, arguments);

        this.getGridEl().addClass('x-props-grid');
    }
});