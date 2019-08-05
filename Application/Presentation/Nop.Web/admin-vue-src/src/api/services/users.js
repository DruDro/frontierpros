import axios from "axios";
import { globalApi } from '../../variables';

export class UsersService {
	getRolesForAuthenticatedUser() {
		return axios.get(`${globalApi}/user`);
	}
}