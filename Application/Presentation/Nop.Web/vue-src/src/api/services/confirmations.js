import axios from "axios";
import { api } from '../../variables';

export class ConfirmationsService {
	sendPhoneConfirmationCode(payload) {
		return axios.post(`${api}/phone-confirmation`, payload);
	}

	verifyPhoneConfirmation(payload) {
		return axios.post(`${api}/phone-confirmation/verify`, payload);
	}
}