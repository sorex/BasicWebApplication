//#region 为Mustache.js扩展快捷方法
/*
 *         Authors: sorex
 *            Date: 2014-Feb-28
 *    Dependencies: Mustache.js
 *     Description: 为jQuery添加initTemplate全局方法，快速初始化Mustache.js的template。
 *                  同时添加formateDate方法，方便处理时间。
 */
jQuery.extend({
    initTemplate: function () {
        $("[data-template]").each(function () {
            var $this = $(this);
            $this.data("template", $("#" + $this.attr("data-template")).text());
            $this.data("template_extend", {
                formateDate: function () {
                    return function (text, render) {
                        return new Date(render(text)).format("yyyy-MM-dd");
                    }
                },
                formateDateTime: function () {
                    return function (text, render) {
                        return new Date(render(text)).format("yyyy-MM-dd HH:ii:ss");
                    }
                },
                formateTime: function () {
                    return function (text, render) {
                        return new Date(render(text)).format("HH:ii:ss");
                    }
                }
            });
            $this.html("");
        });
    }
});

/*
 *      Authors: sorex
 *         Date: 2014-Feb-28
 * Dependencies: Mustache.js
 *  Description: 为jQuery对象添加render方法，快捷调用Mustache.js的render方法。
 */
jQuery.fn.extend({
    render: function (data) {
        this.data("template_data", $.extend({}, data, this.data("template_extend")));
        this.html(Mustache.render(this.data("template"), this.data("template_data")));
    }
});
//#endregion

//#region 让 jquery.validate.js 兼容 bootstrap 3
/*
 *         Authors: sorex
 *            Date: 2014-Mar-9
 *    Dependencies: bootstrap.js(>=3.0), jquery.validate.js
 *     Description: 让 jquery.validate.js 兼容 bootstrap 3
 */
$.validator.setDefaults({
    highlight: function (element) {
        $(element).closest('.form-group').addClass('has-error');
    },
    unhighlight: function (element) {
        $(element).closest('.form-group').removeClass('has-error');
    },
    errorElement: 'span',
    errorClass: 'help-block',
    errorPlacement: function (error, element) {
        if (element.closest('.form-group').length) {
            error.appendTo(element.closest('.form-group'));
        } else if (element.parent('.input-group').length) {
            error.insertAfter(element.parent());
        } else {
            error.insertAfter(element);
        }
    }
});
//#endregion

//#region 扩展 Date 对象
/*
 *         Authors: sorex
 *            Date: 2014-Mar-9
 *    Dependencies: bootstrap-datetimepicker.js
 *     Description: 扩展 Date 对象的 format 方法 (2014年9月8日 上午7点6分5秒)
 *				h:小时，12小时制
 *				hh:小时，补0
 *				i:分钟
 *				ii:分钟，补0
 *				s:秒
 *				ss:秒，补0
 *				yyyy:年份
 *				yy:年份，后两位
 *				M:月份简写
 *				MM:月份全称
 *				m:数字月，补0
 *				mm:数字月
 *				D:星期简写
 *				DD:星期全称
 *				d:日期
 *				dd:日期，补0
 *				H:小时，24小时制
 *				HH:小时，补0
 *				p:am/pm
 *				P:AM/PM				
 */
Date.prototype.format = function (format) {
    return $.fn.datetimepicker.DPGlobal.formatDate(this, $.fn.datetimepicker.DPGlobal.parseFormat(format, 'standard'), "zh-CN", 'standard');
}
//#endregion

//#region 初始化 tinymce
/*
 *         Authors: sorex
 *            Date: 2014-Mar-9
 *    Dependencies: tinymce.js, jquery.tinymce.js
 *     Description: 让mce兼容bootstrap dialog
 */
$(function () {
    if ("undefined" != typeof tinymce) {
        // Prevent bootstrap dialog from blocking focusin
        $(document).on('focusin', function (e) {
            if ($(e.target).closest(".mce-window").length) {
                e.stopImmediatePropagation();
            }
        });
    }
});
//#endregion