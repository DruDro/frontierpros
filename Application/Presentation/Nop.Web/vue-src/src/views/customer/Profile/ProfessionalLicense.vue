<template lang="pug">
.tab-content
	v-layout(row wrap align-center justify-space-between)
		v-flex(xs12 sm8 xl10 :class="{'pr-0 pb-4': $vuetify.breakpoint.xs, 'pr-4': $vuetify.breakpoint.smAndUp}")
			b Professional Licenses
			p Please provide your license information below for your profile “HenLicense Typery Carpenter”. A FrontierPros team member will check the license information you provide against the states public licensing database. If we are able to locate the license under your name and business, we will display the license information on your profile.
		v-flex(xs12 sm4 xl2)
			button.btn.custom.large.primary.full-width Add New
	.card.my-5.licenses
		a.license(v-for="i in 4" style="color:#7094f7") License Number
			svg-icon.ml-2(name="close" size="13px")
	p
		b Why Show Your Licence?
	p For certain services, customers prefer to hire professionals who are licensed in their profession. In other cases, licenses are required for the job.
	br
	p
		b What kind of license can I upload to display on my profile?
	p FrontierPros allows you to display an occupational or professional license. We do not display business licenses or registrations because those do not showcase occupational credentials.

</template>
<script>
export default {
    props: {
        pageTitle: {
            type: String
		}
	},
    mounted() {
        this.$emit("passTitle", this.pageTitle);
    }
};
</script>

<style lang="scss">
	.licenses{
		.license{
			display: inline-block;
			vertical-align: top;
			margin:10px 40px 10px 0
		}
		@include b(tablet){
			padding: 15px;
		}
	}
</style>

