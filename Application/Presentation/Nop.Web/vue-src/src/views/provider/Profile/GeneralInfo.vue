<template lang="pug">
	v-flex.page-sidebar
		#chaat.chat(:hidden="$vuetify.breakpoint.width < 1024")
			v-badge(color="white")
				v-avatar.raised(size="86" color="primary" v-ripple)
					svg-icon(name="talk" size="40px" fill="#fff")
				span(slot="badge") 1
		.sidebar__title general info
		.general-ava
			v-badge(right bottom)
				v-btn.ma-0( icon slot="badge" @click="uploadProfileIconDialog = true")
					svg-icon(name="pencil" size="17px" fill="#fff")
				v-avatar(size="160")
					img(:src="profile.Icon")
		.profile__details
			.company STI Network Inc
			.setting
				label(for="bgCheck") Background Check
				checkbox.round(id="bgCheck" color="#e47fa7")
			.setting.mb-3
				label(for="activity") Profile Activity
				switcher(id="activity" color="#e47fa7" @click.native="sw = !sw" :checked="sw")
			//- .people
			//- 	.faces
			//- 		v-avatar(size="45" v-for="i in 6" :key="i")
			//- 			img(:src="`http://i.pravatar.cc/150/random`" alt="")
			//- 	.more +13
			.profile__social
				a(href="https://www.facebook.com/" target="_blank" class="net")
					i.icon.fab.fa-facebook-f
				a(href="https://twitter.com/" target="_blank" class="net")
					i.icon.fab.fa-twitter
				a(href="https://www.instagram.com/" target="_blank" class="net")
					i.icon.fab.fa-instagram
				a(href="https://www.linkedin.com/" target="_blank" class="net")
					i.icon.fab.fa-linkedin-in
		v-dialog(v-model="uploadProfileIconDialog"  width="868" max-width="100%")
			card.py-5(style="position:relative")
				v-btn.close-btn.custom.btn.transparent(@click="uploadProfileIconDialog = false" icon style="position:absolute; right:30px; top:30px")
					v-icon close
				h3.uppercase.text-center ADD PHOTO
				.photo-upload
					input.photo-input(name="addPhoto" id="addPhoto" ref="profileIcon" type="file")
					label(for="addPhoto"  style="cursor:pointer")
						svg-icon(name="attach_photo" fill="#C6D1F1" size="90px")
				v-card-actions
					v-layout(justify-center)
						v-flex(style="flex: 0 0 260px")
							v-btn.btn.custom.primary.full-width.text-capitalize(@click="uploadProfileIcon") Save
</template>
<script>
import { mapState } from "vuex";
import axios from 'axios';
export default {
    props: {
        pageTitle: {
            type: String
		}
	},
	data(){
		return {
			uploadProfileIconDialog:false,
			profileIcon:null,
			sw:true
		}
	},
    computed: {
        ...mapState(["profile"])
    },
	methods:{
		uploadProfileIcon(){
			
            this.profileIcon = this.$refs.profileIcon.files[0];
            let formData = new FormData();
            formData.append("file", this.profileIcon);
            axios
                .post(`${this.$api}/customer/profile/icon`, formData, {
                    headers: {
                        "Content-Type": "multipart/form-data"
                    }
                })
                .then(res=>{					
            		this.$store.dispatch('GET_PROFILE', 'provider')
            		this.uploadProfileIconDialog = false;
				});
		}
	},
    mounted() {
        this.$emit("passTitle", this.pageTitle);
    }
};
</script>
<style lang="scss">

</style>
