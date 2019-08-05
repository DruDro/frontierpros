<template lang="pug">
.tab-content
	card
		v-form
			v-container
				v-layout(row wrap)
					v-flex(xs12 sm6)
						v-text-field(label="Company Name")
					v-flex(xs12 sm6)
						v-text-field(label="Address")
					v-flex(xs12 sm6)
						v-text-field(label="Service")
					v-flex(xs12 sm6)
						v-text-field(label="Website")
					v-flex(xs12 lg6)
						v-text-field(label="Phone Number")
					v-flex(xs12 sm6 lg3)
						v-text-field(label="Year Founded")
					v-flex(xs12 sm6 lg3)
						v-text-field(label="Number of Employees")
	card
		v-form
			v-container
				label Your Introduction
				v-textarea.custom--round(outline)
				label Why Should Customer Hire You?
				v-textarea.custom--round(outline)

</template>
<script>
export default {
	props:{
		pageTitle:{
			type:String
		}
	},
	mounted(){
		this.$emit('passTitle', this.pageTitle)
	}
}
</script>

<style lang="scss">
</style>
