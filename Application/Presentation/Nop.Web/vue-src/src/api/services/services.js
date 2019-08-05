import axios from "axios";
import { api } from '../../variables';

export class ServicesService {
	getServices(payload) {
		return axios.post(`${api}/services`, payload);
	}
}