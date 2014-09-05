/*
Copyright (c) 2003-2010, CKSource - Frederico Knabben. All rights reserved.
For licensing, see LICENSE.html or http://ckeditor.com/license
*/

CKEDITOR.editorConfig = function( config )
{
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
	// config.uiColor = '#AADC6E';
	config.skin = 'office2003';
	config.language = 'zh-cn';
	//config.toolbar = "Basic";
	// config.width = 600; //宽度   
  config.height = 260; //高度
  config.toolbar =
    [
    ['Source', '-', 'Preview'], ['Cut', 'Copy', 'Paste', 'PasteText', 'PasteFromWord'], ['Undo', 'Redo', '-', 'Find', 'Replace', '-', 'SelectAll', 'RemoveFormat'], ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', 'Blockquote', 'ShowBlocks'], '/',
    ['Bold', 'Italic', 'Underline', 'Strike', '-', 'Subscript', 'Superscript'], ['JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock'], ['Link', 'Unlink', 'Anchor'], ['Image', 'Flash', 'Table', 'HorizontalRule', 'SpecialChar'], '/',
    ['Styles', 'Format', 'Font', 'FontSize'], ['TextColor', 'BGColor'], ['Maximize', '-', 'About']
    ];
  
    config.filebrowserBrowseUrl = 'js/ckfinder/ckfinder.html';
    config.filebrowserImageBrowseUrl = 'js/ckfinder/ckfinder.html?Type=Image';//Image是文件夹
    config.filebrowserFlashBrowseUrl = 'js/ckfinder/ckfinder.html?Type=Flash';
    config.filebrowserUploadUrl = 'js/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files';
    config.filebrowserImageUploadUrl = 'js/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Image';//Image是文件夹
    config.filebrowserFlashUploadUrl = 'js/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash';
    };
   