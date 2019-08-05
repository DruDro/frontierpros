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
			path: '/provider/configure-profile',
			component: () => import('./views/provider/configure-profile/configureProfile.vue'),
			meta: {
				title: 'Configure Profile',
			}
		},
		{
			path: '/service-provider/configure-profile',
			component: () => import('./views/provider/configure-profile/configureProfile.vue'),
			meta: {
				title: 'Configure Profile',
			}
		},
		{
			path: '/customer/configure-profile',
			component: () => import('./views/customer/configure-profile/configureProfile.vue'),
			meta: {
				title: 'Configure Profile',
			}
		},
		{
			path: '/provider/profile/',
			component: () => import('./views/provider/Profile/Profile.vue'),
			redirect: '/provider/profile/business-summary/',
			meta: {
				title: 'Profile',
			},
			children: [{
					path: 'business-summary',
					component: () => import('./views/provider/Profile/BusinessSummary.vue'),
					props: {
						pageTitle: 'Business Summary'
					},
					meta: {
						title: "Business Summary"
					}
				},
				{
					path: 'professional-license',
					component: () => import('./views/provider/Profile/ProfessionalLicense.vue'),
					props: {
						pageTitle: 'Professional License'
					},
					meta: {
						title: "Professional License"
					}
				},
				{
					path: 'reviews',
					component: () => import('./views/provider/Profile/Reviews.vue'),
					props: {
						pageTitle: 'Reviews'
					},
					meta: {
						title: "Reviews"
					}
				},
				{
					path: 'photo-video',
					component: () => import('./views/provider/Profile/PhotoVideo.vue'),
					props: {
						pageTitle: 'Photo & Video'
					},
					meta: {
						title: "Photo and Video"
					}
				},
				{
					path: 'general-info',
					component: () => import('./views/provider/Profile/GeneralInfo.vue'),
					props: {
						pageTitle: 'General Info'
					},
					meta: {
						title: "General Info"
					}
				}
			]
		},
		{
			path: '/customer/profile/',
			component: () => import('./views/customer/Profile/Profile.vue'),
			redirect: '/customer/profile/business-summary/',
			meta: {
				title: 'Profile',
			},
			children: [{
					path: 'business-summary',
					component: () => import('./views/customer/Profile/BusinessSummary.vue'),
					props: {
						pageTitle: 'Business Summary'
					},
					meta: {
						title: "Business Summary"
					}
				},
				{
					path: 'professional-license',
					component: () => import('./views/customer/Profile/ProfessionalLicense.vue'),
					props: {
						pageTitle: 'Professional License'
					},
					meta: {
						title: "Professional License"
					}
				},
				{
					path: 'reviews',
					component: () => import('./views/customer/Profile/Reviews.vue'),
					props: {
						pageTitle: 'Reviews'
					},
					meta: {
						title: "Reviews"
					}
				},
				{
					path: 'photo-video',
					component: () => import('./views/customer/Profile/PhotoVideo.vue'),
					props: {
						pageTitle: 'Photo & Video'
					},
					meta: {
						title: "Photo and Video"
					}
				},
				{
					path: 'general-info',
					component: () => import('./views/customer/Profile/GeneralInfo.vue'),
					props: {
						pageTitle: 'General Info'
					},
					meta: {
						title: "General Info"
					}
				}
			]
		},
		{
			path: '/provider/services/',
			component: () => import('./views/provider/Services/Services.vue'),
			meta: {
				title: 'Services',
			}
		},
		{
			path: '/customer/services/',
			component: () => import('./views/customer/Services/Services.vue'),
			meta: {
				title: 'Services',
			}
		},
		{
			path: '/provider/services/:id',
			component: () => import('./views/provider/Services/Service.vue'),
			redirect: '/provider/services/:id/service-info',
			meta: {
				title: 'Service',
			},
			children: [{
					path: 'service-info',
					component: () => import('./views/provider/Services/ServiceInfo.vue'),
					props: {
						pageTitle: 'Service Info'
					},
					meta: {
						title: "Service Info"
					}
				},
				{
					path: 'service-inventory',
					component: () => import('./views/provider/Services/ServiceInventory.vue'),
					props: {
						pageTitle: 'Service Inventory'
					},
					meta: {
						title: "Service Inventory"
					}
				},
				{
					path: 'service-price',
					component: () => import('./views/provider/Services/ServicePrice.vue'),
					props: {
						pageTitle: 'Service Price'
					},
					meta: {
						title: "Service Price"
					}
				},
				{
					path: 'service-faq',
					component: () => import('./views/provider/Services/ServiceFAQ.vue'),
					props: {
						pageTitle: 'Service FAQ'
					},
					meta: {
						title: "Service FAQ"
					}
				},
				{
					path: 'service-team',
					component: () => import('./views/provider/Services/Team.vue'),
					props: {
						pageTitle: 'Service Team'
					},
					meta: {
						title: "Service Team"
					}
				}
			]
		},
		{
			path: '/customer/services/:id',
			component: () => import('./views/customer/Services/Service.vue'),
			redirect: '/customer/services/:id/service-info',
			meta: {
				title: 'Service',
			},
			children: [{
					path: 'service-info',
					component: () => import('./views/customer/Services/ServiceInfo.vue'),
					props: {
						pageTitle: 'Service Info'
					},
					meta: {
						title: "Service Info"
					}
				},
				{
					path: 'service-inventory',
					component: () => import('./views/customer/Services/ServiceInventory.vue'),
					props: {
						pageTitle: 'Service Inventory'
					},
					meta: {
						title: "Service Inventory"
					}
				},
				{
					path: 'service-price',
					component: () => import('./views/customer/Services/ServicePrice.vue'),
					props: {
						pageTitle: 'Service Price'
					},
					meta: {
						title: "Service Price"
					}
				},
				{
					path: 'service-faq',
					component: () => import('./views/customer/Services/ServiceFAQ.vue'),
					props: {
						pageTitle: 'Service FAQ'
					},
					meta: {
						title: "Service FAQ"
					}
				},
				{
					path: 'service-team',
					component: () => import('./views/customer/Services/Team.vue'),
					props: {
						pageTitle: 'Service Team'
					},
					meta: {
						title: "Service Team"
					}
				}
			]
		},
		{
			path: '/provider/account',
			component: () => import('./views/provider/account/Account.vue'),
			props: {
				pageTitle: 'Account Settings'
			},
			meta: {
				title: "Account Settings"
			},
			children: [{
				path: 'personal-info',
				component: () => import('./views/provider/account/PersonalInfo.vue'),
				props: {
					pageTitle: 'Account Settings - Personal Info'
				},
				meta: {
					title: "Account Settings - Personal Info"
				},
			}, {
				path: 'business-info',
				component: () => import('./views/provider/account/BusinessInfo.vue'),
				props: {
					pageTitle: 'Account Settings - Business Info'
				},
				meta: {
					title: "Account Settings - Business Info"
				},
			}, {
				path: 'individual-info',
				component: () => import('./views/provider/account/IndividualInfo.vue'),
				props: {
					pageTitle: 'Account Settings - Individual Info'
				},
				meta: {
					title: "Account Settings - Individual Info"
				},
			}]
		},
		{
			path: '/provider/work',
			redirect: '/provider/work/jobs',
			component: () => import('./views/provider/work/work.vue'),
			props: {
				pageTitle: 'Work Area'
			},
			meta: {
				title: "Work Area"
			},
			children: [{
					path: 'jobs',
					component: () => import('./views/provider/work/jobs/jobList.vue'),
					props: {
						pageTitle: 'Jobs'
					},
					meta: {
						title: "Jobs"
					},
				},
				{
					path: 'requests',
					component: () => import('./views/provider/work/requests/requestList.vue'),
					props: {
						pageTitle: 'Job Requests'
					},
					meta: {
						title: "Job Requests"
					},
				}
			]
		},
		{
			path: '/provider/work/jobs/:id',
			redirect: '/provider/work/jobs/:id/info',
			component: () => import('./views/provider/work/jobs/job/job.vue'),
			props: {
				pageTitle: 'Job'
			},
			meta: {
				title: "Job"
			},
			children: [{
				path: 'info',
				component: () => import('./views/provider/work/jobs/job/jobInfo.vue'),
				props: {
					pageTitle: 'Job Info'
				},
				meta: {
					title: "Job Info"
				}
			}, {
				path: 'issue',
				component: () => import('./views/provider/work/jobs/job/jobIssue.vue'),
				props: {
					pageTitle: 'Job Issue'
				},
				meta: {
					title: "Job Issue"
				}
			}, {
				path: 'price',
				component: () => import('./views/provider/work/jobs/job/jobPrice.vue'),
				props: {
					pageTitle: 'Job Price'
				},
				meta: {
					title: "Job Price"
				}
			}]
		},
		{
			path: '/provider/work/requests/:id',
			redirect: '/provider/work/requests/:id/info',
			component: () => import('./views/provider/work/requests/request/request.vue'),
			props: {
				pageTitle: 'Request'
			},
			meta: {
				title: "Request"
			},
			children: [{
				path: 'info',
				component: () => import('./views/provider/work/requests/request/requestInfo.vue'),
				props: {
					pageTitle: 'Request Info'
				},
				meta: {
					title: "Request Info"
				}
			}, {
				path: 'issue',
				component: () => import('./views/provider/work/requests/request/requestIssue.vue'),
				props: {
					pageTitle: 'Request Issue'
				},
				meta: {
					title: "Request Issue"
				}
			}, {
				path: 'price',
				component: () => import('./views/provider/work/requests/request/requestPrice.vue'),
				props: {
					pageTitle: 'Request Price'
				},
				meta: {
					title: "Request Price"
				}
			}]
		}

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
	base: '/app/',
});
router.beforeEach((to, from, next) => {
	document.title = to.meta.title;
	next();
});

export default router;