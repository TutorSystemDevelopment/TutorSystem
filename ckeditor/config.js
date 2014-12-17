/**
 * @license Copyright (c) 2003-2013, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.html or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here.
	// For the complete reference:
	// http://docs.ckeditor.com/#!/api/CKEDITOR.config

	// The toolbar groups arrangement, optimized for two toolbar rows.
	config.toolbarGroups = [
		//{ name: 'clipboard',   groups: [ 'clipboard', 'undo' ] },
		//{ name: 'editing',     groups: [ 'find', 'selection', 'spellchecker' ] },
//		{ name: 'links' },
		{ name: 'insert' },
		{ name: 'forms' },
//		{ name: 'tools' },
//		{ name: 'document',	   groups: [ 'mode', 'document', 'doctools' ] },
//		{ name: 'others' },
		//'/',
		{ name: 'basicstyles', groups: [ 'basicstyles', 'cleanup' ] },
		//{ name: 'paragraph',   groups: [ 'list', 'indent', 'blocks', 'align', 'bidi' ] },
		{ name: 'styles' },
		{ name: 'colors' },
//		{ name: 'about' }
	];

	// Remove some buttons, provided by the standard plugins, which we don't
	// need to have in the Standard(s) toolbar.
	config.removeButtons = 'Underline,Subscript,Superscript';

	// Se the most common block elements.
	config.format_tags = 'p;h1;h2;h3;pre';

	// Make dialogs simpler.
	config.removeDialogTabs = 'image:advanced;link:advanced';


	config.filebrowserBrowseUrl = '../ckfinder/ckfinder.html';
	config.filebrowserImageBrowseUrl = '../ckfinder/ckfinder.html?Type=Images';
	config.filebrowserFlashBrowseUrl = '../ckfinder/ckfinder.html?Type=Flash';
	config.filebrowserUploadUrl = '../ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files';
	config.filebrowserImageUploadUrl = '../ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images';
	config.filebrowserFlashUploadUrl = '../ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash';

//	config.filebrowserWindowWidth = '800';  //“浏览服务器”弹出框的size设置
//	config.filebrowserWindowHeight = '500';
	// config.forcePasteAsPlainText = true;

	//    config.enterMode = 1; // 回车的时候增加的是<p>
	//    config.enterMode = 2; // 回车的时候增加的是<br>//需要的就是这种情况
	//    config.enterMode = 3; // 回车的时候增加的是<div>

	config.enterMode = 2; //CKEDITOR.ENTER_BR;
	config.shiftEnterMode = 2; //CKEDITOR.ENTER_P;


};
