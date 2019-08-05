import Vue from 'vue';
import Vuex from 'vuex';

import { APIServices } from "../api/api-services";

Vue.use(Vuex);

const userModule = {
	state: {
		user: {}
	},

	getters: {
		USER: state => {
			return state.user;
		}
	},

	mutations: {
		SET_USER: (state, payload) => {
			state.user = payload;
		},
	},

	actions: {
		GET_USER: async (context, payload) => {
			let { data } = await APIServices.users.getRolesForAuthenticatedUser();
			context.commit('SET_USER', data);
		}
	},
}

export const store = new Vuex.Store({
	state: {
		title: ''
	},
	modules: {
		userModule
	}
});