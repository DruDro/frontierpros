<template lang="pug">
.tab-content
	card
		v-form
			v-container
				v-layout(row wrap)
					v-flex(xs12 sm6)
						v-text-field(label="Company Name" v-model="businesssSummaryProfile.CompanyName" @change="modelChanged")
					v-flex(xs12 sm6)
						v-text-field(label="Address", v-model="businesssSummaryProfile.Address" @change="modelChanged")
					v-flex(xs12 sm6)
						v-text-field(label="Phone Number" v-model="businesssSummaryProfile.PhoneNumber" @change="modelChanged")
					v-flex(xs12 sm6)
						v-text-field(label="Website" v-model="businesssSummaryProfile.Website" @change="modelChanged")
					v-flex(xs12 sm6)
						v-text-field(label="Year Founded" v-model="businesssSummaryProfile.FoundedYear" @change="modelChanged")
					v-flex(xs12 sm6)
						v-text-field(label="Number of Employees" v-model="businesssSummaryProfile.NumberOfEmployees" @change="modelChanged")
	card
		v-form(@change="modelChanged")
			v-container
				label Your Introduction
				v-textarea.custom--round(outline v-model="businesssSummaryProfile.YourIntroduction" @change="modelChanged")
				label Why Should Customer Hire You?
				v-textarea.custom--round(outline v-model="businesssSummaryProfile.WhyShouldCustomerHireYou" @change="modelChanged")

</template>
<script>
import _ from "lodash";
import { mapState } from "vuex";

export default {
	props: {
		pageTitle: {
			type: String
		}
	},
	computed: {
		businesssSummaryProfile() {
			return _.clone(this.$store.getters["PROFILE"]);
		}
	},
	mounted() {
		this.$emit("business-summary-profile-change", {});
		this.$emit('passTitle', this.pageTitle)
	},
	methods: {
		modelChanged() {
			this.$emit("business-summary-profile-change", this.businesssSummaryProfile);
		}
	}
}
</script>

<style lang="scss">
</style>
