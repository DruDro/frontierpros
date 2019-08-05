import axios from "axios";
import { api } from '../../variables';

export class QuestionnairesService {
	getClientQuestionnaireByServiceId(serviceId) {
		return axios.get(`${api}/services/${serviceId}/client-questions`);
	}

	getProviderQuestionnaireByServiceId(serviceId) {
		return axios.get(`${api}/services/${serviceId}/provider-questions`);
	}
}