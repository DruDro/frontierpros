
export const api = process.env.NODE_ENV == 'development' ? `${location.origin}/api`: process.env.NODE_ENV == 'production' ? `${location.origin}/api` : '//mycuracare-dev.azurewebsites.net/api';

export const mediaFileHeaders = { headers: {'Content-Type': 'multipart/form-data' }}
export const validImageFormats = [".jpg", ".png"];
export const validVideoFormats = [".webm", ".mp4"];
export const maxImageSize = 1000 * 1000 * 10; // 10MB
export const maxVideoSize = 1000 * 1000 * 100; // 100MB