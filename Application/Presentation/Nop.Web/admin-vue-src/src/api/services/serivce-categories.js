import axios from "axios";
import { api } from '../../variables';

export class ServiceCategoriesService {
	getCategroies() {
		return axios.get(`${api}/service-categories`);
	}
	
	createCategory(payload) {
		return axios.post(`${api}/service-categories/add`, payload);
	}

	updateCategory(payload) {
		return axios.post(`${api}/service-categories/edit`, payload);
	}

	deleteCategory(categoryId) {
		return axios.post(`${api}/service-categories/delete/${categoryId}`);
	}
}