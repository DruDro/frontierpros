import axios from "axios";
import { api, mediaFileHeaders } from '../../variables';

export class ServiceItemsService {
	getServiceItems(searchPayload) {
		return axios.post(`${api}/service-items/search`, searchPayload);
	}

	getProviderServiceItems() {
		return axios.get(`${api}/provider/service-items`);
	}

	getProviderServiceItem(serviceItemId) {
		return axios.get(`${api}/provider/service-items/${serviceItemId}`);
	}


	createServiceItem(payload) {
		return axios.post(`${api}/provider/service-items/add`, payload);
	}

	editServiceItem(payload) {
		return axios.post(`${api}/provider/service-items/edit`, payload);
	}

	deleteServiceItem(serviceItemId) {
		return axios.delete(`${api}/provider/service-items/edit/${serviceItemId}`);
	}


	uploadServiceItemIcon(serviceItemId, payload) {
		return axios.post(`${api}/provider/service-items/${serviceItemId}/icon`, payload, mediaFileHeaders);
	}

	deleteServiceItemIcon(serviceItemId) {
		return axios.delete(`${api}/provider/service-items/${serviceItemId}/icon`);
	}

	uploadServiceItemMedia(serviceItemId, payload) {
		return axios.post(`${api}/provider/service-items/${serviceItemId}/media`, payload, mediaFileHeaders);
	}

	deleteServiceItemMedia(serviceItemId, mediaFileId) {
		return axios.delete(`${api}/provider/service-items/${serviceItemId}/media/${mediaFileId}`);
	}
}