import axios from "axios";
import { api } from '../../variables';

export class ProvidersService {
	getProfileInformation() {
		return axios.get(`${api}/provider/profile`);
	}

	setPersonalInfo(payload) {
		return axios.post(`${api}/provider/account/personal-info`, payload)
	}

	setBusinessInfo(payload) {
		return axios.post(`${api}/provider/account/business-info`, payload)
	}

	setIndividualInfo(payload) {
		return axios.post(`${api}/provider/account/individual-info`, payload)
	}
}