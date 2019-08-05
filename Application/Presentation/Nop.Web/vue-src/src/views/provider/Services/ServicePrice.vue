<template lang="pug">
.tab-content
	h3 What Should The Customer Know About Your Pricing?
	card.my-4
		h3 Price
		v-container(fluid pa-0 ma-0 grid-list-xl)
			v-layout(pa-0 my-0 wrap)
				v-flex(md6 xs12)
					v-layout(my-0 pa-0 row wrap justify-space-between align-center)
						h4.flex.shrink(style="color:#1d2284") Enter Your Base Price
						v-layout.flex.setting(shrink ma-0 align-center nowrap)
							label.mr-4 Price {{basePriceActive ? 'Active' : 'Inactive'}}
							switcher.green-pink(:checked="serviceItem.FirstTimeDiscountEnabled === false" @click.native="serviceItem.FirstTimeDiscountEnabled = !serviceItem.FirstTimeDiscountEnabled")
					p.hint Your base price for wedding customer includes consultation, music, speakers, microphones, and setup & breakdown.

					label.font-weight-bold.mt-5.d-block Min Job Duration
					v-layout(my-0 align-end justify-space-between row wrap)
						v-flex(py-0 shrink)
							v-layout(align-end)
								v-flex(shrink )
									label.text-no-wrap(style="color:#7094f7") Rec. 1h
								v-flex( )
									v-text-field(hide-details=true label="" height="30" value="1h")
						v-flex(shrink  py-0 my-0)
							v-layout(align-end)
								v-flex(shrink )
									label.text-no-wrap(style="color:#7094f7") Rec. $65
								v-flex()
									v-text-field(hide-details=true label="" height="30" value="$65")
				v-flex(md6 xs12)
					.mb-5(v-if="firstTimeCustomerDiscount")
						v-layout(my-0 pa-0 row wrap justify-space-between align-center)
							h4.flex.shrink(style="color:#1d2284") Discount for First-Time Customer
							v-layout.flex.setting(shrink ma-0 align-center nowrap)
								label.mr-4 Price {{firstTimeCustomerPriceActive ? 'Active' : 'Inactive'}}
								switcher.green-pink(:checked="serviceItem.FirstTimeDiscountEnabled === false" @click.native="serviceItem.FirstTimeDiscountEnabled = !serviceItem.FirstTimeDiscountEnabled")
						p.hint Let customers know about all discounts
						v-layout(my-0 mt-2 align-end justify-start nowrap)
							v-flex(py-0 )
								label First-time customer
							v-flex(sm7 py-0)
								v-text-field(height="30" label="" hide-details=true value="0")
	v-expansion-panel.elevation-10.card(focusable flat v-if="providerQuestions.length")
		v-expansion-panel-content(v-for="question in providerQuestions" :key="question.Id")
			template(v-slot:header)
				.text-center {{question.ProviderHeading}}
			v-card
				v-card-text
					p.text-center(v-if="question.ProviderSubHeading") {{question.ProviderSubHeading}}
					template(v-if="question.Type === 'Select' || question.Type === 'MultiSelect'")
						v-layout(:py-2="question.IsPaidQuestion" v-for="(option,i) in question.Options" :key="option.Id" row wrap align-center justify-center)
							v-flex(xs12 sm2)
								v-checkbox( v-model="option.IsActive" :label="option.ProviderText" hide-details mt-0)
							v-flex(v-if="question.IsPaidQuestion" shrink)
								v-text-field( v-model="option.Price" mask="$nnnnnnn" placeholder="Price" hide-details)
					template(v-if="question.Type !== 'Select' && question.Type !== 'MultiSelect'")
						v-text-field()
	card(v-else)
		v-layout(justify-center)
			v-flex(shrink)
				v-progress-circular(indeterminate color="primary")
	h3.mt-5.mb-4 Recurring Job
	.mb-4
		v-layout(align-center justify-space-between row nowrap)
			v-flex.tabs(mr-2 :shrink="$vuetify.breakpoint.lgAndUp"   :hidden="$vuetify.breakpoint.width < 1600")
				v-layout(row)
					v-flex(v-for="(tab,index) in recurringTabs" :key="index" :xs12="$vuetify.breakpoint.smAndDown" )
						button.btn.custom.full-width(:class="{active: tab.value === RecurringSchedule}" @click="RecurringSchedule = tab.value" ) {{ tab.title }}
			v-flex(mr-2 shrink :hidden="$vuetify.breakpoint.width >= 1600")
				v-select(v-model="RecurringSchedule" :items="recurringTabs" item-text="title" item-value="value")
			v-flex(shrink)
				v-layout.flex.setting(shrink ma-0 align-center nowrap)
					label.mr-4.text-no-wrap Price {{recurringWorkPriceActive ? 'Active' : 'Inactive'}}
					switcher.green-pink(:checked="recurringWorkPriceActive" @click.native="recurringWorkPriceActive = !recurringWorkPriceActive")
	card.pb-5
		v-checkbox(sm  v-model="recurringWorkSchedule" label="Make Recurring Work Schedule")
		h4.flex.shrink(style="color:#1d2284") Recurring Job Discounted Rates
		label.font-weight-bold.mt-5.d-block Discount Rate Type
		v-radio-group.radio-group-full-width(v-model="DiscountRateType")
			v-layout(row wrap )
				v-flex(lg2 md4 sm6 xs12)
					v-radio(value="0" label="% of Base Amount")
				v-flex(lg2 md4 sm6 xs12)
					v-radio(value="1" label="Fixed Amount")
		v-container(grid-list-xl pa-0 fluid)
			v-layout.schedule(row wrap)
				v-flex(lg2 md4 sm6 xs12)
					v-layout(row nowrap align-center)
						v-flex(shrink)
							v-checkbox(v-model="OneMonthDiscountEnabled" hide-details)
						v-flex.text-no-wrap 1 Month
						v-flex.pt-0(style="flex:0 1 130px")
							v-text-field(hide-details label="" height="30"  v-model="OneMonthDiscountValue")
				v-flex(lg2 md4 sm6 xs12)
					v-layout(row nowrap align-center)
						v-flex(shrink)
							v-checkbox(v-model="ThreeMonthDiscountEnabled" hide-details)
						v-flex.text-no-wrap 3 Months
						v-flex.pt-0(style="flex:0 1 130px")
							v-text-field(hide-details label="" height="30"  v-model="ThreeMonthDiscountValue")
				v-flex(lg2 md4 sm6 xs12)
					v-layout(row nowrap align-center)
						v-flex(shrink)
							v-checkbox(v-model="SixMonthDiscountEnabled" hide-details)
						v-flex.text-no-wrap 6 Months
						v-flex.pt-0(style="flex:0 1 130px")
							v-text-field(hide-details label="" height="30"  v-model="SixMonthDiscountValue")
				v-flex(lg2 md4 sm6 xs12)
					v-layout(row nowrap align-center)
						v-flex(shrink)
							v-checkbox(v-model="TwelveMonthDiscountEnabled" hide-details)
						v-flex.text-no-wrap 12 Months
						v-flex.pt-0(style="flex:0 1 130px")
							v-text-field(hide-details label="" height="30"  v-model="TwelveMonthDiscountValue")
</template>
<script>
import { mapState } from "vuex";
export default {
    props: {
        pageTitle: {
            type: String
        }
    },
    data() {
        return {
            recurringWorkPriceActive: true,
            recurringWorkSchedule: true,
            RecurringSchedule: 0,
            DiscountRateType: 1,
            OneMonthDiscountEnabled: true,
            OneMonthDiscountValue: 252,
            ThreeMonthDiscountEnabled: true,
            ThreeMonthDiscountValue: 252,
            SixMonthDiscountEnabled: true,
            SixMonthDiscountValue: 252,
            TwelveMonthDiscountEnabled: true,
            TwelveMonthDiscountValue: 252,
            recurringTabs: [
                {
                    title: "Monthly",
                    value: 3
                },
                {
                    title: "Biweekly",
                    value: 2
                },
                {
                    title: "Weekly",
                    value: 1
                },
                {
                    title: "Everyday",
                    value: 0
                }
            ],
            prepayments: true,
            prepaymentPriceActive: false,
            giftCards: true,
            giftCardsPriceActive: false,
            fees: false,
            firstTimeCustomerDiscount: true,
            firstTimeCustomerPriceActive: false,
            discountedHourlyPrice: false,
            basePriceActive: false,
            addOnServicePriceActive: false,
            addOnProductPriceActive: false,
            weekendPricing: false
        };
	},
	computed:{
		...mapState(['serviceItem', 'providerQuestions']),
	},
    mounted() {
		this.$emit("passTitle", this.pageTitle);
    }
};
</script>

<style lang="scss">
.schedule .v-input--selection-controls {
    margin-top: 0;
}
.v-expansion-panel__container{
	padding-left: 0;
	&:before{
		display: none;
	}
}
</style>
