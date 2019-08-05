import 'babel-polyfill';
import "isomorphic-fetch";
import _ from 'lodash';
import Vue from 'vue';
import VueResource from 'vue-resource';
import Vuetify from 'vuetify';
import 'vuetify/dist/vuetify.min.css';
import '@fortawesome/fontawesome-free/js/all';
import { store } from './store';
import router from './router';
import App from './App.vue';
import SvgIcon from './components/partials/SvgIcon.vue';
import gradient from './components/partials/gradient.vue';
import card from './components/partials/Card.vue';
import './components/partials/Button.scss';
import checkbox from './components/partials/Checkbox.vue';
import radiobox from './components/partials/Radiobox.vue';
import switcher from './components/partials/Switch.vue';
import {api, capitalize} from './variables';

Vue.use(_);

Vue.prototype.$api = api;
window.$ = window.jQuery = require('jquery');
Vue.use({
	install: function (Vue) {
		Vue.prototype.$jQuery = require('jquery'); // you'll have this.$jQuery anywhere in your vue project
	}
});

Vue.use(VueResource);

Vue.component('svg-icon', SvgIcon);
Vue.component('gradient', gradient);
Vue.component('card', card);
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

Vue.filter('capitalize', capitalize);



Vue.config.productionTip = false;



new Vue({
	el:'#app',
	store,
	router,
	render: h => h(App)
  });