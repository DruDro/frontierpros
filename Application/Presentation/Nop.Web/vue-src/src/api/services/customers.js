import axios from "axios";
import { api } from '../../variables';

export class CustomersService {
	getProfileInformation() {
		return axios.get(`${api}/customer/profile`);
	}

	updateProfileInformation(payload) {
		return axios.post(`${api}/customer/profile`, payload);
	}
}