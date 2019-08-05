import axios from "axios";
import { api, mediaFileHeaders } from '../../variables';

export class UsersService {
	getRolesForAuthenticatedUser() {
		return axios.get(`${api}/user`);
	}

	getProfileInformation(role) {
		return axios.get(`${api}/${role}/profile`);
	}

	uploadIcon(payload) {
		return axios.post(`${api}/customer/profile/icon`, payload, mediaFileHeaders);
	}

	deleteIcon() {
		return axios.delete(`${api}/customer/profile/icon`);
	}
	
	uploadMediaFile(payload) {
		return axios.post(`${api}/customer/profile/media`, payload, mediaFileHeaders);
	}

	editMediaFile(id, payload) {
		return axios.put(`${api}/customer/profile/media/${id}`, payload);
	}

	deleteMediaFile(mediaFileId) {
		return axios.delete(`${api}/customer/profile/media/${mediaFileId}`);
	}
}