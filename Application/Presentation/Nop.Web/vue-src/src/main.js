import 'babel-polyfill';
import "isomorphic-fetch";
import _ from 'lodash';
import Vue from 'vue';
import Vuelidate from 'vuelidate';
import VueResource from 'vue-resource';
import Vuetify from 'vuetify';
import VueYoutube from 'vue-youtube';
import 'vuetify/dist/vuetify.min.css';
import '@fortawesome/fontawesome-free/js/all';
import { store } from './store';
import router from './router';
import App from './App.vue';
import SvgIcon from './components/partials/SvgIcon.vue';
import gradient from './components/partials/gradient.vue';
import card from './components/partials/Card.vue';
import mediaCard from './components/media-card.vue';
import './components/partials/Button.scss';
import checkbox from './components/partials/Checkbox.vue';
import radiobox from './components/partials/Radiobox.vue';
import switcher from './components/partials/Switch.vue';
import {api} from './variables';

Vue.use(_);
Vue.use(Vuelidate);
Vue.use(VueResource);
Vue.use(VueYoutube);

Vue.prototype.$api = api;
window.$ = window.jQuery = require('jquery');
Vue.use({
	install: function (Vue) {
		Vue.prototype.$jQuery = require('jquery'); // you'll have this.$jQuery anywhere in your vue project
	}
});

Vue.component('svg-icon', SvgIcon);
Vue.component('gradient', gradient);
Vue.component('card', card);
Vue.component('media-card', mediaCard);
Vue.component('switcher', switcher);
Vue.component('checkbox', checkbox);
Vue.component('radiobox', radiobox);

Vue.use(Vuetify, {
	theme: {
		primary: '#7094f7',
	},
	iconfont: 'md',
	icons: {
		'eye': {
			component: SvgIcon, // you can use string here if component is registered globally
			props: { // pass props to your component if needed
				name: 'eye',
				size:'100%'
			}
		}
	}
});

Vue.filter('capitalize', function (value) {
	if (!value) return '';
	value = value.toString();
	return value.charAt(0).toUpperCase() + value.slice(1);
});
Vue.filter('uppercase', function (value) {
	if (!value) return '';
	value = value.toString();
	return value.toUpperCase();
});
Vue.filter('lowercase', function (value) {
	if (!value) return '';
	value = value.toString();
	return value.toLowerCase();
});

Vue.filter('dollar', function (value) {
	if (!value) return '';
	value = value.toString();
	return `$${value}`;
});

Vue.config.productionTip = false;



new Vue({
	el:'#app',
	store,
	router,
	render: h => h(App)
  });