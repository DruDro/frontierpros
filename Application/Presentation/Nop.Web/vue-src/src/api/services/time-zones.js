import axios from "axios";
import { api } from '../../variables';

export class TimeZonesService {
	getTimeZones() {
		return axios.get(`${api}/timezones`);
	}
}