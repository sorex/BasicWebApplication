//┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓
//┃ jQuery对象的扩展，添加Mustache的快捷方法  ┃
//┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛

/*
 * Authors:  sorex
 * Date:    2014-Feb-28
 * Dependencies: Mustache.js
 * Description:
 */
jQuery.fn.extend({
    render: function (data) {
        this.data("template_data", $.extend({}, data, this.data("template_extend")));
        this.html(Mustache.render(this.data("template"), this.data("template_data")));
    }
});

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


//┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓
//┃ 让 jquery.validate.js 兼容 bootstrap 3  ┃
//┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛
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

//┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓
//┃ 使用 bootstrap-datetimepicker.js 扩展 Date 对象的 format 方法  ┃
//┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛

Date.prototype.format = function (format) {
    return $.fn.datetimepicker.DPGlobal.formatDate(this, $.fn.datetimepicker.DPGlobal.parseFormat(format, 'standard'), "zh-CN", 'standard');
}