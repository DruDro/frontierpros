$(function () {
	var tabContainers = $('.js-tab-cont'),
		links = '.js-tab-link',
		active = 'tab__link--active',
		initialTab = '';
	if ($('.' + active).length) {
		if ($('.' + active)[0].hash) {
			initialTab = $('.' + active)[0].hash
		} else {
			initialTab = `[data-id="` + $('.' + active).data('tab') + `"]`
		}
	} else {
		initialTab = ':first'
	}
	tabContainers.not(initialTab).hide();

	$(links).click(function (e) {
		var tab = this.hash ? {
			hash: this.hash
		} : {
			hash: $(this).data('tab'),
			dataAttr: true
		};

		e.preventDefault();
		if (tabContainers.is(':animated')) {
			return false;
		}

		tabContainers.hide();

		if (!$(this).hasClass(active)) {
			$(links).removeClass(active);
			if (tab.dataAttr) {
				tabContainers.filter('[data-id="' + tab.hash + '"]').show();
				$('[data-tab="' + tab.hash + '"]').addClass(active);
			} else {
				tabContainers.filter(tab.hash).show();
				$('[href="' + tab.hash).addClass(active);
			}

		} else {
			if (tab.dataAttr) {
				tabContainers.filter('[data-id="' + tab.hash + '"]').hide();
			} else {
				tabContainers.filter(tab.hash).hide();
			}

			$(links).removeClass(active);
		}
		return false;
	});

});