import axios from "axios";
import { api } from '../../variables';

export class ServiceCategoriesService {
	getServiceCategories() {
		return axios.get(`${api}/service-categories`);
	}

	getServiceCategoriesByServiceCategoryId(serviceCategoryId) {
		return axios.get(`${api}/service-categories/${serviceCategoryId}/services`);
	}
}