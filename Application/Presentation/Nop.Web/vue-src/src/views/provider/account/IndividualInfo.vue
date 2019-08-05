<template lang="pug">
.step-content
	v-card.pt-3.pb-0.px-4(tag="card" :width="870" max-width="100%" v-if="profile")
		v-card-text.pb-0
			v-container(pa-0 grid-list-xl)
				v-layout(wrap)
					v-flex(sm6)
						v-text-field(type="tel" label="Phone Number"  mask="phone" placeholder="(444) 44-4444" v-model="profile.PhoneNumber")
					v-flex
						v-text-field(label="Address" placeholder="Enter Address" v-model="profile.Address")
				v-layout(wrap)
					v-flex
						v-text-field(label="Website" placeholder="example.com" v-model="profile.Website")
					v-flex(sm6)
						v-text-field(label="Year Founded" placeholder="Enter Year" v-model="profile.FoundedYear")
	v-card.pt-3.pb-0.px-4(tag="card"  :width="870" max-width="100%")
		v-card-text.pb-0
			v-container(pa-0 grid-list-xl)
				v-layout
					v-flex
						label.custom-label Your Introduction
						v-textarea.custom--round(outline placeholder="This is one of the first things customers see about your business" v-model="profile.YourIntroduction")
				v-layout
					v-flex
						label.custom-label Why Should Customer Hire You?
						v-textarea.custom--round(outline placeholder="I have an extensive experience as a service Pro. I deal any type of computer repair services." v-model="profile.WhyShouldCustomerHireYou")
</template>

<script>
	import { mapState } from "vuex";
	export default {
		data(){
			return {
				categories:[]
			}
		},
		computed: {
		...mapState(["profile"])
		}
	}
</script>

<style lang="scss" scoped>

</style>