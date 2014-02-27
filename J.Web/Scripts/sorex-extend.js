//┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓
//┃ jQuery对象的扩展，添加Mustache的快捷方法  ┃
//┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛
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
			$this.data("template_extend", {});
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