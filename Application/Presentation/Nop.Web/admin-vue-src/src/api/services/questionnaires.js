import axios from "axios";
import { api } from '../../variables';

export class QuestionnairesService {
	getServiceQuestionnaire(serviceId) {
		return axios.get(`${api}/services/${serviceId}/questionnaire`);
	}

	createQuestionnaire(serviceId, payload) {
		return axios.post(`${api}/services/${serviceId}/questionnaire/add`, payload);
	}  

	updateQuestionnaire(serviceId, payload) {
		return axios.post(`${api}/services/${serviceId}/questionnaire/edit`, payload);
	}
}