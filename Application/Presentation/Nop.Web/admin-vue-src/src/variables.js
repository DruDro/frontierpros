export const globalApi = process.env.NODE_ENV == 'development' ? `${location.origin}/api`: process.env.NODE_ENV == 'production' ? `${location.origin}/api` : '//mycuracare-dev.azurewebsites.net/api';

export const api = process.env.NODE_ENV == 'development' ? `${location.origin}/api/admin`: process.env.NODE_ENV == 'production' ? `${location.origin}/api/admin` : '//mycuracare-dev.azurewebsites.net/api';

export function capitalize(str) {
	if (!str) return '';
	let splitStr = str.toLowerCase().split(' ');
	for (let i = 0; i < splitStr.length; i++) {
		// You do not need to check if i is larger than splitStr length, as your for does that for you
		// Assign it back to the array
		splitStr[i] = splitStr[i].charAt(0).toUpperCase() + splitStr[i].slice(1);     
	}
	// Directly return the joined string
	return splitStr.join(' '); 
}