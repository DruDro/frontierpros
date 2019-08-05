<template lang="pug">
.tab-content( v-resize="onResize")
	v-layout(column)
		p(v-if="isViewMode") {{profile.GalleryDescription}}
		template(v-else)
			v-flex(shrink align-self-end)
				v-btn(flat icon @click="saveGalleryDescription")
					v-icon(color="primary") save
			v-flex
				v-textarea.gallery-description.light-border(outline no-resize background-color="orange" v-model="profile.GalleryDescription" placeholder="Write few words about your gallery")
	.profile-gallery
		v-layout(justify-space-between align-center wrap v-if="getMediaFiles()" style="height: 48px;")
			v-flex(shrink)
				b {{(this.mediaFiles || []).length}} Photos/Videos
			v-layout(justify-end align-center)
				v-flex(shrink v-if="!isViewMode")
					v-btn(flat icon @click="editMediaDialog = true")
						v-icon(color="primary") edit
				v-flex(shrink)
					a.expand-gallery.font-weight-bold(:hidden="vw < 1024" @click="toggleGallery()") {{galleryExpanded ? 'Show Less':'Show All'}}
		v-layout(justify-center v-else)
			v-flex(shrink)
				v-progress-circular(indeterminate color="primary")
		.gallery( v-if="vw >= 1024")
			.gallery__item(v-for="(item,index) in getMediaFilesWithPlaceholders()" @click="onGalleryItemClick(item)")
				media-card(:media="item")
		.slider-container( v-if="vw < 1024")
			slick.gallery.slider(ref="slider" :options="slickOptions" @init="handleInit")
				.gallery__item(v-for="(item,index) in getMediaFiles()" @click="onGalleryItemClick(item)")
					media-card(:media="item")
			.slider__nav

	v-dialog(v-model="addMediaDialog" persistent max-width="700px")
		v-layout(align-stretch fluid py-0)
			card(style="width: 100%;")
				v-form
					v-layout(justify-end)
						v-btn.close-btn.custom.btn.transparent(@click="closePopUp" icon)
							v-icon close
					h4.text-uppercase.text-center {{isMediaFileBeingEdited() ? 'EDIT' : 'ADD'}} PHOTO/VIDEO
					v-layout(justify-center)
						.gallery__item.card.pre-upload-thumbnail( @click="viewMedia(mediaFile)")
							template(v-if="isYoutubeUrlValid(mediaFile.url || mediaFile.externalUrl)")
								v-img(:src="getThumbnailUrlFromYoutubeVideoUrl(mediaFile.url || mediaFile.externalUrl)")
								.badge
									svg-icon.video-icon(name="video-camera"	fill="#fff"	size="18px")
							v-img(v-else-if="!mediaFile.name || !isVideo(mediaFile.name)" :src="mediaFile.url || mediaFile.externalUrl || imagePlaceHolder")
							template(v-else)
								video(:src="mediaFile.url" style="width: 100%; height: 100%;")
								.badge
									svg-icon.video-icon(name="video-camera"	fill="#fff"	size="18px")
					template(v-if="!isMediaFileBeingEdited()")
						v-layout(row wrap align-end)
							v-flex(xs12 sm8)
								v-text-field.mt-4.space-label(disabled label="File name" type="text" placeholder="Choose File" :value="mediaFile.name" :error-messages="mediaFileErrors" @input="$v.mediaFile.name.$touch()" @blur="$v.mediaFile.name.$touch()") 
							v-flex(xs12 sm4 choose-file-btn)
								label.btn.custom.primary.full-width Choose File
									input.hidden(type="file" @change="onFileSelect")
						v-text-field.mt-4.space-label(label="Link" v-model="mediaFile.externalUrl" type="text" placeholder="Enter Link for file" :error-messages="externalUrlErrors" @input="$v.mediaFile.externalUrl.$touch()" @blur="$v.mediaFile.externalUrl.$touch()")
					v-flex(v-else xs12)
						v-text-field.mt-4.space-label(disabled label="Selected file" type="text" :value="mediaFile.name") 
					v-text-field.mt-4.space-label(label="Title" v-model="mediaFile.title" type="text" placeholder="Enter Title" :error-messages="titleErrors" @input="$v.mediaFile.title.$touch()" @blur="$v.mediaFile.title.$touch()")
					v-textarea.mt-4.space-label.light-border(label="Description" outline no-resize v-model="mediaFile.description" placeholder="Enter Your Description")
					v-layout.mt-2.pb-3(row justify-center)
						v-btn.mr-5.btn.primary.custom.large(@click="saveMediaFile") Save
						v-btn.ml-5.btn.error.custom.large(@click="closePopUp") Cancel

	v-dialog(v-model="viewMediaCardDialog" max-width="700px")
		v-layout(align-stretch fluid py-0)
			card(style="width: 100%;")
				v-form
					v-layout(justify-end)
						v-btn.close-btn.custom.btn.transparent(@click="closePopUp" icon)
							v-icon close
					h4.text-uppercase.text-center {{mediaFile.title}}
					v-layout(justify-center)
						.gallery__item.card.pre-upload-thumbnail(@click="viewMedia(mediaFile)")
							template(v-if="isYoutubeUrlValid(mediaFile.url)")
								v-img(:src="getThumbnailUrlFromYoutubeVideoUrl(mediaFile.url)")
								.badge
									svg-icon.video-icon(name="video-camera"	fill="#fff"	size="18px")
							template(v-else-if="isVideo(mediaFile.name)")
								video( :src="mediaFile.url" style="width: 100%; height: 100%;")
								.badge
									svg-icon.video-icon(name="video-camera"	fill="#fff"	size="18px")
							v-img(v-else :src="mediaFile.url || mediaFile.externalUrl")
					template(v-if="mediaFile.description")
						p {{mediaFile.description}}

	v-dialog(v-model="viewMediaDialog" max-width="80%" content-class="viewMediaDialog")
		v-card.pa-0(style="position:relative" )
			v-btn.close-btn.custom.btn.transparent(@click="hideViewMediaDialog" icon style="position:absolute; right:30px; top:30px;")
				v-icon close
			v-card-text.pa-0(v-if="mediaFile.url || mediaFile.externalUrl")
				youtube(v-if="isYoutubeUrlValid(mediaFile.url || mediaFile.externalUrl)" :video-id="getYoutubeIdFromUrl(mediaFile.url || mediaFile.externalUrl)" ref="youtube" style="display:block; height: -webkit-fill-available;")
				video(v-else-if="isVideo(mediaFile.name)" controls style="display:block; width:100%")
					source(:src="mediaFile.url" )
				img(v-else :src="mediaFile.url || mediaFile.externalUrl" style="display:block;width:100%")

	v-dialog(v-model="editMediaDialog"  width="868" max-width="100%")
		card.py-5(style="position:relative")
			v-btn.close-btn.custom.btn.transparent(@click="hideEditMediaDialog" icon style="position:absolute; right:30px; top:30px")
				v-icon close
			h3.uppercase.text-center EDIT PHOTO & VIDEO
			p.text-center.my-4 You can change the order of photos and videos, delete and add a new one
			ul.media-list.mt-4.mb-5
				v-layout(tag="li" v-for="(item,i) in getMediaFiles()" :key="item.Id" row nowrap align-center style="cursor:pointer")
					v-flex.media__item-preview(:mr-2="$vuetify.breakpoint.smAndDown" :mr-5="$vuetify.breakpoint.mdAndUp" @click="viewMedia(item)" style="overflow:hidden; display:flex;")
						template(v-if="isYoutubeUrlValid(item.Url)")
							v-img(:src="getThumbnailUrlFromYoutubeVideoUrl(item.Url)" style="width: 100%;")
							.badge
								svg-icon.video-icon(name="video-camera"	fill="#fff"	size="18px")
						template(v-else-if="isVideo(item.Name)")
							video( :src="item.Url" style="width: 100%; height: 100%;")
							.badge
								svg-icon.video-icon(name="video-camera"	fill="#fff"	size="18px")
						v-img(v-else :src="item.Url || item.ExternalUrl")
					v-flex.media__item-title {{item.Name}}
					v-flex.media__item-delete(shrink)
						v-btn(icon flat @click="removeMediaFile(item.Id)")
							svg-icon(name="bin" fill="#C6D1F1" size="16px")
			v-card-actions
				v-container(pa-0 fluid grid-list-xl)
					v-layout(justify-center row wrap)
						v-flex( style="flex: 0 0 260px")
							v-btn.btn.custom.transparent.full-width.text-capitalize(flat @click="addMediaDialog = true") Add New
						v-flex( style="flex: 0 0 260px")
							v-btn.btn.custom.primary.full-width.text-capitalize(flat @click="updateMedia") Save

	v-snackbar(v-model="showMessage")
		| {{message}}
		v-btn(flat @click="showMessage = false")
</template>
<script>
import { mapMutations, mapState } from 'vuex';
import { helpers, url, required, requiredUnless, maxLength } from "vuelidate/lib/validators";
import _ from "lodash";

import "@/components/partials/Slider.scss";

import { APIServices } from "../../../api/api-services";

import Slick from "vue-slick";
import mediaCard from '../../../components/media-card.vue';

import { validImageFormats, validVideoFormats, maxImageSize, maxVideoSize, mediaFileHeaders } from '../../../variables';

const mediaCardPlaceHolder = {
	Url: "/images/img-placeholder.png",
	Name: "placeholder",
	Title: "placeholder",
	placeholder: true
};

const numberOfGalleryItemsPerRowDependingOnScreenSize = [ // step is 280px after 1270
	[ 1024, 2 ],
	[ 1270, 3 ],
	[ 1550, 4 ],
	[ 1830, 5 ],
	[ 2110, 6 ],
	[ 2390, 7 ],
	[ 2670, 8 ],
	[ 2950, 9 ],
	[ 3230, 10 ],
	[ 100000, 0 ] // 10 is the limit
];

export default {
	components: {
		'slick':Slick,
		'media-card': mediaCard
	},
	props: {
		pageTitle: {
			type: String
		}
	},
	data() {
		return {
			vw: 0,
			defaultNumberOfRows: 2,
			slickOptions: {
				dots: true,
				infinite: false,
				speed: 300,
				prevArrow:
					'<span class="prev"><i class="icon fas fa-chevron-left"></i></span>',
				nextArrow:
					'<span class="next"><i class="icon fas fa-chevron-right"></i></span>',
				appendArrows: ".slider__nav",
				appendDots: ".slider__nav",
				slidesToShow: 3,
				slidesToScroll: 3,
				responsive: [
					{
						breakpoint: 940,
						settings: {
							slidesToShow: 2,
							slidesToScroll: 2
						}
					},
					{
						breakpoint: 640,
						settings: {
							slidesToShow: 1,
							slidesToScroll: 1
						}
					},
				]
			},
			showMessage: false,
			galleryExpanded: false,
			addMediaDialog: false,
			editMediaDialog: false,
			viewMediaDialog: false,
			viewMediaCardDialog: false,
			mediaFile: {
				name: "",
				externalUrl: ""
			},
			imagePlaceHolder: "/images/img-placeholder.png",
			selectedFile: {},
			message:""
		};
	},
	computed: {
		...mapState({
			mediaFiles: state => state.profile.MediaFiles,
			isViewMode: state => state.isViewMode
		}),
		profile() {
			return _.clone(this.$store.getters["PROFILE"]);
		},
		titleErrors() {
			const errors = [];
			if (!this.$v.mediaFile.title.$dirty) return errors;
			!this.$v.mediaFile.title.required && errors.push('Title is required');
			!this.$v.mediaFile.title.maxLength && errors.push('Title must be at most 40 characters long');
			return errors;
		},
		mediaFileErrors() {
			const errors = [];
			if (!this.$v.mediaFile.name.$dirty) return errors;
			!this.$v.mediaFile.name.required && errors.push('Select Photo/video file or enter link');
			!this.$v.mediaFile.name.validFileFormat && errors.push('Allowed file formats: jpg, png, mp4, webm');
			!this.$v.mediaFile.name.validFileSize && errors.push('Allowed file size: img < 10mb, video < 100mb');
			return errors;
		},
		externalUrlErrors() {
			const errors = [];
			if (!this.$v.mediaFile.title.$dirty) return errors;
			!this.$v.mediaFile.externalUrl.required && errors.push('Select Photo/video file or enter link');
			!this.$v.mediaFile.externalUrl.url && errors.push('Enter valid url');
			return errors;
		}
	},
	validations: {
		mediaFile: {
			name: {
				required: requiredUnless(function(value) {
					return this.mediaFile.externalUrl;
				}), 
				validFileFormat: function(value) { return this.isMediaFileBeingEdited() || !helpers.req(value) || this.isValidFileFormat(value) },
				validFileSize: function(value) { return this.isMediaFileBeingEdited() || !helpers.req(value) || this.isValidFileSize(value) }
			},
			title: { required, maxLength: maxLength(40) },
			externalUrl: { 
				required: requiredUnless(function(value) {
					return this.mediaFile.name;
				}),
				url
			}
		}
	},
	methods: {
		...mapMutations({
			commitAdd: "ADD_MEDIA_FILE",
			commitUpdate: "UPDATE_MEDIA_FILE",
			commitRemove: "REMOVE_MEDIA_FILE",
			commitSetGalleryDescription: "SET_GALLERY_DESCRIPTION"
		}),
		getMediaFiles() {
			return (this.mediaFiles || []);
		},
		getMediaFilesWithPlaceholders() {
			let numberOfItemsPerRow = this.getNumberOfItemsPerRow();
			let mediaFiles = _.clone(this.getMediaFiles());
			if (!this.galleryExpanded) {
				const elemntLimit = numberOfItemsPerRow * this.defaultNumberOfRows > mediaFiles.length ? 
					mediaFiles.length : numberOfItemsPerRow * this.defaultNumberOfRows;
				mediaFiles.length = elemntLimit;
			}
			let numberOfItemstoBeAdded = (numberOfItemsPerRow - mediaFiles.length % numberOfItemsPerRow) % numberOfItemsPerRow;

			for (let i = 0; i < numberOfItemstoBeAdded; ++i) {
				mediaFiles.push(mediaCardPlaceHolder);
			}

			return mediaFiles;
		},
		getNumberOfItemsPerRow() {
			let res = 0;

			for (let i = 0; i < numberOfGalleryItemsPerRowDependingOnScreenSize.length - 1; ++i) {
				if (this.vw >= numberOfGalleryItemsPerRowDependingOnScreenSize[i][0] && 
					this.vw < numberOfGalleryItemsPerRowDependingOnScreenSize[i + 1][0]) {
					res = numberOfGalleryItemsPerRowDependingOnScreenSize[i][1];
					break;
				}
			}

			return res;
		},
		onFileSelect(e) {
			this.$v.mediaFile.name.$touch();
			this.mediaFile.name = e.target.files[0].name; 
			this.selectedFile = e.target.files[0];
			this.mediaFile.url = !this.$v.mediaFile.name.$invalid ? this.mediaFile.url = URL.createObjectURL(e.target.files[0]) : "";
		},
		onGalleryItemClick(item) {
			if (item.placeholder) {
				if (!this.isViewMode) {
					this.addMediaDialog = true;
				}

				return;
			}
			
			this.mediaFile = this.itemFieldsToLowerCase(item);
			if (this.isViewMode) {
				this.viewMediaCardDialog = true;
			} else {
				this.addMediaDialog = true;
			}
		},
		viewMedia(item) {
			item = this.itemFieldsToLowerCase(item);
			if (item.url || item.externalUrl) {
				this.mediaFile = item;
				this.viewMediaDialog = true;
			}
		},
		hideViewMediaDialog() {
			if (this.$refs.youtube)
				this.$refs.youtube.player.stopVideo();
			this.viewMediaDialog = false;
		},
		updateMedia(item) {
			this.editMediaDialog = false
		},
		saveMediaFile() {
			this.$v.$touch();
			if (!this.$v.$invalid) {
				if (!this.isMediaFileBeingEdited()) {
					let formData = new FormData();
					formData.append("title", this.mediaFile.title ? this.mediaFile.title : "");
					formData.append("externalUrl", this.mediaFile.externalUrl ? this.mediaFile.externalUrl : "");
					formData.append("description", this.mediaFile.description ? this.mediaFile.description : "");
					formData.append("file", this.selectedFile);

					APIServices
						.users
						.uploadMediaFile(formData)
						.then(res => {
							if (res.data.success) {
								this.commitAdd({ mediaFile: res.data.mediaFile });
								this.closePopUp();
							} else {
								console.log(res.data.errorMessage);
							}
						}).catch(err => console.log(err.response));
				} else {
					APIServices
						.users
						.editMediaFile(this.mediaFile.id, this.mediaFile)
						.then(res => {
							if (res.data.success) {
								this.commitUpdate({ mediaFile: res.data.mediaFile });
								this.closePopUp();
							} else {
								console.log(res.data.errorMessage);
							}
						}).catch(err => console.log(err.response));
				}
			}
		},
		removeMediaFile(id) {
			if(confirm("Do you really want to delete this file?")) {
				APIServices
					.users
					.deleteMediaFile(id)
					.then(res => {
						if (res.data.success) {
							this.commitRemove({ mediaFileId: id });
						} else {
							console.log(res.data.errorMessage);
						}
					}).catch(err => console.log(err));
			}
		},
		saveGalleryDescription() {
			APIServices
				.providers
				.setIndividualInfo(this.profile)
				.then(res => {
					if (res.data.success) {
						this.commitSetGalleryDescription({ galleryDescription : this.profile.GalleryDescription });
					}
				});
		},
		closePopUp() {
			this.viewMediaCardDialog = false;
			this.addMediaDialog = false;
			this.$v.$reset();
			this.mediaFile = { name: "", externalUrl: "" };
			this.selectedFile = {};
		},
		hideEditMediaDialog() {
			this.editMediaDialog = false;
		},
		handleInit(event, slick) {
			slick.goTo(slick.currentSlide);
		},
		toggleGallery: function() {
			this.galleryExpanded = !this.galleryExpanded;
		},
		onResize() {
			this.vw = window.innerWidth;
		},
		isValidFileFormat(mediaFileName) {
			return mediaFileName && 
				(this.isImage(mediaFileName) || this.isVideo(mediaFileName));
		},
		isValidFileSize(fileName) {
			let res = false;

			if (fileName) {
				res |= this.isImage(fileName) && this.selectedFile.size < maxImageSize;
				res |= this.isVideo(fileName) && this.selectedFile.size < maxVideoSize;
			}

			return res;
		},
		isImage(fileName) {
			return this.isEndsWithAny(fileName, validImageFormats);
		},
		isVideo(fileName) {
			return this.isEndsWithAny(fileName, validVideoFormats);
		},
		isEndsWithAny(name, any) {
			let res = false

			for (let value of any) {
				res |= name.endsWith(value);
			}

			return res;
		},
		itemFieldsToLowerCase(item) {
			return { 
				url: item.Url || item.url, 
				name: item.Name || item.name, 
				description: item.Description || item.description, 
				id: item.Id || item.id, 
				title: item.Title || item.title,
				externalUrl: item.ExternalUrl || item.externalUrl
			};
		},
		isMediaFileBeingEdited() {
			return this.mediaFile.id;
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
	},
	mounted() {
		this.$emit("passTitle", this.pageTitle);
	},
};
</script>

<style local lang="scss">

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

.profile-gallery {
	margin: 30px 0 0;
	.expand-gallery {
		position: relative;

		&:after {
			content: "";
			position: relative;
			width: 12px;
			height: 12px;
			font-size: 18px;
			vertical-align: middle;
			color: currentColor;
			border-style: solid;
			border-width: 1px 1px 0 0;
			background-color: currentColor currentColor transparent transparent;
			display: inline-block;
			transform: rotate(135deg);
			top: -4px;
			margin-left: 5px;
		}
	}
}
.gallery {
	display: flex;
	flex-flow: row wrap;
	margin: 20px -10px 0;
	justify-content: space-between;

	@include b(1599) {
		justify-content: space-evenly;
	}

	&__item {
		margin: 15px 10px;
		width: 260px;
		box-shadow: 0px 15px 30px 0px rgba(10, 15, 67, 0.11);
		border-radius: 20px;
		overflow: hidden;

		.card {
			margin: 0 auto;
			position: relative;
			width: 260px;
			height: 250px;
			transition: all 0.15s ease-in-out;

			.bg {
				position: absolute;
				width: 100%;
				height: 100%;
				top: 0;
				left: 0;

				img {
					position: absolute;
					left: 50%;
					top: 50%;
					min-width: 100%;
					min-height: 100%;
					transform: translate(-50%, -50%);
					border-radius: 20px;
				}
				.video-icon {
					position: absolute;
					left: 10px;
					bottom: 10px;
					width: 30px;
					height: 30px;
					border-radius: 50%;
					background: #7094f7;
					text-align: center;
					display: block;
					svg {
						position: absolute;
						top: 50%;
						left: 50%;
						transform: translate(-50%, -50%);
					}
				}
			}

			.info {
				opacity: 0;
				width: 100%;
				height: 100%;
				top: 0;
				left: 0;
				position: absolute;
				background: #7094f7 !important;
				color: #fff;
				transition: all 0.15s ease-in-out;
				text-align: center;
				padding: 10px;

				.item-title {
					text-overflow: ellipsis;
					white-space: nowrap;
					overflow: hidden;
					font-size: 14px;
					font-weight: bold;
					margin: 0px 10px 0px 10px;
				}

				.delete {
					position: absolute;
					right: 0px;
					top: 0px;
				}
			}

			&:hover {
				.info {
					opacity: 1;
				}
			}
		}
	}

	&.slider {
		display: block;

		.slick-slide {
			margin: 0 20px;
		}

		.gallery__item {
			box-shadow: none;
			overflow: visible;
			padding: 0 0 30px 0;
			margin: 0;

			.card {
				box-shadow: 0px 15px 30px 0px rgba(10, 15, 67, 0.11);
			}
		}
	}
}

.gallery__item {
	position: relative !important;
}

.photo-upload {
	margin: 50px auto 40px;

	input {
		display: none;
	}

	label {
		display: block;
		margin: 0 auto;
		width: 260px;
		height: 260px;
		border-radius: 20px;
		background-color: rgb(220, 228, 253);
		display: flex;
		flex-flow: row nowrap;
		align-items: center;
		justify-content: center;

		.icon {
			width: 90px;
			height: 90px;

			svg {
				width: 100%;
				height: 100%;
				fill: #c6d1f1;
			}
		}
	}
}

.media-list {
	li {
		padding: 0;
		margin: 10px 0;
		&:before {
			display: none;
		}
	}

	.media__item {
		&-preview {
			width: 50px;
			height: 50px;
			flex: 0 0 50px;
			position: relative;

			.badge {
				left: -5px;
				bottom: -5px;
			}
		}

		&-title {
			font-size: 18px;
			font-weight: bold;
			white-space: nowrap;
			display: block;
			overflow: hidden;
			text-overflow: ellipsis;
			max-width: 100%;
			padding: 0 40px ;
		}

		&-size {
			flex-basis: 0 0 100px;
			padding: 5px;
		}

		&-delete {
			flex-basis: 0 0 50px;
			padding: 5px;
		}
	}
}

.pre-upload-thumbnail {
	height: 150px;
	width: 150px;
	padding: 0px;
	
	.v-image {
		height: 150px;
	}
}

.choose-file-btn {
	padding-bottom: 18px;
	padding-left: 20px;
}

.space-label .v-input__control .v-input__slot .v-text-field__slot label {
	top: -5px;
}

.light-border {
	padding-top: 25px !important;

	.v-input__control {
		.v-input__slot:not(:hover) {
			border: 1px solid rgba(0, 0, 0, 0.54) !important;
		}

		.v-input__slot {
			border: 1px solid !important;
		}

		.v-input__slot {
			padding: 0px !important;

			.v-text-field__slot {
				label {
					top: -25px;
				}

				textarea {
					margin-top: 0px;
					margin-left: 12px;
				}
			} 
		}
	}
}

.gallery-description .v-input__control .v-input__slot {
	background-color: white !important;
}

.large {
	width: 200px;
}

.viewMediaDialog {
	max-height: 81% !important;
	width: auto;
}

</style>
