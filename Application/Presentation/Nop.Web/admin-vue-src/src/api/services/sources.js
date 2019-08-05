import axios from "axios";
import { api } from '../../variables';

export class SourcesService {
	getSourceServiceQuestionnaire(serviceId) {
		return axios.get(`${api}/sources/services/${serviceId}/questionnaire`);
	}

	getSourceCategories() {
		return axios.get(`${api}/sources/service-categories`);
	}

	getAllSourceServices() {
		return axios.post(`${api}/sources/services`, {});
	}
}