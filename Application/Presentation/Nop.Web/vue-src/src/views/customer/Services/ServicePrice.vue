<template lang="pug">
.tab-content
	h3 What Should The Customer Know About Your Pricing?
	v-container(fluid pa-0 ma-0 grid-list-xl)
		v-layout(row wrap mt-4)
			v-layout.flex(shrink ma-0 align-center)
				checkbox.sm.shrink.flex.mr-2.pa-0(id="prepayments" @click.native="prepayments = !prepayments" :checked="prepayments")
				label.font-weight-bold.shrink(for="prepayments") Prepayments
			v-layout.flex(shrink ma-0 align-center)
				checkbox.sm.shrink.flex.mr-2.pa-0(id="giftCards" @click.native="giftCards = !giftCards" :checked="giftCards")
				label.font-weight-bold.shrink(for="giftCards") Accepts Gift Cards
			v-layout.flex(shrink ma-0 align-center)
				checkbox.sm.shrink.flex.mr-2.pa-0(id="fees" @click.native="fees = !fees" :checked="fees")
				label.font-weight-bold.shrink(for="fees") Fees
			v-layout.flex(shrink ma-0 align-center)
				checkbox.sm.shrink.flex.mr-2.pa-0(id="firstTimeCustomerDiscount" @click.native="firstTimeCustomerDiscount = !firstTimeCustomerDiscount" :checked="firstTimeCustomerDiscount")
				label.font-weight-bold.shrink(for="firstTimeCustomerDiscount") First Time Customer Discount
			v-layout.flex(shrink ma-0 align-center)
				checkbox.sm.shrink.flex.mr-2.pa-0(id="discountedHourlyPrice" @click.native="discountedHourlyPrice = !discountedHourlyPrice" :checked="discountedHourlyPrice")
				label.font-weight-bold.shrink(for="discountedHourlyPrice") Discounted Hourly Price
	card.mt-4
		label.font-weight-bold Payment Details
		v-textarea.custom--round(rows="8" outline value="Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. \nExcepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum. Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat ")
	card
		h3 Price
		v-container(fluid pa-0 ma-0 grid-list-xl)
			v-layout(pa-0 my-0 wrap)
				v-flex(md6 xs12)
					v-layout(my-0 pa-0 row wrap justify-space-between align-center)
						h4.flex.shrink(style="color:#1d2284") Enter Your Base Price
						v-layout.flex.setting(shrink ma-0 align-center nowrap)
							label.mr-4 Price {{basePriceActive ? 'Active' : 'Inactive'}}
							switcher.green-pink(:checked="basePriceActive" @click.native="basePriceActive = !basePriceActive")
					p.hint Your base price for wedding customer includes consultation, music, speakers, microphones, and setup & breakdown.
					label.font-weight-bold.mt-4.d-block {{discountedHourlyPrice ? 'Discounted':'Flat'}} Hourly Price
					v-layout(shrink ma-0 mt-2 align-center)
						checkbox.sm.shrink.flex.mr-2.pa-0(id="weekendPricing" :checked="weekendPricing" @click.native="weekendPricing = !weekendPricing")
						label.font-weight-light.shrink(for="weekendPricing") Enter Different Weekend Pricing
					.mt-4(:class="{'grey--text text--lighten-1' :!weekendPricing}")
						label.font-weight-bold.d-block Choose Weekend Schedule
						v-layout(my-0 align-center wrap justify-start)
							v-layout.flex( ma-0 nowrap align-center )
								radiobox.sm.shrink.flex.mr-2.pa-0(id="SatSun" name="weekend" :disabled="!weekendPricing")
								label.font-weight-light.shrink(for="SatSun") SAT-SUN
							v-layout.flex(sm7  ma-0 nowrap align-center )
								radiobox.sm.shrink.flex.mr-2.pa-0(id="FriSat" name="weekend" :disabled="!weekendPricing")
								label.font-weight-light.shrink(for="FriSat") FRI-SAT					
					v-layout(my-0 align-end  justify-start nowrap)
						v-flex(py-0 )
							label.font-weight-bold %&nbsp;of&nbsp;Deposits Required
						v-flex(sm7 py-0)
							v-text-field(height="30" label="" hide-details=true value="0 %")
					label.font-weight-bold.mt-5.d-block JOB
					v-layout(my-0 align-end)
						v-flex(py-0)
							label 1h
						v-layout.flex(sm10 align-end py-0 my-0)
							v-flex(shrink py-0)
								label.text-no-wrap(style="color:#7094f7") Rec. $40
							v-flex( py-0)
								v-text-field(hide-details=true label="" height="30" value="$40")
					.mt-5(v-if="prepayments")
						v-layout(my-0 pa-0 row wrap justify-space-between align-center)
							h4.flex.shrink(style="color:#1d2284") Prepayment
							v-layout.flex.setting(shrink ma-0 align-center nowrap)
								label.mr-4 Price {{prepaymentPriceActive ? 'Active' : 'Inactive'}}
								switcher.green-pink(:checked="prepaymentPriceActive" @click.native="prepaymentPriceActive = !prepaymentPriceActive")
						p.hint The client may send part of the cost of the service with prepayment.
						v-layout(my-0 mt-2 align-end justify-start nowrap)
							v-flex(py-0 )
								label Prepayment&nbsp;Cost
							v-flex(sm7 py-0)
								v-text-field(height="30" label="" hide-details=true value="$0")
				v-flex(md6 xs12)
					.mb-5(v-if="giftCards")
						v-layout(my-0 pa-0 row wrap justify-space-between align-center)
							h4.flex.shrink(style="color:#1d2284") Accepts Gift Cards
							v-layout.flex.setting(shrink ma-0 align-center nowrap)
								label.mr-4 Price {{giftCardsPriceActive ? 'Active' : 'Inactive'}}
								switcher.green-pink(:checked="giftCardsPriceActive" @click.native="giftCardsPriceActive = !giftCardsPriceActive")
						p.hint A customer can send a part of the service cost with a gift card.
						v-layout(my-0 mt-2 align-end justify-start nowrap)
							v-flex(py-0 )
								label %&nbsp;payment by&nbsp;gift&nbsp;card
							v-flex(sm7 py-0)
								v-text-field(height="30" label="" hide-details=true value="0 %")
					.mb-5(v-if="firstTimeCustomerDiscount")
						v-layout(my-0 pa-0 row wrap justify-space-between align-center)
							h4.flex.shrink(style="color:#1d2284") Discount for First-Time Customer
							v-layout.flex.setting(shrink ma-0 align-center nowrap)
								label.mr-4 Price {{firstTimeCustomerPriceActive ? 'Active' : 'Inactive'}}
								switcher.green-pink(:checked="firstTimeCustomerPriceActive" @click.native="firstTimeCustomerPriceActive = !firstTimeCustomerPriceActive")
						p.hint Let customers know about all discounts
						v-layout(my-0 mt-2 align-end justify-start nowrap)
							v-flex(py-0 )
								label First-time customer
							v-flex(sm7 py-0)
								v-text-field(height="30" label="" hide-details=true value="0")
					h4.mt-3.mb-1(style="color:#1d2284") Enter Add-On Price
					p.hint Your base price for wedding customer includes consultation, music, speakers, microphones, and setup & breakdown.
					v-layout(my-0 mt-2 pa-0 row wrap justify-space-between align-center)
						h4.flex.shrink() Add-On Service
						v-layout.flex.setting(shrink ma-0 align-center nowrap)
							label.mr-4 Price {{addOnServicePriceActive ? 'Active' : 'Inactive'}}
							switcher.green-pink(:checked="addOnServicePriceActive" @click.native="addOnServicePriceActive = !addOnServicePriceActive")
					v-layout(my-0 align-end  justify-start nowrap)
						v-flex(py-0 )
							label.font-weight-bold %&nbsp;of&nbsp;Deposits Required
						v-flex(sm7 py-0)
							v-text-field(height="30" label="" hide-details=true value="100 %")
					v-layout(my-0 align-end mt-3 justify-start :wrap="$vuetify.breakpoint.xs" )
						v-flex(py-0 grow)
							v-text-field(height="30" label="" hide-details=true value="New Add-Ons Service" read-only)
						v-flex(sm7 py-0 xs12 :mt-2="$vuetify.breakpoint.xs")
							v-btn.btn.transparent.custom.capitalize(:class="{'full-width':$vuetify.breakpoint.xs}" flat color="primary")
								svg-icon.mr-2(size="20px"  name="plus")
								| Add New
					v-layout(my-0 mt-4 pa-0 row wrap justify-space-between align-center)
						h4.flex.shrink() Add-On Product
						v-layout.flex.setting(shrink ma-0 align-center nowrap)
							label.mr-4 Price {{addOnProductPriceActive ? 'Active' : 'Inactive'}}
							switcher.green-pink(:checked="addOnProductPriceActive" @click.native="addOnProductPriceActive = !addOnProductPriceActive")
					v-layout(my-0 align-end  justify-start nowrap)
						v-flex(py-0 )
							label.font-weight-bold %&nbsp;of&nbsp;Deposits Required
						v-flex(sm7 py-0)
							v-text-field(height="30" label="" hide-details=true value="100 %")
					v-layout(my-0 align-end mt-3 :wrap="$vuetify.breakpoint.xs" justify-start )
						v-flex(py-0 grow)
							v-text-field(height="30" label="" hide-details=true value="New Add-Ons Product" read-only)
						v-flex(sm7 py-0 xs12 :mt-2="$vuetify.breakpoint.xs")
							v-btn.btn.transparent.custom.capitalize(:class="{'full-width':$vuetify.breakpoint.xs}" flat color="primary")
								svg-icon.mr-2( size="20px"  name="plus")
								| Add New
					

</template>
<script>
export default {
	props:{
		pageTitle:{
			type:String
		}
	},
	data(){
		return{
			prepayments: true,
			prepaymentPriceActive: false,
			giftCards: true,
			giftCardsPriceActive: false,
			fees: false,
			firstTimeCustomerDiscount: true,
			firstTimeCustomerPriceActive: false,
			discountedHourlyPrice:false,
			basePriceActive:false,
			addOnServicePriceActive:false,
			addOnProductPriceActive:false,
			weekendPricing:false
		}
	},
	mounted(){
		this.$emit('passTitle', this.pageTitle)
	}
}
</script>

<style lang="scss">
</style>
