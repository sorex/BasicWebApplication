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
        if (element.parent('.input-group').length) {
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
 *     Description: 扩展 Date 对象的 format 方法
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
 *     Description: 初始化 tinymce
 */
$(function () {
    if ("undefined" != typeof tinymce) {
        tinymce.init({
            selector: "textarea"
        });
    }
});
//#endregion