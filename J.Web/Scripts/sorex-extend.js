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
		$(".template").each(function () {
			var $this = $(this);
			$this.data("template", $("script[type='text/x-mustache']", $this).text());
			$this.data("template_extend", {});
			$this.html("");
		});
	}
});