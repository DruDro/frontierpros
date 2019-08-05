<template lang="pug">
.step-content
	v-card.pt-3.pb-0.px-4(tag="card"  :width="870" max-width="100%" v-if="profile")
		v-card-title
			b Personal Info
		v-card-text.pb-0
			v-container(pa-0 grid-list-xl)
				v-radio-group.radio-group-full-width(v-model="profile.IsIndividualCompany" @change="setCompanyType" )
					v-layout( wrap)
						v-flex( sm4)
							v-radio(:value="false"  label="Business Company" )
						v-flex( sm4)
							v-radio(:value="true" label="Individual Company")
				v-layout(wrap)
					v-flex(sm4)
						v-text-field(label="Name" placeholder="First Name" v-model="profile.Name")
					v-flex(sm4)
						v-text-field(label="Surname" placeholder="Last Name" v-model="profile.Surname")
					v-flex(sm4)
						v-select(:items="['Male', 'Female']" label="Gender" placeholder="Male" v-model="profile.Gender")
				v-layout(wrap)
					v-flex(sm4)
						v-text-field(type="number" label="Birthday" placeholder="1" v-model="profile.BirthdayDay")
					v-flex(sm4)
						v-select(:items="months" placeholder="January" v-model="profile.BirthdayMonth")
					v-flex(sm4)
						v-select(:items="years" placeholder="1988" v-model="profile.BirthdayYear")
				v-layout(wrap)
					v-flex(sm6)
						v-text-field(label="Country" placeholder="USA" v-model="profile.Country")
					v-flex
						v-text-field(label="City" placeholder="Vermont" v-model="profile.City")
				v-layout(wrap)
					v-flex(sm6)
						v-text-field(label="State (optional)" placeholder="Origon" v-model="profile.State")
					v-flex
						v-text-field(label="Address" placeholder="7421 Washington Ave" v-model="profile.PersonalAddress")
	.text-xs-center(v-else)
		v-progress-circular(:size="50" color="primary" indeterminate)
</template>

<script>
import { mapState } from "vuex";
import moment from "moment";
export default {
    data() {
        return {
        };
    },
    computed: {
        ...mapState(["profile"]),
        years: function() {
            let years = [];
            let currentYear = moment().year();
            for (let i = 0; i < 70; i++) {
                years.push(currentYear - i);
            }
            return years;
        },
        months: function() {
            return moment.months().map((m, i) => {
                return { value: i, text: m };
            });
        }
    },
    methods: {
        setCompanyType() {
            // this.$store.companyType = this.companyType;
			this.$emit("setCompanyType", this.profile.IsIndividualCompany);
		}
	},
	mounted(){
	}
};
</script>

<style lang="scss" >
</style>