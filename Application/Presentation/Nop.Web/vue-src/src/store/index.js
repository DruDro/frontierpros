import Vue from 'vue';
import Vuex from 'vuex';

import { APIServices } from "../api/api-services";

Vue.use(Vuex);

export const store = new Vuex.Store({
	state: {
		title: '',
		user: {},
		serviceItem: {},
		services: [],
		providerQuestions: [],
		profile: {},
		isViewMode: false
	},

	getters: {
		USER: state => {
			return state.user;
		},
		PROFILE: state => {
			return state.profile;
		},
		SERVICE_ITEM: state => {
			return state.serviceItem;
		},
		PROVIDER_QUESTIONS: state => {
			return state.serviceItem;
		},
	},

	mutations: {
		ADD_MEDIA_FILE : (state, payload) => {
			state.profile.MediaFiles.push(payload.mediaFile);
		},
		UPDATE_MEDIA_FILE: (state, payload) => {
			const idx = state.profile.MediaFiles
				.map(x => x.Id)
				.indexOf(payload.mediaFile.Id);
			state.profile.MediaFiles[idx] = payload.mediaFile
		},
		REMOVE_MEDIA_FILE : (state, payload) => {
			state.profile.MediaFiles = state
				.profile
				.MediaFiles
				.filter(file => file.Id != payload.mediaFileId);
		},

		TOGGLE_VIEW_MODE : (state) => {
			state.isViewMode = !state.isViewMode;
		},

		SET_GALLERY_DESCRIPTION: (state, payload) => {
			state.profile.GalleryDescription = payload.galleryDescription;
		},

		SET_USER: (state, payload) => {
			state.user = payload;
		},
		SET_PROFILE: (state, payload) => {
			state.profile = payload;
		},
		SET_SERVICE_ITEM: (state, payload) => {
			state.serviceItem = payload;
		},
		SET_SERVICES: (state, payload) => {
			state.services = payload;
		},
		SET_PROVIDER_QUESTIONS: (state, payload) => {
			state.providerQuestions = payload;
		},
	},

	actions: {
		GET_USER: (context, payload) => {
			return new Promise((resolve, reject) => {
				APIServices
					.users
					.getRolesForAuthenticatedUser()
					.then(res => {
						context.commit('SET_USER', res.data);
						resolve(res.data)
					})
					.catch(err => reject(err))
			});
		},
		GET_PROFILE: ({
			commit,
			state
		}, role) => {
			return new Promise((resolve, reject) => {
				APIServices
					.users
					.getProfileInformation(role)
					.then(res => {
						commit('SET_PROFILE', res.data);
						resolve(res.data)
					}).catch(err => reject(err));
			});
		},
		GET_SERVICE_ITEM: ({
			commit,
			state
		}, payload) => {
			return new Promise((resolve, reject) => {
				APIServices
					.serviceItems
					.getProviderServiceItem(payload.id)
					.then(res => {
						commit('SET_SERVICE_ITEM', res.data);
						resolve(res.data)
					}).catch(err => reject(err));
			});
		},
		GET_SERVICES: ({
			commit,
			state
		}) => {
			return new Promise((resolve, reject) => {
				APIServices
					.services
					.getServices({})
					.then(res => {
						commit('SET_SERVICES', res.data);
						resolve(res.data)
					}).catch(err => reject(err));
			});
		},
		GET_PROVIDER_QUESTIONS: ({
			commit,
			state
		}, payload) => {
			return new Promise((resolve, reject) => {
				console.log(payload);
				APIServices
					.questionnaires
					.getProviderQuestionnaireByServiceId(payload.serviceInfoId)
					.then(res => {
						let providerQuestions = res.data;
						for (let i = 0; i < providerQuestions.length; i++) {
							for(let j = 0; j < providerQuestions[i].Options.length; j++){
								let settings = payload.settings.find(s => s.OptionId == providerQuestions[i].Options[j].Id);
								if(settings){
									providerQuestions[i].Options[j].IsActive = settings.IsActive;
									providerQuestions[i].Options[j].Price = settings.Price;
								} else {
									providerQuestions[i].Options[j].IsActive = false;
									providerQuestions[i].Options[j].Price = 0;		
								}
							}
						}

						commit('SET_PROVIDER_QUESTIONS', providerQuestions);
						resolve(providerQuestions)
					}).catch(err => reject(err));
			});
		},
		UPDATE_SERVICE_ITEM: ({
			commit,
			state
		}, serviceItem) => {
			return new Promise((resolve, reject) => {
				APIServices
					.serviceItems
					.editServiceItem(serviceItem)
					.then(res => {
						resolve(res.data)
					}).catch(err => reject(err));
			});
		}
	},
});