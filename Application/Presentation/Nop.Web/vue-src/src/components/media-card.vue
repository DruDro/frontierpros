<template lang="pug">
	.media-card
		.card
			v-layout(v-if="isYoutubeUrlValid(media.Url)" align-center fill-height)
				v-flex
					img(:src="getThumbnailUrlFromYoutubeVideoUrl(media.Url)")
				.badge
					svg-icon.video-icon(name="video-camera"	fill="#fff"	size="18px")
			template(v-else-if="isVideo(media.Name)")
				video(:src="media.Url")
				.badge
					svg-icon.video-icon(name="video-camera"	fill="#fff"	size="18px")
			template(v-else)
				.bg
					img(:src="media.Url")
			.info
				.item-title {{media.Title}}
</template>

<script>
import { validVideoFormats } from '../variables';

export default {
	name: "media-card",
	props: {
		media: {
			type: Object
		}
	},
	methods: {
		isVideo(fileName) {
			let res = false;

			for (let extension of validVideoFormats) {
				res |= fileName.endsWith(extension);
			}

			return res;
		},
		isYoutubeUrlValid(url) {
			let res = false;
			if (url) {
				let regExp = /^.*(youtu.be\/|v\/|u\/\w\/|embed\/|watch\?v=|\&v=|\?v=)([^#\&\?]*).*/;
				let match = url.match(regExp);

				res = match && match[2].length == 11;
			}

			return res;
		},
		getThumbnailUrlFromYoutubeVideoUrl(url) {
			const id = this.getYoutubeIdFromUrl(url);

			return `http://img.youtube.com/vi/${id}/0.jpg`;
		},
		getYoutubeIdFromUrl(url) {
			return this.$youtube.getIdFromUrl(url);
		},
	}
}
</script>

<style scoped>
.card {
	padding: 0px;	
}

video {
	width: 100%;
	height: 100%;
}

.info {
	height: 15% !important;
}

.item-title {
	word-break: break-word
}

.badge {
	background: rgb(112, 148, 247);
	border-radius: 50%;
	display: block;
	position: absolute;
	left: 0px;
	bottom: 0px;
	width: 30px;
	height: 30px;
	text-align: center;
	line-height: 34px;
}

</style>
