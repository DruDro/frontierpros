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
					v-btn(icon slot="badge")
						svg-icon(name="pencil" size="17px" fill="#fff")
					v-avatar(size="160")
						img(src="~@/assets/img/ava.png")
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
</template>
<script>
export default {
    props: {
        pageTitle: {
            type: String
		}
	},
	data(){
		return {
			sw:true
		}
	},
    mounted() {
        this.$emit("passTitle", this.pageTitle);
    }
};
</script>