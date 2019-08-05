import axios from "axios";
import { api } from '../../variables';

export class ServicesService {
	getServices(payload) {
		return axios.post(`${api}/services`, payload);
	}

	createService(payload) {
		return axios.post(`${api}/services/add`, payload);
	}

	updateService(payload) {
		return axios.post(`${api}/services/edit`, payload);
	}

	deleteService(serviceId) {
		return axios.post(`${api}/services/delete/${serviceId}`);
	}
}