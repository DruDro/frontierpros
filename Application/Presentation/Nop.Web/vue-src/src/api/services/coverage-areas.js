import axios from "axios";
import { api } from '../../variables';

export class CoverageAreasService {
	getCoverageAreasByServiceItemId(serviceItemId) {
		return axios.get(`${api}/provider/service-items/${serviceItemId}/coverage-areas`);
	}

	getCoverageArea(coverageAreaId) {
		return axios.get(`${api}/provider/coverage-areas/${coverageAreaId}`);
	}

	addCoverageArea(payload) {
		return axios.post(`${api}/provider/coverage-areas/add`, payload);
	}

	editCoverageArea(payload) {
		return axios.post(`${api}/provider/coverage-areas/edit`, payload);
	}

	deleteCoverageArea(coverageAreaId) {
		return axios.post(`${api}/provider/coverage-areas/delete/${coverageAreaId}`);
	}
}