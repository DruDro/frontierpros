import axios from "axios";
import { api } from '../../variables';

export class LocationsService {
	getCountries() {
		return axios.get(`${api}/countries`);
	}

	getRegionsByCountryId(countryId) {
		return axios.get(`${api}/countries/${countryId}/regions`)
	}

	getCitiesByCountryIdAndRegionId(countryId, regionId) {
		return axios.get(`${api}/countries/${countryId}/regions/${regionId}/cities`);
	}
}