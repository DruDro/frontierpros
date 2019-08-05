import axios from "axios";
import { api } from '../../variables';

export class ProviderLicencesService {
	getProviderLicenses(providerId) {
		return axios.get(`${api}/provider/${providerId}/licenses`);
	}

	getLicense(licenceId) {
		return axios.get(`${api}/provider/licenses/${licenceId}`);
	}

	addLicense(payload) {
		return axios.post(`${api}/provider/licenses/add`, payload)
	}

	editLicense(payload) {
		return axios.post(`${api}/provider/licenses/edit`, payload)
	}

	deleteLicense(licenceId) {
		return axios.post(`${api}/provider/licenses/delete/${licenceId}`)
	}
}