import axios from "axios";
import { api } from '../../variables';

export class ProviderReviewsService {
	getProviderReviews(providerId) {
		return axios.get(`${api}/provider/${providerId}/reviews`);
	}

	getReview(reviewId) {
		return axios.get(`${api}/provider/reviews/${reviewId}`);
	}

	addReview(payload) {
		return axios.post(`${api}/provider/reviews/add`, payload)
	}

	editReview(payload) {
		return axios.post(`${api}/provider/reviews/edit`, payload)
	}

	deleteReview(reviewId) {
		return axios.post(`${api}/provider/reviews/delete/${reviewId}`)
	}
}