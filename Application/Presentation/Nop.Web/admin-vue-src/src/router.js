import Vue from 'vue';
import Router from 'vue-router';
import error404 from './views/404.vue';
import Home from './views/Home.vue';

Vue.use(Router);
Vue.component('router-link', Vue.options.components.RouterLink);
Vue.component('router-view', Vue.options.components.RouterView);

let router = new Router({
	routes: [{
			path: '*',
			component: error404,
			meta: {
				title: 'Nothing found',
			}
		},
		{
			path: '/',
			component: Home,
			meta: {
				title: 'Home',
			}
		},
		{
			path: '/categories',
			component: () => import('./views/categories.vue'),
			meta: {
				title: 'Service Categories',
			}
		},
		{
			path: '/services',
			component: () => import('./views/services.vue'),
			meta: {
				title: 'Services & Questions',
			}
		},

	],
	scrollBehavior(to, from, savedPosition) {
		if (savedPosition) {
			return savedPosition;
		}
		if (to.hash) {
			return {
				selector: to.hash
			};
		}
		return {
			x: 0,
			y: 0
		};
	},
	mode: 'history',
	base: '/administration/',
});
router.beforeEach((to, from, next) => {
	document.title = to.meta.title;
	next();
});

export default router;