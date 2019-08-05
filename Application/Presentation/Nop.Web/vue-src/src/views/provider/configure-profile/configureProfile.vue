<template lang="pug">
	v-layout(align-stretch fluid py-0 )
		v-dialog(v-model="confirmPhonePopup" persistent max-width="700px")
			card.py-5
				v-form(v-model="valid" lazy-validation ref="phoneVerificationForm")
					h3.text-uppercase.text-center.mt-4 Verify Your Information
					p.text-center.mt-4 Thanks for Signing Up!
					v-text-field.mt-4(label="Phone" type="text" placeholder="Enter Your Phone Number (+123 ** ** **)" :rules="phoneRules" required v-model="phoneNumber")
					template(v-if="codeSent")
						v-text-field.mt-4(label="Mobile Verification Code" type="text" placeholder="5-digit Code" :rules="codeRules" required v-model="verificationCode")
					template(v-if="smsError")
						p.error SMS wasn't sent. Please try again later
					p.mt-4.text-center
						b Terms
					v-layout.mt-3(align-center justify-center)
						v-flex(shrink)
							v-checkbox(v-model="agreed" color="primary" value required :rules="[v => !!v || 'You must agree to continue!']")
								div(slot="label")
									| I agree to FrontierPros 
									a(href="#") Terms Of use
									| &nbsp;and&nbsp;
									a(href="#")  Privacy Policy
					.text-center.mt-3.mx-auto(style="width: 250px;")
						v-btn.btn.primary.custom.full-width.large(@click="verifyPhone" :disabled="!valid") Next

</template>
<script>
import { APIServices } from "../../../api/api-services";

export default {
	data() {
		return {
			valid: true,
			confirmPhonePopup: true,
			codeSent: false,
			phoneNumber: null,
			phoneRules: [v => !!v || "Please enter phone number"],
			codeRules: [
				v =>
					!!v ||
					"Please enter the verification code sent to the specified phone number",
				v => (v && v.length == 5) || "Code must be 5 digits"
			],
			verificationCode: null,
			agreed: false,
			smsError: false
		};
	},
	computed: {},
	methods: {
		verifyPhone() {
			const self = this;
			if (this.$refs.phoneVerificationForm.validate()) {
				if (!this.codeSent) {
					APIServices
						.confirmations
						.sendPhoneConfirmationCode({ phoneNumber: this.phoneNumber })
						.then((res) => {
							console.log(res);
							if(res.data && res.data.success){
								self.codeSent = true;
							}
						})
						.catch(function(error) {
							self.smsError = true;
							console.log(error);
						});
				} else {
					APIServices
						.confirmations
						.verifyPhoneConfirmation({ code: self.verificationCode })
						.then((res) => {
							if(res.data && res.data.success){
								self.confirmPhonePopup = false;
								this.$router.push(`/provider/account/personal-info`);
							}
							console.log(res);
						})
						.catch((error) => {
							console.log(error);
						});
				}
			}
		}
	},
	mounted() {}
};
</script>

<style lang="scss">
</style>
