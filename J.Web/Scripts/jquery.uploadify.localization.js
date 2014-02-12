//*********************************************************************
//1.查找如下代码，并注释掉alert行：
//	case SWFUpload.UPLOAD_ERROR.UPLOAD_LIMIT_EXCEEDED:
//	//alert('The upload limit has been reached (' + errorMsg + ').');
//	errorString = 'Exceeds Upload Limit';
//	break;
//*********************************************************************

//*********************************************************************
//2.将汉化一下部分
//	'Some files were not added to the queue:'
//	'一些文件未被加入到队列：'
//
//	'\nThe number of files selected exceeds the remaining upload limit ('
//	'\n所选文件的数量超过剩余的上传限制数量 ('
//
//	'\nThe number of files selected exceeds the queue size limit ('
//	'\n所选文件的数量超过了队列大小限制 ('
//
//	'\nThe file "'
//	'\n文件 "'
//
//	'" exceeds the size limit ('
//	'" 超过大小限制 ('
//
//	'" is empty.'
//	'" 为空文件.'
//
//	'" is not an accepted file type ('
//	'" 不是允许的文件类型 ('
//
//	' - Cancelled'
//	' - 取消'
//
//	' - Complete'
//	' - 完成'
//*********************************************************************

//*********************************************************************
//3.初始化时加入一下代码，用于处理弹出框，不加入则默认弹窗
//	overrideEvents: ['onDialogClose'],
//	onDialogClose: function (queueData)
//	{
//		//filesSelected		The number of files selected in browse files dialog
//		//filesQueued		The number of files added to the queue (that didn’t return an error)
//		//filesReplaced		The number of files replaced in the queue
//		//filesCancelled	The number of files that were cancelled from being added to the queue (not replaced)
//		//filesErrored		The number of files that returned an error
//		if (queueData.filesErrored > 0)
//		{
//			alert(queueData.errorMsg);
//		}
//	},
//*********************************************************************

//*********************************************************************
//4.适应本地的参数
//	swf: '/Content/uploadify.swf',		//'@Url.Content("~/Content/uploadify.swf")'
//	uploader: '/Home/UploadFile',		//'@Url.Action("UploadFile", "Home")'
//	// Options
//	buttonText: '选择文件',				// The text to use for the browse button
//	fileTypeDesc: '所有文件',			// The description for file types in the browse dialog
//	multi: false,						// Allow multiple file selection in the browse dialog
//	fileSizeLimit: '4MB',
//*********************************************************************
